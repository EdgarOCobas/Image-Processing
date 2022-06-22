namespace Projekt_APO_2022
{
    partial class Operations
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
            this.loadBtn1 = new System.Windows.Forms.Button();
            this.loadBtn2 = new System.Windows.Forms.Button();
            this.andBtn = new System.Windows.Forms.Button();
            this.notBtn = new System.Windows.Forms.Button();
            this.orBtn = new System.Windows.Forms.Button();
            this.xorBtn = new System.Windows.Forms.Button();
            this.blendBtn = new System.Windows.Forms.Button();
            this.subtractBtn = new System.Windows.Forms.Button();
            this.picBox1 = new System.Windows.Forms.PictureBox();
            this.picBox2 = new System.Windows.Forms.PictureBox();
            this.picBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // loadBtn1
            // 
            this.loadBtn1.Location = new System.Drawing.Point(37, 377);
            this.loadBtn1.Name = "loadBtn1";
            this.loadBtn1.Size = new System.Drawing.Size(75, 23);
            this.loadBtn1.TabIndex = 3;
            this.loadBtn1.Text = "Load";
            this.loadBtn1.UseVisualStyleBackColor = true;
            this.loadBtn1.Click += new System.EventHandler(this.loadBtn1_Click);
            // 
            // loadBtn2
            // 
            this.loadBtn2.Location = new System.Drawing.Point(327, 377);
            this.loadBtn2.Name = "loadBtn2";
            this.loadBtn2.Size = new System.Drawing.Size(75, 23);
            this.loadBtn2.TabIndex = 4;
            this.loadBtn2.Text = "Load";
            this.loadBtn2.UseVisualStyleBackColor = true;
            this.loadBtn2.Click += new System.EventHandler(this.loadBtn2_Click);
            // 
            // andBtn
            // 
            this.andBtn.Location = new System.Drawing.Point(648, 126);
            this.andBtn.Name = "andBtn";
            this.andBtn.Size = new System.Drawing.Size(75, 23);
            this.andBtn.TabIndex = 5;
            this.andBtn.Text = "AND";
            this.andBtn.UseVisualStyleBackColor = true;
            this.andBtn.Click += new System.EventHandler(this.andBtn_Click);
            // 
            // notBtn
            // 
            this.notBtn.Location = new System.Drawing.Point(648, 169);
            this.notBtn.Name = "notBtn";
            this.notBtn.Size = new System.Drawing.Size(75, 23);
            this.notBtn.TabIndex = 6;
            this.notBtn.Text = "NOT";
            this.notBtn.UseVisualStyleBackColor = true;
            this.notBtn.Click += new System.EventHandler(this.notBtn_Click);
            // 
            // orBtn
            // 
            this.orBtn.Location = new System.Drawing.Point(648, 209);
            this.orBtn.Name = "orBtn";
            this.orBtn.Size = new System.Drawing.Size(75, 23);
            this.orBtn.TabIndex = 7;
            this.orBtn.Text = "OR";
            this.orBtn.UseVisualStyleBackColor = true;
            this.orBtn.Click += new System.EventHandler(this.orBtn_Click);
            // 
            // xorBtn
            // 
            this.xorBtn.Location = new System.Drawing.Point(648, 254);
            this.xorBtn.Name = "xorBtn";
            this.xorBtn.Size = new System.Drawing.Size(75, 23);
            this.xorBtn.TabIndex = 8;
            this.xorBtn.Text = "XOR";
            this.xorBtn.UseVisualStyleBackColor = true;
            this.xorBtn.Click += new System.EventHandler(this.xorBtn_Click);
            // 
            // blendBtn
            // 
            this.blendBtn.Location = new System.Drawing.Point(633, 353);
            this.blendBtn.Name = "blendBtn";
            this.blendBtn.Size = new System.Drawing.Size(107, 23);
            this.blendBtn.TabIndex = 9;
            this.blendBtn.Text = "Blend";
            this.blendBtn.UseVisualStyleBackColor = true;
            this.blendBtn.Click += new System.EventHandler(this.blendBtn_Click);
            // 
            // subtractBtn
            // 
            this.subtractBtn.Location = new System.Drawing.Point(633, 397);
            this.subtractBtn.Name = "subtractBtn";
            this.subtractBtn.Size = new System.Drawing.Size(107, 23);
            this.subtractBtn.TabIndex = 10;
            this.subtractBtn.Text = "Add";
            this.subtractBtn.UseVisualStyleBackColor = true;
            this.subtractBtn.Click += new System.EventHandler(this.subtractBtn_Click);
            // 
            // picBox1
            // 
            this.picBox1.Location = new System.Drawing.Point(12, 61);
            this.picBox1.Name = "picBox1";
            this.picBox1.Size = new System.Drawing.Size(261, 262);
            this.picBox1.TabIndex = 11;
            this.picBox1.TabStop = false;
            // 
            // picBox2
            // 
            this.picBox2.Location = new System.Drawing.Point(327, 61);
            this.picBox2.Name = "picBox2";
            this.picBox2.Size = new System.Drawing.Size(261, 262);
            this.picBox2.TabIndex = 12;
            this.picBox2.TabStop = false;
            // 
            // picBox3
            // 
            this.picBox3.Location = new System.Drawing.Point(787, 61);
            this.picBox3.Name = "picBox3";
            this.picBox3.Size = new System.Drawing.Size(261, 262);
            this.picBox3.TabIndex = 13;
            this.picBox3.TabStop = false;
            // 
            // Operations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 538);
            this.Controls.Add(this.picBox3);
            this.Controls.Add(this.picBox2);
            this.Controls.Add(this.picBox1);
            this.Controls.Add(this.subtractBtn);
            this.Controls.Add(this.blendBtn);
            this.Controls.Add(this.xorBtn);
            this.Controls.Add(this.orBtn);
            this.Controls.Add(this.notBtn);
            this.Controls.Add(this.andBtn);
            this.Controls.Add(this.loadBtn2);
            this.Controls.Add(this.loadBtn1);
            this.Name = "Operations";
            this.Text = "Operations";
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private OpenCvSharp.UserInterface.PictureBoxIpl picBox1;
        //private OpenCvSharp.UserInterface.PictureBoxIpl picBox2;
        //private OpenCvSharp.UserInterface.PictureBoxIpl picBox3;
        private System.Windows.Forms.Button loadBtn1;
        private System.Windows.Forms.Button loadBtn2;
        private System.Windows.Forms.Button andBtn;
        private System.Windows.Forms.Button notBtn;
        private System.Windows.Forms.Button orBtn;
        private System.Windows.Forms.Button xorBtn;
        private System.Windows.Forms.Button blendBtn;
        private System.Windows.Forms.Button subtractBtn;
        private System.Windows.Forms.PictureBox picBox1;
        private System.Windows.Forms.PictureBox picBox2;
        private System.Windows.Forms.PictureBox picBox3;
    }
}