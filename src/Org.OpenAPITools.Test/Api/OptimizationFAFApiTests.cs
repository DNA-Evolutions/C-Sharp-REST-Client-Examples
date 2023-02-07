/*
 * DNA Evolutions - JOpt.TourOptimizer
 *
 * This is DNA's JOpt.TourOptimizer service. A RESTful Spring Boot application using springdoc-openapi and OpenAPI 3. JOpt.TourOpptimizer is a service that delivers route optimization and automatic scheduling features to be easily integrated into any third-party application. JOpt.TourOpptimizer encapsulates all necessary optimization functionality and provides a comprehensive REST API that offers a domain-specific optimization interface for the transportation industry. The service is stateless and does not come with graphical user interfaces, map depiction or any databases. These extensions and adjustments are supposed to be introduced by the consumer of the service while integrating it into his/her own application. The service will allow for many suitable adjustments and user-specific settings to adjust the behaviour and optimization goals (e.g. minimizing distance, maximizing resource utilization, etc.) through a comprehensive set of functions. This will enable you to gain control of the complete optimization processes.This service is based on JOpt (7.5.1-SNAPSHOT)
 *
 * The version of the OpenAPI document: 1.2.1-SNAPSHOT
 * Contact: info@dna-evolutions.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using Xunit;

using Org.OpenAPITools.Client;
using Org.OpenAPITools.Api;
// uncomment below to import models
//using Org.OpenAPITools.Model;

namespace Org.OpenAPITools.Test.Api
{
    /// <summary>
    ///  Class for testing OptimizationFAFApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class OptimizationFAFApiTests : IDisposable
    {
        private OptimizationFAFApi instance;

        public OptimizationFAFApiTests()
        {
            instance = new OptimizationFAFApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of OptimizationFAFApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' OptimizationFAFApi
            //Assert.IsType<OptimizationFAFApi>(instance);
        }

        /// <summary>
        /// Test RunFAF
        /// </summary>
        [Fact]
        public void RunFAFTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //RestOptimization restOptimization = null;
            //var response = instance.RunFAF(restOptimization);
            //Assert.IsType<bool>(response);
        }

        /// <summary>
        /// Test RunOnlyResultFAF
        /// </summary>
        [Fact]
        public void RunOnlyResultFAFTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //RestOptimization restOptimization = null;
            //var response = instance.RunOnlyResultFAF(restOptimization);
            //Assert.IsType<Solution>(response);
        }
    }
}
