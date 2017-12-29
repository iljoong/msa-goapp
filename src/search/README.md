## GO

Compile proto to `go` interface file

```
protoc ./search.proto --go_out=plugins=grpc:.
```

## C#

Compile proto to `c#` interface file

```
set PROTOC=%UserProfile%\.nuget\packages\Google.Protobuf.Tools\3.2.0\tools\windows_x64\protoc.exe
set PLUGIN=%UserProfile%\.nuget\packages\Grpc.Tools\1.2.2\tools\windows_x64\grpc_csharp_plugin.exe

%PROTOC% -I./ --csharp_out=../fedotnet ./search.proto --grpc_out ../fedotnet --plugin=protoc-gen-grpc=%PLUGIN% 
```

Add `fedotnet` namespace name in `fedotnet/SearchGrpc.cs`
