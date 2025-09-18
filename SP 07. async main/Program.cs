// async
using System.Net;

WebClient client = new();
string url = @"https://turbo.az/";

//SomeVoidAsync(url);

//var task = SomeAsync(url);
//Console.WriteLine(task.Result);

var text = await SomeAsync(url);
Console.WriteLine(text);
Console.ReadLine();

async void SomeVoidAsync(string url)
{
    var text = await client.DownloadStringTaskAsync(url);
    Console.WriteLine(text);
}

async Task<string> SomeAsync(string url)
{
    return await client.DownloadStringTaskAsync(url);
    
}

