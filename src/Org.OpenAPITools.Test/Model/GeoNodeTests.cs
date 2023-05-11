/*
 * DNA Evolutions - JOpt.TourOptimizer
 *
 * This is DNA's JOpt.TourOptimizer service. A RESTful Spring Boot application using springdoc-openapi and OpenAPI 3. JOpt.TourOpptimizer is a service that delivers route optimization and automatic scheduling features to be easily integrated into any third-party application. JOpt.TourOpptimizer encapsulates all necessary optimization functionality and provides a comprehensive REST API that offers a domain-specific optimization interface for the transportation industry. The service is stateless and does not come with graphical user interfaces, map depiction or any databases. These extensions and adjustments are supposed to be introduced by the consumer of the service while integrating it into his/her own application. The service will allow for many suitable adjustments and user-specific settings to adjust the behaviour and optimization goals (e.g. minimizing distance, maximizing resource utilization, etc.) through a comprehensive set of functions. This will enable you to gain control of the complete optimization processes.This service is based on JOpt (null)
 *
 * The version of the OpenAPI document: 1.2.2-SNAPSHOT
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
    ///  Class for testing GeoNode
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class GeoNodeTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for GeoNode
        //private GeoNode instance;

        public GeoNodeTests()
        {
            // TODO uncomment below to create an instance of GeoNode
            //instance = new GeoNode();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of GeoNode
        /// </summary>
        [Fact]
        public void GeoNodeInstanceTest()
        {
            // TODO uncomment below to test "IsType" GeoNode
            //Assert.IsType<GeoNode>(instance);
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
        /// Test the property 'PillarNode'
        /// </summary>
        [Fact]
        public void PillarNodeTest()
        {
            // TODO unit test for the property 'PillarNode'
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
