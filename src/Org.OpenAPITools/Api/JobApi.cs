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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Org.OpenAPITools.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IJobApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Submit an optimization job.
        /// </summary>
        /// <remarks>
        /// Accepts a RestOptimization payload and starts processing asynchronously. Returns HTTP 202 with a JobAcceptedResponse containing a unique jobId. Use the jobId with X-Tenant-Id to poll the job read endpoints for status, progress, warnings, errors, and the final result. Persistence is scoped to the tenant identified by the X-Tenant-Id header.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway. Scopes all persisted data to this tenant.</param>
        /// <param name="restOptimization"></param>
        /// <returns>JobAcceptedResponse</returns>
        JobAcceptedResponse CreateJob(string xTenantId, RestOptimization restOptimization);

        /// <summary>
        /// Submit an optimization job.
        /// </summary>
        /// <remarks>
        /// Accepts a RestOptimization payload and starts processing asynchronously. Returns HTTP 202 with a JobAcceptedResponse containing a unique jobId. Use the jobId with X-Tenant-Id to poll the job read endpoints for status, progress, warnings, errors, and the final result. Persistence is scoped to the tenant identified by the X-Tenant-Id header.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway. Scopes all persisted data to this tenant.</param>
        /// <param name="restOptimization"></param>
        /// <returns>ApiResponse of JobAcceptedResponse</returns>
        ApiResponse<JobAcceptedResponse> CreateJobWithHttpInfo(string xTenantId, RestOptimization restOptimization);
        /// <summary>
        /// Delete all persisted data for a job.
        /// </summary>
        /// <remarks>
        /// Permanently removes the optimization result and all associated stream documents (progress, status, warnings, errors) for the given jobId from the database. Does not stop a running optimization — call POST /api/v1/jobs/{jobId}/stop first and wait for the job to terminate before deleting. Idempotent: returns 200 even if no data exists for this jobId.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <returns>bool</returns>
        bool DeleteJob(string jobId, string xTenantId);

        /// <summary>
        /// Delete all persisted data for a job.
        /// </summary>
        /// <remarks>
        /// Permanently removes the optimization result and all associated stream documents (progress, status, warnings, errors) for the given jobId from the database. Does not stop a running optimization — call POST /api/v1/jobs/{jobId}/stop first and wait for the job to terminate before deleting. Idempotent: returns 200 even if no data exists for this jobId.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <returns>ApiResponse of bool</returns>
        ApiResponse<bool> DeleteJobWithHttpInfo(string jobId, string xTenantId);
        /// <summary>
        /// Download the optimization result as a ZIP archive.
        /// </summary>
        /// <remarks>
        /// Returns a ZIP archive of the persisted optimization result for the given job. If the result was stored with client-side encryption, provide the original passphrase via X-Encryption-Secret and the archive will be decrypted before streaming. For KMS-encrypted or unencrypted results the header can be omitted — decryption is handled transparently by the server. The Content-Disposition header carries the suggested filename.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="xEncryptionSecret">Client decryption secret. Required only for CLIENT-mode encrypted results. Omit for KMS or unencrypted. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>FileParameter</returns>
        FileParameter ExportJob(string jobId, string xTenantId, string? xEncryptionSecret = default, string? timeOut = default);

        /// <summary>
        /// Download the optimization result as a ZIP archive.
        /// </summary>
        /// <remarks>
        /// Returns a ZIP archive of the persisted optimization result for the given job. If the result was stored with client-side encryption, provide the original passphrase via X-Encryption-Secret and the archive will be decrypted before streaming. For KMS-encrypted or unencrypted results the header can be omitted — decryption is handled transparently by the server. The Content-Disposition header carries the suggested filename.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="xEncryptionSecret">Client decryption secret. Required only for CLIENT-mode encrypted results. Omit for KMS or unencrypted. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>ApiResponse of FileParameter</returns>
        ApiResponse<FileParameter> ExportJobWithHttpInfo(string jobId, string xTenantId, string? xEncryptionSecret = default, string? timeOut = default);
        /// <summary>
        /// Retrieve error messages for a job.
        /// </summary>
        /// <remarks>
        /// Returns persisted error messages for the given job. Errors are only persisted if saveError was enabled in the MongoOptimizationPersistenceSetting.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of errors to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>List&lt;JOptOptimizationError&gt;</returns>
        List<JOptOptimizationError> GetJobErrors(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default);

        /// <summary>
        /// Retrieve error messages for a job.
        /// </summary>
        /// <remarks>
        /// Returns persisted error messages for the given job. Errors are only persisted if saveError was enabled in the MongoOptimizationPersistenceSetting.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of errors to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>ApiResponse of List&lt;JOptOptimizationError&gt;</returns>
        ApiResponse<List<JOptOptimizationError>> GetJobErrorsWithHttpInfo(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default);
        /// <summary>
        /// Retrieve progress snapshots for a job.
        /// </summary>
        /// <remarks>
        /// Returns persisted progress snapshots for the given job. Progress events are only persisted if saveProgress was enabled in the MongoOptimizationPersistenceSetting.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of snapshots to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>List&lt;JOptOptimizationProgress&gt;</returns>
        List<JOptOptimizationProgress> GetJobProgress(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default);

        /// <summary>
        /// Retrieve progress snapshots for a job.
        /// </summary>
        /// <remarks>
        /// Returns persisted progress snapshots for the given job. Progress events are only persisted if saveProgress was enabled in the MongoOptimizationPersistenceSetting.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of snapshots to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>ApiResponse of List&lt;JOptOptimizationProgress&gt;</returns>
        ApiResponse<List<JOptOptimizationProgress>> GetJobProgressWithHttpInfo(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default);
        /// <summary>
        /// Retrieve the full optimization result for a job.
        /// </summary>
        /// <remarks>
        /// Loads the complete persisted optimization snapshot for the given jobId, scoped to the authenticated tenant. If the result was client-encrypted, provide the original secret via X-Encryption-Secret; for KMS-encrypted or unencrypted results the header can be omitted.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="xEncryptionSecret">Client decryption secret. Required only for CLIENT-mode encrypted results. Omit for KMS or unencrypted. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>RestOptimization</returns>
        RestOptimization GetJobResult(string jobId, string xTenantId, string? xEncryptionSecret = default, string? timeOut = default);

        /// <summary>
        /// Retrieve the full optimization result for a job.
        /// </summary>
        /// <remarks>
        /// Loads the complete persisted optimization snapshot for the given jobId, scoped to the authenticated tenant. If the result was client-encrypted, provide the original secret via X-Encryption-Secret; for KMS-encrypted or unencrypted results the header can be omitted.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="xEncryptionSecret">Client decryption secret. Required only for CLIENT-mode encrypted results. Omit for KMS or unencrypted. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>ApiResponse of RestOptimization</returns>
        ApiResponse<RestOptimization> GetJobResultWithHttpInfo(string jobId, string xTenantId, string? xEncryptionSecret = default, string? timeOut = default);
        /// <summary>
        /// Retrieve the solution payload for a job.
        /// </summary>
        /// <remarks>
        /// Returns the Solution portion of the optimization result only, omitting the full optimization input echo. Useful for lightweight integrations that do not need the complete RestOptimization envelope. If the result was client-encrypted, provide X-Encryption-Secret.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="xEncryptionSecret">Client decryption secret. Required only for CLIENT-mode encrypted results. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>Solution</returns>
        Solution GetJobSolution(string jobId, string xTenantId, string? xEncryptionSecret = default, string? timeOut = default);

        /// <summary>
        /// Retrieve the solution payload for a job.
        /// </summary>
        /// <remarks>
        /// Returns the Solution portion of the optimization result only, omitting the full optimization input echo. Useful for lightweight integrations that do not need the complete RestOptimization envelope. If the result was client-encrypted, provide X-Encryption-Secret.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="xEncryptionSecret">Client decryption secret. Required only for CLIENT-mode encrypted results. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>ApiResponse of Solution</returns>
        ApiResponse<Solution> GetJobSolutionWithHttpInfo(string jobId, string xTenantId, string? xEncryptionSecret = default, string? timeOut = default);
        /// <summary>
        /// Retrieve status updates for a job.
        /// </summary>
        /// <remarks>
        /// Returns persisted status lifecycle events for the given job (e.g. RUNNING, SUCCESS_WITH_SOLUTION, ERROR). Status events are only persisted if saveStatus was enabled in the MongoOptimizationPersistenceSetting.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of events to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>List&lt;JOptOptimizationStatus&gt;</returns>
        List<JOptOptimizationStatus> GetJobStatus(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default);

        /// <summary>
        /// Retrieve status updates for a job.
        /// </summary>
        /// <remarks>
        /// Returns persisted status lifecycle events for the given job (e.g. RUNNING, SUCCESS_WITH_SOLUTION, ERROR). Status events are only persisted if saveStatus was enabled in the MongoOptimizationPersistenceSetting.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of events to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>ApiResponse of List&lt;JOptOptimizationStatus&gt;</returns>
        ApiResponse<List<JOptOptimizationStatus>> GetJobStatusWithHttpInfo(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default);
        /// <summary>
        /// Retrieve warning messages for a job.
        /// </summary>
        /// <remarks>
        /// Returns persisted warning messages for the given job. Warnings are only persisted if saveWarning was enabled in the MongoOptimizationPersistenceSetting.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of warnings to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>List&lt;JOptOptimizationWarning&gt;</returns>
        List<JOptOptimizationWarning> GetJobWarnings(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default);

        /// <summary>
        /// Retrieve warning messages for a job.
        /// </summary>
        /// <remarks>
        /// Returns persisted warning messages for the given job. Warnings are only persisted if saveWarning was enabled in the MongoOptimizationPersistenceSetting.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of warnings to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>ApiResponse of List&lt;JOptOptimizationWarning&gt;</returns>
        ApiResponse<List<JOptOptimizationWarning>> GetJobWarningsWithHttpInfo(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default);
        /// <summary>
        /// Import a pre-computed optimization result into the database.
        /// </summary>
        /// <remarks>
        /// Persists a RestOptimization payload directly without running the optimizer. The call blocks until the write completes. Returns a JobAcceptedResponse containing the generated jobId, which can be used immediately with GET /api/v1/jobs/{jobId}/result to retrieve the imported result. Persistence must be enabled in the RestOptimization extension settings. The tenant is scoped by the X-Tenant-Id header.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway. Scopes the persisted result to this tenant.</param>
        /// <param name="restOptimization"></param>
        /// <returns>JobAcceptedResponse</returns>
        JobAcceptedResponse ImportJob(string xTenantId, RestOptimization restOptimization);

        /// <summary>
        /// Import a pre-computed optimization result into the database.
        /// </summary>
        /// <remarks>
        /// Persists a RestOptimization payload directly without running the optimizer. The call blocks until the write completes. Returns a JobAcceptedResponse containing the generated jobId, which can be used immediately with GET /api/v1/jobs/{jobId}/result to retrieve the imported result. Persistence must be enabled in the RestOptimization extension settings. The tenant is scoped by the X-Tenant-Id header.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway. Scopes the persisted result to this tenant.</param>
        /// <param name="restOptimization"></param>
        /// <returns>ApiResponse of JobAcceptedResponse</returns>
        ApiResponse<JobAcceptedResponse> ImportJobWithHttpInfo(string xTenantId, RestOptimization restOptimization);
        /// <summary>
        /// Search persisted optimization jobs and return metadata summaries.
        /// </summary>
        /// <remarks>
        /// Accepts a DatabaseInfoSearch body and returns a stream of metadata summaries for all matching optimization jobs. All fields in the search body are optional and combinable. Results are sorted by upload date, newest first by default. Each entry contains a jobId that can be used directly with GET /api/v1/jobs/{jobId}/result to retrieve the full optimization result. Fields absent for encrypted jobs (creator, ident, status, createdTimeStamp) are omitted from each result entry. On-premise only: requires a connected database.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="databaseInfoSearch"></param>
        /// <param name="xTenantId">Tenant identifier. When provided, results are scoped to this tenant. In on-premise single-tenant setups this header may be omitted. (optional)</param>
        /// <returns>List&lt;DatabaseInfoSearchResult&gt;</returns>
        List<DatabaseInfoSearchResult> ListJobs(DatabaseInfoSearch databaseInfoSearch, string? xTenantId = default);

        /// <summary>
        /// Search persisted optimization jobs and return metadata summaries.
        /// </summary>
        /// <remarks>
        /// Accepts a DatabaseInfoSearch body and returns a stream of metadata summaries for all matching optimization jobs. All fields in the search body are optional and combinable. Results are sorted by upload date, newest first by default. Each entry contains a jobId that can be used directly with GET /api/v1/jobs/{jobId}/result to retrieve the full optimization result. Fields absent for encrypted jobs (creator, ident, status, createdTimeStamp) are omitted from each result entry. On-premise only: requires a connected database.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="databaseInfoSearch"></param>
        /// <param name="xTenantId">Tenant identifier. When provided, results are scoped to this tenant. In on-premise single-tenant setups this header may be omitted. (optional)</param>
        /// <returns>ApiResponse of List&lt;DatabaseInfoSearchResult&gt;</returns>
        ApiResponse<List<DatabaseInfoSearchResult>> ListJobsWithHttpInfo(DatabaseInfoSearch databaseInfoSearch, string? xTenantId = default);
        /// <summary>
        /// Stop a running job gracefully.
        /// </summary>
        /// <remarks>
        /// Sends a graceful stop signal to the running optimization identified by jobId. The optimizer finishes its current iteration and persists the best result found so far. Returns immediately — the stop may take several seconds to complete. Poll GET /api/v1/jobs/{jobId}/status to confirm termination. Returns 200 if the job was found and the signal was sent. Returns 404 if the job is not running (already completed or never started).
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <returns>bool</returns>
        bool StopJob(string jobId, string xTenantId);

        /// <summary>
        /// Stop a running job gracefully.
        /// </summary>
        /// <remarks>
        /// Sends a graceful stop signal to the running optimization identified by jobId. The optimizer finishes its current iteration and persists the best result found so far. Returns immediately — the stop may take several seconds to complete. Poll GET /api/v1/jobs/{jobId}/status to confirm termination. Returns 200 if the job was found and the signal was sent. Returns 404 if the job is not running (already completed or never started).
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <returns>ApiResponse of bool</returns>
        ApiResponse<bool> StopJobWithHttpInfo(string jobId, string xTenantId);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IJobApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Submit an optimization job.
        /// </summary>
        /// <remarks>
        /// Accepts a RestOptimization payload and starts processing asynchronously. Returns HTTP 202 with a JobAcceptedResponse containing a unique jobId. Use the jobId with X-Tenant-Id to poll the job read endpoints for status, progress, warnings, errors, and the final result. Persistence is scoped to the tenant identified by the X-Tenant-Id header.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway. Scopes all persisted data to this tenant.</param>
        /// <param name="restOptimization"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of JobAcceptedResponse</returns>
        System.Threading.Tasks.Task<JobAcceptedResponse> CreateJobAsync(string xTenantId, RestOptimization restOptimization, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Submit an optimization job.
        /// </summary>
        /// <remarks>
        /// Accepts a RestOptimization payload and starts processing asynchronously. Returns HTTP 202 with a JobAcceptedResponse containing a unique jobId. Use the jobId with X-Tenant-Id to poll the job read endpoints for status, progress, warnings, errors, and the final result. Persistence is scoped to the tenant identified by the X-Tenant-Id header.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway. Scopes all persisted data to this tenant.</param>
        /// <param name="restOptimization"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (JobAcceptedResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<JobAcceptedResponse>> CreateJobWithHttpInfoAsync(string xTenantId, RestOptimization restOptimization, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Delete all persisted data for a job.
        /// </summary>
        /// <remarks>
        /// Permanently removes the optimization result and all associated stream documents (progress, status, warnings, errors) for the given jobId from the database. Does not stop a running optimization — call POST /api/v1/jobs/{jobId}/stop first and wait for the job to terminate before deleting. Idempotent: returns 200 even if no data exists for this jobId.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of bool</returns>
        System.Threading.Tasks.Task<bool> DeleteJobAsync(string jobId, string xTenantId, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete all persisted data for a job.
        /// </summary>
        /// <remarks>
        /// Permanently removes the optimization result and all associated stream documents (progress, status, warnings, errors) for the given jobId from the database. Does not stop a running optimization — call POST /api/v1/jobs/{jobId}/stop first and wait for the job to terminate before deleting. Idempotent: returns 200 even if no data exists for this jobId.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (bool)</returns>
        System.Threading.Tasks.Task<ApiResponse<bool>> DeleteJobWithHttpInfoAsync(string jobId, string xTenantId, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Download the optimization result as a ZIP archive.
        /// </summary>
        /// <remarks>
        /// Returns a ZIP archive of the persisted optimization result for the given job. If the result was stored with client-side encryption, provide the original passphrase via X-Encryption-Secret and the archive will be decrypted before streaming. For KMS-encrypted or unencrypted results the header can be omitted — decryption is handled transparently by the server. The Content-Disposition header carries the suggested filename.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="xEncryptionSecret">Client decryption secret. Required only for CLIENT-mode encrypted results. Omit for KMS or unencrypted. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of FileParameter</returns>
        System.Threading.Tasks.Task<FileParameter> ExportJobAsync(string jobId, string xTenantId, string? xEncryptionSecret = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Download the optimization result as a ZIP archive.
        /// </summary>
        /// <remarks>
        /// Returns a ZIP archive of the persisted optimization result for the given job. If the result was stored with client-side encryption, provide the original passphrase via X-Encryption-Secret and the archive will be decrypted before streaming. For KMS-encrypted or unencrypted results the header can be omitted — decryption is handled transparently by the server. The Content-Disposition header carries the suggested filename.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="xEncryptionSecret">Client decryption secret. Required only for CLIENT-mode encrypted results. Omit for KMS or unencrypted. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (FileParameter)</returns>
        System.Threading.Tasks.Task<ApiResponse<FileParameter>> ExportJobWithHttpInfoAsync(string jobId, string xTenantId, string? xEncryptionSecret = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Retrieve error messages for a job.
        /// </summary>
        /// <remarks>
        /// Returns persisted error messages for the given job. Errors are only persisted if saveError was enabled in the MongoOptimizationPersistenceSetting.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of errors to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;JOptOptimizationError&gt;</returns>
        System.Threading.Tasks.Task<List<JOptOptimizationError>> GetJobErrorsAsync(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve error messages for a job.
        /// </summary>
        /// <remarks>
        /// Returns persisted error messages for the given job. Errors are only persisted if saveError was enabled in the MongoOptimizationPersistenceSetting.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of errors to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;JOptOptimizationError&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<JOptOptimizationError>>> GetJobErrorsWithHttpInfoAsync(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Retrieve progress snapshots for a job.
        /// </summary>
        /// <remarks>
        /// Returns persisted progress snapshots for the given job. Progress events are only persisted if saveProgress was enabled in the MongoOptimizationPersistenceSetting.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of snapshots to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;JOptOptimizationProgress&gt;</returns>
        System.Threading.Tasks.Task<List<JOptOptimizationProgress>> GetJobProgressAsync(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve progress snapshots for a job.
        /// </summary>
        /// <remarks>
        /// Returns persisted progress snapshots for the given job. Progress events are only persisted if saveProgress was enabled in the MongoOptimizationPersistenceSetting.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of snapshots to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;JOptOptimizationProgress&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<JOptOptimizationProgress>>> GetJobProgressWithHttpInfoAsync(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Retrieve the full optimization result for a job.
        /// </summary>
        /// <remarks>
        /// Loads the complete persisted optimization snapshot for the given jobId, scoped to the authenticated tenant. If the result was client-encrypted, provide the original secret via X-Encryption-Secret; for KMS-encrypted or unencrypted results the header can be omitted.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="xEncryptionSecret">Client decryption secret. Required only for CLIENT-mode encrypted results. Omit for KMS or unencrypted. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of RestOptimization</returns>
        System.Threading.Tasks.Task<RestOptimization> GetJobResultAsync(string jobId, string xTenantId, string? xEncryptionSecret = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve the full optimization result for a job.
        /// </summary>
        /// <remarks>
        /// Loads the complete persisted optimization snapshot for the given jobId, scoped to the authenticated tenant. If the result was client-encrypted, provide the original secret via X-Encryption-Secret; for KMS-encrypted or unencrypted results the header can be omitted.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="xEncryptionSecret">Client decryption secret. Required only for CLIENT-mode encrypted results. Omit for KMS or unencrypted. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (RestOptimization)</returns>
        System.Threading.Tasks.Task<ApiResponse<RestOptimization>> GetJobResultWithHttpInfoAsync(string jobId, string xTenantId, string? xEncryptionSecret = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Retrieve the solution payload for a job.
        /// </summary>
        /// <remarks>
        /// Returns the Solution portion of the optimization result only, omitting the full optimization input echo. Useful for lightweight integrations that do not need the complete RestOptimization envelope. If the result was client-encrypted, provide X-Encryption-Secret.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="xEncryptionSecret">Client decryption secret. Required only for CLIENT-mode encrypted results. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Solution</returns>
        System.Threading.Tasks.Task<Solution> GetJobSolutionAsync(string jobId, string xTenantId, string? xEncryptionSecret = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve the solution payload for a job.
        /// </summary>
        /// <remarks>
        /// Returns the Solution portion of the optimization result only, omitting the full optimization input echo. Useful for lightweight integrations that do not need the complete RestOptimization envelope. If the result was client-encrypted, provide X-Encryption-Secret.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="xEncryptionSecret">Client decryption secret. Required only for CLIENT-mode encrypted results. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Solution)</returns>
        System.Threading.Tasks.Task<ApiResponse<Solution>> GetJobSolutionWithHttpInfoAsync(string jobId, string xTenantId, string? xEncryptionSecret = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Retrieve status updates for a job.
        /// </summary>
        /// <remarks>
        /// Returns persisted status lifecycle events for the given job (e.g. RUNNING, SUCCESS_WITH_SOLUTION, ERROR). Status events are only persisted if saveStatus was enabled in the MongoOptimizationPersistenceSetting.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of events to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;JOptOptimizationStatus&gt;</returns>
        System.Threading.Tasks.Task<List<JOptOptimizationStatus>> GetJobStatusAsync(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve status updates for a job.
        /// </summary>
        /// <remarks>
        /// Returns persisted status lifecycle events for the given job (e.g. RUNNING, SUCCESS_WITH_SOLUTION, ERROR). Status events are only persisted if saveStatus was enabled in the MongoOptimizationPersistenceSetting.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of events to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;JOptOptimizationStatus&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<JOptOptimizationStatus>>> GetJobStatusWithHttpInfoAsync(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Retrieve warning messages for a job.
        /// </summary>
        /// <remarks>
        /// Returns persisted warning messages for the given job. Warnings are only persisted if saveWarning was enabled in the MongoOptimizationPersistenceSetting.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of warnings to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;JOptOptimizationWarning&gt;</returns>
        System.Threading.Tasks.Task<List<JOptOptimizationWarning>> GetJobWarningsAsync(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve warning messages for a job.
        /// </summary>
        /// <remarks>
        /// Returns persisted warning messages for the given job. Warnings are only persisted if saveWarning was enabled in the MongoOptimizationPersistenceSetting.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of warnings to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;JOptOptimizationWarning&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<JOptOptimizationWarning>>> GetJobWarningsWithHttpInfoAsync(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Import a pre-computed optimization result into the database.
        /// </summary>
        /// <remarks>
        /// Persists a RestOptimization payload directly without running the optimizer. The call blocks until the write completes. Returns a JobAcceptedResponse containing the generated jobId, which can be used immediately with GET /api/v1/jobs/{jobId}/result to retrieve the imported result. Persistence must be enabled in the RestOptimization extension settings. The tenant is scoped by the X-Tenant-Id header.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway. Scopes the persisted result to this tenant.</param>
        /// <param name="restOptimization"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of JobAcceptedResponse</returns>
        System.Threading.Tasks.Task<JobAcceptedResponse> ImportJobAsync(string xTenantId, RestOptimization restOptimization, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Import a pre-computed optimization result into the database.
        /// </summary>
        /// <remarks>
        /// Persists a RestOptimization payload directly without running the optimizer. The call blocks until the write completes. Returns a JobAcceptedResponse containing the generated jobId, which can be used immediately with GET /api/v1/jobs/{jobId}/result to retrieve the imported result. Persistence must be enabled in the RestOptimization extension settings. The tenant is scoped by the X-Tenant-Id header.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway. Scopes the persisted result to this tenant.</param>
        /// <param name="restOptimization"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (JobAcceptedResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<JobAcceptedResponse>> ImportJobWithHttpInfoAsync(string xTenantId, RestOptimization restOptimization, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Search persisted optimization jobs and return metadata summaries.
        /// </summary>
        /// <remarks>
        /// Accepts a DatabaseInfoSearch body and returns a stream of metadata summaries for all matching optimization jobs. All fields in the search body are optional and combinable. Results are sorted by upload date, newest first by default. Each entry contains a jobId that can be used directly with GET /api/v1/jobs/{jobId}/result to retrieve the full optimization result. Fields absent for encrypted jobs (creator, ident, status, createdTimeStamp) are omitted from each result entry. On-premise only: requires a connected database.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="databaseInfoSearch"></param>
        /// <param name="xTenantId">Tenant identifier. When provided, results are scoped to this tenant. In on-premise single-tenant setups this header may be omitted. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;DatabaseInfoSearchResult&gt;</returns>
        System.Threading.Tasks.Task<List<DatabaseInfoSearchResult>> ListJobsAsync(DatabaseInfoSearch databaseInfoSearch, string? xTenantId = default, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Search persisted optimization jobs and return metadata summaries.
        /// </summary>
        /// <remarks>
        /// Accepts a DatabaseInfoSearch body and returns a stream of metadata summaries for all matching optimization jobs. All fields in the search body are optional and combinable. Results are sorted by upload date, newest first by default. Each entry contains a jobId that can be used directly with GET /api/v1/jobs/{jobId}/result to retrieve the full optimization result. Fields absent for encrypted jobs (creator, ident, status, createdTimeStamp) are omitted from each result entry. On-premise only: requires a connected database.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="databaseInfoSearch"></param>
        /// <param name="xTenantId">Tenant identifier. When provided, results are scoped to this tenant. In on-premise single-tenant setups this header may be omitted. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;DatabaseInfoSearchResult&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<DatabaseInfoSearchResult>>> ListJobsWithHttpInfoAsync(DatabaseInfoSearch databaseInfoSearch, string? xTenantId = default, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Stop a running job gracefully.
        /// </summary>
        /// <remarks>
        /// Sends a graceful stop signal to the running optimization identified by jobId. The optimizer finishes its current iteration and persists the best result found so far. Returns immediately — the stop may take several seconds to complete. Poll GET /api/v1/jobs/{jobId}/status to confirm termination. Returns 200 if the job was found and the signal was sent. Returns 404 if the job is not running (already completed or never started).
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of bool</returns>
        System.Threading.Tasks.Task<bool> StopJobAsync(string jobId, string xTenantId, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Stop a running job gracefully.
        /// </summary>
        /// <remarks>
        /// Sends a graceful stop signal to the running optimization identified by jobId. The optimizer finishes its current iteration and persists the best result found so far. Returns immediately — the stop may take several seconds to complete. Poll GET /api/v1/jobs/{jobId}/status to confirm termination. Returns 200 if the job was found and the signal was sent. Returns 404 if the job is not running (already completed or never started).
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (bool)</returns>
        System.Threading.Tasks.Task<ApiResponse<bool>> StopJobWithHttpInfoAsync(string jobId, string xTenantId, System.Threading.CancellationToken cancellationToken = default);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IJobApi : IJobApiSync, IJobApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class JobApi : IDisposable, IJobApi
    {
        private Org.OpenAPITools.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobApi"/> class.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <returns></returns>
        public JobApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobApi"/> class.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        public JobApi(string basePath)
        {
            this.Configuration = Org.OpenAPITools.Client.Configuration.MergeConfigurations(
                Org.OpenAPITools.Client.GlobalConfiguration.Instance,
                new Org.OpenAPITools.Client.Configuration { BasePath = basePath }
            );
            this.ApiClient = new Org.OpenAPITools.Client.ApiClient(this.Configuration.BasePath);
            this.Client =  this.ApiClient;
            this.AsynchronousClient = this.ApiClient;
            this.ExceptionFactory = Org.OpenAPITools.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobApi"/> class using Configuration object.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="configuration">An instance of Configuration.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public JobApi(Org.OpenAPITools.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = Org.OpenAPITools.Client.Configuration.MergeConfigurations(
                Org.OpenAPITools.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.ApiClient = new Org.OpenAPITools.Client.ApiClient(this.Configuration.BasePath);
            this.Client = this.ApiClient;
            this.AsynchronousClient = this.ApiClient;
            ExceptionFactory = Org.OpenAPITools.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobApi"/> class.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public JobApi(HttpClient client, HttpClientHandler handler = null) : this(client, (string)null, handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobApi"/> class.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public JobApi(HttpClient client, string basePath, HttpClientHandler handler = null)
        {
            if (client == null) throw new ArgumentNullException("client");

            this.Configuration = Org.OpenAPITools.Client.Configuration.MergeConfigurations(
                Org.OpenAPITools.Client.GlobalConfiguration.Instance,
                new Org.OpenAPITools.Client.Configuration { BasePath = basePath }
            );
            this.ApiClient = new Org.OpenAPITools.Client.ApiClient(client, this.Configuration.BasePath, handler);
            this.Client =  this.ApiClient;
            this.AsynchronousClient = this.ApiClient;
            this.ExceptionFactory = Org.OpenAPITools.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobApi"/> class using Configuration object.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="configuration">An instance of Configuration.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public JobApi(HttpClient client, Org.OpenAPITools.Client.Configuration configuration, HttpClientHandler handler = null)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");
            if (client == null) throw new ArgumentNullException("client");

            this.Configuration = Org.OpenAPITools.Client.Configuration.MergeConfigurations(
                Org.OpenAPITools.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.ApiClient = new Org.OpenAPITools.Client.ApiClient(client, this.Configuration.BasePath, handler);
            this.Client = this.ApiClient;
            this.AsynchronousClient = this.ApiClient;
            ExceptionFactory = Org.OpenAPITools.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public JobApi(Org.OpenAPITools.Client.ISynchronousClient client, Org.OpenAPITools.Client.IAsynchronousClient asyncClient, Org.OpenAPITools.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = Org.OpenAPITools.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Disposes resources if they were created by us
        /// </summary>
        public void Dispose()
        {
            this.ApiClient?.Dispose();
        }

        /// <summary>
        /// Holds the ApiClient if created
        /// </summary>
        public Org.OpenAPITools.Client.ApiClient ApiClient { get; set; } = null;

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public Org.OpenAPITools.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public Org.OpenAPITools.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Org.OpenAPITools.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public Org.OpenAPITools.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Submit an optimization job. Accepts a RestOptimization payload and starts processing asynchronously. Returns HTTP 202 with a JobAcceptedResponse containing a unique jobId. Use the jobId with X-Tenant-Id to poll the job read endpoints for status, progress, warnings, errors, and the final result. Persistence is scoped to the tenant identified by the X-Tenant-Id header.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway. Scopes all persisted data to this tenant.</param>
        /// <param name="restOptimization"></param>
        /// <returns>JobAcceptedResponse</returns>
        public JobAcceptedResponse CreateJob(string xTenantId, RestOptimization restOptimization)
        {
            Org.OpenAPITools.Client.ApiResponse<JobAcceptedResponse> localVarResponse = CreateJobWithHttpInfo(xTenantId, restOptimization);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Submit an optimization job. Accepts a RestOptimization payload and starts processing asynchronously. Returns HTTP 202 with a JobAcceptedResponse containing a unique jobId. Use the jobId with X-Tenant-Id to poll the job read endpoints for status, progress, warnings, errors, and the final result. Persistence is scoped to the tenant identified by the X-Tenant-Id header.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway. Scopes all persisted data to this tenant.</param>
        /// <param name="restOptimization"></param>
        /// <returns>ApiResponse of JobAcceptedResponse</returns>
        public Org.OpenAPITools.Client.ApiResponse<JobAcceptedResponse> CreateJobWithHttpInfo(string xTenantId, RestOptimization restOptimization)
        {
            // verify the required parameter 'xTenantId' is set
            if (xTenantId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'xTenantId' when calling JobApi->CreateJob");

            // verify the required parameter 'restOptimization' is set
            if (restOptimization == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'restOptimization' when calling JobApi->CreateJob");

            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xTenantId)); // header parameter
            localVarRequestOptions.Data = restOptimization;

            // authentication (TenantId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id")))
            {
                localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<JobAcceptedResponse>("/api/v1/jobs", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateJob", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Submit an optimization job. Accepts a RestOptimization payload and starts processing asynchronously. Returns HTTP 202 with a JobAcceptedResponse containing a unique jobId. Use the jobId with X-Tenant-Id to poll the job read endpoints for status, progress, warnings, errors, and the final result. Persistence is scoped to the tenant identified by the X-Tenant-Id header.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway. Scopes all persisted data to this tenant.</param>
        /// <param name="restOptimization"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of JobAcceptedResponse</returns>
        public async System.Threading.Tasks.Task<JobAcceptedResponse> CreateJobAsync(string xTenantId, RestOptimization restOptimization, System.Threading.CancellationToken cancellationToken = default)
        {
            Org.OpenAPITools.Client.ApiResponse<JobAcceptedResponse> localVarResponse = await CreateJobWithHttpInfoAsync(xTenantId, restOptimization, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Submit an optimization job. Accepts a RestOptimization payload and starts processing asynchronously. Returns HTTP 202 with a JobAcceptedResponse containing a unique jobId. Use the jobId with X-Tenant-Id to poll the job read endpoints for status, progress, warnings, errors, and the final result. Persistence is scoped to the tenant identified by the X-Tenant-Id header.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway. Scopes all persisted data to this tenant.</param>
        /// <param name="restOptimization"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (JobAcceptedResponse)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<JobAcceptedResponse>> CreateJobWithHttpInfoAsync(string xTenantId, RestOptimization restOptimization, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'xTenantId' is set
            if (xTenantId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'xTenantId' when calling JobApi->CreateJob");

            // verify the required parameter 'restOptimization' is set
            if (restOptimization == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'restOptimization' when calling JobApi->CreateJob");


            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };


            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xTenantId)); // header parameter
            localVarRequestOptions.Data = restOptimization;

            // authentication (TenantId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id")))
            {
                localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<JobAcceptedResponse>("/api/v1/jobs", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateJob", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete all persisted data for a job. Permanently removes the optimization result and all associated stream documents (progress, status, warnings, errors) for the given jobId from the database. Does not stop a running optimization — call POST /api/v1/jobs/{jobId}/stop first and wait for the job to terminate before deleting. Idempotent: returns 200 even if no data exists for this jobId.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <returns>bool</returns>
        public bool DeleteJob(string jobId, string xTenantId)
        {
            Org.OpenAPITools.Client.ApiResponse<bool> localVarResponse = DeleteJobWithHttpInfo(jobId, xTenantId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Delete all persisted data for a job. Permanently removes the optimization result and all associated stream documents (progress, status, warnings, errors) for the given jobId from the database. Does not stop a running optimization — call POST /api/v1/jobs/{jobId}/stop first and wait for the job to terminate before deleting. Idempotent: returns 200 even if no data exists for this jobId.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <returns>ApiResponse of bool</returns>
        public Org.OpenAPITools.Client.ApiResponse<bool> DeleteJobWithHttpInfo(string jobId, string xTenantId)
        {
            // verify the required parameter 'jobId' is set
            if (jobId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'jobId' when calling JobApi->DeleteJob");

            // verify the required parameter 'xTenantId' is set
            if (xTenantId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'xTenantId' when calling JobApi->DeleteJob");

            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("jobId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(jobId)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xTenantId)); // header parameter

            // authentication (TenantId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id")))
            {
                localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Delete<bool>("/api/v1/jobs/{jobId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteJob", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete all persisted data for a job. Permanently removes the optimization result and all associated stream documents (progress, status, warnings, errors) for the given jobId from the database. Does not stop a running optimization — call POST /api/v1/jobs/{jobId}/stop first and wait for the job to terminate before deleting. Idempotent: returns 200 even if no data exists for this jobId.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of bool</returns>
        public async System.Threading.Tasks.Task<bool> DeleteJobAsync(string jobId, string xTenantId, System.Threading.CancellationToken cancellationToken = default)
        {
            Org.OpenAPITools.Client.ApiResponse<bool> localVarResponse = await DeleteJobWithHttpInfoAsync(jobId, xTenantId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Delete all persisted data for a job. Permanently removes the optimization result and all associated stream documents (progress, status, warnings, errors) for the given jobId from the database. Does not stop a running optimization — call POST /api/v1/jobs/{jobId}/stop first and wait for the job to terminate before deleting. Idempotent: returns 200 even if no data exists for this jobId.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (bool)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<bool>> DeleteJobWithHttpInfoAsync(string jobId, string xTenantId, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'jobId' is set
            if (jobId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'jobId' when calling JobApi->DeleteJob");

            // verify the required parameter 'xTenantId' is set
            if (xTenantId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'xTenantId' when calling JobApi->DeleteJob");


            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };


            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("jobId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(jobId)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xTenantId)); // header parameter

            // authentication (TenantId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id")))
            {
                localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<bool>("/api/v1/jobs/{jobId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteJob", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Download the optimization result as a ZIP archive. Returns a ZIP archive of the persisted optimization result for the given job. If the result was stored with client-side encryption, provide the original passphrase via X-Encryption-Secret and the archive will be decrypted before streaming. For KMS-encrypted or unencrypted results the header can be omitted — decryption is handled transparently by the server. The Content-Disposition header carries the suggested filename.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="xEncryptionSecret">Client decryption secret. Required only for CLIENT-mode encrypted results. Omit for KMS or unencrypted. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>FileParameter</returns>
        public FileParameter ExportJob(string jobId, string xTenantId, string? xEncryptionSecret = default, string? timeOut = default)
        {
            Org.OpenAPITools.Client.ApiResponse<FileParameter> localVarResponse = ExportJobWithHttpInfo(jobId, xTenantId, xEncryptionSecret, timeOut);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Download the optimization result as a ZIP archive. Returns a ZIP archive of the persisted optimization result for the given job. If the result was stored with client-side encryption, provide the original passphrase via X-Encryption-Secret and the archive will be decrypted before streaming. For KMS-encrypted or unencrypted results the header can be omitted — decryption is handled transparently by the server. The Content-Disposition header carries the suggested filename.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="xEncryptionSecret">Client decryption secret. Required only for CLIENT-mode encrypted results. Omit for KMS or unencrypted. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>ApiResponse of FileParameter</returns>
        public Org.OpenAPITools.Client.ApiResponse<FileParameter> ExportJobWithHttpInfo(string jobId, string xTenantId, string? xEncryptionSecret = default, string? timeOut = default)
        {
            // verify the required parameter 'jobId' is set
            if (jobId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'jobId' when calling JobApi->ExportJob");

            // verify the required parameter 'xTenantId' is set
            if (xTenantId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'xTenantId' when calling JobApi->ExportJob");

            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/octet-stream",
                "application/json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("jobId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(jobId)); // path parameter
            if (timeOut != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "timeOut", timeOut));
            }
            localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xTenantId)); // header parameter
            if (xEncryptionSecret != null)
            {
                localVarRequestOptions.HeaderParameters.Add("X-Encryption-Secret", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xEncryptionSecret)); // header parameter
            }

            // authentication (TenantId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id")))
            {
                localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<FileParameter>("/api/v1/jobs/{jobId}/export", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ExportJob", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Download the optimization result as a ZIP archive. Returns a ZIP archive of the persisted optimization result for the given job. If the result was stored with client-side encryption, provide the original passphrase via X-Encryption-Secret and the archive will be decrypted before streaming. For KMS-encrypted or unencrypted results the header can be omitted — decryption is handled transparently by the server. The Content-Disposition header carries the suggested filename.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="xEncryptionSecret">Client decryption secret. Required only for CLIENT-mode encrypted results. Omit for KMS or unencrypted. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of FileParameter</returns>
        public async System.Threading.Tasks.Task<FileParameter> ExportJobAsync(string jobId, string xTenantId, string? xEncryptionSecret = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default)
        {
            Org.OpenAPITools.Client.ApiResponse<FileParameter> localVarResponse = await ExportJobWithHttpInfoAsync(jobId, xTenantId, xEncryptionSecret, timeOut, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Download the optimization result as a ZIP archive. Returns a ZIP archive of the persisted optimization result for the given job. If the result was stored with client-side encryption, provide the original passphrase via X-Encryption-Secret and the archive will be decrypted before streaming. For KMS-encrypted or unencrypted results the header can be omitted — decryption is handled transparently by the server. The Content-Disposition header carries the suggested filename.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="xEncryptionSecret">Client decryption secret. Required only for CLIENT-mode encrypted results. Omit for KMS or unencrypted. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (FileParameter)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<FileParameter>> ExportJobWithHttpInfoAsync(string jobId, string xTenantId, string? xEncryptionSecret = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'jobId' is set
            if (jobId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'jobId' when calling JobApi->ExportJob");

            // verify the required parameter 'xTenantId' is set
            if (xTenantId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'xTenantId' when calling JobApi->ExportJob");


            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/octet-stream",
                "application/json"
            };


            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("jobId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(jobId)); // path parameter
            if (timeOut != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "timeOut", timeOut));
            }
            localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xTenantId)); // header parameter
            if (xEncryptionSecret != null)
            {
                localVarRequestOptions.HeaderParameters.Add("X-Encryption-Secret", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xEncryptionSecret)); // header parameter
            }

            // authentication (TenantId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id")))
            {
                localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<FileParameter>("/api/v1/jobs/{jobId}/export", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ExportJob", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve error messages for a job. Returns persisted error messages for the given job. Errors are only persisted if saveError was enabled in the MongoOptimizationPersistenceSetting.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of errors to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>List&lt;JOptOptimizationError&gt;</returns>
        public List<JOptOptimizationError> GetJobErrors(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default)
        {
            Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationError>> localVarResponse = GetJobErrorsWithHttpInfo(jobId, xTenantId, limit, sortDirection, timeOut);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve error messages for a job. Returns persisted error messages for the given job. Errors are only persisted if saveError was enabled in the MongoOptimizationPersistenceSetting.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of errors to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>ApiResponse of List&lt;JOptOptimizationError&gt;</returns>
        public Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationError>> GetJobErrorsWithHttpInfo(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default)
        {
            // verify the required parameter 'jobId' is set
            if (jobId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'jobId' when calling JobApi->GetJobErrors");

            // verify the required parameter 'xTenantId' is set
            if (xTenantId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'xTenantId' when calling JobApi->GetJobErrors");

            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("jobId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(jobId)); // path parameter
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (sortDirection != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "sortDirection", sortDirection));
            }
            if (timeOut != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "timeOut", timeOut));
            }
            localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xTenantId)); // header parameter

            // authentication (TenantId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id")))
            {
                localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<List<JOptOptimizationError>>("/api/v1/jobs/{jobId}/errors", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetJobErrors", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve error messages for a job. Returns persisted error messages for the given job. Errors are only persisted if saveError was enabled in the MongoOptimizationPersistenceSetting.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of errors to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;JOptOptimizationError&gt;</returns>
        public async System.Threading.Tasks.Task<List<JOptOptimizationError>> GetJobErrorsAsync(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default)
        {
            Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationError>> localVarResponse = await GetJobErrorsWithHttpInfoAsync(jobId, xTenantId, limit, sortDirection, timeOut, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve error messages for a job. Returns persisted error messages for the given job. Errors are only persisted if saveError was enabled in the MongoOptimizationPersistenceSetting.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of errors to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;JOptOptimizationError&gt;)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationError>>> GetJobErrorsWithHttpInfoAsync(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'jobId' is set
            if (jobId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'jobId' when calling JobApi->GetJobErrors");

            // verify the required parameter 'xTenantId' is set
            if (xTenantId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'xTenantId' when calling JobApi->GetJobErrors");


            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };


            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("jobId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(jobId)); // path parameter
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (sortDirection != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "sortDirection", sortDirection));
            }
            if (timeOut != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "timeOut", timeOut));
            }
            localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xTenantId)); // header parameter

            // authentication (TenantId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id")))
            {
                localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<JOptOptimizationError>>("/api/v1/jobs/{jobId}/errors", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetJobErrors", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve progress snapshots for a job. Returns persisted progress snapshots for the given job. Progress events are only persisted if saveProgress was enabled in the MongoOptimizationPersistenceSetting.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of snapshots to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>List&lt;JOptOptimizationProgress&gt;</returns>
        public List<JOptOptimizationProgress> GetJobProgress(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default)
        {
            Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationProgress>> localVarResponse = GetJobProgressWithHttpInfo(jobId, xTenantId, limit, sortDirection, timeOut);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve progress snapshots for a job. Returns persisted progress snapshots for the given job. Progress events are only persisted if saveProgress was enabled in the MongoOptimizationPersistenceSetting.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of snapshots to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>ApiResponse of List&lt;JOptOptimizationProgress&gt;</returns>
        public Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationProgress>> GetJobProgressWithHttpInfo(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default)
        {
            // verify the required parameter 'jobId' is set
            if (jobId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'jobId' when calling JobApi->GetJobProgress");

            // verify the required parameter 'xTenantId' is set
            if (xTenantId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'xTenantId' when calling JobApi->GetJobProgress");

            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("jobId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(jobId)); // path parameter
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (sortDirection != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "sortDirection", sortDirection));
            }
            if (timeOut != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "timeOut", timeOut));
            }
            localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xTenantId)); // header parameter

            // authentication (TenantId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id")))
            {
                localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<List<JOptOptimizationProgress>>("/api/v1/jobs/{jobId}/progress", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetJobProgress", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve progress snapshots for a job. Returns persisted progress snapshots for the given job. Progress events are only persisted if saveProgress was enabled in the MongoOptimizationPersistenceSetting.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of snapshots to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;JOptOptimizationProgress&gt;</returns>
        public async System.Threading.Tasks.Task<List<JOptOptimizationProgress>> GetJobProgressAsync(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default)
        {
            Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationProgress>> localVarResponse = await GetJobProgressWithHttpInfoAsync(jobId, xTenantId, limit, sortDirection, timeOut, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve progress snapshots for a job. Returns persisted progress snapshots for the given job. Progress events are only persisted if saveProgress was enabled in the MongoOptimizationPersistenceSetting.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of snapshots to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;JOptOptimizationProgress&gt;)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationProgress>>> GetJobProgressWithHttpInfoAsync(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'jobId' is set
            if (jobId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'jobId' when calling JobApi->GetJobProgress");

            // verify the required parameter 'xTenantId' is set
            if (xTenantId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'xTenantId' when calling JobApi->GetJobProgress");


            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };


            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("jobId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(jobId)); // path parameter
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (sortDirection != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "sortDirection", sortDirection));
            }
            if (timeOut != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "timeOut", timeOut));
            }
            localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xTenantId)); // header parameter

            // authentication (TenantId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id")))
            {
                localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<JOptOptimizationProgress>>("/api/v1/jobs/{jobId}/progress", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetJobProgress", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve the full optimization result for a job. Loads the complete persisted optimization snapshot for the given jobId, scoped to the authenticated tenant. If the result was client-encrypted, provide the original secret via X-Encryption-Secret; for KMS-encrypted or unencrypted results the header can be omitted.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="xEncryptionSecret">Client decryption secret. Required only for CLIENT-mode encrypted results. Omit for KMS or unencrypted. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>RestOptimization</returns>
        public RestOptimization GetJobResult(string jobId, string xTenantId, string? xEncryptionSecret = default, string? timeOut = default)
        {
            Org.OpenAPITools.Client.ApiResponse<RestOptimization> localVarResponse = GetJobResultWithHttpInfo(jobId, xTenantId, xEncryptionSecret, timeOut);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve the full optimization result for a job. Loads the complete persisted optimization snapshot for the given jobId, scoped to the authenticated tenant. If the result was client-encrypted, provide the original secret via X-Encryption-Secret; for KMS-encrypted or unencrypted results the header can be omitted.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="xEncryptionSecret">Client decryption secret. Required only for CLIENT-mode encrypted results. Omit for KMS or unencrypted. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>ApiResponse of RestOptimization</returns>
        public Org.OpenAPITools.Client.ApiResponse<RestOptimization> GetJobResultWithHttpInfo(string jobId, string xTenantId, string? xEncryptionSecret = default, string? timeOut = default)
        {
            // verify the required parameter 'jobId' is set
            if (jobId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'jobId' when calling JobApi->GetJobResult");

            // verify the required parameter 'xTenantId' is set
            if (xTenantId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'xTenantId' when calling JobApi->GetJobResult");

            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("jobId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(jobId)); // path parameter
            if (timeOut != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "timeOut", timeOut));
            }
            localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xTenantId)); // header parameter
            if (xEncryptionSecret != null)
            {
                localVarRequestOptions.HeaderParameters.Add("X-Encryption-Secret", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xEncryptionSecret)); // header parameter
            }

            // authentication (TenantId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id")))
            {
                localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<RestOptimization>("/api/v1/jobs/{jobId}/result", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetJobResult", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve the full optimization result for a job. Loads the complete persisted optimization snapshot for the given jobId, scoped to the authenticated tenant. If the result was client-encrypted, provide the original secret via X-Encryption-Secret; for KMS-encrypted or unencrypted results the header can be omitted.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="xEncryptionSecret">Client decryption secret. Required only for CLIENT-mode encrypted results. Omit for KMS or unencrypted. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of RestOptimization</returns>
        public async System.Threading.Tasks.Task<RestOptimization> GetJobResultAsync(string jobId, string xTenantId, string? xEncryptionSecret = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default)
        {
            Org.OpenAPITools.Client.ApiResponse<RestOptimization> localVarResponse = await GetJobResultWithHttpInfoAsync(jobId, xTenantId, xEncryptionSecret, timeOut, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve the full optimization result for a job. Loads the complete persisted optimization snapshot for the given jobId, scoped to the authenticated tenant. If the result was client-encrypted, provide the original secret via X-Encryption-Secret; for KMS-encrypted or unencrypted results the header can be omitted.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="xEncryptionSecret">Client decryption secret. Required only for CLIENT-mode encrypted results. Omit for KMS or unencrypted. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (RestOptimization)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<RestOptimization>> GetJobResultWithHttpInfoAsync(string jobId, string xTenantId, string? xEncryptionSecret = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'jobId' is set
            if (jobId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'jobId' when calling JobApi->GetJobResult");

            // verify the required parameter 'xTenantId' is set
            if (xTenantId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'xTenantId' when calling JobApi->GetJobResult");


            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };


            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("jobId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(jobId)); // path parameter
            if (timeOut != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "timeOut", timeOut));
            }
            localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xTenantId)); // header parameter
            if (xEncryptionSecret != null)
            {
                localVarRequestOptions.HeaderParameters.Add("X-Encryption-Secret", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xEncryptionSecret)); // header parameter
            }

            // authentication (TenantId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id")))
            {
                localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<RestOptimization>("/api/v1/jobs/{jobId}/result", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetJobResult", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve the solution payload for a job. Returns the Solution portion of the optimization result only, omitting the full optimization input echo. Useful for lightweight integrations that do not need the complete RestOptimization envelope. If the result was client-encrypted, provide X-Encryption-Secret.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="xEncryptionSecret">Client decryption secret. Required only for CLIENT-mode encrypted results. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>Solution</returns>
        public Solution GetJobSolution(string jobId, string xTenantId, string? xEncryptionSecret = default, string? timeOut = default)
        {
            Org.OpenAPITools.Client.ApiResponse<Solution> localVarResponse = GetJobSolutionWithHttpInfo(jobId, xTenantId, xEncryptionSecret, timeOut);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve the solution payload for a job. Returns the Solution portion of the optimization result only, omitting the full optimization input echo. Useful for lightweight integrations that do not need the complete RestOptimization envelope. If the result was client-encrypted, provide X-Encryption-Secret.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="xEncryptionSecret">Client decryption secret. Required only for CLIENT-mode encrypted results. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>ApiResponse of Solution</returns>
        public Org.OpenAPITools.Client.ApiResponse<Solution> GetJobSolutionWithHttpInfo(string jobId, string xTenantId, string? xEncryptionSecret = default, string? timeOut = default)
        {
            // verify the required parameter 'jobId' is set
            if (jobId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'jobId' when calling JobApi->GetJobSolution");

            // verify the required parameter 'xTenantId' is set
            if (xTenantId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'xTenantId' when calling JobApi->GetJobSolution");

            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("jobId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(jobId)); // path parameter
            if (timeOut != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "timeOut", timeOut));
            }
            localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xTenantId)); // header parameter
            if (xEncryptionSecret != null)
            {
                localVarRequestOptions.HeaderParameters.Add("X-Encryption-Secret", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xEncryptionSecret)); // header parameter
            }

            // authentication (TenantId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id")))
            {
                localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<Solution>("/api/v1/jobs/{jobId}/solution", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetJobSolution", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve the solution payload for a job. Returns the Solution portion of the optimization result only, omitting the full optimization input echo. Useful for lightweight integrations that do not need the complete RestOptimization envelope. If the result was client-encrypted, provide X-Encryption-Secret.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="xEncryptionSecret">Client decryption secret. Required only for CLIENT-mode encrypted results. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Solution</returns>
        public async System.Threading.Tasks.Task<Solution> GetJobSolutionAsync(string jobId, string xTenantId, string? xEncryptionSecret = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default)
        {
            Org.OpenAPITools.Client.ApiResponse<Solution> localVarResponse = await GetJobSolutionWithHttpInfoAsync(jobId, xTenantId, xEncryptionSecret, timeOut, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve the solution payload for a job. Returns the Solution portion of the optimization result only, omitting the full optimization input echo. Useful for lightweight integrations that do not need the complete RestOptimization envelope. If the result was client-encrypted, provide X-Encryption-Secret.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="xEncryptionSecret">Client decryption secret. Required only for CLIENT-mode encrypted results. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Solution)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<Solution>> GetJobSolutionWithHttpInfoAsync(string jobId, string xTenantId, string? xEncryptionSecret = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'jobId' is set
            if (jobId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'jobId' when calling JobApi->GetJobSolution");

            // verify the required parameter 'xTenantId' is set
            if (xTenantId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'xTenantId' when calling JobApi->GetJobSolution");


            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };


            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("jobId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(jobId)); // path parameter
            if (timeOut != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "timeOut", timeOut));
            }
            localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xTenantId)); // header parameter
            if (xEncryptionSecret != null)
            {
                localVarRequestOptions.HeaderParameters.Add("X-Encryption-Secret", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xEncryptionSecret)); // header parameter
            }

            // authentication (TenantId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id")))
            {
                localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<Solution>("/api/v1/jobs/{jobId}/solution", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetJobSolution", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve status updates for a job. Returns persisted status lifecycle events for the given job (e.g. RUNNING, SUCCESS_WITH_SOLUTION, ERROR). Status events are only persisted if saveStatus was enabled in the MongoOptimizationPersistenceSetting.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of events to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>List&lt;JOptOptimizationStatus&gt;</returns>
        public List<JOptOptimizationStatus> GetJobStatus(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default)
        {
            Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationStatus>> localVarResponse = GetJobStatusWithHttpInfo(jobId, xTenantId, limit, sortDirection, timeOut);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve status updates for a job. Returns persisted status lifecycle events for the given job (e.g. RUNNING, SUCCESS_WITH_SOLUTION, ERROR). Status events are only persisted if saveStatus was enabled in the MongoOptimizationPersistenceSetting.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of events to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>ApiResponse of List&lt;JOptOptimizationStatus&gt;</returns>
        public Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationStatus>> GetJobStatusWithHttpInfo(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default)
        {
            // verify the required parameter 'jobId' is set
            if (jobId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'jobId' when calling JobApi->GetJobStatus");

            // verify the required parameter 'xTenantId' is set
            if (xTenantId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'xTenantId' when calling JobApi->GetJobStatus");

            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("jobId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(jobId)); // path parameter
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (sortDirection != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "sortDirection", sortDirection));
            }
            if (timeOut != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "timeOut", timeOut));
            }
            localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xTenantId)); // header parameter

            // authentication (TenantId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id")))
            {
                localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<List<JOptOptimizationStatus>>("/api/v1/jobs/{jobId}/status", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetJobStatus", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve status updates for a job. Returns persisted status lifecycle events for the given job (e.g. RUNNING, SUCCESS_WITH_SOLUTION, ERROR). Status events are only persisted if saveStatus was enabled in the MongoOptimizationPersistenceSetting.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of events to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;JOptOptimizationStatus&gt;</returns>
        public async System.Threading.Tasks.Task<List<JOptOptimizationStatus>> GetJobStatusAsync(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default)
        {
            Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationStatus>> localVarResponse = await GetJobStatusWithHttpInfoAsync(jobId, xTenantId, limit, sortDirection, timeOut, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve status updates for a job. Returns persisted status lifecycle events for the given job (e.g. RUNNING, SUCCESS_WITH_SOLUTION, ERROR). Status events are only persisted if saveStatus was enabled in the MongoOptimizationPersistenceSetting.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of events to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;JOptOptimizationStatus&gt;)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationStatus>>> GetJobStatusWithHttpInfoAsync(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'jobId' is set
            if (jobId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'jobId' when calling JobApi->GetJobStatus");

            // verify the required parameter 'xTenantId' is set
            if (xTenantId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'xTenantId' when calling JobApi->GetJobStatus");


            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };


            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("jobId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(jobId)); // path parameter
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (sortDirection != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "sortDirection", sortDirection));
            }
            if (timeOut != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "timeOut", timeOut));
            }
            localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xTenantId)); // header parameter

            // authentication (TenantId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id")))
            {
                localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<JOptOptimizationStatus>>("/api/v1/jobs/{jobId}/status", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetJobStatus", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve warning messages for a job. Returns persisted warning messages for the given job. Warnings are only persisted if saveWarning was enabled in the MongoOptimizationPersistenceSetting.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of warnings to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>List&lt;JOptOptimizationWarning&gt;</returns>
        public List<JOptOptimizationWarning> GetJobWarnings(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default)
        {
            Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationWarning>> localVarResponse = GetJobWarningsWithHttpInfo(jobId, xTenantId, limit, sortDirection, timeOut);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve warning messages for a job. Returns persisted warning messages for the given job. Warnings are only persisted if saveWarning was enabled in the MongoOptimizationPersistenceSetting.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of warnings to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <returns>ApiResponse of List&lt;JOptOptimizationWarning&gt;</returns>
        public Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationWarning>> GetJobWarningsWithHttpInfo(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default)
        {
            // verify the required parameter 'jobId' is set
            if (jobId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'jobId' when calling JobApi->GetJobWarnings");

            // verify the required parameter 'xTenantId' is set
            if (xTenantId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'xTenantId' when calling JobApi->GetJobWarnings");

            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("jobId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(jobId)); // path parameter
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (sortDirection != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "sortDirection", sortDirection));
            }
            if (timeOut != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "timeOut", timeOut));
            }
            localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xTenantId)); // header parameter

            // authentication (TenantId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id")))
            {
                localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<List<JOptOptimizationWarning>>("/api/v1/jobs/{jobId}/warnings", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetJobWarnings", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve warning messages for a job. Returns persisted warning messages for the given job. Warnings are only persisted if saveWarning was enabled in the MongoOptimizationPersistenceSetting.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of warnings to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;JOptOptimizationWarning&gt;</returns>
        public async System.Threading.Tasks.Task<List<JOptOptimizationWarning>> GetJobWarningsAsync(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default)
        {
            Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationWarning>> localVarResponse = await GetJobWarningsWithHttpInfoAsync(jobId, xTenantId, limit, sortDirection, timeOut, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve warning messages for a job. Returns persisted warning messages for the given job. Warnings are only persisted if saveWarning was enabled in the MongoOptimizationPersistenceSetting.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="limit">Maximum number of warnings to return. (optional)</param>
        /// <param name="sortDirection">Sort direction by event time: DESC (newest first) or ASC. Defaults to DESC. (optional)</param>
        /// <param name="timeOut">Maximum time to wait for the database response (ISO 8601 duration). Defaults to PT1M. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;JOptOptimizationWarning&gt;)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationWarning>>> GetJobWarningsWithHttpInfoAsync(string jobId, string xTenantId, int? limit = default, string? sortDirection = default, string? timeOut = default, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'jobId' is set
            if (jobId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'jobId' when calling JobApi->GetJobWarnings");

            // verify the required parameter 'xTenantId' is set
            if (xTenantId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'xTenantId' when calling JobApi->GetJobWarnings");


            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };


            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("jobId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(jobId)); // path parameter
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (sortDirection != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "sortDirection", sortDirection));
            }
            if (timeOut != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "timeOut", timeOut));
            }
            localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xTenantId)); // header parameter

            // authentication (TenantId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id")))
            {
                localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<JOptOptimizationWarning>>("/api/v1/jobs/{jobId}/warnings", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetJobWarnings", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Import a pre-computed optimization result into the database. Persists a RestOptimization payload directly without running the optimizer. The call blocks until the write completes. Returns a JobAcceptedResponse containing the generated jobId, which can be used immediately with GET /api/v1/jobs/{jobId}/result to retrieve the imported result. Persistence must be enabled in the RestOptimization extension settings. The tenant is scoped by the X-Tenant-Id header.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway. Scopes the persisted result to this tenant.</param>
        /// <param name="restOptimization"></param>
        /// <returns>JobAcceptedResponse</returns>
        public JobAcceptedResponse ImportJob(string xTenantId, RestOptimization restOptimization)
        {
            Org.OpenAPITools.Client.ApiResponse<JobAcceptedResponse> localVarResponse = ImportJobWithHttpInfo(xTenantId, restOptimization);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Import a pre-computed optimization result into the database. Persists a RestOptimization payload directly without running the optimizer. The call blocks until the write completes. Returns a JobAcceptedResponse containing the generated jobId, which can be used immediately with GET /api/v1/jobs/{jobId}/result to retrieve the imported result. Persistence must be enabled in the RestOptimization extension settings. The tenant is scoped by the X-Tenant-Id header.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway. Scopes the persisted result to this tenant.</param>
        /// <param name="restOptimization"></param>
        /// <returns>ApiResponse of JobAcceptedResponse</returns>
        public Org.OpenAPITools.Client.ApiResponse<JobAcceptedResponse> ImportJobWithHttpInfo(string xTenantId, RestOptimization restOptimization)
        {
            // verify the required parameter 'xTenantId' is set
            if (xTenantId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'xTenantId' when calling JobApi->ImportJob");

            // verify the required parameter 'restOptimization' is set
            if (restOptimization == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'restOptimization' when calling JobApi->ImportJob");

            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xTenantId)); // header parameter
            localVarRequestOptions.Data = restOptimization;

            // authentication (TenantId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id")))
            {
                localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<JobAcceptedResponse>("/api/v1/jobs/import", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ImportJob", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Import a pre-computed optimization result into the database. Persists a RestOptimization payload directly without running the optimizer. The call blocks until the write completes. Returns a JobAcceptedResponse containing the generated jobId, which can be used immediately with GET /api/v1/jobs/{jobId}/result to retrieve the imported result. Persistence must be enabled in the RestOptimization extension settings. The tenant is scoped by the X-Tenant-Id header.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway. Scopes the persisted result to this tenant.</param>
        /// <param name="restOptimization"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of JobAcceptedResponse</returns>
        public async System.Threading.Tasks.Task<JobAcceptedResponse> ImportJobAsync(string xTenantId, RestOptimization restOptimization, System.Threading.CancellationToken cancellationToken = default)
        {
            Org.OpenAPITools.Client.ApiResponse<JobAcceptedResponse> localVarResponse = await ImportJobWithHttpInfoAsync(xTenantId, restOptimization, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Import a pre-computed optimization result into the database. Persists a RestOptimization payload directly without running the optimizer. The call blocks until the write completes. Returns a JobAcceptedResponse containing the generated jobId, which can be used immediately with GET /api/v1/jobs/{jobId}/result to retrieve the imported result. Persistence must be enabled in the RestOptimization extension settings. The tenant is scoped by the X-Tenant-Id header.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway. Scopes the persisted result to this tenant.</param>
        /// <param name="restOptimization"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (JobAcceptedResponse)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<JobAcceptedResponse>> ImportJobWithHttpInfoAsync(string xTenantId, RestOptimization restOptimization, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'xTenantId' is set
            if (xTenantId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'xTenantId' when calling JobApi->ImportJob");

            // verify the required parameter 'restOptimization' is set
            if (restOptimization == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'restOptimization' when calling JobApi->ImportJob");


            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };


            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xTenantId)); // header parameter
            localVarRequestOptions.Data = restOptimization;

            // authentication (TenantId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id")))
            {
                localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<JobAcceptedResponse>("/api/v1/jobs/import", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ImportJob", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Search persisted optimization jobs and return metadata summaries. Accepts a DatabaseInfoSearch body and returns a stream of metadata summaries for all matching optimization jobs. All fields in the search body are optional and combinable. Results are sorted by upload date, newest first by default. Each entry contains a jobId that can be used directly with GET /api/v1/jobs/{jobId}/result to retrieve the full optimization result. Fields absent for encrypted jobs (creator, ident, status, createdTimeStamp) are omitted from each result entry. On-premise only: requires a connected database.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="databaseInfoSearch"></param>
        /// <param name="xTenantId">Tenant identifier. When provided, results are scoped to this tenant. In on-premise single-tenant setups this header may be omitted. (optional)</param>
        /// <returns>List&lt;DatabaseInfoSearchResult&gt;</returns>
        public List<DatabaseInfoSearchResult> ListJobs(DatabaseInfoSearch databaseInfoSearch, string? xTenantId = default)
        {
            Org.OpenAPITools.Client.ApiResponse<List<DatabaseInfoSearchResult>> localVarResponse = ListJobsWithHttpInfo(databaseInfoSearch, xTenantId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Search persisted optimization jobs and return metadata summaries. Accepts a DatabaseInfoSearch body and returns a stream of metadata summaries for all matching optimization jobs. All fields in the search body are optional and combinable. Results are sorted by upload date, newest first by default. Each entry contains a jobId that can be used directly with GET /api/v1/jobs/{jobId}/result to retrieve the full optimization result. Fields absent for encrypted jobs (creator, ident, status, createdTimeStamp) are omitted from each result entry. On-premise only: requires a connected database.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="databaseInfoSearch"></param>
        /// <param name="xTenantId">Tenant identifier. When provided, results are scoped to this tenant. In on-premise single-tenant setups this header may be omitted. (optional)</param>
        /// <returns>ApiResponse of List&lt;DatabaseInfoSearchResult&gt;</returns>
        public Org.OpenAPITools.Client.ApiResponse<List<DatabaseInfoSearchResult>> ListJobsWithHttpInfo(DatabaseInfoSearch databaseInfoSearch, string? xTenantId = default)
        {
            // verify the required parameter 'databaseInfoSearch' is set
            if (databaseInfoSearch == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'databaseInfoSearch' when calling JobApi->ListJobs");

            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (xTenantId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xTenantId)); // header parameter
            }
            localVarRequestOptions.Data = databaseInfoSearch;


            // make the HTTP request
            var localVarResponse = this.Client.Post<List<DatabaseInfoSearchResult>>("/api/v1/jobs/search", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListJobs", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Search persisted optimization jobs and return metadata summaries. Accepts a DatabaseInfoSearch body and returns a stream of metadata summaries for all matching optimization jobs. All fields in the search body are optional and combinable. Results are sorted by upload date, newest first by default. Each entry contains a jobId that can be used directly with GET /api/v1/jobs/{jobId}/result to retrieve the full optimization result. Fields absent for encrypted jobs (creator, ident, status, createdTimeStamp) are omitted from each result entry. On-premise only: requires a connected database.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="databaseInfoSearch"></param>
        /// <param name="xTenantId">Tenant identifier. When provided, results are scoped to this tenant. In on-premise single-tenant setups this header may be omitted. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;DatabaseInfoSearchResult&gt;</returns>
        public async System.Threading.Tasks.Task<List<DatabaseInfoSearchResult>> ListJobsAsync(DatabaseInfoSearch databaseInfoSearch, string? xTenantId = default, System.Threading.CancellationToken cancellationToken = default)
        {
            Org.OpenAPITools.Client.ApiResponse<List<DatabaseInfoSearchResult>> localVarResponse = await ListJobsWithHttpInfoAsync(databaseInfoSearch, xTenantId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Search persisted optimization jobs and return metadata summaries. Accepts a DatabaseInfoSearch body and returns a stream of metadata summaries for all matching optimization jobs. All fields in the search body are optional and combinable. Results are sorted by upload date, newest first by default. Each entry contains a jobId that can be used directly with GET /api/v1/jobs/{jobId}/result to retrieve the full optimization result. Fields absent for encrypted jobs (creator, ident, status, createdTimeStamp) are omitted from each result entry. On-premise only: requires a connected database.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="databaseInfoSearch"></param>
        /// <param name="xTenantId">Tenant identifier. When provided, results are scoped to this tenant. In on-premise single-tenant setups this header may be omitted. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;DatabaseInfoSearchResult&gt;)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<List<DatabaseInfoSearchResult>>> ListJobsWithHttpInfoAsync(DatabaseInfoSearch databaseInfoSearch, string? xTenantId = default, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'databaseInfoSearch' is set
            if (databaseInfoSearch == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'databaseInfoSearch' when calling JobApi->ListJobs");


            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };


            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (xTenantId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xTenantId)); // header parameter
            }
            localVarRequestOptions.Data = databaseInfoSearch;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<List<DatabaseInfoSearchResult>>("/api/v1/jobs/search", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListJobs", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Stop a running job gracefully. Sends a graceful stop signal to the running optimization identified by jobId. The optimizer finishes its current iteration and persists the best result found so far. Returns immediately — the stop may take several seconds to complete. Poll GET /api/v1/jobs/{jobId}/status to confirm termination. Returns 200 if the job was found and the signal was sent. Returns 404 if the job is not running (already completed or never started).
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <returns>bool</returns>
        public bool StopJob(string jobId, string xTenantId)
        {
            Org.OpenAPITools.Client.ApiResponse<bool> localVarResponse = StopJobWithHttpInfo(jobId, xTenantId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Stop a running job gracefully. Sends a graceful stop signal to the running optimization identified by jobId. The optimizer finishes its current iteration and persists the best result found so far. Returns immediately — the stop may take several seconds to complete. Poll GET /api/v1/jobs/{jobId}/status to confirm termination. Returns 200 if the job was found and the signal was sent. Returns 404 if the job is not running (already completed or never started).
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <returns>ApiResponse of bool</returns>
        public Org.OpenAPITools.Client.ApiResponse<bool> StopJobWithHttpInfo(string jobId, string xTenantId)
        {
            // verify the required parameter 'jobId' is set
            if (jobId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'jobId' when calling JobApi->StopJob");

            // verify the required parameter 'xTenantId' is set
            if (xTenantId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'xTenantId' when calling JobApi->StopJob");

            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("jobId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(jobId)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xTenantId)); // header parameter

            // authentication (TenantId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id")))
            {
                localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<bool>("/api/v1/jobs/{jobId}/stop", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("StopJob", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Stop a running job gracefully. Sends a graceful stop signal to the running optimization identified by jobId. The optimizer finishes its current iteration and persists the best result found so far. Returns immediately — the stop may take several seconds to complete. Poll GET /api/v1/jobs/{jobId}/status to confirm termination. Returns 200 if the job was found and the signal was sent. Returns 404 if the job is not running (already completed or never started).
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of bool</returns>
        public async System.Threading.Tasks.Task<bool> StopJobAsync(string jobId, string xTenantId, System.Threading.CancellationToken cancellationToken = default)
        {
            Org.OpenAPITools.Client.ApiResponse<bool> localVarResponse = await StopJobWithHttpInfoAsync(jobId, xTenantId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Stop a running job gracefully. Sends a graceful stop signal to the running optimization identified by jobId. The optimizer finishes its current iteration and persists the best result found so far. Returns immediately — the stop may take several seconds to complete. Poll GET /api/v1/jobs/{jobId}/status to confirm termination. Returns 200 if the job was found and the signal was sent. Returns 404 if the job is not running (already completed or never started).
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobId">Unique job identifier from the JobAcceptedResponse.</param>
        /// <param name="xTenantId">Tenant identifier injected by the API gateway.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (bool)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<bool>> StopJobWithHttpInfoAsync(string jobId, string xTenantId, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'jobId' is set
            if (jobId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'jobId' when calling JobApi->StopJob");

            // verify the required parameter 'xTenantId' is set
            if (xTenantId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'xTenantId' when calling JobApi->StopJob");


            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };


            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("jobId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(jobId)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", Org.OpenAPITools.Client.ClientUtils.ParameterToString(xTenantId)); // header parameter

            // authentication (TenantId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id")))
            {
                localVarRequestOptions.HeaderParameters.Add("X-Tenant-Id", this.Configuration.GetApiKeyWithPrefix("X-Tenant-Id"));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<bool>("/api/v1/jobs/{jobId}/stop", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("StopJob", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
