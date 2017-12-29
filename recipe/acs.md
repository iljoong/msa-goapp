# ACS - K8S

It is recommned to use managed K8S like AKS. Incase of you cannot provision AKS, use ACS-Engile to create a K8S.

0. install acs-engine

https://github.com/Azure/acs-engine/blob/master/docs/acsengine.md

1. create acs/k8s cluster

- prepare two secretes

	- sshkey for connecting master
	- azure service principal id/key for creating resource

- prepare [kubernetes.json](https://raw.githubusercontent.com/Azure/acs-engine/master/examples/kubernetes.json)

- create resource group

```
az group create -l <location> -n <rgname>
```

- deploy k8s

```
acs-engine deploy --subscription-id <subsid> \
    --dns-prefix <prefix> \
    --resource-group <group> --location <loc> \
    --auto-suffix --api-model ./kubernetes.json \
    --auth-method client_secret \
    --client-id <client-id> \
    --client-secret <client-key>
```

see sample [kubernetes.json](./acs/kubernetes.json)

2. connect k8s

- copy k8s config

```
scp user@<k8s master ip>:~/.kube/config ~/.kube/
```

- Launch console

```
kubectl proxy
```

- browse `http://localhost:8001/ui`