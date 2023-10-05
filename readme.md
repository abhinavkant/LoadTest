# Load test a ASP.Net Core WebAPI

## Specification

1. ASP.Net  Core 7.0 with HTTPS
2. Haproxy with ssl-passthrough
3. Docker to contanarized the project
4. Docker compose to execute everything
5. K6 to load test the aplication
6. mkcert to create self sign certificate

## Create Self-Signed Certificate

```sh
mkcert -pkcs12 local.host.dev localhost 127.0.0.1

## p12 password is changeit

mv .\local.host.dev+2.p12 .\aspnetapp1.pfx
```

## Link to Visit

- https://webhostinggeeks.com/howto/how-to-enable-tls-1-3-in-haproxy/
- https://webhostinggeeks.com/howto/how-to-configure-haproxy-with-ssl-pass-through/
- https://webhostinggeeks.com/howto/how-to-enable-tls-1-3-in-haproxy/
- https://serversforhackers.com/c/using-ssl-certificates-with-haproxy

