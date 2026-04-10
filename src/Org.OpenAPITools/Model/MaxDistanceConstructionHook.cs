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
using JsonSubTypes;
using System.ComponentModel.DataAnnotations;
using FileParameter = Org.OpenAPITools.Client.FileParameter;
using OpenAPIDateConverter = Org.OpenAPITools.Client.OpenAPIDateConverter;

namespace Org.OpenAPITools.Model
{
    /// <summary>
    /// MaxDistanceConstructionHook
    /// </summary>
    [DataContract(Name = "MaxDistanceConstructionHook")]
    public partial class MaxDistanceConstructionHook : HookType, IValidatableObject
    {
        /// <summary>
        /// When is the hook incorporated?
        /// </summary>
        /// <value>When is the hook incorporated?</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum InvocationPositionEnum
        {
            /// <summary>
            /// Enum PRECONSTRUCTION for value: PRE_CONSTRUCTION
            /// </summary>
            [EnumMember(Value = "PRE_CONSTRUCTION")]
            PRECONSTRUCTION = 1,

            /// <summary>
            /// Enum BEFORELEFTOVERHANDLING for value: BEFORE_LEFTOVER_HANDLING
            /// </summary>
            [EnumMember(Value = "BEFORE_LEFTOVER_HANDLING")]
            BEFORELEFTOVERHANDLING = 2,

            /// <summary>
            /// Enum POSTCONSTRUCTION for value: POST_CONSTRUCTION
            /// </summary>
            [EnumMember(Value = "POST_CONSTRUCTION")]
            POSTCONSTRUCTION = 3
        }


        /// <summary>
        /// When is the hook incorporated?
        /// </summary>
        /// <value>When is the hook incorporated?</value>
        [DataMember(Name = "invocationPosition", IsRequired = true, EmitDefaultValue = true)]
        public InvocationPositionEnum InvocationPosition { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="MaxDistanceConstructionHook" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected MaxDistanceConstructionHook() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="MaxDistanceConstructionHook" /> class.
        /// </summary>
        /// <param name="typeName">The typeName of the object (required) (default to &quot;MaxDistanceConstructionHook&quot;).</param>
        /// <param name="prioritizeNodeConnectorOnFallbackSpeed">In case the route to be used to calculate the average speed is empty, we need to calculate a fallback speed. By default we take the average speed provided by the resource. However, we can also extract a few connections from node connector that belong to the visiting resource of the route and calculated an average speed. (required).</param>
        /// <param name="onlyApplyOnce">If only applied once, the hook is autmatically set to be inactive after one execution. (required).</param>
        /// <param name="invocationPosition">When is the hook incorporated? (required).</param>
        /// <param name="drivenTime">The offset for driven time. This time will be transformed into a distance (utilizing average resource speed) that is substracted from the defined maxdistance. (required).</param>
        /// <param name="drivenDistance">The offset for driven distance. This value is substracted from the defined maxdistance. (required).</param>
        /// <param name="isActive">Is the hook active? (required).</param>
        public MaxDistanceConstructionHook(string typeName = @"MaxDistanceConstructionHook", bool prioritizeNodeConnectorOnFallbackSpeed = default, bool onlyApplyOnce = default, InvocationPositionEnum invocationPosition = default, string drivenTime = default, string drivenDistance = default, bool isActive = default) : base()
        {
            // to ensure "typeName" is required (not null)
            if (typeName == null)
            {
                throw new ArgumentNullException("typeName is a required property for MaxDistanceConstructionHook and cannot be null");
            }
            this.TypeName = typeName;
            this.PrioritizeNodeConnectorOnFallbackSpeed = prioritizeNodeConnectorOnFallbackSpeed;
            this.OnlyApplyOnce = onlyApplyOnce;
            this.InvocationPosition = invocationPosition;
            // to ensure "drivenTime" is required (not null)
            if (drivenTime == null)
            {
                throw new ArgumentNullException("drivenTime is a required property for MaxDistanceConstructionHook and cannot be null");
            }
            this.DrivenTime = drivenTime;
            // to ensure "drivenDistance" is required (not null)
            if (drivenDistance == null)
            {
                throw new ArgumentNullException("drivenDistance is a required property for MaxDistanceConstructionHook and cannot be null");
            }
            this.DrivenDistance = drivenDistance;
            this.IsActive = isActive;
        }

        /// <summary>
        /// The typeName of the object
        /// </summary>
        /// <value>The typeName of the object</value>
        /*
        <example>MaxDistanceConstructionHook</example>
        */
        [DataMember(Name = "typeName", IsRequired = true, EmitDefaultValue = true)]
        public string TypeName { get; set; }

        /// <summary>
        /// In case the route to be used to calculate the average speed is empty, we need to calculate a fallback speed. By default we take the average speed provided by the resource. However, we can also extract a few connections from node connector that belong to the visiting resource of the route and calculated an average speed.
        /// </summary>
        /// <value>In case the route to be used to calculate the average speed is empty, we need to calculate a fallback speed. By default we take the average speed provided by the resource. However, we can also extract a few connections from node connector that belong to the visiting resource of the route and calculated an average speed.</value>
        [DataMember(Name = "prioritizeNodeConnectorOnFallbackSpeed", IsRequired = true, EmitDefaultValue = true)]
        public bool PrioritizeNodeConnectorOnFallbackSpeed { get; set; }

        /// <summary>
        /// If only applied once, the hook is autmatically set to be inactive after one execution.
        /// </summary>
        /// <value>If only applied once, the hook is autmatically set to be inactive after one execution.</value>
        [DataMember(Name = "onlyApplyOnce", IsRequired = true, EmitDefaultValue = true)]
        public bool OnlyApplyOnce { get; set; }

        /// <summary>
        /// The offset for driven time. This time will be transformed into a distance (utilizing average resource speed) that is substracted from the defined maxdistance.
        /// </summary>
        /// <value>The offset for driven time. This time will be transformed into a distance (utilizing average resource speed) that is substracted from the defined maxdistance.</value>
        /*
        <example>PT120M</example>
        */
        [DataMember(Name = "drivenTime", IsRequired = true, EmitDefaultValue = true)]
        public string DrivenTime { get; set; }

        /// <summary>
        /// The offset for driven distance. This value is substracted from the defined maxdistance.
        /// </summary>
        /// <value>The offset for driven distance. This value is substracted from the defined maxdistance.</value>
        /*
        <example>100.0 km</example>
        */
        [DataMember(Name = "drivenDistance", IsRequired = true, EmitDefaultValue = true)]
        public string DrivenDistance { get; set; }

        /// <summary>
        /// Is the hook active?
        /// </summary>
        /// <value>Is the hook active?</value>
        [DataMember(Name = "isActive", IsRequired = true, EmitDefaultValue = true)]
        public bool IsActive { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class MaxDistanceConstructionHook {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  TypeName: ").Append(TypeName).Append("\n");
            sb.Append("  PrioritizeNodeConnectorOnFallbackSpeed: ").Append(PrioritizeNodeConnectorOnFallbackSpeed).Append("\n");
            sb.Append("  OnlyApplyOnce: ").Append(OnlyApplyOnce).Append("\n");
            sb.Append("  InvocationPosition: ").Append(InvocationPosition).Append("\n");
            sb.Append("  DrivenTime: ").Append(DrivenTime).Append("\n");
            sb.Append("  DrivenDistance: ").Append(DrivenDistance).Append("\n");
            sb.Append("  IsActive: ").Append(IsActive).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
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
            return this.BaseValidate(validationContext);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        protected IEnumerable<ValidationResult> BaseValidate(ValidationContext validationContext)
        {
            foreach (var x in base.BaseValidate(validationContext))
            {
                yield return x;
            }
            yield break;
        }
    }

}
