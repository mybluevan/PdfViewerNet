using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

namespace XPdfNet
{
    class ImageUtil
    {
        internal static void RecalcContinuousPageLocation(PictureBox picBox, bool loading)
        {
            int hMargin = picBox.Margin.Right;
            int vMargin = picBox.Margin.Top;
            int clientWidth = picBox.Parent.ClientSize.Width;
            if (loading)
                clientWidth -= SystemInformation.VerticalScrollBarWidth;
            int width = picBox.Size.Width;

            if (width + hMargin * 2 < clientWidth)
                picBox.Margin = new Padding((clientWidth - width) / 2, vMargin, hMargin, vMargin);
            else
                picBox.Margin = new Padding(hMargin, vMargin, hMargin, vMargin);
        }

        internal static bool IsPDF(string filename)
        {
            return (filename == null) ? false : Regex.IsMatch(filename, @"\.pdf$", RegexOptions.IgnoreCase);
        }

    }
}
