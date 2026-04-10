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
    /// The REST-specific specialization of OptimizationConfig with JSONConfig as the extension type. This is the top-level request/response object for the TourOptimizer REST API. Inherits all fields from OptimizationConfig and adds JSON-specific extension support for license keys, persistence settings, creator settings, and timeout configuration.
    /// </summary>
    [DataContract(Name = "RestOptimization")]
    public partial class RestOptimization : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RestOptimization" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected RestOptimization() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RestOptimization" /> class.
        /// </summary>
        /// <param name="optimizationStatus">optimizationStatus.</param>
        /// <param name="id">A system-generated unique identifier assigned by the persistence layer (e.g. MongoDB ObjectId). This field is read-only and will be populated automatically when the optimization snapshot is stored in the database. Clients may use this value together with the creator field to retrieve or reference a specific persisted snapshot..</param>
        /// <param name="createdTimeStamp">An epoch-millisecond timestamp recording when this optimization snapshot was created. Populated automatically by the server at persistence time. Used for chronological ordering and expiry management Do not set this field in the input — it will be overwritten..</param>
        /// <param name="creator">A tenant-scoped identifier for the entity that submitted this optimization. Typically derived as a SHA-256 hash of the creator name supplied in the request&#39;s creatorSetting. Used as the primary scoping key for database queries — all persistence read operations require the creator to match, ensuring tenant isolation in multi-tenant deployments. Populated automatically by the server; do not set this field in the input..</param>
        /// <param name="ident">A user-defined, human-readable label for this optimization run. Useful for distinguishing runs in database queries and audit logs (e.g. &#39;Weekly-Route-Plan-CW42&#39; or &#39;NightShift-Berlin&#39;). If not provided, the server generates a default identifier based on a timestamp. Note: this field is stored as unencrypted metadata even when payload encryption is enabled — avoid embedding sensitive business information..</param>
        /// <param name="nodes">The list of nodes (work items, customer locations, or events) to be scheduled and assigned to resources. Each node defines a geographic or event-based location, one or more opening-hour windows, a required visit duration, and optional constraints (skill requirements, resource bindings, priority, pickup-and-delivery loads). Every node id must be globally unique across all nodes and resources in this configuration. (required).</param>
        /// <param name="resources">The list of resources (vehicles, drivers, technicians, or other mobile agents) available to visit the defined nodes. Each resource specifies a home position, one or more working-hour windows, maximum working time and distance constraints, optional qualifications (skills), an optional alternate destination, and overnight-stay policies. Resource ids must be globally unique across all elements. (required).</param>
        /// <param name="nodeRelations">The list of inter-node relations that impose ordering or co-assignment constraints between nodes. Supported relation types include SAME_ROUTE (nodes must be on the same route), SAME_VISITOR (nodes must be served by the same resource), DIFFERENT_ROUTE (nodes must not share a route), and relative time-window relations that enforce temporal precedence (e.g. node A must be visited before node B within a defined time gap)..</param>
        /// <param name="elementConnections">Pre-computed pairwise connections between elements (nodes and resources). Each connection specifies the travel distance and time between a source and a target element, optionally including time-dependent traffic profiles via connectionByTime. If connections are not provided, the optimizer falls back to a Haversine-based distance approximation or a configured backup connector. Providing accurate connections significantly improves solution quality. In persisted results, this list may be omitted to conserve storage (controlled via saveConnections)..</param>
        /// <param name="zoneConnections">Zone connections define penalties or restrictions for crossing geographic zone boundaries (e.g. bridge tolls, tunnel crossings, or administrative borders). Each ZoneConnection specifies a pair of zone numbers and an associated crossing cost. When a route transitions between zones, the optimizer accumulates these costs, which discourages unnecessary zone crossings and promotes geographically cohesive routes..</param>
        /// <param name="typeDictionaries">typeDictionaries.</param>
        /// <param name="optimizationOptions">optimizationOptions.</param>
        /// <param name="coreBuildOptions">coreBuildOptions.</param>
        /// <param name="solution">solution.</param>
        /// <param name="extension">extension.</param>
        public RestOptimization(OptimizationStatus optimizationStatus = default, string id = default, long createdTimeStamp = default, string creator = default, string ident = default, List<Node> nodes = default, List<Resource> resources = default, List<NodeRelation> nodeRelations = default, List<ElementConnection> elementConnections = default, List<ZoneConnection> zoneConnections = default, TypeDictionaries typeDictionaries = default, OptimizationOptions optimizationOptions = default, CoreBuildOptions coreBuildOptions = default, Solution solution = default, JSONConfig extension = default)
        {
            // to ensure "nodes" is required (not null)
            if (nodes == null)
            {
                throw new ArgumentNullException("nodes is a required property for RestOptimization and cannot be null");
            }
            this.Nodes = nodes;
            // to ensure "resources" is required (not null)
            if (resources == null)
            {
                throw new ArgumentNullException("resources is a required property for RestOptimization and cannot be null");
            }
            this.Resources = resources;
            this.OptimizationStatus = optimizationStatus;
            this.Id = id;
            this.CreatedTimeStamp = createdTimeStamp;
            this.Creator = creator;
            this.Ident = ident;
            this.NodeRelations = nodeRelations;
            this.ElementConnections = elementConnections;
            this.ZoneConnections = zoneConnections;
            this.TypeDictionaries = typeDictionaries;
            this.OptimizationOptions = optimizationOptions;
            this.CoreBuildOptions = coreBuildOptions;
            this.Solution = solution;
            this.Extension = extension;
        }

        /// <summary>
        /// Gets or Sets OptimizationStatus
        /// </summary>
        [DataMember(Name = "optimizationStatus", EmitDefaultValue = false)]
        public OptimizationStatus OptimizationStatus { get; set; }

        /// <summary>
        /// A system-generated unique identifier assigned by the persistence layer (e.g. MongoDB ObjectId). This field is read-only and will be populated automatically when the optimization snapshot is stored in the database. Clients may use this value together with the creator field to retrieve or reference a specific persisted snapshot.
        /// </summary>
        /// <value>A system-generated unique identifier assigned by the persistence layer (e.g. MongoDB ObjectId). This field is read-only and will be populated automatically when the optimization snapshot is stored in the database. Clients may use this value together with the creator field to retrieve or reference a specific persisted snapshot.</value>
        /*
        <example>626ba175a9d4fa6d6beec158</example>
        */
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// An epoch-millisecond timestamp recording when this optimization snapshot was created. Populated automatically by the server at persistence time. Used for chronological ordering and expiry management Do not set this field in the input — it will be overwritten.
        /// </summary>
        /// <value>An epoch-millisecond timestamp recording when this optimization snapshot was created. Populated automatically by the server at persistence time. Used for chronological ordering and expiry management Do not set this field in the input — it will be overwritten.</value>
        [DataMember(Name = "createdTimeStamp", EmitDefaultValue = false)]
        public long CreatedTimeStamp { get; set; }

        /// <summary>
        /// A tenant-scoped identifier for the entity that submitted this optimization. Typically derived as a SHA-256 hash of the creator name supplied in the request&#39;s creatorSetting. Used as the primary scoping key for database queries — all persistence read operations require the creator to match, ensuring tenant isolation in multi-tenant deployments. Populated automatically by the server; do not set this field in the input.
        /// </summary>
        /// <value>A tenant-scoped identifier for the entity that submitted this optimization. Typically derived as a SHA-256 hash of the creator name supplied in the request&#39;s creatorSetting. Used as the primary scoping key for database queries — all persistence read operations require the creator to match, ensuring tenant isolation in multi-tenant deployments. Populated automatically by the server; do not set this field in the input.</value>
        /*
        <example>11aa65b13c2a6d34f8727e82e403ce869e3bba1d35c45c595e8cc5ce5e74e57a</example>
        */
        [DataMember(Name = "creator", EmitDefaultValue = false)]
        public string Creator { get; set; }

        /// <summary>
        /// A user-defined, human-readable label for this optimization run. Useful for distinguishing runs in database queries and audit logs (e.g. &#39;Weekly-Route-Plan-CW42&#39; or &#39;NightShift-Berlin&#39;). If not provided, the server generates a default identifier based on a timestamp. Note: this field is stored as unencrypted metadata even when payload encryption is enabled — avoid embedding sensitive business information.
        /// </summary>
        /// <value>A user-defined, human-readable label for this optimization run. Useful for distinguishing runs in database queries and audit logs (e.g. &#39;Weekly-Route-Plan-CW42&#39; or &#39;NightShift-Berlin&#39;). If not provided, the server generates a default identifier based on a timestamp. Note: this field is stored as unencrypted metadata even when payload encryption is enabled — avoid embedding sensitive business information.</value>
        /*
        <example>JOpt-Run-603886271000</example>
        */
        [DataMember(Name = "ident", EmitDefaultValue = false)]
        public string Ident { get; set; }

        /// <summary>
        /// The list of nodes (work items, customer locations, or events) to be scheduled and assigned to resources. Each node defines a geographic or event-based location, one or more opening-hour windows, a required visit duration, and optional constraints (skill requirements, resource bindings, priority, pickup-and-delivery loads). Every node id must be globally unique across all nodes and resources in this configuration.
        /// </summary>
        /// <value>The list of nodes (work items, customer locations, or events) to be scheduled and assigned to resources. Each node defines a geographic or event-based location, one or more opening-hour windows, a required visit duration, and optional constraints (skill requirements, resource bindings, priority, pickup-and-delivery loads). Every node id must be globally unique across all nodes and resources in this configuration.</value>
        [DataMember(Name = "nodes", IsRequired = true, EmitDefaultValue = true)]
        public List<Node> Nodes { get; set; }

        /// <summary>
        /// The list of resources (vehicles, drivers, technicians, or other mobile agents) available to visit the defined nodes. Each resource specifies a home position, one or more working-hour windows, maximum working time and distance constraints, optional qualifications (skills), an optional alternate destination, and overnight-stay policies. Resource ids must be globally unique across all elements.
        /// </summary>
        /// <value>The list of resources (vehicles, drivers, technicians, or other mobile agents) available to visit the defined nodes. Each resource specifies a home position, one or more working-hour windows, maximum working time and distance constraints, optional qualifications (skills), an optional alternate destination, and overnight-stay policies. Resource ids must be globally unique across all elements.</value>
        [DataMember(Name = "resources", IsRequired = true, EmitDefaultValue = true)]
        public List<Resource> Resources { get; set; }

        /// <summary>
        /// The list of inter-node relations that impose ordering or co-assignment constraints between nodes. Supported relation types include SAME_ROUTE (nodes must be on the same route), SAME_VISITOR (nodes must be served by the same resource), DIFFERENT_ROUTE (nodes must not share a route), and relative time-window relations that enforce temporal precedence (e.g. node A must be visited before node B within a defined time gap).
        /// </summary>
        /// <value>The list of inter-node relations that impose ordering or co-assignment constraints between nodes. Supported relation types include SAME_ROUTE (nodes must be on the same route), SAME_VISITOR (nodes must be served by the same resource), DIFFERENT_ROUTE (nodes must not share a route), and relative time-window relations that enforce temporal precedence (e.g. node A must be visited before node B within a defined time gap).</value>
        [DataMember(Name = "nodeRelations", EmitDefaultValue = false)]
        public List<NodeRelation> NodeRelations { get; set; }

        /// <summary>
        /// Pre-computed pairwise connections between elements (nodes and resources). Each connection specifies the travel distance and time between a source and a target element, optionally including time-dependent traffic profiles via connectionByTime. If connections are not provided, the optimizer falls back to a Haversine-based distance approximation or a configured backup connector. Providing accurate connections significantly improves solution quality. In persisted results, this list may be omitted to conserve storage (controlled via saveConnections).
        /// </summary>
        /// <value>Pre-computed pairwise connections between elements (nodes and resources). Each connection specifies the travel distance and time between a source and a target element, optionally including time-dependent traffic profiles via connectionByTime. If connections are not provided, the optimizer falls back to a Haversine-based distance approximation or a configured backup connector. Providing accurate connections significantly improves solution quality. In persisted results, this list may be omitted to conserve storage (controlled via saveConnections).</value>
        [DataMember(Name = "elementConnections", EmitDefaultValue = false)]
        public List<ElementConnection> ElementConnections { get; set; }

        /// <summary>
        /// Zone connections define penalties or restrictions for crossing geographic zone boundaries (e.g. bridge tolls, tunnel crossings, or administrative borders). Each ZoneConnection specifies a pair of zone numbers and an associated crossing cost. When a route transitions between zones, the optimizer accumulates these costs, which discourages unnecessary zone crossings and promotes geographically cohesive routes.
        /// </summary>
        /// <value>Zone connections define penalties or restrictions for crossing geographic zone boundaries (e.g. bridge tolls, tunnel crossings, or administrative borders). Each ZoneConnection specifies a pair of zone numbers and an associated crossing cost. When a route transitions between zones, the optimizer accumulates these costs, which discourages unnecessary zone crossings and promotes geographically cohesive routes.</value>
        [DataMember(Name = "zoneConnections", EmitDefaultValue = false)]
        public List<ZoneConnection> ZoneConnections { get; set; }

        /// <summary>
        /// Gets or Sets TypeDictionaries
        /// </summary>
        [DataMember(Name = "typeDictionaries", EmitDefaultValue = false)]
        public TypeDictionaries TypeDictionaries { get; set; }

        /// <summary>
        /// Gets or Sets OptimizationOptions
        /// </summary>
        [DataMember(Name = "optimizationOptions", EmitDefaultValue = false)]
        public OptimizationOptions OptimizationOptions { get; set; }

        /// <summary>
        /// Gets or Sets CoreBuildOptions
        /// </summary>
        [DataMember(Name = "coreBuildOptions", EmitDefaultValue = false)]
        public CoreBuildOptions CoreBuildOptions { get; set; }

        /// <summary>
        /// Gets or Sets Solution
        /// </summary>
        [DataMember(Name = "solution", EmitDefaultValue = false)]
        public Solution Solution { get; set; }

        /// <summary>
        /// Gets or Sets Extension
        /// </summary>
        [DataMember(Name = "extension", EmitDefaultValue = false)]
        public JSONConfig Extension { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class RestOptimization {\n");
            sb.Append("  OptimizationStatus: ").Append(OptimizationStatus).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  CreatedTimeStamp: ").Append(CreatedTimeStamp).Append("\n");
            sb.Append("  Creator: ").Append(Creator).Append("\n");
            sb.Append("  Ident: ").Append(Ident).Append("\n");
            sb.Append("  Nodes: ").Append(Nodes).Append("\n");
            sb.Append("  Resources: ").Append(Resources).Append("\n");
            sb.Append("  NodeRelations: ").Append(NodeRelations).Append("\n");
            sb.Append("  ElementConnections: ").Append(ElementConnections).Append("\n");
            sb.Append("  ZoneConnections: ").Append(ZoneConnections).Append("\n");
            sb.Append("  TypeDictionaries: ").Append(TypeDictionaries).Append("\n");
            sb.Append("  OptimizationOptions: ").Append(OptimizationOptions).Append("\n");
            sb.Append("  CoreBuildOptions: ").Append(CoreBuildOptions).Append("\n");
            sb.Append("  Solution: ").Append(Solution).Append("\n");
            sb.Append("  Extension: ").Append(Extension).Append("\n");
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
