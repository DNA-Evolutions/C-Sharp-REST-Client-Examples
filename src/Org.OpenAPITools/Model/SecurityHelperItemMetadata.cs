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
    /// Cryptographic metadata stored alongside encrypted data in GridFS. Contains the IV, salt (CLIENT mode), algorithm identifiers, and in KMS mode the wrapped DEK and KEK identifier. Used to reconstruct the decryption key at retrieval time.
    /// </summary>
    [DataContract(Name = "SecurityHelperItemMetadata")]
    public partial class SecurityHelperItemMetadata : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityHelperItemMetadata" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SecurityHelperItemMetadata() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityHelperItemMetadata" /> class.
        /// </summary>
        /// <param name="encMode">The encryption mode that was used. &#39;CLIENT&#39; &#x3D; key derived from a client passphrase via PBKDF2. &#39;KMS&#39; &#x3D; key is a server-generated DEK wrapped by an external KMS. Old metadata without this field defaults to CLIENT for backward compatibility..</param>
        /// <param name="iv">The IV used for AES-GCM initialization as base64-encoded String. Should be 12 bytes (96 bits) for GCM per NIST SP 800-38D. (required).</param>
        /// <param name="encAlgo">The algorithm used for encryption. (required).</param>
        /// <param name="keyLength">AES key length in bits..</param>
        /// <param name="salt">The salt used for PBKDF2 key derivation as base64-encoded String. Only present in CLIENT mode. Empty in KMS mode..</param>
        /// <param name="secretKeyFacAlgo">Secret Key Factory algorithm. Only used in CLIENT mode..</param>
        /// <param name="secretKeySpecAlgo">Secret Key Spec algorithm..</param>
        /// <param name="iterationCount">PBKDF2 iteration count. Only used in CLIENT mode. Old snapshots without this field used 65536. KMS mode sets this to 0..</param>
        /// <param name="wrappedDek">The data encryption key (DEK) wrapped (encrypted) by the tenant&#39;s key encryption key (KEK) via an external KMS, stored as a base64-encoded String. Only present in KMS mode. The plaintext DEK is never stored it must be unwrapped via the KMS before decryption..</param>
        /// <param name="kekId">The identifier (URI or ARN) of the key encryption key (KEK) in the external KMS that was used to wrap the DEK. Only present in KMS mode. Required for unwrapping the DEK at retrieval time. Example for Azure Key Vault: &#39;https://myvault.vault.azure.net/keys/tenant-kek/abc123&#39;. Example for AWS KMS: &#39;arn:aws:kms:eu-west-1:123456789:key/mrk-abc123&#39;..</param>
        /// <param name="kmsMode">Convenience flag derived from encMode. True when encMode is KMS, false for CLIENT mode or legacy documents without an encMode field..</param>
        public SecurityHelperItemMetadata(string encMode = default, string iv = default, string encAlgo = default, int keyLength = default, string salt = default, string secretKeyFacAlgo = default, string secretKeySpecAlgo = default, int iterationCount = default, string wrappedDek = default, string kekId = default, bool kmsMode = default)
        {
            // to ensure "iv" is required (not null)
            if (iv == null)
            {
                throw new ArgumentNullException("iv is a required property for SecurityHelperItemMetadata and cannot be null");
            }
            this.Iv = iv;
            // to ensure "encAlgo" is required (not null)
            if (encAlgo == null)
            {
                throw new ArgumentNullException("encAlgo is a required property for SecurityHelperItemMetadata and cannot be null");
            }
            this.EncAlgo = encAlgo;
            this.EncMode = encMode;
            this.KeyLength = keyLength;
            this.Salt = salt;
            this.SecretKeyFacAlgo = secretKeyFacAlgo;
            this.SecretKeySpecAlgo = secretKeySpecAlgo;
            this.IterationCount = iterationCount;
            this.WrappedDek = wrappedDek;
            this.KekId = kekId;
            this.KmsMode = kmsMode;
        }

        /// <summary>
        /// The encryption mode that was used. &#39;CLIENT&#39; &#x3D; key derived from a client passphrase via PBKDF2. &#39;KMS&#39; &#x3D; key is a server-generated DEK wrapped by an external KMS. Old metadata without this field defaults to CLIENT for backward compatibility.
        /// </summary>
        /// <value>The encryption mode that was used. &#39;CLIENT&#39; &#x3D; key derived from a client passphrase via PBKDF2. &#39;KMS&#39; &#x3D; key is a server-generated DEK wrapped by an external KMS. Old metadata without this field defaults to CLIENT for backward compatibility.</value>
        /*
        <example>CLIENT</example>
        */
        [DataMember(Name = "encMode", EmitDefaultValue = false)]
        public string EncMode { get; set; }

        /// <summary>
        /// The IV used for AES-GCM initialization as base64-encoded String. Should be 12 bytes (96 bits) for GCM per NIST SP 800-38D.
        /// </summary>
        /// <value>The IV used for AES-GCM initialization as base64-encoded String. Should be 12 bytes (96 bits) for GCM per NIST SP 800-38D.</value>
        /*
        <example>dPrQge5LIDdPxEeg</example>
        */
        [DataMember(Name = "iv", IsRequired = true, EmitDefaultValue = true)]
        public string Iv { get; set; }

        /// <summary>
        /// The algorithm used for encryption.
        /// </summary>
        /// <value>The algorithm used for encryption.</value>
        /*
        <example>AES/GCM/NoPadding</example>
        */
        [DataMember(Name = "encAlgo", IsRequired = true, EmitDefaultValue = true)]
        public string EncAlgo { get; set; }

        /// <summary>
        /// AES key length in bits.
        /// </summary>
        /// <value>AES key length in bits.</value>
        /*
        <example>256</example>
        */
        [DataMember(Name = "keyLength", EmitDefaultValue = false)]
        public int KeyLength { get; set; }

        /// <summary>
        /// The salt used for PBKDF2 key derivation as base64-encoded String. Only present in CLIENT mode. Empty in KMS mode.
        /// </summary>
        /// <value>The salt used for PBKDF2 key derivation as base64-encoded String. Only present in CLIENT mode. Empty in KMS mode.</value>
        /*
        <example>UVSGQfW40PybJ2HecBhjmg&#x3D;&#x3D;</example>
        */
        [DataMember(Name = "salt", EmitDefaultValue = false)]
        public string Salt { get; set; }

        /// <summary>
        /// Secret Key Factory algorithm. Only used in CLIENT mode.
        /// </summary>
        /// <value>Secret Key Factory algorithm. Only used in CLIENT mode.</value>
        /*
        <example>PBKDF2WithHmacSHA256</example>
        */
        [DataMember(Name = "secretKeyFacAlgo", EmitDefaultValue = false)]
        public string SecretKeyFacAlgo { get; set; }

        /// <summary>
        /// Secret Key Spec algorithm.
        /// </summary>
        /// <value>Secret Key Spec algorithm.</value>
        /*
        <example>AES</example>
        */
        [DataMember(Name = "secretKeySpecAlgo", EmitDefaultValue = false)]
        public string SecretKeySpecAlgo { get; set; }

        /// <summary>
        /// PBKDF2 iteration count. Only used in CLIENT mode. Old snapshots without this field used 65536. KMS mode sets this to 0.
        /// </summary>
        /// <value>PBKDF2 iteration count. Only used in CLIENT mode. Old snapshots without this field used 65536. KMS mode sets this to 0.</value>
        /*
        <example>310000</example>
        */
        [DataMember(Name = "iterationCount", EmitDefaultValue = false)]
        public int IterationCount { get; set; }

        /// <summary>
        /// The data encryption key (DEK) wrapped (encrypted) by the tenant&#39;s key encryption key (KEK) via an external KMS, stored as a base64-encoded String. Only present in KMS mode. The plaintext DEK is never stored it must be unwrapped via the KMS before decryption.
        /// </summary>
        /// <value>The data encryption key (DEK) wrapped (encrypted) by the tenant&#39;s key encryption key (KEK) via an external KMS, stored as a base64-encoded String. Only present in KMS mode. The plaintext DEK is never stored it must be unwrapped via the KMS before decryption.</value>
        /*
        <example>BASE64_WRAPPED_KEY</example>
        */
        [DataMember(Name = "wrappedDek", EmitDefaultValue = false)]
        public string WrappedDek { get; set; }

        /// <summary>
        /// The identifier (URI or ARN) of the key encryption key (KEK) in the external KMS that was used to wrap the DEK. Only present in KMS mode. Required for unwrapping the DEK at retrieval time. Example for Azure Key Vault: &#39;https://myvault.vault.azure.net/keys/tenant-kek/abc123&#39;. Example for AWS KMS: &#39;arn:aws:kms:eu-west-1:123456789:key/mrk-abc123&#39;.
        /// </summary>
        /// <value>The identifier (URI or ARN) of the key encryption key (KEK) in the external KMS that was used to wrap the DEK. Only present in KMS mode. Required for unwrapping the DEK at retrieval time. Example for Azure Key Vault: &#39;https://myvault.vault.azure.net/keys/tenant-kek/abc123&#39;. Example for AWS KMS: &#39;arn:aws:kms:eu-west-1:123456789:key/mrk-abc123&#39;.</value>
        /*
        <example>https://myvault.vault.azure.net/keys/tenant-kek/abc123</example>
        */
        [DataMember(Name = "kekId", EmitDefaultValue = false)]
        public string KekId { get; set; }

        /// <summary>
        /// Convenience flag derived from encMode. True when encMode is KMS, false for CLIENT mode or legacy documents without an encMode field.
        /// </summary>
        /// <value>Convenience flag derived from encMode. True when encMode is KMS, false for CLIENT mode or legacy documents without an encMode field.</value>
        /*
        <example>false</example>
        */
        [DataMember(Name = "kmsMode", EmitDefaultValue = true)]
        public bool KmsMode { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SecurityHelperItemMetadata {\n");
            sb.Append("  EncMode: ").Append(EncMode).Append("\n");
            sb.Append("  Iv: ").Append(Iv).Append("\n");
            sb.Append("  EncAlgo: ").Append(EncAlgo).Append("\n");
            sb.Append("  KeyLength: ").Append(KeyLength).Append("\n");
            sb.Append("  Salt: ").Append(Salt).Append("\n");
            sb.Append("  SecretKeyFacAlgo: ").Append(SecretKeyFacAlgo).Append("\n");
            sb.Append("  SecretKeySpecAlgo: ").Append(SecretKeySpecAlgo).Append("\n");
            sb.Append("  IterationCount: ").Append(IterationCount).Append("\n");
            sb.Append("  WrappedDek: ").Append(WrappedDek).Append("\n");
            sb.Append("  KekId: ").Append(KekId).Append("\n");
            sb.Append("  KmsMode: ").Append(KmsMode).Append("\n");
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
