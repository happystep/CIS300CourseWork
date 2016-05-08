namespace Ksu.Cis300.NameLookup
{
    partial class UserInterface
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
            this.uxOpen = new System.Windows.Forms.Button();
            this.uxRank = new System.Windows.Forms.TextBox();
            this.uxRankLabel = new System.Windows.Forms.Label();
            this.uxFrequency = new System.Windows.Forms.TextBox();
            this.uxFrequencyLabel = new System.Windows.Forms.Label();
            this.uxLookup = new System.Windows.Forms.Button();
            this.uxName = new System.Windows.Forms.TextBox();
            this.uxNameLabel = new System.Windows.Forms.Label();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxPanel1 = new System.Windows.Forms.Panel();
            this.uxSort = new System.Windows.Forms.Button();
            this.uxPanel2 = new System.Windows.Forms.Panel();
            this.uxLetterResult = new System.Windows.Forms.TextBox();
            this.uxLetterCount = new System.Windows.Forms.Button();
            this.uxLetter = new System.Windows.Forms.TextBox();
            this.uxCommonText = new System.Windows.Forms.TextBox();
            this.uxLetterLabel = new System.Windows.Forms.Label();
            this.uxCommonLetter = new System.Windows.Forms.Button();
            this.uxSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.uxPanel1.SuspendLayout();
            this.uxPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxOpen
            // 
            this.uxOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxOpen.Location = new System.Drawing.Point(33, 31);
            this.uxOpen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxOpen.Name = "uxOpen";
            this.uxOpen.Size = new System.Drawing.Size(465, 63);
            this.uxOpen.TabIndex = 31;
            this.uxOpen.Text = "Open Data File";
            this.uxOpen.UseVisualStyleBackColor = true;
            this.uxOpen.Click += new System.EventHandler(this.uxOpen_Click);
            // 
            // uxRank
            // 
            this.uxRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxRank.Location = new System.Drawing.Point(123, 283);
            this.uxRank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxRank.Name = "uxRank";
            this.uxRank.ReadOnly = true;
            this.uxRank.Size = new System.Drawing.Size(373, 40);
            this.uxRank.TabIndex = 30;
            this.uxRank.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uxRankLabel
            // 
            this.uxRankLabel.AutoSize = true;
            this.uxRankLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxRankLabel.Location = new System.Drawing.Point(27, 288);
            this.uxRankLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uxRankLabel.Name = "uxRankLabel";
            this.uxRankLabel.Size = new System.Drawing.Size(91, 33);
            this.uxRankLabel.TabIndex = 29;
            this.uxRankLabel.Text = "Rank:";
            // 
            // uxFrequency
            // 
            this.uxFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxFrequency.Location = new System.Drawing.Point(196, 229);
            this.uxFrequency.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxFrequency.Name = "uxFrequency";
            this.uxFrequency.ReadOnly = true;
            this.uxFrequency.Size = new System.Drawing.Size(300, 40);
            this.uxFrequency.TabIndex = 28;
            this.uxFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uxFrequencyLabel
            // 
            this.uxFrequencyLabel.AutoSize = true;
            this.uxFrequencyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxFrequencyLabel.Location = new System.Drawing.Point(27, 234);
            this.uxFrequencyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uxFrequencyLabel.Name = "uxFrequencyLabel";
            this.uxFrequencyLabel.Size = new System.Drawing.Size(161, 33);
            this.uxFrequencyLabel.TabIndex = 27;
            this.uxFrequencyLabel.Text = "Frequency:";
            // 
            // uxLookup
            // 
            this.uxLookup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLookup.Location = new System.Drawing.Point(33, 157);
            this.uxLookup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxLookup.Name = "uxLookup";
            this.uxLookup.Size = new System.Drawing.Size(465, 63);
            this.uxLookup.TabIndex = 26;
            this.uxLookup.Text = "Get Statistics";
            this.uxLookup.UseVisualStyleBackColor = true;
            this.uxLookup.Click += new System.EventHandler(this.uxLookup_Click);
            // 
            // uxName
            // 
            this.uxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxName.Location = new System.Drawing.Point(135, 103);
            this.uxName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxName.Name = "uxName";
            this.uxName.Size = new System.Drawing.Size(361, 40);
            this.uxName.TabIndex = 25;
            // 
            // uxNameLabel
            // 
            this.uxNameLabel.AutoSize = true;
            this.uxNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxNameLabel.Location = new System.Drawing.Point(27, 108);
            this.uxNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uxNameLabel.Name = "uxNameLabel";
            this.uxNameLabel.Size = new System.Drawing.Size(101, 33);
            this.uxNameLabel.TabIndex = 24;
            this.uxNameLabel.Text = "Name:";
            // 
            // uxPanel1
            // 
            this.uxPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.uxPanel1.Controls.Add(this.uxSort);
            this.uxPanel1.Location = new System.Drawing.Point(14, 12);
            this.uxPanel1.Name = "uxPanel1";
            this.uxPanel1.Size = new System.Drawing.Size(500, 418);
            this.uxPanel1.TabIndex = 32;
            // 
            // uxSort
            // 
            this.uxSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxSort.Location = new System.Drawing.Point(16, 335);
            this.uxSort.Name = "uxSort";
            this.uxSort.Size = new System.Drawing.Size(465, 63);
            this.uxSort.TabIndex = 0;
            this.uxSort.Text = "Output Sorted File";
            this.uxSort.UseVisualStyleBackColor = true;
            this.uxSort.Click += new System.EventHandler(this.uxSort_Click);
            // 
            // uxPanel2
            // 
            this.uxPanel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.uxPanel2.Controls.Add(this.uxLetterResult);
            this.uxPanel2.Controls.Add(this.uxLetterCount);
            this.uxPanel2.Controls.Add(this.uxLetter);
            this.uxPanel2.Controls.Add(this.uxCommonText);
            this.uxPanel2.Controls.Add(this.uxLetterLabel);
            this.uxPanel2.Controls.Add(this.uxCommonLetter);
            this.uxPanel2.Location = new System.Drawing.Point(520, 12);
            this.uxPanel2.Name = "uxPanel2";
            this.uxPanel2.Size = new System.Drawing.Size(398, 418);
            this.uxPanel2.TabIndex = 33;
            // 
            // uxLetterResult
            // 
            this.uxLetterResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLetterResult.Location = new System.Drawing.Point(20, 153);
            this.uxLetterResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxLetterResult.Multiline = true;
            this.uxLetterResult.Name = "uxLetterResult";
            this.uxLetterResult.Size = new System.Drawing.Size(357, 82);
            this.uxLetterResult.TabIndex = 6;
            // 
            // uxLetterCount
            // 
            this.uxLetterCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLetterCount.Location = new System.Drawing.Point(18, 77);
            this.uxLetterCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxLetterCount.Name = "uxLetterCount";
            this.uxLetterCount.Size = new System.Drawing.Size(359, 62);
            this.uxLetterCount.TabIndex = 5;
            this.uxLetterCount.Text = "Count Names with Letter";
            this.uxLetterCount.UseVisualStyleBackColor = true;
            this.uxLetterCount.Click += new System.EventHandler(this.uxLetterCount_Click);
            // 
            // uxLetter
            // 
            this.uxLetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLetter.Location = new System.Drawing.Point(165, 18);
            this.uxLetter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxLetter.Name = "uxLetter";
            this.uxLetter.Size = new System.Drawing.Size(212, 40);
            this.uxLetter.TabIndex = 4;
            // 
            // uxCommonText
            // 
            this.uxCommonText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxCommonText.Location = new System.Drawing.Point(18, 323);
            this.uxCommonText.Multiline = true;
            this.uxCommonText.Name = "uxCommonText";
            this.uxCommonText.Size = new System.Drawing.Size(359, 75);
            this.uxCommonText.TabIndex = 2;
            // 
            // uxLetterLabel
            // 
            this.uxLetterLabel.AutoSize = true;
            this.uxLetterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLetterLabel.Location = new System.Drawing.Point(14, 21);
            this.uxLetterLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uxLetterLabel.Name = "uxLetterLabel";
            this.uxLetterLabel.Size = new System.Drawing.Size(154, 33);
            this.uxLetterLabel.TabIndex = 3;
            this.uxLetterLabel.Text = "First letter:";
            // 
            // uxCommonLetter
            // 
            this.uxCommonLetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxCommonLetter.Location = new System.Drawing.Point(18, 243);
            this.uxCommonLetter.Name = "uxCommonLetter";
            this.uxCommonLetter.Size = new System.Drawing.Size(361, 65);
            this.uxCommonLetter.TabIndex = 1;
            this.uxCommonLetter.Text = "Find Most Common Letter";
            this.uxCommonLetter.UseVisualStyleBackColor = true;
            this.uxCommonLetter.Click += new System.EventHandler(this.uxCommonLetter_Click);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 442);
            this.Controls.Add(this.uxPanel2);
            this.Controls.Add(this.uxOpen);
            this.Controls.Add(this.uxRank);
            this.Controls.Add(this.uxRankLabel);
            this.Controls.Add(this.uxFrequency);
            this.Controls.Add(this.uxFrequencyLabel);
            this.Controls.Add(this.uxLookup);
            this.Controls.Add(this.uxName);
            this.Controls.Add(this.uxNameLabel);
            this.Controls.Add(this.uxPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "UserInterface";
            this.Text = "Name Lookup";
            this.uxPanel1.ResumeLayout(false);
            this.uxPanel2.ResumeLayout(false);
            this.uxPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxOpen;
        private System.Windows.Forms.TextBox uxRank;
        private System.Windows.Forms.Label uxRankLabel;
        private System.Windows.Forms.TextBox uxFrequency;
        private System.Windows.Forms.Label uxFrequencyLabel;
        private System.Windows.Forms.Button uxLookup;
        private System.Windows.Forms.TextBox uxName;
        private System.Windows.Forms.Label uxNameLabel;
        private System.Windows.Forms.OpenFileDialog uxOpenDialog;
        private System.Windows.Forms.Panel uxPanel1;
        private System.Windows.Forms.Panel uxPanel2;
        private System.Windows.Forms.TextBox uxCommonText;
        private System.Windows.Forms.Button uxCommonLetter;
        private System.Windows.Forms.Button uxSort;
        private System.Windows.Forms.SaveFileDialog uxSaveDialog;
        private System.Windows.Forms.TextBox uxLetterResult;
        private System.Windows.Forms.Button uxLetterCount;
        private System.Windows.Forms.TextBox uxLetter;
        private System.Windows.Forms.Label uxLetterLabel;
    }
}

