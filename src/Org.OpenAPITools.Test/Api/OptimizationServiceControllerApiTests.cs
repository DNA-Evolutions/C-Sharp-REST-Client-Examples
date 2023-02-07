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
    ///  Class for testing OptimizationServiceControllerApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class OptimizationServiceControllerApiTests : IDisposable
    {
        private OptimizationServiceControllerApi instance;

        public OptimizationServiceControllerApiTests()
        {
            instance = new OptimizationServiceControllerApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of OptimizationServiceControllerApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' OptimizationServiceControllerApi
            //Assert.IsType<OptimizationServiceControllerApi>(instance);
        }

        /// <summary>
        /// Test Error
        /// </summary>
        [Fact]
        public void ErrorTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.Error();
            //Assert.IsType<List<JOptOptimizationError>>(response);
        }

        /// <summary>
        /// Test Progress
        /// </summary>
        [Fact]
        public void ProgressTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.Progress();
            //Assert.IsType<List<JOptOptimizationProgress>>(response);
        }

        /// <summary>
        /// Test Run
        /// </summary>
        [Fact]
        public void RunTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //RestOptimization restOptimization = null;
            //var response = instance.Run(restOptimization);
            //Assert.IsType<RestOptimization>(response);
        }

        /// <summary>
        /// Test RunOnlyResult
        /// </summary>
        [Fact]
        public void RunOnlyResultTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //RestOptimization restOptimization = null;
            //var response = instance.RunOnlyResult(restOptimization);
            //Assert.IsType<Solution>(response);
        }

        /// <summary>
        /// Test RunStartedSginal
        /// </summary>
        [Fact]
        public void RunStartedSginalTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.RunStartedSginal();
            //Assert.IsType<bool>(response);
        }

        /// <summary>
        /// Test Status
        /// </summary>
        [Fact]
        public void StatusTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.Status();
            //Assert.IsType<List<JOptOptimizationStatus>>(response);
        }

        /// <summary>
        /// Test StopOptimizationRun
        /// </summary>
        [Fact]
        public void StopOptimizationRunTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.StopOptimizationRun();
            //Assert.IsType<bool>(response);
        }

        /// <summary>
        /// Test Warning
        /// </summary>
        [Fact]
        public void WarningTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.Warning();
            //Assert.IsType<List<JOptOptimizationWarning>>(response);
        }
    }
}
