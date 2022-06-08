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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Linq;

namespace Utils
{
    public class OptimizationOptionsJsonConverter : JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(OptimizationOptions));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null!;
            }

            JObject jo = JObject.Load(reader);


            // This contains the keys and values
            JObject? jprops = jo["properties"] as JObject;

            if (jprops == null)
            {
                return null!;
            }

            Dictionary<String, String>? dict = jprops.ToObject<Dictionary<String, String>>();

            OptimizationOptionsProperties optimizationOptionsProperties = new OptimizationOptionsProperties();

            if (!(dict is null))
            {
                foreach (KeyValuePair<string, string> entry in dict)
                {
                    optimizationOptionsProperties.Add(entry.Key, entry.Value);
                }
            }


            // Options
            OptimizationOptions optimizationOptions = new OptimizationOptions(properties: optimizationOptionsProperties);

            return optimizationOptions;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

    }
}