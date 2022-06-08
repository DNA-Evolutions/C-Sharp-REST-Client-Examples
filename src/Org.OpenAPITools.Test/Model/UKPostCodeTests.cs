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
    ///  Class for testing UKPostCode
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class UKPostCodeTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for UKPostCode
        //private UKPostCode instance;

        public UKPostCodeTests()
        {
            // TODO uncomment below to create an instance of UKPostCode
            //instance = new UKPostCode();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of UKPostCode
        /// </summary>
        [Fact]
        public void UKPostCodeInstanceTest()
        {
            // TODO uncomment below to test "IsType" UKPostCode
            //Assert.IsType<UKPostCode>(instance);
        }


        /// <summary>
        /// Test the property 'AreaIdent'
        /// </summary>
        [Fact]
        public void AreaIdentTest()
        {
            // TODO unit test for the property 'AreaIdent'
        }
        /// <summary>
        /// Test the property 'DistrictIdentOpt'
        /// </summary>
        [Fact]
        public void DistrictIdentOptTest()
        {
            // TODO unit test for the property 'DistrictIdentOpt'
        }
        /// <summary>
        /// Test the property 'SectorIdentOpt'
        /// </summary>
        [Fact]
        public void SectorIdentOptTest()
        {
            // TODO unit test for the property 'SectorIdentOpt'
        }
        /// <summary>
        /// Test the property 'UnitIdentOpt'
        /// </summary>
        [Fact]
        public void UnitIdentOptTest()
        {
            // TODO unit test for the property 'UnitIdentOpt'
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
