using Newtonsoft.Json;

namespace CPMobile.Helper
{
    public static class JsonHelper
    {
        /// <summary>The generic deserialize.</summary>
        /// <param name="jsonValue">The JSON String.</param>
        /// <typeparam name="T">Class for JSON deserialization</typeparam>
        /// <returns>The deserialized T object</returns>
        public static T Deserialize<T>(string jsonValue)
        {
            // todo: spanchal - write a unit test for this helper method
            return JsonConvert.DeserializeObject<T>(jsonValue);
        }
    }
}
