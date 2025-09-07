namespace SP_02._Threads_in_UI_App;

public partial class Form1 : Form
{
    Thread thread = default;
    static int count = 0;
    public Form1()
    {
        InitializeComponent();       
    }

    private void counter(object? sender, EventArgs e)
    {
        countLabel.Text = count.ToString();
        count++;
    }


    private void startButton_Click(object sender, EventArgs e)
    {
        //thread = new Thread(() =>
        //{
        //    for (int i = 0; i < 100000; i++)
        //    {
        //        countLabel.Text = i.ToString();
        //        Thread.Sleep(1);
        //    }
        //});
        //thread.IsBackground = true;
        //thread.Start();
        timer1.Start();
    }
}
