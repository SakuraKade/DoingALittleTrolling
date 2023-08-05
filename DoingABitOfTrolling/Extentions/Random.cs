using System;
using System.Linq;

namespace DoingABitOfTrolling.Extentions
{
    internal partial class Random : System.Random
    {
        public float NextFloat(float minValue, float maxValue)
        {
            float multiplier = (float)this.NextDouble();
            float result = multiplier * maxValue;
            result = Math.Max(result, minValue);
            return result;
        }
    }
}
