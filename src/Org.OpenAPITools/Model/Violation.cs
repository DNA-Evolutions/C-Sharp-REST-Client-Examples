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
    /// A single constraint violation detected during optimization. Describes the violation value (e.g. minutes of lateness), a human-readable description, the offending element (node or route), and a category/attribute/subAttribute taxonomy for programmatic filtering (e.g. CONSTRAINTVIOLATION &gt; TIMECONSTRAINT &gt; LATE).
    /// </summary>
    [DataContract(Name = "Violation")]
    public partial class Violation : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Violation" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Violation() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Violation" /> class.
        /// </summary>
        /// <param name="value">If for example a constraint is triggering the violation, the underlying ident of the constraint class might be provided. (required).</param>
        /// <param name="desc">The description of the violation. A human readable description of the violation (required).</param>
        /// <param name="offender">The offender corresponding to the violation. That could be a node or route id..</param>
        /// <param name="category">The category of the violation. The main category of the violation. (required).</param>
        /// <param name="attribute">The attribute is further defining the type of the violation. For example, late and early violation belong to the attribute &#39;TIMECONSTRAINT&#39;. (required).</param>
        /// <param name="subAttribute">The subAttribute defines what kind of violation we are dealing with. (required).</param>
        /// <param name="code">The code is the unique code for each Violation type. (required).</param>
        public Violation(string value = default, string desc = default, string offender = default, string category = default, string attribute = default, string subAttribute = default, int code = default)
        {
            // to ensure "value" is required (not null)
            if (value == null)
            {
                throw new ArgumentNullException("value is a required property for Violation and cannot be null");
            }
            this.Value = value;
            // to ensure "desc" is required (not null)
            if (desc == null)
            {
                throw new ArgumentNullException("desc is a required property for Violation and cannot be null");
            }
            this.Desc = desc;
            // to ensure "category" is required (not null)
            if (category == null)
            {
                throw new ArgumentNullException("category is a required property for Violation and cannot be null");
            }
            this.Category = category;
            // to ensure "attribute" is required (not null)
            if (attribute == null)
            {
                throw new ArgumentNullException("attribute is a required property for Violation and cannot be null");
            }
            this.Attribute = attribute;
            // to ensure "subAttribute" is required (not null)
            if (subAttribute == null)
            {
                throw new ArgumentNullException("subAttribute is a required property for Violation and cannot be null");
            }
            this.SubAttribute = subAttribute;
            this.Code = code;
            this.Offender = offender;
        }

        /// <summary>
        /// If for example a constraint is triggering the violation, the underlying ident of the constraint class might be provided.
        /// </summary>
        /// <value>If for example a constraint is triggering the violation, the underlying ident of the constraint class might be provided.</value>
        [DataMember(Name = "value", IsRequired = true, EmitDefaultValue = true)]
        public string Value { get; set; }

        /// <summary>
        /// The description of the violation. A human readable description of the violation
        /// </summary>
        /// <value>The description of the violation. A human readable description of the violation</value>
        /*
        <example>Late time [min]: 507.98525</example>
        */
        [DataMember(Name = "desc", IsRequired = true, EmitDefaultValue = true)]
        public string Desc { get; set; }

        /// <summary>
        /// The offender corresponding to the violation. That could be a node or route id.
        /// </summary>
        /// <value>The offender corresponding to the violation. That could be a node or route id.</value>
        /*
        <example>Node_0</example>
        */
        [DataMember(Name = "offender", EmitDefaultValue = false)]
        public string Offender { get; set; }

        /// <summary>
        /// The category of the violation. The main category of the violation.
        /// </summary>
        /// <value>The category of the violation. The main category of the violation.</value>
        /*
        <example>CONSTRAINTVIOLATION</example>
        */
        [DataMember(Name = "category", IsRequired = true, EmitDefaultValue = true)]
        public string Category { get; set; }

        /// <summary>
        /// The attribute is further defining the type of the violation. For example, late and early violation belong to the attribute &#39;TIMECONSTRAINT&#39;.
        /// </summary>
        /// <value>The attribute is further defining the type of the violation. For example, late and early violation belong to the attribute &#39;TIMECONSTRAINT&#39;.</value>
        /*
        <example>TIMECONSTRAINT</example>
        */
        [DataMember(Name = "attribute", IsRequired = true, EmitDefaultValue = true)]
        public string Attribute { get; set; }

        /// <summary>
        /// The subAttribute defines what kind of violation we are dealing with.
        /// </summary>
        /// <value>The subAttribute defines what kind of violation we are dealing with.</value>
        /*
        <example>LATE</example>
        */
        [DataMember(Name = "subAttribute", IsRequired = true, EmitDefaultValue = true)]
        public string SubAttribute { get; set; }

        /// <summary>
        /// The code is the unique code for each Violation type.
        /// </summary>
        /// <value>The code is the unique code for each Violation type.</value>
        /*
        <example>5</example>
        */
        [DataMember(Name = "code", IsRequired = true, EmitDefaultValue = true)]
        public int Code { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Violation {\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  Desc: ").Append(Desc).Append("\n");
            sb.Append("  Offender: ").Append(Offender).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  Attribute: ").Append(Attribute).Append("\n");
            sb.Append("  SubAttribute: ").Append(SubAttribute).Append("\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
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
