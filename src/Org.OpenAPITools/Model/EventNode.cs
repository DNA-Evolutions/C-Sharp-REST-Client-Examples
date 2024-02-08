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
using JsonSubTypes;
using System.ComponentModel.DataAnnotations;
using FileParameter = Org.OpenAPITools.Client.FileParameter;
using OpenAPIDateConverter = Org.OpenAPITools.Client.OpenAPIDateConverter;

namespace Org.OpenAPITools.Model
{
    /// <summary>
    /// EventNode
    /// </summary>
    [DataContract(Name = "EventNode")]
    [JsonConverter(typeof(JsonSubtypes), "TypeName")]
    public partial class EventNode : NodeType, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventNode" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EventNode() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="EventNode" /> class.
        /// </summary>
        /// <param name="pillarNode">pillarNode.</param>
        /// <param name="typeName">The typeName of the object (required) (default to &quot;Event&quot;).</param>
        /// <param name="isPartialExchangeIdleForDrivingTime">An EventNode is allowed to be visited BEWTWEEN two Nodes and does not need to be positioned at a node. (default to true).</param>
        public EventNode(EventPillarNode pillarNode = default(EventPillarNode), string typeName = @"Event", bool? isPartialExchangeIdleForDrivingTime = true) : base()
        {
            // to ensure "typeName" is required (not null)
            if (typeName == null)
            {
                throw new ArgumentNullException("typeName is a required property for EventNode and cannot be null");
            }
            this.TypeName = typeName;
            this.PillarNode = pillarNode;
            // use default value if no "isPartialExchangeIdleForDrivingTime" provided
            this.IsPartialExchangeIdleForDrivingTime = isPartialExchangeIdleForDrivingTime ?? true;
        }

        /// <summary>
        /// Gets or Sets PillarNode
        /// </summary>
        [DataMember(Name = "pillarNode", EmitDefaultValue = false)]
        public EventPillarNode PillarNode { get; set; }

        /// <summary>
        /// The typeName of the object
        /// </summary>
        /// <value>The typeName of the object</value>
        /// <example>Event</example>
        [DataMember(Name = "typeName", IsRequired = true, EmitDefaultValue = true)]
        public string TypeName { get; set; }

        /// <summary>
        /// An EventNode is allowed to be visited BEWTWEEN two Nodes and does not need to be positioned at a node.
        /// </summary>
        /// <value>An EventNode is allowed to be visited BEWTWEEN two Nodes and does not need to be positioned at a node.</value>
        [DataMember(Name = "isPartialExchangeIdleForDrivingTime", EmitDefaultValue = true)]
        public bool? IsPartialExchangeIdleForDrivingTime { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class EventNode {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  PillarNode: ").Append(PillarNode).Append("\n");
            sb.Append("  TypeName: ").Append(TypeName).Append("\n");
            sb.Append("  IsPartialExchangeIdleForDrivingTime: ").Append(IsPartialExchangeIdleForDrivingTime).Append("\n");
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
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            return this.BaseValidate(validationContext);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        protected IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> BaseValidate(ValidationContext validationContext)
        {
            foreach (var x in base.BaseValidate(validationContext))
            {
                yield return x;
            }
            yield break;
        }
    }

}
