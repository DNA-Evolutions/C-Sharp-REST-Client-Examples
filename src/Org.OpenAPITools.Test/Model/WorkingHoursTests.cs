/*
 * DNA Evolutions - JOpt.TourOptimizer
 *
 * This is DNA's JOpt.TourOptimizer service. A RESTful Spring Boot application using springdoc-openapi and OpenAPI 3. JOpt.TourOpptimizer is a service that delivers route optimization and automatic scheduling features to be easily integrated into any third-party application. JOpt.TourOpptimizer encapsulates all necessary optimization functionality and provides a comprehensive REST API that offers a domain-specific optimization interface for the transportation industry. The service is stateless and does not come with graphical user interfaces, map depiction or any databases. These extensions and adjustments are supposed to be introduced by the consumer of the service while integrating it into his/her own application. The service will allow for many suitable adjustments and user-specific settings to adjust the behaviour and optimization goals (e.g. minimizing distance, maximizing resource utilization, etc.) through a comprehensive set of functions. This will enable you to gain control of the complete optimization processes.This service is based on JOpt (7.5.1-SNAPSHOT)
 *
 * The version of the OpenAPI document: 1.2.1-SNAPSHOT
 * Contact: info@dna-evolutions.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using Xunit;

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Model;
using Org.OpenAPITools.Client;
using System.Reflection;
using Newtonsoft.Json;

namespace Org.OpenAPITools.Test.Model
{
    /// <summary>
    ///  Class for testing WorkingHours
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class WorkingHoursTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for WorkingHours
        //private WorkingHours instance;

        public WorkingHoursTests()
        {
            // TODO uncomment below to create an instance of WorkingHours
            //instance = new WorkingHours();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of WorkingHours
        /// </summary>
        [Fact]
        public void WorkingHoursInstanceTest()
        {
            // TODO uncomment below to test "IsType" WorkingHours
            //Assert.IsType<WorkingHours>(instance);
        }


        /// <summary>
        /// Test the property 'Begin'
        /// </summary>
        [Fact]
        public void BeginTest()
        {
            // TODO unit test for the property 'Begin'
        }
        /// <summary>
        /// Test the property 'End'
        /// </summary>
        [Fact]
        public void EndTest()
        {
            // TODO unit test for the property 'End'
        }
        /// <summary>
        /// Test the property 'ZoneId'
        /// </summary>
        [Fact]
        public void ZoneIdTest()
        {
            // TODO unit test for the property 'ZoneId'
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
        /// Test the property 'StayOutCycleDefinition'
        /// </summary>
        [Fact]
        public void StayOutCycleDefinitionTest()
        {
            // TODO unit test for the property 'StayOutCycleDefinition'
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
        /// Test the property 'LocalFlexTime'
        /// </summary>
        [Fact]
        public void LocalFlexTimeTest()
        {
            // TODO unit test for the property 'LocalFlexTime'
        }
        /// <summary>
        /// Test the property 'LocalPostFlexTime'
        /// </summary>
        [Fact]
        public void LocalPostFlexTimeTest()
        {
            // TODO unit test for the property 'LocalPostFlexTime'
        }
        /// <summary>
        /// Test the property 'LocalPostFlexTimeOnlyOnOvertime'
        /// </summary>
        [Fact]
        public void LocalPostFlexTimeOnlyOnOvertimeTest()
        {
            // TODO unit test for the property 'LocalPostFlexTimeOnlyOnOvertime'
        }
        /// <summary>
        /// Test the property 'MaxLocalPillarAfterHoursTime'
        /// </summary>
        [Fact]
        public void MaxLocalPillarAfterHoursTimeTest()
        {
            // TODO unit test for the property 'MaxLocalPillarAfterHoursTime'
        }
        /// <summary>
        /// Test the property 'NodeColorCapacities'
        /// </summary>
        [Fact]
        public void NodeColorCapacitiesTest()
        {
            // TODO unit test for the property 'NodeColorCapacities'
        }
        /// <summary>
        /// Test the property 'WorkingHoursConstraints'
        /// </summary>
        [Fact]
        public void WorkingHoursConstraintsTest()
        {
            // TODO unit test for the property 'WorkingHoursConstraints'
        }
        /// <summary>
        /// Test the property 'MultiWorkingHoursConstraints'
        /// </summary>
        [Fact]
        public void MultiWorkingHoursConstraintsTest()
        {
            // TODO unit test for the property 'MultiWorkingHoursConstraints'
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
        /// Test the property 'RouteStartTimeHook'
        /// </summary>
        [Fact]
        public void RouteStartTimeHookTest()
        {
            // TODO unit test for the property 'RouteStartTimeHook'
        }
        /// <summary>
        /// Test the property 'HookElementConnections'
        /// </summary>
        [Fact]
        public void HookElementConnectionsTest()
        {
            // TODO unit test for the property 'HookElementConnections'
        }
        /// <summary>
        /// Test the property 'IsAvailableForStay'
        /// </summary>
        [Fact]
        public void IsAvailableForStayTest()
        {
            // TODO unit test for the property 'IsAvailableForStay'
        }
        /// <summary>
        /// Test the property 'IsClosedRoute'
        /// </summary>
        [Fact]
        public void IsClosedRouteTest()
        {
            // TODO unit test for the property 'IsClosedRoute'
        }

    }

}
