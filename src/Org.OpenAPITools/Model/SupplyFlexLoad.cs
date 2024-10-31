/*
 * DNA Evolutions - JOpt.TourOptimizer
 *
 * This is DNA's JOpt.TourOptimizer service. A RESTful Spring Boot application using springdoc-openapi and OpenAPI 3. JOpt.TourOpptimizer is a service that delivers route optimization and automatic scheduling features to be easily integrated into any third-party application. JOpt.TourOpptimizer encapsulates all necessary optimization functionality and provides a comprehensive REST API that offers a domain-specific optimization interface for the transportation industry. The service is stateless and does not come with graphical user interfaces, map depiction or any databases. These extensions and adjustments are supposed to be introduced by the consumer of the service while integrating it into his/her own application. The service will allow for many suitable adjustments and user-specific settings to adjust the behaviour and optimization goals (e.g. minimizing distance, maximizing resource utilization, etc.) through a comprehensive set of functions. This will enable you to gain control of the complete optimization processes.This service is based on JOpt (7.5.1-rc2-j17)
 *
 * The version of the OpenAPI document: 1.2.8-alpha-SNAPSHOT)
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
    /// SupplyFlexLoad
    /// </summary>
    [DataContract(Name = "SupplyFlexLoad")]
    [JsonConverter(typeof(JsonSubtypes), "TypeName")]
    public partial class SupplyFlexLoad : ILoad, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SupplyFlexLoad" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SupplyFlexLoad() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SupplyFlexLoad" /> class.
        /// </summary>
        /// <param name="loadId">loadId.</param>
        /// <param name="isRequest">isRequest.</param>
        /// <param name="isFuzzyVisit">isFuzzyVisit.</param>
        /// <param name="typeName">The typeName of the object (required) (default to &quot;SupplyFlexLoad&quot;).</param>
        /// <param name="priority">priority.</param>
        /// <param name="loadValue">loadValue.</param>
        /// <param name="fuzzyVisit">fuzzyVisit.</param>
        /// <param name="request">request.</param>
        /// <param name="id">id.</param>
        public SupplyFlexLoad(string loadId = default(string), bool isRequest = default(bool), bool isFuzzyVisit = default(bool), string typeName = @"SupplyFlexLoad", int priority = default(int), double loadValue = default(double), bool fuzzyVisit = default(bool), bool request = default(bool), string id = default(string)) : base(priority, loadValue, fuzzyVisit, request, id)
        {
            // to ensure "typeName" is required (not null)
            if (typeName == null)
            {
                throw new ArgumentNullException("typeName is a required property for SupplyFlexLoad and cannot be null");
            }
            this.TypeName = typeName;
            this.LoadId = loadId;
            this.IsRequest = isRequest;
            this.IsFuzzyVisit = isFuzzyVisit;
        }

        /// <summary>
        /// Gets or Sets LoadId
        /// </summary>
        [DataMember(Name = "loadId", EmitDefaultValue = false)]
        public string LoadId { get; set; }

        /// <summary>
        /// Gets or Sets IsRequest
        /// </summary>
        [DataMember(Name = "isRequest", EmitDefaultValue = true)]
        public bool IsRequest { get; set; }

        /// <summary>
        /// Gets or Sets IsFuzzyVisit
        /// </summary>
        [DataMember(Name = "isFuzzyVisit", EmitDefaultValue = true)]
        public bool IsFuzzyVisit { get; set; }

        /// <summary>
        /// The typeName of the object
        /// </summary>
        /// <value>The typeName of the object</value>
        /// <example>SupplyFlexLoad</example>
        [DataMember(Name = "typeName", IsRequired = true, EmitDefaultValue = true)]
        public string TypeName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SupplyFlexLoad {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  LoadId: ").Append(LoadId).Append("\n");
            sb.Append("  IsRequest: ").Append(IsRequest).Append("\n");
            sb.Append("  IsFuzzyVisit: ").Append(IsFuzzyVisit).Append("\n");
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
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
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
            foreach (var x in base.BaseValidate(validationContext))
            {
                yield return x;
            }
            yield break;
        }
    }

}
