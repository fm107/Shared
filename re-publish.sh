#!/bin/bash

rm -rf /home/ubuntu/testing /app/heroku_output
git clone -b Lastest --single-branch https://github.com/fm107/testing.git
cd /home/ubuntu/testing
dotnet restore
dotnet publish WebTorrent.csproj --output /app/heroku_output --configuration Release
cd /app/heroku_output && sudo dotnet ./WebTorrent.dll --server.urls http://+:\80
