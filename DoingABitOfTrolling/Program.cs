using Microsoft.Win32;

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
        SetCurrentDirToAppDirIfFound();

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

    static void SetCurrentDirToAppDirIfFound()
    {
        const string key = "Software\\SakuraKadeHansen\\DoingABitOfTrolling";
        const string pathValue = "Path";
        try
        {
            string? path = (string?)Registry.GetValue(key, pathValue, null);
            if (path == null) return;
            if (!Directory.Exists(path)) return;
            Directory.SetCurrentDirectory(path);
        }
        catch { }
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