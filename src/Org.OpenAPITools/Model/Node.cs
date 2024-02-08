/*
 * DNA Evolutions - JOpt.TourOptimizer
 *
 * This is DNA's JOpt.TourOptimizer service. A RESTful Spring Boot application using springdoc-openapi and OpenAPI 3. JOpt.TourOpptimizer is a service that delivers route optimization and automatic scheduling features to be easily integrated into any third-party application. JOpt.TourOpptimizer encapsulates all necessary optimization functionality and provides a comprehensive REST API that offers a domain-specific optimization interface for the transportation industry. The service is stateless and does not come with graphical user interfaces, map depiction or any databases. These extensions and adjustments are supposed to be introduced by the consumer of the service while integrating it into his/her own application. The service will allow for many suitable adjustments and user-specific settings to adjust the behaviour and optimization goals (e.g. minimizing distance, maximizing resource utilization, etc.) through a comprehensive set of functions. This will enable you to gain control of the complete optimization processes.This service is based on JOpt (null)
 *
 * The version of the OpenAPI document: 1.2.6-SNAPSHOT
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
    /// The list of nodes
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
        /// <param name="load">The load.</param>
        /// <param name="qualifications">The qualifications of the node..</param>
        /// <param name="lockdownTime">The lockdownTime.</param>
        /// <param name="fixCost">The fixCost defines an abstract cost that arrises when this node is visited..</param>
        /// <param name="priority">The priority of the node. A higher priority leads to a higher cost if a node shows violations. As the Optimizer tries to reduce cost, a higher priority results in lower chance  of seeing violations on this node. However, if all nodes of an Optimization have a priority, the effect vanishes..</param>
        /// <param name="priorityFirst">The priorityFirst defines if we want a node to be the first node in a route-solution..</param>
        /// <param name="priorityLast">The priorityLast defines if we want a node to be the last node in a route-solution..</param>
        /// <param name="nodeColor">nodeColor.</param>
        /// <param name="minAutoFilterProtectedExecutions">The minAutoFilterProtectedExecutions.</param>
        /// <param name="nodeDepot">nodeDepot.</param>
        /// <param name="routeDependentVisitDuration">The routeDependentVisitDuration (default to false).</param>
        /// <param name="allowMoveToReduceFlexTime">The allowMoveToReduceFlexTime (default to false).</param>
        /// <param name="minVisitDuration">The minVisitDuration.</param>
        /// <param name="jointVisitDuration">The jointVisitDuration. If nodes are situated closely to each other (defined via property &#39;JOpt.JointVisitDuration.maxRadiusMeter&#39;) a joint visit duration can be defined. For example, 3 nodes have a visit duration of 20 minutes each. The  joint visit duration for ALL nodes is set to be 10 minutes. Further, they are close enough to each other, that the joint visit duration logic can be triggered. The optimizer finds a solution in which all three nodes are visted in direct succession. The first node (of the three) needs to be visted for the original visit duration of 20 minutes. The seconds and third nodes only needs to be visited for 10 minutes..</param>
        /// <param name="returnStartDuration">The returnStartDuration.</param>
        /// <param name="isOptimizable">The boolean isOptimizable. Defines if a node is optimizable. This property will be auto-defined by the optimizer.. (default to true).</param>
        /// <param name="isOptional">The boolean isOptional. If a node is optional, the Optimizer can decide on its own, if the node is visited or not. Usually, this settings only makes sense in PND problems. (default to false).</param>
        /// <param name="isUnassigned">The boolean isUnassigned. Defines if a node was unassigned by the Optimizer. (default to false).</param>
        /// <param name="isStayNode">The boolean isStayNode defines if a node is capable to be a stay node. A stay node overrides the route termination element of a route, and the route start element of the next route and is  used in the context of &#39;overnight-stays&#39;. (default to false).</param>
        /// <param name="isWorkNode">The isWorkNode (default to true).</param>
        /// <param name="isWaitOnEarlyArrival">The boolean isWaitOnEarlyArrival. In case a Resources reaches a node too early (before the start of the node&#39;s OpeningHours), the Resource can either start working direclty (false) or wait for the node to open (true, default). (default to true).</param>
        /// <param name="isOpeningHoursIncludesDuration">The boolean isOpeningHoursIncludesDuration. By default a node&#39;s openingHour defines the time-window  in which a task has to be fulfilled, meaning a Visitor has to arrive, work, and leave within that time-window. If isOpeningHoursIncludesDuration is set to false, the time-window only counts as arrival-window for the Resource. (default to true).</param>
        /// <param name="isCausingIdleTimeCost">The boolean isCausingIdleTimeCost. By default, waiting at a node to open is creating idle time cost. As the Optimizer tries to reduce cost, it will also try to reschedule nodes if idle time cost is generated. In some problem setups (especially problems of the kind: Low node count, high WorkingHours availability) it may be desired to keep the position of the nodes, even though idle time is created. (default to true).</param>
        /// <param name="isWaitOnEarlyArrivalFirstNode">The boolean isWaitOnEarlyArrivalFirstNode. In case a Resources reaches the FIRST node of a route too early (before the start of the node&#39;s OpeningHours),\&quot;              + \&quot; the Resource can either start working direclty (true) or wait for the FIRST node to open (false, default). This setting only takes action if isWaitOnEarlyArrival is set to true. (default to false).</param>
        public Node(string id = default(string), string extraInfo = default(string), string locationId = default(string), string constraintAliasId = default(string), NodeType type = default(NodeType), List<OpeningHours> openingHours = default(List<OpeningHours>), string visitDuration = default(string), List<Constraint> constraints = default(List<Constraint>), OfferedNode offeredNode = default(OfferedNode), LoadDimension loadDimension = default(LoadDimension), List<double> load = default(List<double>), List<Qualification> qualifications = default(List<Qualification>), long lockdownTime = default(long), double fixCost = default(double), int priority = default(int), int priorityFirst = default(int), int priorityLast = default(int), NodeColor nodeColor = default(NodeColor), int minAutoFilterProtectedExecutions = default(int), INodeDepot nodeDepot = default(INodeDepot), bool? routeDependentVisitDuration = false, bool? allowMoveToReduceFlexTime = false, string minVisitDuration = default(string), string jointVisitDuration = default(string), string returnStartDuration = default(string), bool? isOptimizable = true, bool? isOptional = false, bool? isUnassigned = false, bool? isStayNode = false, bool? isWorkNode = true, bool? isWaitOnEarlyArrival = true, bool? isOpeningHoursIncludesDuration = true, bool? isCausingIdleTimeCost = true, bool? isWaitOnEarlyArrivalFirstNode = false)
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
            // use default value if no "isStayNode" provided
            this.IsStayNode = isStayNode ?? false;
            // use default value if no "isWorkNode" provided
            this.IsWorkNode = isWorkNode ?? true;
            // use default value if no "isWaitOnEarlyArrival" provided
            this.IsWaitOnEarlyArrival = isWaitOnEarlyArrival ?? true;
            // use default value if no "isOpeningHoursIncludesDuration" provided
            this.IsOpeningHoursIncludesDuration = isOpeningHoursIncludesDuration ?? true;
            // use default value if no "isCausingIdleTimeCost" provided
            this.IsCausingIdleTimeCost = isCausingIdleTimeCost ?? true;
            // use default value if no "isWaitOnEarlyArrivalFirstNode" provided
            this.IsWaitOnEarlyArrivalFirstNode = isWaitOnEarlyArrivalFirstNode ?? false;
        }

        /// <summary>
        /// The unique id of the node. It is not possible, to create mutliple elements (also Resources) with the same id.
        /// </summary>
        /// <value>The unique id of the node. It is not possible, to create mutliple elements (also Resources) with the same id.</value>
        /// <example>MySecondNode</example>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// A custom extra info string that is attached to the Node.
        /// </summary>
        /// <value>A custom extra info string that is attached to the Node.</value>
        /// <example>My custom extra info</example>
        [DataMember(Name = "extraInfo", EmitDefaultValue = false)]
        public string ExtraInfo { get; set; }

        /// <summary>
        /// The location id can relate a node to the connection of another node. For example  the node &#39;MyFirstNode&#39; and &#39;MySecondNode&#39; have the same location. It is sufficient to provide the  connection data for &#39;MyFirstNode&#39; and set the LocationId of &#39;MySecondNode&#39; to be &#39;MyFirstNode&#39;
        /// </summary>
        /// <value>The location id can relate a node to the connection of another node. For example  the node &#39;MyFirstNode&#39; and &#39;MySecondNode&#39; have the same location. It is sufficient to provide the  connection data for &#39;MyFirstNode&#39; and set the LocationId of &#39;MySecondNode&#39; to be &#39;MyFirstNode&#39;</value>
        /// <example>MyFirstNode</example>
        [DataMember(Name = "locationId", EmitDefaultValue = false)]
        public string LocationId { get; set; }

        /// <summary>
        /// The constraintAliasId. If set is used during constraint assessment instead of using the normal id.
        /// </summary>
        /// <value>The constraintAliasId. If set is used during constraint assessment instead of using the normal id.</value>
        /// <example>MyNode</example>
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
        /// <example>PT60M</example>
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
        /// The load
        /// </summary>
        /// <value>The load</value>
        [DataMember(Name = "load", EmitDefaultValue = false)]
        public List<double> Load { get; set; }

        /// <summary>
        /// The qualifications of the node.
        /// </summary>
        /// <value>The qualifications of the node.</value>
        [DataMember(Name = "qualifications", EmitDefaultValue = false)]
        public List<Qualification> Qualifications { get; set; }

        /// <summary>
        /// The lockdownTime
        /// </summary>
        /// <value>The lockdownTime</value>
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
        /// The minAutoFilterProtectedExecutions
        /// </summary>
        /// <value>The minAutoFilterProtectedExecutions</value>
        [DataMember(Name = "minAutoFilterProtectedExecutions", EmitDefaultValue = false)]
        public int MinAutoFilterProtectedExecutions { get; set; }

        /// <summary>
        /// Gets or Sets NodeDepot
        /// </summary>
        [DataMember(Name = "nodeDepot", EmitDefaultValue = false)]
        public INodeDepot NodeDepot { get; set; }

        /// <summary>
        /// The routeDependentVisitDuration
        /// </summary>
        /// <value>The routeDependentVisitDuration</value>
        [DataMember(Name = "routeDependentVisitDuration", EmitDefaultValue = true)]
        public bool? RouteDependentVisitDuration { get; set; }

        /// <summary>
        /// The allowMoveToReduceFlexTime
        /// </summary>
        /// <value>The allowMoveToReduceFlexTime</value>
        [DataMember(Name = "allowMoveToReduceFlexTime", EmitDefaultValue = true)]
        public bool? AllowMoveToReduceFlexTime { get; set; }

        /// <summary>
        /// The minVisitDuration
        /// </summary>
        /// <value>The minVisitDuration</value>
        /// <example>PT10M</example>
        [DataMember(Name = "minVisitDuration", EmitDefaultValue = false)]
        public string MinVisitDuration { get; set; }

        /// <summary>
        /// The jointVisitDuration. If nodes are situated closely to each other (defined via property &#39;JOpt.JointVisitDuration.maxRadiusMeter&#39;) a joint visit duration can be defined. For example, 3 nodes have a visit duration of 20 minutes each. The  joint visit duration for ALL nodes is set to be 10 minutes. Further, they are close enough to each other, that the joint visit duration logic can be triggered. The optimizer finds a solution in which all three nodes are visted in direct succession. The first node (of the three) needs to be visted for the original visit duration of 20 minutes. The seconds and third nodes only needs to be visited for 10 minutes.
        /// </summary>
        /// <value>The jointVisitDuration. If nodes are situated closely to each other (defined via property &#39;JOpt.JointVisitDuration.maxRadiusMeter&#39;) a joint visit duration can be defined. For example, 3 nodes have a visit duration of 20 minutes each. The  joint visit duration for ALL nodes is set to be 10 minutes. Further, they are close enough to each other, that the joint visit duration logic can be triggered. The optimizer finds a solution in which all three nodes are visted in direct succession. The first node (of the three) needs to be visted for the original visit duration of 20 minutes. The seconds and third nodes only needs to be visited for 10 minutes.</value>
        /// <example>PT60M</example>
        [DataMember(Name = "jointVisitDuration", EmitDefaultValue = false)]
        public string JointVisitDuration { get; set; }

        /// <summary>
        /// The returnStartDuration
        /// </summary>
        /// <value>The returnStartDuration</value>
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
        /// The boolean isStayNode defines if a node is capable to be a stay node. A stay node overrides the route termination element of a route, and the route start element of the next route and is  used in the context of &#39;overnight-stays&#39;.
        /// </summary>
        /// <value>The boolean isStayNode defines if a node is capable to be a stay node. A stay node overrides the route termination element of a route, and the route start element of the next route and is  used in the context of &#39;overnight-stays&#39;.</value>
        [DataMember(Name = "isStayNode", EmitDefaultValue = true)]
        public bool? IsStayNode { get; set; }

        /// <summary>
        /// The isWorkNode
        /// </summary>
        /// <value>The isWorkNode</value>
        [DataMember(Name = "isWorkNode", EmitDefaultValue = true)]
        public bool? IsWorkNode { get; set; }

        /// <summary>
        /// The boolean isWaitOnEarlyArrival. In case a Resources reaches a node too early (before the start of the node&#39;s OpeningHours), the Resource can either start working direclty (false) or wait for the node to open (true, default).
        /// </summary>
        /// <value>The boolean isWaitOnEarlyArrival. In case a Resources reaches a node too early (before the start of the node&#39;s OpeningHours), the Resource can either start working direclty (false) or wait for the node to open (true, default).</value>
        [DataMember(Name = "isWaitOnEarlyArrival", EmitDefaultValue = true)]
        public bool? IsWaitOnEarlyArrival { get; set; }

        /// <summary>
        /// The boolean isOpeningHoursIncludesDuration. By default a node&#39;s openingHour defines the time-window  in which a task has to be fulfilled, meaning a Visitor has to arrive, work, and leave within that time-window. If isOpeningHoursIncludesDuration is set to false, the time-window only counts as arrival-window for the Resource.
        /// </summary>
        /// <value>The boolean isOpeningHoursIncludesDuration. By default a node&#39;s openingHour defines the time-window  in which a task has to be fulfilled, meaning a Visitor has to arrive, work, and leave within that time-window. If isOpeningHoursIncludesDuration is set to false, the time-window only counts as arrival-window for the Resource.</value>
        [DataMember(Name = "isOpeningHoursIncludesDuration", EmitDefaultValue = true)]
        public bool? IsOpeningHoursIncludesDuration { get; set; }

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
            sb.Append("  IsStayNode: ").Append(IsStayNode).Append("\n");
            sb.Append("  IsWorkNode: ").Append(IsWorkNode).Append("\n");
            sb.Append("  IsWaitOnEarlyArrival: ").Append(IsWaitOnEarlyArrival).Append("\n");
            sb.Append("  IsOpeningHoursIncludesDuration: ").Append(IsOpeningHoursIncludesDuration).Append("\n");
            sb.Append("  IsCausingIdleTimeCost: ").Append(IsCausingIdleTimeCost).Append("\n");
            sb.Append("  IsWaitOnEarlyArrivalFirstNode: ").Append(IsWaitOnEarlyArrivalFirstNode).Append("\n");
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
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
