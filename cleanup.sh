#!/bin/bash

set -e

docker stack rm splunk

echo 'Waiting docker stop all containers'
sleep 20

docker container prune -f

docker volume rm -f splunk_splunk-etc splunk_splunk-var splunk_splunk-forwarder-etc splunk_splunk-forwarder-var
