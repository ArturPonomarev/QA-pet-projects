using NLog;
using NLog.Config;

namespace MyStoreTest.Framework.Logger
{
    class NLogger
    {
        private const string ConfigPath = "Framework/Logger/NLog.config";
        private static NLog.Logger _instance;
        private NLogger()
        { 
        }

        public static NLog.Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    LoadConfig();
                    _instance = LogManager.GetCurrentClassLogger();
                }
                return _instance;
            }
        }

        private static void LoadConfig()
        {
            LogManager.Configuration = new XmlLoggingConfiguration(ConfigPath);
        }
    }
}
