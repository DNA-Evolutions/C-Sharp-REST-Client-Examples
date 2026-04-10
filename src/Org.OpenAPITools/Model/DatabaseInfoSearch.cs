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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using FileParameter = Org.OpenAPITools.Client.FileParameter;
using OpenAPIDateConverter = Org.OpenAPITools.Client.OpenAPIDateConverter;

namespace Org.OpenAPITools.Model
{
    /// <summary>
    /// DatabaseInfoSearch model for a databse search
    /// </summary>
    [DataContract(Name = "DatabaseInfoSearch")]
    public partial class DatabaseInfoSearch : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseInfoSearch" /> class.
        /// </summary>
        /// <param name="jobId">The unique id. Can not be empty..</param>
        /// <param name="creator">A related creator..</param>
        /// <param name="ident">The ident of the optimization to serach for. Leave blank if not required.</param>
        /// <param name="limit">The max number of results. Results are sorted by creation. Newest first by default.</param>
        /// <param name="sortDirection">The sort direction of the createdDate. By default descending (DESC) newest first. For oldest first, use ASC (ascending).</param>
        /// <param name="createdDateStart">The snapshot was created AFTER this time. Leave blank if not required..</param>
        /// <param name="createdDateEnd">The snapshot was created BEFORE this time. Leave blank if not required..</param>
        /// <param name="timeOut">The timeOut for the request. By default one minute.</param>
        public DatabaseInfoSearch(string jobId = default, string creator = default, string ident = default, int limit = default, string sortDirection = default, DateTime createdDateStart = default, DateTime createdDateEnd = default, string timeOut = default)
        {
            this.JobId = jobId;
            this.Creator = creator;
            this.Ident = ident;
            this.Limit = limit;
            this.SortDirection = sortDirection;
            this.CreatedDateStart = createdDateStart;
            this.CreatedDateEnd = createdDateEnd;
            this.TimeOut = timeOut;
        }

        /// <summary>
        /// The unique id. Can not be empty.
        /// </summary>
        /// <value>The unique id. Can not be empty.</value>
        /*
        <example>6274e36cc36712358912bf35</example>
        */
        [DataMember(Name = "jobId", EmitDefaultValue = false)]
        public string JobId { get; set; }

        /// <summary>
        /// A related creator.
        /// </summary>
        /// <value>A related creator.</value>
        /*
        <example>DEFAULT_DNA_CREATOR</example>
        */
        [DataMember(Name = "creator", EmitDefaultValue = false)]
        public string Creator { get; set; }

        /// <summary>
        /// The ident of the optimization to serach for. Leave blank if not required
        /// </summary>
        /// <value>The ident of the optimization to serach for. Leave blank if not required</value>
        /*
        <example>My-JOpt-Run</example>
        */
        [DataMember(Name = "ident", EmitDefaultValue = false)]
        public string Ident { get; set; }

        /// <summary>
        /// The max number of results. Results are sorted by creation. Newest first by default
        /// </summary>
        /// <value>The max number of results. Results are sorted by creation. Newest first by default</value>
        /*
        <example>10</example>
        */
        [DataMember(Name = "limit", EmitDefaultValue = false)]
        public int Limit { get; set; }

        /// <summary>
        /// The sort direction of the createdDate. By default descending (DESC) newest first. For oldest first, use ASC (ascending)
        /// </summary>
        /// <value>The sort direction of the createdDate. By default descending (DESC) newest first. For oldest first, use ASC (ascending)</value>
        /*
        <example>DESC</example>
        */
        [DataMember(Name = "sortDirection", EmitDefaultValue = false)]
        public string SortDirection { get; set; }

        /// <summary>
        /// The snapshot was created AFTER this time. Leave blank if not required.
        /// </summary>
        /// <value>The snapshot was created AFTER this time. Leave blank if not required.</value>
        [DataMember(Name = "createdDateStart", EmitDefaultValue = false)]
        public DateTime CreatedDateStart { get; set; }

        /// <summary>
        /// The snapshot was created BEFORE this time. Leave blank if not required.
        /// </summary>
        /// <value>The snapshot was created BEFORE this time. Leave blank if not required.</value>
        [DataMember(Name = "createdDateEnd", EmitDefaultValue = false)]
        public DateTime CreatedDateEnd { get; set; }

        /// <summary>
        /// The timeOut for the request. By default one minute
        /// </summary>
        /// <value>The timeOut for the request. By default one minute</value>
        /*
        <example>PT1M</example>
        */
        [DataMember(Name = "timeOut", EmitDefaultValue = false)]
        public string TimeOut { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class DatabaseInfoSearch {\n");
            sb.Append("  JobId: ").Append(JobId).Append("\n");
            sb.Append("  Creator: ").Append(Creator).Append("\n");
            sb.Append("  Ident: ").Append(Ident).Append("\n");
            sb.Append("  Limit: ").Append(Limit).Append("\n");
            sb.Append("  SortDirection: ").Append(SortDirection).Append("\n");
            sb.Append("  CreatedDateStart: ").Append(CreatedDateStart).Append("\n");
            sb.Append("  CreatedDateEnd: ").Append(CreatedDateEnd).Append("\n");
            sb.Append("  TimeOut: ").Append(TimeOut).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
