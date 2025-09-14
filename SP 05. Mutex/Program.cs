// Mutex -> Mutual exclusion

#region Mutex -  internal thread
//Mutex mutex = new Mutex();

//int number = 1;

//for (int i = 0; i < 5; i++)
//{
//	Thread thread = new(Count);
//	thread.Name = $"Mister Thread {i + 1}";
//	thread.Start();
//}

//void Count()
//{
//	mutex.WaitOne();
//	for (int i = 0; i < 10; i++)
//	{
//		Console.WriteLine($"Thread: {Thread.CurrentThread.Name}: {number++}");
//	}
//	mutex.ReleaseMutex();
//}

#endregion


#region Mutex -  external (global) thread
//string mutexName = "Mex";
//using (Mutex mutex = new Mutex(true, mutexName))
//{
//    if (!mutex.WaitOne(30000))
//    {
//        Console.WriteLine("Other instance running ...");
//        Thread.Sleep(1000);
//        return;
//    }
//    else
//    {
//        Console.WriteLine("My code running");
//        Console.ReadKey();
//        mutex.ReleaseMutex();
//    }
//}
#endregion
