#!/usr/bin/env bash

# get pakcage
go get github.com/golang/protobuf/proto
go get golang.org/x/net/context
go get golang.org/x/net/trace
go get google.golang.org/grpc

# build go-binaries
echo "building go binaries..."

go build -v -o ../src/besvc/bin/besvc ./besvc/besvc.go

go build -v -o ../src/fesvc/bin/fesvc ./fesvc/fesvc.go

# docker build
echo "building docker images..."

docker build -t iljoong/besvc ../src/besvc

docker build -t iljoong/fesvc ../src/fesvc
