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
    /// The geographical address of the Position in case geo-coding will be applied.
    /// </summary>
    [DataContract(Name = "GeoAddress")]
    public partial class GeoAddress : IEquatable<GeoAddress>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeoAddress" /> class.
        /// </summary>
        /// <param name="locationId">The locationId.</param>
        /// <param name="housenumber">The housenumber.</param>
        /// <param name="streetname">The streetname.</param>
        /// <param name="city">The city.</param>
        /// <param name="county">The county.</param>
        /// <param name="state">The state.</param>
        /// <param name="statecode">The statecode.</param>
        /// <param name="country">The country.</param>
        /// <param name="macrocountry">The macrocountry.</param>
        /// <param name="countrycode">The country code (ISO CODE).</param>
        /// <param name="postalcode">The postalcode.</param>
        /// <param name="layer">The layer.</param>
        /// <param name="source">The source the data was extracted from.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <param name="confidence">This is a general score computed to calculate how likely result is what was asked for. It&#39;s meant to be a combination of all the information available to Pelias. It&#39;s not super sophisticated, and results may not be sorted in confidence-score order. In that case results returned first should be trusted more. Confidence scores are floating point numbers ranging from &#39;0.0&#39; to &#39;1.0&#39;..</param>
        /// <param name="label">The label.</param>
        public GeoAddress(string locationId = default(string), string housenumber = default(string), string streetname = default(string), string city = default(string), string county = default(string), string state = default(string), string statecode = default(string), string country = default(string), string macrocountry = default(string), string countrycode = default(string), string postalcode = default(string), string layer = default(string), string source = default(string), string accuracy = default(string), double confidence = default(double), string label = default(string))
        {
            this.LocationId = locationId;
            this.Housenumber = housenumber;
            this.Streetname = streetname;
            this.City = city;
            this.County = county;
            this.State = state;
            this.Statecode = statecode;
            this.Country = country;
            this.Macrocountry = macrocountry;
            this.Countrycode = countrycode;
            this.Postalcode = postalcode;
            this.Layer = layer;
            this.Source = source;
            this.Accuracy = accuracy;
            this.Confidence = confidence;
            this.Label = label;
        }

        /// <summary>
        /// The locationId
        /// </summary>
        /// <value>The locationId</value>
        [DataMember(Name = "locationId", EmitDefaultValue = false)]
        public string LocationId { get; set; }

        /// <summary>
        /// The housenumber
        /// </summary>
        /// <value>The housenumber</value>
        [DataMember(Name = "housenumber", EmitDefaultValue = false)]
        public string Housenumber { get; set; }

        /// <summary>
        /// The streetname
        /// </summary>
        /// <value>The streetname</value>
        [DataMember(Name = "streetname", EmitDefaultValue = false)]
        public string Streetname { get; set; }

        /// <summary>
        /// The city
        /// </summary>
        /// <value>The city</value>
        [DataMember(Name = "city", EmitDefaultValue = false)]
        public string City { get; set; }

        /// <summary>
        /// The county
        /// </summary>
        /// <value>The county</value>
        [DataMember(Name = "county", EmitDefaultValue = false)]
        public string County { get; set; }

        /// <summary>
        /// The state
        /// </summary>
        /// <value>The state</value>
        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string State { get; set; }

        /// <summary>
        /// The statecode
        /// </summary>
        /// <value>The statecode</value>
        [DataMember(Name = "statecode", EmitDefaultValue = false)]
        public string Statecode { get; set; }

        /// <summary>
        /// The country
        /// </summary>
        /// <value>The country</value>
        [DataMember(Name = "country", EmitDefaultValue = false)]
        public string Country { get; set; }

        /// <summary>
        /// The macrocountry
        /// </summary>
        /// <value>The macrocountry</value>
        [DataMember(Name = "macrocountry", EmitDefaultValue = false)]
        public string Macrocountry { get; set; }

        /// <summary>
        /// The country code (ISO CODE)
        /// </summary>
        /// <value>The country code (ISO CODE)</value>
        [DataMember(Name = "countrycode", EmitDefaultValue = false)]
        public string Countrycode { get; set; }

        /// <summary>
        /// The postalcode
        /// </summary>
        /// <value>The postalcode</value>
        [DataMember(Name = "postalcode", EmitDefaultValue = false)]
        public string Postalcode { get; set; }

        /// <summary>
        /// The layer
        /// </summary>
        /// <value>The layer</value>
        [DataMember(Name = "layer", EmitDefaultValue = false)]
        public string Layer { get; set; }

        /// <summary>
        /// The source the data was extracted from
        /// </summary>
        /// <value>The source the data was extracted from</value>
        [DataMember(Name = "source", EmitDefaultValue = false)]
        public string Source { get; set; }

        /// <summary>
        /// The accuracy
        /// </summary>
        /// <value>The accuracy</value>
        [DataMember(Name = "accuracy", EmitDefaultValue = false)]
        public string Accuracy { get; set; }

        /// <summary>
        /// This is a general score computed to calculate how likely result is what was asked for. It&#39;s meant to be a combination of all the information available to Pelias. It&#39;s not super sophisticated, and results may not be sorted in confidence-score order. In that case results returned first should be trusted more. Confidence scores are floating point numbers ranging from &#39;0.0&#39; to &#39;1.0&#39;.
        /// </summary>
        /// <value>This is a general score computed to calculate how likely result is what was asked for. It&#39;s meant to be a combination of all the information available to Pelias. It&#39;s not super sophisticated, and results may not be sorted in confidence-score order. In that case results returned first should be trusted more. Confidence scores are floating point numbers ranging from &#39;0.0&#39; to &#39;1.0&#39;.</value>
        [DataMember(Name = "confidence", EmitDefaultValue = false)]
        public double Confidence { get; set; }

        /// <summary>
        /// The label
        /// </summary>
        /// <value>The label</value>
        [DataMember(Name = "label", EmitDefaultValue = false)]
        public string Label { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GeoAddress {\n");
            sb.Append("  LocationId: ").Append(LocationId).Append("\n");
            sb.Append("  Housenumber: ").Append(Housenumber).Append("\n");
            sb.Append("  Streetname: ").Append(Streetname).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  County: ").Append(County).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  Statecode: ").Append(Statecode).Append("\n");
            sb.Append("  Country: ").Append(Country).Append("\n");
            sb.Append("  Macrocountry: ").Append(Macrocountry).Append("\n");
            sb.Append("  Countrycode: ").Append(Countrycode).Append("\n");
            sb.Append("  Postalcode: ").Append(Postalcode).Append("\n");
            sb.Append("  Layer: ").Append(Layer).Append("\n");
            sb.Append("  Source: ").Append(Source).Append("\n");
            sb.Append("  Accuracy: ").Append(Accuracy).Append("\n");
            sb.Append("  Confidence: ").Append(Confidence).Append("\n");
            sb.Append("  Label: ").Append(Label).Append("\n");
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
            return this.Equals(input as GeoAddress);
        }

        /// <summary>
        /// Returns true if GeoAddress instances are equal
        /// </summary>
        /// <param name="input">Instance of GeoAddress to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GeoAddress input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.LocationId == input.LocationId ||
                    (this.LocationId != null &&
                    this.LocationId.Equals(input.LocationId))
                ) && 
                (
                    this.Housenumber == input.Housenumber ||
                    (this.Housenumber != null &&
                    this.Housenumber.Equals(input.Housenumber))
                ) && 
                (
                    this.Streetname == input.Streetname ||
                    (this.Streetname != null &&
                    this.Streetname.Equals(input.Streetname))
                ) && 
                (
                    this.City == input.City ||
                    (this.City != null &&
                    this.City.Equals(input.City))
                ) && 
                (
                    this.County == input.County ||
                    (this.County != null &&
                    this.County.Equals(input.County))
                ) && 
                (
                    this.State == input.State ||
                    (this.State != null &&
                    this.State.Equals(input.State))
                ) && 
                (
                    this.Statecode == input.Statecode ||
                    (this.Statecode != null &&
                    this.Statecode.Equals(input.Statecode))
                ) && 
                (
                    this.Country == input.Country ||
                    (this.Country != null &&
                    this.Country.Equals(input.Country))
                ) && 
                (
                    this.Macrocountry == input.Macrocountry ||
                    (this.Macrocountry != null &&
                    this.Macrocountry.Equals(input.Macrocountry))
                ) && 
                (
                    this.Countrycode == input.Countrycode ||
                    (this.Countrycode != null &&
                    this.Countrycode.Equals(input.Countrycode))
                ) && 
                (
                    this.Postalcode == input.Postalcode ||
                    (this.Postalcode != null &&
                    this.Postalcode.Equals(input.Postalcode))
                ) && 
                (
                    this.Layer == input.Layer ||
                    (this.Layer != null &&
                    this.Layer.Equals(input.Layer))
                ) && 
                (
                    this.Source == input.Source ||
                    (this.Source != null &&
                    this.Source.Equals(input.Source))
                ) && 
                (
                    this.Accuracy == input.Accuracy ||
                    (this.Accuracy != null &&
                    this.Accuracy.Equals(input.Accuracy))
                ) && 
                (
                    this.Confidence == input.Confidence ||
                    this.Confidence.Equals(input.Confidence)
                ) && 
                (
                    this.Label == input.Label ||
                    (this.Label != null &&
                    this.Label.Equals(input.Label))
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
                if (this.LocationId != null)
                {
                    hashCode = (hashCode * 59) + this.LocationId.GetHashCode();
                }
                if (this.Housenumber != null)
                {
                    hashCode = (hashCode * 59) + this.Housenumber.GetHashCode();
                }
                if (this.Streetname != null)
                {
                    hashCode = (hashCode * 59) + this.Streetname.GetHashCode();
                }
                if (this.City != null)
                {
                    hashCode = (hashCode * 59) + this.City.GetHashCode();
                }
                if (this.County != null)
                {
                    hashCode = (hashCode * 59) + this.County.GetHashCode();
                }
                if (this.State != null)
                {
                    hashCode = (hashCode * 59) + this.State.GetHashCode();
                }
                if (this.Statecode != null)
                {
                    hashCode = (hashCode * 59) + this.Statecode.GetHashCode();
                }
                if (this.Country != null)
                {
                    hashCode = (hashCode * 59) + this.Country.GetHashCode();
                }
                if (this.Macrocountry != null)
                {
                    hashCode = (hashCode * 59) + this.Macrocountry.GetHashCode();
                }
                if (this.Countrycode != null)
                {
                    hashCode = (hashCode * 59) + this.Countrycode.GetHashCode();
                }
                if (this.Postalcode != null)
                {
                    hashCode = (hashCode * 59) + this.Postalcode.GetHashCode();
                }
                if (this.Layer != null)
                {
                    hashCode = (hashCode * 59) + this.Layer.GetHashCode();
                }
                if (this.Source != null)
                {
                    hashCode = (hashCode * 59) + this.Source.GetHashCode();
                }
                if (this.Accuracy != null)
                {
                    hashCode = (hashCode * 59) + this.Accuracy.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Confidence.GetHashCode();
                if (this.Label != null)
                {
                    hashCode = (hashCode * 59) + this.Label.GetHashCode();
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