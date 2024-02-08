/*
 * DNA Evolutions - JOpt.TourOptimizer
 *
 * This is DNA's JOpt.TourOptimizer service. A RESTful Spring Boot application using springdoc-openapi and OpenAPI 3. JOpt.TourOpptimizer is a service that delivers route optimization and automatic scheduling features to be easily integrated into any third-party application. JOpt.TourOpptimizer encapsulates all necessary optimization functionality and provides a comprehensive REST API that offers a domain-specific optimization interface for the transportation industry. The service is stateless and does not come with graphical user interfaces, map depiction or any databases. These extensions and adjustments are supposed to be introduced by the consumer of the service while integrating it into his/her own application. The service will allow for many suitable adjustments and user-specific settings to adjust the behaviour and optimization goals (e.g. minimizing distance, maximizing resource utilization, etc.) through a comprehensive set of functions. This will enable you to gain control of the complete optimization processes.This service is based on JOpt (null)
 *
 * The version of the OpenAPI document: 1.2.6-SNAPSHOT
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
    /// The extension of the configuration. For example, to provide a license.
    /// </summary>
    [DataContract(Name = "JSONConfig")]
    public partial class JSONConfig : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JSONConfig" /> class.
        /// </summary>
        /// <param name="creatorSetting">creatorSetting.</param>
        /// <param name="textSolution">textSolution.</param>
        /// <param name="keySetting">keySetting.</param>
        /// <param name="persistenceSetting">persistenceSetting.</param>
        /// <param name="pluginSettings">pluginSettings.</param>
        /// <param name="timeOut">The timeout for the optimization run..</param>
        public JSONConfig(CreatorSetting creatorSetting = default(CreatorSetting), TextSolution textSolution = default(TextSolution), OptimizationKeySetting keySetting = default(OptimizationKeySetting), OptimizationPersistenceSetting persistenceSetting = default(OptimizationPersistenceSetting), PluginSettings pluginSettings = default(PluginSettings), string timeOut = default(string))
        {
            this.CreatorSetting = creatorSetting;
            this.TextSolution = textSolution;
            this.KeySetting = keySetting;
            this.PersistenceSetting = persistenceSetting;
            this.PluginSettings = pluginSettings;
            this.TimeOut = timeOut;
        }

        /// <summary>
        /// Gets or Sets CreatorSetting
        /// </summary>
        [DataMember(Name = "creatorSetting", EmitDefaultValue = false)]
        public CreatorSetting CreatorSetting { get; set; }

        /// <summary>
        /// Gets or Sets TextSolution
        /// </summary>
        [DataMember(Name = "textSolution", EmitDefaultValue = false)]
        public TextSolution TextSolution { get; set; }

        /// <summary>
        /// Gets or Sets KeySetting
        /// </summary>
        [DataMember(Name = "keySetting", EmitDefaultValue = false)]
        public OptimizationKeySetting KeySetting { get; set; }

        /// <summary>
        /// Gets or Sets PersistenceSetting
        /// </summary>
        [DataMember(Name = "persistenceSetting", EmitDefaultValue = false)]
        public OptimizationPersistenceSetting PersistenceSetting { get; set; }

        /// <summary>
        /// Gets or Sets PluginSettings
        /// </summary>
        [DataMember(Name = "pluginSettings", EmitDefaultValue = false)]
        public PluginSettings PluginSettings { get; set; }

        /// <summary>
        /// The timeout for the optimization run.
        /// </summary>
        /// <value>The timeout for the optimization run.</value>
        /// <example>PT2H</example>
        [DataMember(Name = "timeOut", EmitDefaultValue = false)]
        public string TimeOut { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class JSONConfig {\n");
            sb.Append("  CreatorSetting: ").Append(CreatorSetting).Append("\n");
            sb.Append("  TextSolution: ").Append(TextSolution).Append("\n");
            sb.Append("  KeySetting: ").Append(KeySetting).Append("\n");
            sb.Append("  PersistenceSetting: ").Append(PersistenceSetting).Append("\n");
            sb.Append("  PluginSettings: ").Append(PluginSettings).Append("\n");
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
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
