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
    /// Metadata summary for a persisted optimization job. Fields absent in encrypted results (creator, ident, createdTimeStamp, status) are omitted from the response. The sec field is present only for encrypted results.
    /// </summary>
    [DataContract(Name = "DatabaseInfoSearchResult")]
    public partial class DatabaseInfoSearchResult : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseInfoSearchResult" /> class.
        /// </summary>
        /// <param name="id">MongoDB document identifier..</param>
        /// <param name="length">Size of the stored document in bytes..</param>
        /// <param name="uploadDate">Timestamp when the result document was written to GridFS..</param>
        /// <param name="contentType">MIME type of the stored content..</param>
        /// <param name="jobId">Unique job identifier. Matches the jobId from the JobAcceptedResponse and can be used directly with the job read endpoints..</param>
        /// <param name="tenantId">Tenant identifier under which this job was persisted..</param>
        /// <param name="type">Internal type label of the persisted document..</param>
        /// <param name="compression">Compression algorithm applied before storage..</param>
        /// <param name="encrypted">Whether this result is encrypted at rest..</param>
        /// <param name="expireAt">Scheduled expiry time. The database will automatically remove this document after this timestamp..</param>
        /// <param name="creator">Creator identifier associated with this job. Absent for client-encrypted results where cleartext metadata is not stored..</param>
        /// <param name="ident">User-defined label assigned to the optimization run. Absent for client-encrypted results..</param>
        /// <param name="createdTimeStamp">Epoch-millisecond timestamp when the optimization was created internally. Absent for client-encrypted results..</param>
        /// <param name="status">status.</param>
        /// <param name="sec">sec.</param>
        public DatabaseInfoSearchResult(string id = default, long length = default, DateTime uploadDate = default, string contentType = default, string jobId = default, string tenantId = default, string type = default, string compression = default, bool encrypted = default, DateTime expireAt = default, string creator = default, string ident = default, long createdTimeStamp = default, OptimizationStatus status = default, SecurityHelperItemMetadata sec = default)
        {
            this.Id = id;
            this.Length = length;
            this.UploadDate = uploadDate;
            this.ContentType = contentType;
            this.JobId = jobId;
            this.TenantId = tenantId;
            this.Type = type;
            this.Compression = compression;
            this.Encrypted = encrypted;
            this.ExpireAt = expireAt;
            this.Creator = creator;
            this.Ident = ident;
            this.CreatedTimeStamp = createdTimeStamp;
            this.Status = status;
            this.Sec = sec;
        }

        /// <summary>
        /// MongoDB document identifier.
        /// </summary>
        /// <value>MongoDB document identifier.</value>
        /*
        <example>69ce5624d720723260b6aca2</example>
        */
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Size of the stored document in bytes.
        /// </summary>
        /// <value>Size of the stored document in bytes.</value>
        /*
        <example>5285</example>
        */
        [DataMember(Name = "length", EmitDefaultValue = false)]
        public long Length { get; set; }

        /// <summary>
        /// Timestamp when the result document was written to GridFS.
        /// </summary>
        /// <value>Timestamp when the result document was written to GridFS.</value>
        [DataMember(Name = "uploadDate", EmitDefaultValue = false)]
        public DateTime UploadDate { get; set; }

        /// <summary>
        /// MIME type of the stored content.
        /// </summary>
        /// <value>MIME type of the stored content.</value>
        /*
        <example>application/x-bzip2</example>
        */
        [DataMember(Name = "contentType", EmitDefaultValue = false)]
        public string ContentType { get; set; }

        /// <summary>
        /// Unique job identifier. Matches the jobId from the JobAcceptedResponse and can be used directly with the job read endpoints.
        /// </summary>
        /// <value>Unique job identifier. Matches the jobId from the JobAcceptedResponse and can be used directly with the job read endpoints.</value>
        /*
        <example>2a3d6d1e-64af-4861-9613-de66675fdc3a</example>
        */
        [DataMember(Name = "jobId", EmitDefaultValue = false)]
        public string JobId { get; set; }

        /// <summary>
        /// Tenant identifier under which this job was persisted.
        /// </summary>
        /// <value>Tenant identifier under which this job was persisted.</value>
        /*
        <example>tenant-abc-123</example>
        */
        [DataMember(Name = "tenantId", EmitDefaultValue = false)]
        public string TenantId { get; set; }

        /// <summary>
        /// Internal type label of the persisted document.
        /// </summary>
        /// <value>Internal type label of the persisted document.</value>
        /*
        <example>OptimizationConfig&lt;JSONConfig&gt;</example>
        */
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// Compression algorithm applied before storage.
        /// </summary>
        /// <value>Compression algorithm applied before storage.</value>
        /*
        <example>bzip2</example>
        */
        [DataMember(Name = "compression", EmitDefaultValue = false)]
        public string Compression { get; set; }

        /// <summary>
        /// Whether this result is encrypted at rest.
        /// </summary>
        /// <value>Whether this result is encrypted at rest.</value>
        /*
        <example>false</example>
        */
        [DataMember(Name = "encrypted", EmitDefaultValue = true)]
        public bool Encrypted { get; set; }

        /// <summary>
        /// Scheduled expiry time. The database will automatically remove this document after this timestamp.
        /// </summary>
        /// <value>Scheduled expiry time. The database will automatically remove this document after this timestamp.</value>
        [DataMember(Name = "expireAt", EmitDefaultValue = false)]
        public DateTime ExpireAt { get; set; }

        /// <summary>
        /// Creator identifier associated with this job. Absent for client-encrypted results where cleartext metadata is not stored.
        /// </summary>
        /// <value>Creator identifier associated with this job. Absent for client-encrypted results where cleartext metadata is not stored.</value>
        /*
        <example>PUBLIC_CREATOR</example>
        */
        [DataMember(Name = "creator", EmitDefaultValue = false)]
        public string Creator { get; set; }

        /// <summary>
        /// User-defined label assigned to the optimization run. Absent for client-encrypted results.
        /// </summary>
        /// <value>User-defined label assigned to the optimization run. Absent for client-encrypted results.</value>
        /*
        <example>JOpt-Run-1775130113116</example>
        */
        [DataMember(Name = "ident", EmitDefaultValue = false)]
        public string Ident { get; set; }

        /// <summary>
        /// Epoch-millisecond timestamp when the optimization was created internally. Absent for client-encrypted results.
        /// </summary>
        /// <value>Epoch-millisecond timestamp when the optimization was created internally. Absent for client-encrypted results.</value>
        /*
        <example>1775130148792</example>
        */
        [DataMember(Name = "createdTimeStamp", EmitDefaultValue = false)]
        public long CreatedTimeStamp { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public OptimizationStatus Status { get; set; }

        /// <summary>
        /// Gets or Sets Sec
        /// </summary>
        [DataMember(Name = "sec", EmitDefaultValue = false)]
        public SecurityHelperItemMetadata Sec { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class DatabaseInfoSearchResult {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Length: ").Append(Length).Append("\n");
            sb.Append("  UploadDate: ").Append(UploadDate).Append("\n");
            sb.Append("  ContentType: ").Append(ContentType).Append("\n");
            sb.Append("  JobId: ").Append(JobId).Append("\n");
            sb.Append("  TenantId: ").Append(TenantId).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Compression: ").Append(Compression).Append("\n");
            sb.Append("  Encrypted: ").Append(Encrypted).Append("\n");
            sb.Append("  ExpireAt: ").Append(ExpireAt).Append("\n");
            sb.Append("  Creator: ").Append(Creator).Append("\n");
            sb.Append("  Ident: ").Append(Ident).Append("\n");
            sb.Append("  CreatedTimeStamp: ").Append(CreatedTimeStamp).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Sec: ").Append(Sec).Append("\n");
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
