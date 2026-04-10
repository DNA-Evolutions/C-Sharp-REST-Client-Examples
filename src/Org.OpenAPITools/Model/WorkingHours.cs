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
    /// A time window during which a resource is available for work. Defined by a begin and end instant with a time zone. Supports maximum working time and distance constraints, overtime/overdistance allowances, start-reduction-time (flex-time) policies, stay-out (overnight) definitions, node color capacities, and optional qualifications and depot configurations per working-hour window.
    /// </summary>
    [DataContract(Name = "WorkingHours")]
    public partial class WorkingHours : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkingHours" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected WorkingHours() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkingHours" /> class.
        /// </summary>
        /// <param name="begin">The begin of the Working hours. (required).</param>
        /// <param name="end">The end of the Working hours. (required).</param>
        /// <param name="zoneId">The zoneId of the Working hours. (required).</param>
        /// <param name="maxTime">The maximal time a Resource should work within the WorkingHour..</param>
        /// <param name="maxDistance">The maximla distance a resource should cover within the WorkingHour..</param>
        /// <param name="stayOutCycleDefinition">stayOutCycleDefinition.</param>
        /// <param name="startReductionTimeDefinition">startReductionTimeDefinition.</param>
        /// <param name="startReductionTimePillarDefinition">startReductionTimePillarDefinition.</param>
        /// <param name="startReductionTimeIncludeDefinition">startReductionTimeIncludeDefinition.</param>
        /// <param name="localFlexTime">The local flexible time. In some cases a Resource should start working later compared to what is defined in the working hours. This way idle time can be reduced. The local flex time is the maximum a Resource is allowed to start working later, depending on the Optimization maybe flex time is not or only partially used..</param>
        /// <param name="localPostFlexTime">The maximum duration by which the resource is allowed to end work earlier than the working-hour boundary. Acts as a flexible end-of-shift buffer — if the last node finishes ahead of schedule, the resource may clock off early by up to this amount, reducing unnecessary idle time at the end of the route. See also localPostFlexTimeOnlyOnOvertime to restrict this behavior to overtime-reduction scenarios only..</param>
        /// <param name="localPostFlexTimeOnlyOnOvertime">The post flextime is only applied to reduce overtime. (default to false).</param>
        /// <param name="maxLocalPillarAfterHoursTime">The maximum duration a pillar node is allowed to be served after the official working-hours end for this specific working-hour window. Enables late-shift mandatory stops (e.g. end-of-day depot return) that extend slightly beyond the defined working-hour boundary..</param>
        /// <param name="nodeColorCapacities">Per-color capacity limits for routes produced from this working hour. Controls the composition of the route by limiting how many nodes of a given color category may appear (e.g. at most 40% hazardous-goods stops). Overrides any resource-level color capacity when set at the working-hour level..</param>
        /// <param name="workingHoursConstraints">The constraints for this working hour..</param>
        /// <param name="multiWorkingHoursConstraints">Constraints that span across multiple working hours of the same resource. Unlike workingHoursConstraints (which apply to a single working-hour window), these constraints enforce policies across the full planning horizon — for example, limiting the total number of a certain node type visited across all days..</param>
        /// <param name="constructionHooks">The hooks for this working hour..</param>
        /// <param name="qualifications">The qualification of the Resource for this working hour. For example, the Resource is allowed to visit a node needing a skill (defined via a constraint) and the Resource is providing this skill..</param>
        /// <param name="routeStartTimeHook">An optional time offset applied to the route start. Shifts the effective departure time from the resource&#39;s home location, for example to account for vehicle preparation, warm-up, or loading time before the first stop..</param>
        /// <param name="hookElementConnections">Pre-computed connections used exclusively during the construction hook phase. These connections override the default element connections for hook-related routing decisions, allowing special distance/time calculations during construction (e.g. depot-to-first-stop distances that differ from normal driving)..</param>
        /// <param name="isLocalServiceHub">If true, this resource operates in service-hub mode during this working hour: instead of the resource traveling to visit nodes, nodes are conceptually &#39;brought to&#39; the resource&#39;s location. Useful for modeling stationary service points, reception desks, or warehouse processing stations. (default to false).</param>
        /// <param name="isClosedRoute">The isClosedRoute boolean describes if a Resource has to visit the termination element of the Route. By default, the start element and the termination element of a Route is the Resource itself. In case of a closed route, by default, the Resource returns to its original starting location. (default to true).</param>
        /// <param name="isAvailableForStay">The boolean isAvailableForStay defines if this working hour is allowed to end at an overnight stay. (default to false).</param>
        public WorkingHours(DateTime begin = default, DateTime end = default, string zoneId = default, string maxTime = default, string maxDistance = default, StayOutCycleDefinition stayOutCycleDefinition = default, StartReductionTimeDefinition startReductionTimeDefinition = default, StartReductionTimePillarDefinition startReductionTimePillarDefinition = default, StartReductionTimeIncludeDefinition startReductionTimeIncludeDefinition = default, string localFlexTime = default, string localPostFlexTime = default, bool? localPostFlexTimeOnlyOnOvertime = false, string maxLocalPillarAfterHoursTime = default, List<NodeColorCapacity> nodeColorCapacities = default, List<Constraint> workingHoursConstraints = default, List<Constraint> multiWorkingHoursConstraints = default, List<ConstructionHook> constructionHooks = default, List<Qualification> qualifications = default, string routeStartTimeHook = default, List<ReducedNodeEdgeConnectorItem> hookElementConnections = default, bool? isLocalServiceHub = false, bool? isClosedRoute = true, bool? isAvailableForStay = false)
        {
            this.Begin = begin;
            this.End = end;
            // to ensure "zoneId" is required (not null)
            if (zoneId == null)
            {
                throw new ArgumentNullException("zoneId is a required property for WorkingHours and cannot be null");
            }
            this.ZoneId = zoneId;
            this.MaxTime = maxTime;
            this.MaxDistance = maxDistance;
            this.StayOutCycleDefinition = stayOutCycleDefinition;
            this.StartReductionTimeDefinition = startReductionTimeDefinition;
            this.StartReductionTimePillarDefinition = startReductionTimePillarDefinition;
            this.StartReductionTimeIncludeDefinition = startReductionTimeIncludeDefinition;
            this.LocalFlexTime = localFlexTime;
            this.LocalPostFlexTime = localPostFlexTime;
            // use default value if no "localPostFlexTimeOnlyOnOvertime" provided
            this.LocalPostFlexTimeOnlyOnOvertime = localPostFlexTimeOnlyOnOvertime ?? false;
            this.MaxLocalPillarAfterHoursTime = maxLocalPillarAfterHoursTime;
            this.NodeColorCapacities = nodeColorCapacities;
            this.WorkingHoursConstraints = workingHoursConstraints;
            this.MultiWorkingHoursConstraints = multiWorkingHoursConstraints;
            this.ConstructionHooks = constructionHooks;
            this.Qualifications = qualifications;
            this.RouteStartTimeHook = routeStartTimeHook;
            this.HookElementConnections = hookElementConnections;
            // use default value if no "isLocalServiceHub" provided
            this.IsLocalServiceHub = isLocalServiceHub ?? false;
            // use default value if no "isClosedRoute" provided
            this.IsClosedRoute = isClosedRoute ?? true;
            // use default value if no "isAvailableForStay" provided
            this.IsAvailableForStay = isAvailableForStay ?? false;
        }

        /// <summary>
        /// The begin of the Working hours.
        /// </summary>
        /// <value>The begin of the Working hours.</value>
        /*
        <example>2020-03-06T07:00Z</example>
        */
        [DataMember(Name = "begin", IsRequired = true, EmitDefaultValue = true)]
        public DateTime Begin { get; set; }

        /// <summary>
        /// The end of the Working hours.
        /// </summary>
        /// <value>The end of the Working hours.</value>
        /*
        <example>2020-03-06T17:00Z</example>
        */
        [DataMember(Name = "end", IsRequired = true, EmitDefaultValue = true)]
        public DateTime End { get; set; }

        /// <summary>
        /// The zoneId of the Working hours.
        /// </summary>
        /// <value>The zoneId of the Working hours.</value>
        /*
        <example>UTC</example>
        */
        [DataMember(Name = "zoneId", IsRequired = true, EmitDefaultValue = true)]
        public string ZoneId { get; set; }

        /// <summary>
        /// The maximal time a Resource should work within the WorkingHour.
        /// </summary>
        /// <value>The maximal time a Resource should work within the WorkingHour.</value>
        /*
        <example>PT480M</example>
        */
        [DataMember(Name = "maxTime", EmitDefaultValue = false)]
        public string MaxTime { get; set; }

        /// <summary>
        /// The maximla distance a resource should cover within the WorkingHour.
        /// </summary>
        /// <value>The maximla distance a resource should cover within the WorkingHour.</value>
        /*
        <example>800.0 km</example>
        */
        [DataMember(Name = "maxDistance", EmitDefaultValue = false)]
        public string MaxDistance { get; set; }

        /// <summary>
        /// Gets or Sets StayOutCycleDefinition
        /// </summary>
        [DataMember(Name = "stayOutCycleDefinition", EmitDefaultValue = false)]
        public StayOutCycleDefinition StayOutCycleDefinition { get; set; }

        /// <summary>
        /// Gets or Sets StartReductionTimeDefinition
        /// </summary>
        [DataMember(Name = "startReductionTimeDefinition", EmitDefaultValue = false)]
        public StartReductionTimeDefinition StartReductionTimeDefinition { get; set; }

        /// <summary>
        /// Gets or Sets StartReductionTimePillarDefinition
        /// </summary>
        [DataMember(Name = "startReductionTimePillarDefinition", EmitDefaultValue = false)]
        public StartReductionTimePillarDefinition StartReductionTimePillarDefinition { get; set; }

        /// <summary>
        /// Gets or Sets StartReductionTimeIncludeDefinition
        /// </summary>
        [DataMember(Name = "startReductionTimeIncludeDefinition", EmitDefaultValue = false)]
        public StartReductionTimeIncludeDefinition StartReductionTimeIncludeDefinition { get; set; }

        /// <summary>
        /// The local flexible time. In some cases a Resource should start working later compared to what is defined in the working hours. This way idle time can be reduced. The local flex time is the maximum a Resource is allowed to start working later, depending on the Optimization maybe flex time is not or only partially used.
        /// </summary>
        /// <value>The local flexible time. In some cases a Resource should start working later compared to what is defined in the working hours. This way idle time can be reduced. The local flex time is the maximum a Resource is allowed to start working later, depending on the Optimization maybe flex time is not or only partially used.</value>
        /*
        <example>PT30M</example>
        */
        [DataMember(Name = "localFlexTime", EmitDefaultValue = false)]
        public string LocalFlexTime { get; set; }

        /// <summary>
        /// The maximum duration by which the resource is allowed to end work earlier than the working-hour boundary. Acts as a flexible end-of-shift buffer — if the last node finishes ahead of schedule, the resource may clock off early by up to this amount, reducing unnecessary idle time at the end of the route. See also localPostFlexTimeOnlyOnOvertime to restrict this behavior to overtime-reduction scenarios only.
        /// </summary>
        /// <value>The maximum duration by which the resource is allowed to end work earlier than the working-hour boundary. Acts as a flexible end-of-shift buffer — if the last node finishes ahead of schedule, the resource may clock off early by up to this amount, reducing unnecessary idle time at the end of the route. See also localPostFlexTimeOnlyOnOvertime to restrict this behavior to overtime-reduction scenarios only.</value>
        /*
        <example>PT30M</example>
        */
        [DataMember(Name = "localPostFlexTime", EmitDefaultValue = false)]
        public string LocalPostFlexTime { get; set; }

        /// <summary>
        /// The post flextime is only applied to reduce overtime.
        /// </summary>
        /// <value>The post flextime is only applied to reduce overtime.</value>
        [DataMember(Name = "localPostFlexTimeOnlyOnOvertime", EmitDefaultValue = true)]
        public bool? LocalPostFlexTimeOnlyOnOvertime { get; set; }

        /// <summary>
        /// The maximum duration a pillar node is allowed to be served after the official working-hours end for this specific working-hour window. Enables late-shift mandatory stops (e.g. end-of-day depot return) that extend slightly beyond the defined working-hour boundary.
        /// </summary>
        /// <value>The maximum duration a pillar node is allowed to be served after the official working-hours end for this specific working-hour window. Enables late-shift mandatory stops (e.g. end-of-day depot return) that extend slightly beyond the defined working-hour boundary.</value>
        /*
        <example>PT30M</example>
        */
        [DataMember(Name = "maxLocalPillarAfterHoursTime", EmitDefaultValue = false)]
        public string MaxLocalPillarAfterHoursTime { get; set; }

        /// <summary>
        /// Per-color capacity limits for routes produced from this working hour. Controls the composition of the route by limiting how many nodes of a given color category may appear (e.g. at most 40% hazardous-goods stops). Overrides any resource-level color capacity when set at the working-hour level.
        /// </summary>
        /// <value>Per-color capacity limits for routes produced from this working hour. Controls the composition of the route by limiting how many nodes of a given color category may appear (e.g. at most 40% hazardous-goods stops). Overrides any resource-level color capacity when set at the working-hour level.</value>
        [DataMember(Name = "nodeColorCapacities", EmitDefaultValue = false)]
        public List<NodeColorCapacity> NodeColorCapacities { get; set; }

        /// <summary>
        /// The constraints for this working hour.
        /// </summary>
        /// <value>The constraints for this working hour.</value>
        [DataMember(Name = "workingHoursConstraints", EmitDefaultValue = false)]
        public List<Constraint> WorkingHoursConstraints { get; set; }

        /// <summary>
        /// Constraints that span across multiple working hours of the same resource. Unlike workingHoursConstraints (which apply to a single working-hour window), these constraints enforce policies across the full planning horizon — for example, limiting the total number of a certain node type visited across all days.
        /// </summary>
        /// <value>Constraints that span across multiple working hours of the same resource. Unlike workingHoursConstraints (which apply to a single working-hour window), these constraints enforce policies across the full planning horizon — for example, limiting the total number of a certain node type visited across all days.</value>
        [DataMember(Name = "multiWorkingHoursConstraints", EmitDefaultValue = false)]
        public List<Constraint> MultiWorkingHoursConstraints { get; set; }

        /// <summary>
        /// The hooks for this working hour.
        /// </summary>
        /// <value>The hooks for this working hour.</value>
        [DataMember(Name = "constructionHooks", EmitDefaultValue = false)]
        public List<ConstructionHook> ConstructionHooks { get; set; }

        /// <summary>
        /// The qualification of the Resource for this working hour. For example, the Resource is allowed to visit a node needing a skill (defined via a constraint) and the Resource is providing this skill.
        /// </summary>
        /// <value>The qualification of the Resource for this working hour. For example, the Resource is allowed to visit a node needing a skill (defined via a constraint) and the Resource is providing this skill.</value>
        [DataMember(Name = "qualifications", EmitDefaultValue = false)]
        public List<Qualification> Qualifications { get; set; }

        /// <summary>
        /// An optional time offset applied to the route start. Shifts the effective departure time from the resource&#39;s home location, for example to account for vehicle preparation, warm-up, or loading time before the first stop.
        /// </summary>
        /// <value>An optional time offset applied to the route start. Shifts the effective departure time from the resource&#39;s home location, for example to account for vehicle preparation, warm-up, or loading time before the first stop.</value>
        /*
        <example>PT30M</example>
        */
        [DataMember(Name = "routeStartTimeHook", EmitDefaultValue = false)]
        public string RouteStartTimeHook { get; set; }

        /// <summary>
        /// Pre-computed connections used exclusively during the construction hook phase. These connections override the default element connections for hook-related routing decisions, allowing special distance/time calculations during construction (e.g. depot-to-first-stop distances that differ from normal driving).
        /// </summary>
        /// <value>Pre-computed connections used exclusively during the construction hook phase. These connections override the default element connections for hook-related routing decisions, allowing special distance/time calculations during construction (e.g. depot-to-first-stop distances that differ from normal driving).</value>
        [DataMember(Name = "hookElementConnections", EmitDefaultValue = false)]
        public List<ReducedNodeEdgeConnectorItem> HookElementConnections { get; set; }

        /// <summary>
        /// If true, this resource operates in service-hub mode during this working hour: instead of the resource traveling to visit nodes, nodes are conceptually &#39;brought to&#39; the resource&#39;s location. Useful for modeling stationary service points, reception desks, or warehouse processing stations.
        /// </summary>
        /// <value>If true, this resource operates in service-hub mode during this working hour: instead of the resource traveling to visit nodes, nodes are conceptually &#39;brought to&#39; the resource&#39;s location. Useful for modeling stationary service points, reception desks, or warehouse processing stations.</value>
        [DataMember(Name = "isLocalServiceHub", EmitDefaultValue = true)]
        public bool? IsLocalServiceHub { get; set; }

        /// <summary>
        /// The isClosedRoute boolean describes if a Resource has to visit the termination element of the Route. By default, the start element and the termination element of a Route is the Resource itself. In case of a closed route, by default, the Resource returns to its original starting location.
        /// </summary>
        /// <value>The isClosedRoute boolean describes if a Resource has to visit the termination element of the Route. By default, the start element and the termination element of a Route is the Resource itself. In case of a closed route, by default, the Resource returns to its original starting location.</value>
        [DataMember(Name = "isClosedRoute", EmitDefaultValue = true)]
        public bool? IsClosedRoute { get; set; }

        /// <summary>
        /// The boolean isAvailableForStay defines if this working hour is allowed to end at an overnight stay.
        /// </summary>
        /// <value>The boolean isAvailableForStay defines if this working hour is allowed to end at an overnight stay.</value>
        [DataMember(Name = "isAvailableForStay", EmitDefaultValue = true)]
        public bool? IsAvailableForStay { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class WorkingHours {\n");
            sb.Append("  Begin: ").Append(Begin).Append("\n");
            sb.Append("  End: ").Append(End).Append("\n");
            sb.Append("  ZoneId: ").Append(ZoneId).Append("\n");
            sb.Append("  MaxTime: ").Append(MaxTime).Append("\n");
            sb.Append("  MaxDistance: ").Append(MaxDistance).Append("\n");
            sb.Append("  StayOutCycleDefinition: ").Append(StayOutCycleDefinition).Append("\n");
            sb.Append("  StartReductionTimeDefinition: ").Append(StartReductionTimeDefinition).Append("\n");
            sb.Append("  StartReductionTimePillarDefinition: ").Append(StartReductionTimePillarDefinition).Append("\n");
            sb.Append("  StartReductionTimeIncludeDefinition: ").Append(StartReductionTimeIncludeDefinition).Append("\n");
            sb.Append("  LocalFlexTime: ").Append(LocalFlexTime).Append("\n");
            sb.Append("  LocalPostFlexTime: ").Append(LocalPostFlexTime).Append("\n");
            sb.Append("  LocalPostFlexTimeOnlyOnOvertime: ").Append(LocalPostFlexTimeOnlyOnOvertime).Append("\n");
            sb.Append("  MaxLocalPillarAfterHoursTime: ").Append(MaxLocalPillarAfterHoursTime).Append("\n");
            sb.Append("  NodeColorCapacities: ").Append(NodeColorCapacities).Append("\n");
            sb.Append("  WorkingHoursConstraints: ").Append(WorkingHoursConstraints).Append("\n");
            sb.Append("  MultiWorkingHoursConstraints: ").Append(MultiWorkingHoursConstraints).Append("\n");
            sb.Append("  ConstructionHooks: ").Append(ConstructionHooks).Append("\n");
            sb.Append("  Qualifications: ").Append(Qualifications).Append("\n");
            sb.Append("  RouteStartTimeHook: ").Append(RouteStartTimeHook).Append("\n");
            sb.Append("  HookElementConnections: ").Append(HookElementConnections).Append("\n");
            sb.Append("  IsLocalServiceHub: ").Append(IsLocalServiceHub).Append("\n");
            sb.Append("  IsClosedRoute: ").Append(IsClosedRoute).Append("\n");
            sb.Append("  IsAvailableForStay: ").Append(IsAvailableForStay).Append("\n");
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
