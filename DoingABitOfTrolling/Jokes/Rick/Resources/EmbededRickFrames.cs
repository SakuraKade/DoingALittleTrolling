using DoingABitOfTrolling.Lib.Abstacts;
using DoingABitOfTrolling.Lib.Implementations;
using DoingABitOfTrolling.Lib.Interfaces;
using System;
using System.Drawing.Imaging;
using System.Linq;

namespace DoingABitOfTrolling.Jokes.Rick.Resources
{
    internal class EmbededRickFrames : EmbededResource<IDisposableList<Bitmap>>, IDisposable
    {
        public EmbededRickFrames()
        {
            resource = new Lazy<IDisposableList<Bitmap>>(GetResource());
        }
            
        protected override Lazy<IDisposableList<Bitmap>> resource { get; init; }

        private IDisposableList<Bitmap> GetResource()
        {
            IDisposableList<Bitmap> collection = new DisposableList<Bitmap>();

            using Bitmap rickGif = EmbededRickResources.rick;
            Bitmap[] frames = GetFrames(rickGif);
            foreach (Bitmap bitmap in frames)
            {
                collection.Add(bitmap);
            }

            return collection;
        }

        private Bitmap[] GetFrames(Bitmap bitmap)
        {
            int frameCount = bitmap.GetFrameCount(FrameDimension.Time);
            Bitmap[] frames = new Bitmap[frameCount];
            for (int i = 0; i < frameCount; i++)
            {
                bitmap.SelectActiveFrame(FrameDimension.Time, i);
                frames[i] = (Bitmap)bitmap.Clone();
            }
            
            return frames;
        }
    }
}
