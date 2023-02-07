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
    /// ZoneNumberConstraint
    /// </summary>
    [DataContract(Name = "ZoneNumberConstraint")]
    [JsonConverter(typeof(JsonSubtypes), "TypeName")]
    [JsonSubtypes.KnownSubType(typeof(BindingResourceConstraint), "BindingResource")]
    [JsonSubtypes.KnownSubType(typeof(ConnectedConstraint), "ConnectedConstraint")]
    [JsonSubtypes.KnownSubType(typeof(ExcludingResourceConstraint), "ExcludingResource")]
    [JsonSubtypes.KnownSubType(typeof(NodeColorMultiRouteConstraint), "NodeColorMultiRouteConstraint")]
    [JsonSubtypes.KnownSubType(typeof(ResourceLocationConstraint), "ResourceLocationConstraint")]
    [JsonSubtypes.KnownSubType(typeof(TypeConstraint), "Type")]
    [JsonSubtypes.KnownSubType(typeof(TypeWithExpertiseConstraint), "TypeWithExpertise")]
    [JsonSubtypes.KnownSubType(typeof(UKPostCodeConstraint), "UKPostCodeConstraint")]
    [JsonSubtypes.KnownSubType(typeof(ZoneNumberConstraint), "ZoneNumberConstraint")]
    public partial class ZoneNumberConstraint : ConstraintType, IEquatable<ZoneNumberConstraint>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZoneNumberConstraint" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ZoneNumberConstraint() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ZoneNumberConstraint" /> class.
        /// </summary>
        /// <param name="zoneCodes">The zoneCodes (required).</param>
        /// <param name="typeName">The typeName of the object (required) (default to &quot;ZoneNumberConstraint&quot;).</param>
        public ZoneNumberConstraint(List<ZoneNumber> zoneCodes = default(List<ZoneNumber>), string typeName = "ZoneNumberConstraint") : base()
        {
            // to ensure "zoneCodes" is required (not null)
            if (zoneCodes == null)
            {
                throw new ArgumentNullException("zoneCodes is a required property for ZoneNumberConstraint and cannot be null");
            }
            this.ZoneCodes = zoneCodes;
            // to ensure "typeName" is required (not null)
            if (typeName == null)
            {
                throw new ArgumentNullException("typeName is a required property for ZoneNumberConstraint and cannot be null");
            }
            this.TypeName = typeName;
        }

        /// <summary>
        /// The zoneCodes
        /// </summary>
        /// <value>The zoneCodes</value>
        [DataMember(Name = "zoneCodes", IsRequired = true, EmitDefaultValue = false)]
        public List<ZoneNumber> ZoneCodes { get; set; }

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
            sb.Append("class ZoneNumberConstraint {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  ZoneCodes: ").Append(ZoneCodes).Append("\n");
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
            return this.Equals(input as ZoneNumberConstraint);
        }

        /// <summary>
        /// Returns true if ZoneNumberConstraint instances are equal
        /// </summary>
        /// <param name="input">Instance of ZoneNumberConstraint to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ZoneNumberConstraint input)
        {
            if (input == null)
            {
                return false;
            }
            return base.Equals(input) && 
                (
                    this.ZoneCodes == input.ZoneCodes ||
                    this.ZoneCodes != null &&
                    input.ZoneCodes != null &&
                    this.ZoneCodes.SequenceEqual(input.ZoneCodes)
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
                if (this.ZoneCodes != null)
                {
                    hashCode = (hashCode * 59) + this.ZoneCodes.GetHashCode();
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
