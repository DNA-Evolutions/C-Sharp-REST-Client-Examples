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
    /// The connectionRelatedLateMargin
    /// </summary>
    [DataContract(Name = "ConnectionRelatedLateMargin")]
    public partial class ConnectionRelatedLateMargin : IEquatable<ConnectionRelatedLateMargin>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionRelatedLateMargin" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ConnectionRelatedLateMargin() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionRelatedLateMargin" /> class.
        /// </summary>
        /// <param name="shiftElementConnectionRealtedLateMargin">The isDoElementShiftConnectionRealtedLateMargin.</param>
        /// <param name="applyPartialConnectionRelatedLateMargin">The applyPartialConnectionRelatedLateMargin.</param>
        /// <param name="maxMargin">The maxMargin (required).</param>
        /// <param name="marginFactor">The marginFactor between 0 (inclusive) and 1 (inclusive) (required).</param>
        public ConnectionRelatedLateMargin(bool shiftElementConnectionRealtedLateMargin = default(bool), bool applyPartialConnectionRelatedLateMargin = default(bool), string maxMargin = default(string), double marginFactor = default(double))
        {
            // to ensure "maxMargin" is required (not null)
            if (maxMargin == null)
            {
                throw new ArgumentNullException("maxMargin is a required property for ConnectionRelatedLateMargin and cannot be null");
            }
            this.MaxMargin = maxMargin;
            this.MarginFactor = marginFactor;
            this.ShiftElementConnectionRealtedLateMargin = shiftElementConnectionRealtedLateMargin;
            this.ApplyPartialConnectionRelatedLateMargin = applyPartialConnectionRelatedLateMargin;
        }

        /// <summary>
        /// The isDoElementShiftConnectionRealtedLateMargin
        /// </summary>
        /// <value>The isDoElementShiftConnectionRealtedLateMargin</value>
        [DataMember(Name = "shiftElementConnectionRealtedLateMargin", EmitDefaultValue = true)]
        public bool ShiftElementConnectionRealtedLateMargin { get; set; }

        /// <summary>
        /// The applyPartialConnectionRelatedLateMargin
        /// </summary>
        /// <value>The applyPartialConnectionRelatedLateMargin</value>
        [DataMember(Name = "applyPartialConnectionRelatedLateMargin", EmitDefaultValue = true)]
        public bool ApplyPartialConnectionRelatedLateMargin { get; set; }

        /// <summary>
        /// The maxMargin
        /// </summary>
        /// <value>The maxMargin</value>
        [DataMember(Name = "maxMargin", IsRequired = true, EmitDefaultValue = false)]
        public string MaxMargin { get; set; }

        /// <summary>
        /// The marginFactor between 0 (inclusive) and 1 (inclusive)
        /// </summary>
        /// <value>The marginFactor between 0 (inclusive) and 1 (inclusive)</value>
        [DataMember(Name = "marginFactor", IsRequired = true, EmitDefaultValue = false)]
        public double MarginFactor { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ConnectionRelatedLateMargin {\n");
            sb.Append("  ShiftElementConnectionRealtedLateMargin: ").Append(ShiftElementConnectionRealtedLateMargin).Append("\n");
            sb.Append("  ApplyPartialConnectionRelatedLateMargin: ").Append(ApplyPartialConnectionRelatedLateMargin).Append("\n");
            sb.Append("  MaxMargin: ").Append(MaxMargin).Append("\n");
            sb.Append("  MarginFactor: ").Append(MarginFactor).Append("\n");
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
            return this.Equals(input as ConnectionRelatedLateMargin);
        }

        /// <summary>
        /// Returns true if ConnectionRelatedLateMargin instances are equal
        /// </summary>
        /// <param name="input">Instance of ConnectionRelatedLateMargin to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ConnectionRelatedLateMargin input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.ShiftElementConnectionRealtedLateMargin == input.ShiftElementConnectionRealtedLateMargin ||
                    this.ShiftElementConnectionRealtedLateMargin.Equals(input.ShiftElementConnectionRealtedLateMargin)
                ) && 
                (
                    this.ApplyPartialConnectionRelatedLateMargin == input.ApplyPartialConnectionRelatedLateMargin ||
                    this.ApplyPartialConnectionRelatedLateMargin.Equals(input.ApplyPartialConnectionRelatedLateMargin)
                ) && 
                (
                    this.MaxMargin == input.MaxMargin ||
                    (this.MaxMargin != null &&
                    this.MaxMargin.Equals(input.MaxMargin))
                ) && 
                (
                    this.MarginFactor == input.MarginFactor ||
                    this.MarginFactor.Equals(input.MarginFactor)
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
                hashCode = (hashCode * 59) + this.ShiftElementConnectionRealtedLateMargin.GetHashCode();
                hashCode = (hashCode * 59) + this.ApplyPartialConnectionRelatedLateMargin.GetHashCode();
                if (this.MaxMargin != null)
                {
                    hashCode = (hashCode * 59) + this.MaxMargin.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.MarginFactor.GetHashCode();
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
