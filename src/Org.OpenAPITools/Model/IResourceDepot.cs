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
    /// The ResourceDepot type
    /// </summary>
    [DataContract(Name = "IResourceDepot")]
    [JsonConverter(typeof(JsonSubtypes), "TypeName")]
    [JsonSubtypes.KnownSubType(typeof(SimpleResourceDepot), "SimpleResourceDepot")]
    public partial class IResourceDepot : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IResourceDepot" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected IResourceDepot() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="IResourceDepot" /> class.
        /// </summary>
        /// <param name="items">items.</param>
        /// <param name="maximalTotalCapacity">maximalTotalCapacity.</param>
        /// <param name="depotId">depotId.</param>
        /// <param name="capacityUnitMap">capacityUnitMap.</param>
        /// <param name="typeName">typeName (required).</param>
        public IResourceDepot(List<ILoadCapacity> items = default(List<ILoadCapacity>), double maximalTotalCapacity = default(double), string depotId = default(string), Dictionary<string, double> capacityUnitMap = default(Dictionary<string, double>), string typeName = default(string))
        {
            // to ensure "typeName" is required (not null)
            if (typeName == null)
            {
                throw new ArgumentNullException("typeName is a required property for IResourceDepot and cannot be null");
            }
            this.TypeName = typeName;
            this.Items = items;
            this.MaximalTotalCapacity = maximalTotalCapacity;
            this.DepotId = depotId;
            this.CapacityUnitMap = capacityUnitMap;
        }

        /// <summary>
        /// Gets or Sets Items
        /// </summary>
        [DataMember(Name = "items", EmitDefaultValue = false)]
        public List<ILoadCapacity> Items { get; set; }

        /// <summary>
        /// Gets or Sets MaximalTotalCapacity
        /// </summary>
        [DataMember(Name = "maximalTotalCapacity", EmitDefaultValue = false)]
        public double MaximalTotalCapacity { get; set; }

        /// <summary>
        /// Gets or Sets DepotId
        /// </summary>
        [DataMember(Name = "depotId", EmitDefaultValue = false)]
        public string DepotId { get; set; }

        /// <summary>
        /// Gets or Sets CapacityUnitMap
        /// </summary>
        [DataMember(Name = "capacityUnitMap", EmitDefaultValue = false)]
        public Dictionary<string, double> CapacityUnitMap { get; set; }

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
            sb.Append("class IResourceDepot {\n");
            sb.Append("  Items: ").Append(Items).Append("\n");
            sb.Append("  MaximalTotalCapacity: ").Append(MaximalTotalCapacity).Append("\n");
            sb.Append("  DepotId: ").Append(DepotId).Append("\n");
            sb.Append("  CapacityUnitMap: ").Append(CapacityUnitMap).Append("\n");
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
