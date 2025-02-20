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
    ///  Class for testing IResourceDepot
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class IResourceDepotTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for IResourceDepot
        //private IResourceDepot instance;

        public IResourceDepotTests()
        {
            // TODO uncomment below to create an instance of IResourceDepot
            //instance = new IResourceDepot();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of IResourceDepot
        /// </summary>
        [Fact]
        public void IResourceDepotInstanceTest()
        {
            // TODO uncomment below to test "IsType" IResourceDepot
            //Assert.IsType<IResourceDepot>(instance);
        }

        /// <summary>
        /// Test deserialize a SimpleResourceDepot from type IResourceDepot
        /// </summary>
        [Fact]
        public void SimpleResourceDepotDeserializeFromIResourceDepotTest()
        {
            // TODO uncomment below to test deserialize a SimpleResourceDepot from type IResourceDepot
            //Assert.IsType<IResourceDepot>(JsonConvert.DeserializeObject<IResourceDepot>(new SimpleResourceDepot().ToJson()));
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
        /// Test the property 'MaximalTotalCapacity'
        /// </summary>
        [Fact]
        public void MaximalTotalCapacityTest()
        {
            // TODO unit test for the property 'MaximalTotalCapacity'
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
        /// Test the property 'CapacityUnitMap'
        /// </summary>
        [Fact]
        public void CapacityUnitMapTest()
        {
            // TODO unit test for the property 'CapacityUnitMap'
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
