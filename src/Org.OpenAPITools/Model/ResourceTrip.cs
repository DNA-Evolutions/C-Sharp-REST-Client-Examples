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
    /// Trips representing the route.
    /// </summary>
    [DataContract(Name = "ResourceTrip")]
    public partial class ResourceTrip : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceTrip" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ResourceTrip() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceTrip" /> class.
        /// </summary>
        /// <param name="line">line (required).</param>
        /// <param name="fromElementId">The position the polyline starts. (required).</param>
        /// <param name="toElementId">The position the polyline ends. (required).</param>
        /// <param name="rawJson">The raw json descirbing the trip..</param>
        public ResourceTrip(EncodedPolyline line = default(EncodedPolyline), string fromElementId = default(string), string toElementId = default(string), Object rawJson = default(Object))
        {
            // to ensure "line" is required (not null)
            if (line == null)
            {
                throw new ArgumentNullException("line is a required property for ResourceTrip and cannot be null");
            }
            this.Line = line;
            // to ensure "fromElementId" is required (not null)
            if (fromElementId == null)
            {
                throw new ArgumentNullException("fromElementId is a required property for ResourceTrip and cannot be null");
            }
            this.FromElementId = fromElementId;
            // to ensure "toElementId" is required (not null)
            if (toElementId == null)
            {
                throw new ArgumentNullException("toElementId is a required property for ResourceTrip and cannot be null");
            }
            this.ToElementId = toElementId;
            this.RawJson = rawJson;
        }

        /// <summary>
        /// Gets or Sets Line
        /// </summary>
        [DataMember(Name = "line", IsRequired = true, EmitDefaultValue = true)]
        public EncodedPolyline Line { get; set; }

        /// <summary>
        /// The position the polyline starts.
        /// </summary>
        /// <value>The position the polyline starts.</value>
        [DataMember(Name = "fromElementId", IsRequired = true, EmitDefaultValue = true)]
        public string FromElementId { get; set; }

        /// <summary>
        /// The position the polyline ends.
        /// </summary>
        /// <value>The position the polyline ends.</value>
        [DataMember(Name = "toElementId", IsRequired = true, EmitDefaultValue = true)]
        public string ToElementId { get; set; }

        /// <summary>
        /// The raw json descirbing the trip.
        /// </summary>
        /// <value>The raw json descirbing the trip.</value>
        [DataMember(Name = "rawJson", EmitDefaultValue = false)]
        public Object RawJson { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ResourceTrip {\n");
            sb.Append("  Line: ").Append(Line).Append("\n");
            sb.Append("  FromElementId: ").Append(FromElementId).Append("\n");
            sb.Append("  ToElementId: ").Append(ToElementId).Append("\n");
            sb.Append("  RawJson: ").Append(RawJson).Append("\n");
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
