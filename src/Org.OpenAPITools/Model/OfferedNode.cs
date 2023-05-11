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
    /// Defines if the node should be treated as offered node.
    /// </summary>
    [DataContract(Name = "OfferedNode")]
    public partial class OfferedNode : IEquatable<OfferedNode>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OfferedNode" /> class.
        /// </summary>
        /// <param name="individualMultiplier">The cost multiplier for an offered node. If the multiplier is bigger than 1.0 the chances that the node shows violations is getting less..</param>
        public OfferedNode(double individualMultiplier = default(double))
        {
            this.IndividualMultiplier = individualMultiplier;
        }

        /// <summary>
        /// The cost multiplier for an offered node. If the multiplier is bigger than 1.0 the chances that the node shows violations is getting less.
        /// </summary>
        /// <value>The cost multiplier for an offered node. If the multiplier is bigger than 1.0 the chances that the node shows violations is getting less.</value>
        [DataMember(Name = "individualMultiplier", EmitDefaultValue = false)]
        public double IndividualMultiplier { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class OfferedNode {\n");
            sb.Append("  IndividualMultiplier: ").Append(IndividualMultiplier).Append("\n");
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
            return this.Equals(input as OfferedNode);
        }

        /// <summary>
        /// Returns true if OfferedNode instances are equal
        /// </summary>
        /// <param name="input">Instance of OfferedNode to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OfferedNode input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.IndividualMultiplier == input.IndividualMultiplier ||
                    this.IndividualMultiplier.Equals(input.IndividualMultiplier)
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
                hashCode = (hashCode * 59) + this.IndividualMultiplier.GetHashCode();
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
