namespace Omino
{
    partial class MainForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.blockCountBox = new System.Windows.Forms.NumericUpDown();
            this.blockSizeBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.heuristicRectangleButton = new System.Windows.Forms.Button();
            this.optimalRectangleButton = new System.Windows.Forms.Button();
            this.heuristicSquareButton = new System.Windows.Forms.Button();
            this.optimalSquareButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blockCountBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blockSizeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.blockCountBox);
            this.splitContainer1.Panel2.Controls.Add(this.blockSizeBox);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.heuristicRectangleButton);
            this.splitContainer1.Panel2.Controls.Add(this.optimalRectangleButton);
            this.splitContainer1.Panel2.Controls.Add(this.heuristicSquareButton);
            this.splitContainer1.Panel2.Controls.Add(this.optimalSquareButton);
            this.splitContainer1.Panel2.Controls.Add(this.generateButton);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 635;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point(3, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(629, 444);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // blockCountBox
            // 
            this.blockCountBox.Location = new System.Drawing.Point(28, 125);
            this.blockCountBox.Name = "blockCountBox";
            this.blockCountBox.Size = new System.Drawing.Size(120, 20);
            this.blockCountBox.TabIndex = 11;
            this.blockCountBox.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // blockSizeBox
            // 
            this.blockSizeBox.Location = new System.Drawing.Point(28, 86);
            this.blockSizeBox.Name = "blockSizeBox";
            this.blockSizeBox.Size = new System.Drawing.Size(120, 20);
            this.blockSizeBox.TabIndex = 10;
            this.blockSizeBox.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Blocks Count";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Block Size";
            // 
            // heuristicRectangleButton
            // 
            this.heuristicRectangleButton.Location = new System.Drawing.Point(14, 405);
            this.heuristicRectangleButton.Name = "heuristicRectangleButton";
            this.heuristicRectangleButton.Size = new System.Drawing.Size(134, 23);
            this.heuristicRectangleButton.TabIndex = 7;
            this.heuristicRectangleButton.Text = "Heuristic Rectangle";
            this.heuristicRectangleButton.UseVisualStyleBackColor = true;
            this.heuristicRectangleButton.Click += new System.EventHandler(this.heuristicRectangleButton_Click);
            // 
            // optimalRectangleButton
            // 
            this.optimalRectangleButton.Location = new System.Drawing.Point(15, 376);
            this.optimalRectangleButton.Name = "optimalRectangleButton";
            this.optimalRectangleButton.Size = new System.Drawing.Size(134, 23);
            this.optimalRectangleButton.TabIndex = 6;
            this.optimalRectangleButton.Text = "Optimal Rectangle";
            this.optimalRectangleButton.UseVisualStyleBackColor = true;
            this.optimalRectangleButton.Click += new System.EventHandler(this.optimalRectangleButton_Click);
            // 
            // heuristicSquareButton
            // 
            this.heuristicSquareButton.Location = new System.Drawing.Point(14, 347);
            this.heuristicSquareButton.Name = "heuristicSquareButton";
            this.heuristicSquareButton.Size = new System.Drawing.Size(134, 23);
            this.heuristicSquareButton.TabIndex = 5;
            this.heuristicSquareButton.Text = "Heuristic Square";
            this.heuristicSquareButton.UseVisualStyleBackColor = true;
            this.heuristicSquareButton.Click += new System.EventHandler(this.heuristicSquareButton_Click);
            // 
            // optimalSquareButton
            // 
            this.optimalSquareButton.Location = new System.Drawing.Point(14, 318);
            this.optimalSquareButton.Name = "optimalSquareButton";
            this.optimalSquareButton.Size = new System.Drawing.Size(134, 23);
            this.optimalSquareButton.TabIndex = 4;
            this.optimalSquareButton.Text = "Optimal Square";
            this.optimalSquareButton.UseVisualStyleBackColor = true;
            this.optimalSquareButton.Click += new System.EventHandler(this.optimalSquareButton_Click);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(42, 150);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 3;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "From File";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Omino";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blockCountBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blockSizeBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button heuristicRectangleButton;
        private System.Windows.Forms.Button optimalRectangleButton;
        private System.Windows.Forms.Button heuristicSquareButton;
        private System.Windows.Forms.Button optimalSquareButton;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown blockCountBox;
        private System.Windows.Forms.NumericUpDown blockSizeBox;
    }
}