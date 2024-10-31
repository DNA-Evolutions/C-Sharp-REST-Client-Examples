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
    public class TourOptimizerZoneTravelExample
    {

        public static void Main(string[] args)
        {

            /*
             * 
             * Modify me
             * 
             */
            String myTourOptimizerKey = ""; // Empty key will fallback to TestRestOptimizationCreator.PUBLIC_JSON_LICENSE
            Boolean isSave2JSON = true;

            List<Position> nodePossManhattan = TestPositionsInput.defaultManhattanNodePositions();
            List<Position> nodePossNewJesrseyCity = TestPositionsInput.defaultNewJerseyCityNodePositions();

            List<Position> resourcePoss = TestPositionsInput.defaultNewYorkPositions();

            // We simply provide empty connections => This will trigger automatic haversine
            // distance calculations
            List<ElementConnection> emptyConnections = new List<ElementConnection>();

           /*
            * Logic
            *
            */

            TourOptimizerRestCaller tourOptimizerCaller = new TourOptimizerRestCaller(tourOptimizerUrl: Endpoints.LOCAL_SWAGGER_TOUROPTIMIZER_URL);
            

            List<Node> nodes = new List<Node>();

            nodePossManhattan.ForEach(delegate (Position curPos)
            {
                Node curNode = Utils.TestElementCreator.defaultGeoNodeWithZoneQualification(curPos, curPos.LocationId, 1);
                nodes.Add(curNode);
            });

            nodePossNewJesrseyCity.ForEach(delegate (Position curPos)
            {
                Node curNode = Utils.TestElementCreator.defaultGeoNodeWithZoneQualification(curPos, curPos.LocationId, 2);
                nodes.Add(curNode);
            });


            /*
            */
            List<Resource> ress = new List<Resource>();
            resourcePoss.ForEach(delegate (Position curPos)
            {
                Resource curRes = Utils.TestElementCreator.defaultCapacityResource(curPos, curPos.LocationId);
                ress.Add(curRes);
            });


            // Alternatively, the method tourOptimizerCaller.optimizeOnlyResult(...) will only return the Solution
            RestOptimization result = tourOptimizerCaller.optimize(nodes, ress, emptyConnections, myTourOptimizerKey, myOptimizationOptionsProperties());

            // Print result in JSON format
            System.Console.WriteLine(tourOptimizerCaller.asJson(result));

            /*
            * Save to JSON snapshot
            */
            if (isSave2JSON)
            {

                String jsonFile = "OptimizationZoneNewYorkExportTest.json";

                // Save result in JSON format in build folder
                tourOptimizerCaller.toJsonFile(jsonFile, result);

            }

        }

        
        public static Dictionary<string, string> myOptimizationOptionsProperties()
        {

            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                { "JOpt.Algorithm.PreOptimization.SA.NumIterations", "100000" },
                { "JOptExitCondition.JOptGenerationCount", "1000" },
                { "JOpt.Clustering.PenlalizeZoneCodeCrossingMultiplier", "10.0" },
                { "JOpt.Clustering.PenlalizeZoneCodeCrossing", "TRUE" }
            };

            return properties;

        }
    }
}
