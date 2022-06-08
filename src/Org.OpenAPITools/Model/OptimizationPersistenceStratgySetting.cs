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
    /// The optimizationPersistenceStratgySetting
    /// </summary>
    [DataContract(Name = "OptimizationPersistenceStratgySetting")]
    public partial class OptimizationPersistenceStratgySetting : IEquatable<OptimizationPersistenceStratgySetting>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OptimizationPersistenceStratgySetting" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected OptimizationPersistenceStratgySetting() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="OptimizationPersistenceStratgySetting" /> class.
        /// </summary>
        /// <param name="saveOnlyResult">The saveOnlyResult (required).</param>
        /// <param name="saveConnections">The saveConnections. Only takes action if saveOnlyResult is false..</param>
        public OptimizationPersistenceStratgySetting(bool saveOnlyResult = default(bool), bool saveConnections = default(bool))
        {
            this.SaveOnlyResult = saveOnlyResult;
            this.SaveConnections = saveConnections;
        }

        /// <summary>
        /// The saveOnlyResult
        /// </summary>
        /// <value>The saveOnlyResult</value>
        [DataMember(Name = "saveOnlyResult", IsRequired = true, EmitDefaultValue = true)]
        public bool SaveOnlyResult { get; set; }

        /// <summary>
        /// The saveConnections. Only takes action if saveOnlyResult is false.
        /// </summary>
        /// <value>The saveConnections. Only takes action if saveOnlyResult is false.</value>
        [DataMember(Name = "saveConnections", EmitDefaultValue = true)]
        public bool SaveConnections { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class OptimizationPersistenceStratgySetting {\n");
            sb.Append("  SaveOnlyResult: ").Append(SaveOnlyResult).Append("\n");
            sb.Append("  SaveConnections: ").Append(SaveConnections).Append("\n");
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
            return this.Equals(input as OptimizationPersistenceStratgySetting);
        }

        /// <summary>
        /// Returns true if OptimizationPersistenceStratgySetting instances are equal
        /// </summary>
        /// <param name="input">Instance of OptimizationPersistenceStratgySetting to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OptimizationPersistenceStratgySetting input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.SaveOnlyResult == input.SaveOnlyResult ||
                    this.SaveOnlyResult.Equals(input.SaveOnlyResult)
                ) && 
                (
                    this.SaveConnections == input.SaveConnections ||
                    this.SaveConnections.Equals(input.SaveConnections)
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
                hashCode = (hashCode * 59) + this.SaveOnlyResult.GetHashCode();
                hashCode = (hashCode * 59) + this.SaveConnections.GetHashCode();
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
