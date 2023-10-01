# Load test a ASP.Net Core WebAPI

## Specification

1. ASP.Net  Core 7.0 with HTTPS
2. Haproxy with ssl-passthrough
3. Docker to contanarized the project
4. Docker compose to execute everything
5. K6 to load test the aplication

## Create Certificate

```sh
mkcert -pkcs12 local.host.dev localhost 127.0.0.1

## p12 password is changeit

mv .\local.host.dev+2.p12 .\aspnetapp1.pfx
```
