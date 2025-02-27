/*
 * DNA Evolutions - JOpt.TourOptimizer
 *
 * This is DNA's JOpt.TourOptimizer service. A RESTful Spring Boot application using springdoc-openapi and OpenAPI 3. JOpt.TourOptimizer is a service that delivers route optimization and automatic scheduling features to be easily integrated into any third-party application. JOpt.TourOptimizer encapsulates all necessary optimization functionality and provides a comprehensive REST API that offers a domain-specific optimization interface for the transportation industry. The service is stateless and does not come with graphical user interfaces, map depiction or any databases. These extensions and adjustments are supposed to be introduced by the consumer of the service while integrating it into his/her own application. The service will allow for many suitable adjustments and user-specific settings to adjust the behaviour and optimization goals (e.g. minimizing distance, maximizing resource utilization, etc.) through a comprehensive set of functions. This will enable you to gain control of the complete optimization processes.This service is based on JOpt (7.5.1-rc3-j17-SNAPSHOT)
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
using JsonSubTypes;
using System.ComponentModel.DataAnnotations;
using FileParameter = Org.OpenAPITools.Client.FileParameter;
using OpenAPIDateConverter = Org.OpenAPITools.Client.OpenAPIDateConverter;

namespace Org.OpenAPITools.Model
{
    /// <summary>
    /// DegradingLoadCapacity
    /// </summary>
    [DataContract(Name = "DegradingLoadCapacity")]
    public partial class DegradingLoadCapacity : ILoadCapacity, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DegradingLoadCapacity" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected DegradingLoadCapacity() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DegradingLoadCapacity" /> class.
        /// </summary>
        /// <param name="loadCapacityId">loadCapacityId.</param>
        /// <param name="maxCapacityValue">maxCapacityValue.</param>
        /// <param name="capacityDegradationPerStop">capacityDegradationPerStop.</param>
        /// <param name="minimalTotaDegradatedCapacity">minimalTotaDegradatedCapacity.</param>
        /// <param name="typeName">The typeName of the object (required) (default to &quot;DegradingLoadCapacity&quot;).</param>
        /// <param name="maximalIndividualLoadCapacity">maximalIndividualLoadCapacity.</param>
        /// <param name="loadPickupTime">loadPickupTime.</param>
        /// <param name="currentLoad">currentLoad.</param>
        /// <param name="id">id.</param>
        public DegradingLoadCapacity(string loadCapacityId = default(string), int maxCapacityValue = default(int), double capacityDegradationPerStop = default(double), double minimalTotaDegradatedCapacity = default(double), string typeName = @"DegradingLoadCapacity", double maximalIndividualLoadCapacity = default(double), long loadPickupTime = default(long), double currentLoad = default(double), string id = default(string)) : base(maximalIndividualLoadCapacity, loadPickupTime, currentLoad, id)
        {
            // to ensure "typeName" is required (not null)
            if (typeName == null)
            {
                throw new ArgumentNullException("typeName is a required property for DegradingLoadCapacity and cannot be null");
            }
            this.TypeName = typeName;
            this.LoadCapacityId = loadCapacityId;
            this.MaxCapacityValue = maxCapacityValue;
            this.CapacityDegradationPerStop = capacityDegradationPerStop;
            this.MinimalTotaDegradatedCapacity = minimalTotaDegradatedCapacity;
        }

        /// <summary>
        /// Gets or Sets LoadCapacityId
        /// </summary>
        [DataMember(Name = "loadCapacityId", EmitDefaultValue = false)]
        public string LoadCapacityId { get; set; }

        /// <summary>
        /// Gets or Sets MaxCapacityValue
        /// </summary>
        [DataMember(Name = "maxCapacityValue", EmitDefaultValue = false)]
        public int MaxCapacityValue { get; set; }

        /// <summary>
        /// Gets or Sets CapacityDegradationPerStop
        /// </summary>
        [DataMember(Name = "capacityDegradationPerStop", EmitDefaultValue = false)]
        public double CapacityDegradationPerStop { get; set; }

        /// <summary>
        /// Gets or Sets MinimalTotaDegradatedCapacity
        /// </summary>
        [DataMember(Name = "minimalTotaDegradatedCapacity", EmitDefaultValue = false)]
        public double MinimalTotaDegradatedCapacity { get; set; }

        /// <summary>
        /// The typeName of the object
        /// </summary>
        /// <value>The typeName of the object</value>
        /*
        <example>DegradingLoadCapacity</example>
        */
        [DataMember(Name = "typeName", IsRequired = true, EmitDefaultValue = true)]
        public string TypeName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class DegradingLoadCapacity {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  LoadCapacityId: ").Append(LoadCapacityId).Append("\n");
            sb.Append("  MaxCapacityValue: ").Append(MaxCapacityValue).Append("\n");
            sb.Append("  CapacityDegradationPerStop: ").Append(CapacityDegradationPerStop).Append("\n");
            sb.Append("  MinimalTotaDegradatedCapacity: ").Append(MinimalTotaDegradatedCapacity).Append("\n");
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
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            return this.BaseValidate(validationContext);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        protected IEnumerable<ValidationResult> BaseValidate(ValidationContext validationContext)
        {
            foreach (var x in base.BaseValidate(validationContext))
            {
                yield return x;
            }
            yield break;
        }
    }

}
