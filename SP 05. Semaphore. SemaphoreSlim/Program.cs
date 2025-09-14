#region Semaphore internal

//Semaphore semaphore = new(3, 3);

//for (int i = 0; i < 10; i++)
//{
//    ThreadPool.QueueUserWorkItem(Some, semaphore);
//}
//Console.ReadKey();
//void Some(object? state)
//{
//    Random random = new Random();
//    var s = state as Semaphore;
//    bool st = false;
//    while (!st)
//    {
//        if (s.WaitOne(500))
//        {
//            try
//            {
//                Thread.Sleep(1);
//                Console.WriteLine($"mr. {Thread.CurrentThread.ManagedThreadId} take key");
//                Thread.Sleep(random.Next(1000, 3000));
//            }
//            finally
//            {
//                Thread.Sleep(1);
//                st = true;
//                Console.WriteLine($"mr. {Thread.CurrentThread.ManagedThreadId} return key");
//                s.Release();
//            }
//        }
//        else
//        {
//            Thread.Sleep(1);
//            Console.WriteLine($"mr. {Thread.CurrentThread.ManagedThreadId} sorry no key yet");

//        }
//    }
//}

#endregion

#region Semaphore external
//Semaphore semaphore = new(3, 3, "Sema");

//for (int i = 0; i < 30; i++)
//{
//    ThreadPool.QueueUserWorkItem(Some, semaphore);
//}
//Console.ReadKey();
//void Some(object? state)
//{
//    DateTime dateTime = DateTime.Now;
//    Random random = new Random();
//    var s = state as Semaphore;
//    bool st = false;
//    while (!st)
//    {
//        if (s.WaitOne(2000))
//        {
//            try
//            {
//                Thread.Sleep(3000);
//                Console.WriteLine($"mr. {Thread.CurrentThread.ManagedThreadId} take key; -> {dateTime.ToLongTimeString()}");
//                Thread.Sleep(random.Next(4000, 6000));
//            }
//            finally
//            {
//                Thread.Sleep(3000);
//                st = true;
//                Console.WriteLine($"mr. {Thread.CurrentThread.ManagedThreadId} return key; -> {dateTime.ToLongTimeString()}");
//                s.Release();
//            }
//        }
//        else
//        {
//            Thread.Sleep(3000);
//            Console.WriteLine($"mr. {Thread.CurrentThread.ManagedThreadId} sorry no key yet");

//        }
//    }
//}

#endregion

#region SemaphoreSlim

//SemaphoreSlim semaphore = new(3, 3);

//for (int i = 0; i < 10; i++)
//{
//    ThreadPool.QueueUserWorkItem(Some, semaphore);
//}
//Console.ReadKey();
//void Some(object? state)
//{
//    Random random = new Random();
//    var s = state as SemaphoreSlim;
//    bool st = false;
//    while (!st)
//    {
//        if (s.Wait(500))
//        {
//            try
//            {
//                Thread.Sleep(1);
//                Console.WriteLine($"mr. {Thread.CurrentThread.ManagedThreadId} take key");
//                Thread.Sleep(random.Next(1000, 3000));
//            }
//            finally
//            {
//                Thread.Sleep(1);
//                st = true;
//                Console.WriteLine($"mr. {Thread.CurrentThread.ManagedThreadId} return key");
//                s.Release();
//            }
//        }
//        else
//        {
//            Thread.Sleep(1);
//            Console.WriteLine($"mr. {Thread.CurrentThread.ManagedThreadId} sorry no key yet");

//        }
//    }
//}

#endregion
