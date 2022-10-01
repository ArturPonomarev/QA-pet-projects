using AngleSharp.Html;
using System;

namespace MyStoreTest.TestSolution.Utils
{
    public static class NumberUtils
    {
        private static Random _rand = new Random();
        public static int CreateRandomNumber(int min, int max)
        {  
            return _rand.Next(min, max);
        }
    }
}
