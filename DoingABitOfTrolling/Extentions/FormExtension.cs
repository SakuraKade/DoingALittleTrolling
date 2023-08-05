using DoingABitOfTrolling.Structs;
using System;
using System.Linq;

namespace DoingABitOfTrolling.Extentions
{
    internal static class FormExtension
    {
        public static void SetupAsOverlay(this Form form)
        {
            form.ShowInTaskbar = false;
            form.Enabled = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopMost = true;
        }

        public static void SetupTransparency(this Form form, Color backgroundColor, Color transparencyKey)
        {
            form.BackColor = backgroundColor;
            form.TransparencyKey = transparencyKey;
        }

        public static void SetRandomPosition(this Form form)
        {
            Rectangle rectangle = Screen.PrimaryScreen.Bounds;
            rectangle = rectangle.Scale(0.8f);
            Position position = rectangle.GetRandomPositionInBounds();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = position.ToPoint();
        }
    }
}
