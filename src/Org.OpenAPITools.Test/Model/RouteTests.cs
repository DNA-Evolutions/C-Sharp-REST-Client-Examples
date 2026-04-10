/*
 * DNA Evolutions - JOpt.TourOptimizer
 *
 * # JOpt.TourOptimizer REST API  ![DNA Evolutions Logo](https://www.dna-evolutions.com/images/dna_logo.png)  JOpt.TourOptimizer is DNA Evolutions' route optimization and scheduling engine for transportation, field service, and resource planning scenarios.  This API is a **reactive Spring WebFlux REST service** with an **OpenAPI 3** contract, designed for integration into third-party systems and for generating typed client SDKs directly from the schema.  - --  ## Endpoint groups  ### Job endpoints (`job`)  The primary integration model for all deployments with a connected database.  Submit an optimization job with `POST /api/v1/jobs` and receive an HTTP 202 response containing a unique `jobId`. Use that jobId to poll for status, progress, warnings, errors, and the final result at any time — no open connection required.  | Endpoint | Description | Availability | |- --|- --|- --| | `POST /api/v1/jobs` | Submit an async optimization job | All deployments | | `GET /api/v1/jobs/{jobId}/status` | Poll job status | All deployments | | `GET /api/v1/jobs/{jobId}/result` | Retrieve full optimization result | All deployments | | `GET /api/v1/jobs/{jobId}/solution` | Retrieve solution payload only | All deployments | | `GET /api/v1/jobs/{jobId}/progress` | Retrieve progress snapshots | All deployments | | `GET /api/v1/jobs/{jobId}/warnings` | Retrieve warning messages | All deployments | | `GET /api/v1/jobs/{jobId}/errors` | Retrieve error messages | All deployments | | `GET /api/v1/jobs/{jobId}/export` | Download result as ZIP archive | All deployments | | `POST /api/v1/jobs/{jobId}/stop` | Send graceful stop signal to a running job | All deployments | | `DELETE /api/v1/jobs/{jobId}` | Delete all persisted data for a job | All deployments | | `POST /api/v1/jobs/search` | Search jobs by metadata criteria | On-premise (free-search enabled) | | `POST /api/v1/jobs/import` | Import a pre-computed result directly | On-premise (import enabled) |  All job endpoints require the `X-Tenant-Id` header, injected by the API gateway. The `jobId` returned at submission is the only token needed for all subsequent reads.  ### Synchronous run endpoints (`optimization`)  Available on on-premise installations with synchronous mode enabled. The client holds the HTTP connection open and receives the result directly in the response body.  | Endpoint | Description | |- --|- --| | `POST /api/v1/runs` | Start a run, return runId immediately (HTTP 202) | | `GET /api/v1/runs/{runId}/result` | Block until run completes, return full result | | `GET /api/v1/runs/{runId}/solution` | Block until run completes, return solution only | | `DELETE /api/v1/runs/{runId}` | Stop the run gracefully | | `GET /api/v1/runs/{runId}/started` | One-shot signal when the run has started |  ### Event stream endpoints (`stream`)  Server-Sent Event streams for monitoring a running synchronous optimization in near real time. Subscribe to one or more streams while a `POST /api/v1/runs` call is in progress.  | Endpoint | Event type | |- --|- --| | `GET /api/v1/runs/{runId}/stream/progress` | Progress percentage and timing | | `GET /api/v1/runs/{runId}/stream/status` | Lifecycle status transitions | | `GET /api/v1/runs/{runId}/stream/warnings` | Non-fatal solver warnings | | `GET /api/v1/runs/{runId}/stream/errors` | Solver error events |  ### Health endpoint (`health`)  | Endpoint | Description | |- --|- --| | `GET /api/v1/health` | Service liveness and readiness |  - --  ## Deployment modes and feature flags  Endpoints that require specific conditions are activated via Spring `@Conditional` annotations and application properties. Endpoints not active in a given deployment are absent from the service entirely and do not appear in the runtime spec.  | Condition | Property / annotation | Effect | |- --|- --|- --| | Database connected | `DatabaseEnabledCondition` | Activates all `job` endpoints | | Sync mode | `SynchControllersEnabledCondition` | Activates `optimization` and `stream` endpoints | | Free search | `DatabaseFreeSearchEnabledCondition` | Activates `POST /api/v1/jobs/search` | | Import | `DatabaseJobImportEnabledCondition` | Activates `POST /api/v1/jobs/import` |  - --  ## Tenant isolation  Every job endpoint is scoped by `X-Tenant-Id`, injected by the API gateway. Persisted documents are tagged with both `jobId` and `tenantId`. A request with a valid `jobId` but a mismatched `tenantId` returns no data. The `jobId` is a UUID v4 (122 bits of randomness) and is not a security credential — security is enforced by the verified `tenantId` from the gateway header.  - --  ## Encryption at rest  Results can be stored encrypted in two modes:  - **CLIENT mode**: key derived from a caller-provided passphrase via PBKDF2.   Pass the same secret in `X-Encryption-Secret` when reading back. - **KMS mode**: server-generated data encryption key (DEK) wrapped by an   external key management service (Azure Key Vault, AWS KMS). Decryption is   transparent to the caller.  The `encrypted` and `sec` fields in `DatabaseInfoSearchResult` indicate which mode was used for each stored result.  - --  ## Client generation  The OpenAPI schema can be used to generate typed clients for any language. The `operationId` values follow `{verb}{Resource}` lowerCamelCase convention (`createJob`, `getJobResult`, `listJobs`, etc.) for predictable generated method names.  - --  This service is based on **JOpt Core (unknown)**. 
 *
 * The version of the OpenAPI document: 1.3.5-SNAPSHOT
 * Contact: info@dna-evolutions.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using Xunit;

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Org.OpenAPITools.Model;
using Org.OpenAPITools.Client;
using System.Reflection;
using Newtonsoft.Json;

namespace Org.OpenAPITools.Test.Model
{
    /// <summary>
    ///  Class for testing Route
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class RouteTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for Route
        //private Route instance;

        public RouteTests()
        {
            // TODO uncomment below to create an instance of Route
            //instance = new Route();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of Route
        /// </summary>
        [Fact]
        public void RouteInstanceTest()
        {
            // TODO uncomment below to test "IsType" Route
            //Assert.IsType<Route>(instance);
        }

        /// <summary>
        /// Test the property 'Header'
        /// </summary>
        [Fact]
        public void HeaderTest()
        {
            // TODO unit test for the property 'Header'
        }

        /// <summary>
        /// Test the property 'Id'
        /// </summary>
        [Fact]
        public void IdTest()
        {
            // TODO unit test for the property 'Id'
        }

        /// <summary>
        /// Test the property 'ResourceId'
        /// </summary>
        [Fact]
        public void ResourceIdTest()
        {
            // TODO unit test for the property 'ResourceId'
        }

        /// <summary>
        /// Test the property 'RouteTrip'
        /// </summary>
        [Fact]
        public void RouteTripTest()
        {
            // TODO unit test for the property 'RouteTrip'
        }

        /// <summary>
        /// Test the property 'StartTime'
        /// </summary>
        [Fact]
        public void StartTimeTest()
        {
            // TODO unit test for the property 'StartTime'
        }

        /// <summary>
        /// Test the property 'StartElementId'
        /// </summary>
        [Fact]
        public void StartElementIdTest()
        {
            // TODO unit test for the property 'StartElementId'
        }

        /// <summary>
        /// Test the property 'StartPosition'
        /// </summary>
        [Fact]
        public void StartPositionTest()
        {
            // TODO unit test for the property 'StartPosition'
        }

        /// <summary>
        /// Test the property 'EndElementId'
        /// </summary>
        [Fact]
        public void EndElementIdTest()
        {
            // TODO unit test for the property 'EndElementId'
        }

        /// <summary>
        /// Test the property 'EndPosition'
        /// </summary>
        [Fact]
        public void EndPositionTest()
        {
            // TODO unit test for the property 'EndPosition'
        }

        /// <summary>
        /// Test the property 'OptimizableElementIds'
        /// </summary>
        [Fact]
        public void OptimizableElementIdsTest()
        {
            // TODO unit test for the property 'OptimizableElementIds'
        }

        /// <summary>
        /// Test the property 'NonOptimizableElementIds'
        /// </summary>
        [Fact]
        public void NonOptimizableElementIdsTest()
        {
            // TODO unit test for the property 'NonOptimizableElementIds'
        }

        /// <summary>
        /// Test the property 'OptionalOptimizableElementIds'
        /// </summary>
        [Fact]
        public void OptionalOptimizableElementIdsTest()
        {
            // TODO unit test for the property 'OptionalOptimizableElementIds'
        }

        /// <summary>
        /// Test the property 'PillarElementIds'
        /// </summary>
        [Fact]
        public void PillarElementIdsTest()
        {
            // TODO unit test for the property 'PillarElementIds'
        }

        /// <summary>
        /// Test the property 'ElementDetails'
        /// </summary>
        [Fact]
        public void ElementDetailsTest()
        {
            // TODO unit test for the property 'ElementDetails'
        }

        /// <summary>
        /// Test the property 'PillarLatestEffectiveArrivalOffsetMap'
        /// </summary>
        [Fact]
        public void PillarLatestEffectiveArrivalOffsetMapTest()
        {
            // TODO unit test for the property 'PillarLatestEffectiveArrivalOffsetMap'
        }

        /// <summary>
        /// Test the property 'Flags'
        /// </summary>
        [Fact]
        public void FlagsTest()
        {
            // TODO unit test for the property 'Flags'
        }

        /// <summary>
        /// Test the property 'AdditionalRouteStartOffset'
        /// </summary>
        [Fact]
        public void AdditionalRouteStartOffsetTest()
        {
            // TODO unit test for the property 'AdditionalRouteStartOffset'
        }

        /// <summary>
        /// Test the property 'IsLockedDown'
        /// </summary>
        [Fact]
        public void IsLockedDownTest()
        {
            // TODO unit test for the property 'IsLockedDown'
        }

        /// <summary>
        /// Test the property 'IsInactive'
        /// </summary>
        [Fact]
        public void IsInactiveTest()
        {
            // TODO unit test for the property 'IsInactive'
        }

        /// <summary>
        /// Test the property 'IsFinalized'
        /// </summary>
        [Fact]
        public void IsFinalizedTest()
        {
            // TODO unit test for the property 'IsFinalized'
        }
    }
}
