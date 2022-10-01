using MyStoreTest.Framework.Models;

namespace MyStoreTest.Framework.Utils
{
    public static class ConfigDataProvider
    {
        private const string ConfigPath = "Resources/frameworkConfig.json";

        public static FrameworkConfig Config = JSONUtil.DeserializeFile<FrameworkConfig>(ConfigPath);
    }
}
