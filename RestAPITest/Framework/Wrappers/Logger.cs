using NLog.Config;
using NLog;

namespace RestAPITest.Framework.Wrappers
{
    class Logger
    {
        private const string ConfigPath = "Resources/NLog.config";
        private static NLog.Logger _instance;
        private Logger()
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
