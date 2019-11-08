#!/bin/bash
echo Start of K8 Setup For Auth.API
kubectl create secret generic auth-secret --from-literal=username=$1 --from-literal=password=$2 --from-literal=secret=$3
kubectl create configmap auth-configmap --from-literal=audience='Emailer.API' --from-literal=issuer='Auth.API'
kubectl apply -f ./auth-deployment.yaml
kubectl apply -f ./auth-service.yaml

echo End of K8 Setup For Auth.API
