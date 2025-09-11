// ThreadPool

/*
CLR Thread Pool thread-lərini istifadə edir:

1. class ThreadPool
2. WinForm Timer
3. Asinxron metodlar (.BeginInvoke(), .EndInvoke()) - köhnəlmiş
4. TPL - Task Parallel Library
...

*/



//ThreadPool.GetAvailableThreads(out int workerCount, out int complCount);

//Console.WriteLine(workerCount);
//Console.WriteLine(complCount);


Console.WriteLine("Main method start...");

ThreadPool.QueueUserWorkItem(SomeOperations!, "Salam");
ThreadPool.QueueUserWorkItem(o => 
{ 
    OtherOperations(); 
});

Console.WriteLine($"Main method ThreadId {Thread.CurrentThread.ManagedThreadId}");
Console.WriteLine($"Main method IsBackground: {Thread.CurrentThread.IsBackground}");
Console.WriteLine($"Main method IsThreadPool: {Thread.CurrentThread.IsThreadPoolThread}");

Console.WriteLine("Main method end...");


void SomeOperations(object state)
{
    Console.WriteLine("\tSomeOperations method start...");
    Console.WriteLine($"\tSomeOperations method state value: {state}");
    Console.WriteLine($"\tSomeOperations method ThreadId {Thread.CurrentThread.ManagedThreadId}");
    Console.WriteLine($"\tSomeOperations method IsBackground: {Thread.CurrentThread.IsBackground}");
    Console.WriteLine($"\tSomeOperations method IsThreadPool: {Thread.CurrentThread.IsThreadPoolThread}");
    Console.WriteLine("\tSomeOperations method end...");
}

void OtherOperations()
{
    Console.WriteLine("\t\tOtherOperations method start...");
    Console.WriteLine($"\t\tOtherOperations method ThreadId {Thread.CurrentThread.ManagedThreadId}");
    Console.WriteLine($"\t\tOtherOperations method IsBackground: {Thread.CurrentThread.IsBackground}");
    Console.WriteLine($"\t\tOtherOperations method IsThreadPool: {Thread.CurrentThread.IsThreadPoolThread}");
    Console.WriteLine(" \t\tOtherOperations method end...");
}
