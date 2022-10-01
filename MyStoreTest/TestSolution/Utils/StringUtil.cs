using System;
using System.Linq;
using static MyStoreTest.Framework.Utils.LoggerUtil;

namespace MyStoreTest.TestSolution.Utils
{
    public static class StringUtils
    {
        public static string GenerateRandomString(int length)
        {
            LogInfo($"Generate random string of length:{length}");
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
