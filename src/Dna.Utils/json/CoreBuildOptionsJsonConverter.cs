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
    public class CoreBuildOptionsJsonConverter : JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(CoreBuildOptions));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {

            if (reader.TokenType == JsonToken.Null || existingValue == null)
            {
                return null!;
            }

            JObject? jo = JObject.Load(reader);

            // This contains the keys and values
            JObject? jprops = jo["buildCoreProperties"] as JObject;

            if (jprops == null)
            {
                return null!;
            }

            Dictionary<String, String>? dict = jprops.ToObject<Dictionary<String, String>>();

            CoreBuildOptionsBuildCoreProperties coreBuildOptionsCoreProperties = new CoreBuildOptionsBuildCoreProperties();

            if (!(dict is null))
            {
                foreach (KeyValuePair<string, string> entry in dict)
                {
                    coreBuildOptionsCoreProperties.Add(entry.Key, entry.Value);

                }
            }

            // Options
            CoreBuildOptions coreBuildOptions = new CoreBuildOptions(buildCoreProperties: coreBuildOptionsCoreProperties);

            return coreBuildOptions;
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