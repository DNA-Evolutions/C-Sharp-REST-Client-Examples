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
    /// TypeWithExpertiseConstraintAllOf
    /// </summary>
    [DataContract(Name = "TypeWithExpertiseConstraint_allOf")]
    public partial class TypeWithExpertiseConstraintAllOf : IEquatable<TypeWithExpertiseConstraintAllOf>, IValidatableObject
    {
        /// <summary>
        /// The cost model for matching the expertise.
        /// </summary>
        /// <value>The cost model for matching the expertise.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CostModelEnum
        {
            /// <summary>
            /// Enum PENALIZEMATCHINGSKILLHIGHDELTA for value: PENALIZE_MATCHING_SKILL_HIGH_DELTA
            /// </summary>
            [EnumMember(Value = "PENALIZE_MATCHING_SKILL_HIGH_DELTA")]
            PENALIZEMATCHINGSKILLHIGHDELTA = 1,

            /// <summary>
            /// Enum PENALIZEMATCHINGSKILLLOWDELTA for value: PENALIZE_MATCHING_SKILL_LOW_DELTA
            /// </summary>
            [EnumMember(Value = "PENALIZE_MATCHING_SKILL_LOW_DELTA")]
            PENALIZEMATCHINGSKILLLOWDELTA = 2,

            /// <summary>
            /// Enum NOPENALIZEMATCHINGSKILL for value: NO_PENALIZE_MATCHING_SKILL
            /// </summary>
            [EnumMember(Value = "NO_PENALIZE_MATCHING_SKILL")]
            NOPENALIZEMATCHINGSKILL = 3

        }


        /// <summary>
        /// The cost model for matching the expertise.
        /// </summary>
        /// <value>The cost model for matching the expertise.</value>
        [DataMember(Name = "costModel", EmitDefaultValue = false)]
        public CostModelEnum? CostModel { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TypeWithExpertiseConstraintAllOf" /> class.
        /// </summary>
        /// <param name="typesWithExpertise">The types with expertise.</param>
        /// <param name="costModel">The cost model for matching the expertise..</param>
        /// <param name="typeName">The typeName of the object (default to &quot;TypeWithExpertise&quot;).</param>
        public TypeWithExpertiseConstraintAllOf(List<TypeWithExpertise> typesWithExpertise = default(List<TypeWithExpertise>), CostModelEnum? costModel = default(CostModelEnum?), string typeName = "TypeWithExpertise")
        {
            this.TypesWithExpertise = typesWithExpertise;
            this.CostModel = costModel;
            // use default value if no "typeName" provided
            this.TypeName = typeName ?? "TypeWithExpertise";
        }

        /// <summary>
        /// The types with expertise
        /// </summary>
        /// <value>The types with expertise</value>
        [DataMember(Name = "typesWithExpertise", EmitDefaultValue = false)]
        public List<TypeWithExpertise> TypesWithExpertise { get; set; }

        /// <summary>
        /// The typeName of the object
        /// </summary>
        /// <value>The typeName of the object</value>
        [DataMember(Name = "typeName", EmitDefaultValue = false)]
        public string TypeName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TypeWithExpertiseConstraintAllOf {\n");
            sb.Append("  TypesWithExpertise: ").Append(TypesWithExpertise).Append("\n");
            sb.Append("  CostModel: ").Append(CostModel).Append("\n");
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
            return this.Equals(input as TypeWithExpertiseConstraintAllOf);
        }

        /// <summary>
        /// Returns true if TypeWithExpertiseConstraintAllOf instances are equal
        /// </summary>
        /// <param name="input">Instance of TypeWithExpertiseConstraintAllOf to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TypeWithExpertiseConstraintAllOf input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.TypesWithExpertise == input.TypesWithExpertise ||
                    this.TypesWithExpertise != null &&
                    input.TypesWithExpertise != null &&
                    this.TypesWithExpertise.SequenceEqual(input.TypesWithExpertise)
                ) && 
                (
                    this.CostModel == input.CostModel ||
                    this.CostModel.Equals(input.CostModel)
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
                if (this.TypesWithExpertise != null)
                {
                    hashCode = (hashCode * 59) + this.TypesWithExpertise.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.CostModel.GetHashCode();
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
            yield break;
        }
    }

}