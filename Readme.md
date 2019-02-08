# Introduction

This project was created to demonstrate basic structured logging using Splunk + .NET Core + Serilog.

# Running

Requirements:
- Windows
- Docker for Windows
- Docker swarm (just run `docker swarm init` once in your computer)
- .NET Core
- Bash

From bash, execute:
```
./run.sh
```

Wait .NET Application start.

Open .NET Application in the browser using url displayed in console.

Every time you hit the .NET Application it will generate logs in c:/logs

All json logs from c:/logs will be ingested into splunk automatically.

In parallel, splunk is initializing, when done, it will be accessible at:
http://localhost:8000

Login in splunk with credentials: admin password

Play with logs from .NET Application.

# Cleaning up resources

From bash, execute:
```
./cleanup.sh
```
