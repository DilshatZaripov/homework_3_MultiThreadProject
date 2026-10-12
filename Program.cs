using homework_3_MultiThreadProject.ArrayGenerators;
using homework_3_MultiThreadProject.SumStrategies;
using homework_3_MultiThreadProject.Tests;

var randGenerator = new RandomArrayGenerator();
var sequentialSum = new SequentialSum();
var threadsSum = new ThreadBasedSum();
var plinqSum = new PLINQSum();

Thread warmUpThread = new Thread(() => Console.WriteLine("This is warm up thread"));
warmUpThread.Start();
warmUpThread.Join();

await Task.Run(() => Console.WriteLine("Warm-up #2"));

Console.ForegroundColor = ConsoleColor.Green;
var testArray1 = randGenerator.Generate(100_000);
BenchmarkRunner.TestSumStrategy(sequentialSum, testArray1, Console.WriteLine);
BenchmarkRunner.TestSumStrategy(threadsSum, testArray1, Console.WriteLine);
BenchmarkRunner.TestSumStrategy(plinqSum, testArray1, Console.WriteLine);


Console.ForegroundColor = ConsoleColor.Yellow;
var testArray2 = randGenerator.Generate(1_000_000);
BenchmarkRunner.TestSumStrategy(sequentialSum, testArray2, Console.WriteLine);
BenchmarkRunner.TestSumStrategy(threadsSum, testArray2, Console.WriteLine);
BenchmarkRunner.TestSumStrategy(plinqSum, testArray2, Console.WriteLine);


Console.ForegroundColor = ConsoleColor.Red;
var testArray3 = randGenerator.Generate(10_000_000);
BenchmarkRunner.TestSumStrategy(sequentialSum, testArray3, Console.WriteLine);
BenchmarkRunner.TestSumStrategy(threadsSum, testArray3, Console.WriteLine);
BenchmarkRunner.TestSumStrategy(plinqSum, testArray3, Console.WriteLine);

//Console.WriteLine("N\t| Seq\t| Threads\t| PLINQ");
//for (int i = 0; i < 25; i++)
//{
//    Console.Write($"{i + 1}\t| ");
//    var testArray = randGenerator.Generate(10_000_000);
//    Console.Write($"{BenchmarkRunner.TestSumStrategy(sequentialSum, testArray, null)}\t| ");
//    Console.Write($"{BenchmarkRunner.TestSumStrategy(threadsSum, testArray, null)}\t| ");
//    Console.Write($"{BenchmarkRunner.TestSumStrategy(plinqSum, testArray, null)}\t|\n");
//}

Console.ForegroundColor = ConsoleColor.White;