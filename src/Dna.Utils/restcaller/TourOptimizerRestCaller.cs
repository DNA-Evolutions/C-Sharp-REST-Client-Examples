/*-
 * #%L
 * JOpt C# REST Client Examples
 * %%
 * Copyright (C) 2017 - 2022 DNA Evolutions GmbH
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
    public class TourOptimizerRestCaller
    {

        private static readonly HttpClient client = new HttpClient();

        private OptimizationServiceControllerApi geoOptimizerApi;

        public const string ISO8601_DATETIME_FORMAT = "o";

        public TourOptimizerRestCaller(String tourOptimizerUrl, string azureApiKey = "")
        {

            // We need to give it more time, here everything need to be done in 100 minutes
            client.Timeout = TimeSpan.FromMinutes(100);

            this.geoOptimizerApi = new OptimizationServiceControllerApi(client, tourOptimizerUrl);

            ApiClient apiClient = this.geoOptimizerApi.ApiClient;

            // Configure ApiClient
            configureApiClient(apiClient);

            if (!string.IsNullOrEmpty(azureApiKey))
            {
                // Constant 768 means TLS 1.1 security protocol, and constant value 3072 means TLS 1.2
                System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)(768 | 3072);

                client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", azureApiKey);
            }

        }

        public void configureApiClient(ApiClient apiClient)
        {

            // Newton JSON seems to have some issues handling Dictionaries in our case - Let's add some custom deserializer 
            apiClient.SerializerSettings.Converters.Add(new OptimizationOptionsJsonConverter());
            apiClient.SerializerSettings.Converters.Add(new CoreBuildOptionsJsonConverter());

            // This will supress keys that have null values
            apiClient.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;

        }

        public string asJson(object obj)
        {
            return JsonConvert.SerializeObject(obj, this.geoOptimizerApi.ApiClient.SerializerSettings);
        }

        public void toJsonFile(string path, object obj)
        {
            // serialize JSON to a string and then write string to a file

            System.IO.File.WriteAllText(path, asJson(obj));
        }


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


            RestOptimization optimization = TestRestOptimizationCreator.defaultTouroptimizerTestInput(nodes, ress,
                jsonLicense);

            optimization.ElementConnections = connections;

            // This will keep the example alive. Otherwise just subscribe
            return optimize(optimization);
        }

        public Solution optimizeOnlyResult(List<Position> nodePoss, List<Position> ressPoss,
            List<ElementConnection> connections, String jsonLicense)
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
                jsonLicense);

            //RestOptimization optimization = new RestOptimization();

            optimization.ElementConnections = connections;

            // Let us attach to streams - in c# this are done via using task
            attachToStreams();

            // Trigger the Optimization
            System.Threading.Tasks.Task<Solution> resultTask = geoOptimizerApi.RunOnlyResultAsync(optimization);

            // This will keep the example alive. Otherwise just subscribe
            resultTask.Wait();
            return resultTask.Result;
        }


        public RestOptimization optimize(RestOptimization optimization)
        {

            // Let us attach to streams - in c# this are done via using task
            attachToStreams();

            // Trigger the Optimization - It is also possible to use the synchronous "Run" method
            System.Threading.Tasks.Task<RestOptimization> resultTask = this.geoOptimizerApi.RunAsync(optimization);

            // This will keep the example alive.
            resultTask.Wait();

            return resultTask.Result;
        }

        public void attachToStreams()
        {
            System.Threading.Tasks.Task<bool> startedTask = this.geoOptimizerApi.RunStartedSginalAsync();

            startedTask.ContinueWith(task =>
            {

                if (task.Result)
                {
                    // The Server returned the start signal

                    Console.WriteLine("Optimization started");

                    System.Threading.Tasks.Task.Run(() =>
                    {
                        System.IO.Stream statusStream = createStream("/api/optimize/stream/status", geoOptimizerApi.Configuration);
                        writeStream(statusStream);
                    });

                    System.Threading.Tasks.Task.Run(() =>
                    {
                        System.IO.Stream statusStream = createStream("/api/optimize/stream/progress", geoOptimizerApi.Configuration);
                        writeStream(statusStream);
                    });


                }
                else
                {
                    Console.WriteLine("Optimization start FAILED");
                }

            });
        }



        public System.IO.Stream createStream(String path, Org.OpenAPITools.Client.IReadableConfiguration configuration)
        {

            System.Threading.Tasks.Task<System.IO.Stream> streamTask = client.GetStreamAsync(configuration.BasePath + path);

            return streamTask.Result;
        }

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