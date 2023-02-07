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
using JsonSubTypes;
using System.ComponentModel.DataAnnotations;
using FileParameter = Org.OpenAPITools.Client.FileParameter;
using OpenAPIDateConverter = Org.OpenAPITools.Client.OpenAPIDateConverter;

namespace Org.OpenAPITools.Model
{
    /// <summary>
    /// UKPostCodeQualification
    /// </summary>
    [DataContract(Name = "UKPostCodeQualification")]
    [JsonConverter(typeof(JsonSubtypes), "TypeName")]
    [JsonSubtypes.KnownSubType(typeof(TypeQualification), "Type")]
    [JsonSubtypes.KnownSubType(typeof(TypeWithExpertiseQualification), "TypeWithExpertise")]
    [JsonSubtypes.KnownSubType(typeof(UKPostCodeQualification), "UKPostCodeQualification")]
    [JsonSubtypes.KnownSubType(typeof(ZoneNumberQualification), "ZoneNumberQualification")]
    public partial class UKPostCodeQualification : QualificationType, IEquatable<UKPostCodeQualification>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UKPostCodeQualification" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected UKPostCodeQualification() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="UKPostCodeQualification" /> class.
        /// </summary>
        /// <param name="myCode">myCode (required).</param>
        /// <param name="myExtraCodes">The myExtraCodes.</param>
        /// <param name="typeName">The typeName of the object (required) (default to &quot;UKPostCodeQualification&quot;).</param>
        public UKPostCodeQualification(UKPostCode myCode = default(UKPostCode), List<UKPostCode> myExtraCodes = default(List<UKPostCode>), string typeName = "UKPostCodeQualification") : base()
        {
            // to ensure "myCode" is required (not null)
            if (myCode == null)
            {
                throw new ArgumentNullException("myCode is a required property for UKPostCodeQualification and cannot be null");
            }
            this.MyCode = myCode;
            // to ensure "typeName" is required (not null)
            if (typeName == null)
            {
                throw new ArgumentNullException("typeName is a required property for UKPostCodeQualification and cannot be null");
            }
            this.TypeName = typeName;
            this.MyExtraCodes = myExtraCodes;
        }

        /// <summary>
        /// Gets or Sets MyCode
        /// </summary>
        [DataMember(Name = "myCode", IsRequired = true, EmitDefaultValue = false)]
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
        [DataMember(Name = "typeName", IsRequired = true, EmitDefaultValue = false)]
        public string TypeName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UKPostCodeQualification {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
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
        public override string ToJson()
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
            return this.Equals(input as UKPostCodeQualification);
        }

        /// <summary>
        /// Returns true if UKPostCodeQualification instances are equal
        /// </summary>
        /// <param name="input">Instance of UKPostCodeQualification to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UKPostCodeQualification input)
        {
            if (input == null)
            {
                return false;
            }
            return base.Equals(input) && 
                (
                    this.MyCode == input.MyCode ||
                    (this.MyCode != null &&
                    this.MyCode.Equals(input.MyCode))
                ) && base.Equals(input) && 
                (
                    this.MyExtraCodes == input.MyExtraCodes ||
                    this.MyExtraCodes != null &&
                    input.MyExtraCodes != null &&
                    this.MyExtraCodes.SequenceEqual(input.MyExtraCodes)
                ) && base.Equals(input) && 
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
                int hashCode = base.GetHashCode();
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
            return this.BaseValidate(validationContext);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        protected IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> BaseValidate(ValidationContext validationContext)
        {
            foreach (var x in BaseValidate(validationContext))
            {
                yield return x;
            }
            yield break;
        }
    }

}
