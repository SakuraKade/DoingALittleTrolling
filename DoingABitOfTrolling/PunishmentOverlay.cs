using DoingABitOfTrolling.Structs;

namespace DoingABitOfTrolling
{
    public partial class PunishmentOverlay : Form
    {
        private CancellationTokenSource shakeCancelationTokenSource = new CancellationTokenSource();
        private CancellationTokenSource rainbowTextCancelationTokenSource = new CancellationTokenSource();
        private CancellationTokenSource keepTopMostCancelationTokenSource = new CancellationTokenSource();

        public PunishmentOverlay()
        {
            InitializeComponent();
            this.AllowTransparency = true;
            this.BackColor = Color.Black;
            this.TransparencyKey = Color.Black;
            PunishmentText.AutoSize = true;
            this.TopMost = true;
            SnapToPosition();
            Load += PunishmentOverlay_Load;
            FormClosing += PunishmentOverlay_FormClosing;
        }

        ~PunishmentOverlay()
        {
            SelfDispose();
        }

        protected override bool ShowWithoutActivation => true;

        private void PunishmentOverlay_FormClosing(object? sender, FormClosingEventArgs e)
        {
            shakeCancelationTokenSource.Cancel();
            rainbowTextCancelationTokenSource.Cancel();
            keepTopMostCancelationTokenSource.Cancel();
            SelfDispose();
        }

        private void SelfDispose()
        {
            shakeCancelationTokenSource.Dispose();
            rainbowTextCancelationTokenSource.Dispose();
            keepTopMostCancelationTokenSource.Dispose();
            GC.SuppressFinalize(this);
        }

        public void SetJokeName(string jokeName)
        {
            PunishmentText.Text = $"{jokeName}";
        }

        private void PunishmentOverlay_Load(object? sender, EventArgs e)
        {
            SizeWindowToText();
            RainbowTextAsync(rainbowTextCancelationTokenSource.Token).ConfigureAwait(true);
            ShakeAsync(shakeCancelationTokenSource.Token).ConfigureAwait(true);
            KeepTopMostAsync(keepTopMostCancelationTokenSource.Token);
        }

        private async Task KeepTopMostAsync(CancellationToken token)
        {
            while (true)
            {
                await Task.Delay(500, token);
                if (token.IsCancellationRequested) return;
                this.TopMost = true;
            }
        }

        private void SizeWindowToText()
        {
            Size = new Size((PunishmentText.Size.Width * 2), (int)(PunishmentText.Size.Height * 1.25f));
        }

        private async Task ShakeAsync(CancellationToken token)
        {
            Random random = new Random();
            Position startPos = Position.FromPoint(Location);

            while (true)
            {
                const int intensity = 5;

                Position position = new Position(random.Next(startPos.X - intensity, startPos.X + intensity), random.Next(startPos.Y - intensity, startPos.Y + intensity));
                Location = position.ToPoint();

                await Task.Delay(50, token).ConfigureAwait(true);
                if (token.IsCancellationRequested) return;
            }
        }

        private async Task RainbowTextAsync(CancellationToken token)
        {
            Random random = new Random();

            while (true)
            {
                int r = random.Next(0, 255);
                int g = random.Next(0, 255);
                int b = random.Next(0, 255);
                Color color = Color.FromArgb(r, g, b);
                this.PunishmentText.BackColor = color;

                await Task.Delay(250, token).ConfigureAwait(true);
                if (token.IsCancellationRequested) return;
            }
        }

        private void SnapToPosition()
        {
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            Rectangle windowSize = this.Bounds;

            const int heightOffset = 80;
            Position targetWindowPoint = new Position(resolution.Width - windowSize.Width, resolution.Height - windowSize.Height / 2 - heightOffset);

            StartPosition = FormStartPosition.Manual;
            Location = targetWindowPoint.ToPoint();
        }
    }
}