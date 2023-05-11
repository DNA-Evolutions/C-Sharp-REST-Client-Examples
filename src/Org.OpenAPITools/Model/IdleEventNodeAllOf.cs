/*
 * DNA Evolutions - JOpt.TourOptimizer
 *
 * This is DNA's JOpt.TourOptimizer service. A RESTful Spring Boot application using springdoc-openapi and OpenAPI 3. JOpt.TourOpptimizer is a service that delivers route optimization and automatic scheduling features to be easily integrated into any third-party application. JOpt.TourOpptimizer encapsulates all necessary optimization functionality and provides a comprehensive REST API that offers a domain-specific optimization interface for the transportation industry. The service is stateless and does not come with graphical user interfaces, map depiction or any databases. These extensions and adjustments are supposed to be introduced by the consumer of the service while integrating it into his/her own application. The service will allow for many suitable adjustments and user-specific settings to adjust the behaviour and optimization goals (e.g. minimizing distance, maximizing resource utilization, etc.) through a comprehensive set of functions. This will enable you to gain control of the complete optimization processes.This service is based on JOpt (null)
 *
 * The version of the OpenAPI document: 1.2.2-SNAPSHOT
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
    /// IdleEventNodeAllOf
    /// </summary>
    [DataContract(Name = "IdleEventNode_allOf")]
    public partial class IdleEventNodeAllOf : IEquatable<IdleEventNodeAllOf>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdleEventNodeAllOf" /> class.
        /// </summary>
        /// <param name="pillarNode">pillarNode.</param>
        /// <param name="masterId">The masterId.</param>
        /// <param name="relatedId">The relatedId.</param>
        /// <param name="creationTimeStamp">The creationTimeStamp.</param>
        /// <param name="typeName">The typeName of the object (default to &quot;IdleEvent&quot;).</param>
        public IdleEventNodeAllOf(EventPillarNode pillarNode = default(EventPillarNode), string masterId = default(string), string relatedId = default(string), long creationTimeStamp = default(long), string typeName = "IdleEvent")
        {
            this.PillarNode = pillarNode;
            this.MasterId = masterId;
            this.RelatedId = relatedId;
            this.CreationTimeStamp = creationTimeStamp;
            // use default value if no "typeName" provided
            this.TypeName = typeName ?? "IdleEvent";
        }

        /// <summary>
        /// Gets or Sets PillarNode
        /// </summary>
        [DataMember(Name = "pillarNode", EmitDefaultValue = false)]
        public EventPillarNode PillarNode { get; set; }

        /// <summary>
        /// The masterId
        /// </summary>
        /// <value>The masterId</value>
        [DataMember(Name = "masterId", EmitDefaultValue = false)]
        public string MasterId { get; set; }

        /// <summary>
        /// The relatedId
        /// </summary>
        /// <value>The relatedId</value>
        [DataMember(Name = "relatedId", EmitDefaultValue = false)]
        public string RelatedId { get; set; }

        /// <summary>
        /// The creationTimeStamp
        /// </summary>
        /// <value>The creationTimeStamp</value>
        [DataMember(Name = "creationTimeStamp", EmitDefaultValue = false)]
        public long CreationTimeStamp { get; set; }

        /// <summary>
        /// The typeName of the object
        /// </summary>
        /// <value>The typeName of the object</value>
        [DataMember(Name = "typeName", EmitDefaultValue = false)]
        public string TypeName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class IdleEventNodeAllOf {\n");
            sb.Append("  PillarNode: ").Append(PillarNode).Append("\n");
            sb.Append("  MasterId: ").Append(MasterId).Append("\n");
            sb.Append("  RelatedId: ").Append(RelatedId).Append("\n");
            sb.Append("  CreationTimeStamp: ").Append(CreationTimeStamp).Append("\n");
            sb.Append("  TypeName: ").Append(TypeName).Append("\n");
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
            return this.Equals(input as IdleEventNodeAllOf);
        }

        /// <summary>
        /// Returns true if IdleEventNodeAllOf instances are equal
        /// </summary>
        /// <param name="input">Instance of IdleEventNodeAllOf to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(IdleEventNodeAllOf input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.PillarNode == input.PillarNode ||
                    (this.PillarNode != null &&
                    this.PillarNode.Equals(input.PillarNode))
                ) && 
                (
                    this.MasterId == input.MasterId ||
                    (this.MasterId != null &&
                    this.MasterId.Equals(input.MasterId))
                ) && 
                (
                    this.RelatedId == input.RelatedId ||
                    (this.RelatedId != null &&
                    this.RelatedId.Equals(input.RelatedId))
                ) && 
                (
                    this.CreationTimeStamp == input.CreationTimeStamp ||
                    this.CreationTimeStamp.Equals(input.CreationTimeStamp)
                ) && 
                (
                    this.TypeName == input.TypeName ||
                    (this.TypeName != null &&
                    this.TypeName.Equals(input.TypeName))
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
                if (this.PillarNode != null)
                {
                    hashCode = (hashCode * 59) + this.PillarNode.GetHashCode();
                }
                if (this.MasterId != null)
                {
                    hashCode = (hashCode * 59) + this.MasterId.GetHashCode();
                }
                if (this.RelatedId != null)
                {
                    hashCode = (hashCode * 59) + this.RelatedId.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.CreationTimeStamp.GetHashCode();
                if (this.TypeName != null)
                {
                    hashCode = (hashCode * 59) + this.TypeName.GetHashCode();
                }
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
