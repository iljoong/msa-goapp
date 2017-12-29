## Deploy to K8S

1. Add registry/acr key

If you're using private registry like ACR then add following secret to Kubernetes

```
kubectl create secret docker-registry "" --docker-server=http://<repo>.azurecr.io --docker-username=<user> --docker-password=<secret> --docker-email=user@mail.com

```

2. Deploy app

- Create from console, or create with CLI

```
kubectl create -f besvc-web.yaml
kubectl create -f besvc-img.yaml
kubectl create -f besvc-vid.yaml

kubectl create -f fesvc.yaml
```

see, sample yaml [besvc-web.yaml](./kube/besvc-web.yaml), [besvc-img.yaml](./kube/besvc-img.yaml), [besvc-vid.yaml](./kube/besvc-vid.yaml), [fesvc.yaml](./kube/fesvc.yaml)