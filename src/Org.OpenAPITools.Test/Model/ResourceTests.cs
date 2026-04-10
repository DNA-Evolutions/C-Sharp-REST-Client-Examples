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
    ///  Class for testing Resource
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class ResourceTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for Resource
        //private Resource instance;

        public ResourceTests()
        {
            // TODO uncomment below to create an instance of Resource
            //instance = new Resource();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of Resource
        /// </summary>
        [Fact]
        public void ResourceInstanceTest()
        {
            // TODO uncomment below to test "IsType" Resource
            //Assert.IsType<Resource>(instance);
        }

        /// <summary>
        /// Test the property 'Id'
        /// </summary>
        [Fact]
        public void IdTest()
        {
            // TODO unit test for the property 'Id'
        }

        /// <summary>
        /// Test the property 'ExtraInfo'
        /// </summary>
        [Fact]
        public void ExtraInfoTest()
        {
            // TODO unit test for the property 'ExtraInfo'
        }

        /// <summary>
        /// Test the property 'LocationId'
        /// </summary>
        [Fact]
        public void LocationIdTest()
        {
            // TODO unit test for the property 'LocationId'
        }

        /// <summary>
        /// Test the property 'ConstraintAliasId'
        /// </summary>
        [Fact]
        public void ConstraintAliasIdTest()
        {
            // TODO unit test for the property 'ConstraintAliasId'
        }

        /// <summary>
        /// Test the property 'Type'
        /// </summary>
        [Fact]
        public void TypeTest()
        {
            // TODO unit test for the property 'Type'
        }

        /// <summary>
        /// Test the property 'Position'
        /// </summary>
        [Fact]
        public void PositionTest()
        {
            // TODO unit test for the property 'Position'
        }

        /// <summary>
        /// Test the property 'WorkingHours'
        /// </summary>
        [Fact]
        public void WorkingHoursTest()
        {
            // TODO unit test for the property 'WorkingHours'
        }

        /// <summary>
        /// Test the property 'MaxTime'
        /// </summary>
        [Fact]
        public void MaxTimeTest()
        {
            // TODO unit test for the property 'MaxTime'
        }

        /// <summary>
        /// Test the property 'MaxDistance'
        /// </summary>
        [Fact]
        public void MaxDistanceTest()
        {
            // TODO unit test for the property 'MaxDistance'
        }

        /// <summary>
        /// Test the property 'DestinationPosition'
        /// </summary>
        [Fact]
        public void DestinationPositionTest()
        {
            // TODO unit test for the property 'DestinationPosition'
        }

        /// <summary>
        /// Test the property 'StayOutDefinition'
        /// </summary>
        [Fact]
        public void StayOutDefinitionTest()
        {
            // TODO unit test for the property 'StayOutDefinition'
        }

        /// <summary>
        /// Test the property 'StayOutCycleDefinition'
        /// </summary>
        [Fact]
        public void StayOutCycleDefinitionTest()
        {
            // TODO unit test for the property 'StayOutCycleDefinition'
        }

        /// <summary>
        /// Test the property 'StayOutPolicyTime'
        /// </summary>
        [Fact]
        public void StayOutPolicyTimeTest()
        {
            // TODO unit test for the property 'StayOutPolicyTime'
        }

        /// <summary>
        /// Test the property 'StayOutPolicyDistance'
        /// </summary>
        [Fact]
        public void StayOutPolicyDistanceTest()
        {
            // TODO unit test for the property 'StayOutPolicyDistance'
        }

        /// <summary>
        /// Test the property 'Capacity'
        /// </summary>
        [Fact]
        public void CapacityTest()
        {
            // TODO unit test for the property 'Capacity'
        }

        /// <summary>
        /// Test the property 'InitialLoad'
        /// </summary>
        [Fact]
        public void InitialLoadTest()
        {
            // TODO unit test for the property 'InitialLoad'
        }

        /// <summary>
        /// Test the property 'MinDegratedCapacity'
        /// </summary>
        [Fact]
        public void MinDegratedCapacityTest()
        {
            // TODO unit test for the property 'MinDegratedCapacity'
        }

        /// <summary>
        /// Test the property 'CapacityDegPerStop'
        /// </summary>
        [Fact]
        public void CapacityDegPerStopTest()
        {
            // TODO unit test for the property 'CapacityDegPerStop'
        }

        /// <summary>
        /// Test the property 'StartReductionTimeDefinition'
        /// </summary>
        [Fact]
        public void StartReductionTimeDefinitionTest()
        {
            // TODO unit test for the property 'StartReductionTimeDefinition'
        }

        /// <summary>
        /// Test the property 'StartReductionTimePillarDefinition'
        /// </summary>
        [Fact]
        public void StartReductionTimePillarDefinitionTest()
        {
            // TODO unit test for the property 'StartReductionTimePillarDefinition'
        }

        /// <summary>
        /// Test the property 'StartReductionTimeIncludeDefinition'
        /// </summary>
        [Fact]
        public void StartReductionTimeIncludeDefinitionTest()
        {
            // TODO unit test for the property 'StartReductionTimeIncludeDefinition'
        }

        /// <summary>
        /// Test the property 'FlexTime'
        /// </summary>
        [Fact]
        public void FlexTimeTest()
        {
            // TODO unit test for the property 'FlexTime'
        }

        /// <summary>
        /// Test the property 'PostFlexTime'
        /// </summary>
        [Fact]
        public void PostFlexTimeTest()
        {
            // TODO unit test for the property 'PostFlexTime'
        }

        /// <summary>
        /// Test the property 'PostFlexTimeOnlyOnOvertime'
        /// </summary>
        [Fact]
        public void PostFlexTimeOnlyOnOvertimeTest()
        {
            // TODO unit test for the property 'PostFlexTimeOnlyOnOvertime'
        }

        /// <summary>
        /// Test the property 'MaxPillarAfterHoursTime'
        /// </summary>
        [Fact]
        public void MaxPillarAfterHoursTimeTest()
        {
            // TODO unit test for the property 'MaxPillarAfterHoursTime'
        }

        /// <summary>
        /// Test the property 'MaxDriveTimeFirstNode'
        /// </summary>
        [Fact]
        public void MaxDriveTimeFirstNodeTest()
        {
            // TODO unit test for the property 'MaxDriveTimeFirstNode'
        }

        /// <summary>
        /// Test the property 'MaxDriveDistanceFirstNode'
        /// </summary>
        [Fact]
        public void MaxDriveDistanceFirstNodeTest()
        {
            // TODO unit test for the property 'MaxDriveDistanceFirstNode'
        }

        /// <summary>
        /// Test the property 'MaxDriveTimeLastNode'
        /// </summary>
        [Fact]
        public void MaxDriveTimeLastNodeTest()
        {
            // TODO unit test for the property 'MaxDriveTimeLastNode'
        }

        /// <summary>
        /// Test the property 'MaxDriveDistanceLastNode'
        /// </summary>
        [Fact]
        public void MaxDriveDistanceLastNodeTest()
        {
            // TODO unit test for the property 'MaxDriveDistanceLastNode'
        }

        /// <summary>
        /// Test the property 'KilometerCost'
        /// </summary>
        [Fact]
        public void KilometerCostTest()
        {
            // TODO unit test for the property 'KilometerCost'
        }

        /// <summary>
        /// Test the property 'HourCost'
        /// </summary>
        [Fact]
        public void HourCostTest()
        {
            // TODO unit test for the property 'HourCost'
        }

        /// <summary>
        /// Test the property 'ProductionHourCost'
        /// </summary>
        [Fact]
        public void ProductionHourCostTest()
        {
            // TODO unit test for the property 'ProductionHourCost'
        }

        /// <summary>
        /// Test the property 'FixCost'
        /// </summary>
        [Fact]
        public void FixCostTest()
        {
            // TODO unit test for the property 'FixCost'
        }

        /// <summary>
        /// Test the property 'PreWorkDrivingTime'
        /// </summary>
        [Fact]
        public void PreWorkDrivingTimeTest()
        {
            // TODO unit test for the property 'PreWorkDrivingTime'
        }

        /// <summary>
        /// Test the property 'SkillEfficiencyFactor'
        /// </summary>
        [Fact]
        public void SkillEfficiencyFactorTest()
        {
            // TODO unit test for the property 'SkillEfficiencyFactor'
        }

        /// <summary>
        /// Test the property 'AcceptableOvertime'
        /// </summary>
        [Fact]
        public void AcceptableOvertimeTest()
        {
            // TODO unit test for the property 'AcceptableOvertime'
        }

        /// <summary>
        /// Test the property 'StrictOvertime'
        /// </summary>
        [Fact]
        public void StrictOvertimeTest()
        {
            // TODO unit test for the property 'StrictOvertime'
        }

        /// <summary>
        /// Test the property 'AcceptableOverdistance'
        /// </summary>
        [Fact]
        public void AcceptableOverdistanceTest()
        {
            // TODO unit test for the property 'AcceptableOverdistance'
        }

        /// <summary>
        /// Test the property 'StrictOverdistance'
        /// </summary>
        [Fact]
        public void StrictOverdistanceTest()
        {
            // TODO unit test for the property 'StrictOverdistance'
        }

        /// <summary>
        /// Test the property 'AverageSpeed'
        /// </summary>
        [Fact]
        public void AverageSpeedTest()
        {
            // TODO unit test for the property 'AverageSpeed'
        }

        /// <summary>
        /// Test the property 'Qualifications'
        /// </summary>
        [Fact]
        public void QualificationsTest()
        {
            // TODO unit test for the property 'Qualifications'
        }

        /// <summary>
        /// Test the property 'Constraints'
        /// </summary>
        [Fact]
        public void ConstraintsTest()
        {
            // TODO unit test for the property 'Constraints'
        }

        /// <summary>
        /// Test the property 'ConnectionTimeEfficiencyFactor'
        /// </summary>
        [Fact]
        public void ConnectionTimeEfficiencyFactorTest()
        {
            // TODO unit test for the property 'ConnectionTimeEfficiencyFactor'
        }

        /// <summary>
        /// Test the property 'Co2emissionFactor'
        /// </summary>
        [Fact]
        public void Co2emissionFactorTest()
        {
            // TODO unit test for the property 'Co2emissionFactor'
        }

        /// <summary>
        /// Test the property 'ResourceDepot'
        /// </summary>
        [Fact]
        public void ResourceDepotTest()
        {
            // TODO unit test for the property 'ResourceDepot'
        }

        /// <summary>
        /// Test the property 'OverallVisitDurationEfficiency'
        /// </summary>
        [Fact]
        public void OverallVisitDurationEfficiencyTest()
        {
            // TODO unit test for the property 'OverallVisitDurationEfficiency'
        }

        /// <summary>
        /// Test the property 'IsReductionTimeIncludedInTotalWorkingTime'
        /// </summary>
        [Fact]
        public void IsReductionTimeIncludedInTotalWorkingTimeTest()
        {
            // TODO unit test for the property 'IsReductionTimeIncludedInTotalWorkingTime'
        }

        /// <summary>
        /// Test the property 'IsReductionTimeOnlyUsedForDriving'
        /// </summary>
        [Fact]
        public void IsReductionTimeOnlyUsedForDrivingTest()
        {
            // TODO unit test for the property 'IsReductionTimeOnlyUsedForDriving'
        }

        /// <summary>
        /// Test the property 'IsServiceHub'
        /// </summary>
        [Fact]
        public void IsServiceHubTest()
        {
            // TODO unit test for the property 'IsServiceHub'
        }
    }
}
