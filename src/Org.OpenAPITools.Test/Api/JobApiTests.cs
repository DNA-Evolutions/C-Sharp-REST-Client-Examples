/*
 * DNA Evolutions - JOpt.TourOptimizer
 *
 * # JOpt.TourOptimizer REST API  ![DNA Evolutions Logo](https://www.dna-evolutions.com/images/dna_logo.png)  JOpt.TourOptimizer is DNA Evolutions' route optimization and scheduling engine for transportation, field service, and resource planning scenarios.  This API is a **reactive Spring WebFlux REST service** with an **OpenAPI 3** contract, designed for integration into third-party systems and for generating typed client SDKs directly from the schema.  - --  ## Endpoint groups  ### Job endpoints (`job`)  The primary integration model for all deployments with a connected database.  Submit an optimization job with `POST /api/v1/jobs` and receive an HTTP 202 response containing a unique `jobId`. Use that jobId to poll for status, progress, warnings, errors, and the final result at any time — no open connection required.  | Endpoint | Description | Availability | |- --|- --|- --| | `POST /api/v1/jobs` | Submit an async optimization job | All deployments | | `GET /api/v1/jobs/{jobId}/status` | Poll job status | All deployments | | `GET /api/v1/jobs/{jobId}/result` | Retrieve full optimization result | All deployments | | `GET /api/v1/jobs/{jobId}/solution` | Retrieve solution payload only | All deployments | | `GET /api/v1/jobs/{jobId}/progress` | Retrieve progress snapshots | All deployments | | `GET /api/v1/jobs/{jobId}/warnings` | Retrieve warning messages | All deployments | | `GET /api/v1/jobs/{jobId}/errors` | Retrieve error messages | All deployments | | `GET /api/v1/jobs/{jobId}/export` | Download result as ZIP archive | All deployments | | `POST /api/v1/jobs/{jobId}/stop` | Send graceful stop signal to a running job | All deployments | | `DELETE /api/v1/jobs/{jobId}` | Delete all persisted data for a job | All deployments | | `POST /api/v1/jobs/search` | Search jobs by metadata criteria | On-premise (free-search enabled) | | `POST /api/v1/jobs/import` | Import a pre-computed result directly | On-premise (import enabled) |  All job endpoints require the `X-Tenant-Id` header, injected by the API gateway. The `jobId` returned at submission is the only token needed for all subsequent reads.  ### Synchronous run endpoints (`optimization`)  Available on on-premise installations with synchronous mode enabled. The client holds the HTTP connection open and receives the result directly in the response body.  | Endpoint | Description | |- --|- --| | `POST /api/v1/runs` | Start a run, return runId immediately (HTTP 202) | | `GET /api/v1/runs/{runId}/result` | Block until run completes, return full result | | `GET /api/v1/runs/{runId}/solution` | Block until run completes, return solution only | | `DELETE /api/v1/runs/{runId}` | Stop the run gracefully | | `GET /api/v1/runs/{runId}/started` | One-shot signal when the run has started |  ### Event stream endpoints (`stream`)  Server-Sent Event streams for monitoring a running synchronous optimization in near real time. Subscribe to one or more streams while a `POST /api/v1/runs` call is in progress.  | Endpoint | Event type | |- --|- --| | `GET /api/v1/runs/{runId}/stream/progress` | Progress percentage and timing | | `GET /api/v1/runs/{runId}/stream/status` | Lifecycle status transitions | | `GET /api/v1/runs/{runId}/stream/warnings` | Non-fatal solver warnings | | `GET /api/v1/runs/{runId}/stream/errors` | Solver error events |  ### Health endpoint (`health`)  | Endpoint | Description | |- --|- --| | `GET /api/v1/health` | Service liveness and readiness |  - --  ## Deployment modes and feature flags  Endpoints that require specific conditions are activated via Spring `@Conditional` annotations and application properties. Endpoints not active in a given deployment are absent from the service entirely and do not appear in the runtime spec.  | Condition | Property / annotation | Effect | |- --|- --|- --| | Database connected | `DatabaseEnabledCondition` | Activates all `job` endpoints | | Sync mode | `SynchControllersEnabledCondition` | Activates `optimization` and `stream` endpoints | | Free search | `DatabaseFreeSearchEnabledCondition` | Activates `POST /api/v1/jobs/search` | | Import | `DatabaseJobImportEnabledCondition` | Activates `POST /api/v1/jobs/import` |  - --  ## Tenant isolation  Every job endpoint is scoped by `X-Tenant-Id`, injected by the API gateway. Persisted documents are tagged with both `jobId` and `tenantId`. A request with a valid `jobId` but a mismatched `tenantId` returns no data. The `jobId` is a UUID v4 (122 bits of randomness) and is not a security credential — security is enforced by the verified `tenantId` from the gateway header.  - --  ## Encryption at rest  Results can be stored encrypted in two modes:  - **CLIENT mode**: key derived from a caller-provided passphrase via PBKDF2.   Pass the same secret in `X-Encryption-Secret` when reading back. - **KMS mode**: server-generated data encryption key (DEK) wrapped by an   external key management service (Azure Key Vault, AWS KMS). Decryption is   transparent to the caller.  The `encrypted` and `sec` fields in `DatabaseInfoSearchResult` indicate which mode was used for each stored result.  - --  ## Client generation  The OpenAPI schema can be used to generate typed clients for any language. The `operationId` values follow `{verb}{Resource}` lowerCamelCase convention (`createJob`, `getJobResult`, `listJobs`, etc.) for predictable generated method names.  - --  This service is based on **JOpt Core (unknown)**. 
 *
 * The version of the OpenAPI document: 1.3.5-SNAPSHOT
 * Contact: info@dna-evolutions.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using Xunit;

using Org.OpenAPITools.Client;
using Org.OpenAPITools.Api;
// uncomment below to import models
//using Org.OpenAPITools.Model;

namespace Org.OpenAPITools.Test.Api
{
    /// <summary>
    ///  Class for testing JobApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class JobApiTests : IDisposable
    {
        private JobApi instance;

        public JobApiTests()
        {
            instance = new JobApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of JobApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' JobApi
            //Assert.IsType<JobApi>(instance);
        }

        /// <summary>
        /// Test CreateJob
        /// </summary>
        [Fact]
        public void CreateJobTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string xTenantId = null;
            //RestOptimization restOptimization = null;
            //var response = instance.CreateJob(xTenantId, restOptimization);
            //Assert.IsType<JobAcceptedResponse>(response);
        }

        /// <summary>
        /// Test DeleteJob
        /// </summary>
        [Fact]
        public void DeleteJobTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string jobId = null;
            //string xTenantId = null;
            //var response = instance.DeleteJob(jobId, xTenantId);
            //Assert.IsType<bool>(response);
        }

        /// <summary>
        /// Test ExportJob
        /// </summary>
        [Fact]
        public void ExportJobTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string jobId = null;
            //string xTenantId = null;
            //string? xEncryptionSecret = null;
            //string? timeOut = null;
            //var response = instance.ExportJob(jobId, xTenantId, xEncryptionSecret, timeOut);
            //Assert.IsType<FileParameter>(response);
        }

        /// <summary>
        /// Test GetJobErrors
        /// </summary>
        [Fact]
        public void GetJobErrorsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string jobId = null;
            //string xTenantId = null;
            //int? limit = null;
            //string? sortDirection = null;
            //string? timeOut = null;
            //var response = instance.GetJobErrors(jobId, xTenantId, limit, sortDirection, timeOut);
            //Assert.IsType<List<JOptOptimizationError>>(response);
        }

        /// <summary>
        /// Test GetJobProgress
        /// </summary>
        [Fact]
        public void GetJobProgressTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string jobId = null;
            //string xTenantId = null;
            //int? limit = null;
            //string? sortDirection = null;
            //string? timeOut = null;
            //var response = instance.GetJobProgress(jobId, xTenantId, limit, sortDirection, timeOut);
            //Assert.IsType<List<JOptOptimizationProgress>>(response);
        }

        /// <summary>
        /// Test GetJobResult
        /// </summary>
        [Fact]
        public void GetJobResultTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string jobId = null;
            //string xTenantId = null;
            //string? xEncryptionSecret = null;
            //string? timeOut = null;
            //var response = instance.GetJobResult(jobId, xTenantId, xEncryptionSecret, timeOut);
            //Assert.IsType<RestOptimization>(response);
        }

        /// <summary>
        /// Test GetJobSolution
        /// </summary>
        [Fact]
        public void GetJobSolutionTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string jobId = null;
            //string xTenantId = null;
            //string? xEncryptionSecret = null;
            //string? timeOut = null;
            //var response = instance.GetJobSolution(jobId, xTenantId, xEncryptionSecret, timeOut);
            //Assert.IsType<Solution>(response);
        }

        /// <summary>
        /// Test GetJobStatus
        /// </summary>
        [Fact]
        public void GetJobStatusTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string jobId = null;
            //string xTenantId = null;
            //int? limit = null;
            //string? sortDirection = null;
            //string? timeOut = null;
            //var response = instance.GetJobStatus(jobId, xTenantId, limit, sortDirection, timeOut);
            //Assert.IsType<List<JOptOptimizationStatus>>(response);
        }

        /// <summary>
        /// Test GetJobWarnings
        /// </summary>
        [Fact]
        public void GetJobWarningsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string jobId = null;
            //string xTenantId = null;
            //int? limit = null;
            //string? sortDirection = null;
            //string? timeOut = null;
            //var response = instance.GetJobWarnings(jobId, xTenantId, limit, sortDirection, timeOut);
            //Assert.IsType<List<JOptOptimizationWarning>>(response);
        }

        /// <summary>
        /// Test ImportJob
        /// </summary>
        [Fact]
        public void ImportJobTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string xTenantId = null;
            //RestOptimization restOptimization = null;
            //var response = instance.ImportJob(xTenantId, restOptimization);
            //Assert.IsType<JobAcceptedResponse>(response);
        }

        /// <summary>
        /// Test ListJobs
        /// </summary>
        [Fact]
        public void ListJobsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //DatabaseInfoSearch databaseInfoSearch = null;
            //string? xTenantId = null;
            //var response = instance.ListJobs(databaseInfoSearch, xTenantId);
            //Assert.IsType<List<DatabaseInfoSearchResult>>(response);
        }

        /// <summary>
        /// Test StopJob
        /// </summary>
        [Fact]
        public void StopJobTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string jobId = null;
            //string xTenantId = null;
            //var response = instance.StopJob(jobId, xTenantId);
            //Assert.IsType<bool>(response);
        }
    }
}
