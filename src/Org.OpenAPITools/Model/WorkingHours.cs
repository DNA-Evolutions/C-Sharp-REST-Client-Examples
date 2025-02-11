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
    /// The list of non-overlapping workingHours.
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
        /// <param name="localPostFlexTime">The localPostFlexTime.</param>
        /// <param name="localPostFlexTimeOnlyOnOvertime">The post flextime is only applied to reduce overtime. (default to false).</param>
        /// <param name="maxLocalPillarAfterHoursTime">The maxLocalPillarAfterHoursTime.</param>
        /// <param name="nodeColorCapacities">The nodeColorCapacities.</param>
        /// <param name="workingHoursConstraints">The constraints for this working hour..</param>
        /// <param name="multiWorkingHoursConstraints">The multiWorkingHoursConstraints.</param>
        /// <param name="qualifications">The qualification of the Resource for this working hour. For example, the Resource is allowed to visit a node needing a skill (defined via a constraint) and the Resource is providing this skill..</param>
        /// <param name="routeStartTimeHook">The routeStartTimeHook.</param>
        /// <param name="hookElementConnections">The list of hook connections.</param>
        /// <param name="isClosedRoute">The isClosedRoute boolean describes if a Resource has to visit the termination element of the Route. By default, the start element and the termination element of a Route is the Resource itself. In case of a closed route, by default, the Resource returns to its original starting location. (default to true).</param>
        /// <param name="isAvailableForStay">The boolean isAvailableForStay defines if this working hour is allowed to end at an overnight stay. (default to true).</param>
        public WorkingHours(DateTime begin = default(DateTime), DateTime end = default(DateTime), string zoneId = default(string), string maxTime = default(string), string maxDistance = default(string), StayOutCycleDefinition stayOutCycleDefinition = default(StayOutCycleDefinition), StartReductionTimeDefinition startReductionTimeDefinition = default(StartReductionTimeDefinition), StartReductionTimePillarDefinition startReductionTimePillarDefinition = default(StartReductionTimePillarDefinition), StartReductionTimeIncludeDefinition startReductionTimeIncludeDefinition = default(StartReductionTimeIncludeDefinition), string localFlexTime = default(string), string localPostFlexTime = default(string), bool? localPostFlexTimeOnlyOnOvertime = false, string maxLocalPillarAfterHoursTime = default(string), List<NodeColorCapacity> nodeColorCapacities = default(List<NodeColorCapacity>), List<Constraint> workingHoursConstraints = default(List<Constraint>), List<Constraint> multiWorkingHoursConstraints = default(List<Constraint>), List<Qualification> qualifications = default(List<Qualification>), string routeStartTimeHook = default(string), List<ReducedNodeEdgeConnectorItem> hookElementConnections = default(List<ReducedNodeEdgeConnectorItem>), bool? isClosedRoute = true, bool? isAvailableForStay = true)
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
            this.Qualifications = qualifications;
            this.RouteStartTimeHook = routeStartTimeHook;
            this.HookElementConnections = hookElementConnections;
            // use default value if no "isClosedRoute" provided
            this.IsClosedRoute = isClosedRoute ?? true;
            // use default value if no "isAvailableForStay" provided
            this.IsAvailableForStay = isAvailableForStay ?? true;
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
        /// The localPostFlexTime
        /// </summary>
        /// <value>The localPostFlexTime</value>
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
        /// The maxLocalPillarAfterHoursTime
        /// </summary>
        /// <value>The maxLocalPillarAfterHoursTime</value>
        /*
        <example>PT30M</example>
        */
        [DataMember(Name = "maxLocalPillarAfterHoursTime", EmitDefaultValue = false)]
        public string MaxLocalPillarAfterHoursTime { get; set; }

        /// <summary>
        /// The nodeColorCapacities
        /// </summary>
        /// <value>The nodeColorCapacities</value>
        [DataMember(Name = "nodeColorCapacities", EmitDefaultValue = false)]
        public List<NodeColorCapacity> NodeColorCapacities { get; set; }

        /// <summary>
        /// The constraints for this working hour.
        /// </summary>
        /// <value>The constraints for this working hour.</value>
        [DataMember(Name = "workingHoursConstraints", EmitDefaultValue = false)]
        public List<Constraint> WorkingHoursConstraints { get; set; }

        /// <summary>
        /// The multiWorkingHoursConstraints
        /// </summary>
        /// <value>The multiWorkingHoursConstraints</value>
        [DataMember(Name = "multiWorkingHoursConstraints", EmitDefaultValue = false)]
        public List<Constraint> MultiWorkingHoursConstraints { get; set; }

        /// <summary>
        /// The qualification of the Resource for this working hour. For example, the Resource is allowed to visit a node needing a skill (defined via a constraint) and the Resource is providing this skill.
        /// </summary>
        /// <value>The qualification of the Resource for this working hour. For example, the Resource is allowed to visit a node needing a skill (defined via a constraint) and the Resource is providing this skill.</value>
        [DataMember(Name = "qualifications", EmitDefaultValue = false)]
        public List<Qualification> Qualifications { get; set; }

        /// <summary>
        /// The routeStartTimeHook
        /// </summary>
        /// <value>The routeStartTimeHook</value>
        /*
        <example>PT30M</example>
        */
        [DataMember(Name = "routeStartTimeHook", EmitDefaultValue = false)]
        public string RouteStartTimeHook { get; set; }

        /// <summary>
        /// The list of hook connections
        /// </summary>
        /// <value>The list of hook connections</value>
        [DataMember(Name = "hookElementConnections", EmitDefaultValue = false)]
        public List<ReducedNodeEdgeConnectorItem> HookElementConnections { get; set; }

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
            sb.Append("  Qualifications: ").Append(Qualifications).Append("\n");
            sb.Append("  RouteStartTimeHook: ").Append(RouteStartTimeHook).Append("\n");
            sb.Append("  HookElementConnections: ").Append(HookElementConnections).Append("\n");
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
