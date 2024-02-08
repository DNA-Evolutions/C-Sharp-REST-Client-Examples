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
    ///  Class for testing QualificationType
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class QualificationTypeTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for QualificationType
        //private QualificationType instance;

        public QualificationTypeTests()
        {
            // TODO uncomment below to create an instance of QualificationType
            //instance = new QualificationType();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of QualificationType
        /// </summary>
        [Fact]
        public void QualificationTypeInstanceTest()
        {
            // TODO uncomment below to test "IsType" QualificationType
            //Assert.IsType<QualificationType>(instance);
        }

        /// <summary>
        /// Test deserialize a TypeQualification from type QualificationType
        /// </summary>
        [Fact]
        public void TypeQualificationDeserializeFromQualificationTypeTest()
        {
            // TODO uncomment below to test deserialize a TypeQualification from type QualificationType
            //Assert.IsType<QualificationType>(JsonConvert.DeserializeObject<QualificationType>(new TypeQualification().ToJson()));
        }

        /// <summary>
        /// Test deserialize a TypeWithExpertiseQualification from type QualificationType
        /// </summary>
        [Fact]
        public void TypeWithExpertiseQualificationDeserializeFromQualificationTypeTest()
        {
            // TODO uncomment below to test deserialize a TypeWithExpertiseQualification from type QualificationType
            //Assert.IsType<QualificationType>(JsonConvert.DeserializeObject<QualificationType>(new TypeWithExpertiseQualification().ToJson()));
        }

        /// <summary>
        /// Test deserialize a UKPostCodeQualification from type QualificationType
        /// </summary>
        [Fact]
        public void UKPostCodeQualificationDeserializeFromQualificationTypeTest()
        {
            // TODO uncomment below to test deserialize a UKPostCodeQualification from type QualificationType
            //Assert.IsType<QualificationType>(JsonConvert.DeserializeObject<QualificationType>(new UKPostCodeQualification().ToJson()));
        }

        /// <summary>
        /// Test deserialize a ZoneNumberQualification from type QualificationType
        /// </summary>
        [Fact]
        public void ZoneNumberQualificationDeserializeFromQualificationTypeTest()
        {
            // TODO uncomment below to test deserialize a ZoneNumberQualification from type QualificationType
            //Assert.IsType<QualificationType>(JsonConvert.DeserializeObject<QualificationType>(new ZoneNumberQualification().ToJson()));
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
