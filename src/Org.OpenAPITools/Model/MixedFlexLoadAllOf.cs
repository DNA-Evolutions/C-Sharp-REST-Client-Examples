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
    /// MixedFlexLoadAllOf
    /// </summary>
    [DataContract(Name = "MixedFlexLoad_allOf")]
    public partial class MixedFlexLoadAllOf : IEquatable<MixedFlexLoadAllOf>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MixedFlexLoadAllOf" /> class.
        /// </summary>
        /// <param name="loadId">loadId.</param>
        /// <param name="isRequest">isRequest.</param>
        /// <param name="isFuzzyVisit">isFuzzyVisit.</param>
        /// <param name="typeName">The typeName of the object (default to &quot;MixedFlexLoad&quot;).</param>
        public MixedFlexLoadAllOf(string loadId = default(string), bool isRequest = default(bool), bool isFuzzyVisit = default(bool), string typeName = "MixedFlexLoad")
        {
            this.LoadId = loadId;
            this.IsRequest = isRequest;
            this.IsFuzzyVisit = isFuzzyVisit;
            // use default value if no "typeName" provided
            this.TypeName = typeName ?? "MixedFlexLoad";
        }

        /// <summary>
        /// Gets or Sets LoadId
        /// </summary>
        [DataMember(Name = "loadId", EmitDefaultValue = false)]
        public string LoadId { get; set; }

        /// <summary>
        /// Gets or Sets IsRequest
        /// </summary>
        [DataMember(Name = "isRequest", EmitDefaultValue = true)]
        public bool IsRequest { get; set; }

        /// <summary>
        /// Gets or Sets IsFuzzyVisit
        /// </summary>
        [DataMember(Name = "isFuzzyVisit", EmitDefaultValue = true)]
        public bool IsFuzzyVisit { get; set; }

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
            sb.Append("class MixedFlexLoadAllOf {\n");
            sb.Append("  LoadId: ").Append(LoadId).Append("\n");
            sb.Append("  IsRequest: ").Append(IsRequest).Append("\n");
            sb.Append("  IsFuzzyVisit: ").Append(IsFuzzyVisit).Append("\n");
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
            return this.Equals(input as MixedFlexLoadAllOf);
        }

        /// <summary>
        /// Returns true if MixedFlexLoadAllOf instances are equal
        /// </summary>
        /// <param name="input">Instance of MixedFlexLoadAllOf to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MixedFlexLoadAllOf input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.LoadId == input.LoadId ||
                    (this.LoadId != null &&
                    this.LoadId.Equals(input.LoadId))
                ) && 
                (
                    this.IsRequest == input.IsRequest ||
                    this.IsRequest.Equals(input.IsRequest)
                ) && 
                (
                    this.IsFuzzyVisit == input.IsFuzzyVisit ||
                    this.IsFuzzyVisit.Equals(input.IsFuzzyVisit)
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
                if (this.LoadId != null)
                {
                    hashCode = (hashCode * 59) + this.LoadId.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.IsRequest.GetHashCode();
                hashCode = (hashCode * 59) + this.IsFuzzyVisit.GetHashCode();
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
