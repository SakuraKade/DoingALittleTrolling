using DoingABitOfTrolling.Extentions;
using DoingABitOfTrolling.Resources;
using System;
using System.Linq;

namespace DoingABitOfTrolling.JokeEvents.Forms
{
    public partial class ErrorsMuch : Form
    {
        Image image;

        public ErrorsMuch()
        {
            image = Images.SkillIssue();

            InitializeComponent();
            this.SetupAsOverlay();
            this.SetupTransparency(Color.White, Color.White);
            SetImage();
            this.SetRandomPosition();
        }

        ~ErrorsMuch()
        {
            SelfDispose();
        }

        void SelfDispose()
        {
            image.Dispose();
        }

        void SetImage()
        {
            this.BackgroundImage = image;
            int height = image.Height;
            int width = image.Width;
            this.Size = new Size(width, height);
        }

        protected override bool ShowWithoutActivation => true;

        public void CustomDispose()
        {
            this.Close();
            SelfDispose();
        }
    }
}
