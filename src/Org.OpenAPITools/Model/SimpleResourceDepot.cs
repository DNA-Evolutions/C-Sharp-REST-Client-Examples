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
using JsonSubTypes;
using System.ComponentModel.DataAnnotations;
using FileParameter = Org.OpenAPITools.Client.FileParameter;
using OpenAPIDateConverter = Org.OpenAPITools.Client.OpenAPIDateConverter;

namespace Org.OpenAPITools.Model
{
    /// <summary>
    /// SimpleResourceDepot
    /// </summary>
    [DataContract(Name = "SimpleResourceDepot")]
    [JsonConverter(typeof(JsonSubtypes), "TypeName")]
    [JsonSubtypes.KnownSubType(typeof(SimpleResourceDepot), "SimpleResourceDepot")]
    public partial class SimpleResourceDepot : IResourceDepot, IEquatable<SimpleResourceDepot>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleResourceDepot" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SimpleResourceDepot() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleResourceDepot" /> class.
        /// </summary>
        /// <param name="maximalUnitMatchedCapacity">maximalUnitMatchedCapacity.</param>
        /// <param name="capacityUnitMap">capacityUnitMap.</param>
        /// <param name="getPerKilometerCostFactorMap">getPerKilometerCostFactorMap.</param>
        /// <param name="typeName">The typeName of the object (required) (default to &quot;SimpleResourceDepot&quot;).</param>
        /// <param name="emptyAtEndOfRouteFactorMap">emptyAtEndOfRouteFactorMap.</param>
        /// <param name="items">items.</param>
        /// <param name="depotId">depotId.</param>
        /// <param name="maximalTotalCapacity">maximalTotalCapacity.</param>
        public SimpleResourceDepot(double maximalUnitMatchedCapacity = default(double), Dictionary<string, double> capacityUnitMap = default(Dictionary<string, double>), Dictionary<string, int> getPerKilometerCostFactorMap = default(Dictionary<string, int>), string typeName = "SimpleResourceDepot", Dictionary<string, int> emptyAtEndOfRouteFactorMap = default(Dictionary<string, int>), List<ILoadCapacity> items = default(List<ILoadCapacity>), string depotId = default(string), double maximalTotalCapacity = default(double)) : base(items, depotId, maximalTotalCapacity)
        {
            // to ensure "typeName" is required (not null)
            if (typeName == null)
            {
                throw new ArgumentNullException("typeName is a required property for SimpleResourceDepot and cannot be null");
            }
            this.TypeName = typeName;
            this.MaximalUnitMatchedCapacity = maximalUnitMatchedCapacity;
            this.CapacityUnitMap = capacityUnitMap;
            this.GetPerKilometerCostFactorMap = getPerKilometerCostFactorMap;
            this.EmptyAtEndOfRouteFactorMap = emptyAtEndOfRouteFactorMap;
        }

        /// <summary>
        /// Gets or Sets MaximalUnitMatchedCapacity
        /// </summary>
        [DataMember(Name = "maximalUnitMatchedCapacity", EmitDefaultValue = false)]
        public double MaximalUnitMatchedCapacity { get; set; }

        /// <summary>
        /// Gets or Sets CapacityUnitMap
        /// </summary>
        [DataMember(Name = "capacityUnitMap", EmitDefaultValue = false)]
        public Dictionary<string, double> CapacityUnitMap { get; set; }

        /// <summary>
        /// Gets or Sets GetPerKilometerCostFactorMap
        /// </summary>
        [DataMember(Name = "getPerKilometerCostFactorMap", EmitDefaultValue = false)]
        public Dictionary<string, int> GetPerKilometerCostFactorMap { get; set; }

        /// <summary>
        /// The typeName of the object
        /// </summary>
        /// <value>The typeName of the object</value>
        [DataMember(Name = "typeName", IsRequired = true, EmitDefaultValue = false)]
        public string TypeName { get; set; }

        /// <summary>
        /// Gets or Sets EmptyAtEndOfRouteFactorMap
        /// </summary>
        [DataMember(Name = "emptyAtEndOfRouteFactorMap", EmitDefaultValue = false)]
        public Dictionary<string, int> EmptyAtEndOfRouteFactorMap { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SimpleResourceDepot {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  MaximalUnitMatchedCapacity: ").Append(MaximalUnitMatchedCapacity).Append("\n");
            sb.Append("  CapacityUnitMap: ").Append(CapacityUnitMap).Append("\n");
            sb.Append("  GetPerKilometerCostFactorMap: ").Append(GetPerKilometerCostFactorMap).Append("\n");
            sb.Append("  TypeName: ").Append(TypeName).Append("\n");
            sb.Append("  EmptyAtEndOfRouteFactorMap: ").Append(EmptyAtEndOfRouteFactorMap).Append("\n");
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
            return this.Equals(input as SimpleResourceDepot);
        }

        /// <summary>
        /// Returns true if SimpleResourceDepot instances are equal
        /// </summary>
        /// <param name="input">Instance of SimpleResourceDepot to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SimpleResourceDepot input)
        {
            if (input == null)
            {
                return false;
            }
            return base.Equals(input) && 
                (
                    this.MaximalUnitMatchedCapacity == input.MaximalUnitMatchedCapacity ||
                    this.MaximalUnitMatchedCapacity.Equals(input.MaximalUnitMatchedCapacity)
                ) && base.Equals(input) && 
                (
                    this.CapacityUnitMap == input.CapacityUnitMap ||
                    this.CapacityUnitMap != null &&
                    input.CapacityUnitMap != null &&
                    this.CapacityUnitMap.SequenceEqual(input.CapacityUnitMap)
                ) && base.Equals(input) && 
                (
                    this.GetPerKilometerCostFactorMap == input.GetPerKilometerCostFactorMap ||
                    this.GetPerKilometerCostFactorMap != null &&
                    input.GetPerKilometerCostFactorMap != null &&
                    this.GetPerKilometerCostFactorMap.SequenceEqual(input.GetPerKilometerCostFactorMap)
                ) && base.Equals(input) && 
                (
                    this.TypeName == input.TypeName ||
                    (this.TypeName != null &&
                    this.TypeName.Equals(input.TypeName))
                ) && base.Equals(input) && 
                (
                    this.EmptyAtEndOfRouteFactorMap == input.EmptyAtEndOfRouteFactorMap ||
                    this.EmptyAtEndOfRouteFactorMap != null &&
                    input.EmptyAtEndOfRouteFactorMap != null &&
                    this.EmptyAtEndOfRouteFactorMap.SequenceEqual(input.EmptyAtEndOfRouteFactorMap)
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
                hashCode = (hashCode * 59) + this.MaximalUnitMatchedCapacity.GetHashCode();
                if (this.CapacityUnitMap != null)
                {
                    hashCode = (hashCode * 59) + this.CapacityUnitMap.GetHashCode();
                }
                if (this.GetPerKilometerCostFactorMap != null)
                {
                    hashCode = (hashCode * 59) + this.GetPerKilometerCostFactorMap.GetHashCode();
                }
                if (this.TypeName != null)
                {
                    hashCode = (hashCode * 59) + this.TypeName.GetHashCode();
                }
                if (this.EmptyAtEndOfRouteFactorMap != null)
                {
                    hashCode = (hashCode * 59) + this.EmptyAtEndOfRouteFactorMap.GetHashCode();
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