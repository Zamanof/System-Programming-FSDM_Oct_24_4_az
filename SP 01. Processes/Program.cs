using System.Diagnostics;

//Console.WriteLine(Process.GetCurrentProcess().Threads.Count);

//Process.Start("calc");
//Process.Start("mspaint");
//Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe");

//Console.WriteLine(Process.GetCurrentProcess().ProcessName);
//Console.WriteLine(Process.GetCurrentProcess().Id);
//Console.WriteLine(Process.GetCurrentProcess().BasePriority);

//var process = Process.GetProcessById(35556); 
// Process Id dinamik olaraq OS terefinden teyin ve her defe ferqli ola biler

//Console.ReadLine();

//Console.WriteLine(process.ProcessName);
//process.Kill();

//var processes = Process.GetProcesses();

//foreach (var proc in processes)
//{
//    Console.WriteLine($"{proc.Id}. {proc.ProcessName} Threads count: {proc.Threads.Count}");
//}

//var calculators = Process.GetProcessesByName("CalculatorApp");
//foreach (var proc in calculators)
//{
//    Console.WriteLine($"{proc.Id}. {proc.ProcessName} Threads count: {proc.Threads.Count}");
//    proc.Kill();
//}