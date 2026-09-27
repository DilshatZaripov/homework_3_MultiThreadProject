namespace homework_3_MultiThreadProject.SumStrategies
{
    internal interface ISumStrategy
    {
        string Name { get; }

        long Calculate(int[] array);
    }
}
