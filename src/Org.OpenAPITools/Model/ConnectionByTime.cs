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
    /// The connectionByTime defines an extension to the connection. For example, on Monday morning we need 2 hours to path a connection, whereas on Sunday morning we only need 1 hour.
    /// </summary>
    [DataContract(Name = "ConnectionByTime")]
    public partial class ConnectionByTime : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionByTime" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ConnectionByTime() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionByTime" /> class.
        /// </summary>
        /// <param name="timeDefinitions">The timeDefinitions describe at which times, what connection should be used. (required).</param>
        /// <param name="timeMillis">The times to pass the connection in milliseconds for the underlying time defitions. (required).</param>
        /// <param name="distanceMeters">The length of the connection in meters. (required).</param>
        public ConnectionByTime(List<Object> timeDefinitions = default(List<Object>), List<long> timeMillis = default(List<long>), List<double> distanceMeters = default(List<double>))
        {
            // to ensure "timeDefinitions" is required (not null)
            if (timeDefinitions == null)
            {
                throw new ArgumentNullException("timeDefinitions is a required property for ConnectionByTime and cannot be null");
            }
            this.TimeDefinitions = timeDefinitions;
            // to ensure "timeMillis" is required (not null)
            if (timeMillis == null)
            {
                throw new ArgumentNullException("timeMillis is a required property for ConnectionByTime and cannot be null");
            }
            this.TimeMillis = timeMillis;
            // to ensure "distanceMeters" is required (not null)
            if (distanceMeters == null)
            {
                throw new ArgumentNullException("distanceMeters is a required property for ConnectionByTime and cannot be null");
            }
            this.DistanceMeters = distanceMeters;
        }

        /// <summary>
        /// The timeDefinitions describe at which times, what connection should be used.
        /// </summary>
        /// <value>The timeDefinitions describe at which times, what connection should be used.</value>
        [DataMember(Name = "timeDefinitions", IsRequired = true, EmitDefaultValue = true)]
        public List<Object> TimeDefinitions { get; set; }

        /// <summary>
        /// The times to pass the connection in milliseconds for the underlying time defitions.
        /// </summary>
        /// <value>The times to pass the connection in milliseconds for the underlying time defitions.</value>
        [DataMember(Name = "timeMillis", IsRequired = true, EmitDefaultValue = true)]
        public List<long> TimeMillis { get; set; }

        /// <summary>
        /// The length of the connection in meters.
        /// </summary>
        /// <value>The length of the connection in meters.</value>
        [DataMember(Name = "distanceMeters", IsRequired = true, EmitDefaultValue = true)]
        public List<double> DistanceMeters { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ConnectionByTime {\n");
            sb.Append("  TimeDefinitions: ").Append(TimeDefinitions).Append("\n");
            sb.Append("  TimeMillis: ").Append(TimeMillis).Append("\n");
            sb.Append("  DistanceMeters: ").Append(DistanceMeters).Append("\n");
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
