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
using System.ComponentModel.DataAnnotations;
using FileParameter = Org.OpenAPITools.Client.FileParameter;
using OpenAPIDateConverter = Org.OpenAPITools.Client.OpenAPIDateConverter;

namespace Org.OpenAPITools.Model
{
    /// <summary>
    /// The loadDimension
    /// </summary>
    [DataContract(Name = "LoadDimension")]
    public partial class LoadDimension : IEquatable<LoadDimension>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoadDimension" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected LoadDimension() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="LoadDimension" /> class.
        /// </summary>
        /// <param name="unloadAllDimension">The unloadAllDimension (required).</param>
        /// <param name="totalLoadDimension">The totalLoadDimension (required).</param>
        /// <param name="unloadAll">The unloadAll.</param>
        public LoadDimension(int unloadAllDimension = default(int), int totalLoadDimension = default(int), bool unloadAll = default(bool))
        {
            this.UnloadAllDimension = unloadAllDimension;
            this.TotalLoadDimension = totalLoadDimension;
            this.UnloadAll = unloadAll;
        }

        /// <summary>
        /// The unloadAllDimension
        /// </summary>
        /// <value>The unloadAllDimension</value>
        [DataMember(Name = "unloadAllDimension", IsRequired = true, EmitDefaultValue = false)]
        public int UnloadAllDimension { get; set; }

        /// <summary>
        /// The totalLoadDimension
        /// </summary>
        /// <value>The totalLoadDimension</value>
        [DataMember(Name = "totalLoadDimension", IsRequired = true, EmitDefaultValue = false)]
        public int TotalLoadDimension { get; set; }

        /// <summary>
        /// The unloadAll
        /// </summary>
        /// <value>The unloadAll</value>
        [DataMember(Name = "unloadAll", EmitDefaultValue = true)]
        public bool UnloadAll { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class LoadDimension {\n");
            sb.Append("  UnloadAllDimension: ").Append(UnloadAllDimension).Append("\n");
            sb.Append("  TotalLoadDimension: ").Append(TotalLoadDimension).Append("\n");
            sb.Append("  UnloadAll: ").Append(UnloadAll).Append("\n");
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
            return this.Equals(input as LoadDimension);
        }

        /// <summary>
        /// Returns true if LoadDimension instances are equal
        /// </summary>
        /// <param name="input">Instance of LoadDimension to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LoadDimension input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.UnloadAllDimension == input.UnloadAllDimension ||
                    this.UnloadAllDimension.Equals(input.UnloadAllDimension)
                ) && 
                (
                    this.TotalLoadDimension == input.TotalLoadDimension ||
                    this.TotalLoadDimension.Equals(input.TotalLoadDimension)
                ) && 
                (
                    this.UnloadAll == input.UnloadAll ||
                    this.UnloadAll.Equals(input.UnloadAll)
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
                hashCode = (hashCode * 59) + this.UnloadAllDimension.GetHashCode();
                hashCode = (hashCode * 59) + this.TotalLoadDimension.GetHashCode();
                hashCode = (hashCode * 59) + this.UnloadAll.GetHashCode();
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
