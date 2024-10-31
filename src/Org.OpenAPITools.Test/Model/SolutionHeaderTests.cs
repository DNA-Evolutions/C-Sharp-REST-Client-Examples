/*
 * DNA Evolutions - JOpt.TourOptimizer
 *
 * This is DNA's JOpt.TourOptimizer service. A RESTful Spring Boot application using springdoc-openapi and OpenAPI 3. JOpt.TourOpptimizer is a service that delivers route optimization and automatic scheduling features to be easily integrated into any third-party application. JOpt.TourOpptimizer encapsulates all necessary optimization functionality and provides a comprehensive REST API that offers a domain-specific optimization interface for the transportation industry. The service is stateless and does not come with graphical user interfaces, map depiction or any databases. These extensions and adjustments are supposed to be introduced by the consumer of the service while integrating it into his/her own application. The service will allow for many suitable adjustments and user-specific settings to adjust the behaviour and optimization goals (e.g. minimizing distance, maximizing resource utilization, etc.) through a comprehensive set of functions. This will enable you to gain control of the complete optimization processes.This service is based on JOpt (7.5.1-rc2-j17)
 *
 * The version of the OpenAPI document: 1.2.8-alpha-SNAPSHOT)
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
    ///  Class for testing SolutionHeader
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class SolutionHeaderTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for SolutionHeader
        //private SolutionHeader instance;

        public SolutionHeaderTests()
        {
            // TODO uncomment below to create an instance of SolutionHeader
            //instance = new SolutionHeader();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of SolutionHeader
        /// </summary>
        [Fact]
        public void SolutionHeaderInstanceTest()
        {
            // TODO uncomment below to test "IsType" SolutionHeader
            //Assert.IsType<SolutionHeader>(instance);
        }

        /// <summary>
        /// Test the property 'NumRoutes'
        /// </summary>
        [Fact]
        public void NumRoutesTest()
        {
            // TODO unit test for the property 'NumRoutes'
        }

        /// <summary>
        /// Test the property 'NumScheduledRoutes'
        /// </summary>
        [Fact]
        public void NumScheduledRoutesTest()
        {
            // TODO unit test for the property 'NumScheduledRoutes'
        }

        /// <summary>
        /// Test the property 'TotElements'
        /// </summary>
        [Fact]
        public void TotElementsTest()
        {
            // TODO unit test for the property 'TotElements'
        }

        /// <summary>
        /// Test the property 'UnassignedElementIds'
        /// </summary>
        [Fact]
        public void UnassignedElementIdsTest()
        {
            // TODO unit test for the property 'UnassignedElementIds'
        }

        /// <summary>
        /// Test the property 'TotCost'
        /// </summary>
        [Fact]
        public void TotCostTest()
        {
            // TODO unit test for the property 'TotCost'
        }

        /// <summary>
        /// Test the property 'TotTime'
        /// </summary>
        [Fact]
        public void TotTimeTest()
        {
            // TODO unit test for the property 'TotTime'
        }

        /// <summary>
        /// Test the property 'TotIdleTime'
        /// </summary>
        [Fact]
        public void TotIdleTimeTest()
        {
            // TODO unit test for the property 'TotIdleTime'
        }

        /// <summary>
        /// Test the property 'TotProdTime'
        /// </summary>
        [Fact]
        public void TotProdTimeTest()
        {
            // TODO unit test for the property 'TotProdTime'
        }

        /// <summary>
        /// Test the property 'TotTranTime'
        /// </summary>
        [Fact]
        public void TotTranTimeTest()
        {
            // TODO unit test for the property 'TotTranTime'
        }

        /// <summary>
        /// Test the property 'TotTermiTime'
        /// </summary>
        [Fact]
        public void TotTermiTimeTest()
        {
            // TODO unit test for the property 'TotTermiTime'
        }

        /// <summary>
        /// Test the property 'TotDistance'
        /// </summary>
        [Fact]
        public void TotDistanceTest()
        {
            // TODO unit test for the property 'TotDistance'
        }

        /// <summary>
        /// Test the property 'TotTermiDistance'
        /// </summary>
        [Fact]
        public void TotTermiDistanceTest()
        {
            // TODO unit test for the property 'TotTermiDistance'
        }

        /// <summary>
        /// Test the property 'JobViolations'
        /// </summary>
        [Fact]
        public void JobViolationsTest()
        {
            // TODO unit test for the property 'JobViolations'
        }
    }
}
