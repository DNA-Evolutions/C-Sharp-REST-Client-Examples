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
    /// The mongoSettings
    /// </summary>
    [DataContract(Name = "MongoOptimizationPersistenceSetting")]
    public partial class MongoOptimizationPersistenceSetting : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MongoOptimizationPersistenceSetting" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected MongoOptimizationPersistenceSetting() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="MongoOptimizationPersistenceSetting" /> class.
        /// </summary>
        /// <param name="enablePersistence">The enablePersistence (required).</param>
        /// <param name="secret">The secret that encrypts the result. If empty, no encryption is assigned. Important: Metadata and stream information like progress is always saved as decrypted clear text. Attention: The secret is not saved by DNA evolutions. If you loose the secret, the file CAN NOT be restored. (required).</param>
        /// <param name="expiry">The document will be automatically deleted after this duration. The default value is 48 hours..</param>
        /// <param name="optimizationPersistenceStratgySetting">optimizationPersistenceStratgySetting (required).</param>
        /// <param name="streamPersistenceStratgySetting">streamPersistenceStratgySetting (required).</param>
        public MongoOptimizationPersistenceSetting(bool enablePersistence = default(bool), string secret = default(string), string expiry = default(string), OptimizationPersistenceStratgySetting optimizationPersistenceStratgySetting = default(OptimizationPersistenceStratgySetting), StreamPersistenceStratgySetting streamPersistenceStratgySetting = default(StreamPersistenceStratgySetting))
        {
            this.EnablePersistence = enablePersistence;
            // to ensure "secret" is required (not null)
            if (secret == null)
            {
                throw new ArgumentNullException("secret is a required property for MongoOptimizationPersistenceSetting and cannot be null");
            }
            this.Secret = secret;
            // to ensure "optimizationPersistenceStratgySetting" is required (not null)
            if (optimizationPersistenceStratgySetting == null)
            {
                throw new ArgumentNullException("optimizationPersistenceStratgySetting is a required property for MongoOptimizationPersistenceSetting and cannot be null");
            }
            this.OptimizationPersistenceStratgySetting = optimizationPersistenceStratgySetting;
            // to ensure "streamPersistenceStratgySetting" is required (not null)
            if (streamPersistenceStratgySetting == null)
            {
                throw new ArgumentNullException("streamPersistenceStratgySetting is a required property for MongoOptimizationPersistenceSetting and cannot be null");
            }
            this.StreamPersistenceStratgySetting = streamPersistenceStratgySetting;
            this.Expiry = expiry;
        }

        /// <summary>
        /// The enablePersistence
        /// </summary>
        /// <value>The enablePersistence</value>
        [DataMember(Name = "enablePersistence", IsRequired = true, EmitDefaultValue = true)]
        public bool EnablePersistence { get; set; }

        /// <summary>
        /// The secret that encrypts the result. If empty, no encryption is assigned. Important: Metadata and stream information like progress is always saved as decrypted clear text. Attention: The secret is not saved by DNA evolutions. If you loose the secret, the file CAN NOT be restored.
        /// </summary>
        /// <value>The secret that encrypts the result. If empty, no encryption is assigned. Important: Metadata and stream information like progress is always saved as decrypted clear text. Attention: The secret is not saved by DNA evolutions. If you loose the secret, the file CAN NOT be restored.</value>
        [DataMember(Name = "secret", IsRequired = true, EmitDefaultValue = true)]
        public string Secret { get; set; }

        /// <summary>
        /// The document will be automatically deleted after this duration. The default value is 48 hours.
        /// </summary>
        /// <value>The document will be automatically deleted after this duration. The default value is 48 hours.</value>
        /*
        <example>PT48H</example>
        */
        [DataMember(Name = "expiry", EmitDefaultValue = false)]
        public string Expiry { get; set; }

        /// <summary>
        /// Gets or Sets OptimizationPersistenceStratgySetting
        /// </summary>
        [DataMember(Name = "optimizationPersistenceStratgySetting", IsRequired = true, EmitDefaultValue = true)]
        public OptimizationPersistenceStratgySetting OptimizationPersistenceStratgySetting { get; set; }

        /// <summary>
        /// Gets or Sets StreamPersistenceStratgySetting
        /// </summary>
        [DataMember(Name = "streamPersistenceStratgySetting", IsRequired = true, EmitDefaultValue = true)]
        public StreamPersistenceStratgySetting StreamPersistenceStratgySetting { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class MongoOptimizationPersistenceSetting {\n");
            sb.Append("  EnablePersistence: ").Append(EnablePersistence).Append("\n");
            sb.Append("  Secret: ").Append(Secret).Append("\n");
            sb.Append("  Expiry: ").Append(Expiry).Append("\n");
            sb.Append("  OptimizationPersistenceStratgySetting: ").Append(OptimizationPersistenceStratgySetting).Append("\n");
            sb.Append("  StreamPersistenceStratgySetting: ").Append(StreamPersistenceStratgySetting).Append("\n");
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
