#region Albahari tricks
// First Tricks
//for (int i = 0; i < 10; i++)
//{

//    new Thread(() =>
//    {
//        Console.WriteLine(i);
//    }).Start();    
//}

// Solve problem
//for (int i = 0; i < 10; i++)
//{
//    int x = i;
//    new Thread(() =>
//    {
//        Console.WriteLine(x);
//    }).Start();
//}

// Second trick
//string name = "Nadir";

//Thread thread1 = new(() =>
//{
//    Console.WriteLine(name);
//});

//name = "Zaman";

//Thread thread2 = new(() =>
//{
//    Console.WriteLine(name);
//});

//thread2.Start();
//thread1.Start();
#endregion

// Critical section - thread-lerin eyni bir bir yaddash sahesine(resursa) muraciet etmesi

#region Critical section problem
//Thread[] threads = new Thread[5];

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new Thread(() =>
//    {
//        for (int i = 0; i < 1000000; i++)
//        {
//            Counter.count++;
//        }
//    });
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Start();
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Join();
//}

//Console.WriteLine(Counter.count);
#endregion

#region Interlocked
//Thread[] threads = new Thread[5];

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new Thread(() =>
//    {
//        for (int i = 0; i < 1000000; i++)
//        {
//            Interlocked.Increment(ref Counter.count);
//        }
//    });
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Start();
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Join();
//}

//Console.WriteLine(Counter.count);
#endregion

#region Interlocked problem
//Thread[] threads = new Thread[5];

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new Thread(() =>
//    {
//        for (int i = 0; i < 1000000; i++)
//        {
//            Interlocked.Increment(ref Counter.count);

//            if (Counter.count % 2 == 0) Interlocked.Increment(ref Counter.even);
//        }
//    });
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Start();
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Join();
//}

//Console.WriteLine(Counter.count);
//Console.WriteLine(Counter.even);
#endregion

#region Monitor
//Thread[] threads = new Thread[5];
//object obj = new();


//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new Thread(() =>
//    {
//        for (int i = 0; i < 1000000; i++)
//        {            
//            Monitor.Enter(obj);
//            try
//            {
//                Counter.count++;
//                if (Counter.count % 2 == 0) Counter.even++;
//            }
//            finally
//            {

//                Monitor.Exit(obj);
//            }


//        }
//    });
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Start();
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Join();
//}

//Console.WriteLine(Counter.count);
//Console.WriteLine(Counter.even);
#endregion

#region lock
Thread[] threads = new Thread[5];
object obj = new();


for (int i = 0; i < threads.Length; i++)
{
    threads[i] = new Thread(() =>
    {
        for (int i = 0; i < 1000000; i++)
        {
            // lock - Monitor syntax sugar
            lock (obj)
            {
                Counter.count++;
                if (Counter.count % 2 == 0) Counter.even++;
            }
        }
    });
}

for (int i = 0; i < threads.Length; i++)
{
    threads[i].Start();
}

for (int i = 0; i < threads.Length; i++)
{
    threads[i].Join();
}

Console.WriteLine(Counter.count);
Console.WriteLine(Counter.even);
#endregion