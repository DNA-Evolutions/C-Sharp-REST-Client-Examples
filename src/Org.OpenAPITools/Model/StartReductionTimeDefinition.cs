/*
 * DNA Evolutions - JOpt.TourOptimizer
 *
 * This is DNA's JOpt.TourOptimizer service. A RESTful Spring Boot application using springdoc-openapi and OpenAPI 3. JOpt.TourOpptimizer is a service that delivers route optimization and automatic scheduling features to be easily integrated into any third-party application. JOpt.TourOpptimizer encapsulates all necessary optimization functionality and provides a comprehensive REST API that offers a domain-specific optimization interface for the transportation industry. The service is stateless and does not come with graphical user interfaces, map depiction or any databases. These extensions and adjustments are supposed to be introduced by the consumer of the service while integrating it into his/her own application. The service will allow for many suitable adjustments and user-specific settings to adjust the behaviour and optimization goals (e.g. minimizing distance, maximizing resource utilization, etc.) through a comprehensive set of functions. This will enable you to gain control of the complete optimization processes.This service is based on JOpt (null)
 *
 * The version of the OpenAPI document: 1.2.2-SNAPSHOT
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
    /// The settings/defintion for the reduction time at the start of the route for non-pillar nodes. A reduction times allows the Resource to start working/driving before the actual official workingHours start. For example, a customer node opens at 8 in the morning and the resource needs 25 minutes to drive to the node. The official workingHour of the Resource start at 8 as well. By giving a maximal reduction time of, for example, one hour and only allow the reduction time to be used for driving, the Resource will start 25 minutes to earlier to reach the node by 8.
    /// </summary>
    [DataContract(Name = "StartReductionTimeDefinition")]
    public partial class StartReductionTimeDefinition : IEquatable<StartReductionTimeDefinition>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StartReductionTimeDefinition" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected StartReductionTimeDefinition() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="StartReductionTimeDefinition" /> class.
        /// </summary>
        /// <param name="maxRouteStartReductionTime">The maximal Routes&#39; Start Reduction Time for nodes the Optimizer is allowed to use. (required).</param>
        /// <param name="isReductionTimeOnlyUsedForDriving">The boolean isReductionTimeOnlyUsedForDriving defines if a Resource is allowed to use reduction time only for driving to the first node but not for working on it. (required).</param>
        public StartReductionTimeDefinition(string maxRouteStartReductionTime = default(string), bool isReductionTimeOnlyUsedForDriving = default(bool))
        {
            // to ensure "maxRouteStartReductionTime" is required (not null)
            if (maxRouteStartReductionTime == null)
            {
                throw new ArgumentNullException("maxRouteStartReductionTime is a required property for StartReductionTimeDefinition and cannot be null");
            }
            this.MaxRouteStartReductionTime = maxRouteStartReductionTime;
            this.IsReductionTimeOnlyUsedForDriving = isReductionTimeOnlyUsedForDriving;
        }

        /// <summary>
        /// The maximal Routes&#39; Start Reduction Time for nodes the Optimizer is allowed to use.
        /// </summary>
        /// <value>The maximal Routes&#39; Start Reduction Time for nodes the Optimizer is allowed to use.</value>
        [DataMember(Name = "maxRouteStartReductionTime", IsRequired = true, EmitDefaultValue = false)]
        public string MaxRouteStartReductionTime { get; set; }

        /// <summary>
        /// The boolean isReductionTimeOnlyUsedForDriving defines if a Resource is allowed to use reduction time only for driving to the first node but not for working on it.
        /// </summary>
        /// <value>The boolean isReductionTimeOnlyUsedForDriving defines if a Resource is allowed to use reduction time only for driving to the first node but not for working on it.</value>
        [DataMember(Name = "isReductionTimeOnlyUsedForDriving", IsRequired = true, EmitDefaultValue = true)]
        public bool IsReductionTimeOnlyUsedForDriving { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class StartReductionTimeDefinition {\n");
            sb.Append("  MaxRouteStartReductionTime: ").Append(MaxRouteStartReductionTime).Append("\n");
            sb.Append("  IsReductionTimeOnlyUsedForDriving: ").Append(IsReductionTimeOnlyUsedForDriving).Append("\n");
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
            return this.Equals(input as StartReductionTimeDefinition);
        }

        /// <summary>
        /// Returns true if StartReductionTimeDefinition instances are equal
        /// </summary>
        /// <param name="input">Instance of StartReductionTimeDefinition to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(StartReductionTimeDefinition input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.MaxRouteStartReductionTime == input.MaxRouteStartReductionTime ||
                    (this.MaxRouteStartReductionTime != null &&
                    this.MaxRouteStartReductionTime.Equals(input.MaxRouteStartReductionTime))
                ) && 
                (
                    this.IsReductionTimeOnlyUsedForDriving == input.IsReductionTimeOnlyUsedForDriving ||
                    this.IsReductionTimeOnlyUsedForDriving.Equals(input.IsReductionTimeOnlyUsedForDriving)
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
                if (this.MaxRouteStartReductionTime != null)
                {
                    hashCode = (hashCode * 59) + this.MaxRouteStartReductionTime.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.IsReductionTimeOnlyUsedForDriving.GetHashCode();
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
