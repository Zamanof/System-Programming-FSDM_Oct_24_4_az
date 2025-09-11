// ThreadPool VS Thread


using System.Diagnostics;

int operationCount = 1000;
var watch = new Stopwatch();
//watch.Start();
//usethread(operationcount);

watch.Stop();
Console.WriteLine($"{watch.ElapsedMilliseconds} milliseconds");

watch.Reset();

watch.Start();
//UseThreadPool(operationCount);

watch.Stop();
Console.WriteLine($"{watch.ElapsedMilliseconds} milliseconds");

void UseThread(int operationCount)
{
    List<int> threadsIds = new List<int>();
    using (var count = new CountdownEvent(operationCount))
    {
        Console.WriteLine("Threads...");
        for (int i = 0; i < operationCount; i++)
        {
            var thread = new Thread(() =>
            {
                Thread.Sleep(1);
                //Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}");
                if (!threadsIds.Contains(Thread.CurrentThread.ManagedThreadId))
                {
                    threadsIds.Add(Thread.CurrentThread.ManagedThreadId);
                }
                count.Signal();
            });
            thread.Start();
        }
        count.Wait();
    }
    Console.WriteLine($"Thread Used {threadsIds.Count} threads");

}

void UseThreadPool(int operationCount)
{
    List<int> threadsIds = new List<int>();
    using (var count = new CountdownEvent(operationCount))
    {
        Console.WriteLine("ThreadPool...");
        for (int i = 0; i < operationCount; i++)
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                Thread.Sleep(1);
                //Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}");
                if (!threadsIds.Contains(Thread.CurrentThread.ManagedThreadId))
                {
                    threadsIds.Add(Thread.CurrentThread.ManagedThreadId);
                }
                count.Signal();
            });
        }
            count.Wait();
    }
        Console.WriteLine($"ThreadPool Used {threadsIds.Count} threads");

}