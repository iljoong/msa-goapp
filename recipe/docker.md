# Docker

## Docker image

- Build besvc & fesvc

```
docker build -t iljoong/besvc .

docker build -t iljoong/fesvc .
```

## Docker run (local test)

- backend

```
docker run -p 36061:36060 -e GO_SCHTYPE=web -d iljoong/besvc
docker run -p 36071:36060 -e GO_SCHTYPE=images -d iljoong/besvc
docker run -p 36081:36060 -e GO_SCHTYPE=videos -d iljoong/besvc
```

- frontend

```
docker run -p 8088:8888 -e GO_WEBBACKENDS=<host>:36061 \
-e GO_IMGBACKENDS=<host>:36071 \
-e GO_VIDBACKENDS=<host>:36081 \
-d iljoong/fesvc
```

- redundancy 

```
docker run -p 36161:36060 -e GO_SCHTYPE=web -d iljoong/besvc
docker run -p 36171:36060 -e GO_SCHTYPE=images -d iljoong/besvc
docker run -p 36181:36060 -e GO_SCHTYPE=videos -d iljoong/besvc

docker run -p 8088:8888 -e GO_WEBBACKENDS=<host>:36061,<host>:36161 \
-e GO_IMGBACKENDS=<host>:36071,<host>:36171 \
-e GO_VIDBACKENDS=<host>:36081,<host>:36181 \
-d iljoong/fesvc
```

## Docker push to Docker hub

docker login  -u <user> -p <key>

docker push iljoong/besvc
docker push iljoong/fesvc

## Docker push to ACR (private registry)

- Login to registry
```
docker login <reop>.azurecr.io -u <user> -p <key>
```

- Tag 

```
docker tag iljoong/besvc <repo>.azurecr.io/besvc
docker tag iljoong/fesvc <repo>.azurecr.io/fesvc
```

- Push to regsitry

```
docker push <repo>.azurecr.io/besvc
docker push <repo>.azurecr.io/fesvc
```

