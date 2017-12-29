# Local Test: Windows, PowerShell
# runtest.ps1 -sce "1"
param (
    [string]$sce = "1"
 )

switch ($sce)
{
     '1' {
        cd ..\src\besvc
        # Run web backend
        $env:GO_RPCPORT = "36061"
        $env:GO_SCHTYPE = "web"

        Start-Process go -ArgumentList "run besvc.go"

        # Run img backend
        $env:GO_RPCPORT = "36071"
        $env:GO_SCHTYPE = "images"
        Start-Process go -ArgumentList "run besvc.go"

        # Run vid backend
        $env:GO_RPCPORT = "36081"
        $env:GO_SCHTYPE = "videos"
        Start-Process go -ArgumentList "run besvc.go"

        cd ..\fesvc
        # run frontend, MUST run at fesvc dire
        $env:GO_WEBBACKENDS="localhost:36061" # "localhost:36161,localhost:36061,..."
        $env:GO_IMGBACKENDS="localhost:36071"
        $env:GO_VIDBACKENDS="localhost:36081"
        Start-Process go -ArgumentList "run fesvc.go -mode seq -timeout 400"

        cd ..\..\test
     }

     '2' {
        cd ..\src\besvc
        # Run web backend
        $env:GO_RPCPORT = "36061"
        $env:GO_SCHTYPE = "web"

        Start-Process go -ArgumentList "run besvc.go"

        # Run img backend
        $env:GO_RPCPORT = "36071"
        $env:GO_SCHTYPE = "images"
        Start-Process go -ArgumentList "run besvc.go"

        # Run vid backend
        $env:GO_RPCPORT = "36081"
        $env:GO_SCHTYPE = "videos"
        Start-Process go -ArgumentList "run besvc.go"

        cd ..\fesvc
        # run frontend, MUST run at fesvc dir
        $env:GO_WEBBACKENDS="localhost:36061" # "localhost:36161,localhost:36061,..."
        $env:GO_IMGBACKENDS="localhost:36071"
        $env:GO_VIDBACKENDS="localhost:36081"
        Start-Process go -ArgumentList "run fesvc.go -timeout 400"

        cd ..\..\test
     }

    '3' {
        cd ..\src\besvc

        # Run web backend
        $env:GO_RPCPORT = "36061"
        $env:GO_SCHTYPE = "web"

        Start-Process go -ArgumentList "run besvc.go"

        # Run img backend
        $env:GO_RPCPORT = "36071"
        $env:GO_SCHTYPE = "images"
        Start-Process go -ArgumentList "run besvc.go"

        # Run vid backend
        $env:GO_RPCPORT = "36081"
        $env:GO_SCHTYPE = "videos"
        Start-Process go -ArgumentList "run besvc.go"
        
        # Run web backend
        $env:GO_RPCPORT = "36161"
        $env:GO_SCHTYPE = "web"
        Start-Process go -ArgumentList "run besvc.go"

        # Run img backend
        $env:GO_RPCPORT = "36171"
        $env:GO_SCHTYPE = "images"
        Start-Process go -ArgumentList "run besvc.go"

        # Run vid backend
        $env:GO_RPCPORT = "36181"
        $env:GO_SCHTYPE = "videos"
        Start-Process go -ArgumentList "run besvc.go"

        cd ..\fesvc

        # run frontend, MUST run at fesvc dir
        $env:GO_WEBBACKENDS="localhost:36061,localhost:36161"
        $env:GO_IMGBACKENDS="localhost:36171,localhost:36171"
        $env:GO_VIDBACKENDS="localhost:36081,localhost:36181"
        Start-Process go -ArgumentList "run fesvc.go -timeout 400"

        cd ..\..\test
     }

}






