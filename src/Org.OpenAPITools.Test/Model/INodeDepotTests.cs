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
    ///  Class for testing INodeDepot
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class INodeDepotTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for INodeDepot
        //private INodeDepot instance;

        public INodeDepotTests()
        {
            // TODO uncomment below to create an instance of INodeDepot
            //instance = new INodeDepot();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of INodeDepot
        /// </summary>
        [Fact]
        public void INodeDepotInstanceTest()
        {
            // TODO uncomment below to test "IsType" INodeDepot
            //Assert.IsType<INodeDepot>(instance);
        }

        /// <summary>
        /// Test deserialize a SimpleNodeDepot from type INodeDepot
        /// </summary>
        [Fact]
        public void SimpleNodeDepotDeserializeFromINodeDepotTest()
        {
            // TODO uncomment below to test deserialize a SimpleNodeDepot from type INodeDepot
            //Assert.IsType<INodeDepot>(JsonConvert.DeserializeObject<INodeDepot>(new SimpleNodeDepot().ToJson()));
        }

        /// <summary>
        /// Test the property 'Items'
        /// </summary>
        [Fact]
        public void ItemsTest()
        {
            // TODO unit test for the property 'Items'
        }

        /// <summary>
        /// Test the property 'DepotId'
        /// </summary>
        [Fact]
        public void DepotIdTest()
        {
            // TODO unit test for the property 'DepotId'
        }

        /// <summary>
        /// Test the property 'HasTimedLoads'
        /// </summary>
        [Fact]
        public void HasTimedLoadsTest()
        {
            // TODO unit test for the property 'HasTimedLoads'
        }

        /// <summary>
        /// Test the property 'HasFlexLoad'
        /// </summary>
        [Fact]
        public void HasFlexLoadTest()
        {
            // TODO unit test for the property 'HasFlexLoad'
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
