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
    /// Pre-computed connections used exclusively during the construction hook phase. These connections override the default element connections for hook-related routing decisions, allowing special distance/time calculations during construction (e.g. depot-to-first-stop distances that differ from normal driving).
    /// </summary>
    [DataContract(Name = "ReducedNodeEdgeConnectorItem")]
    public partial class ReducedNodeEdgeConnectorItem : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReducedNodeEdgeConnectorItem" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ReducedNodeEdgeConnectorItem() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ReducedNodeEdgeConnectorItem" /> class.
        /// </summary>
        /// <param name="distance">The distance of the hook connection. (required).</param>
        /// <param name="time">The time needed to pass the hook connection. (required).</param>
        /// <param name="fromElementId">The fromElementId defines the element where the connections starts. (required).</param>
        /// <param name="toElementId">The toElementId defines the element where the connections ends. (required).</param>
        public ReducedNodeEdgeConnectorItem(string distance = default, string time = default, string fromElementId = default, string toElementId = default)
        {
            // to ensure "distance" is required (not null)
            if (distance == null)
            {
                throw new ArgumentNullException("distance is a required property for ReducedNodeEdgeConnectorItem and cannot be null");
            }
            this.Distance = distance;
            // to ensure "time" is required (not null)
            if (time == null)
            {
                throw new ArgumentNullException("time is a required property for ReducedNodeEdgeConnectorItem and cannot be null");
            }
            this.Time = time;
            // to ensure "fromElementId" is required (not null)
            if (fromElementId == null)
            {
                throw new ArgumentNullException("fromElementId is a required property for ReducedNodeEdgeConnectorItem and cannot be null");
            }
            this.FromElementId = fromElementId;
            // to ensure "toElementId" is required (not null)
            if (toElementId == null)
            {
                throw new ArgumentNullException("toElementId is a required property for ReducedNodeEdgeConnectorItem and cannot be null");
            }
            this.ToElementId = toElementId;
        }

        /// <summary>
        /// The distance of the hook connection.
        /// </summary>
        /// <value>The distance of the hook connection.</value>
        /*
        <example>100.0 km</example>
        */
        [DataMember(Name = "distance", IsRequired = true, EmitDefaultValue = true)]
        public string Distance { get; set; }

        /// <summary>
        /// The time needed to pass the hook connection.
        /// </summary>
        /// <value>The time needed to pass the hook connection.</value>
        /*
        <example>PT30M</example>
        */
        [DataMember(Name = "time", IsRequired = true, EmitDefaultValue = true)]
        public string Time { get; set; }

        /// <summary>
        /// The fromElementId defines the element where the connections starts.
        /// </summary>
        /// <value>The fromElementId defines the element where the connections starts.</value>
        /*
        <example>MyStartElementId</example>
        */
        [DataMember(Name = "fromElementId", IsRequired = true, EmitDefaultValue = true)]
        public string FromElementId { get; set; }

        /// <summary>
        /// The toElementId defines the element where the connections ends.
        /// </summary>
        /// <value>The toElementId defines the element where the connections ends.</value>
        /*
        <example>MyToElementId</example>
        */
        [DataMember(Name = "toElementId", IsRequired = true, EmitDefaultValue = true)]
        public string ToElementId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ReducedNodeEdgeConnectorItem {\n");
            sb.Append("  Distance: ").Append(Distance).Append("\n");
            sb.Append("  Time: ").Append(Time).Append("\n");
            sb.Append("  FromElementId: ").Append(FromElementId).Append("\n");
            sb.Append("  ToElementId: ").Append(ToElementId).Append("\n");
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
