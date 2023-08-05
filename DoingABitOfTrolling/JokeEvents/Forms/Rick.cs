using DoingABitOfTrolling.Resources;
using DoingABitOfTrolling.Structs;
using System;
using System.Linq;
using System.Media;

namespace DoingABitOfTrolling.JokeEvents.Forms
{
    public partial class Rick : Form
    {
        private Image[] rickFrames;
        private Stream rickRollSoundStream;
        private SoundPlayer soundPlayer;

        public Rick()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Enabled = false;
            this.TopMost = true;
            this.StartPosition = FormStartPosition.Manual;
            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            rickFrames = Images.Rick();
            Image? referenceImage = rickFrames.FirstOrDefault();
            if (referenceImage == null)
            {
                throw new Exception("No Images");
            }

            this.Width = referenceImage.Width;
            this.Height = referenceImage.Height;

            this.AutoValidate = AutoValidate.Disable;

            // Prepare the soundplayer
            try
            {
                rickRollSoundStream = File.OpenRead("Resources\\rickroll but it never starts.wav");
                soundPlayer = new SoundPlayer(rickRollSoundStream);
                soundPlayer.Load();
            }
            catch (IOException ex)
            {
                throw ex;
            }

            Load += Rick_Load;
        }

        ~Rick()
        {
            soundPlayer.Dispose();
            rickRollSoundStream.Dispose();
        }

        protected override bool ShowWithoutActivation => true;

        public void Stop()
        {
            soundPlayer.Stop();
            soundPlayer.Dispose();
            rickRollSoundStream?.Dispose();

            foreach (Image frame in rickFrames)
            {
                frame.Dispose();
            }

            soundPlayer = null;
            rickRollSoundStream = null;
            GC.Collect();
        }

        private void Rick_Load(object? sender, EventArgs e)
        {
            soundPlayer.PlayLooping();
            MoveLoopAsync();
            ImageLoopAsync();
        }

        private async Task MoveLoopAsync()
        {
            Random random = new Random();
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            Position offset = new Position(this.Width, this.Height);
            int xLowerBound = (int)(resolution.Width * 0.25f);
            int xUpperBound = (int)(resolution.Width * 0.75f);
            int yLowerBound = (int)(resolution.Height * 0.25f);
            int yUpperBound = (int)(resolution.Height * 0.75f);

            Position position;

            while (true)
            {
                await Task.Delay(500).ConfigureAwait(true);
                position = new Position(random.Next(xLowerBound, xUpperBound), random.Next(yLowerBound, yUpperBound));
                this.Location = position.ToPoint();
            }
        }

        private async Task ImageLoopAsync()
        {
            while (true)
            {
                foreach (Image frame in rickFrames)
                {
                    await Task.Delay(100).ConfigureAwait(true);
                    this.BackgroundImage = frame;
                }
            }
        }
    }
}
