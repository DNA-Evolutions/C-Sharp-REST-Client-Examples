/*
 * DNA Evolutions - JOpt.TourOptimizer
 *
 * This is DNA's JOpt.TourOptimizer service. A RESTful Spring Boot application using springdoc-openapi and OpenAPI 3. JOpt.TourOptimizer is a service that delivers route optimization and automatic scheduling features to be easily integrated into any third-party application. JOpt.TourOptimizer encapsulates all necessary optimization functionality and provides a comprehensive REST API that offers a domain-specific optimization interface for the transportation industry. The service is stateless and does not come with graphical user interfaces, map depiction or any databases. These extensions and adjustments are supposed to be introduced by the consumer of the service while integrating it into his/her own application. The service will allow for many suitable adjustments and user-specific settings to adjust the behaviour and optimization goals (e.g. minimizing distance, maximizing resource utilization, etc.) through a comprehensive set of functions. This will enable you to gain control of the complete optimization processes.This service is based on JOpt (7.5.1-rc3-j17-SNAPSHOT)
 *
 * The version of the OpenAPI document: unknown
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
    /// The RouteElementDetail describes the solution for a certain node element.
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
        public RouteElementDetail(string elementId = default(string), DateTime startTime = default(DateTime), DateTime arrivalTime = default(DateTime), DateTime departureTime = default(DateTime), string transitionTime = default(string), Position effectivePosition = default(Position), string idleTime = default(string), string zoneId = default(string), string whiteSpaceIdleTime = default(string), string durationTime = default(string), string transitionDistance = default(string), int choosenWorkingHoursIndex = default(int), string earlyDeviation = default(string), string lateDeviation = default(string), ScheduleStatusEnum? scheduleStatus = default(ScheduleStatusEnum?), string visitorId = default(string), List<double> loadChange = default(List<double>), List<double> curCapacity = default(List<double>), INodeDepot beforeVisitNodeDepot = default(INodeDepot), INodeDepot afterVisitNodeDepot = default(INodeDepot), List<Violation> nodeViolations = default(List<Violation>), bool isUnlocatedIdleTime = default(bool))
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
