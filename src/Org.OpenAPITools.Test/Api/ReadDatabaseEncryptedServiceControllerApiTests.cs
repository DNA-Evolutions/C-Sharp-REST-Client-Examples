/*
 * DNA Evolutions - JOpt.TourOptimizer
 *
 * This is DNA's JOpt.TourOptimizer service. A RESTful Spring Boot application using springdoc-openapi and OpenAPI 3. JOpt.TourOpptimizer is a service that delivers route optimization and automatic scheduling features to be easily integrated into any third-party application. JOpt.TourOpptimizer encapsulates all necessary optimization functionality and provides a comprehensive REST API that offers a domain-specific optimization interface for the transportation industry. The service is stateless and does not come with graphical user interfaces, map depiction or any databases. These extensions and adjustments are supposed to be introduced by the consumer of the service while integrating it into his/her own application. The service will allow for many suitable adjustments and user-specific settings to adjust the behaviour and optimization goals (e.g. minimizing distance, maximizing resource utilization, etc.) through a comprehensive set of functions. This will enable you to gain control of the complete optimization processes.This service is based on JOpt (7.5.1-rc2-j17)
 *
 * The version of the OpenAPI document: 1.2.8-alpha-SNAPSHOT)
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
    ///  Class for testing ReadDatabaseEncryptedServiceControllerApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class ReadDatabaseEncryptedServiceControllerApiTests : IDisposable
    {
        private ReadDatabaseEncryptedServiceControllerApi instance;

        public ReadDatabaseEncryptedServiceControllerApiTests()
        {
            instance = new ReadDatabaseEncryptedServiceControllerApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of ReadDatabaseEncryptedServiceControllerApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' ReadDatabaseEncryptedServiceControllerApi
            //Assert.IsType<ReadDatabaseEncryptedServiceControllerApi>(instance);
        }

        /// <summary>
        /// Test FindEncryptedOptimization
        /// </summary>
        [Fact]
        public void FindEncryptedOptimizationTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //DatabaseEncryptedItemSearch databaseEncryptedItemSearch = null;
            //var response = instance.FindEncryptedOptimization(databaseEncryptedItemSearch);
            //Assert.IsType<RestOptimization>(response);
        }

        /// <summary>
        /// Test FindEncryptedSolution
        /// </summary>
        [Fact]
        public void FindEncryptedSolutionTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //DatabaseEncryptedItemSearch databaseEncryptedItemSearch = null;
            //var response = instance.FindEncryptedSolution(databaseEncryptedItemSearch);
            //Assert.IsType<Solution>(response);
        }
    }
}
