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
    public interface IOptimizationApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Retrieve the full result of a run (blocks until complete).
        /// </summary>
        /// <remarks>
        /// Blocks the connection until the optimization finishes or the timeout is reached. Returns 504 if the optimizer has not finished within the connection timeout. If you expect runs longer than a few minutes, use POST /api/v1/jobs instead.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>RestOptimization</returns>
        RestOptimization GetRunResult(string runId);

        /// <summary>
        /// Retrieve the full result of a run (blocks until complete).
        /// </summary>
        /// <remarks>
        /// Blocks the connection until the optimization finishes or the timeout is reached. Returns 504 if the optimizer has not finished within the connection timeout. If you expect runs longer than a few minutes, use POST /api/v1/jobs instead.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>ApiResponse of RestOptimization</returns>
        ApiResponse<RestOptimization> GetRunResultWithHttpInfo(string runId);
        /// <summary>
        /// Retrieve the solution of a run (blocks until complete).
        /// </summary>
        /// <remarks>
        /// Blocks the connection until the optimization identified by runId finishes, then returns the Solution payload only, omitting full optimization metadata. Returns 404 if the runId is unknown or the run has already completed.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>Solution</returns>
        Solution GetRunSolution(string runId);

        /// <summary>
        /// Retrieve the solution of a run (blocks until complete).
        /// </summary>
        /// <remarks>
        /// Blocks the connection until the optimization identified by runId finishes, then returns the Solution payload only, omitting full optimization metadata. Returns 404 if the runId is unknown or the run has already completed.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>ApiResponse of Solution</returns>
        ApiResponse<Solution> GetRunSolutionWithHttpInfo(string runId);
        /// <summary>
        /// Emits once the run has transitioned to the running state.
        /// </summary>
        /// <remarks>
        /// Returns a single boolean true when the optimizer for the given runId transitions to the running state. Useful for clients that want to begin subscribing to event streams only after the optimizer has actually started.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>bool</returns>
        bool GetStartedSignal(string runId);

        /// <summary>
        /// Emits once the run has transitioned to the running state.
        /// </summary>
        /// <remarks>
        /// Returns a single boolean true when the optimizer for the given runId transitions to the running state. Useful for clients that want to begin subscribing to event streams only after the optimizer has actually started.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>ApiResponse of bool</returns>
        ApiResponse<bool> GetStartedSignalWithHttpInfo(string runId);
        /// <summary>
        /// Start an optimization run and return a runId.
        /// </summary>
        /// <remarks>
        /// Starts a synchronous optimization and returns HTTP 202 with a runId. Intended for short optimizations that complete within a few minutes. The result connection will time out after 10 minutes. For long-running optimizations use POST /api/v1/jobs instead, which provides async job tracking without holding an HTTP connection open.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="restOptimization"></param>
        /// <returns>RunAcceptedResponse</returns>
        RunAcceptedResponse StartRun(RestOptimization restOptimization);

        /// <summary>
        /// Start an optimization run and return a runId.
        /// </summary>
        /// <remarks>
        /// Starts a synchronous optimization and returns HTTP 202 with a runId. Intended for short optimizations that complete within a few minutes. The result connection will time out after 10 minutes. For long-running optimizations use POST /api/v1/jobs instead, which provides async job tracking without holding an HTTP connection open.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="restOptimization"></param>
        /// <returns>ApiResponse of RunAcceptedResponse</returns>
        ApiResponse<RunAcceptedResponse> StartRunWithHttpInfo(RestOptimization restOptimization);
        /// <summary>
        /// Stop an active optimization run gracefully.
        /// </summary>
        /// <remarks>
        /// Requests a graceful stop of the run identified by runId. The optimizer finishes its current iteration and emits the best result found so far, which is then returned by the blocking GET result endpoint. Returns 404 if the runId is unknown or already completed.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>bool</returns>
        bool StopRun(string runId);

        /// <summary>
        /// Stop an active optimization run gracefully.
        /// </summary>
        /// <remarks>
        /// Requests a graceful stop of the run identified by runId. The optimizer finishes its current iteration and emits the best result found so far, which is then returned by the blocking GET result endpoint. Returns 404 if the runId is unknown or already completed.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>ApiResponse of bool</returns>
        ApiResponse<bool> StopRunWithHttpInfo(string runId);
        /// <summary>
        /// SSE stream of optimization errors for a run.
        /// </summary>
        /// <remarks>
        /// Subscribe to receive error events for the run identified by runId. Errors indicate serious problems that may affect result quality.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>List&lt;JOptOptimizationError&gt;</returns>
        List<JOptOptimizationError> StreamErrors(string runId);

        /// <summary>
        /// SSE stream of optimization errors for a run.
        /// </summary>
        /// <remarks>
        /// Subscribe to receive error events for the run identified by runId. Errors indicate serious problems that may affect result quality.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>ApiResponse of List&lt;JOptOptimizationError&gt;</returns>
        ApiResponse<List<JOptOptimizationError>> StreamErrorsWithHttpInfo(string runId);
        /// <summary>
        /// SSE stream of optimization progress for a run.
        /// </summary>
        /// <remarks>
        /// Subscribe to receive real-time progress updates for the run identified by runId. Each event contains the current progress percentage and timing information.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>List&lt;JOptOptimizationProgress&gt;</returns>
        List<JOptOptimizationProgress> StreamProgress(string runId);

        /// <summary>
        /// SSE stream of optimization progress for a run.
        /// </summary>
        /// <remarks>
        /// Subscribe to receive real-time progress updates for the run identified by runId. Each event contains the current progress percentage and timing information.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>ApiResponse of List&lt;JOptOptimizationProgress&gt;</returns>
        ApiResponse<List<JOptOptimizationProgress>> StreamProgressWithHttpInfo(string runId);
        /// <summary>
        /// SSE stream of optimization status messages for a run.
        /// </summary>
        /// <remarks>
        /// Subscribe to receive status lifecycle events for the run identified by runId (e.g. STARTED, RUNNING, FINISHED).
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>List&lt;JOptOptimizationStatus&gt;</returns>
        List<JOptOptimizationStatus> StreamStatus(string runId);

        /// <summary>
        /// SSE stream of optimization status messages for a run.
        /// </summary>
        /// <remarks>
        /// Subscribe to receive status lifecycle events for the run identified by runId (e.g. STARTED, RUNNING, FINISHED).
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>ApiResponse of List&lt;JOptOptimizationStatus&gt;</returns>
        ApiResponse<List<JOptOptimizationStatus>> StreamStatusWithHttpInfo(string runId);
        /// <summary>
        /// SSE stream of optimization warnings for a run.
        /// </summary>
        /// <remarks>
        /// Subscribe to receive warning events for the run identified by runId. Warnings indicate non-fatal issues such as unserviceable nodes or soft constraint violations.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>List&lt;JOptOptimizationWarning&gt;</returns>
        List<JOptOptimizationWarning> StreamWarnings(string runId);

        /// <summary>
        /// SSE stream of optimization warnings for a run.
        /// </summary>
        /// <remarks>
        /// Subscribe to receive warning events for the run identified by runId. Warnings indicate non-fatal issues such as unserviceable nodes or soft constraint violations.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>ApiResponse of List&lt;JOptOptimizationWarning&gt;</returns>
        ApiResponse<List<JOptOptimizationWarning>> StreamWarningsWithHttpInfo(string runId);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IOptimizationApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Retrieve the full result of a run (blocks until complete).
        /// </summary>
        /// <remarks>
        /// Blocks the connection until the optimization finishes or the timeout is reached. Returns 504 if the optimizer has not finished within the connection timeout. If you expect runs longer than a few minutes, use POST /api/v1/jobs instead.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of RestOptimization</returns>
        System.Threading.Tasks.Task<RestOptimization> GetRunResultAsync(string runId, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve the full result of a run (blocks until complete).
        /// </summary>
        /// <remarks>
        /// Blocks the connection until the optimization finishes or the timeout is reached. Returns 504 if the optimizer has not finished within the connection timeout. If you expect runs longer than a few minutes, use POST /api/v1/jobs instead.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (RestOptimization)</returns>
        System.Threading.Tasks.Task<ApiResponse<RestOptimization>> GetRunResultWithHttpInfoAsync(string runId, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Retrieve the solution of a run (blocks until complete).
        /// </summary>
        /// <remarks>
        /// Blocks the connection until the optimization identified by runId finishes, then returns the Solution payload only, omitting full optimization metadata. Returns 404 if the runId is unknown or the run has already completed.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Solution</returns>
        System.Threading.Tasks.Task<Solution> GetRunSolutionAsync(string runId, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve the solution of a run (blocks until complete).
        /// </summary>
        /// <remarks>
        /// Blocks the connection until the optimization identified by runId finishes, then returns the Solution payload only, omitting full optimization metadata. Returns 404 if the runId is unknown or the run has already completed.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Solution)</returns>
        System.Threading.Tasks.Task<ApiResponse<Solution>> GetRunSolutionWithHttpInfoAsync(string runId, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Emits once the run has transitioned to the running state.
        /// </summary>
        /// <remarks>
        /// Returns a single boolean true when the optimizer for the given runId transitions to the running state. Useful for clients that want to begin subscribing to event streams only after the optimizer has actually started.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of bool</returns>
        System.Threading.Tasks.Task<bool> GetStartedSignalAsync(string runId, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Emits once the run has transitioned to the running state.
        /// </summary>
        /// <remarks>
        /// Returns a single boolean true when the optimizer for the given runId transitions to the running state. Useful for clients that want to begin subscribing to event streams only after the optimizer has actually started.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (bool)</returns>
        System.Threading.Tasks.Task<ApiResponse<bool>> GetStartedSignalWithHttpInfoAsync(string runId, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Start an optimization run and return a runId.
        /// </summary>
        /// <remarks>
        /// Starts a synchronous optimization and returns HTTP 202 with a runId. Intended for short optimizations that complete within a few minutes. The result connection will time out after 10 minutes. For long-running optimizations use POST /api/v1/jobs instead, which provides async job tracking without holding an HTTP connection open.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="restOptimization"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of RunAcceptedResponse</returns>
        System.Threading.Tasks.Task<RunAcceptedResponse> StartRunAsync(RestOptimization restOptimization, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Start an optimization run and return a runId.
        /// </summary>
        /// <remarks>
        /// Starts a synchronous optimization and returns HTTP 202 with a runId. Intended for short optimizations that complete within a few minutes. The result connection will time out after 10 minutes. For long-running optimizations use POST /api/v1/jobs instead, which provides async job tracking without holding an HTTP connection open.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="restOptimization"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (RunAcceptedResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<RunAcceptedResponse>> StartRunWithHttpInfoAsync(RestOptimization restOptimization, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Stop an active optimization run gracefully.
        /// </summary>
        /// <remarks>
        /// Requests a graceful stop of the run identified by runId. The optimizer finishes its current iteration and emits the best result found so far, which is then returned by the blocking GET result endpoint. Returns 404 if the runId is unknown or already completed.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of bool</returns>
        System.Threading.Tasks.Task<bool> StopRunAsync(string runId, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Stop an active optimization run gracefully.
        /// </summary>
        /// <remarks>
        /// Requests a graceful stop of the run identified by runId. The optimizer finishes its current iteration and emits the best result found so far, which is then returned by the blocking GET result endpoint. Returns 404 if the runId is unknown or already completed.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (bool)</returns>
        System.Threading.Tasks.Task<ApiResponse<bool>> StopRunWithHttpInfoAsync(string runId, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// SSE stream of optimization errors for a run.
        /// </summary>
        /// <remarks>
        /// Subscribe to receive error events for the run identified by runId. Errors indicate serious problems that may affect result quality.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;JOptOptimizationError&gt;</returns>
        System.Threading.Tasks.Task<List<JOptOptimizationError>> StreamErrorsAsync(string runId, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// SSE stream of optimization errors for a run.
        /// </summary>
        /// <remarks>
        /// Subscribe to receive error events for the run identified by runId. Errors indicate serious problems that may affect result quality.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;JOptOptimizationError&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<JOptOptimizationError>>> StreamErrorsWithHttpInfoAsync(string runId, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// SSE stream of optimization progress for a run.
        /// </summary>
        /// <remarks>
        /// Subscribe to receive real-time progress updates for the run identified by runId. Each event contains the current progress percentage and timing information.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;JOptOptimizationProgress&gt;</returns>
        System.Threading.Tasks.Task<List<JOptOptimizationProgress>> StreamProgressAsync(string runId, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// SSE stream of optimization progress for a run.
        /// </summary>
        /// <remarks>
        /// Subscribe to receive real-time progress updates for the run identified by runId. Each event contains the current progress percentage and timing information.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;JOptOptimizationProgress&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<JOptOptimizationProgress>>> StreamProgressWithHttpInfoAsync(string runId, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// SSE stream of optimization status messages for a run.
        /// </summary>
        /// <remarks>
        /// Subscribe to receive status lifecycle events for the run identified by runId (e.g. STARTED, RUNNING, FINISHED).
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;JOptOptimizationStatus&gt;</returns>
        System.Threading.Tasks.Task<List<JOptOptimizationStatus>> StreamStatusAsync(string runId, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// SSE stream of optimization status messages for a run.
        /// </summary>
        /// <remarks>
        /// Subscribe to receive status lifecycle events for the run identified by runId (e.g. STARTED, RUNNING, FINISHED).
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;JOptOptimizationStatus&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<JOptOptimizationStatus>>> StreamStatusWithHttpInfoAsync(string runId, System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// SSE stream of optimization warnings for a run.
        /// </summary>
        /// <remarks>
        /// Subscribe to receive warning events for the run identified by runId. Warnings indicate non-fatal issues such as unserviceable nodes or soft constraint violations.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;JOptOptimizationWarning&gt;</returns>
        System.Threading.Tasks.Task<List<JOptOptimizationWarning>> StreamWarningsAsync(string runId, System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// SSE stream of optimization warnings for a run.
        /// </summary>
        /// <remarks>
        /// Subscribe to receive warning events for the run identified by runId. Warnings indicate non-fatal issues such as unserviceable nodes or soft constraint violations.
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;JOptOptimizationWarning&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<JOptOptimizationWarning>>> StreamWarningsWithHttpInfoAsync(string runId, System.Threading.CancellationToken cancellationToken = default);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IOptimizationApi : IOptimizationApiSync, IOptimizationApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class OptimizationApi : IDisposable, IOptimizationApi
    {
        private Org.OpenAPITools.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="OptimizationApi"/> class.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <returns></returns>
        public OptimizationApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OptimizationApi"/> class.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        public OptimizationApi(string basePath)
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
        /// Initializes a new instance of the <see cref="OptimizationApi"/> class using Configuration object.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="configuration">An instance of Configuration.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public OptimizationApi(Org.OpenAPITools.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="OptimizationApi"/> class.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public OptimizationApi(HttpClient client, HttpClientHandler handler = null) : this(client, (string)null, handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OptimizationApi"/> class.
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
        public OptimizationApi(HttpClient client, string basePath, HttpClientHandler handler = null)
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
        /// Initializes a new instance of the <see cref="OptimizationApi"/> class using Configuration object.
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
        public OptimizationApi(HttpClient client, Org.OpenAPITools.Client.Configuration configuration, HttpClientHandler handler = null)
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
        /// Initializes a new instance of the <see cref="OptimizationApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public OptimizationApi(Org.OpenAPITools.Client.ISynchronousClient client, Org.OpenAPITools.Client.IAsynchronousClient asyncClient, Org.OpenAPITools.Client.IReadableConfiguration configuration)
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
        /// Retrieve the full result of a run (blocks until complete). Blocks the connection until the optimization finishes or the timeout is reached. Returns 504 if the optimizer has not finished within the connection timeout. If you expect runs longer than a few minutes, use POST /api/v1/jobs instead.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>RestOptimization</returns>
        public RestOptimization GetRunResult(string runId)
        {
            Org.OpenAPITools.Client.ApiResponse<RestOptimization> localVarResponse = GetRunResultWithHttpInfo(runId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve the full result of a run (blocks until complete). Blocks the connection until the optimization finishes or the timeout is reached. Returns 504 if the optimizer has not finished within the connection timeout. If you expect runs longer than a few minutes, use POST /api/v1/jobs instead.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>ApiResponse of RestOptimization</returns>
        public Org.OpenAPITools.Client.ApiResponse<RestOptimization> GetRunResultWithHttpInfo(string runId)
        {
            // verify the required parameter 'runId' is set
            if (runId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'runId' when calling OptimizationApi->GetRunResult");

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

            localVarRequestOptions.PathParameters.Add("runId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(runId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<RestOptimization>("/api/v1/runs/{runId}/result", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetRunResult", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve the full result of a run (blocks until complete). Blocks the connection until the optimization finishes or the timeout is reached. Returns 504 if the optimizer has not finished within the connection timeout. If you expect runs longer than a few minutes, use POST /api/v1/jobs instead.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of RestOptimization</returns>
        public async System.Threading.Tasks.Task<RestOptimization> GetRunResultAsync(string runId, System.Threading.CancellationToken cancellationToken = default)
        {
            Org.OpenAPITools.Client.ApiResponse<RestOptimization> localVarResponse = await GetRunResultWithHttpInfoAsync(runId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve the full result of a run (blocks until complete). Blocks the connection until the optimization finishes or the timeout is reached. Returns 504 if the optimizer has not finished within the connection timeout. If you expect runs longer than a few minutes, use POST /api/v1/jobs instead.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (RestOptimization)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<RestOptimization>> GetRunResultWithHttpInfoAsync(string runId, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'runId' is set
            if (runId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'runId' when calling OptimizationApi->GetRunResult");


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

            localVarRequestOptions.PathParameters.Add("runId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(runId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<RestOptimization>("/api/v1/runs/{runId}/result", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetRunResult", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve the solution of a run (blocks until complete). Blocks the connection until the optimization identified by runId finishes, then returns the Solution payload only, omitting full optimization metadata. Returns 404 if the runId is unknown or the run has already completed.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>Solution</returns>
        public Solution GetRunSolution(string runId)
        {
            Org.OpenAPITools.Client.ApiResponse<Solution> localVarResponse = GetRunSolutionWithHttpInfo(runId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve the solution of a run (blocks until complete). Blocks the connection until the optimization identified by runId finishes, then returns the Solution payload only, omitting full optimization metadata. Returns 404 if the runId is unknown or the run has already completed.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>ApiResponse of Solution</returns>
        public Org.OpenAPITools.Client.ApiResponse<Solution> GetRunSolutionWithHttpInfo(string runId)
        {
            // verify the required parameter 'runId' is set
            if (runId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'runId' when calling OptimizationApi->GetRunSolution");

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

            localVarRequestOptions.PathParameters.Add("runId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(runId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<Solution>("/api/v1/runs/{runId}/solution", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetRunSolution", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve the solution of a run (blocks until complete). Blocks the connection until the optimization identified by runId finishes, then returns the Solution payload only, omitting full optimization metadata. Returns 404 if the runId is unknown or the run has already completed.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Solution</returns>
        public async System.Threading.Tasks.Task<Solution> GetRunSolutionAsync(string runId, System.Threading.CancellationToken cancellationToken = default)
        {
            Org.OpenAPITools.Client.ApiResponse<Solution> localVarResponse = await GetRunSolutionWithHttpInfoAsync(runId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve the solution of a run (blocks until complete). Blocks the connection until the optimization identified by runId finishes, then returns the Solution payload only, omitting full optimization metadata. Returns 404 if the runId is unknown or the run has already completed.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Solution)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<Solution>> GetRunSolutionWithHttpInfoAsync(string runId, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'runId' is set
            if (runId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'runId' when calling OptimizationApi->GetRunSolution");


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

            localVarRequestOptions.PathParameters.Add("runId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(runId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<Solution>("/api/v1/runs/{runId}/solution", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetRunSolution", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Emits once the run has transitioned to the running state. Returns a single boolean true when the optimizer for the given runId transitions to the running state. Useful for clients that want to begin subscribing to event streams only after the optimizer has actually started.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>bool</returns>
        public bool GetStartedSignal(string runId)
        {
            Org.OpenAPITools.Client.ApiResponse<bool> localVarResponse = GetStartedSignalWithHttpInfo(runId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Emits once the run has transitioned to the running state. Returns a single boolean true when the optimizer for the given runId transitions to the running state. Useful for clients that want to begin subscribing to event streams only after the optimizer has actually started.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>ApiResponse of bool</returns>
        public Org.OpenAPITools.Client.ApiResponse<bool> GetStartedSignalWithHttpInfo(string runId)
        {
            // verify the required parameter 'runId' is set
            if (runId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'runId' when calling OptimizationApi->GetStartedSignal");

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

            localVarRequestOptions.PathParameters.Add("runId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(runId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<bool>("/api/v1/runs/{runId}/started", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetStartedSignal", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Emits once the run has transitioned to the running state. Returns a single boolean true when the optimizer for the given runId transitions to the running state. Useful for clients that want to begin subscribing to event streams only after the optimizer has actually started.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of bool</returns>
        public async System.Threading.Tasks.Task<bool> GetStartedSignalAsync(string runId, System.Threading.CancellationToken cancellationToken = default)
        {
            Org.OpenAPITools.Client.ApiResponse<bool> localVarResponse = await GetStartedSignalWithHttpInfoAsync(runId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Emits once the run has transitioned to the running state. Returns a single boolean true when the optimizer for the given runId transitions to the running state. Useful for clients that want to begin subscribing to event streams only after the optimizer has actually started.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (bool)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<bool>> GetStartedSignalWithHttpInfoAsync(string runId, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'runId' is set
            if (runId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'runId' when calling OptimizationApi->GetStartedSignal");


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

            localVarRequestOptions.PathParameters.Add("runId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(runId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<bool>("/api/v1/runs/{runId}/started", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetStartedSignal", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Start an optimization run and return a runId. Starts a synchronous optimization and returns HTTP 202 with a runId. Intended for short optimizations that complete within a few minutes. The result connection will time out after 10 minutes. For long-running optimizations use POST /api/v1/jobs instead, which provides async job tracking without holding an HTTP connection open.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="restOptimization"></param>
        /// <returns>RunAcceptedResponse</returns>
        public RunAcceptedResponse StartRun(RestOptimization restOptimization)
        {
            Org.OpenAPITools.Client.ApiResponse<RunAcceptedResponse> localVarResponse = StartRunWithHttpInfo(restOptimization);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Start an optimization run and return a runId. Starts a synchronous optimization and returns HTTP 202 with a runId. Intended for short optimizations that complete within a few minutes. The result connection will time out after 10 minutes. For long-running optimizations use POST /api/v1/jobs instead, which provides async job tracking without holding an HTTP connection open.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="restOptimization"></param>
        /// <returns>ApiResponse of RunAcceptedResponse</returns>
        public Org.OpenAPITools.Client.ApiResponse<RunAcceptedResponse> StartRunWithHttpInfo(RestOptimization restOptimization)
        {
            // verify the required parameter 'restOptimization' is set
            if (restOptimization == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'restOptimization' when calling OptimizationApi->StartRun");

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

            localVarRequestOptions.Data = restOptimization;


            // make the HTTP request
            var localVarResponse = this.Client.Post<RunAcceptedResponse>("/api/v1/runs", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("StartRun", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Start an optimization run and return a runId. Starts a synchronous optimization and returns HTTP 202 with a runId. Intended for short optimizations that complete within a few minutes. The result connection will time out after 10 minutes. For long-running optimizations use POST /api/v1/jobs instead, which provides async job tracking without holding an HTTP connection open.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="restOptimization"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of RunAcceptedResponse</returns>
        public async System.Threading.Tasks.Task<RunAcceptedResponse> StartRunAsync(RestOptimization restOptimization, System.Threading.CancellationToken cancellationToken = default)
        {
            Org.OpenAPITools.Client.ApiResponse<RunAcceptedResponse> localVarResponse = await StartRunWithHttpInfoAsync(restOptimization, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Start an optimization run and return a runId. Starts a synchronous optimization and returns HTTP 202 with a runId. Intended for short optimizations that complete within a few minutes. The result connection will time out after 10 minutes. For long-running optimizations use POST /api/v1/jobs instead, which provides async job tracking without holding an HTTP connection open.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="restOptimization"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (RunAcceptedResponse)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<RunAcceptedResponse>> StartRunWithHttpInfoAsync(RestOptimization restOptimization, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'restOptimization' is set
            if (restOptimization == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'restOptimization' when calling OptimizationApi->StartRun");


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

            localVarRequestOptions.Data = restOptimization;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<RunAcceptedResponse>("/api/v1/runs", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("StartRun", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Stop an active optimization run gracefully. Requests a graceful stop of the run identified by runId. The optimizer finishes its current iteration and emits the best result found so far, which is then returned by the blocking GET result endpoint. Returns 404 if the runId is unknown or already completed.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>bool</returns>
        public bool StopRun(string runId)
        {
            Org.OpenAPITools.Client.ApiResponse<bool> localVarResponse = StopRunWithHttpInfo(runId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Stop an active optimization run gracefully. Requests a graceful stop of the run identified by runId. The optimizer finishes its current iteration and emits the best result found so far, which is then returned by the blocking GET result endpoint. Returns 404 if the runId is unknown or already completed.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>ApiResponse of bool</returns>
        public Org.OpenAPITools.Client.ApiResponse<bool> StopRunWithHttpInfo(string runId)
        {
            // verify the required parameter 'runId' is set
            if (runId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'runId' when calling OptimizationApi->StopRun");

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

            localVarRequestOptions.PathParameters.Add("runId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(runId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Delete<bool>("/api/v1/runs/{runId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("StopRun", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Stop an active optimization run gracefully. Requests a graceful stop of the run identified by runId. The optimizer finishes its current iteration and emits the best result found so far, which is then returned by the blocking GET result endpoint. Returns 404 if the runId is unknown or already completed.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of bool</returns>
        public async System.Threading.Tasks.Task<bool> StopRunAsync(string runId, System.Threading.CancellationToken cancellationToken = default)
        {
            Org.OpenAPITools.Client.ApiResponse<bool> localVarResponse = await StopRunWithHttpInfoAsync(runId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Stop an active optimization run gracefully. Requests a graceful stop of the run identified by runId. The optimizer finishes its current iteration and emits the best result found so far, which is then returned by the blocking GET result endpoint. Returns 404 if the runId is unknown or already completed.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (bool)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<bool>> StopRunWithHttpInfoAsync(string runId, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'runId' is set
            if (runId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'runId' when calling OptimizationApi->StopRun");


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

            localVarRequestOptions.PathParameters.Add("runId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(runId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<bool>("/api/v1/runs/{runId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("StopRun", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// SSE stream of optimization errors for a run. Subscribe to receive error events for the run identified by runId. Errors indicate serious problems that may affect result quality.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>List&lt;JOptOptimizationError&gt;</returns>
        public List<JOptOptimizationError> StreamErrors(string runId)
        {
            Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationError>> localVarResponse = StreamErrorsWithHttpInfo(runId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// SSE stream of optimization errors for a run. Subscribe to receive error events for the run identified by runId. Errors indicate serious problems that may affect result quality.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>ApiResponse of List&lt;JOptOptimizationError&gt;</returns>
        public Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationError>> StreamErrorsWithHttpInfo(string runId)
        {
            // verify the required parameter 'runId' is set
            if (runId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'runId' when calling OptimizationApi->StreamErrors");

            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "text/event-stream",
                "application/json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("runId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(runId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<JOptOptimizationError>>("/api/v1/runs/{runId}/stream/errors", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("StreamErrors", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// SSE stream of optimization errors for a run. Subscribe to receive error events for the run identified by runId. Errors indicate serious problems that may affect result quality.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;JOptOptimizationError&gt;</returns>
        public async System.Threading.Tasks.Task<List<JOptOptimizationError>> StreamErrorsAsync(string runId, System.Threading.CancellationToken cancellationToken = default)
        {
            Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationError>> localVarResponse = await StreamErrorsWithHttpInfoAsync(runId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// SSE stream of optimization errors for a run. Subscribe to receive error events for the run identified by runId. Errors indicate serious problems that may affect result quality.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;JOptOptimizationError&gt;)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationError>>> StreamErrorsWithHttpInfoAsync(string runId, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'runId' is set
            if (runId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'runId' when calling OptimizationApi->StreamErrors");


            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "text/event-stream",
                "application/json"
            };


            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("runId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(runId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<JOptOptimizationError>>("/api/v1/runs/{runId}/stream/errors", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("StreamErrors", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// SSE stream of optimization progress for a run. Subscribe to receive real-time progress updates for the run identified by runId. Each event contains the current progress percentage and timing information.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>List&lt;JOptOptimizationProgress&gt;</returns>
        public List<JOptOptimizationProgress> StreamProgress(string runId)
        {
            Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationProgress>> localVarResponse = StreamProgressWithHttpInfo(runId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// SSE stream of optimization progress for a run. Subscribe to receive real-time progress updates for the run identified by runId. Each event contains the current progress percentage and timing information.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>ApiResponse of List&lt;JOptOptimizationProgress&gt;</returns>
        public Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationProgress>> StreamProgressWithHttpInfo(string runId)
        {
            // verify the required parameter 'runId' is set
            if (runId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'runId' when calling OptimizationApi->StreamProgress");

            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "text/event-stream",
                "application/json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("runId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(runId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<JOptOptimizationProgress>>("/api/v1/runs/{runId}/stream/progress", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("StreamProgress", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// SSE stream of optimization progress for a run. Subscribe to receive real-time progress updates for the run identified by runId. Each event contains the current progress percentage and timing information.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;JOptOptimizationProgress&gt;</returns>
        public async System.Threading.Tasks.Task<List<JOptOptimizationProgress>> StreamProgressAsync(string runId, System.Threading.CancellationToken cancellationToken = default)
        {
            Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationProgress>> localVarResponse = await StreamProgressWithHttpInfoAsync(runId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// SSE stream of optimization progress for a run. Subscribe to receive real-time progress updates for the run identified by runId. Each event contains the current progress percentage and timing information.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;JOptOptimizationProgress&gt;)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationProgress>>> StreamProgressWithHttpInfoAsync(string runId, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'runId' is set
            if (runId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'runId' when calling OptimizationApi->StreamProgress");


            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "text/event-stream",
                "application/json"
            };


            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("runId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(runId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<JOptOptimizationProgress>>("/api/v1/runs/{runId}/stream/progress", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("StreamProgress", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// SSE stream of optimization status messages for a run. Subscribe to receive status lifecycle events for the run identified by runId (e.g. STARTED, RUNNING, FINISHED).
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>List&lt;JOptOptimizationStatus&gt;</returns>
        public List<JOptOptimizationStatus> StreamStatus(string runId)
        {
            Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationStatus>> localVarResponse = StreamStatusWithHttpInfo(runId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// SSE stream of optimization status messages for a run. Subscribe to receive status lifecycle events for the run identified by runId (e.g. STARTED, RUNNING, FINISHED).
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>ApiResponse of List&lt;JOptOptimizationStatus&gt;</returns>
        public Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationStatus>> StreamStatusWithHttpInfo(string runId)
        {
            // verify the required parameter 'runId' is set
            if (runId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'runId' when calling OptimizationApi->StreamStatus");

            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "text/event-stream",
                "application/json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("runId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(runId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<JOptOptimizationStatus>>("/api/v1/runs/{runId}/stream/status", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("StreamStatus", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// SSE stream of optimization status messages for a run. Subscribe to receive status lifecycle events for the run identified by runId (e.g. STARTED, RUNNING, FINISHED).
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;JOptOptimizationStatus&gt;</returns>
        public async System.Threading.Tasks.Task<List<JOptOptimizationStatus>> StreamStatusAsync(string runId, System.Threading.CancellationToken cancellationToken = default)
        {
            Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationStatus>> localVarResponse = await StreamStatusWithHttpInfoAsync(runId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// SSE stream of optimization status messages for a run. Subscribe to receive status lifecycle events for the run identified by runId (e.g. STARTED, RUNNING, FINISHED).
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;JOptOptimizationStatus&gt;)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationStatus>>> StreamStatusWithHttpInfoAsync(string runId, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'runId' is set
            if (runId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'runId' when calling OptimizationApi->StreamStatus");


            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "text/event-stream",
                "application/json"
            };


            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("runId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(runId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<JOptOptimizationStatus>>("/api/v1/runs/{runId}/stream/status", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("StreamStatus", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// SSE stream of optimization warnings for a run. Subscribe to receive warning events for the run identified by runId. Warnings indicate non-fatal issues such as unserviceable nodes or soft constraint violations.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>List&lt;JOptOptimizationWarning&gt;</returns>
        public List<JOptOptimizationWarning> StreamWarnings(string runId)
        {
            Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationWarning>> localVarResponse = StreamWarningsWithHttpInfo(runId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// SSE stream of optimization warnings for a run. Subscribe to receive warning events for the run identified by runId. Warnings indicate non-fatal issues such as unserviceable nodes or soft constraint violations.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <returns>ApiResponse of List&lt;JOptOptimizationWarning&gt;</returns>
        public Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationWarning>> StreamWarningsWithHttpInfo(string runId)
        {
            // verify the required parameter 'runId' is set
            if (runId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'runId' when calling OptimizationApi->StreamWarnings");

            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "text/event-stream",
                "application/json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("runId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(runId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<JOptOptimizationWarning>>("/api/v1/runs/{runId}/stream/warnings", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("StreamWarnings", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// SSE stream of optimization warnings for a run. Subscribe to receive warning events for the run identified by runId. Warnings indicate non-fatal issues such as unserviceable nodes or soft constraint violations.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;JOptOptimizationWarning&gt;</returns>
        public async System.Threading.Tasks.Task<List<JOptOptimizationWarning>> StreamWarningsAsync(string runId, System.Threading.CancellationToken cancellationToken = default)
        {
            Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationWarning>> localVarResponse = await StreamWarningsWithHttpInfoAsync(runId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// SSE stream of optimization warnings for a run. Subscribe to receive warning events for the run identified by runId. Warnings indicate non-fatal issues such as unserviceable nodes or soft constraint violations.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runId">Run identifier returned by POST /api/v1/runs.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;JOptOptimizationWarning&gt;)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<List<JOptOptimizationWarning>>> StreamWarningsWithHttpInfoAsync(string runId, System.Threading.CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'runId' is set
            if (runId == null)
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'runId' when calling OptimizationApi->StreamWarnings");


            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "text/event-stream",
                "application/json"
            };


            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("runId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(runId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<JOptOptimizationWarning>>("/api/v1/runs/{runId}/stream/warnings", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("StreamWarnings", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
