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
    /// The settings/defintion for the reduction time at the start of the route for pillar nodes. Please see startReductionTimeDefinition for details.
    /// </summary>
    [DataContract(Name = "StartReductionTimePillarDefinition")]
    public partial class StartReductionTimePillarDefinition : IEquatable<StartReductionTimePillarDefinition>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StartReductionTimePillarDefinition" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected StartReductionTimePillarDefinition() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="StartReductionTimePillarDefinition" /> class.
        /// </summary>
        /// <param name="maxRouteStartReductionTimePillar">The maximal Routes&#39; Start Reduction Time for pillars nodes the Optimizer is allowed to use. (required).</param>
        /// <param name="isReductionTimeOnlyUsedForDrivingPillar">The boolean isReductionTimeOnlyUsedForDriving defines if a Resource is allowed to use reduction time only for driving to the first node (here a pillar) but not for working on it. (required).</param>
        public StartReductionTimePillarDefinition(string maxRouteStartReductionTimePillar = default(string), bool isReductionTimeOnlyUsedForDrivingPillar = default(bool))
        {
            // to ensure "maxRouteStartReductionTimePillar" is required (not null)
            if (maxRouteStartReductionTimePillar == null)
            {
                throw new ArgumentNullException("maxRouteStartReductionTimePillar is a required property for StartReductionTimePillarDefinition and cannot be null");
            }
            this.MaxRouteStartReductionTimePillar = maxRouteStartReductionTimePillar;
            this.IsReductionTimeOnlyUsedForDrivingPillar = isReductionTimeOnlyUsedForDrivingPillar;
        }

        /// <summary>
        /// The maximal Routes&#39; Start Reduction Time for pillars nodes the Optimizer is allowed to use.
        /// </summary>
        /// <value>The maximal Routes&#39; Start Reduction Time for pillars nodes the Optimizer is allowed to use.</value>
        [DataMember(Name = "maxRouteStartReductionTimePillar", IsRequired = true, EmitDefaultValue = false)]
        public string MaxRouteStartReductionTimePillar { get; set; }

        /// <summary>
        /// The boolean isReductionTimeOnlyUsedForDriving defines if a Resource is allowed to use reduction time only for driving to the first node (here a pillar) but not for working on it.
        /// </summary>
        /// <value>The boolean isReductionTimeOnlyUsedForDriving defines if a Resource is allowed to use reduction time only for driving to the first node (here a pillar) but not for working on it.</value>
        [DataMember(Name = "isReductionTimeOnlyUsedForDrivingPillar", IsRequired = true, EmitDefaultValue = true)]
        public bool IsReductionTimeOnlyUsedForDrivingPillar { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class StartReductionTimePillarDefinition {\n");
            sb.Append("  MaxRouteStartReductionTimePillar: ").Append(MaxRouteStartReductionTimePillar).Append("\n");
            sb.Append("  IsReductionTimeOnlyUsedForDrivingPillar: ").Append(IsReductionTimeOnlyUsedForDrivingPillar).Append("\n");
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
            return this.Equals(input as StartReductionTimePillarDefinition);
        }

        /// <summary>
        /// Returns true if StartReductionTimePillarDefinition instances are equal
        /// </summary>
        /// <param name="input">Instance of StartReductionTimePillarDefinition to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(StartReductionTimePillarDefinition input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.MaxRouteStartReductionTimePillar == input.MaxRouteStartReductionTimePillar ||
                    (this.MaxRouteStartReductionTimePillar != null &&
                    this.MaxRouteStartReductionTimePillar.Equals(input.MaxRouteStartReductionTimePillar))
                ) && 
                (
                    this.IsReductionTimeOnlyUsedForDrivingPillar == input.IsReductionTimeOnlyUsedForDrivingPillar ||
                    this.IsReductionTimeOnlyUsedForDrivingPillar.Equals(input.IsReductionTimeOnlyUsedForDrivingPillar)
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
                if (this.MaxRouteStartReductionTimePillar != null)
                {
                    hashCode = (hashCode * 59) + this.MaxRouteStartReductionTimePillar.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.IsReductionTimeOnlyUsedForDrivingPillar.GetHashCode();
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
