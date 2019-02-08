#!/bin/bash

set -e

mkdir -p c:/logs

docker stack deploy -c splunk-stack.yaml splunk

dotnet run -p LogGenerator/LogGenerator.Web/
