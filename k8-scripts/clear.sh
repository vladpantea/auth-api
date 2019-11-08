#!/bin/bash
echo Start clear Resources for Auth.API

kubectl delete secret auth-secret
kubectl delete configmap auth-configmap
kubectl delete deployments auth-api
kubectl delete svc auth-service

echo Done Clear Resources for Auth.API