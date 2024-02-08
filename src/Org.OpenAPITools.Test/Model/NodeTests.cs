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
    ///  Class for testing Node
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class NodeTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for Node
        //private Node instance;

        public NodeTests()
        {
            // TODO uncomment below to create an instance of Node
            //instance = new Node();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of Node
        /// </summary>
        [Fact]
        public void NodeInstanceTest()
        {
            // TODO uncomment below to test "IsType" Node
            //Assert.IsType<Node>(instance);
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
        /// Test the property 'OpeningHours'
        /// </summary>
        [Fact]
        public void OpeningHoursTest()
        {
            // TODO unit test for the property 'OpeningHours'
        }

        /// <summary>
        /// Test the property 'VisitDuration'
        /// </summary>
        [Fact]
        public void VisitDurationTest()
        {
            // TODO unit test for the property 'VisitDuration'
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
        /// Test the property 'OfferedNode'
        /// </summary>
        [Fact]
        public void OfferedNodeTest()
        {
            // TODO unit test for the property 'OfferedNode'
        }

        /// <summary>
        /// Test the property 'LoadDimension'
        /// </summary>
        [Fact]
        public void LoadDimensionTest()
        {
            // TODO unit test for the property 'LoadDimension'
        }

        /// <summary>
        /// Test the property 'Load'
        /// </summary>
        [Fact]
        public void LoadTest()
        {
            // TODO unit test for the property 'Load'
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
        /// Test the property 'LockdownTime'
        /// </summary>
        [Fact]
        public void LockdownTimeTest()
        {
            // TODO unit test for the property 'LockdownTime'
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
        /// Test the property 'Priority'
        /// </summary>
        [Fact]
        public void PriorityTest()
        {
            // TODO unit test for the property 'Priority'
        }

        /// <summary>
        /// Test the property 'PriorityFirst'
        /// </summary>
        [Fact]
        public void PriorityFirstTest()
        {
            // TODO unit test for the property 'PriorityFirst'
        }

        /// <summary>
        /// Test the property 'PriorityLast'
        /// </summary>
        [Fact]
        public void PriorityLastTest()
        {
            // TODO unit test for the property 'PriorityLast'
        }

        /// <summary>
        /// Test the property 'NodeColor'
        /// </summary>
        [Fact]
        public void NodeColorTest()
        {
            // TODO unit test for the property 'NodeColor'
        }

        /// <summary>
        /// Test the property 'MinAutoFilterProtectedExecutions'
        /// </summary>
        [Fact]
        public void MinAutoFilterProtectedExecutionsTest()
        {
            // TODO unit test for the property 'MinAutoFilterProtectedExecutions'
        }

        /// <summary>
        /// Test the property 'NodeDepot'
        /// </summary>
        [Fact]
        public void NodeDepotTest()
        {
            // TODO unit test for the property 'NodeDepot'
        }

        /// <summary>
        /// Test the property 'RouteDependentVisitDuration'
        /// </summary>
        [Fact]
        public void RouteDependentVisitDurationTest()
        {
            // TODO unit test for the property 'RouteDependentVisitDuration'
        }

        /// <summary>
        /// Test the property 'AllowMoveToReduceFlexTime'
        /// </summary>
        [Fact]
        public void AllowMoveToReduceFlexTimeTest()
        {
            // TODO unit test for the property 'AllowMoveToReduceFlexTime'
        }

        /// <summary>
        /// Test the property 'MinVisitDuration'
        /// </summary>
        [Fact]
        public void MinVisitDurationTest()
        {
            // TODO unit test for the property 'MinVisitDuration'
        }

        /// <summary>
        /// Test the property 'JointVisitDuration'
        /// </summary>
        [Fact]
        public void JointVisitDurationTest()
        {
            // TODO unit test for the property 'JointVisitDuration'
        }

        /// <summary>
        /// Test the property 'ReturnStartDuration'
        /// </summary>
        [Fact]
        public void ReturnStartDurationTest()
        {
            // TODO unit test for the property 'ReturnStartDuration'
        }

        /// <summary>
        /// Test the property 'IsOptimizable'
        /// </summary>
        [Fact]
        public void IsOptimizableTest()
        {
            // TODO unit test for the property 'IsOptimizable'
        }

        /// <summary>
        /// Test the property 'IsOptional'
        /// </summary>
        [Fact]
        public void IsOptionalTest()
        {
            // TODO unit test for the property 'IsOptional'
        }

        /// <summary>
        /// Test the property 'IsUnassigned'
        /// </summary>
        [Fact]
        public void IsUnassignedTest()
        {
            // TODO unit test for the property 'IsUnassigned'
        }

        /// <summary>
        /// Test the property 'IsStayNode'
        /// </summary>
        [Fact]
        public void IsStayNodeTest()
        {
            // TODO unit test for the property 'IsStayNode'
        }

        /// <summary>
        /// Test the property 'IsWorkNode'
        /// </summary>
        [Fact]
        public void IsWorkNodeTest()
        {
            // TODO unit test for the property 'IsWorkNode'
        }

        /// <summary>
        /// Test the property 'IsWaitOnEarlyArrival'
        /// </summary>
        [Fact]
        public void IsWaitOnEarlyArrivalTest()
        {
            // TODO unit test for the property 'IsWaitOnEarlyArrival'
        }

        /// <summary>
        /// Test the property 'IsOpeningHoursIncludesDuration'
        /// </summary>
        [Fact]
        public void IsOpeningHoursIncludesDurationTest()
        {
            // TODO unit test for the property 'IsOpeningHoursIncludesDuration'
        }

        /// <summary>
        /// Test the property 'IsCausingIdleTimeCost'
        /// </summary>
        [Fact]
        public void IsCausingIdleTimeCostTest()
        {
            // TODO unit test for the property 'IsCausingIdleTimeCost'
        }

        /// <summary>
        /// Test the property 'IsWaitOnEarlyArrivalFirstNode'
        /// </summary>
        [Fact]
        public void IsWaitOnEarlyArrivalFirstNodeTest()
        {
            // TODO unit test for the property 'IsWaitOnEarlyArrivalFirstNode'
        }
    }
}
