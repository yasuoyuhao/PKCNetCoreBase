using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Helpers
{
    public static class RandomHelper
    {
        /// <summary>
        /// 產生亂數
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static int GenerateRandomNnumbers(int limit)
        {
            int seed = Guid.NewGuid().GetHashCode();
            Random random = new Random(seed);
            return random.Next(0, limit);
        }
    }
}
