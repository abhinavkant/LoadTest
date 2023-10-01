# Load test a ASP.Net Core WebAPI

## Create Certificate

```sh
mkcert -pkcs12 local.host.dev localhost 127.0.0.1

## p12 password is changeit

mv .\local.host.dev+2.p12 .\aspnetapp1.pfx
```
