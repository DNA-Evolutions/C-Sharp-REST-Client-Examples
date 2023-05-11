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
    public class TourOptimizerFAFExample
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



            /*
            * A special feature is the magic use of "hash:" as prefix to the creator. The
            * creator string will not saved, instead only the hash of the creator will be
            * saved using SHA-256.
            * 
            * This can be used, for example, in a subscription system. A user is identified
            * by a unique subscription key. For security reasons, the key, is not saved
            * inside a snapshot, instead the hash value is used allowing identification of
            * the original user without revealing the key.
            */

            string rawCreator = "TEST_CREATOR";

            Boolean doHashCreatorName = false;

            if (doHashCreatorName) {
                rawCreator = "hash:" + rawCreator;
            }

            CreatorSetting creatorSettings = new CreatorSetting();

            creatorSettings.Creator = rawCreator;
            String myOptiIdent = "MY_OPTIMIZATION_C#";

            Boolean wasStarted = tourOptimizerCaller.optimizeFireAndForget(nodePoss, resourcePoss, emptyConnections,
                    myOptiIdent, creatorSettings, createPersistenceSetting(), myTourOptimizerKey);

            System.Console.WriteLine(wasStarted);

        }



        public static OptimizationPersistenceSetting createPersistenceSetting()
        {

            /*
            * The general object wrapping the database persistence settings
            */
            OptimizationPersistenceSetting persistenceSetting = new OptimizationPersistenceSetting();


            /*
             * Saving the element connections etc.
             */
            OptimizationPersistenceStratgySetting optimizationPersistenceStratgySetting = new OptimizationPersistenceStratgySetting();


            // Element connections usually make up most of the data size, therefore, when
            // targeting to not further process the result, it might be a good idea
            // to skip the connections saving to reduce space
            optimizationPersistenceStratgySetting.SaveConnections = false;

            // // Do we want to only save the result object?
            optimizationPersistenceStratgySetting.SaveOnlyResult = false;


           /*
            * How to treat streams? For example, do we want to continuously write the
            * current progress into a database? Do we want to cycle the progress?
            */
            StreamPersistenceStratgySetting streamPersistenceStratgySetting = new StreamPersistenceStratgySetting();
            streamPersistenceStratgySetting.SaveProgress = true;
            streamPersistenceStratgySetting.CycleProgress = true;
            streamPersistenceStratgySetting.SaveStatus = true;
            streamPersistenceStratgySetting.CycleStatus = true;
            streamPersistenceStratgySetting.SaveWarning = true;
            // streamPersistenceStratgySetting.saveError(true);

            /*
             * Settings regarding encryption etc.
             */


            // A secret encrypting the content of the final snapshot/result. If empty, no encryption is used.
            // Important: Metadata and stream information like progress is always saved as decrypted clear text.
            // Attention: The secret is not saved by DNA evolutions. If you loose the secret, the file CAN NOT be restored.
            MongoOptimizationPersistenceSetting mongoSettings = new MongoOptimizationPersistenceSetting(secret: "",
               streamPersistenceStratgySetting: streamPersistenceStratgySetting,
               optimizationPersistenceStratgySetting: optimizationPersistenceStratgySetting);

            // Do we want to save anything to the database?
            mongoSettings.EnablePersistence = true;


            // Once saved, the snapshot/result will be deleted automatically after this time
            mongoSettings.Expiry = "PT48H";

            /*
             * Wrap
             */
            persistenceSetting.MongoSettings = mongoSettings;

            return persistenceSetting;
        }
    }
}
