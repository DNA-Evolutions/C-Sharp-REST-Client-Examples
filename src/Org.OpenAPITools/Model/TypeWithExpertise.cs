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
    /// A list of user-provided type-names and expertise levels. A Contraint type-name with its required expertise must be fulfill by the type-with-expertise Qualification to result in a violation free solution.
    /// </summary>
    [DataContract(Name = "TypeWithExpertise")]
    public partial class TypeWithExpertise : IEquatable<TypeWithExpertise>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TypeWithExpertise" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TypeWithExpertise() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TypeWithExpertise" /> class.
        /// </summary>
        /// <param name="type">The type name that in addition requires a certain expertise level. (required).</param>
        /// <param name="level">The expertise level (required).</param>
        /// <param name="isMin">The boolean isMin. If isMin&#x3D;&#x3D;true, the level is a minimal level that needs to be fulfilled. (required).</param>
        public TypeWithExpertise(string type = default(string), double level = default(double), bool isMin = default(bool))
        {
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new ArgumentNullException("type is a required property for TypeWithExpertise and cannot be null");
            }
            this.Type = type;
            this.Level = level;
            this.IsMin = isMin;
        }

        /// <summary>
        /// The type name that in addition requires a certain expertise level.
        /// </summary>
        /// <value>The type name that in addition requires a certain expertise level.</value>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// The expertise level
        /// </summary>
        /// <value>The expertise level</value>
        [DataMember(Name = "level", IsRequired = true, EmitDefaultValue = false)]
        public double Level { get; set; }

        /// <summary>
        /// The boolean isMin. If isMin&#x3D;&#x3D;true, the level is a minimal level that needs to be fulfilled.
        /// </summary>
        /// <value>The boolean isMin. If isMin&#x3D;&#x3D;true, the level is a minimal level that needs to be fulfilled.</value>
        [DataMember(Name = "isMin", IsRequired = true, EmitDefaultValue = true)]
        public bool IsMin { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TypeWithExpertise {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Level: ").Append(Level).Append("\n");
            sb.Append("  IsMin: ").Append(IsMin).Append("\n");
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
            return this.Equals(input as TypeWithExpertise);
        }

        /// <summary>
        /// Returns true if TypeWithExpertise instances are equal
        /// </summary>
        /// <param name="input">Instance of TypeWithExpertise to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TypeWithExpertise input)
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
                    this.Level == input.Level ||
                    this.Level.Equals(input.Level)
                ) && 
                (
                    this.IsMin == input.IsMin ||
                    this.IsMin.Equals(input.IsMin)
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
                hashCode = (hashCode * 59) + this.Level.GetHashCode();
                hashCode = (hashCode * 59) + this.IsMin.GetHashCode();
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
