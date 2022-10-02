using System.Linq;
using System;
using static RestAPITest.Framework.Utils.LoggerUtils;

namespace RestAPITest.Framework.Utils
{
    public static class StringUtil
    {
        public static string GetRandomString(int length)
        {
            LogInfo($"Generate random string with length: {length}");

            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
