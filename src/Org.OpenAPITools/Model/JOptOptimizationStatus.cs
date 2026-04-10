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
    /// JOptOptimizationStatus model for the documentation
    /// </summary>
    [DataContract(Name = "JOptOptimizationStatus")]
    public partial class JOptOptimizationStatus : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JOptOptimizationStatus" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected JOptOptimizationStatus() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="JOptOptimizationStatus" /> class.
        /// </summary>
        /// <param name="creator">An id related to the creator that is filled out autmatically.</param>
        /// <param name="jobId">The jobId id. Will be filled out by the optimizer, if necessary (required).</param>
        /// <param name="tenantId">The tenant id of the creator started this job. (required).</param>
        /// <param name="ident">The ident of the currently running optimization (required).</param>
        /// <param name="message">The info message (required).</param>
        /// <param name="code">The info message code (required).</param>
        /// <param name="desc">The description of the info (required).</param>
        /// <param name="expireAt">Optional value that will be used for database cleanup purposes..</param>
        /// <param name="id">The obejct id. Will be filled out by the optimizer, if necessary.</param>
        public JOptOptimizationStatus(string creator = default, string jobId = default, string tenantId = default, string ident = default, string message = default, int code = default, string desc = default, DateTime expireAt = default, string id = default)
        {
            // to ensure "jobId" is required (not null)
            if (jobId == null)
            {
                throw new ArgumentNullException("jobId is a required property for JOptOptimizationStatus and cannot be null");
            }
            this.JobId = jobId;
            // to ensure "tenantId" is required (not null)
            if (tenantId == null)
            {
                throw new ArgumentNullException("tenantId is a required property for JOptOptimizationStatus and cannot be null");
            }
            this.TenantId = tenantId;
            // to ensure "ident" is required (not null)
            if (ident == null)
            {
                throw new ArgumentNullException("ident is a required property for JOptOptimizationStatus and cannot be null");
            }
            this.Ident = ident;
            // to ensure "message" is required (not null)
            if (message == null)
            {
                throw new ArgumentNullException("message is a required property for JOptOptimizationStatus and cannot be null");
            }
            this.Message = message;
            this.Code = code;
            // to ensure "desc" is required (not null)
            if (desc == null)
            {
                throw new ArgumentNullException("desc is a required property for JOptOptimizationStatus and cannot be null");
            }
            this.Desc = desc;
            this.Creator = creator;
            this.ExpireAt = expireAt;
            this.Id = id;
        }

        /// <summary>
        /// An id related to the creator that is filled out autmatically
        /// </summary>
        /// <value>An id related to the creator that is filled out autmatically</value>
        /*
        <example>11aa65b13c2a6d34f8727e82e403ce869e3bba1d35c45c595e8cc5ce5e74e57a</example>
        */
        [DataMember(Name = "creator", EmitDefaultValue = false)]
        public string Creator { get; set; }

        /// <summary>
        /// The jobId id. Will be filled out by the optimizer, if necessary
        /// </summary>
        /// <value>The jobId id. Will be filled out by the optimizer, if necessary</value>
        /*
        <example>UNIQUE_JOB_ID</example>
        */
        [DataMember(Name = "jobId", IsRequired = true, EmitDefaultValue = true)]
        public string JobId { get; set; }

        /// <summary>
        /// The tenant id of the creator started this job.
        /// </summary>
        /// <value>The tenant id of the creator started this job.</value>
        /*
        <example>UNIQUE_TENANT_ID</example>
        */
        [DataMember(Name = "tenantId", IsRequired = true, EmitDefaultValue = true)]
        public string TenantId { get; set; }

        /// <summary>
        /// The ident of the currently running optimization
        /// </summary>
        /// <value>The ident of the currently running optimization</value>
        /*
        <example>My-JOpt-Run</example>
        */
        [DataMember(Name = "ident", IsRequired = true, EmitDefaultValue = true)]
        public string Ident { get; set; }

        /// <summary>
        /// The info message
        /// </summary>
        /// <value>The info message</value>
        /*
        <example>Info about something</example>
        */
        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = true)]
        public string Message { get; set; }

        /// <summary>
        /// The info message code
        /// </summary>
        /// <value>The info message code</value>
        /*
        <example>555</example>
        */
        [DataMember(Name = "code", IsRequired = true, EmitDefaultValue = true)]
        public int Code { get; set; }

        /// <summary>
        /// The description of the info
        /// </summary>
        /// <value>The description of the info</value>
        /*
        <example>Info desc</example>
        */
        [DataMember(Name = "desc", IsRequired = true, EmitDefaultValue = true)]
        public string Desc { get; set; }

        /// <summary>
        /// Optional value that will be used for database cleanup purposes.
        /// </summary>
        /// <value>Optional value that will be used for database cleanup purposes.</value>
        [DataMember(Name = "expireAt", EmitDefaultValue = false)]
        public DateTime ExpireAt { get; set; }

        /// <summary>
        /// The obejct id. Will be filled out by the optimizer, if necessary
        /// </summary>
        /// <value>The obejct id. Will be filled out by the optimizer, if necessary</value>
        /*
        <example>626d49ae5cf422297561c458</example>
        */
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class JOptOptimizationStatus {\n");
            sb.Append("  Creator: ").Append(Creator).Append("\n");
            sb.Append("  JobId: ").Append(JobId).Append("\n");
            sb.Append("  TenantId: ").Append(TenantId).Append("\n");
            sb.Append("  Ident: ").Append(Ident).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  Desc: ").Append(Desc).Append("\n");
            sb.Append("  ExpireAt: ").Append(ExpireAt).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
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
