// Parallel, PLINQ, ...


using System.Collections.Concurrent;
using System.Diagnostics;

List<Student> students = new List<Student>();

for (int i = 0; i < 1000; i++)
{
    students.Add(new Student()
    {
        Id = i + 1,
        FirstName = Faker.NameFaker.FirstName(),
        LastName = Faker.NameFaker.LastName(),
        Age = Faker.NumberFaker.Number(18, 75),
        Mark = Faker.NumberFaker.Number(10, 120) / 10.0,
        Email = Faker.InternetFaker.Email()
    });
}
Console.WriteLine("Students add finished");

#region Task when, continue
//var task1 = Task.Run(() =>
//{
//    for (int i = 0; i < students.Count / 2; i++)
//    {
//        students[i].Group = "FSDM_Oct_24_4_az";
//        Thread.Sleep(10);
//    }
//});

//var task2 = Task.Run(() =>
//{
//    for (int i = students.Count / 2; i < students.Count; i++)
//    {
//        students[i].Group = "FSDA_Oct_24_5_az";
//        Thread.Sleep(10);
//    }
//});

//Task.WaitAll(task1, task2);
//await Task.WhenAll(task1, task2, WriteDataLog(), SendEmailNotification(), SendSmsNotification())
//    .ContinueWith(t =>
//    {
//        Console.WriteLine("Continue with Task");
//    });
//Console.WriteLine("End");


//students.ForEach(Console.WriteLine);


//Task WriteDataLog() => Task.Delay(500);
//Task SendEmailNotification() => Task.Delay(200);
//Task SendSmsNotification() => Task.Delay(700);

#endregion


#region Parallel
//Parallel.For(0, students.Count, new ParallelOptions { MaxDegreeOfParallelism = 6 },
//    i =>
//    {
//        students[i].Group = "FSDM_Oct_24_4_az";
//        //Console.WriteLine($"""
//        //    ThreadId:               {Thread.CurrentThread.ManagedThreadId}
//        //    IsBackground:           {Thread.CurrentThread.IsBackground}
//        //    IsThreadPoolThread:     {Thread.CurrentThread.IsThreadPoolThread}

//        //    """);
//    });

//Stopwatch stopwatch = new();
//stopwatch.Start();

//for (int i = 0; i < students.Count; i++)
//{
//    students[i].Group = "FSDM_Oct_24_4_az";
//    Thread.Sleep(1);
//}
//Console.WriteLine("Students group add for finished");
//var syncFor = stopwatch.ElapsedTicks;
//stopwatch.Restart();
//stopwatch.Start();
//Parallel.For(0, students.Count,
//    i =>
//    {
//        students[i].Group = "FSDM_Oct_24_5_az";
//        Thread.Sleep(1);
//    });
//Console.WriteLine("Students group add parallel for finished");
//var parallelFor = stopwatch.ElapsedTicks;
//stopwatch.Stop();

//Console.WriteLine($"Synchrony for ->    {syncFor}");
//Console.WriteLine($"Parallel  for ->    {parallelFor}");
//students.ForEach(Console.WriteLine);
//Console.ReadLine();
#endregion

#region PLINQ
Stopwatch stopwatch = new();
stopwatch.Start();

// Parallel.Foreach()
int parallelCount = 0;
object obj = new();
Parallel.ForEach(students,
    s =>
    {
        if (s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com"))
        {
            
        }
        //lock (obj)
        //{
        //    if (s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com"))
        //    {
        //        parallelCount++;
        //    }
        //}

    });
var parallelForEach = stopwatch.ElapsedTicks;

stopwatch.Restart();


// LINQ
int linqCount = students.Count(s => s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com"));

var linqTicks = stopwatch.ElapsedTicks;

stopwatch.Restart();


// PLINQ

var plinqCount = students.AsParallel().Count(s => s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com"));
var plinqTicks = stopwatch.ElapsedTicks;
stopwatch.Stop();


Console.WriteLine($"LINQ ->                 {linqTicks}         Count = {linqCount}");
Console.WriteLine($"Parallel  foreach ->    {parallelForEach}       Count = {parallelCount}");
Console.WriteLine($"PLINQ ->                {plinqTicks}        Count = {plinqCount}");
//students.ForEach(Console.WriteLine);
Console.ReadLine();



#endregion

#region PLINQ VS LINQ VS Parallel
//Stopwatch stopwatch = new();
//stopwatch.Start();
//ConcurrentBag<string> namesParallel = [];
//object obj = new();
//Parallel.ForEach(students, s =>
//{
//    if (s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com"))
//    {
//        namesParallel.Add($"{s.FirstName} {s.LastName}");
//        Thread.Sleep(1);

//    }
//});

//var parallelTicks = stopwatch.ElapsedTicks;
//stopwatch.Restart();

//List<string> namesLinq = students
//    .Where(s => {
//        Thread.Sleep(1);
//        return s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com"); })
//    .Select(s => $"{s.FirstName} {s.LastName}")
//    .ToList();

//var linqTicks = stopwatch.ElapsedTicks;
//stopwatch.Restart();

//List<string> namesPLinq = students
//    .AsParallel()
//    .Where(s => {
//        Thread.Sleep(1);
//        return s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com");
//    })
//    .Select(s => $"{s.FirstName} {s.LastName}")
//    .ToList();

//var plinqTicks = stopwatch.ElapsedTicks;
//stopwatch.Restart();

//stopwatch.Stop();

//Console.WriteLine($"LINQ: {linqTicks}");
//Console.WriteLine($"Parallel: {parallelTicks}");
//Console.WriteLine($"PLINQ: {plinqTicks}");

//Console.WriteLine();

//Console.WriteLine($"LINQ count: {namesLinq.Count}");
//Console.WriteLine($"Parallel count: {namesParallel.Count}");
//Console.WriteLine($"PLINQ count: {namesPLinq.Count}");


#endregion