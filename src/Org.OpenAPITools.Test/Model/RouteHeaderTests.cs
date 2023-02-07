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
    ///  Class for testing RouteHeader
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class RouteHeaderTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for RouteHeader
        //private RouteHeader instance;

        public RouteHeaderTests()
        {
            // TODO uncomment below to create an instance of RouteHeader
            //instance = new RouteHeader();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of RouteHeader
        /// </summary>
        [Fact]
        public void RouteHeaderInstanceTest()
        {
            // TODO uncomment below to test "IsType" RouteHeader
            //Assert.IsType<RouteHeader>(instance);
        }


        /// <summary>
        /// Test the property 'Cost'
        /// </summary>
        [Fact]
        public void CostTest()
        {
            // TODO unit test for the property 'Cost'
        }
        /// <summary>
        /// Test the property 'Time'
        /// </summary>
        [Fact]
        public void TimeTest()
        {
            // TODO unit test for the property 'Time'
        }
        /// <summary>
        /// Test the property 'IdleTime'
        /// </summary>
        [Fact]
        public void IdleTimeTest()
        {
            // TODO unit test for the property 'IdleTime'
        }
        /// <summary>
        /// Test the property 'ProdTime'
        /// </summary>
        [Fact]
        public void ProdTimeTest()
        {
            // TODO unit test for the property 'ProdTime'
        }
        /// <summary>
        /// Test the property 'TranTime'
        /// </summary>
        [Fact]
        public void TranTimeTest()
        {
            // TODO unit test for the property 'TranTime'
        }
        /// <summary>
        /// Test the property 'TermiTime'
        /// </summary>
        [Fact]
        public void TermiTimeTest()
        {
            // TODO unit test for the property 'TermiTime'
        }
        /// <summary>
        /// Test the property 'Distance'
        /// </summary>
        [Fact]
        public void DistanceTest()
        {
            // TODO unit test for the property 'Distance'
        }
        /// <summary>
        /// Test the property 'TermiDistance'
        /// </summary>
        [Fact]
        public void TermiDistanceTest()
        {
            // TODO unit test for the property 'TermiDistance'
        }
        /// <summary>
        /// Test the property 'RouteViolations'
        /// </summary>
        [Fact]
        public void RouteViolationsTest()
        {
            // TODO unit test for the property 'RouteViolations'
        }
        /// <summary>
        /// Test the property 'IsClosed'
        /// </summary>
        [Fact]
        public void IsClosedTest()
        {
            // TODO unit test for the property 'IsClosed'
        }
        /// <summary>
        /// Test the property 'IsAlternateDestination'
        /// </summary>
        [Fact]
        public void IsAlternateDestinationTest()
        {
            // TODO unit test for the property 'IsAlternateDestination'
        }

    }

}
