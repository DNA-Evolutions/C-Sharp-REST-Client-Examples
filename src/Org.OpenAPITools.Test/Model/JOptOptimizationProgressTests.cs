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
    ///  Class for testing JOptOptimizationProgress
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class JOptOptimizationProgressTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for JOptOptimizationProgress
        //private JOptOptimizationProgress instance;

        public JOptOptimizationProgressTests()
        {
            // TODO uncomment below to create an instance of JOptOptimizationProgress
            //instance = new JOptOptimizationProgress();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of JOptOptimizationProgress
        /// </summary>
        [Fact]
        public void JOptOptimizationProgressInstanceTest()
        {
            // TODO uncomment below to test "IsType" JOptOptimizationProgress
            //Assert.IsType<JOptOptimizationProgress>(instance);
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
        /// Test the property 'Creator'
        /// </summary>
        [Fact]
        public void CreatorTest()
        {
            // TODO unit test for the property 'Creator'
        }

        /// <summary>
        /// Test the property 'Ident'
        /// </summary>
        [Fact]
        public void IdentTest()
        {
            // TODO unit test for the property 'Ident'
        }

        /// <summary>
        /// Test the property 'CallerId'
        /// </summary>
        [Fact]
        public void CallerIdTest()
        {
            // TODO unit test for the property 'CallerId'
        }

        /// <summary>
        /// Test the property 'CurProgress'
        /// </summary>
        [Fact]
        public void CurProgressTest()
        {
            // TODO unit test for the property 'CurProgress'
        }

        /// <summary>
        /// Test the property 'CurCost'
        /// </summary>
        [Fact]
        public void CurCostTest()
        {
            // TODO unit test for the property 'CurCost'
        }

        /// <summary>
        /// Test the property 'Stage'
        /// </summary>
        [Fact]
        public void StageTest()
        {
            // TODO unit test for the property 'Stage'
        }

        /// <summary>
        /// Test the property 'Desc'
        /// </summary>
        [Fact]
        public void DescTest()
        {
            // TODO unit test for the property 'Desc'
        }

        /// <summary>
        /// Test the property 'ExpireAt'
        /// </summary>
        [Fact]
        public void ExpireAtTest()
        {
            // TODO unit test for the property 'ExpireAt'
        }
    }
}
