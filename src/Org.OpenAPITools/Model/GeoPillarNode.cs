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
    /// GeoPillarNode
    /// </summary>
    [DataContract(Name = "GeoPillarNode")]
    public partial class GeoPillarNode : PillarType, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeoPillarNode" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GeoPillarNode() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GeoPillarNode" /> class.
        /// </summary>
        /// <param name="attachedResourceId">The attached resourceId. A geoPillar must be visited by this resource..</param>
        /// <param name="onlyScheduledInCompany">If true, this pillar node is only scheduled when the attached resource is part of the same organizational company/group. Prevents cross-company pillar assignments in multi-fleet scenarios..</param>
        /// <param name="connectionRelatedLateMargin">connectionRelatedLateMargin.</param>
        /// <param name="typeName">The typeName of the object (required) (default to &quot;GeoPillarNode&quot;).</param>
        /// <param name="isForcedStayNode">If true, the optimizer must treat this pillar node as an overnight-stay location. The route will terminate here and the next working-hour route will start from this position..</param>
        /// <param name="isAutoTransformable2StartAnchor">If true, the optimizer may automatically promote this pillar to a route-start anchor when it determines that doing so improves the overall solution quality. Allows flexible anchor assignment without manual configuration..</param>
        /// <param name="isOverwritingRouteStart">The boolean isOverwritingRouteStart. Instead of using the default start element of the route, the geoPillar will be used as so-called startAnchor..</param>
        /// <param name="isSchedulableAfterWorkingHours">If true, the optimizer is allowed to schedule this pillar node after the resource&#39;s official working-hours end. Useful for mandatory end-of-day stops (e.g. vehicle return, paperwork drop-off)..</param>
        /// <param name="isOverwritingRouteTermination">The boolean isOverwritingRouteTermination. Instead of using the default termination element of the route, the geoPillar will be used as so-called endAnchor..</param>
        /// <param name="isSchedulableBeforeWorkingHours">If true, the optimizer is allowed to schedule this pillar node before the resource&#39;s official working-hours start. Useful for mandatory stops (e.g. depot loading) that must happen pre-shift..</param>
        /// <param name="isTimeAdjustableAnchor">If true, the anchor timing derived from this pillar is allowed to shift within the working-hour boundaries. Enables the optimizer to adjust the schedule around fixed appointments while maintaining the pillar&#39;s role as a route start or termination anchor..</param>
        public GeoPillarNode(string attachedResourceId = default, bool onlyScheduledInCompany = default, ConnectionRelatedLateMargin connectionRelatedLateMargin = default, string typeName = @"GeoPillarNode", bool isForcedStayNode = default, bool isAutoTransformable2StartAnchor = default, bool isOverwritingRouteStart = default, bool isSchedulableAfterWorkingHours = default, bool isOverwritingRouteTermination = default, bool isSchedulableBeforeWorkingHours = default, bool isTimeAdjustableAnchor = default) : base()
        {
            // to ensure "typeName" is required (not null)
            if (typeName == null)
            {
                throw new ArgumentNullException("typeName is a required property for GeoPillarNode and cannot be null");
            }
            this.TypeName = typeName;
            this.AttachedResourceId = attachedResourceId;
            this.OnlyScheduledInCompany = onlyScheduledInCompany;
            this.ConnectionRelatedLateMargin = connectionRelatedLateMargin;
            this.IsForcedStayNode = isForcedStayNode;
            this.IsAutoTransformable2StartAnchor = isAutoTransformable2StartAnchor;
            this.IsOverwritingRouteStart = isOverwritingRouteStart;
            this.IsSchedulableAfterWorkingHours = isSchedulableAfterWorkingHours;
            this.IsOverwritingRouteTermination = isOverwritingRouteTermination;
            this.IsSchedulableBeforeWorkingHours = isSchedulableBeforeWorkingHours;
            this.IsTimeAdjustableAnchor = isTimeAdjustableAnchor;
        }

        /// <summary>
        /// The attached resourceId. A geoPillar must be visited by this resource.
        /// </summary>
        /// <value>The attached resourceId. A geoPillar must be visited by this resource.</value>
        [DataMember(Name = "attachedResourceId", EmitDefaultValue = false)]
        public string AttachedResourceId { get; set; }

        /// <summary>
        /// If true, this pillar node is only scheduled when the attached resource is part of the same organizational company/group. Prevents cross-company pillar assignments in multi-fleet scenarios.
        /// </summary>
        /// <value>If true, this pillar node is only scheduled when the attached resource is part of the same organizational company/group. Prevents cross-company pillar assignments in multi-fleet scenarios.</value>
        [DataMember(Name = "onlyScheduledInCompany", EmitDefaultValue = true)]
        public bool OnlyScheduledInCompany { get; set; }

        /// <summary>
        /// Gets or Sets ConnectionRelatedLateMargin
        /// </summary>
        [DataMember(Name = "connectionRelatedLateMargin", EmitDefaultValue = false)]
        public ConnectionRelatedLateMargin ConnectionRelatedLateMargin { get; set; }

        /// <summary>
        /// The typeName of the object
        /// </summary>
        /// <value>The typeName of the object</value>
        /*
        <example>GeoPillarNode</example>
        */
        [DataMember(Name = "typeName", IsRequired = true, EmitDefaultValue = true)]
        public string TypeName { get; set; }

        /// <summary>
        /// If true, the optimizer must treat this pillar node as an overnight-stay location. The route will terminate here and the next working-hour route will start from this position.
        /// </summary>
        /// <value>If true, the optimizer must treat this pillar node as an overnight-stay location. The route will terminate here and the next working-hour route will start from this position.</value>
        [DataMember(Name = "isForcedStayNode", EmitDefaultValue = true)]
        public bool IsForcedStayNode { get; set; }

        /// <summary>
        /// If true, the optimizer may automatically promote this pillar to a route-start anchor when it determines that doing so improves the overall solution quality. Allows flexible anchor assignment without manual configuration.
        /// </summary>
        /// <value>If true, the optimizer may automatically promote this pillar to a route-start anchor when it determines that doing so improves the overall solution quality. Allows flexible anchor assignment without manual configuration.</value>
        [DataMember(Name = "isAutoTransformable2StartAnchor", EmitDefaultValue = true)]
        public bool IsAutoTransformable2StartAnchor { get; set; }

        /// <summary>
        /// The boolean isOverwritingRouteStart. Instead of using the default start element of the route, the geoPillar will be used as so-called startAnchor.
        /// </summary>
        /// <value>The boolean isOverwritingRouteStart. Instead of using the default start element of the route, the geoPillar will be used as so-called startAnchor.</value>
        [DataMember(Name = "isOverwritingRouteStart", EmitDefaultValue = true)]
        public bool IsOverwritingRouteStart { get; set; }

        /// <summary>
        /// If true, the optimizer is allowed to schedule this pillar node after the resource&#39;s official working-hours end. Useful for mandatory end-of-day stops (e.g. vehicle return, paperwork drop-off).
        /// </summary>
        /// <value>If true, the optimizer is allowed to schedule this pillar node after the resource&#39;s official working-hours end. Useful for mandatory end-of-day stops (e.g. vehicle return, paperwork drop-off).</value>
        [DataMember(Name = "isSchedulableAfterWorkingHours", EmitDefaultValue = true)]
        public bool IsSchedulableAfterWorkingHours { get; set; }

        /// <summary>
        /// The boolean isOverwritingRouteTermination. Instead of using the default termination element of the route, the geoPillar will be used as so-called endAnchor.
        /// </summary>
        /// <value>The boolean isOverwritingRouteTermination. Instead of using the default termination element of the route, the geoPillar will be used as so-called endAnchor.</value>
        [DataMember(Name = "isOverwritingRouteTermination", EmitDefaultValue = true)]
        public bool IsOverwritingRouteTermination { get; set; }

        /// <summary>
        /// If true, the optimizer is allowed to schedule this pillar node before the resource&#39;s official working-hours start. Useful for mandatory stops (e.g. depot loading) that must happen pre-shift.
        /// </summary>
        /// <value>If true, the optimizer is allowed to schedule this pillar node before the resource&#39;s official working-hours start. Useful for mandatory stops (e.g. depot loading) that must happen pre-shift.</value>
        [DataMember(Name = "isSchedulableBeforeWorkingHours", EmitDefaultValue = true)]
        public bool IsSchedulableBeforeWorkingHours { get; set; }

        /// <summary>
        /// If true, the anchor timing derived from this pillar is allowed to shift within the working-hour boundaries. Enables the optimizer to adjust the schedule around fixed appointments while maintaining the pillar&#39;s role as a route start or termination anchor.
        /// </summary>
        /// <value>If true, the anchor timing derived from this pillar is allowed to shift within the working-hour boundaries. Enables the optimizer to adjust the schedule around fixed appointments while maintaining the pillar&#39;s role as a route start or termination anchor.</value>
        [DataMember(Name = "isTimeAdjustableAnchor", EmitDefaultValue = true)]
        public bool IsTimeAdjustableAnchor { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GeoPillarNode {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  AttachedResourceId: ").Append(AttachedResourceId).Append("\n");
            sb.Append("  OnlyScheduledInCompany: ").Append(OnlyScheduledInCompany).Append("\n");
            sb.Append("  ConnectionRelatedLateMargin: ").Append(ConnectionRelatedLateMargin).Append("\n");
            sb.Append("  TypeName: ").Append(TypeName).Append("\n");
            sb.Append("  IsForcedStayNode: ").Append(IsForcedStayNode).Append("\n");
            sb.Append("  IsAutoTransformable2StartAnchor: ").Append(IsAutoTransformable2StartAnchor).Append("\n");
            sb.Append("  IsOverwritingRouteStart: ").Append(IsOverwritingRouteStart).Append("\n");
            sb.Append("  IsSchedulableAfterWorkingHours: ").Append(IsSchedulableAfterWorkingHours).Append("\n");
            sb.Append("  IsOverwritingRouteTermination: ").Append(IsOverwritingRouteTermination).Append("\n");
            sb.Append("  IsSchedulableBeforeWorkingHours: ").Append(IsSchedulableBeforeWorkingHours).Append("\n");
            sb.Append("  IsTimeAdjustableAnchor: ").Append(IsTimeAdjustableAnchor).Append("\n");
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
