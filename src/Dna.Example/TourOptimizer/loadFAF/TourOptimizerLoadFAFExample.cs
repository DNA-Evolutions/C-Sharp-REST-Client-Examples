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
using System.Collections.Generic;

namespace Optimize
{
    public class TourOptimizerLoadFAFExample
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


            DatabaseItemSearch searchItem = new DatabaseItemSearch();
            searchItem.Creator = "TEST_CREATOR";
            searchItem.Id = "645cd34ef0a18c013811929c"; // Needs to be a valid id. Either save externally, or search it first
            searchItem.TimeOut = "PT1M";

            RestOptimization result = tourOptimizerCaller.findOptimizationInDatabase(searchItem);

            System.Console.WriteLine(tourOptimizerCaller.asJson(result));
            

        }
    }
}
