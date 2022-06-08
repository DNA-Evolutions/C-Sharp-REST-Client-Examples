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
    /// The myExtraCodes
    /// </summary>
    [DataContract(Name = "ZoneNumber")]
    public partial class ZoneNumber : IEquatable<ZoneNumber>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZoneNumber" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ZoneNumber() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ZoneNumber" /> class.
        /// </summary>
        /// <param name="zoneNumber">The zoneNumber (required).</param>
        /// <param name="typeName">The typeName of the object (required) (default to &quot;ZoneNumber&quot;).</param>
        public ZoneNumber(int zoneNumber = default(int), string typeName = "ZoneNumber")
        {
            this._ZoneNumber = zoneNumber;
            // to ensure "typeName" is required (not null)
            if (typeName == null)
            {
                throw new ArgumentNullException("typeName is a required property for ZoneNumber and cannot be null");
            }
            this.TypeName = typeName;
        }

        /// <summary>
        /// The zoneNumber
        /// </summary>
        /// <value>The zoneNumber</value>
        [DataMember(Name = "zoneNumber", IsRequired = true, EmitDefaultValue = false)]
        public int _ZoneNumber { get; set; }

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
            sb.Append("class ZoneNumber {\n");
            sb.Append("  _ZoneNumber: ").Append(_ZoneNumber).Append("\n");
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
            return this.Equals(input as ZoneNumber);
        }

        /// <summary>
        /// Returns true if ZoneNumber instances are equal
        /// </summary>
        /// <param name="input">Instance of ZoneNumber to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ZoneNumber input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this._ZoneNumber == input._ZoneNumber ||
                    this._ZoneNumber.Equals(input._ZoneNumber)
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
                hashCode = (hashCode * 59) + this._ZoneNumber.GetHashCode();
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
