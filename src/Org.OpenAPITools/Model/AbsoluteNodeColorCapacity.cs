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
    /// The absoluteNodeColorCapacities
    /// </summary>
    [DataContract(Name = "AbsoluteNodeColorCapacity")]
    public partial class AbsoluteNodeColorCapacity : IEquatable<AbsoluteNodeColorCapacity>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AbsoluteNodeColorCapacity" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AbsoluteNodeColorCapacity() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="AbsoluteNodeColorCapacity" /> class.
        /// </summary>
        /// <param name="nodeColor">nodeColor (required).</param>
        /// <param name="minUsage">The minUsage (required).</param>
        /// <param name="maxUsage">The maxUsage (required).</param>
        public AbsoluteNodeColorCapacity(NodeColor nodeColor = default(NodeColor), int minUsage = default(int), int maxUsage = default(int))
        {
            // to ensure "nodeColor" is required (not null)
            if (nodeColor == null)
            {
                throw new ArgumentNullException("nodeColor is a required property for AbsoluteNodeColorCapacity and cannot be null");
            }
            this.NodeColor = nodeColor;
            this.MinUsage = minUsage;
            this.MaxUsage = maxUsage;
        }

        /// <summary>
        /// Gets or Sets NodeColor
        /// </summary>
        [DataMember(Name = "nodeColor", IsRequired = true, EmitDefaultValue = false)]
        public NodeColor NodeColor { get; set; }

        /// <summary>
        /// The minUsage
        /// </summary>
        /// <value>The minUsage</value>
        [DataMember(Name = "minUsage", IsRequired = true, EmitDefaultValue = false)]
        public int MinUsage { get; set; }

        /// <summary>
        /// The maxUsage
        /// </summary>
        /// <value>The maxUsage</value>
        [DataMember(Name = "maxUsage", IsRequired = true, EmitDefaultValue = false)]
        public int MaxUsage { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AbsoluteNodeColorCapacity {\n");
            sb.Append("  NodeColor: ").Append(NodeColor).Append("\n");
            sb.Append("  MinUsage: ").Append(MinUsage).Append("\n");
            sb.Append("  MaxUsage: ").Append(MaxUsage).Append("\n");
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
            return this.Equals(input as AbsoluteNodeColorCapacity);
        }

        /// <summary>
        /// Returns true if AbsoluteNodeColorCapacity instances are equal
        /// </summary>
        /// <param name="input">Instance of AbsoluteNodeColorCapacity to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AbsoluteNodeColorCapacity input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.NodeColor == input.NodeColor ||
                    (this.NodeColor != null &&
                    this.NodeColor.Equals(input.NodeColor))
                ) && 
                (
                    this.MinUsage == input.MinUsage ||
                    this.MinUsage.Equals(input.MinUsage)
                ) && 
                (
                    this.MaxUsage == input.MaxUsage ||
                    this.MaxUsage.Equals(input.MaxUsage)
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
                if (this.NodeColor != null)
                {
                    hashCode = (hashCode * 59) + this.NodeColor.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.MinUsage.GetHashCode();
                hashCode = (hashCode * 59) + this.MaxUsage.GetHashCode();
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
