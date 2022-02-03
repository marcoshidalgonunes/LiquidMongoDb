# LiquidMongoDb
This project is an application encompasing a back-end Web API written using [Liquid Framework](https://github.com/Avanade/Liquid-Application-Framework) for .NET Core and MongoDb as Database, plus a client front-end app written using [React](https://reactjs.net)

There is Container Orchestration Support for the solution with Docker-Compose. It includes observability with [ELK Stack](https://www.elastic.co/what-is/elk-stack) and [Grafana](https://grafana.com/).

## Setup without Docker
The MongoDb database should be created as explained in [Create a web API with ASP.NET Core and MongoDB](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-5.0&tabs=visual-studio).

## Setup with Docker
The back-end solution contains a docker-compose.yml for the container orchestration. The images for the observability components and MongoDb should be pulled from the corresponding repositories as seen in the docker-compose, using `docker pull <image-name>`.

The docker-compose.yml also references some docker volumes. They should be created using `docker create volume <volume-name>`.

The network for the orchestration is declared in docker-compose.yml.

### Docker Desktop

It is needed a valid [Docker License](https://www.docker.com/pricing) to work with [Visual Studio](https://visualstudio.microsoft.com/downloads/). As alternative, you can use a Linux Distro of preference (e.g. Ubuntu) and [Visual Studio Code](https://code.visualstudio.com/). Linux can run on [WSL](https://docs.microsoft.com/en-us/windows/wsl/).

## Observability Setup

For [ELK Stack](https://www.elastic.co/what-is/elk-stack) the docker-compose.yml provides the needed settings for [Kibana](https://www.elastic.co/kibana/) dashboards, including [Elasticsearch APM](https://www.elastic.co/apm/) data.

It is needed to setup a Elasticsearch [Grafana](https://grafana.com/) datasource, as seen in the screenshot below:

![Grafana Image](https://github.com/marcoshidalgonunes/LiquidMongoDb/blob/main/images/Grafana%20Settings%20Docker.png)


