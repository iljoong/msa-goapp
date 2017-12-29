# Helms

## Helm Basic 

### Install Helms

[https://github.com/kubernetes/helm/releases](https://github.com/kubernetes/helm/releases)

### Create chart

[https://docs.helm.sh/chart_template_guide/#getting-started-with-a-chart-template](https://docs.helm.sh/chart_template_guide/#getting-started-with-a-chart-template)

### Deloy chart

Deploy demo app using helm chart

```
helm install <chart>
```

- Delete chart

```
helm delete <deploy-name>
```

## Run Demo (sample chart)

### scenario #1- sync/sequential

```
helm install -n gomsa1 ./gomsa1
```

### scenario #2 - parallel/fan-out

```
helm install -n gomsa2 ./gomsa2
```

### scenario #3 - parallel, hedge request

```
helm install -n gomsa3 ./gomsa3
```

### Override command/entrypoint for frontend service

Update following line in `<chart>/templates/deployment.yaml`

```
command: ["/app/fesvc", "-timeout", "100"]
```

_NOTE 1_: K8S's `command` == docker's `entrypoint`

### Override default chart values

Update values in root `values.yaml`

```
reposecret: ""

frontend:
  name: fesvcmsa
  image: iljoong/fesvc:latest
  containerport: 8888
  containerport_debug: 8889
  besvcweb: besvcweb:36060
  besvcimg: besvcimg:36060
  besvcvid: besvcvid:36060
  timeout: 400

besvcimg:
  reposecret: ""
  image: "iljoong/besvc:latest"
besvcvid:
  reposecret: ""
  image: "iljoong/besvc:latest"
besvcweb:
  reposecret: ""
  image: "iljoong/besvc:latest"
```
