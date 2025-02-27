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
    /// DatabaseEncryptedItemSearch model for a databse serach of encypted items
    /// </summary>
    [DataContract(Name = "DatabaseEncryptedItemSearch")]
    public partial class DatabaseEncryptedItemSearch : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseEncryptedItemSearch" /> class.
        /// </summary>
        /// <param name="creator">A related creator..</param>
        /// <param name="id">The unique id.Can not be empty..</param>
        /// <param name="timeOut">The timeOut for the request. By default one minute.</param>
        /// <param name="secret">An optional password for encryption. Can not be empty..</param>
        public DatabaseEncryptedItemSearch(string creator = default(string), string id = default(string), string timeOut = default(string), string secret = default(string))
        {
            this.Creator = creator;
            this.Id = id;
            this.TimeOut = timeOut;
            this.Secret = secret;
        }

        /// <summary>
        /// A related creator.
        /// </summary>
        /// <value>A related creator.</value>
        /*
        <example>DEFAULT_DNA_CREATOR</example>
        */
        [DataMember(Name = "creator", EmitDefaultValue = false)]
        public string Creator { get; set; }

        /// <summary>
        /// The unique id.Can not be empty.
        /// </summary>
        /// <value>The unique id.Can not be empty.</value>
        /*
        <example>6274e36cc36712358912bf35</example>
        */
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// The timeOut for the request. By default one minute
        /// </summary>
        /// <value>The timeOut for the request. By default one minute</value>
        /*
        <example>PT1M</example>
        */
        [DataMember(Name = "timeOut", EmitDefaultValue = false)]
        public string TimeOut { get; set; }

        /// <summary>
        /// An optional password for encryption. Can not be empty.
        /// </summary>
        /// <value>An optional password for encryption. Can not be empty.</value>
        /*
        <example>MySecretPassword</example>
        */
        [DataMember(Name = "secret", EmitDefaultValue = false)]
        public string Secret { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class DatabaseEncryptedItemSearch {\n");
            sb.Append("  Creator: ").Append(Creator).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  TimeOut: ").Append(TimeOut).Append("\n");
            sb.Append("  Secret: ").Append(Secret).Append("\n");
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
