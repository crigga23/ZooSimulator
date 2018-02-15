using System;

namespace ZooSimulator.Models
{
    public class RandomNumberGenerator
    {
        private static readonly Random random = new Random();

        public static double GetNumberInRange(int minValue, int maxValue)
        {
            var next = random.NextDouble();
            return minValue + (next * (maxValue - minValue));
        }
    }
}
