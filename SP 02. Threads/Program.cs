// Threads
//Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
//Console.WriteLine(Thread.CurrentThread.IsBackground);

Thread thread1 = new Thread(() =>
{
    int summ = 0;
	for (int i = 0; i < 10; i++)
	{
        //summ += i;
        Console.WriteLine($"\tMy own thread: Id{Thread.CurrentThread.ManagedThreadId} - {i} - IsBackground: {Thread.CurrentThread.IsBackground}");
    }
    //Console.WriteLine($"My result: {summ}");
});

Thread thread2 = new(Some);

//thread1.IsBackground = true;
//thread1.Priority = ThreadPriority.Highest;
//thread2.Priority = ThreadPriority.Lowest;

thread1.Start();
thread2.Start();
int summ = 0;
Console.WriteLine("Salam");
thread1.Join(); // Chaqiran thread-in chaqirilan thread-i gozlemesi
for (int i = 0; i < 100; i++)
{
    summ += i;
    Console.WriteLine($"Main thread: Id{Thread.CurrentThread.ManagedThreadId} - {i} - IsBackground: {Thread.CurrentThread.IsBackground}");
}
//thread1.Interrupt(); // Thread-in ishini bitirmek
//Console.WriteLine($"Main result: {summ}");
//Console.ReadLine();


//ConsoleKeyInfo key = default;
//while (true)
//{
//    key = Console.ReadKey();
//    if (key.Key == ConsoleKey.Enter)
//    {
//        thread1.Interrupt();
//        break;
//    }
//}
Console.WriteLine("End");
void Some()
{
    int summ = 0;
    for (int i = 0; i < 100; i++)
    {
        summ += i;
        Console.WriteLine($"\t\tSome method thread: Id{Thread.CurrentThread.ManagedThreadId} - {i} - IsBackground: {Thread.CurrentThread.IsBackground}");
    }
    //Console.WriteLine($"Some result: {summ}"); 
}