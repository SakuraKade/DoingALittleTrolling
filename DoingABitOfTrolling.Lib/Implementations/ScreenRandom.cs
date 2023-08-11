using DoingABitOfTrolling.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoingABitOfTrolling.Lib.Implementations
{
    public class ScreenRandom : IScreenRandom
    {
        Random random = new Random();
        Rectangle[] screens;

        public ScreenRandom(Rectangle[] screens)
        {
            this.screens = screens;
        }

        public Point Next()
        {
            if (screens == null)
                throw new NullReferenceException(nameof(screens));

            Rectangle rectangle = ;
        }

        private static Rectangle GetRandomScreen(Rectangle[] screens, Random random)
        {
            int index = random.Next(screens.Length);
            return screens[index];
        }
    }
}
