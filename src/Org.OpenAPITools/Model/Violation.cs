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
    /// The nodeViolations. The violations collected at the element/node. For example, lateViolation, early violation etc.
    /// </summary>
    [DataContract(Name = "Violation")]
    public partial class Violation : IEquatable<Violation>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Violation" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Violation() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Violation" /> class.
        /// </summary>
        /// <param name="value">The value is a violation specfic value. For example, if the violation is of subAttribute &#39;LATE&#39;, the value contains the late violation value in minutes. (required).</param>
        /// <param name="desc">The description of the violation. A human readable description of the violation (required).</param>
        /// <param name="category">The category of the violation. The main category of the violation. (required).</param>
        /// <param name="attribute">The attribute is further defining the type of the violation. For example, late and early violation belong to the attribute &#39;TIMECONSTRAINT&#39;. (required).</param>
        /// <param name="subAttribute">The subAttribute defines what kind of violation we are dealing with. (required).</param>
        /// <param name="code">The code is the unique code for each Violation type. (required).</param>
        public Violation(string value = default(string), string desc = default(string), string category = default(string), string attribute = default(string), string subAttribute = default(string), int code = default(int))
        {
            // to ensure "value" is required (not null)
            if (value == null)
            {
                throw new ArgumentNullException("value is a required property for Violation and cannot be null");
            }
            this.Value = value;
            // to ensure "desc" is required (not null)
            if (desc == null)
            {
                throw new ArgumentNullException("desc is a required property for Violation and cannot be null");
            }
            this.Desc = desc;
            // to ensure "category" is required (not null)
            if (category == null)
            {
                throw new ArgumentNullException("category is a required property for Violation and cannot be null");
            }
            this.Category = category;
            // to ensure "attribute" is required (not null)
            if (attribute == null)
            {
                throw new ArgumentNullException("attribute is a required property for Violation and cannot be null");
            }
            this.Attribute = attribute;
            // to ensure "subAttribute" is required (not null)
            if (subAttribute == null)
            {
                throw new ArgumentNullException("subAttribute is a required property for Violation and cannot be null");
            }
            this.SubAttribute = subAttribute;
            this.Code = code;
        }

        /// <summary>
        /// The value is a violation specfic value. For example, if the violation is of subAttribute &#39;LATE&#39;, the value contains the late violation value in minutes.
        /// </summary>
        /// <value>The value is a violation specfic value. For example, if the violation is of subAttribute &#39;LATE&#39;, the value contains the late violation value in minutes.</value>
        [DataMember(Name = "value", IsRequired = true, EmitDefaultValue = false)]
        public string Value { get; set; }

        /// <summary>
        /// The description of the violation. A human readable description of the violation
        /// </summary>
        /// <value>The description of the violation. A human readable description of the violation</value>
        [DataMember(Name = "desc", IsRequired = true, EmitDefaultValue = false)]
        public string Desc { get; set; }

        /// <summary>
        /// The category of the violation. The main category of the violation.
        /// </summary>
        /// <value>The category of the violation. The main category of the violation.</value>
        [DataMember(Name = "category", IsRequired = true, EmitDefaultValue = false)]
        public string Category { get; set; }

        /// <summary>
        /// The attribute is further defining the type of the violation. For example, late and early violation belong to the attribute &#39;TIMECONSTRAINT&#39;.
        /// </summary>
        /// <value>The attribute is further defining the type of the violation. For example, late and early violation belong to the attribute &#39;TIMECONSTRAINT&#39;.</value>
        [DataMember(Name = "attribute", IsRequired = true, EmitDefaultValue = false)]
        public string Attribute { get; set; }

        /// <summary>
        /// The subAttribute defines what kind of violation we are dealing with.
        /// </summary>
        /// <value>The subAttribute defines what kind of violation we are dealing with.</value>
        [DataMember(Name = "subAttribute", IsRequired = true, EmitDefaultValue = false)]
        public string SubAttribute { get; set; }

        /// <summary>
        /// The code is the unique code for each Violation type.
        /// </summary>
        /// <value>The code is the unique code for each Violation type.</value>
        [DataMember(Name = "code", IsRequired = true, EmitDefaultValue = false)]
        public int Code { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Violation {\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  Desc: ").Append(Desc).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  Attribute: ").Append(Attribute).Append("\n");
            sb.Append("  SubAttribute: ").Append(SubAttribute).Append("\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
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
            return this.Equals(input as Violation);
        }

        /// <summary>
        /// Returns true if Violation instances are equal
        /// </summary>
        /// <param name="input">Instance of Violation to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Violation input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
                ) && 
                (
                    this.Desc == input.Desc ||
                    (this.Desc != null &&
                    this.Desc.Equals(input.Desc))
                ) && 
                (
                    this.Category == input.Category ||
                    (this.Category != null &&
                    this.Category.Equals(input.Category))
                ) && 
                (
                    this.Attribute == input.Attribute ||
                    (this.Attribute != null &&
                    this.Attribute.Equals(input.Attribute))
                ) && 
                (
                    this.SubAttribute == input.SubAttribute ||
                    (this.SubAttribute != null &&
                    this.SubAttribute.Equals(input.SubAttribute))
                ) && 
                (
                    this.Code == input.Code ||
                    this.Code.Equals(input.Code)
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
                if (this.Value != null)
                {
                    hashCode = (hashCode * 59) + this.Value.GetHashCode();
                }
                if (this.Desc != null)
                {
                    hashCode = (hashCode * 59) + this.Desc.GetHashCode();
                }
                if (this.Category != null)
                {
                    hashCode = (hashCode * 59) + this.Category.GetHashCode();
                }
                if (this.Attribute != null)
                {
                    hashCode = (hashCode * 59) + this.Attribute.GetHashCode();
                }
                if (this.SubAttribute != null)
                {
                    hashCode = (hashCode * 59) + this.SubAttribute.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Code.GetHashCode();
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