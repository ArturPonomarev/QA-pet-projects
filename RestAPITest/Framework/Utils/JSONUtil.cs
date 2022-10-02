using Newtonsoft.Json;
using System.IO;
using static RestAPITest.Framework.Utils.LoggerUtils;

namespace RestAPITest.Framework.Utils
{
    public static class JSONUtil
    {
        public static T DeserializeFile<T>(string path)
        {
            LogInfo($"Deserialize file: {path} to object: {typeof(T)}");
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }

        public static T DeserializeData<T>(string data)
        {
            LogInfo($"Deserialize data to object:{typeof(T)}");
            return JsonConvert.DeserializeObject<T>(data);
        }

        public static string Serialize<T>(T data)
        {
            LogInfo($"Serialize from:{typeof(T)}");
            return JsonConvert.SerializeObject(data);
        }
    }
}