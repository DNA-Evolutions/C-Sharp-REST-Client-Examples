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
    /// The full scheduling record for a single node within a route. Extends the minimal timing data with idle time, transit time and distance to the next element, early/late arrival flags, per-node violations, schedule status, white-space (slack) information, and pickup-and-delivery load exchange details. One RouteElementDetail is produced per visited node in each route of the solution.
    /// </summary>
    [DataContract(Name = "RouteElementDetail")]
    public partial class RouteElementDetail : IValidatableObject
    {
        /// <summary>
        /// The scheduleStatus.
        /// </summary>
        /// <value>The scheduleStatus.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ScheduleStatusEnum
        {
            /// <summary>
            /// Enum UNKNOWN for value: UNKNOWN
            /// </summary>
            [EnumMember(Value = "UNKNOWN")]
            UNKNOWN,

            /// <summary>
            /// Enum EARLY for value: EARLY
            /// </summary>
            [EnumMember(Value = "EARLY")]
            EARLY,

            /// <summary>
            /// Enum IDLE for value: IDLE
            /// </summary>
            [EnumMember(Value = "IDLE")]
            IDLE,

            /// <summary>
            /// Enum INTIME for value: INTIME
            /// </summary>
            [EnumMember(Value = "INTIME")]
            INTIME,

            /// <summary>
            /// Enum LATE for value: LATE
            /// </summary>
            [EnumMember(Value = "LATE")]
            LATE
        }


        /// <summary>
        /// The scheduleStatus.
        /// </summary>
        /// <value>The scheduleStatus.</value>
        /*
        <example>INTIME</example>
        */
        [DataMember(Name = "scheduleStatus", EmitDefaultValue = false)]
        public ScheduleStatusEnum? ScheduleStatus { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="RouteElementDetail" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected RouteElementDetail() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RouteElementDetail" /> class.
        /// </summary>
        /// <param name="elementId">The elementId that the detail item belongs to. (required).</param>
        /// <param name="startTime">The startTime defines the time when a vistior (Resource) starts serving a node. (required).</param>
        /// <param name="arrivalTime">The arrivalTime defines the time when a vistior (Resource) arrives at a node. It is possible that a Visitior needs to idle at the node until a node opens. (required).</param>
        /// <param name="departureTime">The departureTime defines the time a resource is leaving a node. (required).</param>
        /// <param name="transitionTime">The transitionTime gives the time taken for the connection from the previous element to this element. (required).</param>
        /// <param name="effectivePosition">effectivePosition.</param>
        /// <param name="idleTime">The idleTime is the time the Visitor has to wait until a node can be served. By default idle time arrises at the node to be visited. For example, a the arrival time of a Visitor is at 7 in the morning but the node opens at 8. The Visitor has to wait for one hour at the node location until the node can be served. (required).</param>
        /// <param name="zoneId">The zoneId of detail (required).</param>
        /// <param name="whiteSpaceIdleTime">The whiteSpaceIdleTime only occurs if the Visitor is using a different reduction time definition for normal nodes and PillarNodes. It is usually introduced to avoid a violation where Pillars are allowed to be served before workingTime and Nodes are not..</param>
        /// <param name="durationTime">The durationTime defines how long a node is serverd by a Visitor. (required).</param>
        /// <param name="transitionDistance">The transitionDistance gives the distance taken for the connection from the previous element to this element. (required).</param>
        /// <param name="choosenWorkingHoursIndex">Each visitor can have a list of workingHours. The choosenWorkingHoursIndex is the index of the Visitors workingHour in which the element is visited..</param>
        /// <param name="chosenOpeningHoursIndex">Each node can have a list of openingHours. The chosenOpeningHoursIndex is the index of the node openingHour in which the node is visited..</param>
        /// <param name="earlyDeviation">The earlyDeviation. The early deviation describes how long before the element opens the Visitor arrives. If the value is negative, the Vistor arrives after the element already opens..</param>
        /// <param name="lateDeviation">The lateDeviation. The late deviation describes how much lateness the Vistor has. For example, the element to be visited is open from 8-11 and the desired visit duration is 2 hours. The Visitor has to arrive latest by 9 to finish the Job until 11. If the Visitor arrives at 10 the late deviation will be one hour, as the Visitor needs till 12 to finish the Job. The late deviation can be also negative indicating not beeing late. For example if the Visitor reaches the element by 8 and finishes the Job by 10 and the element closes at 11 the late deviation will be -1 hour..</param>
        /// <param name="scheduleStatus">The scheduleStatus..</param>
        /// <param name="visitorId">The visitorId. The id of the Visitor serving the element..</param>
        /// <param name="loadChange">LEGACY: The change of the load of the element caused by the Visitor. For example, when the element requested 2 items and the Visitor provided only 1 item the loadChange value would be 1..</param>
        /// <param name="curCapacity">LEGACY: The curCapacity of the visitor after visiting the element..</param>
        /// <param name="beforeVisitNodeDepot">beforeVisitNodeDepot.</param>
        /// <param name="afterVisitNodeDepot">afterVisitNodeDepot.</param>
        /// <param name="nodeViolations">The nodeViolations. The violations collected at the element/node. For example, lateViolation, early violation etc..</param>
        /// <param name="isUnlocatedIdleTime">The isUnlocatedIdleTime changes the representation of the idle time in the solution. By default idle time is located at the node to be waited for. If true, the idle time becomes unlocated. For example, a Visitor can reach a node (that opens at 8) by 7 in the morning. If the idle time is unlocated, the arrival time  will be represented as 8 (instead of 7). .</param>
        public RouteElementDetail(string elementId = default, DateTime startTime = default, DateTime arrivalTime = default, DateTime departureTime = default, string transitionTime = default, Position effectivePosition = default, string idleTime = default, string zoneId = default, string whiteSpaceIdleTime = default, string durationTime = default, string transitionDistance = default, int choosenWorkingHoursIndex = default, int chosenOpeningHoursIndex = default, string earlyDeviation = default, string lateDeviation = default, ScheduleStatusEnum? scheduleStatus = default, string visitorId = default, List<double> loadChange = default, List<double> curCapacity = default, INodeDepot beforeVisitNodeDepot = default, INodeDepot afterVisitNodeDepot = default, List<Violation> nodeViolations = default, bool isUnlocatedIdleTime = default)
        {
            // to ensure "elementId" is required (not null)
            if (elementId == null)
            {
                throw new ArgumentNullException("elementId is a required property for RouteElementDetail and cannot be null");
            }
            this.ElementId = elementId;
            this.StartTime = startTime;
            this.ArrivalTime = arrivalTime;
            this.DepartureTime = departureTime;
            // to ensure "transitionTime" is required (not null)
            if (transitionTime == null)
            {
                throw new ArgumentNullException("transitionTime is a required property for RouteElementDetail and cannot be null");
            }
            this.TransitionTime = transitionTime;
            // to ensure "idleTime" is required (not null)
            if (idleTime == null)
            {
                throw new ArgumentNullException("idleTime is a required property for RouteElementDetail and cannot be null");
            }
            this.IdleTime = idleTime;
            // to ensure "zoneId" is required (not null)
            if (zoneId == null)
            {
                throw new ArgumentNullException("zoneId is a required property for RouteElementDetail and cannot be null");
            }
            this.ZoneId = zoneId;
            // to ensure "durationTime" is required (not null)
            if (durationTime == null)
            {
                throw new ArgumentNullException("durationTime is a required property for RouteElementDetail and cannot be null");
            }
            this.DurationTime = durationTime;
            // to ensure "transitionDistance" is required (not null)
            if (transitionDistance == null)
            {
                throw new ArgumentNullException("transitionDistance is a required property for RouteElementDetail and cannot be null");
            }
            this.TransitionDistance = transitionDistance;
            this.EffectivePosition = effectivePosition;
            this.WhiteSpaceIdleTime = whiteSpaceIdleTime;
            this.ChoosenWorkingHoursIndex = choosenWorkingHoursIndex;
            this.ChosenOpeningHoursIndex = chosenOpeningHoursIndex;
            this.EarlyDeviation = earlyDeviation;
            this.LateDeviation = lateDeviation;
            this.ScheduleStatus = scheduleStatus;
            this.VisitorId = visitorId;
            this.LoadChange = loadChange;
            this.CurCapacity = curCapacity;
            this.BeforeVisitNodeDepot = beforeVisitNodeDepot;
            this.AfterVisitNodeDepot = afterVisitNodeDepot;
            this.NodeViolations = nodeViolations;
            this.IsUnlocatedIdleTime = isUnlocatedIdleTime;
        }

        /// <summary>
        /// The elementId that the detail item belongs to.
        /// </summary>
        /// <value>The elementId that the detail item belongs to.</value>
        /*
        <example>Customer-A</example>
        */
        [DataMember(Name = "elementId", IsRequired = true, EmitDefaultValue = true)]
        public string ElementId { get; set; }

        /// <summary>
        /// The startTime defines the time when a vistior (Resource) starts serving a node.
        /// </summary>
        /// <value>The startTime defines the time when a vistior (Resource) starts serving a node.</value>
        /*
        <example>2020-03-06T08:00Z</example>
        */
        [DataMember(Name = "startTime", IsRequired = true, EmitDefaultValue = true)]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The arrivalTime defines the time when a vistior (Resource) arrives at a node. It is possible that a Visitior needs to idle at the node until a node opens.
        /// </summary>
        /// <value>The arrivalTime defines the time when a vistior (Resource) arrives at a node. It is possible that a Visitior needs to idle at the node until a node opens.</value>
        /*
        <example>2020-03-06T07:00Z</example>
        */
        [DataMember(Name = "arrivalTime", IsRequired = true, EmitDefaultValue = true)]
        public DateTime ArrivalTime { get; set; }

        /// <summary>
        /// The departureTime defines the time a resource is leaving a node.
        /// </summary>
        /// <value>The departureTime defines the time a resource is leaving a node.</value>
        /*
        <example>2020-03-06T10:00Z</example>
        */
        [DataMember(Name = "departureTime", IsRequired = true, EmitDefaultValue = true)]
        public DateTime DepartureTime { get; set; }

        /// <summary>
        /// The transitionTime gives the time taken for the connection from the previous element to this element.
        /// </summary>
        /// <value>The transitionTime gives the time taken for the connection from the previous element to this element.</value>
        /*
        <example>PT23M</example>
        */
        [DataMember(Name = "transitionTime", IsRequired = true, EmitDefaultValue = true)]
        public string TransitionTime { get; set; }

        /// <summary>
        /// Gets or Sets EffectivePosition
        /// </summary>
        [DataMember(Name = "effectivePosition", EmitDefaultValue = false)]
        public Position EffectivePosition { get; set; }

        /// <summary>
        /// The idleTime is the time the Visitor has to wait until a node can be served. By default idle time arrises at the node to be visited. For example, a the arrival time of a Visitor is at 7 in the morning but the node opens at 8. The Visitor has to wait for one hour at the node location until the node can be served.
        /// </summary>
        /// <value>The idleTime is the time the Visitor has to wait until a node can be served. By default idle time arrises at the node to be visited. For example, a the arrival time of a Visitor is at 7 in the morning but the node opens at 8. The Visitor has to wait for one hour at the node location until the node can be served.</value>
        /*
        <example>PT60M</example>
        */
        [DataMember(Name = "idleTime", IsRequired = true, EmitDefaultValue = true)]
        public string IdleTime { get; set; }

        /// <summary>
        /// The zoneId of detail
        /// </summary>
        /// <value>The zoneId of detail</value>
        /*
        <example>UTC</example>
        */
        [DataMember(Name = "zoneId", IsRequired = true, EmitDefaultValue = true)]
        public string ZoneId { get; set; }

        /// <summary>
        /// The whiteSpaceIdleTime only occurs if the Visitor is using a different reduction time definition for normal nodes and PillarNodes. It is usually introduced to avoid a violation where Pillars are allowed to be served before workingTime and Nodes are not.
        /// </summary>
        /// <value>The whiteSpaceIdleTime only occurs if the Visitor is using a different reduction time definition for normal nodes and PillarNodes. It is usually introduced to avoid a violation where Pillars are allowed to be served before workingTime and Nodes are not.</value>
        /*
        <example>PT26M</example>
        */
        [DataMember(Name = "whiteSpaceIdleTime", EmitDefaultValue = false)]
        public string WhiteSpaceIdleTime { get; set; }

        /// <summary>
        /// The durationTime defines how long a node is serverd by a Visitor.
        /// </summary>
        /// <value>The durationTime defines how long a node is serverd by a Visitor.</value>
        /*
        <example>PT120M</example>
        */
        [DataMember(Name = "durationTime", IsRequired = true, EmitDefaultValue = true)]
        public string DurationTime { get; set; }

        /// <summary>
        /// The transitionDistance gives the distance taken for the connection from the previous element to this element.
        /// </summary>
        /// <value>The transitionDistance gives the distance taken for the connection from the previous element to this element.</value>
        /*
        <example>100.0 km</example>
        */
        [DataMember(Name = "transitionDistance", IsRequired = true, EmitDefaultValue = true)]
        public string TransitionDistance { get; set; }

        /// <summary>
        /// Each visitor can have a list of workingHours. The choosenWorkingHoursIndex is the index of the Visitors workingHour in which the element is visited.
        /// </summary>
        /// <value>Each visitor can have a list of workingHours. The choosenWorkingHoursIndex is the index of the Visitors workingHour in which the element is visited.</value>
        /*
        <example>1</example>
        */
        [DataMember(Name = "choosenWorkingHoursIndex", EmitDefaultValue = false)]
        public int ChoosenWorkingHoursIndex { get; set; }

        /// <summary>
        /// Each node can have a list of openingHours. The chosenOpeningHoursIndex is the index of the node openingHour in which the node is visited.
        /// </summary>
        /// <value>Each node can have a list of openingHours. The chosenOpeningHoursIndex is the index of the node openingHour in which the node is visited.</value>
        /*
        <example>1</example>
        */
        [DataMember(Name = "chosenOpeningHoursIndex", EmitDefaultValue = false)]
        public int ChosenOpeningHoursIndex { get; set; }

        /// <summary>
        /// The earlyDeviation. The early deviation describes how long before the element opens the Visitor arrives. If the value is negative, the Vistor arrives after the element already opens.
        /// </summary>
        /// <value>The earlyDeviation. The early deviation describes how long before the element opens the Visitor arrives. If the value is negative, the Vistor arrives after the element already opens.</value>
        /*
        <example>PT30M</example>
        */
        [DataMember(Name = "earlyDeviation", EmitDefaultValue = false)]
        public string EarlyDeviation { get; set; }

        /// <summary>
        /// The lateDeviation. The late deviation describes how much lateness the Vistor has. For example, the element to be visited is open from 8-11 and the desired visit duration is 2 hours. The Visitor has to arrive latest by 9 to finish the Job until 11. If the Visitor arrives at 10 the late deviation will be one hour, as the Visitor needs till 12 to finish the Job. The late deviation can be also negative indicating not beeing late. For example if the Visitor reaches the element by 8 and finishes the Job by 10 and the element closes at 11 the late deviation will be -1 hour.
        /// </summary>
        /// <value>The lateDeviation. The late deviation describes how much lateness the Vistor has. For example, the element to be visited is open from 8-11 and the desired visit duration is 2 hours. The Visitor has to arrive latest by 9 to finish the Job until 11. If the Visitor arrives at 10 the late deviation will be one hour, as the Visitor needs till 12 to finish the Job. The late deviation can be also negative indicating not beeing late. For example if the Visitor reaches the element by 8 and finishes the Job by 10 and the element closes at 11 the late deviation will be -1 hour.</value>
        /*
        <example>PT-30M</example>
        */
        [DataMember(Name = "lateDeviation", EmitDefaultValue = false)]
        public string LateDeviation { get; set; }

        /// <summary>
        /// The visitorId. The id of the Visitor serving the element.
        /// </summary>
        /// <value>The visitorId. The id of the Visitor serving the element.</value>
        /*
        <example>Laura</example>
        */
        [DataMember(Name = "visitorId", EmitDefaultValue = false)]
        public string VisitorId { get; set; }

        /// <summary>
        /// LEGACY: The change of the load of the element caused by the Visitor. For example, when the element requested 2 items and the Visitor provided only 1 item the loadChange value would be 1.
        /// </summary>
        /// <value>LEGACY: The change of the load of the element caused by the Visitor. For example, when the element requested 2 items and the Visitor provided only 1 item the loadChange value would be 1.</value>
        [DataMember(Name = "loadChange", EmitDefaultValue = false)]
        public List<double> LoadChange { get; set; }

        /// <summary>
        /// LEGACY: The curCapacity of the visitor after visiting the element.
        /// </summary>
        /// <value>LEGACY: The curCapacity of the visitor after visiting the element.</value>
        [DataMember(Name = "curCapacity", EmitDefaultValue = false)]
        public List<double> CurCapacity { get; set; }

        /// <summary>
        /// Gets or Sets BeforeVisitNodeDepot
        /// </summary>
        [DataMember(Name = "beforeVisitNodeDepot", EmitDefaultValue = false)]
        public INodeDepot BeforeVisitNodeDepot { get; set; }

        /// <summary>
        /// Gets or Sets AfterVisitNodeDepot
        /// </summary>
        [DataMember(Name = "afterVisitNodeDepot", EmitDefaultValue = false)]
        public INodeDepot AfterVisitNodeDepot { get; set; }

        /// <summary>
        /// The nodeViolations. The violations collected at the element/node. For example, lateViolation, early violation etc.
        /// </summary>
        /// <value>The nodeViolations. The violations collected at the element/node. For example, lateViolation, early violation etc.</value>
        [DataMember(Name = "nodeViolations", EmitDefaultValue = false)]
        public List<Violation> NodeViolations { get; set; }

        /// <summary>
        /// The isUnlocatedIdleTime changes the representation of the idle time in the solution. By default idle time is located at the node to be waited for. If true, the idle time becomes unlocated. For example, a Visitor can reach a node (that opens at 8) by 7 in the morning. If the idle time is unlocated, the arrival time  will be represented as 8 (instead of 7). 
        /// </summary>
        /// <value>The isUnlocatedIdleTime changes the representation of the idle time in the solution. By default idle time is located at the node to be waited for. If true, the idle time becomes unlocated. For example, a Visitor can reach a node (that opens at 8) by 7 in the morning. If the idle time is unlocated, the arrival time  will be represented as 8 (instead of 7). </value>
        [DataMember(Name = "isUnlocatedIdleTime", EmitDefaultValue = true)]
        public bool IsUnlocatedIdleTime { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class RouteElementDetail {\n");
            sb.Append("  ElementId: ").Append(ElementId).Append("\n");
            sb.Append("  StartTime: ").Append(StartTime).Append("\n");
            sb.Append("  ArrivalTime: ").Append(ArrivalTime).Append("\n");
            sb.Append("  DepartureTime: ").Append(DepartureTime).Append("\n");
            sb.Append("  TransitionTime: ").Append(TransitionTime).Append("\n");
            sb.Append("  EffectivePosition: ").Append(EffectivePosition).Append("\n");
            sb.Append("  IdleTime: ").Append(IdleTime).Append("\n");
            sb.Append("  ZoneId: ").Append(ZoneId).Append("\n");
            sb.Append("  WhiteSpaceIdleTime: ").Append(WhiteSpaceIdleTime).Append("\n");
            sb.Append("  DurationTime: ").Append(DurationTime).Append("\n");
            sb.Append("  TransitionDistance: ").Append(TransitionDistance).Append("\n");
            sb.Append("  ChoosenWorkingHoursIndex: ").Append(ChoosenWorkingHoursIndex).Append("\n");
            sb.Append("  ChosenOpeningHoursIndex: ").Append(ChosenOpeningHoursIndex).Append("\n");
            sb.Append("  EarlyDeviation: ").Append(EarlyDeviation).Append("\n");
            sb.Append("  LateDeviation: ").Append(LateDeviation).Append("\n");
            sb.Append("  ScheduleStatus: ").Append(ScheduleStatus).Append("\n");
            sb.Append("  VisitorId: ").Append(VisitorId).Append("\n");
            sb.Append("  LoadChange: ").Append(LoadChange).Append("\n");
            sb.Append("  CurCapacity: ").Append(CurCapacity).Append("\n");
            sb.Append("  BeforeVisitNodeDepot: ").Append(BeforeVisitNodeDepot).Append("\n");
            sb.Append("  AfterVisitNodeDepot: ").Append(AfterVisitNodeDepot).Append("\n");
            sb.Append("  NodeViolations: ").Append(NodeViolations).Append("\n");
            sb.Append("  IsUnlocatedIdleTime: ").Append(IsUnlocatedIdleTime).Append("\n");
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
