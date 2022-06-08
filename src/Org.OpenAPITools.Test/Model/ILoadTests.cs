/*
 * DNA Evolutions - JOpt.TourOptimizer
 *
 * This is DNA's JOpt.TourOptimizer service. A RESTful Spring Boot application using springdoc-openapi and OpenAPI 3. JOpt.TourOpptimizer is a service that delivers route optimization and automatic scheduling features to be easily integrated into any third-party application. JOpt.TourOpptimizer encapsulates all necessary optimization functionality and provides a comprehensive REST API that offers a domain-specific optimization interface for the transportation industry. The service is stateless and does not come with graphical user interfaces, map depiction or any databases. These extensions and adjustments are supposed to be introduced by the consumer of the service while integrating it into his/her own application. The service will allow for many suitable adjustments and user-specific settings to adjust the behaviour and optimization goals (e.g. minimizing distance, maximizing resource utilization, etc.) through a comprehensive set of functions. This will enable you to gain control of the complete optimization processes.This service is based on JOpt (7.4.9-SNAPSHOT)
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
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Model;
using Org.OpenAPITools.Client;
using System.Reflection;
using Newtonsoft.Json;

namespace Org.OpenAPITools.Test.Model
{
    /// <summary>
    ///  Class for testing ILoad
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class ILoadTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for ILoad
        //private ILoad instance;

        public ILoadTests()
        {
            // TODO uncomment below to create an instance of ILoad
            //instance = new ILoad();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of ILoad
        /// </summary>
        [Fact]
        public void ILoadInstanceTest()
        {
            // TODO uncomment below to test "IsType" ILoad
            //Assert.IsType<ILoad>(instance);
        }

        /// <summary>
        /// Test deserialize a MixedFlexLoad from type ILoad
        /// </summary>
        [Fact]
        public void MixedFlexLoadDeserializeFromILoadTest()
        {
            // TODO uncomment below to test deserialize a MixedFlexLoad from type ILoad
            //Assert.IsType<ILoad>(JsonConvert.DeserializeObject<ILoad>(new MixedFlexLoad().ToJson()));
        }
        /// <summary>
        /// Test deserialize a RequestFlexLoad from type ILoad
        /// </summary>
        [Fact]
        public void RequestFlexLoadDeserializeFromILoadTest()
        {
            // TODO uncomment below to test deserialize a RequestFlexLoad from type ILoad
            //Assert.IsType<ILoad>(JsonConvert.DeserializeObject<ILoad>(new RequestFlexLoad().ToJson()));
        }
        /// <summary>
        /// Test deserialize a SimpleLoad from type ILoad
        /// </summary>
        [Fact]
        public void SimpleLoadDeserializeFromILoadTest()
        {
            // TODO uncomment below to test deserialize a SimpleLoad from type ILoad
            //Assert.IsType<ILoad>(JsonConvert.DeserializeObject<ILoad>(new SimpleLoad().ToJson()));
        }
        /// <summary>
        /// Test deserialize a SupplyFlexLoad from type ILoad
        /// </summary>
        [Fact]
        public void SupplyFlexLoadDeserializeFromILoadTest()
        {
            // TODO uncomment below to test deserialize a SupplyFlexLoad from type ILoad
            //Assert.IsType<ILoad>(JsonConvert.DeserializeObject<ILoad>(new SupplyFlexLoad().ToJson()));
        }
        /// <summary>
        /// Test deserialize a UnloadAllLoad from type ILoad
        /// </summary>
        [Fact]
        public void UnloadAllLoadDeserializeFromILoadTest()
        {
            // TODO uncomment below to test deserialize a UnloadAllLoad from type ILoad
            //Assert.IsType<ILoad>(JsonConvert.DeserializeObject<ILoad>(new UnloadAllLoad().ToJson()));
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
        /// Test the property 'FuzzyVisit'
        /// </summary>
        [Fact]
        public void FuzzyVisitTest()
        {
            // TODO unit test for the property 'FuzzyVisit'
        }
        /// <summary>
        /// Test the property 'Request'
        /// </summary>
        [Fact]
        public void RequestTest()
        {
            // TODO unit test for the property 'Request'
        }
        /// <summary>
        /// Test the property 'LoadValue'
        /// </summary>
        [Fact]
        public void LoadValueTest()
        {
            // TODO unit test for the property 'LoadValue'
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
        /// Test the property 'TypeName'
        /// </summary>
        [Fact]
        public void TypeNameTest()
        {
            // TODO unit test for the property 'TypeName'
        }

    }

}
