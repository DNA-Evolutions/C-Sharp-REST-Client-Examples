/*
 * DNA Evolutions - JOpt.TourOptimizer
 *
 * # JOpt.TourOptimizer REST API  ![DNA Evolutions Logo](https://www.dna-evolutions.com/images/dna_logo.png)  JOpt.TourOptimizer is DNA Evolutions' route optimization and scheduling engine for transportation, field service, and resource planning scenarios.  This API is a **reactive Spring WebFlux REST service** with an **OpenAPI 3** contract, designed for integration into third-party systems and for generating typed client SDKs directly from the schema.  - --  ## Endpoint groups  ### Job endpoints (`job`)  The primary integration model for all deployments with a connected database.  Submit an optimization job with `POST /api/v1/jobs` and receive an HTTP 202 response containing a unique `jobId`. Use that jobId to poll for status, progress, warnings, errors, and the final result at any time — no open connection required.  | Endpoint | Description | Availability | |- --|- --|- --| | `POST /api/v1/jobs` | Submit an async optimization job | All deployments | | `GET /api/v1/jobs/{jobId}/status` | Poll job status | All deployments | | `GET /api/v1/jobs/{jobId}/result` | Retrieve full optimization result | All deployments | | `GET /api/v1/jobs/{jobId}/solution` | Retrieve solution payload only | All deployments | | `GET /api/v1/jobs/{jobId}/progress` | Retrieve progress snapshots | All deployments | | `GET /api/v1/jobs/{jobId}/warnings` | Retrieve warning messages | All deployments | | `GET /api/v1/jobs/{jobId}/errors` | Retrieve error messages | All deployments | | `GET /api/v1/jobs/{jobId}/export` | Download result as ZIP archive | All deployments | | `POST /api/v1/jobs/{jobId}/stop` | Send graceful stop signal to a running job | All deployments | | `DELETE /api/v1/jobs/{jobId}` | Delete all persisted data for a job | All deployments | | `POST /api/v1/jobs/search` | Search jobs by metadata criteria | On-premise (free-search enabled) | | `POST /api/v1/jobs/import` | Import a pre-computed result directly | On-premise (import enabled) |  All job endpoints require the `X-Tenant-Id` header, injected by the API gateway. The `jobId` returned at submission is the only token needed for all subsequent reads.  ### Synchronous run endpoints (`optimization`)  Available on on-premise installations with synchronous mode enabled. The client holds the HTTP connection open and receives the result directly in the response body.  | Endpoint | Description | |- --|- --| | `POST /api/v1/runs` | Start a run, return runId immediately (HTTP 202) | | `GET /api/v1/runs/{runId}/result` | Block until run completes, return full result | | `GET /api/v1/runs/{runId}/solution` | Block until run completes, return solution only | | `DELETE /api/v1/runs/{runId}` | Stop the run gracefully | | `GET /api/v1/runs/{runId}/started` | One-shot signal when the run has started |  ### Event stream endpoints (`stream`)  Server-Sent Event streams for monitoring a running synchronous optimization in near real time. Subscribe to one or more streams while a `POST /api/v1/runs` call is in progress.  | Endpoint | Event type | |- --|- --| | `GET /api/v1/runs/{runId}/stream/progress` | Progress percentage and timing | | `GET /api/v1/runs/{runId}/stream/status` | Lifecycle status transitions | | `GET /api/v1/runs/{runId}/stream/warnings` | Non-fatal solver warnings | | `GET /api/v1/runs/{runId}/stream/errors` | Solver error events |  ### Health endpoint (`health`)  | Endpoint | Description | |- --|- --| | `GET /api/v1/health` | Service liveness and readiness |  - --  ## Deployment modes and feature flags  Endpoints that require specific conditions are activated via Spring `@Conditional` annotations and application properties. Endpoints not active in a given deployment are absent from the service entirely and do not appear in the runtime spec.  | Condition | Property / annotation | Effect | |- --|- --|- --| | Database connected | `DatabaseEnabledCondition` | Activates all `job` endpoints | | Sync mode | `SynchControllersEnabledCondition` | Activates `optimization` and `stream` endpoints | | Free search | `DatabaseFreeSearchEnabledCondition` | Activates `POST /api/v1/jobs/search` | | Import | `DatabaseJobImportEnabledCondition` | Activates `POST /api/v1/jobs/import` |  - --  ## Tenant isolation  Every job endpoint is scoped by `X-Tenant-Id`, injected by the API gateway. Persisted documents are tagged with both `jobId` and `tenantId`. A request with a valid `jobId` but a mismatched `tenantId` returns no data. The `jobId` is a UUID v4 (122 bits of randomness) and is not a security credential — security is enforced by the verified `tenantId` from the gateway header.  - --  ## Encryption at rest  Results can be stored encrypted in two modes:  - **CLIENT mode**: key derived from a caller-provided passphrase via PBKDF2.   Pass the same secret in `X-Encryption-Secret` when reading back. - **KMS mode**: server-generated data encryption key (DEK) wrapped by an   external key management service (Azure Key Vault, AWS KMS). Decryption is   transparent to the caller.  The `encrypted` and `sec` fields in `DatabaseInfoSearchResult` indicate which mode was used for each stored result.  - --  ## Client generation  The OpenAPI schema can be used to generate typed clients for any language. The `operationId` values follow `{verb}{Resource}` lowerCamelCase convention (`createJob`, `getJobResult`, `listJobs`, etc.) for predictable generated method names.  - --  This service is based on **JOpt Core (unknown)**. 
 *
 * The version of the OpenAPI document: 1.3.5-SNAPSHOT
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
    /// A structured geographic address used for geocoding. Contains fields for street, house number, postal code, city, country, region, and other GeoJSON-compatible address components. When provided on a Position, the geocoder resolves it to latitude/longitude coordinates.
    /// </summary>
    [DataContract(Name = "GeoAddress")]
    public partial class GeoAddress : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeoAddress" /> class.
        /// </summary>
        /// <param name="locationId">An optional identifier linking this address to a shared location entry..</param>
        /// <param name="housenumber">The house number of the address..</param>
        /// <param name="streetname">The street name of the address (without house number)..</param>
        /// <param name="city">The city or locality name..</param>
        /// <param name="county">The county or administrative district..</param>
        /// <param name="state">The state or region name..</param>
        /// <param name="statecode">The state or region code (abbreviated form, e.g. &#39;NSW&#39;, &#39;BY&#39;)..</param>
        /// <param name="country">The country name (e.g. &#39;Germany&#39;, &#39;Australia&#39;)..</param>
        /// <param name="macrocountry">The macro-country or metropolitan region (e.g. &#39;Berlin&#39;, &#39;Sydney&#39;)..</param>
        /// <param name="countrycode">The country code (ISO CODE).</param>
        /// <param name="postalcode">The postal or ZIP code..</param>
        /// <param name="layer">The geocoding layer (e.g. &#39;address&#39;, &#39;venue&#39;, &#39;street&#39;) indicating the granularity of the match..</param>
        /// <param name="source">The geocoding data source (e.g. &#39;openstreetmap&#39;, &#39;geonames&#39;) that provided this address..</param>
        /// <param name="accuracy">The accuracy level of the geocoding result (e.g. &#39;point&#39;, &#39;centroid&#39;, &#39;interpolated&#39;)..</param>
        /// <param name="confidence">This is a general score computed to calculate how likely result is what was asked for. It&#39;s meant to be a combination of all the information available to Pelias. It&#39;s not super sophisticated, and results may not be sorted in confidence-score order. In that case results returned first should be trusted more. Confidence scores are floating point numbers ranging from &#39;0.0&#39; to &#39;1.0&#39;..</param>
        /// <param name="label">A fully formatted address label combining all available components (e.g. &#39;495 Old South Head Road, Rose Bay, NSW, Australia&#39;)..</param>
        public GeoAddress(string locationId = default, string housenumber = default, string streetname = default, string city = default, string county = default, string state = default, string statecode = default, string country = default, string macrocountry = default, string countrycode = default, string postalcode = default, string layer = default, string source = default, string accuracy = default, double confidence = default, string label = default)
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
        /// An optional identifier linking this address to a shared location entry.
        /// </summary>
        /// <value>An optional identifier linking this address to a shared location entry.</value>
        /*
        <example>MyLocationId</example>
        */
        [DataMember(Name = "locationId", EmitDefaultValue = false)]
        public string LocationId { get; set; }

        /// <summary>
        /// The house number of the address.
        /// </summary>
        /// <value>The house number of the address.</value>
        /*
        <example>5</example>
        */
        [DataMember(Name = "housenumber", EmitDefaultValue = false)]
        public string Housenumber { get; set; }

        /// <summary>
        /// The street name of the address (without house number).
        /// </summary>
        /// <value>The street name of the address (without house number).</value>
        /*
        <example>Marlene-Dietrich-Strasse</example>
        */
        [DataMember(Name = "streetname", EmitDefaultValue = false)]
        public string Streetname { get; set; }

        /// <summary>
        /// The city or locality name.
        /// </summary>
        /// <value>The city or locality name.</value>
        /*
        <example>Neu-Ulm</example>
        */
        [DataMember(Name = "city", EmitDefaultValue = false)]
        public string City { get; set; }

        /// <summary>
        /// The county or administrative district.
        /// </summary>
        /// <value>The county or administrative district.</value>
        [DataMember(Name = "county", EmitDefaultValue = false)]
        public string County { get; set; }

        /// <summary>
        /// The state or region name.
        /// </summary>
        /// <value>The state or region name.</value>
        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string State { get; set; }

        /// <summary>
        /// The state or region code (abbreviated form, e.g. &#39;NSW&#39;, &#39;BY&#39;).
        /// </summary>
        /// <value>The state or region code (abbreviated form, e.g. &#39;NSW&#39;, &#39;BY&#39;).</value>
        [DataMember(Name = "statecode", EmitDefaultValue = false)]
        public string Statecode { get; set; }

        /// <summary>
        /// The country name (e.g. &#39;Germany&#39;, &#39;Australia&#39;).
        /// </summary>
        /// <value>The country name (e.g. &#39;Germany&#39;, &#39;Australia&#39;).</value>
        /*
        <example>Germany</example>
        */
        [DataMember(Name = "country", EmitDefaultValue = false)]
        public string Country { get; set; }

        /// <summary>
        /// The macro-country or metropolitan region (e.g. &#39;Berlin&#39;, &#39;Sydney&#39;).
        /// </summary>
        /// <value>The macro-country or metropolitan region (e.g. &#39;Berlin&#39;, &#39;Sydney&#39;).</value>
        /*
        <example>Berlin</example>
        */
        [DataMember(Name = "macrocountry", EmitDefaultValue = false)]
        public string Macrocountry { get; set; }

        /// <summary>
        /// The country code (ISO CODE)
        /// </summary>
        /// <value>The country code (ISO CODE)</value>
        /*
        <example>DE</example>
        */
        [DataMember(Name = "countrycode", EmitDefaultValue = false)]
        public string Countrycode { get; set; }

        /// <summary>
        /// The postal or ZIP code.
        /// </summary>
        /// <value>The postal or ZIP code.</value>
        /*
        <example>89231</example>
        */
        [DataMember(Name = "postalcode", EmitDefaultValue = false)]
        public string Postalcode { get; set; }

        /// <summary>
        /// The geocoding layer (e.g. &#39;address&#39;, &#39;venue&#39;, &#39;street&#39;) indicating the granularity of the match.
        /// </summary>
        /// <value>The geocoding layer (e.g. &#39;address&#39;, &#39;venue&#39;, &#39;street&#39;) indicating the granularity of the match.</value>
        [DataMember(Name = "layer", EmitDefaultValue = false)]
        public string Layer { get; set; }

        /// <summary>
        /// The geocoding data source (e.g. &#39;openstreetmap&#39;, &#39;geonames&#39;) that provided this address.
        /// </summary>
        /// <value>The geocoding data source (e.g. &#39;openstreetmap&#39;, &#39;geonames&#39;) that provided this address.</value>
        [DataMember(Name = "source", EmitDefaultValue = false)]
        public string Source { get; set; }

        /// <summary>
        /// The accuracy level of the geocoding result (e.g. &#39;point&#39;, &#39;centroid&#39;, &#39;interpolated&#39;).
        /// </summary>
        /// <value>The accuracy level of the geocoding result (e.g. &#39;point&#39;, &#39;centroid&#39;, &#39;interpolated&#39;).</value>
        [DataMember(Name = "accuracy", EmitDefaultValue = false)]
        public string Accuracy { get; set; }

        /// <summary>
        /// This is a general score computed to calculate how likely result is what was asked for. It&#39;s meant to be a combination of all the information available to Pelias. It&#39;s not super sophisticated, and results may not be sorted in confidence-score order. In that case results returned first should be trusted more. Confidence scores are floating point numbers ranging from &#39;0.0&#39; to &#39;1.0&#39;.
        /// </summary>
        /// <value>This is a general score computed to calculate how likely result is what was asked for. It&#39;s meant to be a combination of all the information available to Pelias. It&#39;s not super sophisticated, and results may not be sorted in confidence-score order. In that case results returned first should be trusted more. Confidence scores are floating point numbers ranging from &#39;0.0&#39; to &#39;1.0&#39;.</value>
        /*
        <example>1.0</example>
        */
        [DataMember(Name = "confidence", EmitDefaultValue = false)]
        public double Confidence { get; set; }

        /// <summary>
        /// A fully formatted address label combining all available components (e.g. &#39;495 Old South Head Road, Rose Bay, NSW, Australia&#39;).
        /// </summary>
        /// <value>A fully formatted address label combining all available components (e.g. &#39;495 Old South Head Road, Rose Bay, NSW, Australia&#39;).</value>
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
