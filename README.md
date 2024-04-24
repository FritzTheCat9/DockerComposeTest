### Docker compose:
This repository contains two C# web APIs served in single docker-compose file.\
You can run this two APIs on docker on windows with windows environment varaibles: "windows.env".\
You can run this two APIs on docker on Raspberry Pi with linux environment varaibles: "linux.env".

The README.md file contains commands that will allow you to:
- create images of your APIs depending on picked system and environment variables
- add the images to the docker hub platform
- download the images to the Linux (Raspberry Pi) / Windows
- run the all APIs containers on the Linux (Raspberry Pi) / Windows

### Api 1 (dockercomposetest_api):
```
http://localhost:5000
https://localhost:5001
```
### Api 1 (dockercomposetest_api2):
```
http://localhost:5002
https://localhost:5003
```
### Build and up all containers (change environment variables depending on system You want to use):
```
docker-compose --env-file linux.env up -d --build
docker-compose --env-file windows.env up -d --build
--env-file - environment variables (other for different configuration / system)
-d - detached mode (services in the background, without blocking the command prompt)
--build - rebuild the docker images
```
### Docker compose up (create and start all containers)
```
docker-compose --env-file linux.env up -d
docker-compose --env-file windows.env up -d
```
### Stop / start Docker compose (only start or stop all containers)
```
docker-compose --env-file linux.env stop
docker-compose --env-file linux.env start
docker-compose --env-file windows.env stop
docker-compose --env-file windows.env start
```
### Docker compose down (stop and remove all containers)
```
docker-compose --env-file linux.env down
docker-compose --env-file windows.env down
```
### Docker compose push (push all containers to docker hub)
```
docker-compose --env-file linux.env push
docker-compose --env-file windows.env push
```
### Install Docker Compose on Raspberry Pi:
```
sudo apt install docker-compose
```
### Copy files to Raspberry Pi (change <raspberrypi_ip> to correct Raspberry Pi ip)
- Copy "docker-compose.yml" file to Raspberry Pi (using scp)
- Copy "linux.env" file to Raspberry Pi (using scp)
```
scp C:\Users\bartl\source\repos\DockerComposeTest\docker-compose.yml malinka@<raspberrypi_ip>:/home/malinka/Desktop/
scp C:\Users\bartl\source\repos\DockerComposeTest\linux.env malinka@<raspberrypi_ip>:/home/malinka/Desktop/
```
### Pull and run Docker Compose on Rapberry Pi / Windows:
```
docker-compose --env-file linux.env pull
docker-compose --env-file linux.env up -d
docker-compose --env-file windows.env pull
docker-compose --env-file windows.env up -d
```
### Check docker images and containers:
```
docker images
docker ps -a
```
### Test Apis:
```
curl http://localhost:5000/api
curl -k https://localhost:5001/api
curl http://localhost:5002/api
curl -k https://localhost:5003/api
-k - ignore certificate check
```
### Pull only single image if needed
```
docker pull fritzthecat9/dockercomposetest_api:LINUX
docker pull fritzthecat9/dockercomposetest_api2:LINUX
docker pull fritzthecat9/dockercomposetest_api:WINDOWS
docker pull fritzthecat9/dockercomposetest_api2:WINDOWS
```