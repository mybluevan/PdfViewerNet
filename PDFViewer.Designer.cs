namespace XPdfNet
{
    partial class PDFViewer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tscbZoom = new System.Windows.Forms.ToolStripComboBox();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsPageLabel = new System.Windows.Forms.ToolStripLabel();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsFirst = new System.Windows.Forms.ToolStripButton();
            this.tsPrevious = new System.Windows.Forms.ToolStripButton();
            this.tsNext = new System.Windows.Forms.ToolStripButton();
            this.tsLast = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsZoomOut = new System.Windows.Forms.ToolStripButton();
            this.tsZoomIn = new System.Windows.Forms.ToolStripButton();
            this.FlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.LoadingLbl = new System.Windows.Forms.Label();
            this.LoadingBar = new System.Windows.Forms.ProgressBar();
            this.ToolStrip1.SuspendLayout();
            this.FlowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tscbZoom
            // 
            this.tscbZoom.MaxDropDownItems = 10;
            this.tscbZoom.Name = "tscbZoom";
            this.tscbZoom.Size = new System.Drawing.Size(100, 25);
            this.tscbZoom.SelectedIndexChanged += new System.EventHandler(this.tscbZoom_SelectedIndexChanged);
            this.tscbZoom.TextChanged += new System.EventHandler(this.tscbZoom_TextChanged);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsPageLabel
            // 
            this.tsPageLabel.Name = "tsPageLabel";
            this.tsPageLabel.Size = new System.Drawing.Size(62, 22);
            this.tsPageLabel.Text = "Page 1 of 1";
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsPageLabel,
            this.ToolStripSeparator1,
            this.tsPrint,
            this.toolStripSeparator2,
            this.tsFirst,
            this.tsPrevious,
            this.tsNext,
            this.tsLast,
            this.ToolStripSeparator3,
            this.tsZoomOut,
            this.tsZoomIn,
            this.tscbZoom});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(403, 25);
            this.ToolStrip1.TabIndex = 3;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // tsPrint
            // 
            this.tsPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsPrint.Image = global::XPdfNet.Properties.Resources.document_print;
            this.tsPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPrint.Name = "tsPrint";
            this.tsPrint.Size = new System.Drawing.Size(23, 22);
            this.tsPrint.Text = "Print";
            this.tsPrint.Click += new System.EventHandler(this.tsPrint_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsFirst
            // 
            this.tsFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsFirst.Image = global::XPdfNet.Properties.Resources.go_first;
            this.tsFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFirst.Name = "tsFirst";
            this.tsFirst.Size = new System.Drawing.Size(23, 22);
            this.tsFirst.Text = "First";
            this.tsFirst.ToolTipText = "First Page";
            this.tsFirst.Click += new System.EventHandler(this.tsFirst_Click);
            // 
            // tsPrevious
            // 
            this.tsPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsPrevious.Image = global::XPdfNet.Properties.Resources.go_previous;
            this.tsPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPrevious.Name = "tsPrevious";
            this.tsPrevious.Size = new System.Drawing.Size(23, 22);
            this.tsPrevious.Text = "Previous";
            this.tsPrevious.ToolTipText = "Previous Page";
            this.tsPrevious.Click += new System.EventHandler(this.tsPrevious_Click);
            // 
            // tsNext
            // 
            this.tsNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsNext.Image = global::XPdfNet.Properties.Resources.go_next;
            this.tsNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNext.Name = "tsNext";
            this.tsNext.Size = new System.Drawing.Size(23, 22);
            this.tsNext.Text = "Next";
            this.tsNext.ToolTipText = "Next Page";
            this.tsNext.Click += new System.EventHandler(this.tsNext_Click);
            // 
            // tsLast
            // 
            this.tsLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsLast.Image = global::XPdfNet.Properties.Resources.go_last;
            this.tsLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsLast.Name = "tsLast";
            this.tsLast.Size = new System.Drawing.Size(23, 22);
            this.tsLast.Text = "Last";
            this.tsLast.ToolTipText = "Last Page";
            this.tsLast.Click += new System.EventHandler(this.tsLast_Click);
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsZoomOut
            // 
            this.tsZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsZoomOut.Image = global::XPdfNet.Properties.Resources.zoom_out;
            this.tsZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsZoomOut.Name = "tsZoomOut";
            this.tsZoomOut.Size = new System.Drawing.Size(23, 22);
            this.tsZoomOut.Text = "ToolStripButton3";
            this.tsZoomOut.ToolTipText = "Zoom Out";
            this.tsZoomOut.Click += new System.EventHandler(this.tsZoomOut_Click);
            // 
            // tsZoomIn
            // 
            this.tsZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsZoomIn.Image = global::XPdfNet.Properties.Resources.zoom_in;
            this.tsZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsZoomIn.Name = "tsZoomIn";
            this.tsZoomIn.Size = new System.Drawing.Size(23, 22);
            this.tsZoomIn.Text = "ToolStripButton4";
            this.tsZoomIn.ToolTipText = "Zoom In";
            this.tsZoomIn.Click += new System.EventHandler(this.tsZoomIn_Click);
            // 
            // FlowPanel
            // 
            this.FlowPanel.AutoScroll = true;
            this.FlowPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.FlowPanel.Controls.Add(this.LoadingLbl);
            this.FlowPanel.Controls.Add(this.LoadingBar);
            this.FlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FlowPanel.Location = new System.Drawing.Point(0, 25);
            this.FlowPanel.Name = "FlowPanel";
            this.FlowPanel.Size = new System.Drawing.Size(403, 285);
            this.FlowPanel.TabIndex = 9;
            this.FlowPanel.WrapContents = false;
            this.FlowPanel.Click += new System.EventHandler(this.FlowPanel_Click);
            this.FlowPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.FlowPanel_Scroll);
            // 
            // LoadingLbl
            // 
            this.LoadingLbl.AutoSize = true;
            this.LoadingLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadingLbl.Location = new System.Drawing.Point(3, 0);
            this.LoadingLbl.Name = "LoadingLbl";
            this.LoadingLbl.Size = new System.Drawing.Size(107, 26);
            this.LoadingLbl.TabIndex = 2;
            this.LoadingLbl.Text = "Loading...";
            this.LoadingLbl.Visible = false;
            // 
            // LoadingBar
            // 
            this.LoadingBar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LoadingBar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.LoadingBar.Location = new System.Drawing.Point(3, 29);
            this.LoadingBar.MarqueeAnimationSpeed = 75;
            this.LoadingBar.Name = "LoadingBar";
            this.LoadingBar.Size = new System.Drawing.Size(102, 23);
            this.LoadingBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.LoadingBar.TabIndex = 3;
            this.LoadingBar.Visible = false;
            // 
            // PDFViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FlowPanel);
            this.Controls.Add(this.ToolStrip1);
            this.Name = "PDFViewer";
            this.Size = new System.Drawing.Size(403, 310);
            this.Resize += new System.EventHandler(this.PDFViewer_Resize);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.PDFViewer_ControlRemoved);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.FlowPanel.ResumeLayout(false);
            this.FlowPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripComboBox tscbZoom;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tsPageLabel;
        private System.Windows.Forms.ToolStrip ToolStrip1;
        private System.Windows.Forms.ToolStripButton tsPrevious;
        private System.Windows.Forms.ToolStripButton tsNext;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsZoomOut;
        private System.Windows.Forms.ToolStripButton tsZoomIn;
        private System.Windows.Forms.FlowLayoutPanel FlowPanel;
        private System.Windows.Forms.ToolStripButton tsFirst;
        private System.Windows.Forms.ToolStripButton tsLast;
        private System.Windows.Forms.ToolStripButton tsPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ProgressBar LoadingBar;
        private System.Windows.Forms.Label LoadingLbl;
    }
}
