using Newtonsoft.Json;
using System.IO;

namespace MyStoreTest.Framework.Utils
{
    public static class JSONUtil
    {
        public static T DeserializeFile<T>(string path)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }

        public static T DeserializeData<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        public static string Serialize<T>(T data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}
