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
        /// <param name="requireUniqueIdentCreatorCombination">The requireUniqueIdentCreatorCombination (required).</param>
        /// <param name="secret">The secret that encrypts the result. If empty, no encryption is assigned. Important: Metadata and stream information like progress is always saved as decrypted clear text. Attention: The secret is not saved by DNA evolutions. If you loose the secret, the file CAN NOT be restored. (required).</param>
        /// <param name="expiry">The document will be automatically deleted after this duration. The default value is 48 hours..</param>
        /// <param name="optimizationPersistenceStrategySetting">optimizationPersistenceStrategySetting (required).</param>
        /// <param name="streamPersistenceStrategySetting">streamPersistenceStrategySetting (required).</param>
        /// <param name="completionWebhookUrl">Optional URL the server calls (POST) when the job completes or fails. The payload contains jobId, tenantId, status, and completedAt only — no optimization data. Leave empty to disable. URL validation is controlled by the server&#39;s webhook-validation policy: in strict mode (SaaS default) only public HTTPS URLs are accepted; in relaxed mode (on-premise) HTTP and private network addresses are also allowed; in none mode (local development) any URL is accepted. Loopback addresses (127.x, ::1) are always rejected. Validation is performed at submission time..</param>
        /// <param name="completionWebhookSecret">Optional secret used to sign the webhook payload with HMAC-SHA256. When provided, the server includes an X-JOpt-Signature header on every delivery in the form &#39;sha256&#x3D;&lt;hex&gt;&#39;. The receiver should compute the same HMAC over the raw request body and compare it using a constant-time comparison before trusting the payload. Leave empty to send unsigned webhooks. Unsigned webhooks are acceptable in trusted internal networks but are not recommended when the webhook URL is reachable from untrusted clients..</param>
        public MongoOptimizationPersistenceSetting(bool enablePersistence = default, bool requireUniqueIdentCreatorCombination = default, string secret = default, string expiry = default, OptimizationPersistenceStrategySetting optimizationPersistenceStrategySetting = default, StreamPersistenceStrategySetting streamPersistenceStrategySetting = default, string completionWebhookUrl = default, string completionWebhookSecret = default)
        {
            this.EnablePersistence = enablePersistence;
            this.RequireUniqueIdentCreatorCombination = requireUniqueIdentCreatorCombination;
            // to ensure "secret" is required (not null)
            if (secret == null)
            {
                throw new ArgumentNullException("secret is a required property for MongoOptimizationPersistenceSetting and cannot be null");
            }
            this.Secret = secret;
            // to ensure "optimizationPersistenceStrategySetting" is required (not null)
            if (optimizationPersistenceStrategySetting == null)
            {
                throw new ArgumentNullException("optimizationPersistenceStrategySetting is a required property for MongoOptimizationPersistenceSetting and cannot be null");
            }
            this.OptimizationPersistenceStrategySetting = optimizationPersistenceStrategySetting;
            // to ensure "streamPersistenceStrategySetting" is required (not null)
            if (streamPersistenceStrategySetting == null)
            {
                throw new ArgumentNullException("streamPersistenceStrategySetting is a required property for MongoOptimizationPersistenceSetting and cannot be null");
            }
            this.StreamPersistenceStrategySetting = streamPersistenceStrategySetting;
            this.Expiry = expiry;
            this.CompletionWebhookUrl = completionWebhookUrl;
            this.CompletionWebhookSecret = completionWebhookSecret;
        }

        /// <summary>
        /// The enablePersistence
        /// </summary>
        /// <value>The enablePersistence</value>
        [DataMember(Name = "enablePersistence", IsRequired = true, EmitDefaultValue = true)]
        public bool EnablePersistence { get; set; }

        /// <summary>
        /// The requireUniqueIdentCreatorCombination
        /// </summary>
        /// <value>The requireUniqueIdentCreatorCombination</value>
        [DataMember(Name = "requireUniqueIdentCreatorCombination", IsRequired = true, EmitDefaultValue = true)]
        public bool RequireUniqueIdentCreatorCombination { get; set; }

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
        /// Gets or Sets OptimizationPersistenceStrategySetting
        /// </summary>
        [DataMember(Name = "optimizationPersistenceStrategySetting", IsRequired = true, EmitDefaultValue = true)]
        public OptimizationPersistenceStrategySetting OptimizationPersistenceStrategySetting { get; set; }

        /// <summary>
        /// Gets or Sets StreamPersistenceStrategySetting
        /// </summary>
        [DataMember(Name = "streamPersistenceStrategySetting", IsRequired = true, EmitDefaultValue = true)]
        public StreamPersistenceStrategySetting StreamPersistenceStrategySetting { get; set; }

        /// <summary>
        /// Optional URL the server calls (POST) when the job completes or fails. The payload contains jobId, tenantId, status, and completedAt only — no optimization data. Leave empty to disable. URL validation is controlled by the server&#39;s webhook-validation policy: in strict mode (SaaS default) only public HTTPS URLs are accepted; in relaxed mode (on-premise) HTTP and private network addresses are also allowed; in none mode (local development) any URL is accepted. Loopback addresses (127.x, ::1) are always rejected. Validation is performed at submission time.
        /// </summary>
        /// <value>Optional URL the server calls (POST) when the job completes or fails. The payload contains jobId, tenantId, status, and completedAt only — no optimization data. Leave empty to disable. URL validation is controlled by the server&#39;s webhook-validation policy: in strict mode (SaaS default) only public HTTPS URLs are accepted; in relaxed mode (on-premise) HTTP and private network addresses are also allowed; in none mode (local development) any URL is accepted. Loopback addresses (127.x, ::1) are always rejected. Validation is performed at submission time.</value>
        [DataMember(Name = "completionWebhookUrl", EmitDefaultValue = false)]
        public string CompletionWebhookUrl { get; set; }

        /// <summary>
        /// Optional secret used to sign the webhook payload with HMAC-SHA256. When provided, the server includes an X-JOpt-Signature header on every delivery in the form &#39;sha256&#x3D;&lt;hex&gt;&#39;. The receiver should compute the same HMAC over the raw request body and compare it using a constant-time comparison before trusting the payload. Leave empty to send unsigned webhooks. Unsigned webhooks are acceptable in trusted internal networks but are not recommended when the webhook URL is reachable from untrusted clients.
        /// </summary>
        /// <value>Optional secret used to sign the webhook payload with HMAC-SHA256. When provided, the server includes an X-JOpt-Signature header on every delivery in the form &#39;sha256&#x3D;&lt;hex&gt;&#39;. The receiver should compute the same HMAC over the raw request body and compare it using a constant-time comparison before trusting the payload. Leave empty to send unsigned webhooks. Unsigned webhooks are acceptable in trusted internal networks but are not recommended when the webhook URL is reachable from untrusted clients.</value>
        [DataMember(Name = "completionWebhookSecret", EmitDefaultValue = false)]
        public string CompletionWebhookSecret { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class MongoOptimizationPersistenceSetting {\n");
            sb.Append("  EnablePersistence: ").Append(EnablePersistence).Append("\n");
            sb.Append("  RequireUniqueIdentCreatorCombination: ").Append(RequireUniqueIdentCreatorCombination).Append("\n");
            sb.Append("  Secret: ").Append(Secret).Append("\n");
            sb.Append("  Expiry: ").Append(Expiry).Append("\n");
            sb.Append("  OptimizationPersistenceStrategySetting: ").Append(OptimizationPersistenceStrategySetting).Append("\n");
            sb.Append("  StreamPersistenceStrategySetting: ").Append(StreamPersistenceStrategySetting).Append("\n");
            sb.Append("  CompletionWebhookUrl: ").Append(CompletionWebhookUrl).Append("\n");
            sb.Append("  CompletionWebhookSecret: ").Append(CompletionWebhookSecret).Append("\n");
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
