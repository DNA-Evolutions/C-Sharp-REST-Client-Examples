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
using System.Collections.Generic;

namespace Optimize
{
    public class TourOptimizerConstraintExample
    {

        public static void Main(string[] args)
        {

            /*
             * 
             * Modify me
             * 
             */
            Boolean isAzureCall = !true; // Make sure you have a local docker container running at Endpoints.LOCAL_SWAGGER_TOUROPTIMIZER_URL

            String myAzureApiKey = ""; // Empty key will be ignored
            String myTourOptimizerKey = ""; // Empty key will fallback to TestRestOptimizationCreator.PUBLIC_JSON_LICENSE
            Boolean isSave2JSON = true;

            List<Position> nodePoss = TestPositionsInput.defaultSydneyNodePositions();
            List<Position> resourcePoss = TestPositionsInput.defaultSydneyResourcePositions();

            // We simply provide empty connections => This will trigger automatic haversine
            // distance calculations
            List<ElementConnection> emptyConnections = new List<ElementConnection>();

           /*
            * Logic
            *
            */

            TourOptimizerRestCaller tourOptimizerCaller;

            if (isAzureCall)
            {

                tourOptimizerCaller = new TourOptimizerRestCaller(tourOptimizerUrl: Endpoints.AZURE_SWAGGER_TOUROPTIMIZER_URL,
                    azureApiKey: myAzureApiKey);
            }
            else
            {
                tourOptimizerCaller = new TourOptimizerRestCaller(tourOptimizerUrl: Endpoints.LOCAL_SWAGGER_TOUROPTIMIZER_URL);
            }


            // Define nodes and resources from the positions - The node have the type Constraint "UnreachableQuali" but the resources can only provide "Quali"
            // therefore, the result will contain violations
            List<Node> nodes = new List<Node>();
            nodePoss.ForEach(delegate (Position curPos)
            {
                Node curNode = Utils.TestElementCreator.defaultGeoNodeWithTypeConstraint(curPos, curPos.LocationId,"UnreachableQuali");
                nodes.Add(curNode);
            });


            List<Resource> ress = new List<Resource>();
            resourcePoss.ForEach(delegate (Position curPos)
            {
                Resource curRes = Utils.TestElementCreator.defaultCapacityResourceWithQulaificationConstraint(curPos, curPos.LocationId,"Quali");
                ress.Add(curRes);
            });


            // Alternatively, the method tourOptimizerCaller.optimizeOnlyResult(...) will only return the Solution
            RestOptimization result = tourOptimizerCaller.optimize(nodes, ress, emptyConnections, myTourOptimizerKey);

            // Print result in JSON format
            System.Console.WriteLine(tourOptimizerCaller.asJson(result));

            /*
            * Save to JSON snapshot
            */
            if (isSave2JSON)
            {

                String jsonFile = "OptimizationExportTest.json";

                // Save result in JSON format in build folder
                tourOptimizerCaller.toJsonFile(jsonFile, result);

            }

        }
    }
}
