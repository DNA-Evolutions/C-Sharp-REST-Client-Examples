/*
 * DNA Evolutions - JOpt.TourOptimizer
 *
 * This is DNA's JOpt.TourOptimizer service. A RESTful Spring Boot application using springdoc-openapi and OpenAPI 3. JOpt.TourOptimizer is a service that delivers route optimization and automatic scheduling features to be easily integrated into any third-party application. JOpt.TourOptimizer encapsulates all necessary optimization functionality and provides a comprehensive REST API that offers a domain-specific optimization interface for the transportation industry. The service is stateless and does not come with graphical user interfaces, map depiction or any databases. These extensions and adjustments are supposed to be introduced by the consumer of the service while integrating it into his/her own application. The service will allow for many suitable adjustments and user-specific settings to adjust the behaviour and optimization goals (e.g. minimizing distance, maximizing resource utilization, etc.) through a comprehensive set of functions. This will enable you to gain control of the complete optimization processes.This service is based on JOpt (7.5.1-rc3-j17-SNAPSHOT)
 *
 * The version of the OpenAPI document: unknown
 * Contact: info@dna-evolutions.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.IO;

namespace Org.OpenAPITools.Client
{
    /// <summary>
    /// Contract for Synchronous RESTful API interactions.
    ///
    /// This interface allows consumers to provide a custom API accessor client.
    /// </summary>
    public interface ISynchronousClient
    {
        /// <summary>
        /// Executes a blocking call to some <paramref name="path"/> using the GET http verb.
        /// </summary>
        /// <param name="path">The relative path to invoke.</param>
        /// <param name="options">The request parameters to pass along to the client.</param>
        /// <param name="configuration">Per-request configurable settings.</param>
        /// <typeparam name="T">The return type.</typeparam>
        /// <returns>The response data, decorated with <see cref="ApiResponse{T}"/></returns>
        ApiResponse<T> Get<T>(string path, RequestOptions options, IReadableConfiguration configuration = null);

        /// <summary>
        /// Executes a blocking call to some <paramref name="path"/> using the POST http verb.
        /// </summary>
        /// <param name="path">The relative path to invoke.</param>
        /// <param name="options">The request parameters to pass along to the client.</param>
        /// <param name="configuration">Per-request configurable settings.</param>
        /// <typeparam name="T">The return type.</typeparam>
        /// <returns>The response data, decorated with <see cref="ApiResponse{T}"/></returns>
        ApiResponse<T> Post<T>(string path, RequestOptions options, IReadableConfiguration configuration = null);

        /// <summary>
        /// Executes a blocking call to some <paramref name="path"/> using the PUT http verb.
        /// </summary>
        /// <param name="path">The relative path to invoke.</param>
        /// <param name="options">The request parameters to pass along to the client.</param>
        /// <param name="configuration">Per-request configurable settings.</param>
        /// <typeparam name="T">The return type.</typeparam>
        /// <returns>The response data, decorated with <see cref="ApiResponse{T}"/></returns>
        ApiResponse<T> Put<T>(string path, RequestOptions options, IReadableConfiguration configuration = null);

        /// <summary>
        /// Executes a blocking call to some <paramref name="path"/> using the DELETE http verb.
        /// </summary>
        /// <param name="path">The relative path to invoke.</param>
        /// <param name="options">The request parameters to pass along to the client.</param>
        /// <param name="configuration">Per-request configurable settings.</param>
        /// <typeparam name="T">The return type.</typeparam>
        /// <returns>The response data, decorated with <see cref="ApiResponse{T}"/></returns>
        ApiResponse<T> Delete<T>(string path, RequestOptions options, IReadableConfiguration configuration = null);

        /// <summary>
        /// Executes a blocking call to some <paramref name="path"/> using the HEAD http verb.
        /// </summary>
        /// <param name="path">The relative path to invoke.</param>
        /// <param name="options">The request parameters to pass along to the client.</param>
        /// <param name="configuration">Per-request configurable settings.</param>
        /// <typeparam name="T">The return type.</typeparam>
        /// <returns>The response data, decorated with <see cref="ApiResponse{T}"/></returns>
        ApiResponse<T> Head<T>(string path, RequestOptions options, IReadableConfiguration configuration = null);

        /// <summary>
        /// Executes a blocking call to some <paramref name="path"/> using the OPTIONS http verb.
        /// </summary>
        /// <param name="path">The relative path to invoke.</param>
        /// <param name="options">The request parameters to pass along to the client.</param>
        /// <param name="configuration">Per-request configurable settings.</param>
        /// <typeparam name="T">The return type.</typeparam>
        /// <returns>The response data, decorated with <see cref="ApiResponse{T}"/></returns>
        ApiResponse<T> Options<T>(string path, RequestOptions options, IReadableConfiguration configuration = null);

        /// <summary>
        /// Executes a blocking call to some <paramref name="path"/> using the PATCH http verb.
        /// </summary>
        /// <param name="path">The relative path to invoke.</param>
        /// <param name="options">The request parameters to pass along to the client.</param>
        /// <param name="configuration">Per-request configurable settings.</param>
        /// <typeparam name="T">The return type.</typeparam>
        /// <returns>The response data, decorated with <see cref="ApiResponse{T}"/></returns>
        ApiResponse<T> Patch<T>(string path, RequestOptions options, IReadableConfiguration configuration = null);
    }
}
