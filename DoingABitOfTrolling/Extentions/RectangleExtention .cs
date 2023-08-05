using DoingABitOfTrolling.Structs;
using System;
using System.Linq;

namespace DoingABitOfTrolling.Extentions
{
    internal static class RectangleExtention
    {
        public static Rectangle Scale(this Rectangle rectangle, double scale)
        {
            Rectangle rect = new Rectangle(
                new Point(0, 0),
                new Size((int)(rectangle.Width * scale), (int)(rectangle.Height * scale))
                );

            return rect;
        }

        public static Position GetRandomPositionInBounds(this Rectangle rectangle)
        {
            int lowerX = rectangle.Left;
            int upperX = rectangle.Right;
            int upperY = rectangle.Bottom;
            int lowerY = rectangle.Top;

            Random random = new Random();
            int randX = random.Next(lowerX, upperX);
            int randY = random.Next(lowerY, upperY);

            return new Position(randX, randY);
        }
    }
}
