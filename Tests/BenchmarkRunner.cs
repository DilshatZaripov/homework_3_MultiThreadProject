using homework_3_MultiThreadProject.SumStrategies;
using System.Diagnostics;

namespace homework_3_MultiThreadProject.Tests
{
    internal static class BenchmarkRunner
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strategy"></param>
        /// <param name="array"></param>
        /// <param name="write"></param>
        /// <returns>Stopwatch.ElapsedMilliseconds</returns>
        public static long TestSumStrategy(ISumStrategy strategy, int[] array, Action<string> write)
        {
            write?.Invoke($"==========");
            write?.Invoke($"Testing strategy: \"{strategy.Name}\"...");
            write?.Invoke($"Array length: {array.Length}...");
            write?.Invoke($"Starting test...");

            var sw = Stopwatch.StartNew();
            var result = strategy.Calculate(array);
            sw.Stop();

            var timeSpend = sw.ElapsedMilliseconds;

            write?.Invoke($"Processed time: {timeSpend} ms. Calculated result: {result}");

            return timeSpend;
        }
    }
}
