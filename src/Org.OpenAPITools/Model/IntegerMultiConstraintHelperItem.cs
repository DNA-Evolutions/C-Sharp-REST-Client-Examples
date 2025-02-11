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
    /// The mirrorItem
    /// </summary>
    [DataContract(Name = "IntegerMultiConstraintHelperItem")]
    public partial class IntegerMultiConstraintHelperItem : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerMultiConstraintHelperItem" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected IntegerMultiConstraintHelperItem() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerMultiConstraintHelperItem" /> class.
        /// </summary>
        /// <param name="pairs">The pairs (required).</param>
        public IntegerMultiConstraintHelperItem(List<StringIntegerPair> pairs = default(List<StringIntegerPair>))
        {
            // to ensure "pairs" is required (not null)
            if (pairs == null)
            {
                throw new ArgumentNullException("pairs is a required property for IntegerMultiConstraintHelperItem and cannot be null");
            }
            this.Pairs = pairs;
        }

        /// <summary>
        /// The pairs
        /// </summary>
        /// <value>The pairs</value>
        [DataMember(Name = "pairs", IsRequired = true, EmitDefaultValue = true)]
        public List<StringIntegerPair> Pairs { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class IntegerMultiConstraintHelperItem {\n");
            sb.Append("  Pairs: ").Append(Pairs).Append("\n");
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
