package main

import (
	"context"
	"encoding/json"
	"flag"
	"fmt"
	"html/template"
	"log"
	"net/http"
	"os"
	"strings"
	"time"

	_ "net/http/pprof"

	"google.golang.org/grpc"

	pb "../search"
)

// TODO: config with env
var (
	// web
	webbackends   = "localhost:36061"
	webbackendsvr []pb.GoogleClient
	imgbackends   = "localhost:36071"
	imgbackendsvr []pb.GoogleClient
	vidbackends   = "localhost:36081"
	vidbackendsvr []pb.GoogleClient

	schmode = flag.String("mode", "para", "search mode [seq | para]")
	timeout = flag.Int("timeout", 100, "search timeout in msec")
)

type page struct {
	Title string
	Query string
	Body  string
}

type result struct {
	Result *pb.Result
	Err    error
}

func main() {

	flag.Parse()

	if webbe := os.Getenv("GO_WEBBACKENDS"); webbe != "" {
		webbackends = webbe
	}

	if imgbe := os.Getenv("GO_IMGBACKENDS"); imgbe != "" {
		imgbackends = imgbe
	}

	if vidbe := os.Getenv("GO_VIDBACKENDS"); vidbe != "" {
		vidbackends = vidbe
	}

	// grpc HTTP debugging
	grpc.EnableTracing = true
	//go http.ListenAndServe(":8889", nil) // don't need

	// initialize backend services
	webbackendsvr = setSearchBackends(webbackends, webbackendsvr)
	imgbackendsvr = setSearchBackends(imgbackends, imgbackendsvr)
	vidbackendsvr = setSearchBackends(vidbackends, vidbackendsvr)

	// http frontend
	http.HandleFunc("/", searchHandler)
	//http.HandleFunc("/", rootHandler)
	http.HandleFunc("/api/", apiHandler)

	fmt.Printf("serving on http://localhost:8888/\nmode = %s\ntimeout = %d\nwebbe = %s\nimgbe = %s\nvidbe = %s\n", *schmode, *timeout, webbackends, imgbackends, vidbackends)
	http.ListenAndServe(":8888", nil)
}

func setSearchBackends(beaddr string, besvr []pb.GoogleClient) []pb.GoogleClient {
	for _, addr := range strings.Split(beaddr, ",") {
		conn, err := grpc.Dial(addr, grpc.WithInsecure())
		if err != nil {
			log.Fatalf("fail to dial: %v", err)
		}
		client := pb.NewGoogleClient(conn)
		besvr = append(besvr, client)
	}

	return besvr
}

func rootHandler(w http.ResponseWriter, r *http.Request) {
	query := r.URL.Path[len("/"):]

	p := &page{Title: "Test", Query: query}

	t, _ := template.ParseFiles("index.html")

	t.Execute(w, p)
}

func searchHandler(w http.ResponseWriter, r *http.Request) {

	var (
		title string
		query string
		body  string
	)

	if title = "Sequential Test"; *schmode != "seq" {
		title = "Parallel Test"
	}

	if query = r.FormValue("search"); r.Method == "POST" {
		//query = r.FormValue("search")
		var results []result

		if *schmode == "seq" {
			results, _ = searchHandlerSeq(w, r, query)

		} else {
			results, _ = searchHandlerPara(w, r, query)
		}

		body = formatResult(results)
	}

	p := &page{Title: title, Query: query, Body: body}
	t, _ := template.ParseFiles("index.html")
	t.Execute(w, p)
}

// search parallel
func searchHandlerPara(w http.ResponseWriter, r *http.Request, query string) ([]result, time.Duration) {

	ctx, cancel := context.WithTimeout(context.Background(), time.Duration(*timeout)*time.Millisecond)
	defer cancel()

	req := &pb.Request{Query: query}

	var results []result

	start := time.Now()
	// fan-out
	c := make(chan result)
	go func() { c <- searchSearch(ctx, req, webbackendsvr) }()
	go func() { c <- searchSearch(ctx, req, imgbackendsvr) }()
	go func() { c <- searchSearch(ctx, req, vidbackendsvr) }()

	// fan-in
	for i := 0; i < 3; i++ {
		select {
		case result := <-c:
			results = append(results, result)
		}
	}

	elapsed := time.Since(start)

	return results, elapsed
}

// search sequentially
func searchHandlerSeq(w http.ResponseWriter, r *http.Request, query string) ([]result, time.Duration) {

	ctx, cancel := context.WithTimeout(context.Background(), time.Duration(*timeout)*time.Millisecond)
	defer cancel()

	req := &pb.Request{Query: query}

	start := time.Now()
	var results []result
	results = append(results, searchSearch(ctx, req, webbackendsvr))
	results = append(results, searchSearch(ctx, req, imgbackendsvr))
	results = append(results, searchSearch(ctx, req, vidbackendsvr))

	elapsed := time.Since(start)

	return results, elapsed
}

func apiHandler(w http.ResponseWriter, r *http.Request) {
	query := r.URL.Path[len("/api/"):]

	var (
		results []result
		title   string
		elapsed time.Duration
	)

	if title = "Sequential Test"; *schmode == "seq" {
		results, elapsed = searchHandlerSeq(w, r, query)

	} else {
		title = "Parallel Test"
		results, elapsed = searchHandlerPara(w, r, query)
	}

	body := formatResult(results)
	w.Header().Set("Content-Type", "application/json")
	fmt.Fprintf(w, "{\n\"version\": \"v1\",\n\"mode\": \"%s\",\n\"results\": %s,\n\"time\": %d\n}", title, body, elapsed/1000000)
}

func searchSearch(ctx context.Context, req *pb.Request, backendsrvr []pb.GoogleClient) result {
	c := make(chan result)

	for _, b := range backendsrvr {
		go func(backend pb.GoogleClient) {
			res, err := backend.Search(ctx, req)
			c <- result{res, err}
		}(b)
	}
	return <-c
}

func formatResult(results []result) string {

	jsonByte, err := json.MarshalIndent(results, "", "    ")
	if err != nil {
		panic(err)
	}

	return string(jsonByte)
}
