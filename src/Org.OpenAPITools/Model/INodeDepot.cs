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
    /// The NodeDepot type
    /// </summary>
    [DataContract(Name = "INodeDepot")]
    [JsonConverter(typeof(JsonSubtypes), "TypeName")]
    [JsonSubtypes.KnownSubType(typeof(SimpleNodeDepot), "SimpleNodeDepot")]
    public partial class INodeDepot : IEquatable<INodeDepot>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="INodeDepot" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected INodeDepot() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="INodeDepot" /> class.
        /// </summary>
        /// <param name="items">items.</param>
        /// <param name="hasTimedLoads">hasTimedLoads.</param>
        /// <param name="depotId">depotId.</param>
        /// <param name="hasFlexLoad">hasFlexLoad.</param>
        /// <param name="typeName">typeName (required).</param>
        public INodeDepot(List<ILoad> items = default(List<ILoad>), bool hasTimedLoads = default(bool), string depotId = default(string), bool hasFlexLoad = default(bool), string typeName = default(string))
        {
            // to ensure "typeName" is required (not null)
            if (typeName == null)
            {
                throw new ArgumentNullException("typeName is a required property for INodeDepot and cannot be null");
            }
            this.TypeName = typeName;
            this.Items = items;
            this.HasTimedLoads = hasTimedLoads;
            this.DepotId = depotId;
            this.HasFlexLoad = hasFlexLoad;
        }

        /// <summary>
        /// Gets or Sets Items
        /// </summary>
        [DataMember(Name = "items", EmitDefaultValue = false)]
        public List<ILoad> Items { get; set; }

        /// <summary>
        /// Gets or Sets HasTimedLoads
        /// </summary>
        [DataMember(Name = "hasTimedLoads", EmitDefaultValue = true)]
        public bool HasTimedLoads { get; set; }

        /// <summary>
        /// Gets or Sets DepotId
        /// </summary>
        [DataMember(Name = "depotId", EmitDefaultValue = false)]
        public string DepotId { get; set; }

        /// <summary>
        /// Gets or Sets HasFlexLoad
        /// </summary>
        [DataMember(Name = "hasFlexLoad", EmitDefaultValue = true)]
        public bool HasFlexLoad { get; set; }

        /// <summary>
        /// Gets or Sets TypeName
        /// </summary>
        [DataMember(Name = "typeName", IsRequired = true, EmitDefaultValue = false)]
        public string TypeName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class INodeDepot {\n");
            sb.Append("  Items: ").Append(Items).Append("\n");
            sb.Append("  HasTimedLoads: ").Append(HasTimedLoads).Append("\n");
            sb.Append("  DepotId: ").Append(DepotId).Append("\n");
            sb.Append("  HasFlexLoad: ").Append(HasFlexLoad).Append("\n");
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
            return this.Equals(input as INodeDepot);
        }

        /// <summary>
        /// Returns true if INodeDepot instances are equal
        /// </summary>
        /// <param name="input">Instance of INodeDepot to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(INodeDepot input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Items == input.Items ||
                    this.Items != null &&
                    input.Items != null &&
                    this.Items.SequenceEqual(input.Items)
                ) && 
                (
                    this.HasTimedLoads == input.HasTimedLoads ||
                    this.HasTimedLoads.Equals(input.HasTimedLoads)
                ) && 
                (
                    this.DepotId == input.DepotId ||
                    (this.DepotId != null &&
                    this.DepotId.Equals(input.DepotId))
                ) && 
                (
                    this.HasFlexLoad == input.HasFlexLoad ||
                    this.HasFlexLoad.Equals(input.HasFlexLoad)
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
                if (this.Items != null)
                {
                    hashCode = (hashCode * 59) + this.Items.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.HasTimedLoads.GetHashCode();
                if (this.DepotId != null)
                {
                    hashCode = (hashCode * 59) + this.DepotId.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.HasFlexLoad.GetHashCode();
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
            yield break;
        }
    }

}
