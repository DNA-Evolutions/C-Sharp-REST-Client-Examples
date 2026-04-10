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
    ///  Class for testing WorkingHours
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class WorkingHoursTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for WorkingHours
        //private WorkingHours instance;

        public WorkingHoursTests()
        {
            // TODO uncomment below to create an instance of WorkingHours
            //instance = new WorkingHours();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of WorkingHours
        /// </summary>
        [Fact]
        public void WorkingHoursInstanceTest()
        {
            // TODO uncomment below to test "IsType" WorkingHours
            //Assert.IsType<WorkingHours>(instance);
        }

        /// <summary>
        /// Test the property 'Begin'
        /// </summary>
        [Fact]
        public void BeginTest()
        {
            // TODO unit test for the property 'Begin'
        }

        /// <summary>
        /// Test the property 'End'
        /// </summary>
        [Fact]
        public void EndTest()
        {
            // TODO unit test for the property 'End'
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
        /// Test the property 'MaxTime'
        /// </summary>
        [Fact]
        public void MaxTimeTest()
        {
            // TODO unit test for the property 'MaxTime'
        }

        /// <summary>
        /// Test the property 'MaxDistance'
        /// </summary>
        [Fact]
        public void MaxDistanceTest()
        {
            // TODO unit test for the property 'MaxDistance'
        }

        /// <summary>
        /// Test the property 'StayOutCycleDefinition'
        /// </summary>
        [Fact]
        public void StayOutCycleDefinitionTest()
        {
            // TODO unit test for the property 'StayOutCycleDefinition'
        }

        /// <summary>
        /// Test the property 'StartReductionTimeDefinition'
        /// </summary>
        [Fact]
        public void StartReductionTimeDefinitionTest()
        {
            // TODO unit test for the property 'StartReductionTimeDefinition'
        }

        /// <summary>
        /// Test the property 'StartReductionTimePillarDefinition'
        /// </summary>
        [Fact]
        public void StartReductionTimePillarDefinitionTest()
        {
            // TODO unit test for the property 'StartReductionTimePillarDefinition'
        }

        /// <summary>
        /// Test the property 'StartReductionTimeIncludeDefinition'
        /// </summary>
        [Fact]
        public void StartReductionTimeIncludeDefinitionTest()
        {
            // TODO unit test for the property 'StartReductionTimeIncludeDefinition'
        }

        /// <summary>
        /// Test the property 'LocalFlexTime'
        /// </summary>
        [Fact]
        public void LocalFlexTimeTest()
        {
            // TODO unit test for the property 'LocalFlexTime'
        }

        /// <summary>
        /// Test the property 'LocalPostFlexTime'
        /// </summary>
        [Fact]
        public void LocalPostFlexTimeTest()
        {
            // TODO unit test for the property 'LocalPostFlexTime'
        }

        /// <summary>
        /// Test the property 'LocalPostFlexTimeOnlyOnOvertime'
        /// </summary>
        [Fact]
        public void LocalPostFlexTimeOnlyOnOvertimeTest()
        {
            // TODO unit test for the property 'LocalPostFlexTimeOnlyOnOvertime'
        }

        /// <summary>
        /// Test the property 'MaxLocalPillarAfterHoursTime'
        /// </summary>
        [Fact]
        public void MaxLocalPillarAfterHoursTimeTest()
        {
            // TODO unit test for the property 'MaxLocalPillarAfterHoursTime'
        }

        /// <summary>
        /// Test the property 'NodeColorCapacities'
        /// </summary>
        [Fact]
        public void NodeColorCapacitiesTest()
        {
            // TODO unit test for the property 'NodeColorCapacities'
        }

        /// <summary>
        /// Test the property 'WorkingHoursConstraints'
        /// </summary>
        [Fact]
        public void WorkingHoursConstraintsTest()
        {
            // TODO unit test for the property 'WorkingHoursConstraints'
        }

        /// <summary>
        /// Test the property 'MultiWorkingHoursConstraints'
        /// </summary>
        [Fact]
        public void MultiWorkingHoursConstraintsTest()
        {
            // TODO unit test for the property 'MultiWorkingHoursConstraints'
        }

        /// <summary>
        /// Test the property 'ConstructionHooks'
        /// </summary>
        [Fact]
        public void ConstructionHooksTest()
        {
            // TODO unit test for the property 'ConstructionHooks'
        }

        /// <summary>
        /// Test the property 'Qualifications'
        /// </summary>
        [Fact]
        public void QualificationsTest()
        {
            // TODO unit test for the property 'Qualifications'
        }

        /// <summary>
        /// Test the property 'RouteStartTimeHook'
        /// </summary>
        [Fact]
        public void RouteStartTimeHookTest()
        {
            // TODO unit test for the property 'RouteStartTimeHook'
        }

        /// <summary>
        /// Test the property 'HookElementConnections'
        /// </summary>
        [Fact]
        public void HookElementConnectionsTest()
        {
            // TODO unit test for the property 'HookElementConnections'
        }

        /// <summary>
        /// Test the property 'IsLocalServiceHub'
        /// </summary>
        [Fact]
        public void IsLocalServiceHubTest()
        {
            // TODO unit test for the property 'IsLocalServiceHub'
        }

        /// <summary>
        /// Test the property 'IsClosedRoute'
        /// </summary>
        [Fact]
        public void IsClosedRouteTest()
        {
            // TODO unit test for the property 'IsClosedRoute'
        }

        /// <summary>
        /// Test the property 'IsAvailableForStay'
        /// </summary>
        [Fact]
        public void IsAvailableForStayTest()
        {
            // TODO unit test for the property 'IsAvailableForStay'
        }
    }
}
