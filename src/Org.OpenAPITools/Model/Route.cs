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
    /// A single route within the optimization solution. Assigns a resource to a sequence of nodes with full scheduling details. Contains the route header (KPIs), start/end elements and positions, lists of optimizable, non-optimizable, optional, and pillar element ids, per-element scheduling details, and route-level flags.
    /// </summary>
    [DataContract(Name = "Route")]
    public partial class Route : IValidatableObject
    {
        /// <summary>
        /// The flags. A list of flags indicating statii like which source finalized a route.
        /// </summary>
        /// <value>The flags. A list of flags indicating statii like which source finalized a route.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum FlagsEnum
        {
            /// <summary>
            /// Enum FINALIZEDPILLARFORCEARRANGER for value: FINALIZED_PILLARFORCEARRANGER
            /// </summary>
            [EnumMember(Value = "FINALIZED_PILLARFORCEARRANGER")]
            FINALIZEDPILLARFORCEARRANGER = 1,

            /// <summary>
            /// Enum INACTIVEPILLARFORCEARRANGER for value: INACTIVE_PILLARFORCEARRANGER
            /// </summary>
            [EnumMember(Value = "INACTIVE_PILLARFORCEARRANGER")]
            INACTIVEPILLARFORCEARRANGER = 2,

            /// <summary>
            /// Enum FINALIZEDROUTEFINALIZER for value: FINALIZED_ROUTE_FINALIZER
            /// </summary>
            [EnumMember(Value = "FINALIZED_ROUTE_FINALIZER")]
            FINALIZEDROUTEFINALIZER = 3,

            /// <summary>
            /// Enum INACTIVEROUTEFINALIZER for value: INACTIVE_ROUTE_FINALIZER
            /// </summary>
            [EnumMember(Value = "INACTIVE_ROUTE_FINALIZER")]
            INACTIVEROUTEFINALIZER = 4
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Route" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Route() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Route" /> class.
        /// </summary>
        /// <param name="header">header.</param>
        /// <param name="id">The id is an optimizer provided number identifiying a route. (required).</param>
        /// <param name="resourceId">The resourceId of the Visitor owning this route. (required).</param>
        /// <param name="routeTrip">routeTrip.</param>
        /// <param name="startTime">The startTime of the route. This is usually the start of the workingHours of the Resource. However, when using flextime/reduction-time the starttime can be different from the working hours start. (required).</param>
        /// <param name="startElementId">The startElementId, is the element from where the route starts. By default, it is the Resource itself. (required).</param>
        /// <param name="startPosition">startPosition.</param>
        /// <param name="endElementId">The endElementId, is the element where the route stops. By default, it is the Resource itself. (required).</param>
        /// <param name="endPosition">endPosition.</param>
        /// <param name="optimizableElementIds">The optimizableElementIds. The list of optimizable elements that are part of the route. (required).</param>
        /// <param name="nonOptimizableElementIds">The nonOptimizableElementIds. The list of non-optimizable elements that are part of the route. (required).</param>
        /// <param name="optionalOptimizableElementIds">The optionalOptimizableElementIds. The list of optional elements that are part of the route. (required).</param>
        /// <param name="pillarElementIds">The pillarElementIds. The list of pillar elements that are part of the route. (required).</param>
        /// <param name="elementDetails">The elementDetails. The list of details describing the route schedule. (required).</param>
        /// <param name="pillarLatestEffectiveArrivalOffsetMap">The pillarLatestEffectiveArrivalOffsetMap. A map of additional time offsets for pillar elements. Each pillar has a latest possible arrival. As a route can consist of multiple pillars, the latest arrival at a certain pillar is also a function of  subsequent pillars. This latest arrival may shifted to a later time spot to allow shifitig a pillar around a normal node, even the normal node would fit before the pillar..</param>
        /// <param name="flags">The flags. A list of flags indicating statii like which source finalized a route..</param>
        /// <param name="additionalRouteStartOffset">The additionalRouteStartOffset.</param>
        /// <param name="isLockedDown">The isLockedDown. Describes if a route was undergoing lockdown..</param>
        /// <param name="isInactive">The isInactive boolean describes if a route is deactivated..</param>
        /// <param name="isFinalized">The isFinalized. Describes if a route was undergoing finalization..</param>
        public Route(RouteHeader header = default, int id = default, string resourceId = default, RouteTrip routeTrip = default, DateTime startTime = default, string startElementId = default, Position startPosition = default, string endElementId = default, Position endPosition = default, List<string> optimizableElementIds = default, List<string> nonOptimizableElementIds = default, List<string> optionalOptimizableElementIds = default, List<string> pillarElementIds = default, List<RouteElementDetail> elementDetails = default, Dictionary<string, long> pillarLatestEffectiveArrivalOffsetMap = default, List<FlagsEnum> flags = default, long additionalRouteStartOffset = default, bool isLockedDown = default, bool isInactive = default, bool isFinalized = default)
        {
            this.Id = id;
            // to ensure "resourceId" is required (not null)
            if (resourceId == null)
            {
                throw new ArgumentNullException("resourceId is a required property for Route and cannot be null");
            }
            this.ResourceId = resourceId;
            this.StartTime = startTime;
            // to ensure "startElementId" is required (not null)
            if (startElementId == null)
            {
                throw new ArgumentNullException("startElementId is a required property for Route and cannot be null");
            }
            this.StartElementId = startElementId;
            // to ensure "endElementId" is required (not null)
            if (endElementId == null)
            {
                throw new ArgumentNullException("endElementId is a required property for Route and cannot be null");
            }
            this.EndElementId = endElementId;
            // to ensure "optimizableElementIds" is required (not null)
            if (optimizableElementIds == null)
            {
                throw new ArgumentNullException("optimizableElementIds is a required property for Route and cannot be null");
            }
            this.OptimizableElementIds = optimizableElementIds;
            // to ensure "nonOptimizableElementIds" is required (not null)
            if (nonOptimizableElementIds == null)
            {
                throw new ArgumentNullException("nonOptimizableElementIds is a required property for Route and cannot be null");
            }
            this.NonOptimizableElementIds = nonOptimizableElementIds;
            // to ensure "optionalOptimizableElementIds" is required (not null)
            if (optionalOptimizableElementIds == null)
            {
                throw new ArgumentNullException("optionalOptimizableElementIds is a required property for Route and cannot be null");
            }
            this.OptionalOptimizableElementIds = optionalOptimizableElementIds;
            // to ensure "pillarElementIds" is required (not null)
            if (pillarElementIds == null)
            {
                throw new ArgumentNullException("pillarElementIds is a required property for Route and cannot be null");
            }
            this.PillarElementIds = pillarElementIds;
            // to ensure "elementDetails" is required (not null)
            if (elementDetails == null)
            {
                throw new ArgumentNullException("elementDetails is a required property for Route and cannot be null");
            }
            this.ElementDetails = elementDetails;
            this.Header = header;
            this.RouteTrip = routeTrip;
            this.StartPosition = startPosition;
            this.EndPosition = endPosition;
            this.PillarLatestEffectiveArrivalOffsetMap = pillarLatestEffectiveArrivalOffsetMap;
            this.Flags = flags;
            this.AdditionalRouteStartOffset = additionalRouteStartOffset;
            this.IsLockedDown = isLockedDown;
            this.IsInactive = isInactive;
            this.IsFinalized = isFinalized;
        }

        /// <summary>
        /// Gets or Sets Header
        /// </summary>
        [DataMember(Name = "header", EmitDefaultValue = false)]
        public RouteHeader Header { get; set; }

        /// <summary>
        /// The id is an optimizer provided number identifiying a route.
        /// </summary>
        /// <value>The id is an optimizer provided number identifiying a route.</value>
        /*
        <example>11</example>
        */
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public int Id { get; set; }

        /// <summary>
        /// The resourceId of the Visitor owning this route.
        /// </summary>
        /// <value>The resourceId of the Visitor owning this route.</value>
        /*
        <example>Laura</example>
        */
        [DataMember(Name = "resourceId", IsRequired = true, EmitDefaultValue = true)]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or Sets RouteTrip
        /// </summary>
        [DataMember(Name = "routeTrip", EmitDefaultValue = false)]
        public RouteTrip RouteTrip { get; set; }

        /// <summary>
        /// The startTime of the route. This is usually the start of the workingHours of the Resource. However, when using flextime/reduction-time the starttime can be different from the working hours start.
        /// </summary>
        /// <value>The startTime of the route. This is usually the start of the workingHours of the Resource. However, when using flextime/reduction-time the starttime can be different from the working hours start.</value>
        /*
        <example>2020-03-06T07:00Z</example>
        */
        [DataMember(Name = "startTime", IsRequired = true, EmitDefaultValue = true)]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The startElementId, is the element from where the route starts. By default, it is the Resource itself.
        /// </summary>
        /// <value>The startElementId, is the element from where the route starts. By default, it is the Resource itself.</value>
        /*
        <example>Laura</example>
        */
        [DataMember(Name = "startElementId", IsRequired = true, EmitDefaultValue = true)]
        public string StartElementId { get; set; }

        /// <summary>
        /// Gets or Sets StartPosition
        /// </summary>
        [DataMember(Name = "startPosition", EmitDefaultValue = false)]
        public Position StartPosition { get; set; }

        /// <summary>
        /// The endElementId, is the element where the route stops. By default, it is the Resource itself.
        /// </summary>
        /// <value>The endElementId, is the element where the route stops. By default, it is the Resource itself.</value>
        /*
        <example>Laura</example>
        */
        [DataMember(Name = "endElementId", IsRequired = true, EmitDefaultValue = true)]
        public string EndElementId { get; set; }

        /// <summary>
        /// Gets or Sets EndPosition
        /// </summary>
        [DataMember(Name = "endPosition", EmitDefaultValue = false)]
        public Position EndPosition { get; set; }

        /// <summary>
        /// The optimizableElementIds. The list of optimizable elements that are part of the route.
        /// </summary>
        /// <value>The optimizableElementIds. The list of optimizable elements that are part of the route.</value>
        [DataMember(Name = "optimizableElementIds", IsRequired = true, EmitDefaultValue = true)]
        public List<string> OptimizableElementIds { get; set; }

        /// <summary>
        /// The nonOptimizableElementIds. The list of non-optimizable elements that are part of the route.
        /// </summary>
        /// <value>The nonOptimizableElementIds. The list of non-optimizable elements that are part of the route.</value>
        [DataMember(Name = "nonOptimizableElementIds", IsRequired = true, EmitDefaultValue = true)]
        public List<string> NonOptimizableElementIds { get; set; }

        /// <summary>
        /// The optionalOptimizableElementIds. The list of optional elements that are part of the route.
        /// </summary>
        /// <value>The optionalOptimizableElementIds. The list of optional elements that are part of the route.</value>
        [DataMember(Name = "optionalOptimizableElementIds", IsRequired = true, EmitDefaultValue = true)]
        public List<string> OptionalOptimizableElementIds { get; set; }

        /// <summary>
        /// The pillarElementIds. The list of pillar elements that are part of the route.
        /// </summary>
        /// <value>The pillarElementIds. The list of pillar elements that are part of the route.</value>
        [DataMember(Name = "pillarElementIds", IsRequired = true, EmitDefaultValue = true)]
        public List<string> PillarElementIds { get; set; }

        /// <summary>
        /// The elementDetails. The list of details describing the route schedule.
        /// </summary>
        /// <value>The elementDetails. The list of details describing the route schedule.</value>
        [DataMember(Name = "elementDetails", IsRequired = true, EmitDefaultValue = true)]
        public List<RouteElementDetail> ElementDetails { get; set; }

        /// <summary>
        /// The pillarLatestEffectiveArrivalOffsetMap. A map of additional time offsets for pillar elements. Each pillar has a latest possible arrival. As a route can consist of multiple pillars, the latest arrival at a certain pillar is also a function of  subsequent pillars. This latest arrival may shifted to a later time spot to allow shifitig a pillar around a normal node, even the normal node would fit before the pillar.
        /// </summary>
        /// <value>The pillarLatestEffectiveArrivalOffsetMap. A map of additional time offsets for pillar elements. Each pillar has a latest possible arrival. As a route can consist of multiple pillars, the latest arrival at a certain pillar is also a function of  subsequent pillars. This latest arrival may shifted to a later time spot to allow shifitig a pillar around a normal node, even the normal node would fit before the pillar.</value>
        [DataMember(Name = "pillarLatestEffectiveArrivalOffsetMap", EmitDefaultValue = false)]
        public Dictionary<string, long> PillarLatestEffectiveArrivalOffsetMap { get; set; }

        /// <summary>
        /// The flags. A list of flags indicating statii like which source finalized a route.
        /// </summary>
        /// <value>The flags. A list of flags indicating statii like which source finalized a route.</value>
        [DataMember(Name = "flags", EmitDefaultValue = false)]
        public List<Route.FlagsEnum> Flags { get; set; }

        /// <summary>
        /// The additionalRouteStartOffset
        /// </summary>
        /// <value>The additionalRouteStartOffset</value>
        [DataMember(Name = "additionalRouteStartOffset", EmitDefaultValue = false)]
        public long AdditionalRouteStartOffset { get; set; }

        /// <summary>
        /// The isLockedDown. Describes if a route was undergoing lockdown.
        /// </summary>
        /// <value>The isLockedDown. Describes if a route was undergoing lockdown.</value>
        /*
        <example>false</example>
        */
        [DataMember(Name = "isLockedDown", EmitDefaultValue = true)]
        public bool IsLockedDown { get; set; }

        /// <summary>
        /// The isInactive boolean describes if a route is deactivated.
        /// </summary>
        /// <value>The isInactive boolean describes if a route is deactivated.</value>
        /*
        <example>false</example>
        */
        [DataMember(Name = "isInactive", EmitDefaultValue = true)]
        public bool IsInactive { get; set; }

        /// <summary>
        /// The isFinalized. Describes if a route was undergoing finalization.
        /// </summary>
        /// <value>The isFinalized. Describes if a route was undergoing finalization.</value>
        /*
        <example>false</example>
        */
        [DataMember(Name = "isFinalized", EmitDefaultValue = true)]
        public bool IsFinalized { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Route {\n");
            sb.Append("  Header: ").Append(Header).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ResourceId: ").Append(ResourceId).Append("\n");
            sb.Append("  RouteTrip: ").Append(RouteTrip).Append("\n");
            sb.Append("  StartTime: ").Append(StartTime).Append("\n");
            sb.Append("  StartElementId: ").Append(StartElementId).Append("\n");
            sb.Append("  StartPosition: ").Append(StartPosition).Append("\n");
            sb.Append("  EndElementId: ").Append(EndElementId).Append("\n");
            sb.Append("  EndPosition: ").Append(EndPosition).Append("\n");
            sb.Append("  OptimizableElementIds: ").Append(OptimizableElementIds).Append("\n");
            sb.Append("  NonOptimizableElementIds: ").Append(NonOptimizableElementIds).Append("\n");
            sb.Append("  OptionalOptimizableElementIds: ").Append(OptionalOptimizableElementIds).Append("\n");
            sb.Append("  PillarElementIds: ").Append(PillarElementIds).Append("\n");
            sb.Append("  ElementDetails: ").Append(ElementDetails).Append("\n");
            sb.Append("  PillarLatestEffectiveArrivalOffsetMap: ").Append(PillarLatestEffectiveArrivalOffsetMap).Append("\n");
            sb.Append("  Flags: ").Append(Flags).Append("\n");
            sb.Append("  AdditionalRouteStartOffset: ").Append(AdditionalRouteStartOffset).Append("\n");
            sb.Append("  IsLockedDown: ").Append(IsLockedDown).Append("\n");
            sb.Append("  IsInactive: ").Append(IsInactive).Append("\n");
            sb.Append("  IsFinalized: ").Append(IsFinalized).Append("\n");
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
