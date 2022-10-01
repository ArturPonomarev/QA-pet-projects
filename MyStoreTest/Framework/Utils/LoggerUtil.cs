using MyStoreTest.Framework.Logger;

namespace MyStoreTest.Framework.Utils
{
    public static class LoggerUtil
    {
        public static void LogTrace(string message)
        {
            NLogger.Instance.Trace(message);
        }

        public static void LogInfo(string message)
        {
            NLogger.Instance.Info(message);
        }

        public static void LogDebug(string message)
        {
            NLogger.Instance.Debug(message);
        }
    }
}
