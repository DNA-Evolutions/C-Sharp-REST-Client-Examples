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
    /// The header of the whole solution. Summarizing important data like total number of routes, total time needed for ALL routes etc.
    /// </summary>
    [DataContract(Name = "SolutionHeader")]
    public partial class SolutionHeader : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SolutionHeader" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SolutionHeader() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SolutionHeader" /> class.
        /// </summary>
        /// <param name="numRoutes">The numRoutes. The number of routes. (required).</param>
        /// <param name="numScheduledRoutes">The numScheduledRoutes. The number of routes that have non-zero time. (required).</param>
        /// <param name="totElements">The total number of Elements inlucidng Nodes and Resoures (required).</param>
        /// <param name="unassignedElementIds">The unassignedElementIds, The ids of the elements that were unassigned during the Optimization run. Either by the AutoFilter or at start up due to conflicting hard-constraints. (required).</param>
        /// <param name="totCost">The total cost is the abstract value that is used as figure of merit during the Optimization run. (required).</param>
        /// <param name="totTime">The total time needed for all routes. (required).</param>
        /// <param name="totIdleTime">The total IdleTime accumulated over all routes. (required).</param>
        /// <param name="totProdTime">The total Productive Time accumulated over all routes (required).</param>
        /// <param name="totTranTime">The total transit Time accumulated over all routes (required).</param>
        /// <param name="totTermiTime">The total termination Time accumulated over all routes (required).</param>
        /// <param name="totDistance">The total distance accumulated over all routes (required).</param>
        /// <param name="totTermiDistance">The total termiantion distance accumulated over all routes (required).</param>
        /// <param name="jobViolations">The jobViolations. The violation that occured on Job level. This does NOT contain individual node violations like lateness etc. Moreover,  it contains violations like relation-constraints between nodes. For example, node &#39;A&#39; needs to be visited before node &#39;B&#39; is violated. (required).</param>
        public SolutionHeader(int numRoutes = default, int numScheduledRoutes = default, int totElements = default, List<string> unassignedElementIds = default, double totCost = default, string totTime = default, string totIdleTime = default, string totProdTime = default, string totTranTime = default, string totTermiTime = default, string totDistance = default, string totTermiDistance = default, List<Violation> jobViolations = default)
        {
            this.NumRoutes = numRoutes;
            this.NumScheduledRoutes = numScheduledRoutes;
            this.TotElements = totElements;
            // to ensure "unassignedElementIds" is required (not null)
            if (unassignedElementIds == null)
            {
                throw new ArgumentNullException("unassignedElementIds is a required property for SolutionHeader and cannot be null");
            }
            this.UnassignedElementIds = unassignedElementIds;
            this.TotCost = totCost;
            // to ensure "totTime" is required (not null)
            if (totTime == null)
            {
                throw new ArgumentNullException("totTime is a required property for SolutionHeader and cannot be null");
            }
            this.TotTime = totTime;
            // to ensure "totIdleTime" is required (not null)
            if (totIdleTime == null)
            {
                throw new ArgumentNullException("totIdleTime is a required property for SolutionHeader and cannot be null");
            }
            this.TotIdleTime = totIdleTime;
            // to ensure "totProdTime" is required (not null)
            if (totProdTime == null)
            {
                throw new ArgumentNullException("totProdTime is a required property for SolutionHeader and cannot be null");
            }
            this.TotProdTime = totProdTime;
            // to ensure "totTranTime" is required (not null)
            if (totTranTime == null)
            {
                throw new ArgumentNullException("totTranTime is a required property for SolutionHeader and cannot be null");
            }
            this.TotTranTime = totTranTime;
            // to ensure "totTermiTime" is required (not null)
            if (totTermiTime == null)
            {
                throw new ArgumentNullException("totTermiTime is a required property for SolutionHeader and cannot be null");
            }
            this.TotTermiTime = totTermiTime;
            // to ensure "totDistance" is required (not null)
            if (totDistance == null)
            {
                throw new ArgumentNullException("totDistance is a required property for SolutionHeader and cannot be null");
            }
            this.TotDistance = totDistance;
            // to ensure "totTermiDistance" is required (not null)
            if (totTermiDistance == null)
            {
                throw new ArgumentNullException("totTermiDistance is a required property for SolutionHeader and cannot be null");
            }
            this.TotTermiDistance = totTermiDistance;
            // to ensure "jobViolations" is required (not null)
            if (jobViolations == null)
            {
                throw new ArgumentNullException("jobViolations is a required property for SolutionHeader and cannot be null");
            }
            this.JobViolations = jobViolations;
        }

        /// <summary>
        /// The numRoutes. The number of routes.
        /// </summary>
        /// <value>The numRoutes. The number of routes.</value>
        /*
        <example>10</example>
        */
        [DataMember(Name = "numRoutes", IsRequired = true, EmitDefaultValue = true)]
        public int NumRoutes { get; set; }

        /// <summary>
        /// The numScheduledRoutes. The number of routes that have non-zero time.
        /// </summary>
        /// <value>The numScheduledRoutes. The number of routes that have non-zero time.</value>
        /*
        <example>8</example>
        */
        [DataMember(Name = "numScheduledRoutes", IsRequired = true, EmitDefaultValue = true)]
        public int NumScheduledRoutes { get; set; }

        /// <summary>
        /// The total number of Elements inlucidng Nodes and Resoures
        /// </summary>
        /// <value>The total number of Elements inlucidng Nodes and Resoures</value>
        /*
        <example>516</example>
        */
        [DataMember(Name = "totElements", IsRequired = true, EmitDefaultValue = true)]
        public int TotElements { get; set; }

        /// <summary>
        /// The unassignedElementIds, The ids of the elements that were unassigned during the Optimization run. Either by the AutoFilter or at start up due to conflicting hard-constraints.
        /// </summary>
        /// <value>The unassignedElementIds, The ids of the elements that were unassigned during the Optimization run. Either by the AutoFilter or at start up due to conflicting hard-constraints.</value>
        [DataMember(Name = "unassignedElementIds", IsRequired = true, EmitDefaultValue = true)]
        public List<string> UnassignedElementIds { get; set; }

        /// <summary>
        /// The total cost is the abstract value that is used as figure of merit during the Optimization run.
        /// </summary>
        /// <value>The total cost is the abstract value that is used as figure of merit during the Optimization run.</value>
        /*
        <example>95164.1314</example>
        */
        [DataMember(Name = "totCost", IsRequired = true, EmitDefaultValue = true)]
        public double TotCost { get; set; }

        /// <summary>
        /// The total time needed for all routes.
        /// </summary>
        /// <value>The total time needed for all routes.</value>
        /*
        <example>PT480M</example>
        */
        [DataMember(Name = "totTime", IsRequired = true, EmitDefaultValue = true)]
        public string TotTime { get; set; }

        /// <summary>
        /// The total IdleTime accumulated over all routes.
        /// </summary>
        /// <value>The total IdleTime accumulated over all routes.</value>
        /*
        <example>PT30M</example>
        */
        [DataMember(Name = "totIdleTime", IsRequired = true, EmitDefaultValue = true)]
        public string TotIdleTime { get; set; }

        /// <summary>
        /// The total Productive Time accumulated over all routes
        /// </summary>
        /// <value>The total Productive Time accumulated over all routes</value>
        /*
        <example>PT300M</example>
        */
        [DataMember(Name = "totProdTime", IsRequired = true, EmitDefaultValue = true)]
        public string TotProdTime { get; set; }

        /// <summary>
        /// The total transit Time accumulated over all routes
        /// </summary>
        /// <value>The total transit Time accumulated over all routes</value>
        /*
        <example>PT200M</example>
        */
        [DataMember(Name = "totTranTime", IsRequired = true, EmitDefaultValue = true)]
        public string TotTranTime { get; set; }

        /// <summary>
        /// The total termination Time accumulated over all routes
        /// </summary>
        /// <value>The total termination Time accumulated over all routes</value>
        /*
        <example>PT30M</example>
        */
        [DataMember(Name = "totTermiTime", IsRequired = true, EmitDefaultValue = true)]
        public string TotTermiTime { get; set; }

        /// <summary>
        /// The total distance accumulated over all routes
        /// </summary>
        /// <value>The total distance accumulated over all routes</value>
        /*
        <example>100.0 km</example>
        */
        [DataMember(Name = "totDistance", IsRequired = true, EmitDefaultValue = true)]
        public string TotDistance { get; set; }

        /// <summary>
        /// The total termiantion distance accumulated over all routes
        /// </summary>
        /// <value>The total termiantion distance accumulated over all routes</value>
        /*
        <example>100.0 km</example>
        */
        [DataMember(Name = "totTermiDistance", IsRequired = true, EmitDefaultValue = true)]
        public string TotTermiDistance { get; set; }

        /// <summary>
        /// The jobViolations. The violation that occured on Job level. This does NOT contain individual node violations like lateness etc. Moreover,  it contains violations like relation-constraints between nodes. For example, node &#39;A&#39; needs to be visited before node &#39;B&#39; is violated.
        /// </summary>
        /// <value>The jobViolations. The violation that occured on Job level. This does NOT contain individual node violations like lateness etc. Moreover,  it contains violations like relation-constraints between nodes. For example, node &#39;A&#39; needs to be visited before node &#39;B&#39; is violated.</value>
        [DataMember(Name = "jobViolations", IsRequired = true, EmitDefaultValue = true)]
        public List<Violation> JobViolations { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SolutionHeader {\n");
            sb.Append("  NumRoutes: ").Append(NumRoutes).Append("\n");
            sb.Append("  NumScheduledRoutes: ").Append(NumScheduledRoutes).Append("\n");
            sb.Append("  TotElements: ").Append(TotElements).Append("\n");
            sb.Append("  UnassignedElementIds: ").Append(UnassignedElementIds).Append("\n");
            sb.Append("  TotCost: ").Append(TotCost).Append("\n");
            sb.Append("  TotTime: ").Append(TotTime).Append("\n");
            sb.Append("  TotIdleTime: ").Append(TotIdleTime).Append("\n");
            sb.Append("  TotProdTime: ").Append(TotProdTime).Append("\n");
            sb.Append("  TotTranTime: ").Append(TotTranTime).Append("\n");
            sb.Append("  TotTermiTime: ").Append(TotTermiTime).Append("\n");
            sb.Append("  TotDistance: ").Append(TotDistance).Append("\n");
            sb.Append("  TotTermiDistance: ").Append(TotTermiDistance).Append("\n");
            sb.Append("  JobViolations: ").Append(JobViolations).Append("\n");
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
