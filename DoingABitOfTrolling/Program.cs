namespace DoingABitOfTrolling;

internal static class Program
{
    private static CancellationTokenSource applicationCancelationTokenSource = new CancellationTokenSource();

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        try
        {
            MainAsync(applicationCancelationTokenSource.Token);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            throw;
        }
        Application.Run();
        Task.Delay(-1).Wait();
    }


    static async void MainAsync(CancellationToken token)
    {
        try
        {
            Joker punisher = new Joker();
            await punisher.RunAsync(token).ConfigureAwait(true);
        }
        catch
        {
            throw;
        }
    }
}