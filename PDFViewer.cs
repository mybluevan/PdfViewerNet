using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace XPdfNet
{
    public partial class PDFViewer : UserControl
    {
        private PDFLibNet.PDFWrapper pdfDoc;
        private int pdfPageCount;
        private int scrollUnitsPerPage;
        private int currentPageNumber;
        private int lastPageNumber;
        private bool pageInitDone;
        //private bool continuousPages = true;
        private string pdfFileName;
        //private string userPassword;
        //private string ownerPassword;
        //private string password;
        private Point panStartPoint;
        private bool loading;
        private bool doZoom;
        private const int DEFAULT_ZOOM_INDEX = 0;
        private const double ZOOM_FACTOR = 1.25;
        private Dictionary<string, object> zoomLevels = new Dictionary<string, object>() {
            { "Fit To Width", ViewMode.FIT_WIDTH },
            { "Fit To Screen", ViewMode.FIT_TO_SCREEN },
            { "200%", 200D },
            { "150%", 150D },
            { "125%", 125D },
            { "100%", 100D },
            { "75%", 75D },
            { "50%", 50D },
            { "25%", 25D } };

        public PDFViewer()
        {
            InitializeComponent();
            this.Disposed += new EventHandler(this.PDFViewer_Disposed);
            FlowPanel.MouseWheel += new MouseEventHandler(this.FlowPanel_MouseWheel);
            FlowPanel.KeyDown += new KeyEventHandler(FlowPanel_KeyDown);
            FlowPanel.KeyUp += new KeyEventHandler(FlowPanel_KeyUp);
        }

        public string FileName
        {
            get
            {
                return pdfFileName;
            }
            set
            {
                if (value != null && value != "" && ImageUtil.IsPDF(value))
                {
                    //userPassword = "";
                    //ownerPassword = "";
                    //password = "";
                    ShowLoading = true;
                    if (pdfDoc != null) pdfDoc.Dispose();
                    try
                    {
                        pdfDoc = new PDFLibNet.PDFWrapper("");
                        pdfDoc.LoadPDF(value);
                    }
                    //catch (System.Security.SecurityException ex)
                    //{
                    //}
                    catch
                    {
                        if (pdfDoc != null) pdfDoc.Dispose();
                        throw;
                    }

                    //Initialize zoom dropdown
                    tscbZoom.Items.Clear();
                    string[] keys = new string[zoomLevels.Keys.Count];
                    zoomLevels.Keys.CopyTo(keys, 0);
                    tscbZoom.Items.AddRange(keys);

                    pdfPageCount = pdfDoc.PageCount;
                    currentPageNumber = 1;
                    tscbZoom.SelectedIndex = DEFAULT_ZOOM_INDEX;
                    pdfFileName = value;
                    ShowLoading = false;
                    this.Enabled = true;
                }
                else
                {
                    this.Enabled = false;
                }
            }
        }

        public int PageCount
        {
            get
            {
                return pdfPageCount;
            }
        }

        public bool Print()
        {
            if (pdfDoc == null)
                return false;
            else
                return PrinterUtil.PrintImagesToPrinter(pdfDoc);
        }

        public bool Print(string filename)
        {
            //TODO
            if (filename != null && filename != "" && ImageUtil.IsPDF(filename))
            {
                PDFLibNet.PDFWrapper tmpDoc = new PDFLibNet.PDFWrapper("");
                tmpDoc.LoadPDF(filename);
                return PrinterUtil.PrintImagesToPrinter(tmpDoc);
            }
            else
                return false;
        }

        public bool ShowLoading
        {
            get
            {
                return loading;
            }
            set
            {
                if (value != loading)
                {
                    if (value)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        FlowPanel.Controls.Clear();
                        FlowPanel.Controls.Add(LoadingLbl);
                        FlowPanel.Controls.Add(LoadingBar);
                    }
                    else
                    {
                        FlowPanel.Controls.Remove(LoadingLbl);
                        FlowPanel.Controls.Remove(LoadingBar);
                        Cursor.Current = Cursors.Default;
                    }
                    LoadingLbl.Visible = LoadingBar.Visible = loading = value;
                    if (value) Application.DoEvents();
                }
            }
        }

        public bool ShowPrintBtn
        {
            get
            {
                return tsPrint.Visible;
            }
            set
            {
                tsPrint.Visible = toolStripSeparator2.Visible = value;
            }
        }

        #region Events

        private void PDFViewer_Disposed(object sender, EventArgs e)
        {
            if (pdfDoc != null) pdfDoc.Dispose();
        }

        private void PDFViewer_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (pdfDoc != null) pdfDoc.Dispose();
        }

        private void PDFViewer_Resize(object sender, EventArgs e)
        {
            if (pageInitDone)
                CenterPicBoxesInPanel();

            // Center the label and progress bar.
            LoadingLbl.Margin = new Padding((FlowPanel.Width - LoadingLbl.Width) / 2,
                (FlowPanel.Height - LoadingLbl.Height - LoadingBar.Height - LoadingBar.Margin.Top) / 2,
                LoadingLbl.Margin.Right, LoadingLbl.Margin.Bottom);
            LoadingBar.Margin = new Padding(LoadingLbl.Margin.Left, LoadingBar.Margin.Top,
                LoadingBar.Margin.Right, LoadingLbl.Margin.Top);
        }

        private void tscbZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyZoom(zoomLevels[tscbZoom.SelectedItem.ToString()]);
        }

        private void tsFirst_Click(object sender, EventArgs e)
        {
            GoToPage(1);
        }

        private void tsPrevious_Click(object sender, EventArgs e)
        {
            GoToPage(currentPageNumber - 1);
        }

        private void tsNext_Click(object sender, EventArgs e)
        {
            GoToPage(currentPageNumber + 1);
        }

        private void tsLast_Click(object sender, EventArgs e)
        {
            GoToPage(pdfPageCount);
        }

        private void tsZoomOut_Click(object sender, EventArgs e)
        {
            double zoom = pdfDoc.Zoom / ZOOM_FACTOR;
            tscbZoom.Text = String.Format("{0:F0}%", zoom);
            ApplyZoom(zoom);
        }

        private void tsZoomIn_Click(object sender, EventArgs e)
        {
            double zoom = pdfDoc.Zoom * ZOOM_FACTOR;
            tscbZoom.Text = String.Format("{0:F0}%", zoom);
            ApplyZoom(zoom);
        }

        private void PicImage_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
            panStartPoint = new Point(e.X, e.Y);
        }

        private void PicImage_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void PicImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ScrollableControl parent = (ScrollableControl)((Control)sender).Parent;
                parent.AutoScrollPosition = new Point((panStartPoint.X - e.X - parent.AutoScrollPosition.X), (panStartPoint.Y - e.Y - parent.AutoScrollPosition.Y));
                CalcCurrentPage();
            }
        }

        private void tsPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void FlowPanel_Scroll(object sender, ScrollEventArgs e)
        {
            CalcCurrentPage();
        }

        private void FlowPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (doZoom && !ShowLoading)
            {
                if (e.Delta < 0)
                    ApplyZoom(-ZOOM_FACTOR);
                else if (e.Delta > 0)
                    ApplyZoom(ZOOM_FACTOR);
            }
            else
                CalcCurrentPage();
        }

        private void FlowPanel_Click(object sender, EventArgs e)
        {
            FlowPanel.Focus();
        }

        void FlowPanel_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
                doZoom = false;
        }

        void FlowPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
                doZoom = true;
        }

        #endregion

        #region Helper Functions

        private enum ViewMode
        {
            FIT_TO_SCREEN,
            FIT_WIDTH
            //ACTUAL_SIZE
        }

        private PictureBox FindPictureBox(string controlName)
        {
            return (PictureBox)FindControl(FlowPanel, controlName);
        }

        private Control FindControl(Control container, string name)
        {
            Queue<Control> searchQueue = new Queue<Control>();
            Control node;
            searchQueue.Enqueue(container);
            while (searchQueue.Count > 0)
            {
                node = searchQueue.Dequeue();
                if (node.Name == name)
                    return node;
                foreach (Control child in node.Controls)
                    searchQueue.Enqueue(child);
            }
            return null;
        }

        private void CenterPicBoxesInPanel()
        {
            //if (flowPanel != null)
            foreach (Control c in FlowPanel.Controls)
                if (c.GetType() == typeof(PictureBox))
                    ImageUtil.RecalcContinuousPageLocation((PictureBox)c, false);
        }

        private void InitializePageView(object mode)
        {
            FlowPanel.SuspendLayout();
            foreach (Control c in FlowPanel.Controls)
                if (c.GetType() == typeof(PictureBox))
                    FlowPanel.Controls.Remove(c);
            for (int i = 1; i <= pdfPageCount; i++)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Name = i.ToString();
                pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBox.Height = FlowPanel.Height - pictureBox.Margin.Top * 2;
                pictureBox.Width = FlowPanel.Width - pictureBox.Margin.Right * 2 - SystemInformation.VerticalScrollBarWidth;
                pictureBox.MouseUp += PicImage_MouseUp;
                pictureBox.MouseDown += PicImage_MouseDown;
                pictureBox.MouseMove += PicImage_MouseMove;
                pictureBox.MouseClick += FlowPanel_Click;
                FlowPanel.Controls.Add(pictureBox);
                ApplyZoomToPDF(pictureBox, mode);
                GetImageFromPDF(i, pictureBox);
            }
            FlowPanel.ResumeLayout();
            scrollUnitsPerPage = (FlowPanel.VerticalScroll.Maximum-FlowPanel.VerticalScroll.LargeChange) / pdfPageCount;
            pageInitDone = true;
        }

        private void UpdatePageLabel()
        {
            tsPageLabel.Text = "Page " + currentPageNumber + " of " + pdfPageCount;
        }

        private void CalcCurrentPage()
        {
            currentPageNumber = (int)(System.Math.Floor((double)FlowPanel.VerticalScroll.Value / scrollUnitsPerPage)) + 1;
            UpdatePageLabel();
        }

        private void ApplyZoom(object mode)
        {
            ShowLoading = true;
            InitializePageView(mode);
            ShowLoading = false;
            CenterPicBoxesInPanel();
            DisplayCurrentPage();
        }

        private void DisplayCurrentPage()
        {

            CheckPageBounds();
            FlowPanel.ScrollControlIntoView(FindPictureBox(currentPageNumber.ToString()));
            UpdatePageLabel();
        }

        private void CheckPageBounds()
        {
            if (currentPageNumber > pdfPageCount)
                currentPageNumber = pdfPageCount;
            else if (currentPageNumber < 1)
                currentPageNumber = 1;

            if (currentPageNumber < pdfPageCount)
            {
                tsNext.Enabled = true;
                tsLast.Enabled = true;
            }
            else
            {
                tsNext.Enabled = false;
                tsLast.Enabled = false;
            }

            if (currentPageNumber > 1)
            {
                tsPrevious.Enabled = true;
                tsFirst.Enabled = true;
            }
            else
            {
                tsPrevious.Enabled = false;
                tsFirst.Enabled = false;
            }
        }

        private void ApplyZoomToPDF(PictureBox pictureBox, object mode)
        {
            pictureBox.Width += SystemInformation.VerticalScrollBarWidth;
            if (mode.GetType() == typeof(ViewMode))
            {
                if ((ViewMode)mode == ViewMode.FIT_WIDTH)
                    pdfDoc.FitToWidth(pictureBox.Handle);
                else if ((ViewMode)mode == ViewMode.FIT_TO_SCREEN)
                {
                    pdfDoc.FitToHeight(pictureBox.Handle);
                    if (pdfDoc.PageWidth > pdfDoc.PageHeight)
                        pdfDoc.FitToWidth(pictureBox.Handle);
                }
            }
            else if (mode.GetType() == typeof(double))
                pdfDoc.Zoom = Math.Abs((double)mode);
            pictureBox.Width -= SystemInformation.VerticalScrollBarWidth;
        }

        private void GetImageFromPDF(int page, PictureBox pictureBox)
        {
            if (pdfDoc != null)
            {
                pdfDoc.CurrentPage = page;
                pdfDoc.CurrentX = pdfDoc.CurrentY = 0;
                pdfDoc.RenderPage(pictureBox.Handle);
                pictureBox.Image = new Bitmap(pdfDoc.PageWidth, pdfDoc.PageHeight);
                pdfDoc.ClientBounds = new Rectangle(0, 0, pdfDoc.PageWidth, pdfDoc.PageHeight);
                using (Graphics g = Graphics.FromImage(pictureBox.Image))
                {
                    pdfDoc.DrawPageHDC(g.GetHdc());
                    g.ReleaseHdc();
                }
            }
        }

        private void GoToPage(int page)
        {
            lastPageNumber = currentPageNumber;
            currentPageNumber = page;
            DisplayCurrentPage();
        }

        #endregion

        private void tscbZoom_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
