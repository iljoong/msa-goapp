# VSTS

## Create an linux agent for VSTS

In order to build go source and release to docker registry, you need to create linux agent for VSTS.

[https://docs.microsoft.com/en-us/vsts/build-release/actions/agents/v2-linux](https://docs.microsoft.com/en-us/vsts/build-release/actions/agents/v2-linux)]

After configured agent, you need to manully install `go`, `protoc` and `docker`

- `go`: [https://golang.org/doc/install](https://golang.org/doc/install)

- `protoc`: [https://github.com/google/protobuf/releases](https://github.com/google/protobuf/releases)

- `docker`: [https://docs.docker.com/engine/installation/linux/docker-ce/ubuntu/#install-using-the-repository](https://docs.docker.com/engine/installation/linux/docker-ce/ubuntu/#install-using-the-repository)

note that if you get `permission error` while running docker, you need to add permission and then relogin/reboot. 

```
sudo usermod -a -G docker $USER
```

See following article for more information

[https://techoverflow.net/2017/03/01/solving-docker-permission-denied-while-trying-to-connect-to-the-docker-daemon-socket/](https://techoverflow.net/2017/03/01/solving-docker-permission-denied-while-trying-to-connect-to-the-docker-daemon-socket/)

## Create a project

Once you created the project, save source code to the project.

## Create build definition

Build defintion

- build besvc/fesvc using Shell Script with `src\build.sh`

- Copy Publish Artifact to `drop/besvc`

- Copy Publish Artifact to `drop/fesvc`

## Create release defintion

Release defintion

- build `besvc` image

- push `besvc` image to repo

- build `fesvc` image

- push `fesvc` image to repp
