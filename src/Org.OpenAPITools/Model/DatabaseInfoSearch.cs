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
    /// DatabaseInfoSearch model for a databse search
    /// </summary>
    [DataContract(Name = "DatabaseInfoSearch")]
    public partial class DatabaseInfoSearch : IEquatable<DatabaseInfoSearch>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseInfoSearch" /> class.
        /// </summary>
        /// <param name="creator">A related creator..</param>
        /// <param name="ident">The ident of the optimization to serach for. Leave blank if not required.</param>
        /// <param name="limit">The max number of results. Results are sorted by creation. Newest first by default.</param>
        /// <param name="sortDirection">The sort direction of the createdDate. By default descending (DESC) newest first. For oldest first, use ASC (ascending).</param>
        /// <param name="createdDateStart">The snapshot was created AFTER this time. Leave blank if not required..</param>
        /// <param name="createdDateEnd">The snapshot was created BEFORE this time. Leave blank if not required..</param>
        /// <param name="timeOut">The timeOut for the request. By default one minute.</param>
        public DatabaseInfoSearch(string creator = default(string), string ident = default(string), int limit = default(int), string sortDirection = default(string), DateTime createdDateStart = default(DateTime), DateTime createdDateEnd = default(DateTime), string timeOut = default(string))
        {
            this.Creator = creator;
            this.Ident = ident;
            this.Limit = limit;
            this.SortDirection = sortDirection;
            this.CreatedDateStart = createdDateStart;
            this.CreatedDateEnd = createdDateEnd;
            this.TimeOut = timeOut;
        }

        /// <summary>
        /// A related creator.
        /// </summary>
        /// <value>A related creator.</value>
        [DataMember(Name = "creator", EmitDefaultValue = false)]
        public string Creator { get; set; }

        /// <summary>
        /// The ident of the optimization to serach for. Leave blank if not required
        /// </summary>
        /// <value>The ident of the optimization to serach for. Leave blank if not required</value>
        [DataMember(Name = "ident", EmitDefaultValue = false)]
        public string Ident { get; set; }

        /// <summary>
        /// The max number of results. Results are sorted by creation. Newest first by default
        /// </summary>
        /// <value>The max number of results. Results are sorted by creation. Newest first by default</value>
        [DataMember(Name = "limit", EmitDefaultValue = false)]
        public int Limit { get; set; }

        /// <summary>
        /// The sort direction of the createdDate. By default descending (DESC) newest first. For oldest first, use ASC (ascending)
        /// </summary>
        /// <value>The sort direction of the createdDate. By default descending (DESC) newest first. For oldest first, use ASC (ascending)</value>
        [DataMember(Name = "sortDirection", EmitDefaultValue = false)]
        public string SortDirection { get; set; }

        /// <summary>
        /// The snapshot was created AFTER this time. Leave blank if not required.
        /// </summary>
        /// <value>The snapshot was created AFTER this time. Leave blank if not required.</value>
        [DataMember(Name = "createdDateStart", EmitDefaultValue = false)]
        public DateTime CreatedDateStart { get; set; }

        /// <summary>
        /// The snapshot was created BEFORE this time. Leave blank if not required.
        /// </summary>
        /// <value>The snapshot was created BEFORE this time. Leave blank if not required.</value>
        [DataMember(Name = "createdDateEnd", EmitDefaultValue = false)]
        public DateTime CreatedDateEnd { get; set; }

        /// <summary>
        /// The timeOut for the request. By default one minute
        /// </summary>
        /// <value>The timeOut for the request. By default one minute</value>
        [DataMember(Name = "timeOut", EmitDefaultValue = false)]
        public string TimeOut { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class DatabaseInfoSearch {\n");
            sb.Append("  Creator: ").Append(Creator).Append("\n");
            sb.Append("  Ident: ").Append(Ident).Append("\n");
            sb.Append("  Limit: ").Append(Limit).Append("\n");
            sb.Append("  SortDirection: ").Append(SortDirection).Append("\n");
            sb.Append("  CreatedDateStart: ").Append(CreatedDateStart).Append("\n");
            sb.Append("  CreatedDateEnd: ").Append(CreatedDateEnd).Append("\n");
            sb.Append("  TimeOut: ").Append(TimeOut).Append("\n");
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
            return this.Equals(input as DatabaseInfoSearch);
        }

        /// <summary>
        /// Returns true if DatabaseInfoSearch instances are equal
        /// </summary>
        /// <param name="input">Instance of DatabaseInfoSearch to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DatabaseInfoSearch input)
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
                    this.Limit == input.Limit ||
                    this.Limit.Equals(input.Limit)
                ) && 
                (
                    this.SortDirection == input.SortDirection ||
                    (this.SortDirection != null &&
                    this.SortDirection.Equals(input.SortDirection))
                ) && 
                (
                    this.CreatedDateStart == input.CreatedDateStart ||
                    (this.CreatedDateStart != null &&
                    this.CreatedDateStart.Equals(input.CreatedDateStart))
                ) && 
                (
                    this.CreatedDateEnd == input.CreatedDateEnd ||
                    (this.CreatedDateEnd != null &&
                    this.CreatedDateEnd.Equals(input.CreatedDateEnd))
                ) && 
                (
                    this.TimeOut == input.TimeOut ||
                    (this.TimeOut != null &&
                    this.TimeOut.Equals(input.TimeOut))
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
                hashCode = (hashCode * 59) + this.Limit.GetHashCode();
                if (this.SortDirection != null)
                {
                    hashCode = (hashCode * 59) + this.SortDirection.GetHashCode();
                }
                if (this.CreatedDateStart != null)
                {
                    hashCode = (hashCode * 59) + this.CreatedDateStart.GetHashCode();
                }
                if (this.CreatedDateEnd != null)
                {
                    hashCode = (hashCode * 59) + this.CreatedDateEnd.GetHashCode();
                }
                if (this.TimeOut != null)
                {
                    hashCode = (hashCode * 59) + this.TimeOut.GetHashCode();
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
