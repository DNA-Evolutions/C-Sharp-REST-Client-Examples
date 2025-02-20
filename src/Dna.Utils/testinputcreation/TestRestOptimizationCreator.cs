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

namespace Utils
{
    public class TestRestOptimizationCreator
    {

        public const string PUBLIC_JSON_LICENSE = "{\r\n"
    	+ "  \"version\" : \"1.2\",\r\n"
    	+ "  \"identifier\" : \"PUBLIC-\",\r\n"
    	+ "  \"description\" : \"Key provided to for evaluation purpose from DNA evolutions GmbH.\",\r\n"
    	+ "  \"contact\" : \"www.dna-evolutions.com\",\r\n"
    	+ "  \"modules\" : [ {\r\n"
    	+ "    \"Module:\" : \"Elements\",\r\n"
    	+ "    \"max\" : 20\r\n"
    	+ "  }, {\r\n"
    	+ "    \"Module:\" : \"Date\",\r\n"
    	+ "    \"creation\" : \"2025-02-04\",\r\n"
    	+ "    \"due\" : \"2029-01-28\"\r\n"
    	+ "  } ],\r\n"
    	+ "  \"key\" : \"PUBLIC-e6dc49fcbda599f45638d39794fd4f99b062c2ae96864e37ef\"\r\n"
    	+ "}";

        public static RestOptimization defaultTouroptimizerTestInput(List<Node> nodes, List<Resource> ress,
                string jsonLicense, Dictionary<string, string>? properties = null)
        {

            if (String.IsNullOrEmpty(jsonLicense))
            {
                jsonLicense = TestRestOptimizationCreator.PUBLIC_JSON_LICENSE;
            }

            // Use defaultOptimizationOptionsProperties if properties is null
            properties ??= defaultOptimizationOptionsProperties();
            

            string ident = "StandardTouroptimizerTestInput";
            string timeOut = "PT2H";

            // Options
            OptimizationOptions optimizationOptions = new OptimizationOptions(properties: properties);
            OptimizationKeySetting keySetting = new OptimizationKeySetting(jsonLicense: jsonLicense);
            JSONConfig extension = new JSONConfig(keySetting: keySetting, timeOut: timeOut);

            List<NodeRelation> nodeRelations = new List<NodeRelation>();
            List<ElementConnection> elementConnections = new List<ElementConnection>();

            RestOptimization myOpti = new RestOptimization(ident: ident,
                nodes: nodes, resources:
                ress, nodeRelations: nodeRelations,
                elementConnections: elementConnections,
                optimizationOptions: optimizationOptions);

            myOpti.Extension = extension;

            return myOpti;
        }

        public static Dictionary<string, string> defaultOptimizationOptionsProperties()
        {

            /*
            * Old version
            */
            //OptimizationOptionsProperties optimizationOptionsProperties = new OptimizationOptionsProperties();
            //optimizationOptionsProperties.Add("JOpt.Algorithm.PreOptimization.SA.NumIterations", "100000");
            //optimizationOptionsProperties.Add("JOptExitCondition.JOptGenerationCount", "1000");

            //return optimizationOptionsProperties;

        
            /*
            * Update from Februrary 8th 2024
            */

            Dictionary<string, string> properties =  new Dictionary<string, string>();
            properties.Add("JOpt.Algorithm.PreOptimization.SA.NumIterations", "100000");
            properties.Add("JOptExitCondition.JOptGenerationCount", "1000");

            return properties;

        }

    }
}