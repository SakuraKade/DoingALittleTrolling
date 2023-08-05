using DoingABitOfTrolling.Resources;
using DoingABitOfTrolling.Structs;
using System;
using System.Linq;
using System.Media;

namespace DoingABitOfTrolling.JokeEvents.Forms
{
    public partial class PopCat : Form
    {
        private Image popCat0;
        private Image popCat1;
        private SoundPlayer soundPlayer;
        private Stream popCatAudioStream;

        public PopCat()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;
            this.Enabled = false;
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.Cursor = Cursors.No;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            popCat0 = Images.PopCat0();
            popCat1 = Images.PopCat1();

            this.BackgroundImage = popCat0;

            LoadMusic();

            FormClosed += PopCat_FormClosed;
            Load += PopCat_Load;
        }

        ~PopCat()
        {
            SelfDispose();
        }

        protected override bool ShowWithoutActivation => true;

        private void SelfDispose()
        {
            soundPlayer?.Dispose();
            popCatAudioStream?.Dispose();
            popCat0?.Dispose();
            popCat1?.Dispose();
            popCat0 = null;
            popCat1 = null;
        }

        private void PopCat_FormClosed(object? sender, FormClosedEventArgs e)
        {
            SelfDispose();
        }

        private void PopCat_Load(object? sender, EventArgs e)
        {
            PlayMusicLooped();
            Task.Delay(1000).Wait();
            FormPannerLoopAsync();
            ImageSwapperLoopAsync();
        }

        private void LoadMusic()
        {
            popCatAudioStream = File.OpenRead("Resources\\Pop Cat.wav");
            soundPlayer = new SoundPlayer(popCatAudioStream);
            soundPlayer.Load();
        }

        private void PlayMusicLooped()
        {
            soundPlayer.PlayLooping();
        }

        public void Stop() { soundPlayer?.Stop(); }

        private async Task FormPannerLoopAsync()
        {
            const int delay = 1;
            const int pannSpeed = 20;
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            Rectangle formBounds = this.Bounds;

            int middleHeight = resolution.Height / 2 - formBounds.Height / 2;
            Position position = new Position(0, middleHeight);

            Position targetPositionRight = new Position(resolution.Width + formBounds.Width * 2, middleHeight);
            Position targetPositionLeft = new Position(formBounds.Width * -2, middleHeight);
            Position currentTargetPosition = targetPositionRight;

            while (true)
            {
                position = Position.MoveTowards(position, currentTargetPosition, pannSpeed);

                if (position == currentTargetPosition)
                {
                    if (currentTargetPosition == targetPositionLeft)
                    {
                        currentTargetPosition = targetPositionLeft;
                        position = targetPositionRight;
                    }
                    else
                    {
                        currentTargetPosition = targetPositionRight;
                        position = targetPositionLeft;
                    }
                }

                this.Location = position.ToPoint();
                await Task.Delay(delay).ConfigureAwait(true);
            }
        }

        private async Task ImageSwapperLoopAsync()
        {
            const int delay = 125;
            while (true)
            {
                await Task.Delay(delay).ConfigureAwait(true);
                if (this.BackgroundImage == popCat0)
                {
                    this.BackgroundImage = popCat1;
                }
                else
                {
                    this.BackgroundImage = popCat0;
                }
            }
        }
    }
}
