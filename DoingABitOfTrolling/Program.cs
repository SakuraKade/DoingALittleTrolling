using DoingABitOfTrolling.Lib.Implementations;
using DoingABitOfTrolling.Lib.Interfaces;

namespace DoingABitOfTrolling
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                using CancellationTokenSource runAsyncCancellationTokenSource = new CancellationTokenSource();
                MainAsync(args, runAsyncCancellationTokenSource.Token);
                Application.Run();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.ToString(), "Critical", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Retry) Main(args); 
            }
        }

        static async Task MainAsync(string[] args, CancellationToken cancellationToken)
        {
            using IJokeEventPicker jokeEventPicker = new JokeEventPicker();
            // Add events here.

            while (true)
            {
                if (cancellationToken.IsCancellationRequested) break;

                try
                {
                    using CancellationTokenSource runnerCancellationTokenSource = new CancellationTokenSource();

                    IJokeEvent jokeEvent = jokeEventPicker.Get();
                    IJokeEventRunner runner = new JokeEventRunner();
                    using Task runningTask = runner.RunAsync(jokeEvent, runnerCancellationTokenSource.Token);
                    while (!runningTask.IsCompleted)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        await Task.Delay(1000);
                    }

                }
                catch (Exception ex)
                {
                    if (ex is OperationCanceledException) return;
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}