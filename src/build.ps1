# build script for windows environment

# $env:GOROOT=C:\Go\
# $env:PATH=$env:PATH;C:\Go\bin

# install package
go get github.com/golang/protobuf/proto
go get golang.org/x/net/context
go get golang.org/x/net/trace
go get google.golang.org/grpc

# build
go build -o ./fesvc/bin/fesvc.exe ./fesvc/fesvc.go
go build -o ./besvc/bin/besvc.exe ./besvc/besvc.go