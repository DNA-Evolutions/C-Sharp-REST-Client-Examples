/*
 * DNA Evolutions - JOpt.TourOptimizer
 *
 * This is DNA's JOpt.TourOptimizer service. A RESTful Spring Boot application using springdoc-openapi and OpenAPI 3. JOpt.TourOpptimizer is a service that delivers route optimization and automatic scheduling features to be easily integrated into any third-party application. JOpt.TourOpptimizer encapsulates all necessary optimization functionality and provides a comprehensive REST API that offers a domain-specific optimization interface for the transportation industry. The service is stateless and does not come with graphical user interfaces, map depiction or any databases. These extensions and adjustments are supposed to be introduced by the consumer of the service while integrating it into his/her own application. The service will allow for many suitable adjustments and user-specific settings to adjust the behaviour and optimization goals (e.g. minimizing distance, maximizing resource utilization, etc.) through a comprehensive set of functions. This will enable you to gain control of the complete optimization processes.This service is based on JOpt (null)
 *
 * The version of the OpenAPI document: 1.2.6-SNAPSHOT
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
    /// The settings/defintion for how to handle working time in the context of reduction time.
    /// </summary>
    [DataContract(Name = "StartReductionTimeIncludeDefinition")]
    public partial class StartReductionTimeIncludeDefinition : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StartReductionTimeIncludeDefinition" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected StartReductionTimeIncludeDefinition() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="StartReductionTimeIncludeDefinition" /> class.
        /// </summary>
        /// <param name="isReductionTimeIncludedInWorkingTime">The boolean isReductionTimeIncludedInWorkingTime. If reduction time is used it can be either counted as part of the working time or not. (required).</param>
        public StartReductionTimeIncludeDefinition(bool isReductionTimeIncludedInWorkingTime = default(bool))
        {
            this.IsReductionTimeIncludedInWorkingTime = isReductionTimeIncludedInWorkingTime;
        }

        /// <summary>
        /// The boolean isReductionTimeIncludedInWorkingTime. If reduction time is used it can be either counted as part of the working time or not.
        /// </summary>
        /// <value>The boolean isReductionTimeIncludedInWorkingTime. If reduction time is used it can be either counted as part of the working time or not.</value>
        [DataMember(Name = "isReductionTimeIncludedInWorkingTime", IsRequired = true, EmitDefaultValue = true)]
        public bool IsReductionTimeIncludedInWorkingTime { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class StartReductionTimeIncludeDefinition {\n");
            sb.Append("  IsReductionTimeIncludedInWorkingTime: ").Append(IsReductionTimeIncludedInWorkingTime).Append("\n");
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
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
