// Thread -> ThreadPool -> Task -> syntax sugar + love = async await

Console.WriteLine($"Main method start in thread: {Thread.CurrentThread.ManagedThreadId}"); // Main thread

//SomeMethod();
SomeMethodAsync();
Console.ReadLine();
Console.WriteLine($"Main method end in thread: {Thread.CurrentThread.ManagedThreadId}"); // Main thread

void SomeMethod()
{
    Console.WriteLine($"SomeMethod start in thread: {Thread.CurrentThread.ManagedThreadId}"); // Main thread
    var result = Task.Run<int>(() =>
    {
        Console.WriteLine($"SomeMethod task start in thread: {Thread.CurrentThread.ManagedThreadId}"); // any ThreadPool thread
        Thread.Sleep(1000);
        Console.WriteLine($"SomeMethod task end in thread: {Thread.CurrentThread.ManagedThreadId}"); //  same ThreadPool thread
        return 884;
    });
    Console.WriteLine($"SomeMethod end in thread: {Thread.CurrentThread.ManagedThreadId} result={result.Result}"); // Main thread

}

async void SomeMethodAsync()
{
    Console.WriteLine($"SomeMethodAsync start in thread: {Thread.CurrentThread.ManagedThreadId}"); // Main thread
    var result = await Task.Run<int>(() =>
    {
        Console.WriteLine($"SomeMethodAsync task start in thread: {Thread.CurrentThread.ManagedThreadId}"); // any ThreadPool thread
        Thread.Sleep(1000);
        Console.WriteLine($"SomeMethodAsync task end in thread: {Thread.CurrentThread.ManagedThreadId}"); // same ThreadPool thread
        return 884;
    });
    Console.WriteLine($"SomeMethodAsync end in thread: {Thread.CurrentThread.ManagedThreadId} result={result}"); //  same ThreadPool thread
}