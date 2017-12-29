// test tool to call backend server
package main

import (
	"context"
	"flag"
	"fmt"
	"log"

	pb "../search"
	"google.golang.org/grpc"
)

var (
	addr = flag.String("addr", "", "backend server")
)

func main() {

	flag.Parse()
	query := flag.Arg(0)

	fmt.Println("Debug:", *addr, query)

	conn, err := grpc.Dial(*addr, grpc.WithInsecure())
	if err != nil {
		log.Fatalf("fail to dial: %v", err)
	}
	client := pb.NewGoogleClient(conn)

	res, err := client.Search(context.Background(), &pb.Request{Query: query})

	if err != nil {
		panic("Error!")
	}
	fmt.Println("return:", res)

}
