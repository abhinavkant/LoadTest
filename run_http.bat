docker build -t sampleapp:latest -f Dockerfile .

docker run --rm -it -p 8000:8080 -e ASPNETCORE_URLS="http://+" -e ASPNETCORE_HTTP_PORT=8080 -e ASPNETCORE_ENVIRONMENT=Development sampleapp:latest