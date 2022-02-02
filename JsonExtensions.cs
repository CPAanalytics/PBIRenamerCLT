using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PBIRenamerCLT
{
    
    public static class JsonExtensions
    {
        //https://stackoverflow.com/questions/19645501/searching-for-a-specific-jtoken-by-name-in-a-jobject-hierarchy
        public static List<JToken> FindTokens(this JToken containerToken, string name)
        {
            List<JToken> matches = new List<JToken>();
            FindTokens(containerToken, name, matches);
            return matches;
        }

        private static void FindTokens(JToken containerToken, string name, List<JToken> matches)
        {
            if (containerToken.Type == JTokenType.Object)
            {
                foreach (JProperty child in containerToken.Children<JProperty>())
                {
                    if (child.Name == name)
                    {
                        matches.Add(child.Value);
                    }
                    FindTokens(child.Value, name, matches);
                }
            }
            else if (containerToken.Type == JTokenType.Array)
            {
                foreach (JToken child in containerToken.Children())
                {
                    FindTokens(child, name, matches);
                }
            }
        }

        public static List<JToken> FindValues<T>(this JToken containerToken, T value)
        {
            List<JToken> matches = new List<JToken>();
            FindValues(containerToken, value, matches);
            return matches;
        }

        private static void FindValues<T>(JToken containerToken, T value, List<JToken> matches)
        {
            if (containerToken.Type == JTokenType.Object)
            {
                foreach (JProperty child in containerToken.Children<JProperty>())
                {

                    if (child.Value.GetType() == typeof(JValue))
                    {
                        var childvalue = child.Value.ToObject<T>();
                        if (value.Equals(childvalue))
                        {
                            matches.Add(child.Value);
                        }

                        continue;
                    }
                    
                    
                    
                    FindValues<T>(child.Value, value, matches);
                }
            }
            else if (containerToken.Type == JTokenType.Array)
            {
                foreach (JToken child in containerToken.Children())
                {
                    FindValues(child, value, matches);
                }
            }
        }
    }
}
