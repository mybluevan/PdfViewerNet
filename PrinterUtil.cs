using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;

namespace XPdfNet
{
    class PrinterUtil
    {
        private PrintDocument printDocument;
        private PDFLibNet.PDFWrapper pdfDoc;
        private int endPage;
        private int currentPage;
        private bool finishedPrinting = false;
        private const int RENDER_DPI = 300;

        private PrinterUtil(PrintDocument printDocument, PDFLibNet.PDFWrapper pdfDoc)
        {
            this.printDocument = printDocument;
            this.pdfDoc = pdfDoc;
            this.endPage = printDocument.PrinterSettings.ToPage;
            this.currentPage = printDocument.PrinterSettings.FromPage;
            printDocument.PrintPage += PrintDocument_PrintPage;
            printDocument.EndPrint += PrintDocument_EndPrint;
        }

        private void PrintDocument_EndPrint(object sender, PrintEventArgs e)
        {
            finishedPrinting = true;
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Image image = new Bitmap("null");
            //Image image = ImageUtil.GetImageFromPDF(pdfDoc, currentPage, RENDER_DPI);
            
            AutoRotate(image, e.Graphics.VisibleClipBounds);

            float xFactor = ((e.Graphics.VisibleClipBounds.Width / 100) * image.HorizontalResolution) / image.Width;
            float yFactor = ((e.Graphics.VisibleClipBounds.Height / 100) * image.VerticalResolution) / image.Height;

            float scalePercentage = (yFactor > xFactor) ? xFactor : yFactor;
            int optimalDPI = (int)(RENDER_DPI * scalePercentage);

            e.Graphics.ScaleTransform(scalePercentage, scalePercentage);
            e.Graphics.DrawImage(image, 0, 0);

            e.HasMorePages = (currentPage < endPage);

            image.Dispose();
            currentPage += 1;
        }

        private void AutoRotate(Image image, RectangleF bounds)
        {
            if ((image.Height > image.Width & bounds.Width > bounds.Height) | (image.Width > image.Height & bounds.Height > bounds.Width))
                image.RotateFlip(RotateFlipType.Rotate270FlipNone);
        }

        internal static bool PrintImagesToPrinter(PDFLibNet.PDFWrapper pdfDoc)
        {
            PrintDialog pd = new PrintDialog();
            pd.AllowPrintToFile = false;
            pd.AllowSomePages = true;
            pd.PrinterSettings.FromPage = pd.PrinterSettings.MinimumPage = 1;
            pd.PrinterSettings.ToPage = pd.PrinterSettings.MaximumPage = pdfDoc.PageCount;
            if (pd.ShowDialog() == DialogResult.OK)
            {
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintController = new StandardPrintController();
                printDocument.PrinterSettings = pd.PrinterSettings;
                PrinterUtil printUtil = new PrinterUtil(printDocument, pdfDoc);
                Cursor.Current = Cursors.WaitCursor;
                printUtil.printDocument.Print();
                bool retVal = printUtil.finishedPrinting;
                printUtil = null;
                GC.Collect();
                Cursor.Current = Cursors.Default;
                return retVal;
            }
            else
                return false;
        }
    }
}
