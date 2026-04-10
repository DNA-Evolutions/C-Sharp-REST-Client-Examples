# C# Dna.Examples

C# Dna.Examples are a collection of examples of using the JOpt TourOptimizer suite. The examples are utilizing the Dna.Utils project.

**Requires JOpt TourOptimizer Server 1.3.5 or newer.**

## The Architecture
The examples project is subdivided into different parts:


### TourOptimizer 
Examples dealing with the use of DNA's JOpt containerized TourOptimizer, either via Azure as a service or a local docker instance. Please refer to  <a href="https://github.com/DNA-Evolutions/Docker-REST-TourOptimizer#how-to-start-jopttouroptimizer-docker" target="_blank">"How to start JOpt TourOptimizer in docker"</a> for more help.

#### Synchronous optimization examples

These examples use the `OptimizationApi` (synchronous run endpoints). The client submits an optimization, receives a `runId`, subscribes to SSE streams for live progress/status, and blocks until the result is available.

**1a. optimize\TourOptimizerExample.cs:** Basic example on how to call the JOpt TourOptimizer service. Runs a synchronous optimization with default Sydney positions and prints the full result as JSON.

**1b. optimize\TourOptimizerDockerExample.cs:** Same as 1a but uses `host.docker.internal:8081` to reach a TourOptimizer server on the Docker host. Use this when running the client inside a Docker container (e.g. our sandbox).

**1c. optimize\TourOptimizerZoneTravelExample.cs:** Demonstrates zone-travel optimization with Manhattan (zone 1) and New Jersey City (zone 2) nodes. Penalizes routes that cross zone boundaries using `ZoneNumberQualification`.

**2. constraint\TourOptimizerConstraintExample.cs:** Demonstrates constraint violations. Nodes require "UnreachableQuali" but resources only provide "Quali", resulting in violations in the output.

#### Fire-and-forget (Job API) examples

These examples use the `JobApi` (asynchronous job endpoints). Jobs are submitted to a database-backed server and can be retrieved later by `jobId`. All job endpoints require a `tenantId` for multi-tenant isolation.

**3. optimizeFAF\TourOptimizerFAFExample.cs:** Submits an optimization as an asynchronous job via `POST /api/v1/jobs`. Configures creator settings, persistence strategy (stream saving, encryption, expiry), and prints whether the job was accepted.

**4. searchFAF\TourOptimizerSearchFAFExample.cs:** Searches for previously persisted jobs by metadata criteria (creator, ident, date range) via `POST /api/v1/jobs/search`. Returns a list of matching job metadata entries.

**5. loadFAF\TourOptimizerLoadFAFExample.cs:** Retrieves a previously persisted optimization result from the database by its `jobId` and `tenantId` via `GET /api/v1/jobs/{jobId}/result`.

For setting up a local test environment with database support, please refer to the separate **Hands-on Tutorial: Setting Up a Local Fire and Forget TourOptimizer-Database Test Environment** [tutorial](https://github.com/DNA-Evolutions/Docker-REST-TourOptimizer/blob/main/TourOptimizerWithDatabase.md).
