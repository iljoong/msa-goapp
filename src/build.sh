#!bin/bash
#build script for linux environment
export GOROOT=/usr/local/go
export PATH=PATH:/usr/local/go/bin

# loggng
#pwd
#whoami 

# install package
go get github.com/golang/protobuf/proto
go get golang.org/x/net/context
go get golang.org/x/net/trace
go get google.golang.org/grpc

# build
go build -o ./fesvc/bin/fesvc ./fesvc/fesvc.go
go build -o ./besvc/bin/besvc ./besvc/besvc.go