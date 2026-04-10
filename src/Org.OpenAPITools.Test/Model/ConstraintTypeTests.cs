/*
 * DNA Evolutions - JOpt.TourOptimizer
 *
 * # JOpt.TourOptimizer REST API  ![DNA Evolutions Logo](https://www.dna-evolutions.com/images/dna_logo.png)  JOpt.TourOptimizer is DNA Evolutions' route optimization and scheduling engine for transportation, field service, and resource planning scenarios.  This API is a **reactive Spring WebFlux REST service** with an **OpenAPI 3** contract, designed for integration into third-party systems and for generating typed client SDKs directly from the schema.  - --  ## Endpoint groups  ### Job endpoints (`job`)  The primary integration model for all deployments with a connected database.  Submit an optimization job with `POST /api/v1/jobs` and receive an HTTP 202 response containing a unique `jobId`. Use that jobId to poll for status, progress, warnings, errors, and the final result at any time — no open connection required.  | Endpoint | Description | Availability | |- --|- --|- --| | `POST /api/v1/jobs` | Submit an async optimization job | All deployments | | `GET /api/v1/jobs/{jobId}/status` | Poll job status | All deployments | | `GET /api/v1/jobs/{jobId}/result` | Retrieve full optimization result | All deployments | | `GET /api/v1/jobs/{jobId}/solution` | Retrieve solution payload only | All deployments | | `GET /api/v1/jobs/{jobId}/progress` | Retrieve progress snapshots | All deployments | | `GET /api/v1/jobs/{jobId}/warnings` | Retrieve warning messages | All deployments | | `GET /api/v1/jobs/{jobId}/errors` | Retrieve error messages | All deployments | | `GET /api/v1/jobs/{jobId}/export` | Download result as ZIP archive | All deployments | | `POST /api/v1/jobs/{jobId}/stop` | Send graceful stop signal to a running job | All deployments | | `DELETE /api/v1/jobs/{jobId}` | Delete all persisted data for a job | All deployments | | `POST /api/v1/jobs/search` | Search jobs by metadata criteria | On-premise (free-search enabled) | | `POST /api/v1/jobs/import` | Import a pre-computed result directly | On-premise (import enabled) |  All job endpoints require the `X-Tenant-Id` header, injected by the API gateway. The `jobId` returned at submission is the only token needed for all subsequent reads.  ### Synchronous run endpoints (`optimization`)  Available on on-premise installations with synchronous mode enabled. The client holds the HTTP connection open and receives the result directly in the response body.  | Endpoint | Description | |- --|- --| | `POST /api/v1/runs` | Start a run, return runId immediately (HTTP 202) | | `GET /api/v1/runs/{runId}/result` | Block until run completes, return full result | | `GET /api/v1/runs/{runId}/solution` | Block until run completes, return solution only | | `DELETE /api/v1/runs/{runId}` | Stop the run gracefully | | `GET /api/v1/runs/{runId}/started` | One-shot signal when the run has started |  ### Event stream endpoints (`stream`)  Server-Sent Event streams for monitoring a running synchronous optimization in near real time. Subscribe to one or more streams while a `POST /api/v1/runs` call is in progress.  | Endpoint | Event type | |- --|- --| | `GET /api/v1/runs/{runId}/stream/progress` | Progress percentage and timing | | `GET /api/v1/runs/{runId}/stream/status` | Lifecycle status transitions | | `GET /api/v1/runs/{runId}/stream/warnings` | Non-fatal solver warnings | | `GET /api/v1/runs/{runId}/stream/errors` | Solver error events |  ### Health endpoint (`health`)  | Endpoint | Description | |- --|- --| | `GET /api/v1/health` | Service liveness and readiness |  - --  ## Deployment modes and feature flags  Endpoints that require specific conditions are activated via Spring `@Conditional` annotations and application properties. Endpoints not active in a given deployment are absent from the service entirely and do not appear in the runtime spec.  | Condition | Property / annotation | Effect | |- --|- --|- --| | Database connected | `DatabaseEnabledCondition` | Activates all `job` endpoints | | Sync mode | `SynchControllersEnabledCondition` | Activates `optimization` and `stream` endpoints | | Free search | `DatabaseFreeSearchEnabledCondition` | Activates `POST /api/v1/jobs/search` | | Import | `DatabaseJobImportEnabledCondition` | Activates `POST /api/v1/jobs/import` |  - --  ## Tenant isolation  Every job endpoint is scoped by `X-Tenant-Id`, injected by the API gateway. Persisted documents are tagged with both `jobId` and `tenantId`. A request with a valid `jobId` but a mismatched `tenantId` returns no data. The `jobId` is a UUID v4 (122 bits of randomness) and is not a security credential — security is enforced by the verified `tenantId` from the gateway header.  - --  ## Encryption at rest  Results can be stored encrypted in two modes:  - **CLIENT mode**: key derived from a caller-provided passphrase via PBKDF2.   Pass the same secret in `X-Encryption-Secret` when reading back. - **KMS mode**: server-generated data encryption key (DEK) wrapped by an   external key management service (Azure Key Vault, AWS KMS). Decryption is   transparent to the caller.  The `encrypted` and `sec` fields in `DatabaseInfoSearchResult` indicate which mode was used for each stored result.  - --  ## Client generation  The OpenAPI schema can be used to generate typed clients for any language. The `operationId` values follow `{verb}{Resource}` lowerCamelCase convention (`createJob`, `getJobResult`, `listJobs`, etc.) for predictable generated method names.  - --  This service is based on **JOpt Core (unknown)**. 
 *
 * The version of the OpenAPI document: 1.3.5-SNAPSHOT
 * Contact: info@dna-evolutions.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using Xunit;

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Org.OpenAPITools.Model;
using Org.OpenAPITools.Client;
using System.Reflection;
using Newtonsoft.Json;

namespace Org.OpenAPITools.Test.Model
{
    /// <summary>
    ///  Class for testing ConstraintType
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class ConstraintTypeTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for ConstraintType
        //private ConstraintType instance;

        public ConstraintTypeTests()
        {
            // TODO uncomment below to create an instance of ConstraintType
            //instance = new ConstraintType();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of ConstraintType
        /// </summary>
        [Fact]
        public void ConstraintTypeInstanceTest()
        {
            // TODO uncomment below to test "IsType" ConstraintType
            //Assert.IsType<ConstraintType>(instance);
        }

        /// <summary>
        /// Test deserialize a AbsoluteNodeColorMultiRouteConstraint from type ConstraintType
        /// </summary>
        [Fact]
        public void AbsoluteNodeColorMultiRouteConstraintDeserializeFromConstraintTypeTest()
        {
            // TODO uncomment below to test deserialize a AbsoluteNodeColorMultiRouteConstraint from type ConstraintType
            //Assert.IsType<ConstraintType>(JsonConvert.DeserializeObject<ConstraintType>(new AbsoluteNodeColorMultiRouteConstraint().ToJson()));
        }

        /// <summary>
        /// Test deserialize a BindingResourceConstraint from type ConstraintType
        /// </summary>
        [Fact]
        public void BindingResourceConstraintDeserializeFromConstraintTypeTest()
        {
            // TODO uncomment below to test deserialize a BindingResourceConstraint from type ConstraintType
            //Assert.IsType<ConstraintType>(JsonConvert.DeserializeObject<ConstraintType>(new BindingResourceConstraint().ToJson()));
        }

        /// <summary>
        /// Test deserialize a BitTypeConstraint from type ConstraintType
        /// </summary>
        [Fact]
        public void BitTypeConstraintDeserializeFromConstraintTypeTest()
        {
            // TODO uncomment below to test deserialize a BitTypeConstraint from type ConstraintType
            //Assert.IsType<ConstraintType>(JsonConvert.DeserializeObject<ConstraintType>(new BitTypeConstraint().ToJson()));
        }

        /// <summary>
        /// Test deserialize a BitTypeWithExpertiseConstraint from type ConstraintType
        /// </summary>
        [Fact]
        public void BitTypeWithExpertiseConstraintDeserializeFromConstraintTypeTest()
        {
            // TODO uncomment below to test deserialize a BitTypeWithExpertiseConstraint from type ConstraintType
            //Assert.IsType<ConstraintType>(JsonConvert.DeserializeObject<ConstraintType>(new BitTypeWithExpertiseConstraint().ToJson()));
        }

        /// <summary>
        /// Test deserialize a ConnectedConstraint from type ConstraintType
        /// </summary>
        [Fact]
        public void ConnectedConstraintDeserializeFromConstraintTypeTest()
        {
            // TODO uncomment below to test deserialize a ConnectedConstraint from type ConstraintType
            //Assert.IsType<ConstraintType>(JsonConvert.DeserializeObject<ConstraintType>(new ConnectedConstraint().ToJson()));
        }

        /// <summary>
        /// Test deserialize a ExcludingResourceConstraint from type ConstraintType
        /// </summary>
        [Fact]
        public void ExcludingResourceConstraintDeserializeFromConstraintTypeTest()
        {
            // TODO uncomment below to test deserialize a ExcludingResourceConstraint from type ConstraintType
            //Assert.IsType<ConstraintType>(JsonConvert.DeserializeObject<ConstraintType>(new ExcludingResourceConstraint().ToJson()));
        }

        /// <summary>
        /// Test deserialize a MagnetoNodeConstraint from type ConstraintType
        /// </summary>
        [Fact]
        public void MagnetoNodeConstraintDeserializeFromConstraintTypeTest()
        {
            // TODO uncomment below to test deserialize a MagnetoNodeConstraint from type ConstraintType
            //Assert.IsType<ConstraintType>(JsonConvert.DeserializeObject<ConstraintType>(new MagnetoNodeConstraint().ToJson()));
        }

        /// <summary>
        /// Test deserialize a NodeColorMultiRouteConstraint from type ConstraintType
        /// </summary>
        [Fact]
        public void NodeColorMultiRouteConstraintDeserializeFromConstraintTypeTest()
        {
            // TODO uncomment below to test deserialize a NodeColorMultiRouteConstraint from type ConstraintType
            //Assert.IsType<ConstraintType>(JsonConvert.DeserializeObject<ConstraintType>(new NodeColorMultiRouteConstraint().ToJson()));
        }

        /// <summary>
        /// Test deserialize a ResourceLocationConstraint from type ConstraintType
        /// </summary>
        [Fact]
        public void ResourceLocationConstraintDeserializeFromConstraintTypeTest()
        {
            // TODO uncomment below to test deserialize a ResourceLocationConstraint from type ConstraintType
            //Assert.IsType<ConstraintType>(JsonConvert.DeserializeObject<ConstraintType>(new ResourceLocationConstraint().ToJson()));
        }

        /// <summary>
        /// Test deserialize a TypeConstraint from type ConstraintType
        /// </summary>
        [Fact]
        public void TypeConstraintDeserializeFromConstraintTypeTest()
        {
            // TODO uncomment below to test deserialize a TypeConstraint from type ConstraintType
            //Assert.IsType<ConstraintType>(JsonConvert.DeserializeObject<ConstraintType>(new TypeConstraint().ToJson()));
        }

        /// <summary>
        /// Test deserialize a TypeWithExpertiseConstraint from type ConstraintType
        /// </summary>
        [Fact]
        public void TypeWithExpertiseConstraintDeserializeFromConstraintTypeTest()
        {
            // TODO uncomment below to test deserialize a TypeWithExpertiseConstraint from type ConstraintType
            //Assert.IsType<ConstraintType>(JsonConvert.DeserializeObject<ConstraintType>(new TypeWithExpertiseConstraint().ToJson()));
        }

        /// <summary>
        /// Test deserialize a UKPostCodeConstraint from type ConstraintType
        /// </summary>
        [Fact]
        public void UKPostCodeConstraintDeserializeFromConstraintTypeTest()
        {
            // TODO uncomment below to test deserialize a UKPostCodeConstraint from type ConstraintType
            //Assert.IsType<ConstraintType>(JsonConvert.DeserializeObject<ConstraintType>(new UKPostCodeConstraint().ToJson()));
        }

        /// <summary>
        /// Test deserialize a ZoneNumberConstraint from type ConstraintType
        /// </summary>
        [Fact]
        public void ZoneNumberConstraintDeserializeFromConstraintTypeTest()
        {
            // TODO uncomment below to test deserialize a ZoneNumberConstraint from type ConstraintType
            //Assert.IsType<ConstraintType>(JsonConvert.DeserializeObject<ConstraintType>(new ZoneNumberConstraint().ToJson()));
        }

        /// <summary>
        /// Test the property 'TypeName'
        /// </summary>
        [Fact]
        public void TypeNameTest()
        {
            // TODO unit test for the property 'TypeName'
        }
    }
}
