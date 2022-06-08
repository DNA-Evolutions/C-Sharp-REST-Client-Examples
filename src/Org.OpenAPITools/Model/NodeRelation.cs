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
    /// The list of relations
    /// </summary>
    [DataContract(Name = "NodeRelation")]
    public partial class NodeRelation : IEquatable<NodeRelation>, IValidatableObject
    {
        /// <summary>
        /// The relationMode
        /// </summary>
        /// <value>The relationMode</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RelationModeEnum
        {
            /// <summary>
            /// Enum STRONG for value: STRONG
            /// </summary>
            [EnumMember(Value = "STRONG")]
            STRONG = 1,

            /// <summary>
            /// Enum WEAK for value: WEAK
            /// </summary>
            [EnumMember(Value = "WEAK")]
            WEAK = 2,

            /// <summary>
            /// Enum WEAKTOMATER for value: WEAK_TO_MATER
            /// </summary>
            [EnumMember(Value = "WEAK_TO_MATER")]
            WEAKTOMATER = 3,

            /// <summary>
            /// Enum WEAKTORELATED for value: WEAK_TO_RELATED
            /// </summary>
            [EnumMember(Value = "WEAK_TO_RELATED")]
            WEAKTORELATED = 4

        }


        /// <summary>
        /// The relationMode
        /// </summary>
        /// <value>The relationMode</value>
        [DataMember(Name = "relationMode", EmitDefaultValue = false)]
        public RelationModeEnum? RelationMode { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="NodeRelation" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected NodeRelation() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="NodeRelation" /> class.
        /// </summary>
        /// <param name="masterNodeId">The masterNodeId (required).</param>
        /// <param name="relatedNodeId">The relatedNodeId (required).</param>
        /// <param name="type">type (required).</param>
        /// <param name="relationMode">The relationMode.</param>
        public NodeRelation(string masterNodeId = default(string), string relatedNodeId = default(string), NodeRelationType type = default(NodeRelationType), RelationModeEnum? relationMode = default(RelationModeEnum?))
        {
            // to ensure "masterNodeId" is required (not null)
            if (masterNodeId == null)
            {
                throw new ArgumentNullException("masterNodeId is a required property for NodeRelation and cannot be null");
            }
            this.MasterNodeId = masterNodeId;
            // to ensure "relatedNodeId" is required (not null)
            if (relatedNodeId == null)
            {
                throw new ArgumentNullException("relatedNodeId is a required property for NodeRelation and cannot be null");
            }
            this.RelatedNodeId = relatedNodeId;
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new ArgumentNullException("type is a required property for NodeRelation and cannot be null");
            }
            this.Type = type;
            this.RelationMode = relationMode;
        }

        /// <summary>
        /// The masterNodeId
        /// </summary>
        /// <value>The masterNodeId</value>
        [DataMember(Name = "masterNodeId", IsRequired = true, EmitDefaultValue = false)]
        public string MasterNodeId { get; set; }

        /// <summary>
        /// The relatedNodeId
        /// </summary>
        /// <value>The relatedNodeId</value>
        [DataMember(Name = "relatedNodeId", IsRequired = true, EmitDefaultValue = false)]
        public string RelatedNodeId { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public NodeRelationType Type { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class NodeRelation {\n");
            sb.Append("  MasterNodeId: ").Append(MasterNodeId).Append("\n");
            sb.Append("  RelatedNodeId: ").Append(RelatedNodeId).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  RelationMode: ").Append(RelationMode).Append("\n");
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
            return this.Equals(input as NodeRelation);
        }

        /// <summary>
        /// Returns true if NodeRelation instances are equal
        /// </summary>
        /// <param name="input">Instance of NodeRelation to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NodeRelation input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.MasterNodeId == input.MasterNodeId ||
                    (this.MasterNodeId != null &&
                    this.MasterNodeId.Equals(input.MasterNodeId))
                ) && 
                (
                    this.RelatedNodeId == input.RelatedNodeId ||
                    (this.RelatedNodeId != null &&
                    this.RelatedNodeId.Equals(input.RelatedNodeId))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.RelationMode == input.RelationMode ||
                    this.RelationMode.Equals(input.RelationMode)
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
                if (this.MasterNodeId != null)
                {
                    hashCode = (hashCode * 59) + this.MasterNodeId.GetHashCode();
                }
                if (this.RelatedNodeId != null)
                {
                    hashCode = (hashCode * 59) + this.RelatedNodeId.GetHashCode();
                }
                if (this.Type != null)
                {
                    hashCode = (hashCode * 59) + this.Type.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.RelationMode.GetHashCode();
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
