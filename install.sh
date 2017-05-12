#!/bin/bash

sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ xenial main" > /etc/apt/sources.list.d/dotnetdev.list'
sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 417A0893
sudo apt-get -y update

sudo apt-get install -y dotnet-dev-1.0.4 nodejs nodejs-legacy npm libunwind8 gettext

git clone -b Lastest --single-branch  https://github.com/fm107/testing.git

sudo npm install -g bower

sudo mkdir -p /app/heroku_output/ && sudo chown -R 1000:1000 /app

cd testing

dotnet restore
dotnet publish WebTorrent.csproj --output /app/heroku_output --configuration Release

curl --silent --location http://download.ap.bittorrent.com/track/beta/endpoint/utserver/os/linux-x64-ubuntu-13-04 | tar xz
mv utorrent-server-alpha-v3_3 /app/utorrent-server
curl -o /app/utorrent-server/utserver.conf https://raw.githubusercontent.com/fm107/heroku-buildpack-utorrent/master/bin/utserver.conf
 
cd /app/heroku_output && sudo dotnet ./WebTorrent.dll --server.urls http://+:\80
