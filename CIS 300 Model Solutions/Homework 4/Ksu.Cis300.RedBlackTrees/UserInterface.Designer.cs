namespace Ksu.Cis300.RedBlackTrees
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
            this.uxAdd = new System.Windows.Forms.Button();
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
            this.uxRank.Location = new System.Drawing.Point(123, 213);
            this.uxRank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxRank.Name = "uxRank";
            this.uxRank.Size = new System.Drawing.Size(373, 40);
            this.uxRank.TabIndex = 30;
            this.uxRank.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uxRankLabel
            // 
            this.uxRankLabel.AutoSize = true;
            this.uxRankLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxRankLabel.Location = new System.Drawing.Point(27, 218);
            this.uxRankLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uxRankLabel.Name = "uxRankLabel";
            this.uxRankLabel.Size = new System.Drawing.Size(91, 33);
            this.uxRankLabel.TabIndex = 29;
            this.uxRankLabel.Text = "Rank:";
            // 
            // uxFrequency
            // 
            this.uxFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxFrequency.Location = new System.Drawing.Point(196, 159);
            this.uxFrequency.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxFrequency.Name = "uxFrequency";
            this.uxFrequency.Size = new System.Drawing.Size(300, 40);
            this.uxFrequency.TabIndex = 28;
            this.uxFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uxFrequencyLabel
            // 
            this.uxFrequencyLabel.AutoSize = true;
            this.uxFrequencyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxFrequencyLabel.Location = new System.Drawing.Point(27, 164);
            this.uxFrequencyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uxFrequencyLabel.Name = "uxFrequencyLabel";
            this.uxFrequencyLabel.Size = new System.Drawing.Size(161, 33);
            this.uxFrequencyLabel.TabIndex = 27;
            this.uxFrequencyLabel.Text = "Frequency:";
            // 
            // uxLookup
            // 
            this.uxLookup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLookup.Location = new System.Drawing.Point(33, 335);
            this.uxLookup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxLookup.Name = "uxLookup";
            this.uxLookup.Size = new System.Drawing.Size(465, 60);
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
            // uxAdd
            // 
            this.uxAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxAdd.Location = new System.Drawing.Point(33, 269);
            this.uxAdd.Name = "uxAdd";
            this.uxAdd.Size = new System.Drawing.Size(463, 58);
            this.uxAdd.TabIndex = 34;
            this.uxAdd.Text = "Add";
            this.uxAdd.UseVisualStyleBackColor = true;
            this.uxAdd.Click += new System.EventHandler(this.uxAdd_Click);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 419);
            this.Controls.Add(this.uxAdd);
            this.Controls.Add(this.uxOpen);
            this.Controls.Add(this.uxRank);
            this.Controls.Add(this.uxRankLabel);
            this.Controls.Add(this.uxFrequency);
            this.Controls.Add(this.uxFrequencyLabel);
            this.Controls.Add(this.uxLookup);
            this.Controls.Add(this.uxName);
            this.Controls.Add(this.uxNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "UserInterface";
            this.Text = "Name Lookup";
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
        private System.Windows.Forms.Button uxAdd;
    }
}

