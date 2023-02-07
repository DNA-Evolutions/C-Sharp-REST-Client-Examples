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
    /// The list of hook connections
    /// </summary>
    [DataContract(Name = "ReducedNodeEdgeConnectorItem")]
    public partial class ReducedNodeEdgeConnectorItem : IEquatable<ReducedNodeEdgeConnectorItem>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReducedNodeEdgeConnectorItem" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ReducedNodeEdgeConnectorItem() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ReducedNodeEdgeConnectorItem" /> class.
        /// </summary>
        /// <param name="distance">The distance of the hook connection. (required).</param>
        /// <param name="time">The time needed to pass the hook connection. (required).</param>
        /// <param name="fromElementId">The fromElementId defines the element where the connections starts. (required).</param>
        /// <param name="toElementId">The toElementId defines the element where the connections ends. (required).</param>
        public ReducedNodeEdgeConnectorItem(string distance = default(string), string time = default(string), string fromElementId = default(string), string toElementId = default(string))
        {
            // to ensure "distance" is required (not null)
            if (distance == null)
            {
                throw new ArgumentNullException("distance is a required property for ReducedNodeEdgeConnectorItem and cannot be null");
            }
            this.Distance = distance;
            // to ensure "time" is required (not null)
            if (time == null)
            {
                throw new ArgumentNullException("time is a required property for ReducedNodeEdgeConnectorItem and cannot be null");
            }
            this.Time = time;
            // to ensure "fromElementId" is required (not null)
            if (fromElementId == null)
            {
                throw new ArgumentNullException("fromElementId is a required property for ReducedNodeEdgeConnectorItem and cannot be null");
            }
            this.FromElementId = fromElementId;
            // to ensure "toElementId" is required (not null)
            if (toElementId == null)
            {
                throw new ArgumentNullException("toElementId is a required property for ReducedNodeEdgeConnectorItem and cannot be null");
            }
            this.ToElementId = toElementId;
        }

        /// <summary>
        /// The distance of the hook connection.
        /// </summary>
        /// <value>The distance of the hook connection.</value>
        [DataMember(Name = "distance", IsRequired = true, EmitDefaultValue = false)]
        public string Distance { get; set; }

        /// <summary>
        /// The time needed to pass the hook connection.
        /// </summary>
        /// <value>The time needed to pass the hook connection.</value>
        [DataMember(Name = "time", IsRequired = true, EmitDefaultValue = false)]
        public string Time { get; set; }

        /// <summary>
        /// The fromElementId defines the element where the connections starts.
        /// </summary>
        /// <value>The fromElementId defines the element where the connections starts.</value>
        [DataMember(Name = "fromElementId", IsRequired = true, EmitDefaultValue = false)]
        public string FromElementId { get; set; }

        /// <summary>
        /// The toElementId defines the element where the connections ends.
        /// </summary>
        /// <value>The toElementId defines the element where the connections ends.</value>
        [DataMember(Name = "toElementId", IsRequired = true, EmitDefaultValue = false)]
        public string ToElementId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ReducedNodeEdgeConnectorItem {\n");
            sb.Append("  Distance: ").Append(Distance).Append("\n");
            sb.Append("  Time: ").Append(Time).Append("\n");
            sb.Append("  FromElementId: ").Append(FromElementId).Append("\n");
            sb.Append("  ToElementId: ").Append(ToElementId).Append("\n");
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
            return this.Equals(input as ReducedNodeEdgeConnectorItem);
        }

        /// <summary>
        /// Returns true if ReducedNodeEdgeConnectorItem instances are equal
        /// </summary>
        /// <param name="input">Instance of ReducedNodeEdgeConnectorItem to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ReducedNodeEdgeConnectorItem input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Distance == input.Distance ||
                    (this.Distance != null &&
                    this.Distance.Equals(input.Distance))
                ) && 
                (
                    this.Time == input.Time ||
                    (this.Time != null &&
                    this.Time.Equals(input.Time))
                ) && 
                (
                    this.FromElementId == input.FromElementId ||
                    (this.FromElementId != null &&
                    this.FromElementId.Equals(input.FromElementId))
                ) && 
                (
                    this.ToElementId == input.ToElementId ||
                    (this.ToElementId != null &&
                    this.ToElementId.Equals(input.ToElementId))
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
                if (this.Distance != null)
                {
                    hashCode = (hashCode * 59) + this.Distance.GetHashCode();
                }
                if (this.Time != null)
                {
                    hashCode = (hashCode * 59) + this.Time.GetHashCode();
                }
                if (this.FromElementId != null)
                {
                    hashCode = (hashCode * 59) + this.FromElementId.GetHashCode();
                }
                if (this.ToElementId != null)
                {
                    hashCode = (hashCode * 59) + this.ToElementId.GetHashCode();
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
