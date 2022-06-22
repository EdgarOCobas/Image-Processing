namespace Projekt_APO_2022
{
    partial class APO
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zachowajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszJakoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greyscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussianblurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otsuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaptiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reduceGrayLevelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directionalEdgeDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previttToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medianFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operatonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.watershedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.morphologyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erosionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dilationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topHatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackHatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informacjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rozciaganieHistogramuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rozciaganieHistogramuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.wyrownanieHistogramuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.imageSharpeningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skeletonizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.posteryzacjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multilevelThresholdingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.operacjeToolStripMenuItem,
            this.informacjeToolStripMenuItem,
            this.histogramToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1292, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otToolStripMenuItem,
            this.zachowajToolStripMenuItem,
            this.zapiszJakoToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // otToolStripMenuItem
            // 
            this.otToolStripMenuItem.Name = "otToolStripMenuItem";
            this.otToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.otToolStripMenuItem.Text = "Otwórz";
            this.otToolStripMenuItem.Click += new System.EventHandler(this.otToolStripMenuItem_Click);
            // 
            // zachowajToolStripMenuItem
            // 
            this.zachowajToolStripMenuItem.Name = "zachowajToolStripMenuItem";
            this.zachowajToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.zachowajToolStripMenuItem.Text = "Zapisz";
            this.zachowajToolStripMenuItem.Click += new System.EventHandler(this.zachowajToolStripMenuItem_Click);
            // 
            // zapiszJakoToolStripMenuItem
            // 
            this.zapiszJakoToolStripMenuItem.Name = "zapiszJakoToolStripMenuItem";
            this.zapiszJakoToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.zapiszJakoToolStripMenuItem.Text = "Zapisz jako";
            this.zapiszJakoToolStripMenuItem.Click += new System.EventHandler(this.zapiszJakoToolStripMenuItem_Click);
            // 
            // operacjeToolStripMenuItem
            // 
            this.operacjeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.greyscaleToolStripMenuItem,
            this.blurToolStripMenuItem,
            this.gaussianblurToolStripMenuItem,
            this.invertToolStripMenuItem,
            this.thresholdingToolStripMenuItem,
            this.reduceGrayLevelsToolStripMenuItem,
            this.edgeDetectionToolStripMenuItem,
            this.directionalEdgeDetectionToolStripMenuItem,
            this.medianFilterToolStripMenuItem,
            this.operatonsToolStripMenuItem,
            this.watershedToolStripMenuItem,
            this.morphologyToolStripMenuItem,
            this.imageSharpeningToolStripMenuItem,
            this.skeletonizationToolStripMenuItem,
            this.posteryzacjaToolStripMenuItem});
            this.operacjeToolStripMenuItem.Name = "operacjeToolStripMenuItem";
            this.operacjeToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.operacjeToolStripMenuItem.Text = "Operacje";
            // 
            // greyscaleToolStripMenuItem
            // 
            this.greyscaleToolStripMenuItem.Name = "greyscaleToolStripMenuItem";
            this.greyscaleToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.greyscaleToolStripMenuItem.Text = "Greyscale";
            this.greyscaleToolStripMenuItem.Click += new System.EventHandler(this.greyscaleToolStripMenuItem_Click);
            // 
            // blurToolStripMenuItem
            // 
            this.blurToolStripMenuItem.Name = "blurToolStripMenuItem";
            this.blurToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.blurToolStripMenuItem.Text = "Blur";
            this.blurToolStripMenuItem.Click += new System.EventHandler(this.blurToolStripMenuItem_Click);
            // 
            // gaussianblurToolStripMenuItem
            // 
            this.gaussianblurToolStripMenuItem.Name = "gaussianblurToolStripMenuItem";
            this.gaussianblurToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.gaussianblurToolStripMenuItem.Text = "Gaussian-blur";
            this.gaussianblurToolStripMenuItem.Click += new System.EventHandler(this.gaussianblurToolStripMenuItem_Click);
            // 
            // invertToolStripMenuItem
            // 
            this.invertToolStripMenuItem.Name = "invertToolStripMenuItem";
            this.invertToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.invertToolStripMenuItem.Text = "Negate";
            this.invertToolStripMenuItem.Click += new System.EventHandler(this.invertToolStripMenuItem_Click);
            // 
            // thresholdingToolStripMenuItem
            // 
            this.thresholdingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otsuToolStripMenuItem,
            this.adaptiveToolStripMenuItem,
            this.thresholdingToolStripMenuItem1,
            this.multilevelThresholdingToolStripMenuItem});
            this.thresholdingToolStripMenuItem.Name = "thresholdingToolStripMenuItem";
            this.thresholdingToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.thresholdingToolStripMenuItem.Text = "Thresholding";
            // 
            // otsuToolStripMenuItem
            // 
            this.otsuToolStripMenuItem.Name = "otsuToolStripMenuItem";
            this.otsuToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.otsuToolStripMenuItem.Text = "Otsu";
            this.otsuToolStripMenuItem.Click += new System.EventHandler(this.otsuToolStripMenuItem_Click);
            // 
            // adaptiveToolStripMenuItem
            // 
            this.adaptiveToolStripMenuItem.Name = "adaptiveToolStripMenuItem";
            this.adaptiveToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.adaptiveToolStripMenuItem.Text = "Adaptive";
            this.adaptiveToolStripMenuItem.Click += new System.EventHandler(this.adaptiveToolStripMenuItem_Click);
            // 
            // thresholdingToolStripMenuItem1
            // 
            this.thresholdingToolStripMenuItem1.Name = "thresholdingToolStripMenuItem1";
            this.thresholdingToolStripMenuItem1.Size = new System.Drawing.Size(144, 22);
            this.thresholdingToolStripMenuItem1.Text = "Thresholding";
            this.thresholdingToolStripMenuItem1.Click += new System.EventHandler(this.thresholdingToolStripMenuItem1_Click);
            // 
            // reduceGrayLevelsToolStripMenuItem
            // 
            this.reduceGrayLevelsToolStripMenuItem.Name = "reduceGrayLevelsToolStripMenuItem";
            this.reduceGrayLevelsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.reduceGrayLevelsToolStripMenuItem.Text = "Reduce gray levels";
            this.reduceGrayLevelsToolStripMenuItem.Click += new System.EventHandler(this.reduceGrayLevelsToolStripMenuItem_Click);
            // 
            // edgeDetectionToolStripMenuItem
            // 
            this.edgeDetectionToolStripMenuItem.Name = "edgeDetectionToolStripMenuItem";
            this.edgeDetectionToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.edgeDetectionToolStripMenuItem.Text = "Edge detection";
            this.edgeDetectionToolStripMenuItem.Click += new System.EventHandler(this.edgeDetectionToolStripMenuItem_Click);
            // 
            // directionalEdgeDetectionToolStripMenuItem
            // 
            this.directionalEdgeDetectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previttToolStripMenuItem});
            this.directionalEdgeDetectionToolStripMenuItem.Name = "directionalEdgeDetectionToolStripMenuItem";
            this.directionalEdgeDetectionToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.directionalEdgeDetectionToolStripMenuItem.Text = "Directional edge detection";
            // 
            // previttToolStripMenuItem
            // 
            this.previttToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nToolStripMenuItem,
            this.eToolStripMenuItem,
            this.wToolStripMenuItem,
            this.sToolStripMenuItem,
            this.nEToolStripMenuItem,
            this.nWToolStripMenuItem,
            this.sEToolStripMenuItem,
            this.sWToolStripMenuItem});
            this.previttToolStripMenuItem.Name = "previttToolStripMenuItem";
            this.previttToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.previttToolStripMenuItem.Text = "Prewitt";
            this.previttToolStripMenuItem.Click += new System.EventHandler(this.previttToolStripMenuItem_Click);
            // 
            // medianFilterToolStripMenuItem
            // 
            this.medianFilterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x3ToolStripMenuItem,
            this.x5ToolStripMenuItem,
            this.x7ToolStripMenuItem});
            this.medianFilterToolStripMenuItem.Name = "medianFilterToolStripMenuItem";
            this.medianFilterToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.medianFilterToolStripMenuItem.Text = "Median filter";
            // 
            // x3ToolStripMenuItem
            // 
            this.x3ToolStripMenuItem.Name = "x3ToolStripMenuItem";
            this.x3ToolStripMenuItem.Size = new System.Drawing.Size(91, 22);
            this.x3ToolStripMenuItem.Text = "3x3";
            this.x3ToolStripMenuItem.Click += new System.EventHandler(this.x3ToolStripMenuItem_Click);
            // 
            // x5ToolStripMenuItem
            // 
            this.x5ToolStripMenuItem.Name = "x5ToolStripMenuItem";
            this.x5ToolStripMenuItem.Size = new System.Drawing.Size(91, 22);
            this.x5ToolStripMenuItem.Text = "5x5";
            this.x5ToolStripMenuItem.Click += new System.EventHandler(this.x5ToolStripMenuItem_Click);
            // 
            // x7ToolStripMenuItem
            // 
            this.x7ToolStripMenuItem.Name = "x7ToolStripMenuItem";
            this.x7ToolStripMenuItem.Size = new System.Drawing.Size(91, 22);
            this.x7ToolStripMenuItem.Text = "7x7";
            this.x7ToolStripMenuItem.Click += new System.EventHandler(this.x7ToolStripMenuItem_Click);
            // 
            // operatonsToolStripMenuItem
            // 
            this.operatonsToolStripMenuItem.Name = "operatonsToolStripMenuItem";
            this.operatonsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.operatonsToolStripMenuItem.Text = "Operations";
            this.operatonsToolStripMenuItem.Click += new System.EventHandler(this.operatonsToolStripMenuItem_Click);
            // 
            // watershedToolStripMenuItem
            // 
            this.watershedToolStripMenuItem.Name = "watershedToolStripMenuItem";
            this.watershedToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.watershedToolStripMenuItem.Text = "Watershed";
            this.watershedToolStripMenuItem.Click += new System.EventHandler(this.watershedToolStripMenuItem_Click);
            // 
            // morphologyToolStripMenuItem
            // 
            this.morphologyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.erosionToolStripMenuItem,
            this.dilationToolStripMenuItem,
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.gradientToolStripMenuItem,
            this.topHatToolStripMenuItem,
            this.blackHatToolStripMenuItem});
            this.morphologyToolStripMenuItem.Name = "morphologyToolStripMenuItem";
            this.morphologyToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.morphologyToolStripMenuItem.Text = "Morphology";
            // 
            // erosionToolStripMenuItem
            // 
            this.erosionToolStripMenuItem.Name = "erosionToolStripMenuItem";
            this.erosionToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.erosionToolStripMenuItem.Text = "Erosion";
            this.erosionToolStripMenuItem.Click += new System.EventHandler(this.erosionToolStripMenuItem_Click);
            // 
            // dilationToolStripMenuItem
            // 
            this.dilationToolStripMenuItem.Name = "dilationToolStripMenuItem";
            this.dilationToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.dilationToolStripMenuItem.Text = "Dilation";
            this.dilationToolStripMenuItem.Click += new System.EventHandler(this.dilationToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // gradientToolStripMenuItem
            // 
            this.gradientToolStripMenuItem.Name = "gradientToolStripMenuItem";
            this.gradientToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.gradientToolStripMenuItem.Text = "Gradient";
            this.gradientToolStripMenuItem.Click += new System.EventHandler(this.gradientToolStripMenuItem_Click);
            // 
            // topHatToolStripMenuItem
            // 
            this.topHatToolStripMenuItem.Name = "topHatToolStripMenuItem";
            this.topHatToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.topHatToolStripMenuItem.Text = "Top Hat";
            this.topHatToolStripMenuItem.Click += new System.EventHandler(this.topHatToolStripMenuItem_Click);
            // 
            // blackHatToolStripMenuItem
            // 
            this.blackHatToolStripMenuItem.Name = "blackHatToolStripMenuItem";
            this.blackHatToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.blackHatToolStripMenuItem.Text = "Black Hat";
            this.blackHatToolStripMenuItem.Click += new System.EventHandler(this.blackHatToolStripMenuItem_Click);
            // 
            // informacjeToolStripMenuItem
            // 
            this.informacjeToolStripMenuItem.Name = "informacjeToolStripMenuItem";
            this.informacjeToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.informacjeToolStripMenuItem.Text = "Informacje";
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rozciaganieHistogramuToolStripMenuItem,
            this.rozciaganieHistogramuToolStripMenuItem1,
            this.wyrownanieHistogramuToolStripMenuItem});
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.histogramToolStripMenuItem.Text = "Histogram";
            // 
            // rozciaganieHistogramuToolStripMenuItem
            // 
            this.rozciaganieHistogramuToolStripMenuItem.Name = "rozciaganieHistogramuToolStripMenuItem";
            this.rozciaganieHistogramuToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.rozciaganieHistogramuToolStripMenuItem.Text = "Generuj histogram";
            this.rozciaganieHistogramuToolStripMenuItem.Click += new System.EventHandler(this.rozciaganieHistogramuToolStripMenuItem_Click);
            // 
            // rozciaganieHistogramuToolStripMenuItem1
            // 
            this.rozciaganieHistogramuToolStripMenuItem1.Name = "rozciaganieHistogramuToolStripMenuItem1";
            this.rozciaganieHistogramuToolStripMenuItem1.Size = new System.Drawing.Size(204, 22);
            this.rozciaganieHistogramuToolStripMenuItem1.Text = "Rozciaganie histogramu";
            this.rozciaganieHistogramuToolStripMenuItem1.Click += new System.EventHandler(this.rozciaganieHistogramuToolStripMenuItem1_Click);
            // 
            // wyrownanieHistogramuToolStripMenuItem
            // 
            this.wyrownanieHistogramuToolStripMenuItem.Name = "wyrownanieHistogramuToolStripMenuItem";
            this.wyrownanieHistogramuToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.wyrownanieHistogramuToolStripMenuItem.Text = "Wyrownanie histogramu";
            this.wyrownanieHistogramuToolStripMenuItem.Click += new System.EventHandler(this.wyrownanieHistogramuToolStripMenuItem_Click);
            // 
            // imageBox
            // 
            this.imageBox.Location = new System.Drawing.Point(12, 40);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(882, 520);
            this.imageBox.TabIndex = 2;
            this.imageBox.TabStop = false;
            // 
            // imageSharpeningToolStripMenuItem
            // 
            this.imageSharpeningToolStripMenuItem.Name = "imageSharpeningToolStripMenuItem";
            this.imageSharpeningToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.imageSharpeningToolStripMenuItem.Text = "Image sharpening";
            this.imageSharpeningToolStripMenuItem.Click += new System.EventHandler(this.imageSharpeningToolStripMenuItem_Click);
            // 
            // skeletonizationToolStripMenuItem
            // 
            this.skeletonizationToolStripMenuItem.Name = "skeletonizationToolStripMenuItem";
            this.skeletonizationToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.skeletonizationToolStripMenuItem.Text = "Skeletonization";
            this.skeletonizationToolStripMenuItem.Click += new System.EventHandler(this.skeletonizationToolStripMenuItem_Click);
            // 
            // posteryzacjaToolStripMenuItem
            // 
            this.posteryzacjaToolStripMenuItem.Name = "posteryzacjaToolStripMenuItem";
            this.posteryzacjaToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.posteryzacjaToolStripMenuItem.Text = "Posteryzacja";
            this.posteryzacjaToolStripMenuItem.Click += new System.EventHandler(this.posteryzacjaToolStripMenuItem_Click);
            // 
            // multilevelThresholdingToolStripMenuItem
            // 
            this.multilevelThresholdingToolStripMenuItem.Name = "multilevelThresholdingToolStripMenuItem";
            this.multilevelThresholdingToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.multilevelThresholdingToolStripMenuItem.Text = "Multi-level thresholding";
            this.multilevelThresholdingToolStripMenuItem.Click += new System.EventHandler(this.multilevelThresholdingToolStripMenuItem_Click);
            // 
            // nToolStripMenuItem
            // 
            this.nToolStripMenuItem.Name = "nToolStripMenuItem";
            this.nToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nToolStripMenuItem.Text = "N";
            // 
            // eToolStripMenuItem
            // 
            this.eToolStripMenuItem.Name = "eToolStripMenuItem";
            this.eToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eToolStripMenuItem.Text = "E";
            // 
            // wToolStripMenuItem
            // 
            this.wToolStripMenuItem.Name = "wToolStripMenuItem";
            this.wToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.wToolStripMenuItem.Text = "W";
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            this.sToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sToolStripMenuItem.Text = "S";
            // 
            // nEToolStripMenuItem
            // 
            this.nEToolStripMenuItem.Name = "nEToolStripMenuItem";
            this.nEToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nEToolStripMenuItem.Text = "NE";
            // 
            // nWToolStripMenuItem
            // 
            this.nWToolStripMenuItem.Name = "nWToolStripMenuItem";
            this.nWToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nWToolStripMenuItem.Text = "NW";
            // 
            // sEToolStripMenuItem
            // 
            this.sEToolStripMenuItem.Name = "sEToolStripMenuItem";
            this.sEToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sEToolStripMenuItem.Text = "SE";
            // 
            // sWToolStripMenuItem
            // 
            this.sWToolStripMenuItem.Name = "sWToolStripMenuItem";
            this.sWToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sWToolStripMenuItem.Text = "SW";
            // 
            // APO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 572);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.menuStrip1);
            this.Name = "APO";
            this.Text = "APO";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zachowajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operacjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informacjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszJakoToolStripMenuItem;
        private System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.ToolStripMenuItem greyscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem gaussianblurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rozciaganieHistogramuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rozciaganieHistogramuToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem invertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thresholdingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reduceGrayLevelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edgeDetectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem directionalEdgeDetectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previttToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medianFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operatonsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otsuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaptiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thresholdingToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem watershedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem morphologyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erosionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dilationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topHatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackHatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyrownanieHistogramuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageSharpeningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skeletonizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem posteryzacjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multilevelThresholdingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sWToolStripMenuItem;
    }
}

