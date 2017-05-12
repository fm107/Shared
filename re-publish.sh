#!/bin/bash

rm -rf /home/ubuntu/testing
git clone -b Lastest --single-branch https://github.com/fm107/testing.git
dotnet restore
dotnet publish WebTorrent.csproj --output /app/heroku_output --configuration Release
cd /app/heroku_output && sudo dotnet ./WebTorrent.dll --server.urls http://+:\80
