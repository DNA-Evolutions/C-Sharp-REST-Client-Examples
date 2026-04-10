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
    /// A mobile agent (vehicle, driver, technician) available to visit nodes. Defines a home position, one or more working-hour windows with time/distance constraints, optional qualifications (skills), an optional resource depot for pickup-and-delivery, connection efficiency factors, overnight-stay policies, and route configuration (open/closed, alternate destination, return-to-start).
    /// </summary>
    [DataContract(Name = "Resource")]
    public partial class Resource : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Resource" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Resource() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Resource" /> class.
        /// </summary>
        /// <param name="id">The unique id of the Resource. It is not possible, to create mutliple elements (also Nodes) with the same id. (required).</param>
        /// <param name="extraInfo">A custom extra info string that is attached to the Resource..</param>
        /// <param name="locationId">The location id can relate a Resouce to the connection of another resource. See also locationId of Node..</param>
        /// <param name="constraintAliasId">The constraintAliasId. If set is used during constraint assessment instead of using the normal id..</param>
        /// <param name="type">type (required).</param>
        /// <param name="position">position (required).</param>
        /// <param name="workingHours">The list of non-overlapping workingHours. (required).</param>
        /// <param name="maxTime">The maxTime. The maximal time a Resource should work within the WorkingHour. This value is NOT logically coupled to the workingHours. For example, a working hour is defined from 8 in the morning till  5 in the afternoon and the maxTime is defined as 4 hours. In this situation an overime violation will be already  generated  when the Resource works from 8 till 1 (one hour of overtime). As JOpt supports flexible start times, the Resource might work from 12-4 (4 hours &#x3D;&gt; not violation). The workingHour itself should be seen as a frame that is used primarily for matching WokingHours of Resources and OpeningHours of nodes. If no flexTime is used, the Resource will always start working at the beginning of its current working hours. (required).</param>
        /// <param name="maxDistance">The maxDistance. The maximal distance a Resource is allowed to drive within a certain working hours. (required).</param>
        /// <param name="destinationPosition">destinationPosition.</param>
        /// <param name="stayOutDefinition">stayOutDefinition.</param>
        /// <param name="stayOutCycleDefinition">stayOutCycleDefinition.</param>
        /// <param name="stayOutPolicyTime">The maximum additional working time a resource is allowed to accumulate during an overnight-stay route beyond its normal working-hour boundaries. Acts as a buffer for late arrivals at stay nodes..</param>
        /// <param name="stayOutPolicyDistance">The maximum additional driving distance a resource is allowed to accumulate during an overnight-stay route beyond its normal per-working-hour distance limit. Prevents the resource from driving excessively far to reach a stay node..</param>
        /// <param name="capacity">The multi-dimensional capacity vector of the resource (e.g. weight in kg, volume in m³, number of pallets). Each element represents the maximum capacity for one dimension. Used in pickup-and-delivery (PND) scenarios to enforce load constraints. The index positions must align with the load dimensions defined on the nodes..</param>
        /// <param name="initialLoad">The initial load the resource carries at the start of each route, per capacity dimension. For delivery scenarios, this represents the pre-loaded goods at the depot. For pickup scenarios, this is typically zero. Must have the same dimensionality as the capacity vector..</param>
        /// <param name="minDegratedCapacity">The minimum degraded capacity per dimension. As the resource visits more stops, its effective capacity may degrade (e.g. due to fatigue, compartment loss, or reorganization overhead). This vector defines the floor below which the capacity cannot degrade, regardless of the number of stops visited..</param>
        /// <param name="capacityDegPerStop">The capacity degradation per stop, per dimension. After each node visit, the resource&#39;s effective capacity is reduced by this amount (down to the minDegratedCapacity floor). Models real-world effects such as compartment unavailability after partial unloading or diminishing usable space..</param>
        /// <param name="startReductionTimeDefinition">startReductionTimeDefinition.</param>
        /// <param name="startReductionTimePillarDefinition">startReductionTimePillarDefinition.</param>
        /// <param name="startReductionTimeIncludeDefinition">startReductionTimeIncludeDefinition.</param>
        /// <param name="flexTime">The local flexible time. In some cases a Resource should start working later compared to what is defined in the working hours. This way idle time can be reduced. The local flex time is the maximum a Resource is allowed to start working later, depending on the Optimization maybe flex time is not or only partially used..</param>
        /// <param name="postFlexTime">The maximum duration by which the resource is allowed to end its working day earlier than the working-hour boundary. Reduces unnecessary idle time at the end of a route. See also postFlexTimeOnlyOnOvertime to restrict usage to overtime-reduction scenarios..</param>
        /// <param name="postFlexTimeOnlyOnOvertime">The post flextime is only applied to reduce overtime. (default to false).</param>
        /// <param name="maxPillarAfterHoursTime">The maximum duration a pillar node may be served after the resource&#39;s official working-hours end. Applies globally across all working hours of this resource. For per-working-hour overrides, use maxLocalPillarAfterHoursTime on the individual WorkingHours object..</param>
        /// <param name="maxDriveTimeFirstNode">The maximum driving time allowed from the resource&#39;s start position to the first node of a route. Prevents the optimizer from assigning a distant first stop that would consume excessive travel time before productive work begins..</param>
        /// <param name="maxDriveDistanceFirstNode">The maximum driving distance allowed from the resource&#39;s start position to the first node of a route. Complements maxDriveTimeFirstNode to enforce both time- and distance-based proximity constraints..</param>
        /// <param name="maxDriveTimeLastNode">The maximum driving time allowed from the last visited node to the route termination element (typically the resource&#39;s home position or alternate destination). Prevents the optimizer from placing a final stop that would require an excessively long return journey..</param>
        /// <param name="maxDriveDistanceLastNode">The maximum driving distance allowed from the last visited node to the route termination element. Complements maxDriveTimeLastNode to enforce both time- and distance-based return constraints..</param>
        /// <param name="kilometerCost">The kilometerCost defines how much arbitrary cost arises per kilometer driven..</param>
        /// <param name="hourCost">The hourCost defines how much arbitrary cost arises per hour scheduled (idling, working, driving)..</param>
        /// <param name="productionHourCost">The productionHourCost defines how much arbitrary cost arises per hour working..</param>
        /// <param name="fixCost">The fixCost defines an abstract cost that arrises when this node is visited..</param>
        /// <param name="preWorkDrivingTime">DEPRECATED. Use startReductionTimeDefinition instead. Legacy field that defined how long before the official working-hour start the resource was allowed to drive..</param>
        /// <param name="skillEfficiencyFactor">DEPRECATED. Use the visitDurationEfficiency mechanism on individual nodes and ResourceVisitDurationEfficiency instead. Legacy factor that scaled visit durations for this resource..</param>
        /// <param name="acceptableOvertime">The acceptableOvertime. By default if nodes are constantly leading to overtime for a resource, at some point they might get unassigned (if AutoFilter is activated). The acceptable overtime assigns a margin to avoid filtering nodes if they lead to overtime below this margin. By defaul the property  &#39;JoptAutoFilterWorkingHoursExceedMargin&#39; can be used to globally define this value..</param>
        /// <param name="strictOvertime">The strictOvertime. By default if nodes are constantly leading to overtime for a resource, at some point they might get unassigned (if AutoFilter is activated). The strictOvertime overtime assigns a margin to avoid filtering nodes if they lead to overtime below this margin. By defaul the property  &#39;JoptAutoFilterWorkingHoursStrictExceedMargin&#39; can be used to globally define this value. In contrast to acceptable  overtime, the strict overtime is used during the last fitlering step of the AutoFilter (if strict mode is enabled)..</param>
        /// <param name="acceptableOverdistance">The acceptableOverdistance. Like acceptableOvertime for distance..</param>
        /// <param name="strictOverdistance">The strictOverdistance. Like strictOvertime for distance..</param>
        /// <param name="averageSpeed">The averageSpeed of the Resource. By default this value is set to be 22[m/s] (79.2[km/h]). This value is mainly used, in case no external node connections are provided..</param>
        /// <param name="qualifications">The qualifications of the Resource..</param>
        /// <param name="constraints">The constraints  of the Resource.</param>
        /// <param name="connectionTimeEfficiencyFactor">The connectionTimeEfficiencyFactor. The default time for passing a connection is devided by this factor. For example, if a connections needs 30 minutes to be passed by default, a Resource with a connectionTimeEfficiencyFactor of 1.5 only needs 20 minutes. By default this factor is one. (default to 1.0D).</param>
        /// <param name="co2emissionFactor">The co2emissionFactor..</param>
        /// <param name="resourceDepot">resourceDepot.</param>
        /// <param name="overallVisitDurationEfficiency">The overallVisitDurationEfficiency. The base duration a Resource spends at a node is devided by this factor. For example, if a node has 30 minutes of visit duration assigned, a Resource with a overallVisitDurationEfficiency of 1.5 only needs 20 minutes. By default this factor is one. (default to 1.0D).</param>
        /// <param name="isReductionTimeIncludedInTotalWorkingTime">DEPRECATED. Use StartReductionTimeIncludeDefinition instead. Legacy flag that controlled whether reduction time was counted toward the resource&#39;s total working time. (default to false).</param>
        /// <param name="isReductionTimeOnlyUsedForDriving">DEPRECATED. Use startReductionTimeDefinition instead. Legacy flag that restricted reduction time to driving only (no working at the first node before the shift starts). (default to false).</param>
        /// <param name="isServiceHub">A resource is hub mode gets visited by nodes. (default to false).</param>
        public Resource(string id = default, string extraInfo = default, string locationId = default, string constraintAliasId = default, ResourceType type = default, Position position = default, List<WorkingHours> workingHours = default, string maxTime = default, string maxDistance = default, Position destinationPosition = default, StayOutDefinition stayOutDefinition = default, StayOutCycleDefinition stayOutCycleDefinition = default, string stayOutPolicyTime = default, string stayOutPolicyDistance = default, List<double> capacity = default, List<double> initialLoad = default, List<double> minDegratedCapacity = default, List<double> capacityDegPerStop = default, StartReductionTimeDefinition startReductionTimeDefinition = default, StartReductionTimePillarDefinition startReductionTimePillarDefinition = default, StartReductionTimeIncludeDefinition startReductionTimeIncludeDefinition = default, string flexTime = default, string postFlexTime = default, bool? postFlexTimeOnlyOnOvertime = false, string maxPillarAfterHoursTime = default, string maxDriveTimeFirstNode = default, string maxDriveDistanceFirstNode = default, string maxDriveTimeLastNode = default, string maxDriveDistanceLastNode = default, double kilometerCost = default, double hourCost = default, double productionHourCost = default, double fixCost = default, string preWorkDrivingTime = default, double skillEfficiencyFactor = default, string acceptableOvertime = default, string strictOvertime = default, string acceptableOverdistance = default, string strictOverdistance = default, double averageSpeed = default, List<Qualification> qualifications = default, List<Constraint> constraints = default, double connectionTimeEfficiencyFactor = 1.0D, double co2emissionFactor = default, IResourceDepot resourceDepot = default, double overallVisitDurationEfficiency = 1.0D, bool? isReductionTimeIncludedInTotalWorkingTime = false, bool? isReductionTimeOnlyUsedForDriving = false, bool? isServiceHub = false)
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for Resource and cannot be null");
            }
            this.Id = id;
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new ArgumentNullException("type is a required property for Resource and cannot be null");
            }
            this.Type = type;
            // to ensure "position" is required (not null)
            if (position == null)
            {
                throw new ArgumentNullException("position is a required property for Resource and cannot be null");
            }
            this.Position = position;
            // to ensure "workingHours" is required (not null)
            if (workingHours == null)
            {
                throw new ArgumentNullException("workingHours is a required property for Resource and cannot be null");
            }
            this.WorkingHours = workingHours;
            // to ensure "maxTime" is required (not null)
            if (maxTime == null)
            {
                throw new ArgumentNullException("maxTime is a required property for Resource and cannot be null");
            }
            this.MaxTime = maxTime;
            // to ensure "maxDistance" is required (not null)
            if (maxDistance == null)
            {
                throw new ArgumentNullException("maxDistance is a required property for Resource and cannot be null");
            }
            this.MaxDistance = maxDistance;
            this.ExtraInfo = extraInfo;
            this.LocationId = locationId;
            this.ConstraintAliasId = constraintAliasId;
            this.DestinationPosition = destinationPosition;
            this.StayOutDefinition = stayOutDefinition;
            this.StayOutCycleDefinition = stayOutCycleDefinition;
            this.StayOutPolicyTime = stayOutPolicyTime;
            this.StayOutPolicyDistance = stayOutPolicyDistance;
            this.Capacity = capacity;
            this.InitialLoad = initialLoad;
            this.MinDegratedCapacity = minDegratedCapacity;
            this.CapacityDegPerStop = capacityDegPerStop;
            this.StartReductionTimeDefinition = startReductionTimeDefinition;
            this.StartReductionTimePillarDefinition = startReductionTimePillarDefinition;
            this.StartReductionTimeIncludeDefinition = startReductionTimeIncludeDefinition;
            this.FlexTime = flexTime;
            this.PostFlexTime = postFlexTime;
            // use default value if no "postFlexTimeOnlyOnOvertime" provided
            this.PostFlexTimeOnlyOnOvertime = postFlexTimeOnlyOnOvertime ?? false;
            this.MaxPillarAfterHoursTime = maxPillarAfterHoursTime;
            this.MaxDriveTimeFirstNode = maxDriveTimeFirstNode;
            this.MaxDriveDistanceFirstNode = maxDriveDistanceFirstNode;
            this.MaxDriveTimeLastNode = maxDriveTimeLastNode;
            this.MaxDriveDistanceLastNode = maxDriveDistanceLastNode;
            this.KilometerCost = kilometerCost;
            this.HourCost = hourCost;
            this.ProductionHourCost = productionHourCost;
            this.FixCost = fixCost;
            this.PreWorkDrivingTime = preWorkDrivingTime;
            this.SkillEfficiencyFactor = skillEfficiencyFactor;
            this.AcceptableOvertime = acceptableOvertime;
            this.StrictOvertime = strictOvertime;
            this.AcceptableOverdistance = acceptableOverdistance;
            this.StrictOverdistance = strictOverdistance;
            this.AverageSpeed = averageSpeed;
            this.Qualifications = qualifications;
            this.Constraints = constraints;
            this.ConnectionTimeEfficiencyFactor = connectionTimeEfficiencyFactor;
            this.Co2emissionFactor = co2emissionFactor;
            this.ResourceDepot = resourceDepot;
            this.OverallVisitDurationEfficiency = overallVisitDurationEfficiency;
            // use default value if no "isReductionTimeIncludedInTotalWorkingTime" provided
            this.IsReductionTimeIncludedInTotalWorkingTime = isReductionTimeIncludedInTotalWorkingTime ?? false;
            // use default value if no "isReductionTimeOnlyUsedForDriving" provided
            this.IsReductionTimeOnlyUsedForDriving = isReductionTimeOnlyUsedForDriving ?? false;
            // use default value if no "isServiceHub" provided
            this.IsServiceHub = isServiceHub ?? false;
        }

        /// <summary>
        /// The unique id of the Resource. It is not possible, to create mutliple elements (also Nodes) with the same id.
        /// </summary>
        /// <value>The unique id of the Resource. It is not possible, to create mutliple elements (also Nodes) with the same id.</value>
        /*
        <example>MyResource</example>
        */
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// A custom extra info string that is attached to the Resource.
        /// </summary>
        /// <value>A custom extra info string that is attached to the Resource.</value>
        /*
        <example>My custom extra info</example>
        */
        [DataMember(Name = "extraInfo", EmitDefaultValue = false)]
        public string ExtraInfo { get; set; }

        /// <summary>
        /// The location id can relate a Resouce to the connection of another resource. See also locationId of Node.
        /// </summary>
        /// <value>The location id can relate a Resouce to the connection of another resource. See also locationId of Node.</value>
        /*
        <example>MySecondResource</example>
        */
        [DataMember(Name = "locationId", EmitDefaultValue = false)]
        public string LocationId { get; set; }

        /// <summary>
        /// The constraintAliasId. If set is used during constraint assessment instead of using the normal id.
        /// </summary>
        /// <value>The constraintAliasId. If set is used during constraint assessment instead of using the normal id.</value>
        /*
        <example>Jane</example>
        */
        [DataMember(Name = "constraintAliasId", EmitDefaultValue = false)]
        public string ConstraintAliasId { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public ResourceType Type { get; set; }

        /// <summary>
        /// Gets or Sets Position
        /// </summary>
        [DataMember(Name = "position", IsRequired = true, EmitDefaultValue = true)]
        public Position Position { get; set; }

        /// <summary>
        /// The list of non-overlapping workingHours.
        /// </summary>
        /// <value>The list of non-overlapping workingHours.</value>
        [DataMember(Name = "workingHours", IsRequired = true, EmitDefaultValue = true)]
        public List<WorkingHours> WorkingHours { get; set; }

        /// <summary>
        /// The maxTime. The maximal time a Resource should work within the WorkingHour. This value is NOT logically coupled to the workingHours. For example, a working hour is defined from 8 in the morning till  5 in the afternoon and the maxTime is defined as 4 hours. In this situation an overime violation will be already  generated  when the Resource works from 8 till 1 (one hour of overtime). As JOpt supports flexible start times, the Resource might work from 12-4 (4 hours &#x3D;&gt; not violation). The workingHour itself should be seen as a frame that is used primarily for matching WokingHours of Resources and OpeningHours of nodes. If no flexTime is used, the Resource will always start working at the beginning of its current working hours.
        /// </summary>
        /// <value>The maxTime. The maximal time a Resource should work within the WorkingHour. This value is NOT logically coupled to the workingHours. For example, a working hour is defined from 8 in the morning till  5 in the afternoon and the maxTime is defined as 4 hours. In this situation an overime violation will be already  generated  when the Resource works from 8 till 1 (one hour of overtime). As JOpt supports flexible start times, the Resource might work from 12-4 (4 hours &#x3D;&gt; not violation). The workingHour itself should be seen as a frame that is used primarily for matching WokingHours of Resources and OpeningHours of nodes. If no flexTime is used, the Resource will always start working at the beginning of its current working hours.</value>
        /*
        <example>PT8H</example>
        */
        [DataMember(Name = "maxTime", IsRequired = true, EmitDefaultValue = true)]
        public string MaxTime { get; set; }

        /// <summary>
        /// The maxDistance. The maximal distance a Resource is allowed to drive within a certain working hours.
        /// </summary>
        /// <value>The maxDistance. The maximal distance a Resource is allowed to drive within a certain working hours.</value>
        /*
        <example>100.0 km</example>
        */
        [DataMember(Name = "maxDistance", IsRequired = true, EmitDefaultValue = true)]
        public string MaxDistance { get; set; }

        /// <summary>
        /// Gets or Sets DestinationPosition
        /// </summary>
        [DataMember(Name = "destinationPosition", EmitDefaultValue = false)]
        public Position DestinationPosition { get; set; }

        /// <summary>
        /// Gets or Sets StayOutDefinition
        /// </summary>
        [DataMember(Name = "stayOutDefinition", EmitDefaultValue = false)]
        public StayOutDefinition StayOutDefinition { get; set; }

        /// <summary>
        /// Gets or Sets StayOutCycleDefinition
        /// </summary>
        [DataMember(Name = "stayOutCycleDefinition", EmitDefaultValue = false)]
        public StayOutCycleDefinition StayOutCycleDefinition { get; set; }

        /// <summary>
        /// The maximum additional working time a resource is allowed to accumulate during an overnight-stay route beyond its normal working-hour boundaries. Acts as a buffer for late arrivals at stay nodes.
        /// </summary>
        /// <value>The maximum additional working time a resource is allowed to accumulate during an overnight-stay route beyond its normal working-hour boundaries. Acts as a buffer for late arrivals at stay nodes.</value>
        /*
        <example>PT1H</example>
        */
        [DataMember(Name = "stayOutPolicyTime", EmitDefaultValue = false)]
        public string StayOutPolicyTime { get; set; }

        /// <summary>
        /// The maximum additional driving distance a resource is allowed to accumulate during an overnight-stay route beyond its normal per-working-hour distance limit. Prevents the resource from driving excessively far to reach a stay node.
        /// </summary>
        /// <value>The maximum additional driving distance a resource is allowed to accumulate during an overnight-stay route beyond its normal per-working-hour distance limit. Prevents the resource from driving excessively far to reach a stay node.</value>
        /*
        <example>100.0 km</example>
        */
        [DataMember(Name = "stayOutPolicyDistance", EmitDefaultValue = false)]
        public string StayOutPolicyDistance { get; set; }

        /// <summary>
        /// The multi-dimensional capacity vector of the resource (e.g. weight in kg, volume in m³, number of pallets). Each element represents the maximum capacity for one dimension. Used in pickup-and-delivery (PND) scenarios to enforce load constraints. The index positions must align with the load dimensions defined on the nodes.
        /// </summary>
        /// <value>The multi-dimensional capacity vector of the resource (e.g. weight in kg, volume in m³, number of pallets). Each element represents the maximum capacity for one dimension. Used in pickup-and-delivery (PND) scenarios to enforce load constraints. The index positions must align with the load dimensions defined on the nodes.</value>
        [DataMember(Name = "capacity", EmitDefaultValue = false)]
        public List<double> Capacity { get; set; }

        /// <summary>
        /// The initial load the resource carries at the start of each route, per capacity dimension. For delivery scenarios, this represents the pre-loaded goods at the depot. For pickup scenarios, this is typically zero. Must have the same dimensionality as the capacity vector.
        /// </summary>
        /// <value>The initial load the resource carries at the start of each route, per capacity dimension. For delivery scenarios, this represents the pre-loaded goods at the depot. For pickup scenarios, this is typically zero. Must have the same dimensionality as the capacity vector.</value>
        [DataMember(Name = "initialLoad", EmitDefaultValue = false)]
        public List<double> InitialLoad { get; set; }

        /// <summary>
        /// The minimum degraded capacity per dimension. As the resource visits more stops, its effective capacity may degrade (e.g. due to fatigue, compartment loss, or reorganization overhead). This vector defines the floor below which the capacity cannot degrade, regardless of the number of stops visited.
        /// </summary>
        /// <value>The minimum degraded capacity per dimension. As the resource visits more stops, its effective capacity may degrade (e.g. due to fatigue, compartment loss, or reorganization overhead). This vector defines the floor below which the capacity cannot degrade, regardless of the number of stops visited.</value>
        [DataMember(Name = "minDegratedCapacity", EmitDefaultValue = false)]
        public List<double> MinDegratedCapacity { get; set; }

        /// <summary>
        /// The capacity degradation per stop, per dimension. After each node visit, the resource&#39;s effective capacity is reduced by this amount (down to the minDegratedCapacity floor). Models real-world effects such as compartment unavailability after partial unloading or diminishing usable space.
        /// </summary>
        /// <value>The capacity degradation per stop, per dimension. After each node visit, the resource&#39;s effective capacity is reduced by this amount (down to the minDegratedCapacity floor). Models real-world effects such as compartment unavailability after partial unloading or diminishing usable space.</value>
        [DataMember(Name = "capacityDegPerStop", EmitDefaultValue = false)]
        public List<double> CapacityDegPerStop { get; set; }

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
        <example>PT1H</example>
        */
        [DataMember(Name = "flexTime", EmitDefaultValue = false)]
        public string FlexTime { get; set; }

        /// <summary>
        /// The maximum duration by which the resource is allowed to end its working day earlier than the working-hour boundary. Reduces unnecessary idle time at the end of a route. See also postFlexTimeOnlyOnOvertime to restrict usage to overtime-reduction scenarios.
        /// </summary>
        /// <value>The maximum duration by which the resource is allowed to end its working day earlier than the working-hour boundary. Reduces unnecessary idle time at the end of a route. See also postFlexTimeOnlyOnOvertime to restrict usage to overtime-reduction scenarios.</value>
        /*
        <example>PT1H</example>
        */
        [DataMember(Name = "postFlexTime", EmitDefaultValue = false)]
        public string PostFlexTime { get; set; }

        /// <summary>
        /// The post flextime is only applied to reduce overtime.
        /// </summary>
        /// <value>The post flextime is only applied to reduce overtime.</value>
        [DataMember(Name = "postFlexTimeOnlyOnOvertime", EmitDefaultValue = true)]
        public bool? PostFlexTimeOnlyOnOvertime { get; set; }

        /// <summary>
        /// The maximum duration a pillar node may be served after the resource&#39;s official working-hours end. Applies globally across all working hours of this resource. For per-working-hour overrides, use maxLocalPillarAfterHoursTime on the individual WorkingHours object.
        /// </summary>
        /// <value>The maximum duration a pillar node may be served after the resource&#39;s official working-hours end. Applies globally across all working hours of this resource. For per-working-hour overrides, use maxLocalPillarAfterHoursTime on the individual WorkingHours object.</value>
        /*
        <example>PT1H</example>
        */
        [DataMember(Name = "maxPillarAfterHoursTime", EmitDefaultValue = false)]
        public string MaxPillarAfterHoursTime { get; set; }

        /// <summary>
        /// The maximum driving time allowed from the resource&#39;s start position to the first node of a route. Prevents the optimizer from assigning a distant first stop that would consume excessive travel time before productive work begins.
        /// </summary>
        /// <value>The maximum driving time allowed from the resource&#39;s start position to the first node of a route. Prevents the optimizer from assigning a distant first stop that would consume excessive travel time before productive work begins.</value>
        /*
        <example>PT1H</example>
        */
        [DataMember(Name = "maxDriveTimeFirstNode", EmitDefaultValue = false)]
        public string MaxDriveTimeFirstNode { get; set; }

        /// <summary>
        /// The maximum driving distance allowed from the resource&#39;s start position to the first node of a route. Complements maxDriveTimeFirstNode to enforce both time- and distance-based proximity constraints.
        /// </summary>
        /// <value>The maximum driving distance allowed from the resource&#39;s start position to the first node of a route. Complements maxDriveTimeFirstNode to enforce both time- and distance-based proximity constraints.</value>
        /*
        <example>100.0 km</example>
        */
        [DataMember(Name = "maxDriveDistanceFirstNode", EmitDefaultValue = false)]
        public string MaxDriveDistanceFirstNode { get; set; }

        /// <summary>
        /// The maximum driving time allowed from the last visited node to the route termination element (typically the resource&#39;s home position or alternate destination). Prevents the optimizer from placing a final stop that would require an excessively long return journey.
        /// </summary>
        /// <value>The maximum driving time allowed from the last visited node to the route termination element (typically the resource&#39;s home position or alternate destination). Prevents the optimizer from placing a final stop that would require an excessively long return journey.</value>
        /*
        <example>PT1H</example>
        */
        [DataMember(Name = "maxDriveTimeLastNode", EmitDefaultValue = false)]
        public string MaxDriveTimeLastNode { get; set; }

        /// <summary>
        /// The maximum driving distance allowed from the last visited node to the route termination element. Complements maxDriveTimeLastNode to enforce both time- and distance-based return constraints.
        /// </summary>
        /// <value>The maximum driving distance allowed from the last visited node to the route termination element. Complements maxDriveTimeLastNode to enforce both time- and distance-based return constraints.</value>
        /*
        <example>100.0 km</example>
        */
        [DataMember(Name = "maxDriveDistanceLastNode", EmitDefaultValue = false)]
        public string MaxDriveDistanceLastNode { get; set; }

        /// <summary>
        /// The kilometerCost defines how much arbitrary cost arises per kilometer driven.
        /// </summary>
        /// <value>The kilometerCost defines how much arbitrary cost arises per kilometer driven.</value>
        [DataMember(Name = "kilometerCost", EmitDefaultValue = false)]
        public double KilometerCost { get; set; }

        /// <summary>
        /// The hourCost defines how much arbitrary cost arises per hour scheduled (idling, working, driving).
        /// </summary>
        /// <value>The hourCost defines how much arbitrary cost arises per hour scheduled (idling, working, driving).</value>
        [DataMember(Name = "hourCost", EmitDefaultValue = false)]
        public double HourCost { get; set; }

        /// <summary>
        /// The productionHourCost defines how much arbitrary cost arises per hour working.
        /// </summary>
        /// <value>The productionHourCost defines how much arbitrary cost arises per hour working.</value>
        [DataMember(Name = "productionHourCost", EmitDefaultValue = false)]
        public double ProductionHourCost { get; set; }

        /// <summary>
        /// The fixCost defines an abstract cost that arrises when this node is visited.
        /// </summary>
        /// <value>The fixCost defines an abstract cost that arrises when this node is visited.</value>
        [DataMember(Name = "fixCost", EmitDefaultValue = false)]
        public double FixCost { get; set; }

        /// <summary>
        /// DEPRECATED. Use startReductionTimeDefinition instead. Legacy field that defined how long before the official working-hour start the resource was allowed to drive.
        /// </summary>
        /// <value>DEPRECATED. Use startReductionTimeDefinition instead. Legacy field that defined how long before the official working-hour start the resource was allowed to drive.</value>
        /*
        <example>PT1H</example>
        */
        [DataMember(Name = "preWorkDrivingTime", EmitDefaultValue = false)]
        [Obsolete]
        public string PreWorkDrivingTime { get; set; }

        /// <summary>
        /// DEPRECATED. Use the visitDurationEfficiency mechanism on individual nodes and ResourceVisitDurationEfficiency instead. Legacy factor that scaled visit durations for this resource.
        /// </summary>
        /// <value>DEPRECATED. Use the visitDurationEfficiency mechanism on individual nodes and ResourceVisitDurationEfficiency instead. Legacy factor that scaled visit durations for this resource.</value>
        [DataMember(Name = "skillEfficiencyFactor", EmitDefaultValue = false)]
        [Obsolete]
        public double SkillEfficiencyFactor { get; set; }

        /// <summary>
        /// The acceptableOvertime. By default if nodes are constantly leading to overtime for a resource, at some point they might get unassigned (if AutoFilter is activated). The acceptable overtime assigns a margin to avoid filtering nodes if they lead to overtime below this margin. By defaul the property  &#39;JoptAutoFilterWorkingHoursExceedMargin&#39; can be used to globally define this value.
        /// </summary>
        /// <value>The acceptableOvertime. By default if nodes are constantly leading to overtime for a resource, at some point they might get unassigned (if AutoFilter is activated). The acceptable overtime assigns a margin to avoid filtering nodes if they lead to overtime below this margin. By defaul the property  &#39;JoptAutoFilterWorkingHoursExceedMargin&#39; can be used to globally define this value.</value>
        /*
        <example>PT1H</example>
        */
        [DataMember(Name = "acceptableOvertime", EmitDefaultValue = false)]
        public string AcceptableOvertime { get; set; }

        /// <summary>
        /// The strictOvertime. By default if nodes are constantly leading to overtime for a resource, at some point they might get unassigned (if AutoFilter is activated). The strictOvertime overtime assigns a margin to avoid filtering nodes if they lead to overtime below this margin. By defaul the property  &#39;JoptAutoFilterWorkingHoursStrictExceedMargin&#39; can be used to globally define this value. In contrast to acceptable  overtime, the strict overtime is used during the last fitlering step of the AutoFilter (if strict mode is enabled).
        /// </summary>
        /// <value>The strictOvertime. By default if nodes are constantly leading to overtime for a resource, at some point they might get unassigned (if AutoFilter is activated). The strictOvertime overtime assigns a margin to avoid filtering nodes if they lead to overtime below this margin. By defaul the property  &#39;JoptAutoFilterWorkingHoursStrictExceedMargin&#39; can be used to globally define this value. In contrast to acceptable  overtime, the strict overtime is used during the last fitlering step of the AutoFilter (if strict mode is enabled).</value>
        /*
        <example>PT2H</example>
        */
        [DataMember(Name = "strictOvertime", EmitDefaultValue = false)]
        public string StrictOvertime { get; set; }

        /// <summary>
        /// The acceptableOverdistance. Like acceptableOvertime for distance.
        /// </summary>
        /// <value>The acceptableOverdistance. Like acceptableOvertime for distance.</value>
        /*
        <example>100.0 km</example>
        */
        [DataMember(Name = "acceptableOverdistance", EmitDefaultValue = false)]
        public string AcceptableOverdistance { get; set; }

        /// <summary>
        /// The strictOverdistance. Like strictOvertime for distance.
        /// </summary>
        /// <value>The strictOverdistance. Like strictOvertime for distance.</value>
        /*
        <example>100.0 km</example>
        */
        [DataMember(Name = "strictOverdistance", EmitDefaultValue = false)]
        public string StrictOverdistance { get; set; }

        /// <summary>
        /// The averageSpeed of the Resource. By default this value is set to be 22[m/s] (79.2[km/h]). This value is mainly used, in case no external node connections are provided.
        /// </summary>
        /// <value>The averageSpeed of the Resource. By default this value is set to be 22[m/s] (79.2[km/h]). This value is mainly used, in case no external node connections are provided.</value>
        [DataMember(Name = "averageSpeed", EmitDefaultValue = false)]
        public double AverageSpeed { get; set; }

        /// <summary>
        /// The qualifications of the Resource.
        /// </summary>
        /// <value>The qualifications of the Resource.</value>
        [DataMember(Name = "qualifications", EmitDefaultValue = false)]
        public List<Qualification> Qualifications { get; set; }

        /// <summary>
        /// The constraints  of the Resource
        /// </summary>
        /// <value>The constraints  of the Resource</value>
        [DataMember(Name = "constraints", EmitDefaultValue = false)]
        public List<Constraint> Constraints { get; set; }

        /// <summary>
        /// The connectionTimeEfficiencyFactor. The default time for passing a connection is devided by this factor. For example, if a connections needs 30 minutes to be passed by default, a Resource with a connectionTimeEfficiencyFactor of 1.5 only needs 20 minutes. By default this factor is one.
        /// </summary>
        /// <value>The connectionTimeEfficiencyFactor. The default time for passing a connection is devided by this factor. For example, if a connections needs 30 minutes to be passed by default, a Resource with a connectionTimeEfficiencyFactor of 1.5 only needs 20 minutes. By default this factor is one.</value>
        /*
        <example>1.5</example>
        */
        [DataMember(Name = "connectionTimeEfficiencyFactor", EmitDefaultValue = false)]
        public double ConnectionTimeEfficiencyFactor { get; set; }

        /// <summary>
        /// The co2emissionFactor.
        /// </summary>
        /// <value>The co2emissionFactor.</value>
        /*
        <example>0.377</example>
        */
        [DataMember(Name = "co2emissionFactor", EmitDefaultValue = false)]
        public double Co2emissionFactor { get; set; }

        /// <summary>
        /// Gets or Sets ResourceDepot
        /// </summary>
        [DataMember(Name = "resourceDepot", EmitDefaultValue = false)]
        public IResourceDepot ResourceDepot { get; set; }

        /// <summary>
        /// The overallVisitDurationEfficiency. The base duration a Resource spends at a node is devided by this factor. For example, if a node has 30 minutes of visit duration assigned, a Resource with a overallVisitDurationEfficiency of 1.5 only needs 20 minutes. By default this factor is one.
        /// </summary>
        /// <value>The overallVisitDurationEfficiency. The base duration a Resource spends at a node is devided by this factor. For example, if a node has 30 minutes of visit duration assigned, a Resource with a overallVisitDurationEfficiency of 1.5 only needs 20 minutes. By default this factor is one.</value>
        /*
        <example>1.5</example>
        */
        [DataMember(Name = "overallVisitDurationEfficiency", EmitDefaultValue = false)]
        public double OverallVisitDurationEfficiency { get; set; }

        /// <summary>
        /// DEPRECATED. Use StartReductionTimeIncludeDefinition instead. Legacy flag that controlled whether reduction time was counted toward the resource&#39;s total working time.
        /// </summary>
        /// <value>DEPRECATED. Use StartReductionTimeIncludeDefinition instead. Legacy flag that controlled whether reduction time was counted toward the resource&#39;s total working time.</value>
        [DataMember(Name = "isReductionTimeIncludedInTotalWorkingTime", EmitDefaultValue = true)]
        [Obsolete]
        public bool? IsReductionTimeIncludedInTotalWorkingTime { get; set; }

        /// <summary>
        /// DEPRECATED. Use startReductionTimeDefinition instead. Legacy flag that restricted reduction time to driving only (no working at the first node before the shift starts).
        /// </summary>
        /// <value>DEPRECATED. Use startReductionTimeDefinition instead. Legacy flag that restricted reduction time to driving only (no working at the first node before the shift starts).</value>
        [DataMember(Name = "isReductionTimeOnlyUsedForDriving", EmitDefaultValue = true)]
        [Obsolete]
        public bool? IsReductionTimeOnlyUsedForDriving { get; set; }

        /// <summary>
        /// A resource is hub mode gets visited by nodes.
        /// </summary>
        /// <value>A resource is hub mode gets visited by nodes.</value>
        [DataMember(Name = "isServiceHub", EmitDefaultValue = true)]
        public bool? IsServiceHub { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Resource {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ExtraInfo: ").Append(ExtraInfo).Append("\n");
            sb.Append("  LocationId: ").Append(LocationId).Append("\n");
            sb.Append("  ConstraintAliasId: ").Append(ConstraintAliasId).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Position: ").Append(Position).Append("\n");
            sb.Append("  WorkingHours: ").Append(WorkingHours).Append("\n");
            sb.Append("  MaxTime: ").Append(MaxTime).Append("\n");
            sb.Append("  MaxDistance: ").Append(MaxDistance).Append("\n");
            sb.Append("  DestinationPosition: ").Append(DestinationPosition).Append("\n");
            sb.Append("  StayOutDefinition: ").Append(StayOutDefinition).Append("\n");
            sb.Append("  StayOutCycleDefinition: ").Append(StayOutCycleDefinition).Append("\n");
            sb.Append("  StayOutPolicyTime: ").Append(StayOutPolicyTime).Append("\n");
            sb.Append("  StayOutPolicyDistance: ").Append(StayOutPolicyDistance).Append("\n");
            sb.Append("  Capacity: ").Append(Capacity).Append("\n");
            sb.Append("  InitialLoad: ").Append(InitialLoad).Append("\n");
            sb.Append("  MinDegratedCapacity: ").Append(MinDegratedCapacity).Append("\n");
            sb.Append("  CapacityDegPerStop: ").Append(CapacityDegPerStop).Append("\n");
            sb.Append("  StartReductionTimeDefinition: ").Append(StartReductionTimeDefinition).Append("\n");
            sb.Append("  StartReductionTimePillarDefinition: ").Append(StartReductionTimePillarDefinition).Append("\n");
            sb.Append("  StartReductionTimeIncludeDefinition: ").Append(StartReductionTimeIncludeDefinition).Append("\n");
            sb.Append("  FlexTime: ").Append(FlexTime).Append("\n");
            sb.Append("  PostFlexTime: ").Append(PostFlexTime).Append("\n");
            sb.Append("  PostFlexTimeOnlyOnOvertime: ").Append(PostFlexTimeOnlyOnOvertime).Append("\n");
            sb.Append("  MaxPillarAfterHoursTime: ").Append(MaxPillarAfterHoursTime).Append("\n");
            sb.Append("  MaxDriveTimeFirstNode: ").Append(MaxDriveTimeFirstNode).Append("\n");
            sb.Append("  MaxDriveDistanceFirstNode: ").Append(MaxDriveDistanceFirstNode).Append("\n");
            sb.Append("  MaxDriveTimeLastNode: ").Append(MaxDriveTimeLastNode).Append("\n");
            sb.Append("  MaxDriveDistanceLastNode: ").Append(MaxDriveDistanceLastNode).Append("\n");
            sb.Append("  KilometerCost: ").Append(KilometerCost).Append("\n");
            sb.Append("  HourCost: ").Append(HourCost).Append("\n");
            sb.Append("  ProductionHourCost: ").Append(ProductionHourCost).Append("\n");
            sb.Append("  FixCost: ").Append(FixCost).Append("\n");
            sb.Append("  PreWorkDrivingTime: ").Append(PreWorkDrivingTime).Append("\n");
            sb.Append("  SkillEfficiencyFactor: ").Append(SkillEfficiencyFactor).Append("\n");
            sb.Append("  AcceptableOvertime: ").Append(AcceptableOvertime).Append("\n");
            sb.Append("  StrictOvertime: ").Append(StrictOvertime).Append("\n");
            sb.Append("  AcceptableOverdistance: ").Append(AcceptableOverdistance).Append("\n");
            sb.Append("  StrictOverdistance: ").Append(StrictOverdistance).Append("\n");
            sb.Append("  AverageSpeed: ").Append(AverageSpeed).Append("\n");
            sb.Append("  Qualifications: ").Append(Qualifications).Append("\n");
            sb.Append("  Constraints: ").Append(Constraints).Append("\n");
            sb.Append("  ConnectionTimeEfficiencyFactor: ").Append(ConnectionTimeEfficiencyFactor).Append("\n");
            sb.Append("  Co2emissionFactor: ").Append(Co2emissionFactor).Append("\n");
            sb.Append("  ResourceDepot: ").Append(ResourceDepot).Append("\n");
            sb.Append("  OverallVisitDurationEfficiency: ").Append(OverallVisitDurationEfficiency).Append("\n");
            sb.Append("  IsReductionTimeIncludedInTotalWorkingTime: ").Append(IsReductionTimeIncludedInTotalWorkingTime).Append("\n");
            sb.Append("  IsReductionTimeOnlyUsedForDriving: ").Append(IsReductionTimeOnlyUsedForDriving).Append("\n");
            sb.Append("  IsServiceHub: ").Append(IsServiceHub).Append("\n");
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
