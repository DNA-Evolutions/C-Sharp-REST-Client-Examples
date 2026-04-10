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
using JsonSubTypes;
using System.ComponentModel.DataAnnotations;
using FileParameter = Org.OpenAPITools.Client.FileParameter;
using OpenAPIDateConverter = Org.OpenAPITools.Client.OpenAPIDateConverter;
using System.Reflection;

namespace Org.OpenAPITools.Model
{
    /// <summary>
    /// AnyDefAllOfTimeDefs
    /// </summary>
    [JsonConverter(typeof(AnyDefAllOfTimeDefsJsonConverter))]
    [DataContract(Name = "AnyDef_allOf_timeDefs")]
    public partial class AnyDefAllOfTimeDefs : AbstractOpenAPISchema, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnyDefAllOfTimeDefs" /> class
        /// with the <see cref="AnyDef" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of AnyDef.</param>
        public AnyDefAllOfTimeDefs(AnyDef actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnyDefAllOfTimeDefs" /> class
        /// with the <see cref="Day" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of Day.</param>
        public AnyDefAllOfTimeDefs(Day actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnyDefAllOfTimeDefs" /> class
        /// with the <see cref="DayMonth" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of DayMonth.</param>
        public AnyDefAllOfTimeDefs(DayMonth actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnyDefAllOfTimeDefs" /> class
        /// with the <see cref="DayMonthYear" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of DayMonthYear.</param>
        public AnyDefAllOfTimeDefs(DayMonthYear actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnyDefAllOfTimeDefs" /> class
        /// with the <see cref="RangeDay" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of RangeDay.</param>
        public AnyDefAllOfTimeDefs(RangeDay actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnyDefAllOfTimeDefs" /> class
        /// with the <see cref="RangeDayMonth" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of RangeDayMonth.</param>
        public AnyDefAllOfTimeDefs(RangeDayMonth actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnyDefAllOfTimeDefs" /> class
        /// with the <see cref="RangeDayMonthYear" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of RangeDayMonthYear.</param>
        public AnyDefAllOfTimeDefs(RangeDayMonthYear actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnyDefAllOfTimeDefs" /> class
        /// with the <see cref="RangeWeekDay" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of RangeWeekDay.</param>
        public AnyDefAllOfTimeDefs(RangeWeekDay actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnyDefAllOfTimeDefs" /> class
        /// with the <see cref="WeekDay" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of WeekDay.</param>
        public AnyDefAllOfTimeDefs(WeekDay actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }


        private Object _actualInstance;

        /// <summary>
        /// Gets or Sets ActualInstance
        /// </summary>
        public override Object ActualInstance
        {
            get
            {
                return _actualInstance;
            }
            set
            {
                if (value.GetType() == typeof(AnyDef) || value is AnyDef)
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(Day) || value is Day)
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(DayMonth) || value is DayMonth)
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(DayMonthYear) || value is DayMonthYear)
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(RangeDay) || value is RangeDay)
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(RangeDayMonth) || value is RangeDayMonth)
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(RangeDayMonthYear) || value is RangeDayMonthYear)
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(RangeWeekDay) || value is RangeWeekDay)
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(WeekDay) || value is WeekDay)
                {
                    this._actualInstance = value;
                }
                else
                {
                    throw new ArgumentException("Invalid instance found. Must be the following types: AnyDef, Day, DayMonth, DayMonthYear, RangeDay, RangeDayMonth, RangeDayMonthYear, RangeWeekDay, WeekDay");
                }
            }
        }

        /// <summary>
        /// Get the actual instance of `AnyDef`. If the actual instance is not `AnyDef`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of AnyDef</returns>
        public AnyDef GetAnyDef()
        {
            return (AnyDef)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `Day`. If the actual instance is not `Day`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of Day</returns>
        public Day GetDay()
        {
            return (Day)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `DayMonth`. If the actual instance is not `DayMonth`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of DayMonth</returns>
        public DayMonth GetDayMonth()
        {
            return (DayMonth)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `DayMonthYear`. If the actual instance is not `DayMonthYear`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of DayMonthYear</returns>
        public DayMonthYear GetDayMonthYear()
        {
            return (DayMonthYear)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `RangeDay`. If the actual instance is not `RangeDay`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of RangeDay</returns>
        public RangeDay GetRangeDay()
        {
            return (RangeDay)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `RangeDayMonth`. If the actual instance is not `RangeDayMonth`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of RangeDayMonth</returns>
        public RangeDayMonth GetRangeDayMonth()
        {
            return (RangeDayMonth)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `RangeDayMonthYear`. If the actual instance is not `RangeDayMonthYear`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of RangeDayMonthYear</returns>
        public RangeDayMonthYear GetRangeDayMonthYear()
        {
            return (RangeDayMonthYear)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `RangeWeekDay`. If the actual instance is not `RangeWeekDay`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of RangeWeekDay</returns>
        public RangeWeekDay GetRangeWeekDay()
        {
            return (RangeWeekDay)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `WeekDay`. If the actual instance is not `WeekDay`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of WeekDay</returns>
        public WeekDay GetWeekDay()
        {
            return (WeekDay)this.ActualInstance;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AnyDefAllOfTimeDefs {\n");
            sb.Append("  ActualInstance: ").Append(this.ActualInstance).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return JsonConvert.SerializeObject(this.ActualInstance, AnyDefAllOfTimeDefs.SerializerSettings);
        }

        /// <summary>
        /// Converts the JSON string into an instance of AnyDefAllOfTimeDefs
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        /// <returns>An instance of AnyDefAllOfTimeDefs</returns>
        public static AnyDefAllOfTimeDefs FromJson(string jsonString)
        {
            AnyDefAllOfTimeDefs newAnyDefAllOfTimeDefs = null;

            if (string.IsNullOrEmpty(jsonString))
            {
                return newAnyDefAllOfTimeDefs;
            }
            int match = 0;
            List<string> matchedTypes = new List<string>();

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(AnyDef).GetProperty("AdditionalProperties") == null)
                {
                    newAnyDefAllOfTimeDefs = new AnyDefAllOfTimeDefs(JsonConvert.DeserializeObject<AnyDef>(jsonString, AnyDefAllOfTimeDefs.SerializerSettings));
                }
                else
                {
                    newAnyDefAllOfTimeDefs = new AnyDefAllOfTimeDefs(JsonConvert.DeserializeObject<AnyDef>(jsonString, AnyDefAllOfTimeDefs.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("AnyDef");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into AnyDef: {1}", jsonString, exception.ToString()));
            }

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(Day).GetProperty("AdditionalProperties") == null)
                {
                    newAnyDefAllOfTimeDefs = new AnyDefAllOfTimeDefs(JsonConvert.DeserializeObject<Day>(jsonString, AnyDefAllOfTimeDefs.SerializerSettings));
                }
                else
                {
                    newAnyDefAllOfTimeDefs = new AnyDefAllOfTimeDefs(JsonConvert.DeserializeObject<Day>(jsonString, AnyDefAllOfTimeDefs.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("Day");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into Day: {1}", jsonString, exception.ToString()));
            }

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(DayMonth).GetProperty("AdditionalProperties") == null)
                {
                    newAnyDefAllOfTimeDefs = new AnyDefAllOfTimeDefs(JsonConvert.DeserializeObject<DayMonth>(jsonString, AnyDefAllOfTimeDefs.SerializerSettings));
                }
                else
                {
                    newAnyDefAllOfTimeDefs = new AnyDefAllOfTimeDefs(JsonConvert.DeserializeObject<DayMonth>(jsonString, AnyDefAllOfTimeDefs.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("DayMonth");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into DayMonth: {1}", jsonString, exception.ToString()));
            }

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(DayMonthYear).GetProperty("AdditionalProperties") == null)
                {
                    newAnyDefAllOfTimeDefs = new AnyDefAllOfTimeDefs(JsonConvert.DeserializeObject<DayMonthYear>(jsonString, AnyDefAllOfTimeDefs.SerializerSettings));
                }
                else
                {
                    newAnyDefAllOfTimeDefs = new AnyDefAllOfTimeDefs(JsonConvert.DeserializeObject<DayMonthYear>(jsonString, AnyDefAllOfTimeDefs.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("DayMonthYear");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into DayMonthYear: {1}", jsonString, exception.ToString()));
            }

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(RangeDay).GetProperty("AdditionalProperties") == null)
                {
                    newAnyDefAllOfTimeDefs = new AnyDefAllOfTimeDefs(JsonConvert.DeserializeObject<RangeDay>(jsonString, AnyDefAllOfTimeDefs.SerializerSettings));
                }
                else
                {
                    newAnyDefAllOfTimeDefs = new AnyDefAllOfTimeDefs(JsonConvert.DeserializeObject<RangeDay>(jsonString, AnyDefAllOfTimeDefs.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("RangeDay");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into RangeDay: {1}", jsonString, exception.ToString()));
            }

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(RangeDayMonth).GetProperty("AdditionalProperties") == null)
                {
                    newAnyDefAllOfTimeDefs = new AnyDefAllOfTimeDefs(JsonConvert.DeserializeObject<RangeDayMonth>(jsonString, AnyDefAllOfTimeDefs.SerializerSettings));
                }
                else
                {
                    newAnyDefAllOfTimeDefs = new AnyDefAllOfTimeDefs(JsonConvert.DeserializeObject<RangeDayMonth>(jsonString, AnyDefAllOfTimeDefs.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("RangeDayMonth");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into RangeDayMonth: {1}", jsonString, exception.ToString()));
            }

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(RangeDayMonthYear).GetProperty("AdditionalProperties") == null)
                {
                    newAnyDefAllOfTimeDefs = new AnyDefAllOfTimeDefs(JsonConvert.DeserializeObject<RangeDayMonthYear>(jsonString, AnyDefAllOfTimeDefs.SerializerSettings));
                }
                else
                {
                    newAnyDefAllOfTimeDefs = new AnyDefAllOfTimeDefs(JsonConvert.DeserializeObject<RangeDayMonthYear>(jsonString, AnyDefAllOfTimeDefs.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("RangeDayMonthYear");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into RangeDayMonthYear: {1}", jsonString, exception.ToString()));
            }

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(RangeWeekDay).GetProperty("AdditionalProperties") == null)
                {
                    newAnyDefAllOfTimeDefs = new AnyDefAllOfTimeDefs(JsonConvert.DeserializeObject<RangeWeekDay>(jsonString, AnyDefAllOfTimeDefs.SerializerSettings));
                }
                else
                {
                    newAnyDefAllOfTimeDefs = new AnyDefAllOfTimeDefs(JsonConvert.DeserializeObject<RangeWeekDay>(jsonString, AnyDefAllOfTimeDefs.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("RangeWeekDay");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into RangeWeekDay: {1}", jsonString, exception.ToString()));
            }

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(WeekDay).GetProperty("AdditionalProperties") == null)
                {
                    newAnyDefAllOfTimeDefs = new AnyDefAllOfTimeDefs(JsonConvert.DeserializeObject<WeekDay>(jsonString, AnyDefAllOfTimeDefs.SerializerSettings));
                }
                else
                {
                    newAnyDefAllOfTimeDefs = new AnyDefAllOfTimeDefs(JsonConvert.DeserializeObject<WeekDay>(jsonString, AnyDefAllOfTimeDefs.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("WeekDay");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into WeekDay: {1}", jsonString, exception.ToString()));
            }

            if (match == 0)
            {
                throw new InvalidDataException("The JSON string `" + jsonString + "` cannot be deserialized into any schema defined.");
            }
            else if (match > 1)
            {
                throw new InvalidDataException("The JSON string `" + jsonString + "` incorrectly matches more than one schema (should be exactly one match): " + String.Join(",", matchedTypes));
            }

            // deserialization is considered successful at this point if no exception has been thrown.
            return newAnyDefAllOfTimeDefs;
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

    /// <summary>
    /// Custom JSON converter for AnyDefAllOfTimeDefs
    /// </summary>
    public class AnyDefAllOfTimeDefsJsonConverter : JsonConverter
    {
        /// <summary>
        /// To write the JSON string
        /// </summary>
        /// <param name="writer">JSON writer</param>
        /// <param name="value">Object to be converted into a JSON string</param>
        /// <param name="serializer">JSON Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue((string)(typeof(AnyDefAllOfTimeDefs).GetMethod("ToJson").Invoke(value, null)));
        }

        /// <summary>
        /// To convert a JSON string into an object
        /// </summary>
        /// <param name="reader">JSON reader</param>
        /// <param name="objectType">Object type</param>
        /// <param name="existingValue">Existing value</param>
        /// <param name="serializer">JSON Serializer</param>
        /// <returns>The object converted from the JSON string</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch(reader.TokenType) 
            {
                case JsonToken.StartObject:
                    return AnyDefAllOfTimeDefs.FromJson(JObject.Load(reader).ToString(Formatting.None));
                case JsonToken.StartArray:
                    return AnyDefAllOfTimeDefs.FromJson(JArray.Load(reader).ToString(Formatting.None));
                default:
                    return null;
            }
        }

        /// <summary>
        /// Check if the object can be converted
        /// </summary>
        /// <param name="objectType">Object type</param>
        /// <returns>True if the object can be converted</returns>
        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }

}
