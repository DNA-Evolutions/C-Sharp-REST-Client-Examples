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
    /// Solution
    /// </summary>
    [DataContract(Name = "Solution")]
    public partial class Solution : IEquatable<Solution>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Solution" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Solution() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Solution" /> class.
        /// </summary>
        /// <param name="optimizationStatus">optimizationStatus.</param>
        /// <param name="id">An id created by the system that can be used for unique identification.</param>
        /// <param name="createdTimeStamp">A timestamp the Snapshot was created that will automatically filled out, if neccessary.</param>
        /// <param name="creator">An id related to the creator that is filled out autmatically.</param>
        /// <param name="ident">An optional title/ident inhertited from the OptimizationCondig..</param>
        /// <param name="header">header.</param>
        /// <param name="routes">The routes of the solution. (required).</param>
        public Solution(OptimizationStatus optimizationStatus = default(OptimizationStatus), string id = default(string), long createdTimeStamp = default(long), string creator = default(string), string ident = default(string), SolutionHeader header = default(SolutionHeader), List<Route> routes = default(List<Route>))
        {
            // to ensure "routes" is required (not null)
            if (routes == null)
            {
                throw new ArgumentNullException("routes is a required property for Solution and cannot be null");
            }
            this.Routes = routes;
            this.OptimizationStatus = optimizationStatus;
            this.Id = id;
            this.CreatedTimeStamp = createdTimeStamp;
            this.Creator = creator;
            this.Ident = ident;
            this.Header = header;
        }

        /// <summary>
        /// Gets or Sets OptimizationStatus
        /// </summary>
        [DataMember(Name = "optimizationStatus", EmitDefaultValue = false)]
        public OptimizationStatus OptimizationStatus { get; set; }

        /// <summary>
        /// An id created by the system that can be used for unique identification
        /// </summary>
        /// <value>An id created by the system that can be used for unique identification</value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// A timestamp the Snapshot was created that will automatically filled out, if neccessary
        /// </summary>
        /// <value>A timestamp the Snapshot was created that will automatically filled out, if neccessary</value>
        [DataMember(Name = "createdTimeStamp", EmitDefaultValue = false)]
        public long CreatedTimeStamp { get; set; }

        /// <summary>
        /// An id related to the creator that is filled out autmatically
        /// </summary>
        /// <value>An id related to the creator that is filled out autmatically</value>
        [DataMember(Name = "creator", EmitDefaultValue = false)]
        public string Creator { get; set; }

        /// <summary>
        /// An optional title/ident inhertited from the OptimizationCondig.
        /// </summary>
        /// <value>An optional title/ident inhertited from the OptimizationCondig.</value>
        [DataMember(Name = "ident", EmitDefaultValue = false)]
        public string Ident { get; set; }

        /// <summary>
        /// Gets or Sets Header
        /// </summary>
        [DataMember(Name = "header", EmitDefaultValue = false)]
        public SolutionHeader Header { get; set; }

        /// <summary>
        /// The routes of the solution.
        /// </summary>
        /// <value>The routes of the solution.</value>
        [DataMember(Name = "routes", IsRequired = true, EmitDefaultValue = false)]
        public List<Route> Routes { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Solution {\n");
            sb.Append("  OptimizationStatus: ").Append(OptimizationStatus).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  CreatedTimeStamp: ").Append(CreatedTimeStamp).Append("\n");
            sb.Append("  Creator: ").Append(Creator).Append("\n");
            sb.Append("  Ident: ").Append(Ident).Append("\n");
            sb.Append("  Header: ").Append(Header).Append("\n");
            sb.Append("  Routes: ").Append(Routes).Append("\n");
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
            return this.Equals(input as Solution);
        }

        /// <summary>
        /// Returns true if Solution instances are equal
        /// </summary>
        /// <param name="input">Instance of Solution to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Solution input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.OptimizationStatus == input.OptimizationStatus ||
                    (this.OptimizationStatus != null &&
                    this.OptimizationStatus.Equals(input.OptimizationStatus))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.CreatedTimeStamp == input.CreatedTimeStamp ||
                    this.CreatedTimeStamp.Equals(input.CreatedTimeStamp)
                ) && 
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
                    this.Header == input.Header ||
                    (this.Header != null &&
                    this.Header.Equals(input.Header))
                ) && 
                (
                    this.Routes == input.Routes ||
                    this.Routes != null &&
                    input.Routes != null &&
                    this.Routes.SequenceEqual(input.Routes)
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
                if (this.OptimizationStatus != null)
                {
                    hashCode = (hashCode * 59) + this.OptimizationStatus.GetHashCode();
                }
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.CreatedTimeStamp.GetHashCode();
                if (this.Creator != null)
                {
                    hashCode = (hashCode * 59) + this.Creator.GetHashCode();
                }
                if (this.Ident != null)
                {
                    hashCode = (hashCode * 59) + this.Ident.GetHashCode();
                }
                if (this.Header != null)
                {
                    hashCode = (hashCode * 59) + this.Header.GetHashCode();
                }
                if (this.Routes != null)
                {
                    hashCode = (hashCode * 59) + this.Routes.GetHashCode();
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