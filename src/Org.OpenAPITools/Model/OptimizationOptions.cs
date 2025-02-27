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
using System.ComponentModel.DataAnnotations;
using FileParameter = Org.OpenAPITools.Client.FileParameter;
using OpenAPIDateConverter = Org.OpenAPITools.Client.OpenAPIDateConverter;

namespace Org.OpenAPITools.Model
{
    /// <summary>
    /// The list of optimizationOptions
    /// </summary>
    [DataContract(Name = "OptimizationOptions")]
    public partial class OptimizationOptions : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OptimizationOptions" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected OptimizationOptions() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="OptimizationOptions" /> class.
        /// </summary>
        /// <param name="properties">The properties of the Optimization run. For example, the number of iterations for the Optimization run or the weight for certain Optimization goals can be defined. (required).</param>
        public OptimizationOptions(Dictionary<string, string> properties = default(Dictionary<string, string>))
        {
            // to ensure "properties" is required (not null)
            if (properties == null)
            {
                throw new ArgumentNullException("properties is a required property for OptimizationOptions and cannot be null");
            }
            this.Properties = properties;
        }

        /// <summary>
        /// The properties of the Optimization run. For example, the number of iterations for the Optimization run or the weight for certain Optimization goals can be defined.
        /// </summary>
        /// <value>The properties of the Optimization run. For example, the number of iterations for the Optimization run or the weight for certain Optimization goals can be defined.</value>
        [DataMember(Name = "properties", IsRequired = true, EmitDefaultValue = true)]
        public Dictionary<string, string> Properties { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class OptimizationOptions {\n");
            sb.Append("  Properties: ").Append(Properties).Append("\n");
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
            yield break;
        }
    }

}
