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
    /// The list of resources that should NOT visit a certain node.
    /// </summary>
    [DataContract(Name = "ResourceWithPriority")]
    public partial class ResourceWithPriority : IEquatable<ResourceWithPriority>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceWithPriority" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ResourceWithPriority() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceWithPriority" /> class.
        /// </summary>
        /// <param name="resourceId">The resourceId that will be part of a constraint. For example, Jack is a preffered Resource of a node. If multiple resources are preferred, the Optimizer tries to schedule the Resource with the highest priority. (required).</param>
        /// <param name="priority">The priority (required).</param>
        public ResourceWithPriority(string resourceId = default(string), int priority = default(int))
        {
            // to ensure "resourceId" is required (not null)
            if (resourceId == null)
            {
                throw new ArgumentNullException("resourceId is a required property for ResourceWithPriority and cannot be null");
            }
            this.ResourceId = resourceId;
            this.Priority = priority;
        }

        /// <summary>
        /// The resourceId that will be part of a constraint. For example, Jack is a preffered Resource of a node. If multiple resources are preferred, the Optimizer tries to schedule the Resource with the highest priority.
        /// </summary>
        /// <value>The resourceId that will be part of a constraint. For example, Jack is a preffered Resource of a node. If multiple resources are preferred, the Optimizer tries to schedule the Resource with the highest priority.</value>
        [DataMember(Name = "resourceId", IsRequired = true, EmitDefaultValue = false)]
        public string ResourceId { get; set; }

        /// <summary>
        /// The priority
        /// </summary>
        /// <value>The priority</value>
        [DataMember(Name = "priority", IsRequired = true, EmitDefaultValue = false)]
        public int Priority { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ResourceWithPriority {\n");
            sb.Append("  ResourceId: ").Append(ResourceId).Append("\n");
            sb.Append("  Priority: ").Append(Priority).Append("\n");
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
            return this.Equals(input as ResourceWithPriority);
        }

        /// <summary>
        /// Returns true if ResourceWithPriority instances are equal
        /// </summary>
        /// <param name="input">Instance of ResourceWithPriority to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ResourceWithPriority input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.ResourceId == input.ResourceId ||
                    (this.ResourceId != null &&
                    this.ResourceId.Equals(input.ResourceId))
                ) && 
                (
                    this.Priority == input.Priority ||
                    this.Priority.Equals(input.Priority)
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
                if (this.ResourceId != null)
                {
                    hashCode = (hashCode * 59) + this.ResourceId.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Priority.GetHashCode();
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
