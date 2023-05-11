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
    /// UKPostCodeQualificationAllOf
    /// </summary>
    [DataContract(Name = "UKPostCodeQualification_allOf")]
    public partial class UKPostCodeQualificationAllOf : IEquatable<UKPostCodeQualificationAllOf>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UKPostCodeQualificationAllOf" /> class.
        /// </summary>
        /// <param name="myCode">myCode.</param>
        /// <param name="myExtraCodes">The myExtraCodes.</param>
        /// <param name="typeName">The typeName of the object (default to &quot;UKPostCodeQualification&quot;).</param>
        public UKPostCodeQualificationAllOf(UKPostCode myCode = default(UKPostCode), List<UKPostCode> myExtraCodes = default(List<UKPostCode>), string typeName = "UKPostCodeQualification")
        {
            this.MyCode = myCode;
            this.MyExtraCodes = myExtraCodes;
            // use default value if no "typeName" provided
            this.TypeName = typeName ?? "UKPostCodeQualification";
        }

        /// <summary>
        /// Gets or Sets MyCode
        /// </summary>
        [DataMember(Name = "myCode", EmitDefaultValue = false)]
        public UKPostCode MyCode { get; set; }

        /// <summary>
        /// The myExtraCodes
        /// </summary>
        /// <value>The myExtraCodes</value>
        [DataMember(Name = "myExtraCodes", EmitDefaultValue = false)]
        public List<UKPostCode> MyExtraCodes { get; set; }

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
            sb.Append("class UKPostCodeQualificationAllOf {\n");
            sb.Append("  MyCode: ").Append(MyCode).Append("\n");
            sb.Append("  MyExtraCodes: ").Append(MyExtraCodes).Append("\n");
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
            return this.Equals(input as UKPostCodeQualificationAllOf);
        }

        /// <summary>
        /// Returns true if UKPostCodeQualificationAllOf instances are equal
        /// </summary>
        /// <param name="input">Instance of UKPostCodeQualificationAllOf to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UKPostCodeQualificationAllOf input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.MyCode == input.MyCode ||
                    (this.MyCode != null &&
                    this.MyCode.Equals(input.MyCode))
                ) && 
                (
                    this.MyExtraCodes == input.MyExtraCodes ||
                    this.MyExtraCodes != null &&
                    input.MyExtraCodes != null &&
                    this.MyExtraCodes.SequenceEqual(input.MyExtraCodes)
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
                if (this.MyCode != null)
                {
                    hashCode = (hashCode * 59) + this.MyCode.GetHashCode();
                }
                if (this.MyExtraCodes != null)
                {
                    hashCode = (hashCode * 59) + this.MyExtraCodes.GetHashCode();
                }
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
