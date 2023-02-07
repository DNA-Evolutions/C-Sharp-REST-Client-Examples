/*
 * DNA Evolutions - JOpt.TourOptimizer
 *
 * This is DNA's JOpt.TourOptimizer service. A RESTful Spring Boot application using springdoc-openapi and OpenAPI 3. JOpt.TourOpptimizer is a service that delivers route optimization and automatic scheduling features to be easily integrated into any third-party application. JOpt.TourOpptimizer encapsulates all necessary optimization functionality and provides a comprehensive REST API that offers a domain-specific optimization interface for the transportation industry. The service is stateless and does not come with graphical user interfaces, map depiction or any databases. These extensions and adjustments are supposed to be introduced by the consumer of the service while integrating it into his/her own application. The service will allow for many suitable adjustments and user-specific settings to adjust the behaviour and optimization goals (e.g. minimizing distance, maximizing resource utilization, etc.) through a comprehensive set of functions. This will enable you to gain control of the complete optimization processes.This service is based on JOpt (7.5.1-SNAPSHOT)
 *
 * The version of the OpenAPI document: 1.2.1-SNAPSHOT
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
    /// The constraints  of the Resource
    /// </summary>
    [DataContract(Name = "Constraint")]
    public partial class Constraint : IEquatable<Constraint>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Constraint" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Constraint() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Constraint" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        /// <param name="isHard">Defines if a constraint is soft contrained or hard constraint. A hard constraint is fullfilled by the architectural design of the Optimzer. Therefore a hard constraint violation cannot occure. However, not all constraints can be hard-constraint- (required).</param>
        public Constraint(ConstraintType type = default(ConstraintType), bool isHard = default(bool))
        {
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new ArgumentNullException("type is a required property for Constraint and cannot be null");
            }
            this.Type = type;
            this.IsHard = isHard;
        }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public ConstraintType Type { get; set; }

        /// <summary>
        /// Defines if a constraint is soft contrained or hard constraint. A hard constraint is fullfilled by the architectural design of the Optimzer. Therefore a hard constraint violation cannot occure. However, not all constraints can be hard-constraint-
        /// </summary>
        /// <value>Defines if a constraint is soft contrained or hard constraint. A hard constraint is fullfilled by the architectural design of the Optimzer. Therefore a hard constraint violation cannot occure. However, not all constraints can be hard-constraint-</value>
        [DataMember(Name = "isHard", IsRequired = true, EmitDefaultValue = true)]
        public bool IsHard { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Constraint {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  IsHard: ").Append(IsHard).Append("\n");
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
            return this.Equals(input as Constraint);
        }

        /// <summary>
        /// Returns true if Constraint instances are equal
        /// </summary>
        /// <param name="input">Instance of Constraint to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Constraint input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.IsHard == input.IsHard ||
                    this.IsHard.Equals(input.IsHard)
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
                if (this.Type != null)
                {
                    hashCode = (hashCode * 59) + this.Type.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.IsHard.GetHashCode();
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
