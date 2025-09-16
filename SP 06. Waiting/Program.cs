// Waiting

#region Single Wait
//var firstTask = new Task<int>(() => TaskMethod("FirstTask", 3));
//firstTask.Start();
//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//    Thread.Sleep(10);
//}
////Console.WriteLine(firstTask.Result);
//firstTask.Wait();
//Console.WriteLine("Main end");
#endregion


#region Wait all
//var firstTask = new Task<int>(() => TaskMethod("FirstTask", 3));
//var secondTask = new Task<int>(() => TaskMethod("SecondTask", 3));
//firstTask.Start();
//secondTask.Start();
//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//    Thread.Sleep(10);
//}

//Task.WaitAll(firstTask, secondTask);
//Console.WriteLine("Main end");
#endregion


#region Wait any
var firstTask = new Task<int>(() => TaskMethod("FirstTask", 3));
var secondTask = new Task<int>(() => TaskMethod("SecondTask", 1));
firstTask.Start();
secondTask.Start();
for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"Main thread - {i}");
    Thread.Sleep(10);
}

Task.WaitAny(firstTask, secondTask);
Console.WriteLine("Main end");
#endregion


int TaskMethod(string message, int second)
{
    Console.WriteLine($"Task - {message} start.");
    Console.WriteLine($@"
Id:             {Thread.CurrentThread.ManagedThreadId}
IsBackground:   {Thread.CurrentThread.IsBackground}
IsThreadPool:   {Thread.CurrentThread.IsThreadPoolThread}
");
    Thread.Sleep(TimeSpan.FromSeconds(second));
    Console.WriteLine($"Task - {message} end.");
    return second * 10;
}