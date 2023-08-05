using System.Drawing.Imaging;

namespace DoingABitOfTrolling.Resources
{
    internal static class Images
    {
        public static Image PopCat0()
        {
            return ImageResources.PopCat0;
        }

        public static Image PopCat1()
        {
            return ImageResources.popCat1;
        }

        public static Image RickGif()
        {
            return ImageResources.rick;
        }

        public static Image[] Rick()
        {
            Image gif = ImageResources.rick;
            int frameCount = gif.GetFrameCount(System.Drawing.Imaging.FrameDimension.Time);
            Image[] frames = new Image[frameCount];

            for (int i = 0; i < frames.Length; i++)
            {
                gif.SelectActiveFrame(FrameDimension.Time, i);
                frames[i] = new Bitmap(gif);
            }

            return frames;
        }

        public static Image SkillIssue()
        {
            return ImageResources.SkillIssue;
        }
    }
}
