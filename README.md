# C#-REST-Client-Examples by DNA-Evolutions


<a href="https://dna-evolutions.com/" target="_blank"><img src="https://www.dna-evolutions.com/images/dna_logo.png" width="200"
title="DNA Evolutions" alt="DNA Evolutions"></a>


Containerizing an application helps to use it more conveniently across different platforms and, most importantly, as a microservice. Further, scaling an application becomes more straightforward as various standardized orchestration tools can be utilized. A Microservice can be launched either (locally) or, for example, as a highly-scalable web-micro-service in a Kubernetes cluster.

---

# About this project

This repository provides C# examples for interacting with the **JOpt TourOptimizer REST API** by DNA Evolutions. JOpt TourOptimizer is a route optimization and scheduling engine for transportation, field service, and resource planning scenarios. It solves tour-optimization problems with complex constraints such as time windows, skills, capacities, zone-based routing, and mandatory requirements.

The examples demonstrate two integration modes:

- **Synchronous runs** (`OptimizationApi`): The client submits an optimization via `POST /api/v1/runs`, receives a `runId`, subscribes to Server-Sent Event (SSE) streams for real-time progress and status updates, and retrieves the result once complete. Suitable for on-premise deployments with synchronous mode enabled.

- **Asynchronous jobs** (`JobApi`): The client submits a fire-and-forget job via `POST /api/v1/jobs`, receives a `jobId`, and can poll for status, progress, warnings, errors, and the final result at any time. All job endpoints are tenant-scoped via the `X-Tenant-Id` header. Suitable for all deployments with a connected database.

The generated REST client is built from the OpenAPI 3 specification using the [openapi-csharp generator](https://openapi-generator.tech/docs/generators/csharp/).

---

# Compatibility
This client can be used with <a href="https://hub.docker.com/r/dnaevolutions/jopt_touroptimizer" target="_blank">JOpt-TourOptimizer Spring Server</a>
Compatible Versions:
- **1.3.5-SNAPSHOT or newer** (<a href="https://github.com/DNA-Evolutions/Java-REST-Client-Examples/blob/master/src/main/resources/swagger/touroptimizer/spec/touroptimizer_spec.json" target="_blank">Specs</a>)

> **Note:** Versions prior to 1.3.5 used different API class names (e.g. `OptimizationServiceControllerApi`) and are **not** compatible with this client.

---

# Further Documentation, Contact and Links

- Documentation Hub - <a href="https://www.dna-evolutions.com/docs/getting-started" target="_blank">dna-evolutions.com/docs/getting-started</a>
- Special features - <a href="https://dna-evolutions.com/docs/learn-and-explore/special/special_features" target="_blank">Overview of special features</a>
- Nexus repository - <a href="https://nexus.dna-evolutions.net" target="_blank">nexus.dna-evolutions.net</a>
- Our official JavaDocs 		- <a href="https://public.javadoc.dna-evolutions.com" target="_blank">public.javadoc.dna-evolutions.com</a>
- Our YouTube channel - <a href="https://www.youtube.com/channel/UCzfZjJLp5Rrk7U2UKsOf8Fw" target="_blank">DNA Tutorials</a>
- TourOptimizer server guide - <a href="https://dna-evolutions.com/docs/learn-and-explore/rest/rest-server-touroptimizer" target="_blank">REST server documentation</a>
- Our DockerHub channel - <a href="https://hub.docker.com/u/dnaevolutions" target="_blank">DNA DockerHub</a>
- Our LinkedIn channel - <a href="https://www.linkedin.com/company/dna-evolutions/" target="_blank">DNA LinkedIn</a>


If you need any help, don't hesitate to get in contact with us via our company website <a href="https://www.dna-evolutions.com" target="_blank">www.dna-evolutions.com</a> or write an email to <a href="mailto:info@dna-evolutions.com">info@dna-evolutions.com</a>.


---


# Short Introduction
This repository is part of our JOpt-REST-Suite. It provides examples of how to set up a REST client in C# to access the following DNA Evolution's web services:

- JOpt-TourOptimizer based on JOpt-Core (available as a local Container and via Azure)

All our RESTful Services utilize <a href="https://docs.spring.io/spring/docs/current/spring-framework-reference/web-reactive.html" target="_blank">Spring WebFlux</a> and <a href="https://swagger.io/" target="_blank">Swagger</a>. Internally the Java version of TourOptimizer is used. Indeed all specifications for the different services are derived from the core library, leading to guaranteed compatibility between all three services.

<a href="https://dna-evolutions.com/" target="_blank"><img src="https://www.dna-evolutions.com/images/docs/home/Part_Environment.svg" width="90%"
title="Integration environments" alt="Integration environments"></a>

### JOpt-TourOptimizer
Optimize a problem consisting of Nodes, Resources, and optionally externally provided connections. In contrast to our other services, we allow you to host your JOpt-TourOptimizer locally. Please refer to <a href="https://github.com/DNA-Evolutions/Docker-REST-TourOptimizer#how-to-start-jopttouroptimizer-docker" target="_blank">"How to start JOpt TourOptimizer in docker"</a> for more help.

---

# Outline of this repository

Examples</a>
1. <a href="https://github.com/DNA-Evolutions/C-Sharp-REST-Client-Examples/tree/master/src/Dna.Example/TourOptimizer" target="_blank">TourOptimizer Examples</a>

Each of the sections has its README.

---

# Project Structure

```
DNA.Evolutions.Csharp.Rest.sln
|
+-- src/Org.OpenAPITools/          Auto-generated REST client (API + Model classes)
|   +-- Api/
|   |   +-- OptimizationApi.cs     Synchronous run endpoints (POST /api/v1/runs, ...)
|   |   +-- JobApi.cs              Async job endpoints (POST /api/v1/jobs, ...)
|   |   +-- StreamApi.cs           SSE stream endpoints (progress, status, warnings, errors)
|   |   +-- HealthApi.cs           Health check endpoint
|   +-- Model/                     Data transfer objects (RestOptimization, Node, Resource, ...)
|
+-- src/Dna.Utils/                 Utility/wrapper library
|   +-- endpoints/                 Server URL constants
|   +-- restcaller/                TourOptimizerRestCaller - high-level API wrapper
|   +-- testinputcreation/         Factories for test nodes, resources, positions
|
+-- src/Dna.Example/               Runnable example projects
|   +-- TourOptimizer/
|       +-- optimize/              Synchronous optimization (local + Docker + zone-travel)
|       +-- constraint/            Constraint violation example
|       +-- optimizeFAF/           Fire-and-forget job submission
|       +-- searchFAF/             Search persisted jobs by metadata
|       +-- loadFAF/               Load a persisted job result by jobId
|
+-- src/Org.OpenAPITools.Test/     Auto-generated API test stubs
```

---

# The architecture of the generated REST-Client-API

The C#-REST-Client class files used by the examples of this repository were generated utilizing the <a href="https://openapi-generator.tech/docs/generators/csharp/" target="_blank">openapi-csharp Generator</a>  by <a href="https://github.com/OpenAPITools" target="_blank">OpenAPI Tools</a>.

For creating the models, we used the containerized version of Open-API-Generator by calling:

```xml
docker run --rm -v "${PWD}:/local" openapitools/openapi-generator-cli generate  -i '/local/swagger/touroptimizer/spec/touroptimizer_spec.json' -g csharp -o /local/generated/dna-csharp-models --library=httpclient --additional-properties=targetFramework=net8.0
```

where `${PWD}` needs to be adjusted to find the Open-API-docs under `/local/swagger/touroptimizer/spec/touroptimizer_spec.json` when mounting the volume `${PWD}` into `/local`. Calling the command will generate the folders `/Org.OpenApiTools` and `/Org.OpenApiTools.Test` that are also part of this repository. You can find the `touroptimizer_spec.json` <a href="https://github.com/DNA-Evolutions/C-Sharp-REST-Client-Examples/blob/master/res/swagger/touroptimizer/spec/touroptimizer_spec.json" target="_blank">here</a>.

You can also generate a client in the programming language of your choice utilizing our API-docs. REST facilitates software integration in your desired language (including famous ones like C#, Java, JS, Scala, Python, and many more ). Don't hesitate to reach out to us if you need help setting up your client.


For setting up a local test environment with database support, please refer to the separate **Hands-on Tutorial: Setting Up a Local Fire and Forget TourOptimizer-Database Test Environment** [tutorial](https://github.com/DNA-Evolutions/Docker-REST-TourOptimizer/blob/main/TourOptimizerWithDatabase.md).

---

# Getting started

You can start using our examples:

* [Clone this repository](#clone-this-repository)
* [Use our sandbox in your browser (Docker required)](#use-our-sandbox-in-your-browser-docker-required)


## Clone this repository
Clone this repository and open it, for example, with Visual Code. The `DNA.Evolutions.Csharp.Rest.sln` file contains three util-projects that need to be built. In addition, it contains multiple example-projects that will be built.

### Prerequisites

* .NET SDK 8.x <a href="https://dotnet.microsoft.com/en-us/download/dotnet/8.0" target="_blank">(link)</a>
* Working Docker environment for local TourOptimizer instance
* **JOpt TourOptimizer Server 1.3.5+** running locally or accessible via Azure


### Build necessary files
You can call (from the main folder):

```bash
dotnet restore
dotnet build
```

The call will generate the `OpenApiTools.dll`, `Dna.Utils.dll` and the example-executables (e.g. `TourOptimizerExample.exe`) and will download all dependencies. The target-framework is `net8.0`. You can also use Microsoft Visual Studio and perform the standard solution build process.
 
### Run the examples

You can run the examples directly with `dotnet run`:

```bash
# Basic synchronous optimization
dotnet run --project src/Dna.Example/TourOptimizer/optimize/TourOptimizerExample.csproj

# Run from inside a Docker container (uses host.docker.internal)
dotnet run --project src/Dna.Example/TourOptimizer/optimize/TourOptimizerDockerExample.csproj

# Zone-travel optimization (Manhattan + New Jersey City)
dotnet run --project src/Dna.Example/TourOptimizer/optimize/TourOptimizerZoneTravelExample.csproj

# Constraint violation example
dotnet run --project src/Dna.Example/TourOptimizer/constraint/TourOptimizerConstraintExample.csproj

# Fire-and-forget job submission (requires database)
dotnet run --project src/Dna.Example/TourOptimizer/optimizeFAF/TourOptimizerFAFExample.csproj

# Search persisted jobs
dotnet run --project src/Dna.Example/TourOptimizer/searchFAF/TourOptimizerSearchFAFExample.csproj

# Load a persisted job result
dotnet run --project src/Dna.Example/TourOptimizer/loadFAF/TourOptimizerLoadFAFExample.csproj
```

By default, the examples expect a locally running TourOptimizer at <a href="http://localhost:8081" target="_blank">http://localhost:8081</a>.


## Use our sandbox in your browser (Docker required)
If you want to get started without the hassle of installing C# and an IDE, we provide a sandbox. The sandbox is based on  [code-server](https://github.com/cdr/code-server) and can be used inside your browser, and the interface itself is based on Visual Code. The sandbox is available via DockerHub ([here](https://hub.docker.com/r/dnaevolutions/jopt_net_example_server)). You have to host the sandbox in your Docker environment (Please provide at least 2-4Gb of Ram and 2 Cores). You can pull the sandbox from our DockerHub account (The Dockerfile for creating the sandbox is included in this repository). The latest version of our examples is cloned by default on launching the Docker container, and you can start testing JOpt-REST right away.


### Starting the sandbox and persist your changes
You must mount a volume to which the examples of this project are downloaded on the container's startup. After re-launching the container, the latest version of our examples is only cloned if the folder is not already existing, keeping your files safe from being overridden.

Launching a sandbox and mount your current directory ('$PWD') or any other directory you want:

```
docker run -it -d --name jopt-net-rest-examples -p 127.0.0.1:8023:8080 -v "$PWD/:/home/coder/project" dnaevolutions/jopt_net_example_server:latest
```

Please wait some time before attempting to login with your browser (1-2 minutes). You can also check the logs of the container. Plugins etc. need to be installed. After your first login,  [OmniSharp](https://github.com/OmniSharp) is installed. This also take some time.

### Using the sandbox

After starting the container, you can open [http://localhost:8023/](http://localhost:8023) with your browser and login with the password:

```
joptrest
```

### Running an example

You can start testing with `TourOptimizerDockerExample.cs` (assuming you are locally running a JOptTourOptimizer Server at port 8081). You can run it from the terminal:

```bash
dotnet run --project /home/coder/project/csharp.rest.examples/src/Dna.Example/TourOptimizer/optimize/TourOptimizerDockerExample.csproj
```

### Modify an example
Modify any `cs` file in `DNA.Example` folder. The `dotnet run` command will automatically rebuild before running.

### Add an example

```bash
dotnet sln DNA.Evolutions.Csharp.Rest.sln add src/Dna.Example/TourOptimizer/optimize/NewProject.csproj

dotnet build DNA.Evolutions.Csharp.Rest.sln
```

### Common problems: ###

- If you see an error like this:

```
Unhandled exception. System.AggregateException: One or more errors occurred. (Connection refused (localhost:8081))
 ---> System.Net.Http.HttpRequestException: Connection refused (localhost:8081)
 ---> System.Net.Sockets.SocketException (111): Connection refused
```

You are trying to connect to a local JOpt server but have not adjusted the endpoint. Remember, the sandbox is a docker container and you need to connect to it via the endpoint `http://host.docker.internal:8081` instead of ~`http://localhost:8081`~. You can run `TourOptimizerDockerExample.cs` from the namespace `Optimize` where `Endpoints.LOCAL_SWAGGER_TOUROPTIMIZER_FROM_DOCKER_URL` is used instead of `Endpoints.LOCAL_SWAGGER_TOUROPTIMIZER_URL`.


- If you see an error like this:

```
Build failed
```

simply try again.

---



## Why use JOpt products from DNA Evolutions?
JOpt is a flexible routing optimization engine written in Java, allowing to solve tour-optimization problems that are highly restricted. For example, regarding time windows, skills, and even mandatory constraints can be applied.

Click to open our video:

<a href="https://www.youtube.com/watch?v=U4mDQGnZGZs" target="_blank"><img src="https://dna-evolutions.com/images/docs/home/jopt_intro_prev.gif" width="600"
title="Introduction to JOpt" alt="Introduction to JOpt"></a>

---

## Agreement
For reading our license agreement and for further information about license plans, please visit <a href="https://www.dna-evolutions.com" target="_blank">www.dna-evolutions.com</a>.

--- 

## Authors
A product by [DNA Evolutions GmbH](https://www.dna-evolutions.com) &copy;