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
    /// A work item, customer location, or event to be scheduled and assigned to a resource. Each node defines a type (GeoNode, EventNode, or pillar variants), opening-hour windows, a required visit duration, and optional constraints, pickup-and-delivery loads, priority, node color, and relations to other nodes.
    /// </summary>
    [DataContract(Name = "Node")]
    public partial class Node : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Node() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Node" /> class.
        /// </summary>
        /// <param name="id">The unique id of the node. It is not possible, to create mutliple elements (also Resources) with the same id. (required).</param>
        /// <param name="extraInfo">A custom extra info string that is attached to the Node..</param>
        /// <param name="locationId">The location id can relate a node to the connection of another node. For example  the node &#39;MyFirstNode&#39; and &#39;MySecondNode&#39; have the same location. It is sufficient to provide the  connection data for &#39;MyFirstNode&#39; and set the LocationId of &#39;MySecondNode&#39; to be &#39;MyFirstNode&#39;.</param>
        /// <param name="constraintAliasId">The constraintAliasId. If set is used during constraint assessment instead of using the normal id..</param>
        /// <param name="type">type (required).</param>
        /// <param name="openingHours">The list of non-overlapping openingHours of the nodes. (required).</param>
        /// <param name="visitDuration">The visitDuration defines how long a visitor needs to stay at the node. (required).</param>
        /// <param name="constraints">The constraints of this node.</param>
        /// <param name="offeredNode">offeredNode.</param>
        /// <param name="loadDimension">loadDimension.</param>
        /// <param name="load">The multi-dimensional load vector for this node in pickup-and-delivery scenarios. Each element corresponds to a capacity dimension on the resource (e.g. weight, volume, pallet count). Positive values typically represent demand (delivery), while the interpretation depends on the loadDimension configuration..</param>
        /// <param name="qualifications">The qualifications of the node..</param>
        /// <param name="lockdownTime">An optional lockdown time (in milliseconds) during which this node cannot be reassigned or moved by the optimizer after initial placement. Useful for protecting confirmed appointments from being rescheduled during re-optimization runs..</param>
        /// <param name="fixCost">The fixCost defines an abstract cost that arrises when this node is visited..</param>
        /// <param name="priority">The priority of the node. A higher priority leads to a higher cost if a node shows violations. As the Optimizer tries to reduce cost, a higher priority results in lower chance  of seeing violations on this node. However, if all nodes of an Optimization have a priority, the effect vanishes..</param>
        /// <param name="priorityFirst">The priorityFirst defines if we want a node to be the first node in a route-solution..</param>
        /// <param name="priorityLast">The priorityLast defines if we want a node to be the last node in a route-solution..</param>
        /// <param name="nodeColor">nodeColor.</param>
        /// <param name="minAutoFilterProtectedExecutions">The minimum number of optimization executions during which this node is protected from being removed by the AutoFilter. After this many executions, the AutoFilter may exclude this node if it consistently causes infeasibility. Set to 0 (default) to allow immediate filtering..</param>
        /// <param name="nodeDepot">nodeDepot.</param>
        /// <param name="routeDependentVisitDuration">If true, the actual visit duration at this node may be adjusted based on the resource&#39;s visitDurationEfficiency factor. A more efficient resource completes the task faster (down to minVisitDuration). If false, the visitDuration is fixed regardless of which resource visits. (default to false).</param>
        /// <param name="allowMoveToReduceFlexTime">If true, the optimizer is allowed to reposition this node within the route sequence specifically to reduce the resource&#39;s flex-time usage. Useful when minimizing flex-time consumption is a priority (e.g. contractual constraints on early/late start deviations). (default to false).</param>
        /// <param name="minVisitDuration">The minimum visit duration floor when routeDependentVisitDuration is enabled. Even if the resource&#39;s efficiency factor would reduce the visit time further, it cannot go below this threshold. Ensures a realistic minimum service time regardless of resource skill level..</param>
        /// <param name="jointVisitDuration">The jointVisitDuration. If nodes are situated closely to each other (defined via property &#39;JOpt.JointVisitDuration.maxRadiusMeter&#39;) a joint visit duration can be defined. For example, 3 nodes have a visit duration of 20 minutes each. The  joint visit duration for ALL nodes is set to be 10 minutes. Further, they are close enough to each other, that the joint visit duration logic can be triggered. The optimizer finds a solution in which all three nodes are visted in direct succession. The first node (of the three) needs to be visted for the original visit duration of 20 minutes. The seconds and third nodes only needs to be visited for 10 minutes..</param>
        /// <param name="returnStartDuration">The duration the resource must spend at this node before returning to the route start location (return-to-start behavior). Used in scenarios where a resource must revisit its depot mid-route (e.g. to reload supplies) and the node acts as a return-to-start trigger point..</param>
        /// <param name="isOptimizable">The boolean isOptimizable. Defines if a node is optimizable. This property will be auto-defined by the optimizer.. (default to true).</param>
        /// <param name="isOptional">The boolean isOptional. If a node is optional, the Optimizer can decide on its own, if the node is visited or not. Usually, this settings only makes sense in PND problems. (default to false).</param>
        /// <param name="isUnassigned">The boolean isUnassigned. Defines if a node was unassigned by the Optimizer. (default to false).</param>
        /// <param name="isIgnoreOnZeroDuration">If true, this node is excluded from routing whenever its visit duration is zero. A node with zero visit duration contributes no service time to a route, so visiting it provides no operational value. Enabling this flag allows the optimizer to skip such nodes automatically, reducing route length and travel cost. Defaults to false. (default to false).</param>
        /// <param name="isCausingIdleTimeCost">The boolean isCausingIdleTimeCost. By default, waiting at a node to open is creating idle time cost. As the Optimizer tries to reduce cost, it will also try to reschedule nodes if idle time cost is generated. In some problem setups (especially problems of the kind: Low node count, high WorkingHours availability) it may be desired to keep the position of the nodes, even though idle time is created. (default to true).</param>
        /// <param name="isWaitOnEarlyArrivalFirstNode">The boolean isWaitOnEarlyArrivalFirstNode. In case a Resources reaches the FIRST node of a route too early (before the start of the node&#39;s OpeningHours),\&quot;              + \&quot; the Resource can either start working direclty (true) or wait for the FIRST node to open (false, default). This setting only takes action if isWaitOnEarlyArrival is set to true. (default to false).</param>
        /// <param name="isWaitOnEarlyArrival">The boolean isWaitOnEarlyArrival. In case a Resources reaches a node too early (before the start of the node&#39;s OpeningHours), the Resource can either start working direclty (false) or wait for the node to open (true, default). (default to true).</param>
        /// <param name="isUnlocatedHubConnectionTime">False: If a resource in hub mode deals with this node, the earlist openingHours start of the node describes the earlist time the resource can start working on the node. TRUE:  If a resource in hub mode deals with this node, the connection time is added to the earlist openinghour start of the node, effectively acting as offset. This can be used for example, for shipping scnearios where a package takes 3 days. (default to false).</param>
        /// <param name="isOpeningHoursIncludesDuration">The boolean isOpeningHoursIncludesDuration. By default a node&#39;s openingHour defines the time-window  in which a task has to be fulfilled, meaning a Visitor has to arrive, work, and leave within that time-window. If isOpeningHoursIncludesDuration is set to false, the time-window only counts as arrival-window for the Resource. (default to true).</param>
        /// <param name="isWorkNode">DEPRECATED. Defines whether this node represents actual productive work. When false, the node is treated as a non-productive stop (e.g. a waypoint or break location). This field is deprecated and may be removed in a future version. (default to true).</param>
        /// <param name="isStayNode">The boolean isStayNode defines if a node is capable to be a stay node. A stay node overrides the route termination element of a route, and the route start element of the next route and is  used in the context of &#39;overnight-stays&#39;. (default to false).</param>
        /// <param name="isIgnoreOnZeroLoad">If true, this node is excluded from routing whenever its effective load exchange is zero at the time of evaluation. For supply nodes this means the node is skipped once its available supply has been fully consumed. For request nodes (including coupled split-nodes) this means the node is suppressed when the optimizer has assigned zero demand to it - for example, when a coupled partner already carries the full group total. Setting this flag reduces unnecessary route stops and lowers travel cost without affecting the coupling invariant, since a zero-load node contributes nothing to the delivery. Defaults to false. (default to false).</param>
        public Node(string id = default, string extraInfo = default, string locationId = default, string constraintAliasId = default, NodeType type = default, List<OpeningHours> openingHours = default, string visitDuration = default, List<Constraint> constraints = default, OfferedNode offeredNode = default, LoadDimension loadDimension = default, List<double> load = default, List<Qualification> qualifications = default, long lockdownTime = default, double fixCost = default, int priority = default, int priorityFirst = default, int priorityLast = default, NodeColor nodeColor = default, int minAutoFilterProtectedExecutions = default, INodeDepot nodeDepot = default, bool? routeDependentVisitDuration = false, bool? allowMoveToReduceFlexTime = false, string minVisitDuration = default, string jointVisitDuration = default, string returnStartDuration = default, bool? isOptimizable = true, bool? isOptional = false, bool? isUnassigned = false, bool? isIgnoreOnZeroDuration = false, bool? isCausingIdleTimeCost = true, bool? isWaitOnEarlyArrivalFirstNode = false, bool? isWaitOnEarlyArrival = true, bool? isUnlocatedHubConnectionTime = false, bool? isOpeningHoursIncludesDuration = true, bool? isWorkNode = true, bool? isStayNode = false, bool? isIgnoreOnZeroLoad = false)
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for Node and cannot be null");
            }
            this.Id = id;
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new ArgumentNullException("type is a required property for Node and cannot be null");
            }
            this.Type = type;
            // to ensure "openingHours" is required (not null)
            if (openingHours == null)
            {
                throw new ArgumentNullException("openingHours is a required property for Node and cannot be null");
            }
            this.OpeningHours = openingHours;
            // to ensure "visitDuration" is required (not null)
            if (visitDuration == null)
            {
                throw new ArgumentNullException("visitDuration is a required property for Node and cannot be null");
            }
            this.VisitDuration = visitDuration;
            this.ExtraInfo = extraInfo;
            this.LocationId = locationId;
            this.ConstraintAliasId = constraintAliasId;
            this.Constraints = constraints;
            this.OfferedNode = offeredNode;
            this.LoadDimension = loadDimension;
            this.Load = load;
            this.Qualifications = qualifications;
            this.LockdownTime = lockdownTime;
            this.FixCost = fixCost;
            this.Priority = priority;
            this.PriorityFirst = priorityFirst;
            this.PriorityLast = priorityLast;
            this.NodeColor = nodeColor;
            this.MinAutoFilterProtectedExecutions = minAutoFilterProtectedExecutions;
            this.NodeDepot = nodeDepot;
            // use default value if no "routeDependentVisitDuration" provided
            this.RouteDependentVisitDuration = routeDependentVisitDuration ?? false;
            // use default value if no "allowMoveToReduceFlexTime" provided
            this.AllowMoveToReduceFlexTime = allowMoveToReduceFlexTime ?? false;
            this.MinVisitDuration = minVisitDuration;
            this.JointVisitDuration = jointVisitDuration;
            this.ReturnStartDuration = returnStartDuration;
            // use default value if no "isOptimizable" provided
            this.IsOptimizable = isOptimizable ?? true;
            // use default value if no "isOptional" provided
            this.IsOptional = isOptional ?? false;
            // use default value if no "isUnassigned" provided
            this.IsUnassigned = isUnassigned ?? false;
            // use default value if no "isIgnoreOnZeroDuration" provided
            this.IsIgnoreOnZeroDuration = isIgnoreOnZeroDuration ?? false;
            // use default value if no "isCausingIdleTimeCost" provided
            this.IsCausingIdleTimeCost = isCausingIdleTimeCost ?? true;
            // use default value if no "isWaitOnEarlyArrivalFirstNode" provided
            this.IsWaitOnEarlyArrivalFirstNode = isWaitOnEarlyArrivalFirstNode ?? false;
            // use default value if no "isWaitOnEarlyArrival" provided
            this.IsWaitOnEarlyArrival = isWaitOnEarlyArrival ?? true;
            // use default value if no "isUnlocatedHubConnectionTime" provided
            this.IsUnlocatedHubConnectionTime = isUnlocatedHubConnectionTime ?? false;
            // use default value if no "isOpeningHoursIncludesDuration" provided
            this.IsOpeningHoursIncludesDuration = isOpeningHoursIncludesDuration ?? true;
            // use default value if no "isWorkNode" provided
            this.IsWorkNode = isWorkNode ?? true;
            // use default value if no "isStayNode" provided
            this.IsStayNode = isStayNode ?? false;
            // use default value if no "isIgnoreOnZeroLoad" provided
            this.IsIgnoreOnZeroLoad = isIgnoreOnZeroLoad ?? false;
        }

        /// <summary>
        /// The unique id of the node. It is not possible, to create mutliple elements (also Resources) with the same id.
        /// </summary>
        /// <value>The unique id of the node. It is not possible, to create mutliple elements (also Resources) with the same id.</value>
        /*
        <example>MySecondNode</example>
        */
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// A custom extra info string that is attached to the Node.
        /// </summary>
        /// <value>A custom extra info string that is attached to the Node.</value>
        /*
        <example>My custom extra info</example>
        */
        [DataMember(Name = "extraInfo", EmitDefaultValue = false)]
        public string ExtraInfo { get; set; }

        /// <summary>
        /// The location id can relate a node to the connection of another node. For example  the node &#39;MyFirstNode&#39; and &#39;MySecondNode&#39; have the same location. It is sufficient to provide the  connection data for &#39;MyFirstNode&#39; and set the LocationId of &#39;MySecondNode&#39; to be &#39;MyFirstNode&#39;
        /// </summary>
        /// <value>The location id can relate a node to the connection of another node. For example  the node &#39;MyFirstNode&#39; and &#39;MySecondNode&#39; have the same location. It is sufficient to provide the  connection data for &#39;MyFirstNode&#39; and set the LocationId of &#39;MySecondNode&#39; to be &#39;MyFirstNode&#39;</value>
        /*
        <example>MyFirstNode</example>
        */
        [DataMember(Name = "locationId", EmitDefaultValue = false)]
        public string LocationId { get; set; }

        /// <summary>
        /// The constraintAliasId. If set is used during constraint assessment instead of using the normal id.
        /// </summary>
        /// <value>The constraintAliasId. If set is used during constraint assessment instead of using the normal id.</value>
        /*
        <example>MyNodeXXX</example>
        */
        [DataMember(Name = "constraintAliasId", EmitDefaultValue = false)]
        public string ConstraintAliasId { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public NodeType Type { get; set; }

        /// <summary>
        /// The list of non-overlapping openingHours of the nodes.
        /// </summary>
        /// <value>The list of non-overlapping openingHours of the nodes.</value>
        [DataMember(Name = "openingHours", IsRequired = true, EmitDefaultValue = true)]
        public List<OpeningHours> OpeningHours { get; set; }

        /// <summary>
        /// The visitDuration defines how long a visitor needs to stay at the node.
        /// </summary>
        /// <value>The visitDuration defines how long a visitor needs to stay at the node.</value>
        /*
        <example>PT60M</example>
        */
        [DataMember(Name = "visitDuration", IsRequired = true, EmitDefaultValue = true)]
        public string VisitDuration { get; set; }

        /// <summary>
        /// The constraints of this node
        /// </summary>
        /// <value>The constraints of this node</value>
        [DataMember(Name = "constraints", EmitDefaultValue = false)]
        public List<Constraint> Constraints { get; set; }

        /// <summary>
        /// Gets or Sets OfferedNode
        /// </summary>
        [DataMember(Name = "offeredNode", EmitDefaultValue = false)]
        public OfferedNode OfferedNode { get; set; }

        /// <summary>
        /// Gets or Sets LoadDimension
        /// </summary>
        [DataMember(Name = "loadDimension", EmitDefaultValue = false)]
        public LoadDimension LoadDimension { get; set; }

        /// <summary>
        /// The multi-dimensional load vector for this node in pickup-and-delivery scenarios. Each element corresponds to a capacity dimension on the resource (e.g. weight, volume, pallet count). Positive values typically represent demand (delivery), while the interpretation depends on the loadDimension configuration.
        /// </summary>
        /// <value>The multi-dimensional load vector for this node in pickup-and-delivery scenarios. Each element corresponds to a capacity dimension on the resource (e.g. weight, volume, pallet count). Positive values typically represent demand (delivery), while the interpretation depends on the loadDimension configuration.</value>
        [DataMember(Name = "load", EmitDefaultValue = false)]
        public List<double> Load { get; set; }

        /// <summary>
        /// The qualifications of the node.
        /// </summary>
        /// <value>The qualifications of the node.</value>
        [DataMember(Name = "qualifications", EmitDefaultValue = false)]
        public List<Qualification> Qualifications { get; set; }

        /// <summary>
        /// An optional lockdown time (in milliseconds) during which this node cannot be reassigned or moved by the optimizer after initial placement. Useful for protecting confirmed appointments from being rescheduled during re-optimization runs.
        /// </summary>
        /// <value>An optional lockdown time (in milliseconds) during which this node cannot be reassigned or moved by the optimizer after initial placement. Useful for protecting confirmed appointments from being rescheduled during re-optimization runs.</value>
        [DataMember(Name = "lockdownTime", EmitDefaultValue = false)]
        public long LockdownTime { get; set; }

        /// <summary>
        /// The fixCost defines an abstract cost that arrises when this node is visited.
        /// </summary>
        /// <value>The fixCost defines an abstract cost that arrises when this node is visited.</value>
        [DataMember(Name = "fixCost", EmitDefaultValue = false)]
        public double FixCost { get; set; }

        /// <summary>
        /// The priority of the node. A higher priority leads to a higher cost if a node shows violations. As the Optimizer tries to reduce cost, a higher priority results in lower chance  of seeing violations on this node. However, if all nodes of an Optimization have a priority, the effect vanishes.
        /// </summary>
        /// <value>The priority of the node. A higher priority leads to a higher cost if a node shows violations. As the Optimizer tries to reduce cost, a higher priority results in lower chance  of seeing violations on this node. However, if all nodes of an Optimization have a priority, the effect vanishes.</value>
        [DataMember(Name = "priority", EmitDefaultValue = false)]
        public int Priority { get; set; }

        /// <summary>
        /// The priorityFirst defines if we want a node to be the first node in a route-solution.
        /// </summary>
        /// <value>The priorityFirst defines if we want a node to be the first node in a route-solution.</value>
        [DataMember(Name = "priorityFirst", EmitDefaultValue = false)]
        public int PriorityFirst { get; set; }

        /// <summary>
        /// The priorityLast defines if we want a node to be the last node in a route-solution.
        /// </summary>
        /// <value>The priorityLast defines if we want a node to be the last node in a route-solution.</value>
        [DataMember(Name = "priorityLast", EmitDefaultValue = false)]
        public int PriorityLast { get; set; }

        /// <summary>
        /// Gets or Sets NodeColor
        /// </summary>
        [DataMember(Name = "nodeColor", EmitDefaultValue = false)]
        public NodeColor NodeColor { get; set; }

        /// <summary>
        /// The minimum number of optimization executions during which this node is protected from being removed by the AutoFilter. After this many executions, the AutoFilter may exclude this node if it consistently causes infeasibility. Set to 0 (default) to allow immediate filtering.
        /// </summary>
        /// <value>The minimum number of optimization executions during which this node is protected from being removed by the AutoFilter. After this many executions, the AutoFilter may exclude this node if it consistently causes infeasibility. Set to 0 (default) to allow immediate filtering.</value>
        [DataMember(Name = "minAutoFilterProtectedExecutions", EmitDefaultValue = false)]
        public int MinAutoFilterProtectedExecutions { get; set; }

        /// <summary>
        /// Gets or Sets NodeDepot
        /// </summary>
        [DataMember(Name = "nodeDepot", EmitDefaultValue = false)]
        public INodeDepot NodeDepot { get; set; }

        /// <summary>
        /// If true, the actual visit duration at this node may be adjusted based on the resource&#39;s visitDurationEfficiency factor. A more efficient resource completes the task faster (down to minVisitDuration). If false, the visitDuration is fixed regardless of which resource visits.
        /// </summary>
        /// <value>If true, the actual visit duration at this node may be adjusted based on the resource&#39;s visitDurationEfficiency factor. A more efficient resource completes the task faster (down to minVisitDuration). If false, the visitDuration is fixed regardless of which resource visits.</value>
        [DataMember(Name = "routeDependentVisitDuration", EmitDefaultValue = true)]
        public bool? RouteDependentVisitDuration { get; set; }

        /// <summary>
        /// If true, the optimizer is allowed to reposition this node within the route sequence specifically to reduce the resource&#39;s flex-time usage. Useful when minimizing flex-time consumption is a priority (e.g. contractual constraints on early/late start deviations).
        /// </summary>
        /// <value>If true, the optimizer is allowed to reposition this node within the route sequence specifically to reduce the resource&#39;s flex-time usage. Useful when minimizing flex-time consumption is a priority (e.g. contractual constraints on early/late start deviations).</value>
        [DataMember(Name = "allowMoveToReduceFlexTime", EmitDefaultValue = true)]
        public bool? AllowMoveToReduceFlexTime { get; set; }

        /// <summary>
        /// The minimum visit duration floor when routeDependentVisitDuration is enabled. Even if the resource&#39;s efficiency factor would reduce the visit time further, it cannot go below this threshold. Ensures a realistic minimum service time regardless of resource skill level.
        /// </summary>
        /// <value>The minimum visit duration floor when routeDependentVisitDuration is enabled. Even if the resource&#39;s efficiency factor would reduce the visit time further, it cannot go below this threshold. Ensures a realistic minimum service time regardless of resource skill level.</value>
        /*
        <example>PT10M</example>
        */
        [DataMember(Name = "minVisitDuration", EmitDefaultValue = false)]
        public string MinVisitDuration { get; set; }

        /// <summary>
        /// The jointVisitDuration. If nodes are situated closely to each other (defined via property &#39;JOpt.JointVisitDuration.maxRadiusMeter&#39;) a joint visit duration can be defined. For example, 3 nodes have a visit duration of 20 minutes each. The  joint visit duration for ALL nodes is set to be 10 minutes. Further, they are close enough to each other, that the joint visit duration logic can be triggered. The optimizer finds a solution in which all three nodes are visted in direct succession. The first node (of the three) needs to be visted for the original visit duration of 20 minutes. The seconds and third nodes only needs to be visited for 10 minutes.
        /// </summary>
        /// <value>The jointVisitDuration. If nodes are situated closely to each other (defined via property &#39;JOpt.JointVisitDuration.maxRadiusMeter&#39;) a joint visit duration can be defined. For example, 3 nodes have a visit duration of 20 minutes each. The  joint visit duration for ALL nodes is set to be 10 minutes. Further, they are close enough to each other, that the joint visit duration logic can be triggered. The optimizer finds a solution in which all three nodes are visted in direct succession. The first node (of the three) needs to be visted for the original visit duration of 20 minutes. The seconds and third nodes only needs to be visited for 10 minutes.</value>
        /*
        <example>PT60M</example>
        */
        [DataMember(Name = "jointVisitDuration", EmitDefaultValue = false)]
        public string JointVisitDuration { get; set; }

        /// <summary>
        /// The duration the resource must spend at this node before returning to the route start location (return-to-start behavior). Used in scenarios where a resource must revisit its depot mid-route (e.g. to reload supplies) and the node acts as a return-to-start trigger point.
        /// </summary>
        /// <value>The duration the resource must spend at this node before returning to the route start location (return-to-start behavior). Used in scenarios where a resource must revisit its depot mid-route (e.g. to reload supplies) and the node acts as a return-to-start trigger point.</value>
        [DataMember(Name = "returnStartDuration", EmitDefaultValue = false)]
        public string ReturnStartDuration { get; set; }

        /// <summary>
        /// The boolean isOptimizable. Defines if a node is optimizable. This property will be auto-defined by the optimizer..
        /// </summary>
        /// <value>The boolean isOptimizable. Defines if a node is optimizable. This property will be auto-defined by the optimizer..</value>
        [DataMember(Name = "isOptimizable", EmitDefaultValue = true)]
        public bool? IsOptimizable { get; set; }

        /// <summary>
        /// The boolean isOptional. If a node is optional, the Optimizer can decide on its own, if the node is visited or not. Usually, this settings only makes sense in PND problems.
        /// </summary>
        /// <value>The boolean isOptional. If a node is optional, the Optimizer can decide on its own, if the node is visited or not. Usually, this settings only makes sense in PND problems.</value>
        [DataMember(Name = "isOptional", EmitDefaultValue = true)]
        public bool? IsOptional { get; set; }

        /// <summary>
        /// The boolean isUnassigned. Defines if a node was unassigned by the Optimizer.
        /// </summary>
        /// <value>The boolean isUnassigned. Defines if a node was unassigned by the Optimizer.</value>
        [DataMember(Name = "isUnassigned", EmitDefaultValue = true)]
        public bool? IsUnassigned { get; set; }

        /// <summary>
        /// If true, this node is excluded from routing whenever its visit duration is zero. A node with zero visit duration contributes no service time to a route, so visiting it provides no operational value. Enabling this flag allows the optimizer to skip such nodes automatically, reducing route length and travel cost. Defaults to false.
        /// </summary>
        /// <value>If true, this node is excluded from routing whenever its visit duration is zero. A node with zero visit duration contributes no service time to a route, so visiting it provides no operational value. Enabling this flag allows the optimizer to skip such nodes automatically, reducing route length and travel cost. Defaults to false.</value>
        [DataMember(Name = "isIgnoreOnZeroDuration", EmitDefaultValue = true)]
        public bool? IsIgnoreOnZeroDuration { get; set; }

        /// <summary>
        /// The boolean isCausingIdleTimeCost. By default, waiting at a node to open is creating idle time cost. As the Optimizer tries to reduce cost, it will also try to reschedule nodes if idle time cost is generated. In some problem setups (especially problems of the kind: Low node count, high WorkingHours availability) it may be desired to keep the position of the nodes, even though idle time is created.
        /// </summary>
        /// <value>The boolean isCausingIdleTimeCost. By default, waiting at a node to open is creating idle time cost. As the Optimizer tries to reduce cost, it will also try to reschedule nodes if idle time cost is generated. In some problem setups (especially problems of the kind: Low node count, high WorkingHours availability) it may be desired to keep the position of the nodes, even though idle time is created.</value>
        [DataMember(Name = "isCausingIdleTimeCost", EmitDefaultValue = true)]
        public bool? IsCausingIdleTimeCost { get; set; }

        /// <summary>
        /// The boolean isWaitOnEarlyArrivalFirstNode. In case a Resources reaches the FIRST node of a route too early (before the start of the node&#39;s OpeningHours),\&quot;              + \&quot; the Resource can either start working direclty (true) or wait for the FIRST node to open (false, default). This setting only takes action if isWaitOnEarlyArrival is set to true.
        /// </summary>
        /// <value>The boolean isWaitOnEarlyArrivalFirstNode. In case a Resources reaches the FIRST node of a route too early (before the start of the node&#39;s OpeningHours),\&quot;              + \&quot; the Resource can either start working direclty (true) or wait for the FIRST node to open (false, default). This setting only takes action if isWaitOnEarlyArrival is set to true.</value>
        [DataMember(Name = "isWaitOnEarlyArrivalFirstNode", EmitDefaultValue = true)]
        public bool? IsWaitOnEarlyArrivalFirstNode { get; set; }

        /// <summary>
        /// The boolean isWaitOnEarlyArrival. In case a Resources reaches a node too early (before the start of the node&#39;s OpeningHours), the Resource can either start working direclty (false) or wait for the node to open (true, default).
        /// </summary>
        /// <value>The boolean isWaitOnEarlyArrival. In case a Resources reaches a node too early (before the start of the node&#39;s OpeningHours), the Resource can either start working direclty (false) or wait for the node to open (true, default).</value>
        [DataMember(Name = "isWaitOnEarlyArrival", EmitDefaultValue = true)]
        public bool? IsWaitOnEarlyArrival { get; set; }

        /// <summary>
        /// False: If a resource in hub mode deals with this node, the earlist openingHours start of the node describes the earlist time the resource can start working on the node. TRUE:  If a resource in hub mode deals with this node, the connection time is added to the earlist openinghour start of the node, effectively acting as offset. This can be used for example, for shipping scnearios where a package takes 3 days.
        /// </summary>
        /// <value>False: If a resource in hub mode deals with this node, the earlist openingHours start of the node describes the earlist time the resource can start working on the node. TRUE:  If a resource in hub mode deals with this node, the connection time is added to the earlist openinghour start of the node, effectively acting as offset. This can be used for example, for shipping scnearios where a package takes 3 days.</value>
        [DataMember(Name = "isUnlocatedHubConnectionTime", EmitDefaultValue = true)]
        public bool? IsUnlocatedHubConnectionTime { get; set; }

        /// <summary>
        /// The boolean isOpeningHoursIncludesDuration. By default a node&#39;s openingHour defines the time-window  in which a task has to be fulfilled, meaning a Visitor has to arrive, work, and leave within that time-window. If isOpeningHoursIncludesDuration is set to false, the time-window only counts as arrival-window for the Resource.
        /// </summary>
        /// <value>The boolean isOpeningHoursIncludesDuration. By default a node&#39;s openingHour defines the time-window  in which a task has to be fulfilled, meaning a Visitor has to arrive, work, and leave within that time-window. If isOpeningHoursIncludesDuration is set to false, the time-window only counts as arrival-window for the Resource.</value>
        [DataMember(Name = "isOpeningHoursIncludesDuration", EmitDefaultValue = true)]
        public bool? IsOpeningHoursIncludesDuration { get; set; }

        /// <summary>
        /// DEPRECATED. Defines whether this node represents actual productive work. When false, the node is treated as a non-productive stop (e.g. a waypoint or break location). This field is deprecated and may be removed in a future version.
        /// </summary>
        /// <value>DEPRECATED. Defines whether this node represents actual productive work. When false, the node is treated as a non-productive stop (e.g. a waypoint or break location). This field is deprecated and may be removed in a future version.</value>
        [DataMember(Name = "isWorkNode", EmitDefaultValue = true)]
        public bool? IsWorkNode { get; set; }

        /// <summary>
        /// The boolean isStayNode defines if a node is capable to be a stay node. A stay node overrides the route termination element of a route, and the route start element of the next route and is  used in the context of &#39;overnight-stays&#39;.
        /// </summary>
        /// <value>The boolean isStayNode defines if a node is capable to be a stay node. A stay node overrides the route termination element of a route, and the route start element of the next route and is  used in the context of &#39;overnight-stays&#39;.</value>
        [DataMember(Name = "isStayNode", EmitDefaultValue = true)]
        public bool? IsStayNode { get; set; }

        /// <summary>
        /// If true, this node is excluded from routing whenever its effective load exchange is zero at the time of evaluation. For supply nodes this means the node is skipped once its available supply has been fully consumed. For request nodes (including coupled split-nodes) this means the node is suppressed when the optimizer has assigned zero demand to it - for example, when a coupled partner already carries the full group total. Setting this flag reduces unnecessary route stops and lowers travel cost without affecting the coupling invariant, since a zero-load node contributes nothing to the delivery. Defaults to false.
        /// </summary>
        /// <value>If true, this node is excluded from routing whenever its effective load exchange is zero at the time of evaluation. For supply nodes this means the node is skipped once its available supply has been fully consumed. For request nodes (including coupled split-nodes) this means the node is suppressed when the optimizer has assigned zero demand to it - for example, when a coupled partner already carries the full group total. Setting this flag reduces unnecessary route stops and lowers travel cost without affecting the coupling invariant, since a zero-load node contributes nothing to the delivery. Defaults to false.</value>
        [DataMember(Name = "isIgnoreOnZeroLoad", EmitDefaultValue = true)]
        public bool? IsIgnoreOnZeroLoad { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Node {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ExtraInfo: ").Append(ExtraInfo).Append("\n");
            sb.Append("  LocationId: ").Append(LocationId).Append("\n");
            sb.Append("  ConstraintAliasId: ").Append(ConstraintAliasId).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  OpeningHours: ").Append(OpeningHours).Append("\n");
            sb.Append("  VisitDuration: ").Append(VisitDuration).Append("\n");
            sb.Append("  Constraints: ").Append(Constraints).Append("\n");
            sb.Append("  OfferedNode: ").Append(OfferedNode).Append("\n");
            sb.Append("  LoadDimension: ").Append(LoadDimension).Append("\n");
            sb.Append("  Load: ").Append(Load).Append("\n");
            sb.Append("  Qualifications: ").Append(Qualifications).Append("\n");
            sb.Append("  LockdownTime: ").Append(LockdownTime).Append("\n");
            sb.Append("  FixCost: ").Append(FixCost).Append("\n");
            sb.Append("  Priority: ").Append(Priority).Append("\n");
            sb.Append("  PriorityFirst: ").Append(PriorityFirst).Append("\n");
            sb.Append("  PriorityLast: ").Append(PriorityLast).Append("\n");
            sb.Append("  NodeColor: ").Append(NodeColor).Append("\n");
            sb.Append("  MinAutoFilterProtectedExecutions: ").Append(MinAutoFilterProtectedExecutions).Append("\n");
            sb.Append("  NodeDepot: ").Append(NodeDepot).Append("\n");
            sb.Append("  RouteDependentVisitDuration: ").Append(RouteDependentVisitDuration).Append("\n");
            sb.Append("  AllowMoveToReduceFlexTime: ").Append(AllowMoveToReduceFlexTime).Append("\n");
            sb.Append("  MinVisitDuration: ").Append(MinVisitDuration).Append("\n");
            sb.Append("  JointVisitDuration: ").Append(JointVisitDuration).Append("\n");
            sb.Append("  ReturnStartDuration: ").Append(ReturnStartDuration).Append("\n");
            sb.Append("  IsOptimizable: ").Append(IsOptimizable).Append("\n");
            sb.Append("  IsOptional: ").Append(IsOptional).Append("\n");
            sb.Append("  IsUnassigned: ").Append(IsUnassigned).Append("\n");
            sb.Append("  IsIgnoreOnZeroDuration: ").Append(IsIgnoreOnZeroDuration).Append("\n");
            sb.Append("  IsCausingIdleTimeCost: ").Append(IsCausingIdleTimeCost).Append("\n");
            sb.Append("  IsWaitOnEarlyArrivalFirstNode: ").Append(IsWaitOnEarlyArrivalFirstNode).Append("\n");
            sb.Append("  IsWaitOnEarlyArrival: ").Append(IsWaitOnEarlyArrival).Append("\n");
            sb.Append("  IsUnlocatedHubConnectionTime: ").Append(IsUnlocatedHubConnectionTime).Append("\n");
            sb.Append("  IsOpeningHoursIncludesDuration: ").Append(IsOpeningHoursIncludesDuration).Append("\n");
            sb.Append("  IsWorkNode: ").Append(IsWorkNode).Append("\n");
            sb.Append("  IsStayNode: ").Append(IsStayNode).Append("\n");
            sb.Append("  IsIgnoreOnZeroLoad: ").Append(IsIgnoreOnZeroLoad).Append("\n");
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
