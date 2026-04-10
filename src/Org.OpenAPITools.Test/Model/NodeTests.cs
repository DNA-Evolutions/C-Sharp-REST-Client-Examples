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
    ///  Class for testing Node
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class NodeTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for Node
        //private Node instance;

        public NodeTests()
        {
            // TODO uncomment below to create an instance of Node
            //instance = new Node();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of Node
        /// </summary>
        [Fact]
        public void NodeInstanceTest()
        {
            // TODO uncomment below to test "IsType" Node
            //Assert.IsType<Node>(instance);
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
        /// Test the property 'ExtraInfo'
        /// </summary>
        [Fact]
        public void ExtraInfoTest()
        {
            // TODO unit test for the property 'ExtraInfo'
        }

        /// <summary>
        /// Test the property 'LocationId'
        /// </summary>
        [Fact]
        public void LocationIdTest()
        {
            // TODO unit test for the property 'LocationId'
        }

        /// <summary>
        /// Test the property 'ConstraintAliasId'
        /// </summary>
        [Fact]
        public void ConstraintAliasIdTest()
        {
            // TODO unit test for the property 'ConstraintAliasId'
        }

        /// <summary>
        /// Test the property 'Type'
        /// </summary>
        [Fact]
        public void TypeTest()
        {
            // TODO unit test for the property 'Type'
        }

        /// <summary>
        /// Test the property 'OpeningHours'
        /// </summary>
        [Fact]
        public void OpeningHoursTest()
        {
            // TODO unit test for the property 'OpeningHours'
        }

        /// <summary>
        /// Test the property 'VisitDuration'
        /// </summary>
        [Fact]
        public void VisitDurationTest()
        {
            // TODO unit test for the property 'VisitDuration'
        }

        /// <summary>
        /// Test the property 'Constraints'
        /// </summary>
        [Fact]
        public void ConstraintsTest()
        {
            // TODO unit test for the property 'Constraints'
        }

        /// <summary>
        /// Test the property 'OfferedNode'
        /// </summary>
        [Fact]
        public void OfferedNodeTest()
        {
            // TODO unit test for the property 'OfferedNode'
        }

        /// <summary>
        /// Test the property 'LoadDimension'
        /// </summary>
        [Fact]
        public void LoadDimensionTest()
        {
            // TODO unit test for the property 'LoadDimension'
        }

        /// <summary>
        /// Test the property 'Load'
        /// </summary>
        [Fact]
        public void LoadTest()
        {
            // TODO unit test for the property 'Load'
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
        /// Test the property 'LockdownTime'
        /// </summary>
        [Fact]
        public void LockdownTimeTest()
        {
            // TODO unit test for the property 'LockdownTime'
        }

        /// <summary>
        /// Test the property 'FixCost'
        /// </summary>
        [Fact]
        public void FixCostTest()
        {
            // TODO unit test for the property 'FixCost'
        }

        /// <summary>
        /// Test the property 'Priority'
        /// </summary>
        [Fact]
        public void PriorityTest()
        {
            // TODO unit test for the property 'Priority'
        }

        /// <summary>
        /// Test the property 'PriorityFirst'
        /// </summary>
        [Fact]
        public void PriorityFirstTest()
        {
            // TODO unit test for the property 'PriorityFirst'
        }

        /// <summary>
        /// Test the property 'PriorityLast'
        /// </summary>
        [Fact]
        public void PriorityLastTest()
        {
            // TODO unit test for the property 'PriorityLast'
        }

        /// <summary>
        /// Test the property 'NodeColor'
        /// </summary>
        [Fact]
        public void NodeColorTest()
        {
            // TODO unit test for the property 'NodeColor'
        }

        /// <summary>
        /// Test the property 'MinAutoFilterProtectedExecutions'
        /// </summary>
        [Fact]
        public void MinAutoFilterProtectedExecutionsTest()
        {
            // TODO unit test for the property 'MinAutoFilterProtectedExecutions'
        }

        /// <summary>
        /// Test the property 'NodeDepot'
        /// </summary>
        [Fact]
        public void NodeDepotTest()
        {
            // TODO unit test for the property 'NodeDepot'
        }

        /// <summary>
        /// Test the property 'RouteDependentVisitDuration'
        /// </summary>
        [Fact]
        public void RouteDependentVisitDurationTest()
        {
            // TODO unit test for the property 'RouteDependentVisitDuration'
        }

        /// <summary>
        /// Test the property 'AllowMoveToReduceFlexTime'
        /// </summary>
        [Fact]
        public void AllowMoveToReduceFlexTimeTest()
        {
            // TODO unit test for the property 'AllowMoveToReduceFlexTime'
        }

        /// <summary>
        /// Test the property 'MinVisitDuration'
        /// </summary>
        [Fact]
        public void MinVisitDurationTest()
        {
            // TODO unit test for the property 'MinVisitDuration'
        }

        /// <summary>
        /// Test the property 'JointVisitDuration'
        /// </summary>
        [Fact]
        public void JointVisitDurationTest()
        {
            // TODO unit test for the property 'JointVisitDuration'
        }

        /// <summary>
        /// Test the property 'ReturnStartDuration'
        /// </summary>
        [Fact]
        public void ReturnStartDurationTest()
        {
            // TODO unit test for the property 'ReturnStartDuration'
        }

        /// <summary>
        /// Test the property 'IsOptimizable'
        /// </summary>
        [Fact]
        public void IsOptimizableTest()
        {
            // TODO unit test for the property 'IsOptimizable'
        }

        /// <summary>
        /// Test the property 'IsOptional'
        /// </summary>
        [Fact]
        public void IsOptionalTest()
        {
            // TODO unit test for the property 'IsOptional'
        }

        /// <summary>
        /// Test the property 'IsUnassigned'
        /// </summary>
        [Fact]
        public void IsUnassignedTest()
        {
            // TODO unit test for the property 'IsUnassigned'
        }

        /// <summary>
        /// Test the property 'IsIgnoreOnZeroDuration'
        /// </summary>
        [Fact]
        public void IsIgnoreOnZeroDurationTest()
        {
            // TODO unit test for the property 'IsIgnoreOnZeroDuration'
        }

        /// <summary>
        /// Test the property 'IsCausingIdleTimeCost'
        /// </summary>
        [Fact]
        public void IsCausingIdleTimeCostTest()
        {
            // TODO unit test for the property 'IsCausingIdleTimeCost'
        }

        /// <summary>
        /// Test the property 'IsWaitOnEarlyArrivalFirstNode'
        /// </summary>
        [Fact]
        public void IsWaitOnEarlyArrivalFirstNodeTest()
        {
            // TODO unit test for the property 'IsWaitOnEarlyArrivalFirstNode'
        }

        /// <summary>
        /// Test the property 'IsWaitOnEarlyArrival'
        /// </summary>
        [Fact]
        public void IsWaitOnEarlyArrivalTest()
        {
            // TODO unit test for the property 'IsWaitOnEarlyArrival'
        }

        /// <summary>
        /// Test the property 'IsUnlocatedHubConnectionTime'
        /// </summary>
        [Fact]
        public void IsUnlocatedHubConnectionTimeTest()
        {
            // TODO unit test for the property 'IsUnlocatedHubConnectionTime'
        }

        /// <summary>
        /// Test the property 'IsOpeningHoursIncludesDuration'
        /// </summary>
        [Fact]
        public void IsOpeningHoursIncludesDurationTest()
        {
            // TODO unit test for the property 'IsOpeningHoursIncludesDuration'
        }

        /// <summary>
        /// Test the property 'IsWorkNode'
        /// </summary>
        [Fact]
        public void IsWorkNodeTest()
        {
            // TODO unit test for the property 'IsWorkNode'
        }

        /// <summary>
        /// Test the property 'IsStayNode'
        /// </summary>
        [Fact]
        public void IsStayNodeTest()
        {
            // TODO unit test for the property 'IsStayNode'
        }

        /// <summary>
        /// Test the property 'IsIgnoreOnZeroLoad'
        /// </summary>
        [Fact]
        public void IsIgnoreOnZeroLoadTest()
        {
            // TODO unit test for the property 'IsIgnoreOnZeroLoad'
        }
    }
}
