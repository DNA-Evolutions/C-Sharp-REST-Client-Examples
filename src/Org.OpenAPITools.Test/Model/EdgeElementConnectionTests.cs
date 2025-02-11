/*
 * DNA Evolutions - JOpt.TourOptimizer
 *
 * This is DNA's JOpt.TourOptimizer service. A RESTful Spring Boot application using springdoc-openapi and OpenAPI 3. JOpt.TourOptimizer is a service that delivers route optimization and automatic scheduling features to be easily integrated into any third-party application. JOpt.TourOptimizer encapsulates all necessary optimization functionality and provides a comprehensive REST API that offers a domain-specific optimization interface for the transportation industry. The service is stateless and does not come with graphical user interfaces, map depiction or any databases. These extensions and adjustments are supposed to be introduced by the consumer of the service while integrating it into his/her own application. The service will allow for many suitable adjustments and user-specific settings to adjust the behaviour and optimization goals (e.g. minimizing distance, maximizing resource utilization, etc.) through a comprehensive set of functions. This will enable you to gain control of the complete optimization processes.This service is based on JOpt (7.5.1-rc3-j17-SNAPSHOT)
 *
 * The version of the OpenAPI document: unknown
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
    ///  Class for testing EdgeElementConnection
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class EdgeElementConnectionTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for EdgeElementConnection
        //private EdgeElementConnection instance;

        public EdgeElementConnectionTests()
        {
            // TODO uncomment below to create an instance of EdgeElementConnection
            //instance = new EdgeElementConnection();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of EdgeElementConnection
        /// </summary>
        [Fact]
        public void EdgeElementConnectionInstanceTest()
        {
            // TODO uncomment below to test "IsType" EdgeElementConnection
            //Assert.IsType<EdgeElementConnection>(instance);
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
        /// Test the property 'Time'
        /// </summary>
        [Fact]
        public void TimeTest()
        {
            // TODO unit test for the property 'Time'
        }

        /// <summary>
        /// Test the property 'FromPosition'
        /// </summary>
        [Fact]
        public void FromPositionTest()
        {
            // TODO unit test for the property 'FromPosition'
        }

        /// <summary>
        /// Test the property 'ToPosition'
        /// </summary>
        [Fact]
        public void ToPositionTest()
        {
            // TODO unit test for the property 'ToPosition'
        }

        /// <summary>
        /// Test the property 'ConnectionByTime'
        /// </summary>
        [Fact]
        public void ConnectionByTimeTest()
        {
            // TODO unit test for the property 'ConnectionByTime'
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
