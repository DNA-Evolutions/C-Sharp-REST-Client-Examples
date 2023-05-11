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
using JsonSubTypes;
using System.ComponentModel.DataAnnotations;
using FileParameter = Org.OpenAPITools.Client.FileParameter;
using OpenAPIDateConverter = Org.OpenAPITools.Client.OpenAPIDateConverter;

namespace Org.OpenAPITools.Model
{
    /// <summary>
    /// TimeWindowNodeRelation
    /// </summary>
    [DataContract(Name = "TimeWindowNodeRelation")]
    [JsonConverter(typeof(JsonSubtypes), "TypeName")]
    [JsonSubtypes.KnownSubType(typeof(DifferentVisitorNodeRelation), "DifferentVisitor")]
    [JsonSubtypes.KnownSubType(typeof(MultiTimeWindowNodeRelation), "MultiTimeWindow")]
    [JsonSubtypes.KnownSubType(typeof(SameVisitorNodeRelation), "SameVisitor")]
    [JsonSubtypes.KnownSubType(typeof(TimeWindowNodeRelation), "TimeWindow")]
    public partial class TimeWindowNodeRelation : NodeRelationType, IEquatable<TimeWindowNodeRelation>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeWindowNodeRelation" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TimeWindowNodeRelation() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeWindowNodeRelation" /> class.
        /// </summary>
        /// <param name="minTimeDeviation">The minTimeDeviation defines the minimal time of the relation. (required).</param>
        /// <param name="maxTimeDeviation">The maxTimeDeviation defines the minimal time of the relation. (required).</param>
        /// <param name="timeComparisonJuncture">timeComparisonJuncture.</param>
        /// <param name="typeName">The typeName of the object (required) (default to &quot;TimeWindow&quot;).</param>
        public TimeWindowNodeRelation(string minTimeDeviation = default(string), string maxTimeDeviation = default(string), TimeComparisonJuncture timeComparisonJuncture = default(TimeComparisonJuncture), string typeName = "TimeWindow") : base()
        {
            // to ensure "minTimeDeviation" is required (not null)
            if (minTimeDeviation == null)
            {
                throw new ArgumentNullException("minTimeDeviation is a required property for TimeWindowNodeRelation and cannot be null");
            }
            this.MinTimeDeviation = minTimeDeviation;
            // to ensure "maxTimeDeviation" is required (not null)
            if (maxTimeDeviation == null)
            {
                throw new ArgumentNullException("maxTimeDeviation is a required property for TimeWindowNodeRelation and cannot be null");
            }
            this.MaxTimeDeviation = maxTimeDeviation;
            // to ensure "typeName" is required (not null)
            if (typeName == null)
            {
                throw new ArgumentNullException("typeName is a required property for TimeWindowNodeRelation and cannot be null");
            }
            this.TypeName = typeName;
            this.TimeComparisonJuncture = timeComparisonJuncture;
        }

        /// <summary>
        /// The minTimeDeviation defines the minimal time of the relation.
        /// </summary>
        /// <value>The minTimeDeviation defines the minimal time of the relation.</value>
        [DataMember(Name = "minTimeDeviation", IsRequired = true, EmitDefaultValue = false)]
        public string MinTimeDeviation { get; set; }

        /// <summary>
        /// The maxTimeDeviation defines the minimal time of the relation.
        /// </summary>
        /// <value>The maxTimeDeviation defines the minimal time of the relation.</value>
        [DataMember(Name = "maxTimeDeviation", IsRequired = true, EmitDefaultValue = false)]
        public string MaxTimeDeviation { get; set; }

        /// <summary>
        /// Gets or Sets TimeComparisonJuncture
        /// </summary>
        [DataMember(Name = "timeComparisonJuncture", EmitDefaultValue = false)]
        public TimeComparisonJuncture TimeComparisonJuncture { get; set; }

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
            sb.Append("class TimeWindowNodeRelation {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  MinTimeDeviation: ").Append(MinTimeDeviation).Append("\n");
            sb.Append("  MaxTimeDeviation: ").Append(MaxTimeDeviation).Append("\n");
            sb.Append("  TimeComparisonJuncture: ").Append(TimeComparisonJuncture).Append("\n");
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
            return this.Equals(input as TimeWindowNodeRelation);
        }

        /// <summary>
        /// Returns true if TimeWindowNodeRelation instances are equal
        /// </summary>
        /// <param name="input">Instance of TimeWindowNodeRelation to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TimeWindowNodeRelation input)
        {
            if (input == null)
            {
                return false;
            }
            return base.Equals(input) && 
                (
                    this.MinTimeDeviation == input.MinTimeDeviation ||
                    (this.MinTimeDeviation != null &&
                    this.MinTimeDeviation.Equals(input.MinTimeDeviation))
                ) && base.Equals(input) && 
                (
                    this.MaxTimeDeviation == input.MaxTimeDeviation ||
                    (this.MaxTimeDeviation != null &&
                    this.MaxTimeDeviation.Equals(input.MaxTimeDeviation))
                ) && base.Equals(input) && 
                (
                    this.TimeComparisonJuncture == input.TimeComparisonJuncture ||
                    (this.TimeComparisonJuncture != null &&
                    this.TimeComparisonJuncture.Equals(input.TimeComparisonJuncture))
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
                if (this.MinTimeDeviation != null)
                {
                    hashCode = (hashCode * 59) + this.MinTimeDeviation.GetHashCode();
                }
                if (this.MaxTimeDeviation != null)
                {
                    hashCode = (hashCode * 59) + this.MaxTimeDeviation.GetHashCode();
                }
                if (this.TimeComparisonJuncture != null)
                {
                    hashCode = (hashCode * 59) + this.TimeComparisonJuncture.GetHashCode();
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
