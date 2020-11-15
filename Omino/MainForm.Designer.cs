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
            this.deleteButton = new System.Windows.Forms.Button();
            this.addBlock = new System.Windows.Forms.Button();
            this.labelInfo2 = new System.Windows.Forms.Label();
            this.labelInfo1 = new System.Windows.Forms.Label();
            this.blockCountBox = new System.Windows.Forms.NumericUpDown();
            this.blockSizeBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.heuristicRectangleButton = new System.Windows.Forms.Button();
            this.optimalRectangleButton = new System.Windows.Forms.Button();
            this.heuristicSquareButton = new System.Windows.Forms.Button();
            this.optimalSquareButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.fromFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.blockCountBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.blockSizeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.splitContainer1.Panel2.Controls.Add(this.deleteButton);
            this.splitContainer1.Panel2.Controls.Add(this.addBlock);
            this.splitContainer1.Panel2.Controls.Add(this.labelInfo2);
            this.splitContainer1.Panel2.Controls.Add(this.labelInfo1);
            this.splitContainer1.Panel2.Controls.Add(this.blockCountBox);
            this.splitContainer1.Panel2.Controls.Add(this.blockSizeBox);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.heuristicRectangleButton);
            this.splitContainer1.Panel2.Controls.Add(this.optimalRectangleButton);
            this.splitContainer1.Panel2.Controls.Add(this.heuristicSquareButton);
            this.splitContainer1.Panel2.Controls.Add(this.optimalSquareButton);
            this.splitContainer1.Panel2.Controls.Add(this.generateButton);
            this.splitContainer1.Panel2.Controls.Add(this.fromFile);
            this.splitContainer1.Size = new System.Drawing.Size(1262, 771);
            this.splitContainer1.SplitterDistance = 928;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.MidnightBlue;
            this.pictureBox.Location = new System.Drawing.Point(6, 6);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(629, 444);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.deleteButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.deleteButton.Location = new System.Drawing.Point(85, 385);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(6);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(150, 46);
            this.deleteButton.TabIndex = 15;
            this.deleteButton.Text = "Delete Last";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addBlock
            // 
            this.addBlock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addBlock.BackColor = System.Drawing.Color.MidnightBlue;
            this.addBlock.Location = new System.Drawing.Point(85, 327);
            this.addBlock.Margin = new System.Windows.Forms.Padding(6);
            this.addBlock.Name = "addBlock";
            this.addBlock.Size = new System.Drawing.Size(150, 46);
            this.addBlock.TabIndex = 14;
            this.addBlock.Text = "Add Blocks";
            this.addBlock.UseVisualStyleBackColor = false;
            this.addBlock.Click += new System.EventHandler(this.addBlock_Click);
            // 
            // labelInfo2
            // 
            this.labelInfo2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelInfo2.AutoSize = true;
            this.labelInfo2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelInfo2.Location = new System.Drawing.Point(53, 498);
            this.labelInfo2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelInfo2.Name = "labelInfo2";
            this.labelInfo2.Size = new System.Drawing.Size(0, 27);
            this.labelInfo2.TabIndex = 13;
            // 
            // labelInfo1
            // 
            this.labelInfo1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelInfo1.AutoSize = true;
            this.labelInfo1.BackColor = System.Drawing.Color.DodgerBlue;
            this.labelInfo1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelInfo1.Location = new System.Drawing.Point(53, 446);
            this.labelInfo1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelInfo1.Name = "labelInfo1";
            this.labelInfo1.Size = new System.Drawing.Size(0, 27);
            this.labelInfo1.TabIndex = 12;
            // 
            // blockCountBox
            // 
            this.blockCountBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.blockCountBox.BackColor = System.Drawing.Color.MidnightBlue;
            this.blockCountBox.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.blockCountBox.Location = new System.Drawing.Point(38, 204);
            this.blockCountBox.Margin = new System.Windows.Forms.Padding(6);
            this.blockCountBox.Name = "blockCountBox";
            this.blockCountBox.Size = new System.Drawing.Size(240, 34);
            this.blockCountBox.TabIndex = 11;
            this.blockCountBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.blockCountBox.Value = new decimal(new int[] {5, 0, 0, 0});
            // 
            // blockSizeBox
            // 
            this.blockSizeBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.blockSizeBox.BackColor = System.Drawing.Color.MidnightBlue;
            this.blockSizeBox.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.blockSizeBox.Location = new System.Drawing.Point(38, 123);
            this.blockSizeBox.Margin = new System.Windows.Forms.Padding(6);
            this.blockSizeBox.Name = "blockSizeBox";
            this.blockSizeBox.Size = new System.Drawing.Size(240, 34);
            this.blockSizeBox.TabIndex = 10;
            this.blockSizeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.blockSizeBox.Value = new decimal(new int[] {6, 0, 0, 0});
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(30, 169);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 27);
            this.label2.TabIndex = 9;
            this.label2.Text = "Blocks Count";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(30, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 27);
            this.label1.TabIndex = 8;
            this.label1.Text = "Block Size";
            // 
            // heuristicRectangleButton
            // 
            this.heuristicRectangleButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.heuristicRectangleButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.heuristicRectangleButton.Location = new System.Drawing.Point(30, 711);
            this.heuristicRectangleButton.Margin = new System.Windows.Forms.Padding(6);
            this.heuristicRectangleButton.Name = "heuristicRectangleButton";
            this.heuristicRectangleButton.Size = new System.Drawing.Size(268, 48);
            this.heuristicRectangleButton.TabIndex = 7;
            this.heuristicRectangleButton.Text = "Heuristic Rectangle";
            this.heuristicRectangleButton.UseVisualStyleBackColor = false;
            this.heuristicRectangleButton.Click += new System.EventHandler(this.heuristicRectangleButton_Click);
            // 
            // optimalRectangleButton
            // 
            this.optimalRectangleButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.optimalRectangleButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.optimalRectangleButton.Location = new System.Drawing.Point(30, 651);
            this.optimalRectangleButton.Margin = new System.Windows.Forms.Padding(6);
            this.optimalRectangleButton.Name = "optimalRectangleButton";
            this.optimalRectangleButton.Size = new System.Drawing.Size(268, 48);
            this.optimalRectangleButton.TabIndex = 6;
            this.optimalRectangleButton.Text = "Optimal Rectangle";
            this.optimalRectangleButton.UseVisualStyleBackColor = false;
            this.optimalRectangleButton.Click += new System.EventHandler(this.optimalRectangleButton_Click);
            // 
            // heuristicSquareButton
            // 
            this.heuristicSquareButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.heuristicSquareButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.heuristicSquareButton.Location = new System.Drawing.Point(30, 593);
            this.heuristicSquareButton.Margin = new System.Windows.Forms.Padding(6);
            this.heuristicSquareButton.Name = "heuristicSquareButton";
            this.heuristicSquareButton.Size = new System.Drawing.Size(268, 48);
            this.heuristicSquareButton.TabIndex = 5;
            this.heuristicSquareButton.Text = "Heuristic Square";
            this.heuristicSquareButton.UseVisualStyleBackColor = false;
            this.heuristicSquareButton.Click += new System.EventHandler(this.heuristicSquareButton_Click);
            // 
            // optimalSquareButton
            // 
            this.optimalSquareButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.optimalSquareButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.optimalSquareButton.Location = new System.Drawing.Point(30, 531);
            this.optimalSquareButton.Margin = new System.Windows.Forms.Padding(6);
            this.optimalSquareButton.Name = "optimalSquareButton";
            this.optimalSquareButton.Size = new System.Drawing.Size(268, 48);
            this.optimalSquareButton.TabIndex = 4;
            this.optimalSquareButton.Text = "Optimal Square";
            this.optimalSquareButton.UseVisualStyleBackColor = false;
            this.optimalSquareButton.Click += new System.EventHandler(this.optimalSquareButton_Click);
            // 
            // generateButton
            // 
            this.generateButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.generateButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.generateButton.Location = new System.Drawing.Point(85, 267);
            this.generateButton.Margin = new System.Windows.Forms.Padding(6);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(150, 48);
            this.generateButton.TabIndex = 3;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = false;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // fromFile
            // 
            this.fromFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fromFile.BackColor = System.Drawing.Color.MidnightBlue;
            this.fromFile.Location = new System.Drawing.Point(83, 17);
            this.fromFile.Margin = new System.Windows.Forms.Padding(6);
            this.fromFile.Name = "fromFile";
            this.fromFile.Size = new System.Drawing.Size(150, 48);
            this.fromFile.TabIndex = 0;
            this.fromFile.Text = "From File";
            this.fromFile.UseVisualStyleBackColor = false;
            this.fromFile.Click += new System.EventHandler(this.fromFileButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1262, 771);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 14.25F,
                ((System.Drawing.FontStyle) ((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))),
                System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainForm";
            this.Text = "Omino";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.blockCountBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.blockSizeBox)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button fromFile;

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
        private System.Windows.Forms.NumericUpDown blockCountBox;
        private System.Windows.Forms.NumericUpDown blockSizeBox;
        private System.Windows.Forms.Label labelInfo2;
        private System.Windows.Forms.Label labelInfo1;
        private System.Windows.Forms.Button addBlock;
        private System.Windows.Forms.Button deleteButton;
    }
}