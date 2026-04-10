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
    /// <summary>
    /// Example demonstrating how to retrieve a previously persisted optimization result
    /// from the database by its jobId and tenantId. The jobId must be a valid identifier
    /// obtained from a prior fire-and-forget job submission or a search operation.
    /// </summary>
    public class TourOptimizerLoadFAFExample
    {

        /// <summary>
        /// Entry point. Connects to the TourOptimizer server and retrieves a stored
        /// optimization result using a known jobId and tenantId.
        /// </summary>
        /// <param name="args">Command-line arguments (not used).</param>
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


            string jobId = "645cd34ef0a18c013811929c"; // Needs to be a valid id. Either save externally, or search it first
            string tenantId = "TEST_CREATOR";

            RestOptimization result = tourOptimizerCaller.findOptimizationInDatabase(jobId, tenantId);

            System.Console.WriteLine(tourOptimizerCaller.asJson(result));


        }
    }
}
