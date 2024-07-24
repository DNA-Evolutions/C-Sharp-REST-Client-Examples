# C#-REST-Client-Examples by DNA-Evolutions


<a href="https://dna-evolutions.com/" target="_blank"><img src="https://docs.dna-evolutions.com/indexres/dna-temp-logo.png" width="110"
title="DNA-Evolutions" alt="DNA-Evolutions"></a>


Containerizing an application helps to use it more conveniently across different platforms and, most importantly, as a microservice. Further, scaling an application becomes more straightforward as various standardized orchestration tools can be utilized. A Microservice can be launched either (locally) or, for example, as a highly-scalable web-micro-service in a Kubernetes cluster.

---

# Compatibility
This client can be used with <a href="https://hub.docker.com/r/dnaevolutions/jopt_touroptimizer" target="_blank">JOpt-TourOptimizer Spring Server</a>
Compatible Versions:
- 1.2.6-SNAPSHOT (this version was used to create the models of this repository)
- 1.2.7-SNAPSHOT (<a href="https://github.com/DNA-Evolutions/Java-REST-Client-Examples/blob/master/src/main/resources/swagger/touroptimizer/spec/touroptimizer_spec.json" target="_blank">Specs</a> )

---

# Further Documentation, Contact and Links

- Further documentation 	- <a href="https://docs.dna-evolutions.com" target="_blank">docs.dna-evolutions.com</a>
- Special features 	- <a href="https://docs.dna-evolutions.com/overview_docs/special_features/Special_Features.html" target="_blank">Overview of special features</a>
- Our official repository 	- <a href="https://public.repo.dna-evolutions.com" target="_blank">public.repo.dna-evolutions.com</a>
- Our official JavaDocs 		- <a href="https://public.javadoc.dna-evolutions.com" target="_blank">public.javadoc.dna-evolutions.com</a>
- Our YouTube channel - <a href="https://www.youtube.com/channel/UCzfZjJLp5Rrk7U2UKsOf8Fw" target="_blank">DNA Tutorials</a>
- Documentation - <a href="https://docs.dna-evolutions.com/rest/touroptimizer/rest_touroptimizer.html" target="_blank">DNA's RESTful Spring-TourOptimizer in Docker </a>
- Our DockerHub channel - <a href="https://hub.docker.com/u/dnaevolutions" target="_blank">DNA DockerHub</a>
- Our LinkedIn channel - <a href="https://www.linkedin.com/company/dna-evolutions/" target="_blank">DNA LinkedIn</a>


If you need any help, don't hesitate to get in contact with us via our company website <a href="https://www.dna-evolutions.com" target="_blank">www.dna-evolutions.com</a> or write an email to <a href="mailto:info@dna-evolutions.com">info@dna-evolutions.com</a>.


---


# Short Introduction
This repository is part of our JOpt-REST-Suite. It provides examples of how to set up a REST client in C# to access the following DNA Evolution's web services:

- JOpt-TourOptimizer based on JOpt-Core (available as a local Container and via Azure)

The service can be called via an API-Key using our Microsoft Azure-Kubernetes Infrastructure. If you are interested in hosting our JOpt-REST-GeoCoder and JOpt-REST-GeoRouter products in your environment, please get in contact with us.

All our RESTful Services utilize <a href="https://docs.spring.io/spring/docs/current/spring-framework-reference/web-reactive.html" target="_blank">Spring WebFlux</a> and <a href="https://swagger.io/" target="_blank">Swagger</a>. Internally the Java version of TourOptimizer is used. Indeed all specifications for the different services are derived from the core library, leading to guaranteed compatibility between all three services.

<a href="https://dna-evolutions.com/" target="_blank"><img src="https://docs.dna-evolutions.com/indexres/dna-evolutions-product-infographic-jopt-cloud-integration-highres.svg" width="600"
title="DNA-Evolutions Integration" alt="DNA-Evolutions Integration"></a>

### JOpt-TourOptimizer
Optimize a problem consisting of Nodes, Resources, and optionally externally provided connections. In contrast to our other services, we allow you to host your JOpt-TourOptimizer locally. Please refer to <a href="https://github.com/DNA-Evolutions/Docker-REST-TourOptimizer#how-to-start-jopttouroptimizer-docker" target="_blank">"How to start JOpt TourOptimizer in docker"</a> for more help.

---

# Outline of this repository

Examples</a>
1. <a href="https://github.com/DNA-Evolutions/C-Sharp-REST-Client-Examples/tree/master/src/Dna.Example/TourOptimizer" target="_blank">TourOptimizer Examples</a>

Each of the sections has its README.

---


# The architecture of the generated REST-Client-API

The C#-REST-Client class files used by the examples of this repository were generated utilizing the <a href="https://openapi-generator.tech/docs/generators/csharp/" target="_blank">openapi-csharp Generator</a>  by <a href="https://github.com/OpenAPITools" target="_blank">OpenAPI Tools</a>.

For creating the models, we used the containerized version of Open-API-Generator by calling:

```xml
docker run --rm -v "${PWD}:/local" openapitools/openapi-generator-cli generate  -i '/local/swagger/touroptimizer/spec/touroptimizer_spec.json' -g csharp -o /local/generated/dna-csharp-models --library=httpclient
```

where `${PWD}` needs to be adjusted to find the Open-API-docs under `/local/swagger/touroptimizer/spec/touroptimizer_spec.json` when mounting the volume `${PWD}` into `/local`. Calling the command will generate the folders `/Org.OpenApiTools` and `/Org.OpenApiTools.Test` that are also part of this repository. You can find the `touroptimizer_spec.json` <a href="https://github.com/DNA-Evolutions/C-Sharp-REST-Client-Examples/blob/master/res/swagger/touroptimizer/spec/touroptimizer_spec.json" target="_blank">here</a>.

You can also generate a client in the programming language of your choice utilizing our API-docs. REST facilitates software integration in your desired language (including famous ones like C#, Java, JS, Scala, Python, and many more ). Don't hesitate to reach out to us if you need help setting up your client.


For setting up a local test enviorment with database support, please refer to the separate **Hands-on Tutorial: Setting Up a Local Fire and Forget TourOptimizer-Database Test Environment** [tutorial](https://github.com/DNA-Evolutions/Docker-REST-TourOptimizer/blob/main/TourOptimizerWithDatabase.md).

---

# Getting started

You can start using our examples:

* [Clone this repository](#clone-this-repository)
* [Use our sandbox in your browser (Docker required)](#use-our-sandbox-in-your-browser-docker-required)


## Clone this repository
Clone this repository and open it, for example, with Visual Code. The `DNA.Evolutions.Csharp.Rest.sln` file contains three util-projects that need to be built. In addition, it contains multiple example-projects that will be built.

### Prerequisites

* Dotnet SKD 8.x <a href="https://dotnet.microsoft.com/en-us/download/dotnet/8.0" target="_blank">(link)</a>
* Working Docker environment for local TourOptimizer instance


### Build necessary files
You can call (from the main folder):

```bash
dotnet restore
dotnet build
```

The call will generate the `OpenApiTools.dll`, `Dna.Utils.dll` and the example-executables (e.g. `TourOptimizerExample.exe`) and will download all dependencies. The target-framework is `netstandard2.0` (for the libraries) and `net8.0` (for the executables). You can also use Microsoft Visual Studio and perform the standard solution build process.
 
### Run the examples

For example, go to `src\Dna.Example\TourOptimizer\optimize\bin\Debug\net8.0\` and call the executable `TourOptimizerExample.exe`. By default, it expects a locally running TourOptimizer at <a href="http://localhost:8081" target="_blank">http://localhost:8081</a>.


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

You can start testing with `TourOptimizerDockerExample.cs` (assuming you are locally running a JOptTourOptimizer Server at port 8081). The `dll` should be already created on first startup of the container.

You can run the `dll` by calling from the [terminal](https://code.visualstudio.com/docs/terminal/basics):

```bash
dotnet /home/coder/project/csharp.rest.examples/src/Dna.Example/TourOptimizer/optimize/bin/Debug/net8.0/TourOptimizerDockerExample.dll
```

### Modify an example
Modify any `cs` file in `DNA.Example` folder. Afterwards, call:

```bash
dotnet restore
dotnet build
```

from the [terminal](https://code.visualstudio.com/docs/terminal/basics) and call your modified dll by

```bash
dotnet /home/coder/project/csharp.rest.examples/YOUR_MODIFIED_DLL_PATH
```

### Common problems: ###

- If you see the an error like this:

```
Unhandled exception. System.AggregateException: One or more errors occurred. (Connection refused (localhost:8081))
 ---> System.Net.Http.HttpRequestException: Connection refused (localhost:8081)
 ---> System.Net.Sockets.SocketException (111): Connection refused
```

You are trying to connect to a local JOpt server but have not adjusted the endpoint. Remember, the sandbox is a docker container and you need to connect to it via the endpoint `http://host.docker.internal:8081` instead of ~`http://localhost:8081`~. You can run `TourOptimizerDockerExample.cs` from the namespace `Optimize` where `Endpoints.LOCAL_SWAGGER_TOUROPTIMIZER_FROM_DOCKER_URL` is used instead of `Endpoints.LOCAL_SWAGGER_TOUROPTIMIZER_URL`.


- If you see the an error like this:

```
Build failed
```

simply try again.

---



## Why use JOpt products from DNA Evolutions?
JOpt is a flexible routing optimization engine written in Java, allowing to solve tour-optimization problems that are highly restricted. For example, regarding time windows, skills, and even mandatory constraints can be applied.

Click to open our video:

<a href="https://www.youtube.com/watch?v=U4mDQGnZGZs" target="_blank"><img src="https://dna-evolutions.com/wp-content/uploads/2021/02/joptIntrox169_small.png" width="500"
title="Introduction Video for DNA's JOpt" alt="Introduction Video for DNA's JOpt"></a>

---

## Agreement
For reading our license agreement and for further information about license plans, please visit <a href="https://www.dna-evolutions.com" target="_blank">www.dna-evolutions.com</a>.

--- 

## Authors
A product by [dna-evolutions](https://www.dna-evolutions.com)&copy;
