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
    /// JOptOptimizationStatus model for the documentation
    /// </summary>
    [DataContract(Name = "JOptOptimizationStatus")]
    public partial class JOptOptimizationStatus : IEquatable<JOptOptimizationStatus>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JOptOptimizationStatus" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected JOptOptimizationStatus() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="JOptOptimizationStatus" /> class.
        /// </summary>
        /// <param name="creator">An id related to the creator that is filled out autmatically.</param>
        /// <param name="ident">The ident of the currently running optimization (required).</param>
        /// <param name="message">The info message (required).</param>
        /// <param name="code">The info message code (required).</param>
        /// <param name="desc">The description of the info (required).</param>
        /// <param name="expireAt">Optional value that will be used for database cleanup purposes..</param>
        /// <param name="id">The obejct id. Will be filled out by the optimizer, if necessary.</param>
        public JOptOptimizationStatus(string creator = default(string), string ident = default(string), string message = default(string), int code = default(int), string desc = default(string), DateTime expireAt = default(DateTime), string id = default(string))
        {
            // to ensure "ident" is required (not null)
            if (ident == null)
            {
                throw new ArgumentNullException("ident is a required property for JOptOptimizationStatus and cannot be null");
            }
            this.Ident = ident;
            // to ensure "message" is required (not null)
            if (message == null)
            {
                throw new ArgumentNullException("message is a required property for JOptOptimizationStatus and cannot be null");
            }
            this.Message = message;
            this.Code = code;
            // to ensure "desc" is required (not null)
            if (desc == null)
            {
                throw new ArgumentNullException("desc is a required property for JOptOptimizationStatus and cannot be null");
            }
            this.Desc = desc;
            this.Creator = creator;
            this.ExpireAt = expireAt;
            this.Id = id;
        }

        /// <summary>
        /// An id related to the creator that is filled out autmatically
        /// </summary>
        /// <value>An id related to the creator that is filled out autmatically</value>
        [DataMember(Name = "creator", EmitDefaultValue = false)]
        public string Creator { get; set; }

        /// <summary>
        /// The ident of the currently running optimization
        /// </summary>
        /// <value>The ident of the currently running optimization</value>
        [DataMember(Name = "ident", IsRequired = true, EmitDefaultValue = false)]
        public string Ident { get; set; }

        /// <summary>
        /// The info message
        /// </summary>
        /// <value>The info message</value>
        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// The info message code
        /// </summary>
        /// <value>The info message code</value>
        [DataMember(Name = "code", IsRequired = true, EmitDefaultValue = false)]
        public int Code { get; set; }

        /// <summary>
        /// The description of the info
        /// </summary>
        /// <value>The description of the info</value>
        [DataMember(Name = "desc", IsRequired = true, EmitDefaultValue = false)]
        public string Desc { get; set; }

        /// <summary>
        /// Optional value that will be used for database cleanup purposes.
        /// </summary>
        /// <value>Optional value that will be used for database cleanup purposes.</value>
        [DataMember(Name = "expireAt", EmitDefaultValue = false)]
        public DateTime ExpireAt { get; set; }

        /// <summary>
        /// The obejct id. Will be filled out by the optimizer, if necessary
        /// </summary>
        /// <value>The obejct id. Will be filled out by the optimizer, if necessary</value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class JOptOptimizationStatus {\n");
            sb.Append("  Creator: ").Append(Creator).Append("\n");
            sb.Append("  Ident: ").Append(Ident).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  Desc: ").Append(Desc).Append("\n");
            sb.Append("  ExpireAt: ").Append(ExpireAt).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
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
            return this.Equals(input as JOptOptimizationStatus);
        }

        /// <summary>
        /// Returns true if JOptOptimizationStatus instances are equal
        /// </summary>
        /// <param name="input">Instance of JOptOptimizationStatus to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(JOptOptimizationStatus input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Creator == input.Creator ||
                    (this.Creator != null &&
                    this.Creator.Equals(input.Creator))
                ) && 
                (
                    this.Ident == input.Ident ||
                    (this.Ident != null &&
                    this.Ident.Equals(input.Ident))
                ) && 
                (
                    this.Message == input.Message ||
                    (this.Message != null &&
                    this.Message.Equals(input.Message))
                ) && 
                (
                    this.Code == input.Code ||
                    this.Code.Equals(input.Code)
                ) && 
                (
                    this.Desc == input.Desc ||
                    (this.Desc != null &&
                    this.Desc.Equals(input.Desc))
                ) && 
                (
                    this.ExpireAt == input.ExpireAt ||
                    (this.ExpireAt != null &&
                    this.ExpireAt.Equals(input.ExpireAt))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
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
                if (this.Creator != null)
                {
                    hashCode = (hashCode * 59) + this.Creator.GetHashCode();
                }
                if (this.Ident != null)
                {
                    hashCode = (hashCode * 59) + this.Ident.GetHashCode();
                }
                if (this.Message != null)
                {
                    hashCode = (hashCode * 59) + this.Message.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Code.GetHashCode();
                if (this.Desc != null)
                {
                    hashCode = (hashCode * 59) + this.Desc.GetHashCode();
                }
                if (this.ExpireAt != null)
                {
                    hashCode = (hashCode * 59) + this.ExpireAt.GetHashCode();
                }
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
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
