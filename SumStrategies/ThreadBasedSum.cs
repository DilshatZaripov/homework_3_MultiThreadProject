using System.Collections.Concurrent;

namespace homework_3_MultiThreadProject.SumStrategies
{
    internal class ThreadBasedSum : ISumStrategy
    {
        private ConcurrentQueue<(int start, int length)> _chunks;

        public string Name => "2. Thread Based Sum Strategy";

        public long Calculate(int[] array)
        {
            _chunks = new ConcurrentQueue<(int start, int length)>();

            int chunkCnt = 64;
            int chunkSize = array.Length / chunkCnt;

            for (int i = 0; i < chunkCnt; i++)
            {
                int start = i * chunkSize;
                int length = (i == chunkCnt - 1)
                    ? (array.Length - start) 
                    : chunkSize;
                _chunks.Enqueue((start, length));
            }

            long[] partialSums = new long[chunkCnt];
            int processorCnt = Environment.ProcessorCount;
            var threads = new List<Thread>();
            int chunkIndex = 0;

            for (int i = 0; i < processorCnt; i++)
            {
                var thread = new Thread(() =>
                {
                    while (_chunks.TryDequeue(out var chunk))
                    {
                        long localSum = 0;
                        int partialSumIndex = Interlocked.Increment(ref chunkIndex) - 1;

                        for (int j = chunk.start; j < chunk.start + chunk.length; j++)
                        {
                            localSum += array[j];
                        }

                        partialSums[partialSumIndex] = localSum;
                    }
                });

                threads.Add(thread);
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            return partialSums.Sum();
        }
    }
}
