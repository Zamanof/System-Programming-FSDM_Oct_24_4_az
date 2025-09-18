using System.Net;
using System.Windows;

namespace SP_07._async_love;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    WebClient client = new();
    string url = @"https://turbo.az/";
    public MainWindow()
    {
        InitializeComponent();
    }

    private void SimpleDownload(object sender, RoutedEventArgs e)
    {
        var text = client.DownloadString(url);
        Thread.Sleep(1000);
        contentText.Text = text;
    }
    private void DontClick(object sender, RoutedEventArgs e)
    {
        var task = client.DownloadStringTaskAsync(url);
        contentText.Text = task.Result;
    }
    private void TaskDownload(object sender, RoutedEventArgs e)
    {
        var task = client.DownloadStringTaskAsync(url)
            .ContinueWith(t =>
            {
                Thread.Sleep(1000);
                contentText.Text = t.Result;
            }, TaskScheduler.FromCurrentSynchronizationContext());
    }
    private void TaskContextDownload(object sender, RoutedEventArgs e)
    {
        var context = SynchronizationContext.Current;
        var task = client.DownloadStringTaskAsync(url)
            .ContinueWith(t =>
            {
                Thread.Sleep(1000);
                context.Send(_ =>
                {
                    contentText.Text = t.Result;
                }, null);
            });
    }
    private async void DownloadAsync(object sender, RoutedEventArgs e) {
        var text = await client.DownloadStringTaskAsync(url);
        contentText.Text = text;
    }
    private void Clear(object sender, RoutedEventArgs e)
    {
        contentText.Clear();
    }
}