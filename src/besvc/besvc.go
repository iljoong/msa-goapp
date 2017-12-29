// The backend command runs a Google server that returns fake results.
package main

import (
	"fmt"
	"log"
	"math/rand"
	"net"
	"net/http"
	_ "net/http/pprof"
	"os"
	"strconv"
	"time"

	pb "../search"
	"golang.org/x/net/context"
	"golang.org/x/net/trace"
	"google.golang.org/grpc"
)

var (
	rpcport int
	strport string
	schtype string

	schresult []pb.Result
	re        pb.Result
)

type server struct{}

// randomDuration returns a random duration up to max, at intervals of max/10.
func randomDuration(max time.Duration) time.Duration {
	return time.Duration(1+int64(rand.Intn(10))) * (max / 10)
}

// Search sleeps for a random interval then returns a string
// identifying the query and this backend.
func (s *server) Search(ctx context.Context, req *pb.Request) (*pb.Result, error) {
	d := randomDuration(100 * time.Millisecond)
	logSleep(ctx, d)

	select {
	case <-time.After(d):

		switch schtype {
		case "web":
			re = schresult[0]
			break
		case "images":
			re = schresult[1]
			break
		case "videos":
			re = schresult[2]
			break
		}

		return &pb.Result{
			Title:   re.Title, //"web",
			Url:     re.Url,
			Snippet: re.Snippet,
			Log:     fmt.Sprintf("result for [%s] from backend %d, process time %d sec", req.Query, rpcport, d/1000000),
		}, nil
	case <-ctx.Done():
		return nil, ctx.Err()
	}
}

func logSleep(ctx context.Context, d time.Duration) {
	if tr, ok := trace.FromContext(ctx); ok {
		tr.LazyPrintf("sleeping for %s", d)
	}
}

func main() {
	grpc.EnableTracing = true

	schresult = append(schresult, pb.Result{Title: "web", Url: "http://golang.org", Snippet: "The Go Programming Lanugage"})
	schresult = append(schresult, pb.Result{Title: "images", Url: "https://golang.org/doc/gopher/frontpage.png", Snippet: "Gopher mascot"})
	schresult = append(schresult, pb.Result{Title: "videos", Url: "https://youtu.be/f6kdp27TYZs", Snippet: "Google I/O 2012 - Go Concurrency Patterns"})

	strport = os.Getenv("GO_RPCPORT")
	if rpcport = 36060; strport != "" {
		rpcport, _ = strconv.Atoi(strport)
	}

	schtype = os.Getenv("GO_SCHTYPE")
	if schtype == "" {
		schtype = "web"
	}

	rand.Seed(time.Now().UnixNano())
	go http.ListenAndServe(fmt.Sprintf(":%d", rpcport+600), nil) // HTTP debugging
	lis, err := net.Listen("tcp", fmt.Sprintf(":%d", rpcport))   // RPC port
	if err != nil {
		log.Fatalf("failed to listen: %v", err)
	}

	log.Println("Backendservice running on port/debug port/schtype:", rpcport, rpcport+600, schtype)

	g := grpc.NewServer()
	pb.RegisterGoogleServer(g, new(server))
	g.Serve(lis)
}
