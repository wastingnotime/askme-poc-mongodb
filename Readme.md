# Askme.Poc.MongoDb

The purpose of this POC is to demonstrate mongoDB.
It is not a performance benchmark or an in-deep analysis.
It's a kind of human inspection that gave us some understanding about mongoDB. 


## Requirements
* .net 7.0 runtime - to execute application
* nuget package manager - to restore dependencies for the application
* docker runtime - to execute mongodb server

## Target
* mongo driver 2.21
* .net 7.0

## Getting started

In this essay we are going to inspect some caracteristics of this database server.
We are about to do some simple database operations as create, retrieve, update and delete.
In order to execute our application we need to instanciate a mongodb server, we had choose 
docker for it.

### preparation
```
docker run -d -p 27017:27017 --name=askme-mongo mongo:latest
```

### running

use the IDE

just run or debug the application

### closing/cleaning  

get the container id 
```
 docker ps --filter name=askme-mongo
```

stop container
```
 docker stop <container id>
```

remove container
```
 docker rm <container id>
```


## References

* [official driver](https://www.mongodb.com/docs/drivers/csharp/v2.21)
