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
    /// The LoadCapacity type
    /// </summary>
    [DataContract(Name = "ILoadCapacity")]
    [JsonConverter(typeof(JsonSubtypes), "TypeName")]
    [JsonSubtypes.KnownSubType(typeof(DegradingLoadCapacity), "DegradingLoadCapacity")]
    [JsonSubtypes.KnownSubType(typeof(SimpleLoadCapacity), "SimpleLoadCapacity")]
    public partial class ILoadCapacity : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ILoadCapacity" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ILoadCapacity() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ILoadCapacity" /> class.
        /// </summary>
        /// <param name="maximalIndividualLoadCapacity">maximalIndividualLoadCapacity.</param>
        /// <param name="loadPickupTime">loadPickupTime.</param>
        /// <param name="currentLoad">currentLoad.</param>
        /// <param name="id">id.</param>
        /// <param name="typeName">typeName (required).</param>
        public ILoadCapacity(double maximalIndividualLoadCapacity = default(double), long loadPickupTime = default(long), double currentLoad = default(double), string id = default(string), string typeName = default(string))
        {
            // to ensure "typeName" is required (not null)
            if (typeName == null)
            {
                throw new ArgumentNullException("typeName is a required property for ILoadCapacity and cannot be null");
            }
            this.TypeName = typeName;
            this.MaximalIndividualLoadCapacity = maximalIndividualLoadCapacity;
            this.LoadPickupTime = loadPickupTime;
            this.CurrentLoad = currentLoad;
            this.Id = id;
        }

        /// <summary>
        /// Gets or Sets MaximalIndividualLoadCapacity
        /// </summary>
        [DataMember(Name = "maximalIndividualLoadCapacity", EmitDefaultValue = false)]
        public double MaximalIndividualLoadCapacity { get; set; }

        /// <summary>
        /// Gets or Sets LoadPickupTime
        /// </summary>
        [DataMember(Name = "loadPickupTime", EmitDefaultValue = false)]
        public long LoadPickupTime { get; set; }

        /// <summary>
        /// Gets or Sets CurrentLoad
        /// </summary>
        [DataMember(Name = "currentLoad", EmitDefaultValue = false)]
        public double CurrentLoad { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets TypeName
        /// </summary>
        [DataMember(Name = "typeName", IsRequired = true, EmitDefaultValue = true)]
        public string TypeName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ILoadCapacity {\n");
            sb.Append("  MaximalIndividualLoadCapacity: ").Append(MaximalIndividualLoadCapacity).Append("\n");
            sb.Append("  LoadPickupTime: ").Append(LoadPickupTime).Append("\n");
            sb.Append("  CurrentLoad: ").Append(CurrentLoad).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
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
            yield break;
        }
    }

}
