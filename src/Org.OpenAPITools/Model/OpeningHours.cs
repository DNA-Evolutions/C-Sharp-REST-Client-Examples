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
    /// A time window during which a node is available for visits. Defined by a begin and end instant with a time zone. Supports preferred-window hints, sub-window offsets (e.g. lunch breaks), and exclusive solo-access mode. Multiple non-overlapping opening hours per node are supported.
    /// </summary>
    [DataContract(Name = "OpeningHours")]
    public partial class OpeningHours : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningHours" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected OpeningHours() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningHours" /> class.
        /// </summary>
        /// <param name="begin">The begin of the Opening Hour (required).</param>
        /// <param name="end">The end of the Opening Hour (required).</param>
        /// <param name="zoneId">The zoneId of the Opening Hour (required).</param>
        /// <param name="serviceHoursOffsets">Optional offset pairs that define sub-windows within this opening hour during which the node can actually be serviced. Each pair specifies a start offset and an end offset (in milliseconds) relative to the opening-hour begin. Useful for modeling lunch breaks, shift handovers, or restricted access periods within an otherwise open time window..</param>
        /// <param name="isPreffered">The isPreffered boolean. If an Opening Hour is preffered the Optimizer will try to visit the node inside this Opening Hour. By default, the first Openinghour of a node is the preffered opening hour. (default to false).</param>
        /// <param name="isSoloAccessHours">If true, this opening hour grants exclusive access — the node can only be visited during this specific time window and not during any other opening hour of the same node. Useful for modeling time slots that require dedicated attention (e.g. a VIP appointment slot that cannot overlap with general availability). (default to false).</param>
        public OpeningHours(DateTime begin = default, DateTime end = default, string zoneId = default, List<LongLongPair> serviceHoursOffsets = default, bool? isPreffered = false, bool? isSoloAccessHours = false)
        {
            this.Begin = begin;
            this.End = end;
            // to ensure "zoneId" is required (not null)
            if (zoneId == null)
            {
                throw new ArgumentNullException("zoneId is a required property for OpeningHours and cannot be null");
            }
            this.ZoneId = zoneId;
            this.ServiceHoursOffsets = serviceHoursOffsets;
            // use default value if no "isPreffered" provided
            this.IsPreffered = isPreffered ?? false;
            // use default value if no "isSoloAccessHours" provided
            this.IsSoloAccessHours = isSoloAccessHours ?? false;
        }

        /// <summary>
        /// The begin of the Opening Hour
        /// </summary>
        /// <value>The begin of the Opening Hour</value>
        /*
        <example>2020-03-06T06:00Z</example>
        */
        [DataMember(Name = "begin", IsRequired = true, EmitDefaultValue = true)]
        public DateTime Begin { get; set; }

        /// <summary>
        /// The end of the Opening Hour
        /// </summary>
        /// <value>The end of the Opening Hour</value>
        /*
        <example>2020-03-06T19:00Z</example>
        */
        [DataMember(Name = "end", IsRequired = true, EmitDefaultValue = true)]
        public DateTime End { get; set; }

        /// <summary>
        /// The zoneId of the Opening Hour
        /// </summary>
        /// <value>The zoneId of the Opening Hour</value>
        /*
        <example>UTC</example>
        */
        [DataMember(Name = "zoneId", IsRequired = true, EmitDefaultValue = true)]
        public string ZoneId { get; set; }

        /// <summary>
        /// Optional offset pairs that define sub-windows within this opening hour during which the node can actually be serviced. Each pair specifies a start offset and an end offset (in milliseconds) relative to the opening-hour begin. Useful for modeling lunch breaks, shift handovers, or restricted access periods within an otherwise open time window.
        /// </summary>
        /// <value>Optional offset pairs that define sub-windows within this opening hour during which the node can actually be serviced. Each pair specifies a start offset and an end offset (in milliseconds) relative to the opening-hour begin. Useful for modeling lunch breaks, shift handovers, or restricted access periods within an otherwise open time window.</value>
        [DataMember(Name = "serviceHoursOffsets", EmitDefaultValue = false)]
        public List<LongLongPair> ServiceHoursOffsets { get; set; }

        /// <summary>
        /// The isPreffered boolean. If an Opening Hour is preffered the Optimizer will try to visit the node inside this Opening Hour. By default, the first Openinghour of a node is the preffered opening hour.
        /// </summary>
        /// <value>The isPreffered boolean. If an Opening Hour is preffered the Optimizer will try to visit the node inside this Opening Hour. By default, the first Openinghour of a node is the preffered opening hour.</value>
        /*
        <example>false</example>
        */
        [DataMember(Name = "isPreffered", EmitDefaultValue = true)]
        public bool? IsPreffered { get; set; }

        /// <summary>
        /// If true, this opening hour grants exclusive access — the node can only be visited during this specific time window and not during any other opening hour of the same node. Useful for modeling time slots that require dedicated attention (e.g. a VIP appointment slot that cannot overlap with general availability).
        /// </summary>
        /// <value>If true, this opening hour grants exclusive access — the node can only be visited during this specific time window and not during any other opening hour of the same node. Useful for modeling time slots that require dedicated attention (e.g. a VIP appointment slot that cannot overlap with general availability).</value>
        [DataMember(Name = "isSoloAccessHours", EmitDefaultValue = true)]
        public bool? IsSoloAccessHours { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class OpeningHours {\n");
            sb.Append("  Begin: ").Append(Begin).Append("\n");
            sb.Append("  End: ").Append(End).Append("\n");
            sb.Append("  ZoneId: ").Append(ZoneId).Append("\n");
            sb.Append("  ServiceHoursOffsets: ").Append(ServiceHoursOffsets).Append("\n");
            sb.Append("  IsPreffered: ").Append(IsPreffered).Append("\n");
            sb.Append("  IsSoloAccessHours: ").Append(IsSoloAccessHours).Append("\n");
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
