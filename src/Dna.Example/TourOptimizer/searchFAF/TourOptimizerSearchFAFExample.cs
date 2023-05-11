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
    public class TourOptimizerSearchFAFExample
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


            /*
            * 
            * Not all fields are mandatory. The ident IS NOT equal to the id. The ident is
            * a user defined String to identify the optimization (it does NOT need to be
            * unique). The id is a unique string automatically generated by the database.
            * 
            * JSON-Example: { 
            * 	"creator": "DEFAULT_DNA_CREATOR",
            *  	"ident": "My-JOpt-Run",
            * 	"limit": 10, "sortDirection": "DESC", 
            * 	"createdDateStart": "2023-05-10T09:11:38.445Z",
            *  	"createdDateEnd": "2023-05-10T09:11:38.445Z",
            * 	"timeOut": "PT1M" 
            * }
            */

            DatabaseInfoSearch searchItem = new DatabaseInfoSearch();
            searchItem.Creator = "TEST_CREATOR";

            List<DatabaseInfoSearchResult> result = tourOptimizerCaller.findOptimizationInfosInDatabase(searchItem);

            System.Console.WriteLine(tourOptimizerCaller.asJson(result));

        }
    }
}