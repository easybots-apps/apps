using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easybots.Apps;
using Newtonsoft.Json.Linq;

namespace JsonUtilities
{
    public class JsonBot : Easybot
    {
        public JsonBot() : base("JSON Bot")
        {
        }

        [Action("Returns the JSON object specified by the JSON Path. If the JSON Path is not matched, null will be returned.")]
        [return: ParameterDescription("jsonObject", "The JSON object that matches the JSON Path.", typeof(string))]
        public string SelectObject(
            [ParameterDescription("json", "JSON as string.", typeof(string), AllowUserInput = true, Order = 0)]
            [ParameterDescription("jsonPathQuery", "The JSON Path expression. Example: '$.type, 'Manufacturers[1].Products[0].Name', ...'", typeof(string), AllowUserInput = true, Order = 1)]
            string[] inputs)
        {
            string json = inputs[0];
            string jsonPathQuery = inputs[1];
            if (string.IsNullOrWhiteSpace(json) || string.IsNullOrWhiteSpace(jsonPathQuery))
                throw new ArgumentException("The JSON and the JSON Path can't be empty or white space.");

            return SelectObjectByJPath(json, jsonPathQuery);
        }

        [Action("Returns an array of all JSON objects that match the specified JSON Path. If there are no objects that match the specified JSON Path, an empty array will be returned.")]
        [return: ParameterDescription("jsonObjectsCollection", "Collection of objects that match the JSON Path Query", typeof(string[]), Order = 0)]
        [return: ParameterDescription("count", "The number of objects in the collection.", typeof(int), Order = 1)]
        public object[] SelectObjects(
            [ParameterDescription("json", "JSON as string.", typeof(string), AllowUserInput = true, Order = 0)]
            [ParameterDescription("jsonPathQuery", "The JSON Path expression. Example: '$.type, 'Manufacturers[1].Products[0].Name', ...'", typeof(string), AllowUserInput = true, Order = 1)]
            string[] inputs)
        {
            string json = inputs[0];
            string jsonPathQuery = inputs[1];
            if (string.IsNullOrWhiteSpace(json) || string.IsNullOrWhiteSpace(jsonPathQuery))
                throw new ArgumentException("The JSON and the JSON Path can't be empty or white space.");

            string[] collection = SelectAllObjectsByJPath(json, jsonPathQuery);
            int count = collection.Count();
            object[] result = new object[] { collection, count };
            return result;
        }

        [Action("Returns an array of the children of a JSON object, specified by the JSON Path. If there is no object that match the specified JSON Path, an empty array will be returned.")]
        [return: ParameterDescription("children", "An array of the children of the specified JSON object.", typeof(string[]), Order = 0)]
        [return: ParameterDescription("count", "The number of objects in the collection.", typeof(int), Order = 1)]
        public object[] GetChildrenByJsonPath(
            [ParameterDescription("json", "JSON as string.", typeof(string), AllowUserInput = true, Order = 0)]
            [ParameterDescription("jsonPathQuery", "The JSON Path expression. Example: '$.type, 'Manufacturers[1].Products[0].Name', ...'", typeof(string), AllowUserInput = true, Order = 1)]
            string[] inputs)
        {
            string json = inputs[0];
            string jsonPathQuery = inputs[1];
            if (string.IsNullOrWhiteSpace(json) || string.IsNullOrWhiteSpace(jsonPathQuery))
                throw new ArgumentException("The JSON and the JSON Path can't be empty or white space.");
            string[] collection = GetAllChildrenByJPath(json, jsonPathQuery);
            int count = collection.Count();
            object[] result = new object[] { collection, count };
            return result;
        }

        public static string[] GetAllChildrenByJPath(string json, string jsonPathQuery)
        {
            if (string.IsNullOrWhiteSpace(json) || string.IsNullOrWhiteSpace(jsonPathQuery))
                throw new ArgumentException("The JSON and the JSON Path can't be empty or white space.");

            string[] collection = null;
            JObject jObject = JObject.Parse(json);
            try
            {
                collection = jObject.SelectToken(jsonPathQuery).Children().Select(child => child.ToString()).ToArray();
            }
            catch (NullReferenceException)
            {
                return new string[] { };
            }

            return collection;
        }

        public static string[] SelectAllObjectsByJPath(string json, string jsonPathQuery)
        {
            if (string.IsNullOrWhiteSpace(json) || string.IsNullOrWhiteSpace(jsonPathQuery))
                throw new ArgumentException("The JSON and the JSON Path can't be empty or white space.");

            JObject jObject = JObject.Parse(json);
            string[] result = jObject.SelectTokens(jsonPathQuery).Select(token => token.ToString()).ToArray();
            return result;
        }

        public static string SelectObjectByJPath(string json, string jsonPathQuery)
        {
            if (string.IsNullOrWhiteSpace(json) || string.IsNullOrWhiteSpace(jsonPathQuery))
                throw new ArgumentException("The JSON and the JSON Path can't be empty or white space.");

            JObject jObject = JObject.Parse(json);
            JToken result = jObject.SelectToken(jsonPathQuery);
            if (result == null)
                return null;

            return result.ToString();
        }
    }
}
