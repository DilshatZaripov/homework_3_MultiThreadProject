namespace homework_3_MultiThreadProject.ArrayGenerators
{
    internal class RandomArrayGenerator : IArrayGenerator
    {
        public int[] Generate(int arraySize)
        {
            var result = new int[arraySize];

            var random = new Random();

            for (int i = 0; i < arraySize; i++)
            {
                result[i] = random.Next(int.MaxValue);
            }

            return result;
        }
    }
}
