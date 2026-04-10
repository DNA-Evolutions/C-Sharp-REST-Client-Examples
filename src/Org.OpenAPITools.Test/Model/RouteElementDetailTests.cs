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
    ///  Class for testing RouteElementDetail
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class RouteElementDetailTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for RouteElementDetail
        //private RouteElementDetail instance;

        public RouteElementDetailTests()
        {
            // TODO uncomment below to create an instance of RouteElementDetail
            //instance = new RouteElementDetail();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of RouteElementDetail
        /// </summary>
        [Fact]
        public void RouteElementDetailInstanceTest()
        {
            // TODO uncomment below to test "IsType" RouteElementDetail
            //Assert.IsType<RouteElementDetail>(instance);
        }

        /// <summary>
        /// Test the property 'ElementId'
        /// </summary>
        [Fact]
        public void ElementIdTest()
        {
            // TODO unit test for the property 'ElementId'
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
        /// Test the property 'ArrivalTime'
        /// </summary>
        [Fact]
        public void ArrivalTimeTest()
        {
            // TODO unit test for the property 'ArrivalTime'
        }

        /// <summary>
        /// Test the property 'DepartureTime'
        /// </summary>
        [Fact]
        public void DepartureTimeTest()
        {
            // TODO unit test for the property 'DepartureTime'
        }

        /// <summary>
        /// Test the property 'TransitionTime'
        /// </summary>
        [Fact]
        public void TransitionTimeTest()
        {
            // TODO unit test for the property 'TransitionTime'
        }

        /// <summary>
        /// Test the property 'EffectivePosition'
        /// </summary>
        [Fact]
        public void EffectivePositionTest()
        {
            // TODO unit test for the property 'EffectivePosition'
        }

        /// <summary>
        /// Test the property 'IdleTime'
        /// </summary>
        [Fact]
        public void IdleTimeTest()
        {
            // TODO unit test for the property 'IdleTime'
        }

        /// <summary>
        /// Test the property 'ZoneId'
        /// </summary>
        [Fact]
        public void ZoneIdTest()
        {
            // TODO unit test for the property 'ZoneId'
        }

        /// <summary>
        /// Test the property 'WhiteSpaceIdleTime'
        /// </summary>
        [Fact]
        public void WhiteSpaceIdleTimeTest()
        {
            // TODO unit test for the property 'WhiteSpaceIdleTime'
        }

        /// <summary>
        /// Test the property 'DurationTime'
        /// </summary>
        [Fact]
        public void DurationTimeTest()
        {
            // TODO unit test for the property 'DurationTime'
        }

        /// <summary>
        /// Test the property 'TransitionDistance'
        /// </summary>
        [Fact]
        public void TransitionDistanceTest()
        {
            // TODO unit test for the property 'TransitionDistance'
        }

        /// <summary>
        /// Test the property 'ChoosenWorkingHoursIndex'
        /// </summary>
        [Fact]
        public void ChoosenWorkingHoursIndexTest()
        {
            // TODO unit test for the property 'ChoosenWorkingHoursIndex'
        }

        /// <summary>
        /// Test the property 'ChosenOpeningHoursIndex'
        /// </summary>
        [Fact]
        public void ChosenOpeningHoursIndexTest()
        {
            // TODO unit test for the property 'ChosenOpeningHoursIndex'
        }

        /// <summary>
        /// Test the property 'EarlyDeviation'
        /// </summary>
        [Fact]
        public void EarlyDeviationTest()
        {
            // TODO unit test for the property 'EarlyDeviation'
        }

        /// <summary>
        /// Test the property 'LateDeviation'
        /// </summary>
        [Fact]
        public void LateDeviationTest()
        {
            // TODO unit test for the property 'LateDeviation'
        }

        /// <summary>
        /// Test the property 'ScheduleStatus'
        /// </summary>
        [Fact]
        public void ScheduleStatusTest()
        {
            // TODO unit test for the property 'ScheduleStatus'
        }

        /// <summary>
        /// Test the property 'VisitorId'
        /// </summary>
        [Fact]
        public void VisitorIdTest()
        {
            // TODO unit test for the property 'VisitorId'
        }

        /// <summary>
        /// Test the property 'LoadChange'
        /// </summary>
        [Fact]
        public void LoadChangeTest()
        {
            // TODO unit test for the property 'LoadChange'
        }

        /// <summary>
        /// Test the property 'CurCapacity'
        /// </summary>
        [Fact]
        public void CurCapacityTest()
        {
            // TODO unit test for the property 'CurCapacity'
        }

        /// <summary>
        /// Test the property 'BeforeVisitNodeDepot'
        /// </summary>
        [Fact]
        public void BeforeVisitNodeDepotTest()
        {
            // TODO unit test for the property 'BeforeVisitNodeDepot'
        }

        /// <summary>
        /// Test the property 'AfterVisitNodeDepot'
        /// </summary>
        [Fact]
        public void AfterVisitNodeDepotTest()
        {
            // TODO unit test for the property 'AfterVisitNodeDepot'
        }

        /// <summary>
        /// Test the property 'NodeViolations'
        /// </summary>
        [Fact]
        public void NodeViolationsTest()
        {
            // TODO unit test for the property 'NodeViolations'
        }

        /// <summary>
        /// Test the property 'IsUnlocatedIdleTime'
        /// </summary>
        [Fact]
        public void IsUnlocatedIdleTimeTest()
        {
            // TODO unit test for the property 'IsUnlocatedIdleTime'
        }
    }
}
