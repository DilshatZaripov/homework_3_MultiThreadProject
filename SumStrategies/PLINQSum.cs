namespace homework_3_MultiThreadProject.SumStrategies
{
    internal class PLINQSum : ISumStrategy
    {
        public string Name => "3. Parallel LINQ Sum Strategy";

        public long Calculate(int[] array)
        {
            return array.AsParallel().Sum(i => (long)i);
        }
    }
}
