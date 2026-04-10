/*-
 * #%L
 * JOpt C# REST Client Examples
 * %%
 * Copyright (C) 2017 - 2023 DNA Evolutions GmbH
 * %%
 * This file is subject to the terms and conditions defined in file 'LICENSE.md',
 * which is part of this repository.
 *
 * If not, see <https://www.dna-evolutions.com/agb-conditions-and-terms/>.
 * #L%
 */


using System;
using Utils;
using Org.OpenAPITools.Model;

using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;

namespace Optimize
{
    /// <summary>
    /// High-level wrapper around the JOpt TourOptimizer REST API.
    /// Provides methods for synchronous optimization (via <see cref="OptimizationApi"/>)
    /// and asynchronous fire-and-forget job submission (via <see cref="JobApi"/>).
    /// </summary>
    public class TourOptimizerRestCaller
    {

        private static readonly HttpClient client = new HttpClient();

        private OptimizationApi geoOptimizerApi;

        private JobApi geoJobApi;

        /// <summary>
        /// ISO 8601 round-trip date/time format specifier.
        /// </summary>
        public const string ISO8601_DATETIME_FORMAT = "o";

        /// <summary>
        /// Initializes a new instance of <see cref="TourOptimizerRestCaller"/> and configures
        /// the underlying <see cref="OptimizationApi"/> and <see cref="JobApi"/> clients.
        /// </summary>
        /// <param name="tourOptimizerUrl">Base URL of the TourOptimizer server (e.g. <c>http://localhost:8081</c>).</param>
        /// <param name="azureApiKey">Optional Azure API Management subscription key.
        /// When provided, TLS 1.1/1.2 is enforced and the key is sent as <c>Ocp-Apim-Subscription-Key</c> header.</param>
        public TourOptimizerRestCaller(String tourOptimizerUrl, string azureApiKey = "")
        {

            // We need to give it more time, here everything need to be done in 100 minutes
            client.Timeout = TimeSpan.FromMinutes(100);

            this.geoOptimizerApi = new OptimizationApi(client, tourOptimizerUrl);

            ApiClient optApiClient = this.geoOptimizerApi.ApiClient;

            // Configure ApiClient
            configureApiClient(optApiClient);

            //
            this.geoJobApi = new JobApi(client, tourOptimizerUrl);

            ApiClient apiJobClient = this.geoJobApi.ApiClient;

            // Configure ApiClient
            configureApiClient(apiJobClient);

            if (!string.IsNullOrEmpty(azureApiKey))
            {
                // Constant 768 means TLS 1.1 security protocol, and constant value 3072 means TLS 1.2
                System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)(768 | 3072);

                client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", azureApiKey);
            }

        }

        /// <summary>
        /// Configures shared serializer settings on an <see cref="ApiClient"/>.
        /// Suppresses null-valued properties during JSON serialization.
        /// </summary>
        /// <param name="apiClient">The API client whose serializer settings will be modified.</param>
        public void configureApiClient(ApiClient apiClient)
        {

            // Newton JSON seems to have some issues handling Dictionaries in our case - Let's add some custom deserializer
            //apiClient.SerializerSettings.Converters.Add(new OptimizationOptionsJsonConverter());
            //apiClient.SerializerSettings.Converters.Add(new CoreBuildOptionsJsonConverter());

            // This will supress keys that have null values
            apiClient.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;

        }

        /// <summary>
        /// Serializes the given object to a JSON string using the configured serializer settings.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>A JSON string representation of <paramref name="obj"/>.</returns>
        public string asJson(object obj)
        {
            return JsonConvert.SerializeObject(obj, this.geoOptimizerApi.ApiClient.SerializerSettings);
        }

        /// <summary>
        /// Serializes the given object to JSON and writes it to a file.
        /// </summary>
        /// <param name="path">File path to write the JSON output to.</param>
        /// <param name="obj">The object to serialize.</param>
        public void toJsonFile(string path, object obj)
        {
            // serialize JSON to a string and then write string to a file

            System.IO.File.WriteAllText(path, asJson(obj));
        }


        /// <summary>
        /// Runs a synchronous optimization from raw elements and returns the full result
        /// including the optimized solution and input echo.
        /// Nodes and resources are wrapped into a <see cref="RestOptimization"/> with default settings.
        /// </summary>
        /// <param name="nodes">The nodes (jobs/visits) to be scheduled.</param>
        /// <param name="ress">The resources (vehicles/workers) available for scheduling.</param>
        /// <param name="connections">Pre-calculated element connections, or an empty list for automatic haversine distance calculation.</param>
        /// <param name="jsonLicense">JOpt license key as a JSON string. Falls back to the public evaluation key if empty.</param>
        /// <param name="properties">Optional optimization algorithm properties (e.g. iteration counts).</param>
        /// <returns>The full <see cref="RestOptimization"/> result containing the solution and all input data.</returns>
        public RestOptimization optimize(List<Node> nodes, List<Resource> ress,
            List<ElementConnection> connections, string jsonLicense, Dictionary<string, string>? properties = null)
        {

            if (String.IsNullOrEmpty(jsonLicense))
            {
                jsonLicense = TestRestOptimizationCreator.PUBLIC_JSON_LICENSE;
            }


            RestOptimization optimization = TestRestOptimizationCreator.defaultTouroptimizerTestInput(nodes, ress,
                jsonLicense, properties);

            optimization.ElementConnections = connections;

            // This will keep the example alive. Otherwise just subscribe
            return optimize(optimization);
        }


        /// <summary>
        /// Convenience overload that creates default nodes and resources from positions,
        /// then runs a synchronous optimization.
        /// </summary>
        /// <param name="nodePoss">Geographic positions for the nodes to visit.</param>
        /// <param name="ressPoss">Geographic positions for the resource starting locations.</param>
        /// <param name="connections">Pre-calculated element connections, or an empty list for automatic haversine distance calculation.</param>
        /// <param name="jsonLicense">JOpt license key as a JSON string. Falls back to the public evaluation key if empty.</param>
        /// <returns>The full <see cref="RestOptimization"/> result.</returns>
        public RestOptimization optimize(List<Position> nodePoss, List<Position> ressPoss,
            List<ElementConnection> connections, string jsonLicense)
        {

            if (String.IsNullOrEmpty(jsonLicense))
            {
                jsonLicense = TestRestOptimizationCreator.PUBLIC_JSON_LICENSE;
            }


            List<Node> nodes = new List<Node>();

            nodePoss.ForEach(delegate (Position curPos)
            {
                Node curNode = Utils.TestElementCreator.defaultGeoNode(curPos, curPos.LocationId);
                nodes.Add(curNode);
            });


            List<Resource> ress = new List<Resource>();

            ressPoss.ForEach(delegate (Position curPos)
            {
                Resource curRes = Utils.TestElementCreator.defaultCapacityResource(curPos, curPos.LocationId);
                ress.Add(curRes);
            });


            return optimize(nodes, ress, connections, jsonLicense);
        }


        /// <summary>
        /// Runs a synchronous optimization and returns only the <see cref="Solution"/> (without the full input echo).
        /// Subscribes to status and progress streams for console output while the optimization is running.
        /// </summary>
        /// <param name="nodePoss">Geographic positions for the nodes to visit.</param>
        /// <param name="ressPoss">Geographic positions for the resource starting locations.</param>
        /// <param name="connections">Pre-calculated element connections, or an empty list for automatic haversine distance calculation.</param>
        /// <param name="jsonLicense">JOpt license key as a JSON string. Falls back to the public evaluation key if empty.</param>
        /// <param name="properties">Optional optimization algorithm properties (e.g. iteration counts).</param>
        /// <returns>The <see cref="Solution"/> containing only the optimized routes and schedule.</returns>
        public Solution optimizeOnlyResult(List<Position> nodePoss, List<Position> ressPoss,
            List<ElementConnection> connections, String jsonLicense, Dictionary<string, string>? properties = null)
        {
            List<Node> nodes = new List<Node>();

            nodePoss.ForEach(delegate (Position curPos)
            {
                Node curNode = Utils.TestElementCreator.defaultGeoNode(curPos, curPos.LocationId);
                nodes.Add(curNode);
            });


            List<Resource> ress = new List<Resource>();

            ressPoss.ForEach(delegate (Position curPos)
            {
                Resource curRes = Utils.TestElementCreator.defaultCapacityResource(curPos, curPos.LocationId);
                ress.Add(curRes);
            });


            RestOptimization optimization = TestRestOptimizationCreator.defaultTouroptimizerTestInput(nodes, ress,
                jsonLicense, properties);

            optimization.ElementConnections = connections;

            // Start the optimization and get the runId
            System.Threading.Tasks.Task<RunAcceptedResponse> startTask = geoOptimizerApi.StartRunAsync(optimization);
            startTask.Wait();
            string runId = startTask.Result.RunId;

            // Let us attach to streams using the runId
            attachToStreams(runId);

            // Get the solution using the runId
            System.Threading.Tasks.Task<Solution> resultTask = geoOptimizerApi.GetRunSolutionAsync(runId);

            // This will keep the example alive. Otherwise just subscribe
            resultTask.Wait();
            return resultTask.Result;
        }


        /// <summary>
        /// Runs a synchronous optimization from a fully constructed <see cref="RestOptimization"/> input.
        /// Submits the run via <c>POST /api/v1/runs</c>, subscribes to SSE streams for progress/status,
        /// and blocks until the full result is available via <c>GET /api/v1/runs/{runId}/result</c>.
        /// </summary>
        /// <param name="optimization">The complete optimization input including nodes, resources, connections, and settings.</param>
        /// <returns>The full <see cref="RestOptimization"/> result.</returns>
        public RestOptimization optimize(RestOptimization optimization)
        {

            // Start the optimization and get the runId
            System.Threading.Tasks.Task<RunAcceptedResponse> startTask = this.geoOptimizerApi.StartRunAsync(optimization);
            startTask.Wait();
            string runId = startTask.Result.RunId;

            // Let us attach to streams using the runId
            attachToStreams(runId);

            // Get the full result using the runId
            System.Threading.Tasks.Task<RestOptimization> resultTask = this.geoOptimizerApi.GetRunResultAsync(runId);

            // This will keep the example alive.
            resultTask.Wait();

            return resultTask.Result;
        }


        //
        //
        //


        /// <summary>
        /// Submits an asynchronous fire-and-forget optimization job from positions.
        /// The job is persisted in the server's database and can be retrieved later using its jobId.
        /// </summary>
        /// <param name="nodePoss">Geographic positions for the nodes to visit.</param>
        /// <param name="ressPoss">Geographic positions for the resource starting locations.</param>
        /// <param name="connections">Pre-calculated element connections, or an empty list for automatic haversine distance calculation.</param>
        /// <param name="optiIdent">A user-defined identifier for this optimization run.</param>
        /// <param name="creatorSettings">Creator metadata to tag the persisted result (optionally hashed via <c>hash:</c> prefix).</param>
        /// <param name="persistenceSetting">Database persistence configuration (encryption, expiry, stream saving).</param>
        /// <param name="jsonLicense">JOpt license key as a JSON string. Falls back to the public evaluation key if empty.</param>
        /// <param name="tenantId">Tenant identifier for multi-tenant isolation (sent as <c>X-Tenant-Id</c> header).</param>
        /// <returns><c>true</c> if the job was accepted by the server.</returns>
        public Boolean optimizeFireAndForget(List<Position> nodePoss, List<Position> ressPoss,
            List<ElementConnection> connections, string optiIdent,
            CreatorSetting creatorSettings, OptimizationPersistenceSetting persistenceSetting,
            string jsonLicense, string tenantId = "DEFAULT_TENANT")
        {

            if (String.IsNullOrEmpty(jsonLicense))
            {
                jsonLicense = TestRestOptimizationCreator.PUBLIC_JSON_LICENSE;
            }


            List<Node> nodes = new List<Node>();

            nodePoss.ForEach(delegate (Position curPos)
            {
                Node curNode = Utils.TestElementCreator.defaultGeoNode(curPos, curPos.LocationId);
                nodes.Add(curNode);
            });


            List<Resource> ress = new List<Resource>();

            ressPoss.ForEach(delegate (Position curPos)
            {
                Resource curRes = Utils.TestElementCreator.defaultCapacityResource(curPos, curPos.LocationId);
                ress.Add(curRes);
            });


            return optimizeFireAndForget(nodes, ress, connections, optiIdent, creatorSettings, persistenceSetting, jsonLicense, tenantId);
        }


        /// <summary>
        /// Submits an asynchronous fire-and-forget optimization job from fully constructed nodes and resources.
        /// Configures the optimization with the given creator settings and persistence options before submission.
        /// </summary>
        /// <param name="nodes">The nodes (jobs/visits) to be scheduled.</param>
        /// <param name="ress">The resources (vehicles/workers) available for scheduling.</param>
        /// <param name="connections">Pre-calculated element connections, or an empty list for automatic haversine distance calculation.</param>
        /// <param name="optiIdent">A user-defined identifier for this optimization run.</param>
        /// <param name="creatorSettings">Creator metadata to tag the persisted result.</param>
        /// <param name="persistenceSetting">Database persistence configuration.</param>
        /// <param name="jsonLicense">JOpt license key as a JSON string. Falls back to the public evaluation key if empty.</param>
        /// <param name="tenantId">Tenant identifier for multi-tenant isolation.</param>
        /// <returns><c>true</c> if the job was accepted by the server.</returns>
        public Boolean optimizeFireAndForget(List<Node> nodes, List<Resource> ress,
            List<ElementConnection> connections, string optiIdent,
            CreatorSetting creatorSettings, OptimizationPersistenceSetting persistenceSetting,
            string jsonLicense, string tenantId = "DEFAULT_TENANT")
        {

            if (String.IsNullOrEmpty(jsonLicense))
            {
                jsonLicense = TestRestOptimizationCreator.PUBLIC_JSON_LICENSE;
            }


            RestOptimization optimization = TestRestOptimizationCreator.defaultTouroptimizerTestInput(nodes, ress,
                jsonLicense);

            optimization.ElementConnections = connections;


            // Modify defaults
            optimization.Ident = optiIdent;
            JSONConfig curExt = optimization.Extension;

            curExt.CreatorSetting = creatorSettings;

            curExt.PersistenceSetting = persistenceSetting;

            // This will keep the example alive. Otherwise just subscribe
            return optimizeFireAndForget(optimization, tenantId);
        }

        /// <summary>
        /// Submits a fully constructed <see cref="RestOptimization"/> as an asynchronous job
        /// via <c>POST /api/v1/jobs</c>.
        /// </summary>
        /// <param name="optimization">The complete optimization input.</param>
        /// <param name="tenantId">Tenant identifier for multi-tenant isolation.</param>
        /// <returns><c>true</c> if the server responded with <see cref="JobAcceptedResponse.StatusEnum.ACCEPTED"/>.</returns>
        public Boolean optimizeFireAndForget(RestOptimization optimization, string tenantId = "DEFAULT_TENANT")
        {

            // Trigger the Job creation
            System.Threading.Tasks.Task<JobAcceptedResponse> resultTask = this.geoJobApi.CreateJobAsync(tenantId, optimization);

            resultTask.Wait();

            return resultTask.Result.Status == JobAcceptedResponse.StatusEnum.ACCEPTED;

        }


        /// <summary>
        /// Searches for previously persisted optimization jobs matching the given criteria.
        /// Calls <c>POST /api/v1/jobs/search</c> via <see cref="JobApi.ListJobs"/>.
        /// </summary>
        /// <param name="searchItem">Search criteria (creator, ident, date range, limit, etc.).</param>
        /// <param name="tenantId">Tenant identifier for multi-tenant isolation.</param>
        /// <returns>A list of matching <see cref="DatabaseInfoSearchResult"/> metadata entries.</returns>
        public List<DatabaseInfoSearchResult> findOptimizationInfosInDatabase(DatabaseInfoSearch searchItem, string tenantId = "DEFAULT_TENANT")
        {
            List<DatabaseInfoSearchResult> result = this.geoJobApi.ListJobs(searchItem, tenantId);
            return result;
        }


        /// <summary>
        /// Retrieves a previously persisted optimization result by its job identifier.
        /// Calls <c>GET /api/v1/jobs/{jobId}/result</c> via <see cref="JobApi.GetJobResult"/>.
        /// </summary>
        /// <param name="jobId">The unique job identifier returned when the job was created.</param>
        /// <param name="tenantId">Tenant identifier for multi-tenant isolation.</param>
        /// <returns>The full <see cref="RestOptimization"/> result.</returns>
        public RestOptimization findOptimizationInDatabase(string jobId, string tenantId = "DEFAULT_TENANT")
        {

            RestOptimization result = this.geoJobApi.GetJobResult(jobId, tenantId);

            return result;
        }

        /// <summary>
        /// Subscribes to the server-sent event (SSE) streams for status and progress of a running optimization.
        /// Waits for the started signal from <c>GET /api/v1/runs/{runId}/started</c>, then opens
        /// background tasks that read and print the status and progress streams to the console.
        /// </summary>
        /// <param name="runId">The run identifier returned by <see cref="OptimizationApi.StartRunAsync"/>.</param>
        public void attachToStreams(string runId)
        {
            System.Threading.Tasks.Task<bool> startedTask = this.geoOptimizerApi.GetStartedSignalAsync(runId);

            startedTask.ContinueWith(task =>
            {

                if (task.Result)
                {
                    // The Server returned the start signal
                    Console.WriteLine("Optimization started");

                    System.Threading.Tasks.Task.Run(() =>
                    {
                        System.IO.Stream statusStream = createStream("/api/v1/runs/" + runId + "/stream/status", geoOptimizerApi.Configuration);
                        writeStream(statusStream);
                    });

                    System.Threading.Tasks.Task.Run(() =>
                    {
                        System.IO.Stream progressStream = createStream("/api/v1/runs/" + runId + "/stream/progress", geoOptimizerApi.Configuration);
                        writeStream(progressStream);
                    });


                }
                else
                {
                    Console.WriteLine("Optimization start FAILED");
                }

            });
        }



        /// <summary>
        /// Opens an HTTP GET stream to the given path on the configured server.
        /// Used internally to connect to SSE endpoints for real-time optimization monitoring.
        /// </summary>
        /// <param name="path">The relative API path (e.g. <c>/api/v1/runs/{runId}/stream/status</c>).</param>
        /// <param name="configuration">The API client configuration providing the base URL.</param>
        /// <returns>A readable <see cref="System.IO.Stream"/> of the server response body.</returns>
        public System.IO.Stream createStream(String path, Org.OpenAPITools.Client.IReadableConfiguration configuration)
        {

            System.Threading.Tasks.Task<System.IO.Stream> streamTask = client.GetStreamAsync(configuration.BasePath + path);

            return streamTask.Result;
        }

        /// <summary>
        /// Reads all lines from the given stream and writes them to the console.
        /// Blocks until the stream ends (i.e. the server closes the SSE connection).
        /// </summary>
        /// <param name="stream">The stream to read from (typically an SSE response body).</param>
        public void writeStream(System.IO.Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    Console.WriteLine(reader.ReadLine());
                }
            }
        }
    }
}
