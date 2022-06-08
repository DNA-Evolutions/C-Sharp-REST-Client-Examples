/*
 * DNA Evolutions - JOpt.TourOptimizer
 *
 * This is DNA's JOpt.TourOptimizer service. A RESTful Spring Boot application using springdoc-openapi and OpenAPI 3. JOpt.TourOpptimizer is a service that delivers route optimization and automatic scheduling features to be easily integrated into any third-party application. JOpt.TourOpptimizer encapsulates all necessary optimization functionality and provides a comprehensive REST API that offers a domain-specific optimization interface for the transportation industry. The service is stateless and does not come with graphical user interfaces, map depiction or any databases. These extensions and adjustments are supposed to be introduced by the consumer of the service while integrating it into his/her own application. The service will allow for many suitable adjustments and user-specific settings to adjust the behaviour and optimization goals (e.g. minimizing distance, maximizing resource utilization, etc.) through a comprehensive set of functions. This will enable you to gain control of the complete optimization processes.This service is based on JOpt (7.4.9-SNAPSHOT)
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
    /// The routes of the solution.
    /// </summary>
    [DataContract(Name = "Route")]
    public partial class Route : IEquatable<Route>, IValidatableObject
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
        /// The flags. A list of flags indicating statii like which source finalized a route.
        /// </summary>
        /// <value>The flags. A list of flags indicating statii like which source finalized a route.</value>
        [DataMember(Name = "flags", EmitDefaultValue = false)]
        public List<FlagsEnum> Flags { get; set; }
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
        /// <param name="isInactive">The isInactive boolean describes if a route is deactivated..</param>
        /// <param name="isFinalized">The isFinalized. Describes if a route was undergoing finalization..</param>
        /// <param name="isLockedDown">The isLockedDown. Describes if a route was undergoing lockdown..</param>
        public Route(RouteHeader header = default(RouteHeader), int id = default(int), string resourceId = default(string), RouteTrip routeTrip = default(RouteTrip), DateTime startTime = default(DateTime), string startElementId = default(string), Position startPosition = default(Position), string endElementId = default(string), Position endPosition = default(Position), List<string> optimizableElementIds = default(List<string>), List<string> nonOptimizableElementIds = default(List<string>), List<string> optionalOptimizableElementIds = default(List<string>), List<string> pillarElementIds = default(List<string>), List<RouteElementDetail> elementDetails = default(List<RouteElementDetail>), Dictionary<string, long> pillarLatestEffectiveArrivalOffsetMap = default(Dictionary<string, long>), List<FlagsEnum> flags = default(List<FlagsEnum>), bool isInactive = default(bool), bool isFinalized = default(bool), bool isLockedDown = default(bool))
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
            this.IsInactive = isInactive;
            this.IsFinalized = isFinalized;
            this.IsLockedDown = isLockedDown;
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
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// The resourceId of the Visitor owning this route.
        /// </summary>
        /// <value>The resourceId of the Visitor owning this route.</value>
        [DataMember(Name = "resourceId", IsRequired = true, EmitDefaultValue = false)]
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
        [DataMember(Name = "startTime", IsRequired = true, EmitDefaultValue = false)]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The startElementId, is the element from where the route starts. By default, it is the Resource itself.
        /// </summary>
        /// <value>The startElementId, is the element from where the route starts. By default, it is the Resource itself.</value>
        [DataMember(Name = "startElementId", IsRequired = true, EmitDefaultValue = false)]
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
        [DataMember(Name = "endElementId", IsRequired = true, EmitDefaultValue = false)]
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
        [DataMember(Name = "optimizableElementIds", IsRequired = true, EmitDefaultValue = false)]
        public List<string> OptimizableElementIds { get; set; }

        /// <summary>
        /// The nonOptimizableElementIds. The list of non-optimizable elements that are part of the route.
        /// </summary>
        /// <value>The nonOptimizableElementIds. The list of non-optimizable elements that are part of the route.</value>
        [DataMember(Name = "nonOptimizableElementIds", IsRequired = true, EmitDefaultValue = false)]
        public List<string> NonOptimizableElementIds { get; set; }

        /// <summary>
        /// The optionalOptimizableElementIds. The list of optional elements that are part of the route.
        /// </summary>
        /// <value>The optionalOptimizableElementIds. The list of optional elements that are part of the route.</value>
        [DataMember(Name = "optionalOptimizableElementIds", IsRequired = true, EmitDefaultValue = false)]
        public List<string> OptionalOptimizableElementIds { get; set; }

        /// <summary>
        /// The pillarElementIds. The list of pillar elements that are part of the route.
        /// </summary>
        /// <value>The pillarElementIds. The list of pillar elements that are part of the route.</value>
        [DataMember(Name = "pillarElementIds", IsRequired = true, EmitDefaultValue = false)]
        public List<string> PillarElementIds { get; set; }

        /// <summary>
        /// The elementDetails. The list of details describing the route schedule.
        /// </summary>
        /// <value>The elementDetails. The list of details describing the route schedule.</value>
        [DataMember(Name = "elementDetails", IsRequired = true, EmitDefaultValue = false)]
        public List<RouteElementDetail> ElementDetails { get; set; }

        /// <summary>
        /// The pillarLatestEffectiveArrivalOffsetMap. A map of additional time offsets for pillar elements. Each pillar has a latest possible arrival. As a route can consist of multiple pillars, the latest arrival at a certain pillar is also a function of  subsequent pillars. This latest arrival may shifted to a later time spot to allow shifitig a pillar around a normal node, even the normal node would fit before the pillar.
        /// </summary>
        /// <value>The pillarLatestEffectiveArrivalOffsetMap. A map of additional time offsets for pillar elements. Each pillar has a latest possible arrival. As a route can consist of multiple pillars, the latest arrival at a certain pillar is also a function of  subsequent pillars. This latest arrival may shifted to a later time spot to allow shifitig a pillar around a normal node, even the normal node would fit before the pillar.</value>
        [DataMember(Name = "pillarLatestEffectiveArrivalOffsetMap", EmitDefaultValue = false)]
        public Dictionary<string, long> PillarLatestEffectiveArrivalOffsetMap { get; set; }

        /// <summary>
        /// The isInactive boolean describes if a route is deactivated.
        /// </summary>
        /// <value>The isInactive boolean describes if a route is deactivated.</value>
        [DataMember(Name = "isInactive", EmitDefaultValue = true)]
        public bool IsInactive { get; set; }

        /// <summary>
        /// The isFinalized. Describes if a route was undergoing finalization.
        /// </summary>
        /// <value>The isFinalized. Describes if a route was undergoing finalization.</value>
        [DataMember(Name = "isFinalized", EmitDefaultValue = true)]
        public bool IsFinalized { get; set; }

        /// <summary>
        /// The isLockedDown. Describes if a route was undergoing lockdown.
        /// </summary>
        /// <value>The isLockedDown. Describes if a route was undergoing lockdown.</value>
        [DataMember(Name = "isLockedDown", EmitDefaultValue = true)]
        public bool IsLockedDown { get; set; }

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
            sb.Append("  IsInactive: ").Append(IsInactive).Append("\n");
            sb.Append("  IsFinalized: ").Append(IsFinalized).Append("\n");
            sb.Append("  IsLockedDown: ").Append(IsLockedDown).Append("\n");
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
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Route);
        }

        /// <summary>
        /// Returns true if Route instances are equal
        /// </summary>
        /// <param name="input">Instance of Route to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Route input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Header == input.Header ||
                    (this.Header != null &&
                    this.Header.Equals(input.Header))
                ) && 
                (
                    this.Id == input.Id ||
                    this.Id.Equals(input.Id)
                ) && 
                (
                    this.ResourceId == input.ResourceId ||
                    (this.ResourceId != null &&
                    this.ResourceId.Equals(input.ResourceId))
                ) && 
                (
                    this.RouteTrip == input.RouteTrip ||
                    (this.RouteTrip != null &&
                    this.RouteTrip.Equals(input.RouteTrip))
                ) && 
                (
                    this.StartTime == input.StartTime ||
                    (this.StartTime != null &&
                    this.StartTime.Equals(input.StartTime))
                ) && 
                (
                    this.StartElementId == input.StartElementId ||
                    (this.StartElementId != null &&
                    this.StartElementId.Equals(input.StartElementId))
                ) && 
                (
                    this.StartPosition == input.StartPosition ||
                    (this.StartPosition != null &&
                    this.StartPosition.Equals(input.StartPosition))
                ) && 
                (
                    this.EndElementId == input.EndElementId ||
                    (this.EndElementId != null &&
                    this.EndElementId.Equals(input.EndElementId))
                ) && 
                (
                    this.EndPosition == input.EndPosition ||
                    (this.EndPosition != null &&
                    this.EndPosition.Equals(input.EndPosition))
                ) && 
                (
                    this.OptimizableElementIds == input.OptimizableElementIds ||
                    this.OptimizableElementIds != null &&
                    input.OptimizableElementIds != null &&
                    this.OptimizableElementIds.SequenceEqual(input.OptimizableElementIds)
                ) && 
                (
                    this.NonOptimizableElementIds == input.NonOptimizableElementIds ||
                    this.NonOptimizableElementIds != null &&
                    input.NonOptimizableElementIds != null &&
                    this.NonOptimizableElementIds.SequenceEqual(input.NonOptimizableElementIds)
                ) && 
                (
                    this.OptionalOptimizableElementIds == input.OptionalOptimizableElementIds ||
                    this.OptionalOptimizableElementIds != null &&
                    input.OptionalOptimizableElementIds != null &&
                    this.OptionalOptimizableElementIds.SequenceEqual(input.OptionalOptimizableElementIds)
                ) && 
                (
                    this.PillarElementIds == input.PillarElementIds ||
                    this.PillarElementIds != null &&
                    input.PillarElementIds != null &&
                    this.PillarElementIds.SequenceEqual(input.PillarElementIds)
                ) && 
                (
                    this.ElementDetails == input.ElementDetails ||
                    this.ElementDetails != null &&
                    input.ElementDetails != null &&
                    this.ElementDetails.SequenceEqual(input.ElementDetails)
                ) && 
                (
                    this.PillarLatestEffectiveArrivalOffsetMap == input.PillarLatestEffectiveArrivalOffsetMap ||
                    this.PillarLatestEffectiveArrivalOffsetMap != null &&
                    input.PillarLatestEffectiveArrivalOffsetMap != null &&
                    this.PillarLatestEffectiveArrivalOffsetMap.SequenceEqual(input.PillarLatestEffectiveArrivalOffsetMap)
                ) && 
                (
                    this.Flags == input.Flags ||
                    this.Flags.SequenceEqual(input.Flags)
                ) && 
                (
                    this.IsInactive == input.IsInactive ||
                    this.IsInactive.Equals(input.IsInactive)
                ) && 
                (
                    this.IsFinalized == input.IsFinalized ||
                    this.IsFinalized.Equals(input.IsFinalized)
                ) && 
                (
                    this.IsLockedDown == input.IsLockedDown ||
                    this.IsLockedDown.Equals(input.IsLockedDown)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Header != null)
                {
                    hashCode = (hashCode * 59) + this.Header.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Id.GetHashCode();
                if (this.ResourceId != null)
                {
                    hashCode = (hashCode * 59) + this.ResourceId.GetHashCode();
                }
                if (this.RouteTrip != null)
                {
                    hashCode = (hashCode * 59) + this.RouteTrip.GetHashCode();
                }
                if (this.StartTime != null)
                {
                    hashCode = (hashCode * 59) + this.StartTime.GetHashCode();
                }
                if (this.StartElementId != null)
                {
                    hashCode = (hashCode * 59) + this.StartElementId.GetHashCode();
                }
                if (this.StartPosition != null)
                {
                    hashCode = (hashCode * 59) + this.StartPosition.GetHashCode();
                }
                if (this.EndElementId != null)
                {
                    hashCode = (hashCode * 59) + this.EndElementId.GetHashCode();
                }
                if (this.EndPosition != null)
                {
                    hashCode = (hashCode * 59) + this.EndPosition.GetHashCode();
                }
                if (this.OptimizableElementIds != null)
                {
                    hashCode = (hashCode * 59) + this.OptimizableElementIds.GetHashCode();
                }
                if (this.NonOptimizableElementIds != null)
                {
                    hashCode = (hashCode * 59) + this.NonOptimizableElementIds.GetHashCode();
                }
                if (this.OptionalOptimizableElementIds != null)
                {
                    hashCode = (hashCode * 59) + this.OptionalOptimizableElementIds.GetHashCode();
                }
                if (this.PillarElementIds != null)
                {
                    hashCode = (hashCode * 59) + this.PillarElementIds.GetHashCode();
                }
                if (this.ElementDetails != null)
                {
                    hashCode = (hashCode * 59) + this.ElementDetails.GetHashCode();
                }
                if (this.PillarLatestEffectiveArrivalOffsetMap != null)
                {
                    hashCode = (hashCode * 59) + this.PillarLatestEffectiveArrivalOffsetMap.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Flags.GetHashCode();
                hashCode = (hashCode * 59) + this.IsInactive.GetHashCode();
                hashCode = (hashCode * 59) + this.IsFinalized.GetHashCode();
                hashCode = (hashCode * 59) + this.IsLockedDown.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}