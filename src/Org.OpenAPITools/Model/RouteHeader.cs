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
    /// The header of the solution per route is summarizing important data like number of elements in the route , total time needed for the route etc.
    /// </summary>
    [DataContract(Name = "RouteHeader")]
    public partial class RouteHeader : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RouteHeader" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected RouteHeader() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RouteHeader" /> class.
        /// </summary>
        /// <param name="cost">The abstract cost value of the route. (required).</param>
        /// <param name="time">The time that is needed for the route. (required).</param>
        /// <param name="idleTime">The accumlated idleTime of the route. (required).</param>
        /// <param name="prodTime">The productive time of the route. Productive time is working-time spend at a node. (required).</param>
        /// <param name="tranTime">The tranTime. The summed transit time of the route. (required).</param>
        /// <param name="termiTime">The termiTime. The time taken from the last element to the termination element of the route. (required).</param>
        /// <param name="distance">The distance. The summed transit distance of the route. (required).</param>
        /// <param name="termiDistance">The termiDistance. The distance taken from the last element to the termination element of the route. (required).</param>
        /// <param name="routeViolations">The routeViolations. Violations that occur on route level. For example, overtime, overdistance etc. (required).</param>
        /// <param name="isClosed">The isClosed boolean describes if a Resource has to visit the termination element of the Route. By default, the start element and the termination element of a Route is the Resource itself. In case of a closed route, by default, the Resource returns to its original starting location. (required).</param>
        /// <param name="isAlternateDestination">The isAlternateDestination boolean. Descibes of the Resource has an alternate destination. The Resource has to end it&#39;s Route at the alternate destination there but  will start from the original route start again the next working hour. (required).</param>
        public RouteHeader(double cost = default, string time = default, string idleTime = default, string prodTime = default, string tranTime = default, string termiTime = default, string distance = default, string termiDistance = default, List<Violation> routeViolations = default, bool isClosed = default, bool isAlternateDestination = default)
        {
            this.Cost = cost;
            // to ensure "time" is required (not null)
            if (time == null)
            {
                throw new ArgumentNullException("time is a required property for RouteHeader and cannot be null");
            }
            this.Time = time;
            // to ensure "idleTime" is required (not null)
            if (idleTime == null)
            {
                throw new ArgumentNullException("idleTime is a required property for RouteHeader and cannot be null");
            }
            this.IdleTime = idleTime;
            // to ensure "prodTime" is required (not null)
            if (prodTime == null)
            {
                throw new ArgumentNullException("prodTime is a required property for RouteHeader and cannot be null");
            }
            this.ProdTime = prodTime;
            // to ensure "tranTime" is required (not null)
            if (tranTime == null)
            {
                throw new ArgumentNullException("tranTime is a required property for RouteHeader and cannot be null");
            }
            this.TranTime = tranTime;
            // to ensure "termiTime" is required (not null)
            if (termiTime == null)
            {
                throw new ArgumentNullException("termiTime is a required property for RouteHeader and cannot be null");
            }
            this.TermiTime = termiTime;
            // to ensure "distance" is required (not null)
            if (distance == null)
            {
                throw new ArgumentNullException("distance is a required property for RouteHeader and cannot be null");
            }
            this.Distance = distance;
            // to ensure "termiDistance" is required (not null)
            if (termiDistance == null)
            {
                throw new ArgumentNullException("termiDistance is a required property for RouteHeader and cannot be null");
            }
            this.TermiDistance = termiDistance;
            // to ensure "routeViolations" is required (not null)
            if (routeViolations == null)
            {
                throw new ArgumentNullException("routeViolations is a required property for RouteHeader and cannot be null");
            }
            this.RouteViolations = routeViolations;
            this.IsClosed = isClosed;
            this.IsAlternateDestination = isAlternateDestination;
        }

        /// <summary>
        /// The abstract cost value of the route.
        /// </summary>
        /// <value>The abstract cost value of the route.</value>
        /*
        <example>2468.32</example>
        */
        [DataMember(Name = "cost", IsRequired = true, EmitDefaultValue = true)]
        public double Cost { get; set; }

        /// <summary>
        /// The time that is needed for the route.
        /// </summary>
        /// <value>The time that is needed for the route.</value>
        /*
        <example>PT30M</example>
        */
        [DataMember(Name = "time", IsRequired = true, EmitDefaultValue = true)]
        public string Time { get; set; }

        /// <summary>
        /// The accumlated idleTime of the route.
        /// </summary>
        /// <value>The accumlated idleTime of the route.</value>
        /*
        <example>PT30M</example>
        */
        [DataMember(Name = "idleTime", IsRequired = true, EmitDefaultValue = true)]
        public string IdleTime { get; set; }

        /// <summary>
        /// The productive time of the route. Productive time is working-time spend at a node.
        /// </summary>
        /// <value>The productive time of the route. Productive time is working-time spend at a node.</value>
        /*
        <example>PT30M</example>
        */
        [DataMember(Name = "prodTime", IsRequired = true, EmitDefaultValue = true)]
        public string ProdTime { get; set; }

        /// <summary>
        /// The tranTime. The summed transit time of the route.
        /// </summary>
        /// <value>The tranTime. The summed transit time of the route.</value>
        /*
        <example>PT310M</example>
        */
        [DataMember(Name = "tranTime", IsRequired = true, EmitDefaultValue = true)]
        public string TranTime { get; set; }

        /// <summary>
        /// The termiTime. The time taken from the last element to the termination element of the route.
        /// </summary>
        /// <value>The termiTime. The time taken from the last element to the termination element of the route.</value>
        /*
        <example>PT800M</example>
        */
        [DataMember(Name = "termiTime", IsRequired = true, EmitDefaultValue = true)]
        public string TermiTime { get; set; }

        /// <summary>
        /// The distance. The summed transit distance of the route.
        /// </summary>
        /// <value>The distance. The summed transit distance of the route.</value>
        /*
        <example>800.0 km</example>
        */
        [DataMember(Name = "distance", IsRequired = true, EmitDefaultValue = true)]
        public string Distance { get; set; }

        /// <summary>
        /// The termiDistance. The distance taken from the last element to the termination element of the route.
        /// </summary>
        /// <value>The termiDistance. The distance taken from the last element to the termination element of the route.</value>
        /*
        <example>53.0 km</example>
        */
        [DataMember(Name = "termiDistance", IsRequired = true, EmitDefaultValue = true)]
        public string TermiDistance { get; set; }

        /// <summary>
        /// The routeViolations. Violations that occur on route level. For example, overtime, overdistance etc.
        /// </summary>
        /// <value>The routeViolations. Violations that occur on route level. For example, overtime, overdistance etc.</value>
        [DataMember(Name = "routeViolations", IsRequired = true, EmitDefaultValue = true)]
        public List<Violation> RouteViolations { get; set; }

        /// <summary>
        /// The isClosed boolean describes if a Resource has to visit the termination element of the Route. By default, the start element and the termination element of a Route is the Resource itself. In case of a closed route, by default, the Resource returns to its original starting location.
        /// </summary>
        /// <value>The isClosed boolean describes if a Resource has to visit the termination element of the Route. By default, the start element and the termination element of a Route is the Resource itself. In case of a closed route, by default, the Resource returns to its original starting location.</value>
        [DataMember(Name = "isClosed", IsRequired = true, EmitDefaultValue = true)]
        public bool IsClosed { get; set; }

        /// <summary>
        /// The isAlternateDestination boolean. Descibes of the Resource has an alternate destination. The Resource has to end it&#39;s Route at the alternate destination there but  will start from the original route start again the next working hour.
        /// </summary>
        /// <value>The isAlternateDestination boolean. Descibes of the Resource has an alternate destination. The Resource has to end it&#39;s Route at the alternate destination there but  will start from the original route start again the next working hour.</value>
        [DataMember(Name = "isAlternateDestination", IsRequired = true, EmitDefaultValue = true)]
        public bool IsAlternateDestination { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class RouteHeader {\n");
            sb.Append("  Cost: ").Append(Cost).Append("\n");
            sb.Append("  Time: ").Append(Time).Append("\n");
            sb.Append("  IdleTime: ").Append(IdleTime).Append("\n");
            sb.Append("  ProdTime: ").Append(ProdTime).Append("\n");
            sb.Append("  TranTime: ").Append(TranTime).Append("\n");
            sb.Append("  TermiTime: ").Append(TermiTime).Append("\n");
            sb.Append("  Distance: ").Append(Distance).Append("\n");
            sb.Append("  TermiDistance: ").Append(TermiDistance).Append("\n");
            sb.Append("  RouteViolations: ").Append(RouteViolations).Append("\n");
            sb.Append("  IsClosed: ").Append(IsClosed).Append("\n");
            sb.Append("  IsAlternateDestination: ").Append(IsAlternateDestination).Append("\n");
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
