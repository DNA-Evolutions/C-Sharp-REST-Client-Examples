/*
 * DNA Evolutions - JOpt.TourOptimizer
 *
 * This is DNA's JOpt.TourOptimizer service. A RESTful Spring Boot application using springdoc-openapi and OpenAPI 3. JOpt.TourOpptimizer is a service that delivers route optimization and automatic scheduling features to be easily integrated into any third-party application. JOpt.TourOpptimizer encapsulates all necessary optimization functionality and provides a comprehensive REST API that offers a domain-specific optimization interface for the transportation industry. The service is stateless and does not come with graphical user interfaces, map depiction or any databases. These extensions and adjustments are supposed to be introduced by the consumer of the service while integrating it into his/her own application. The service will allow for many suitable adjustments and user-specific settings to adjust the behaviour and optimization goals (e.g. minimizing distance, maximizing resource utilization, etc.) through a comprehensive set of functions. This will enable you to gain control of the complete optimization processes.This service is based on JOpt (null)
 *
 * The version of the OpenAPI document: 1.2.6-SNAPSHOT
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
    }
}
