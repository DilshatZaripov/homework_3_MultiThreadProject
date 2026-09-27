namespace homework_3_MultiThreadProject.SumStrategies
{
    internal class SequentialSum : ISumStrategy
    {
        public string Name => "1. Sequential Sum Strategy";

        public long Calculate(int[] array)
        {
            long result = 0L;

            for (int i = 0; i < array.Length; i++)
            {
                result += array[i];
            }

            return result;
        }
    }
}
