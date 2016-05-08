namespace Ksu.Cis300.Boggle
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
            this.uxFindWords = new System.Windows.Forms.Button();
            this.uxNewBoard = new System.Windows.Forms.Button();
            this.uxWordsFound = new System.Windows.Forms.ListBox();
            this.uxWordsFoundLabel = new System.Windows.Forms.Label();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxBoard = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // uxFindWords
            // 
            this.uxFindWords.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.uxFindWords.Enabled = false;
            this.uxFindWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxFindWords.Location = new System.Drawing.Point(329, 461);
            this.uxFindWords.Name = "uxFindWords";
            this.uxFindWords.Size = new System.Drawing.Size(308, 44);
            this.uxFindWords.TabIndex = 19;
            this.uxFindWords.Text = "Find Words";
            this.uxFindWords.UseVisualStyleBackColor = true;
            this.uxFindWords.Click += new System.EventHandler(this.uxFindWords_Click);
            // 
            // uxNewBoard
            // 
            this.uxNewBoard.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.uxNewBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxNewBoard.Location = new System.Drawing.Point(15, 461);
            this.uxNewBoard.Name = "uxNewBoard";
            this.uxNewBoard.Size = new System.Drawing.Size(308, 44);
            this.uxNewBoard.TabIndex = 18;
            this.uxNewBoard.Text = "New Board";
            this.uxNewBoard.UseVisualStyleBackColor = true;
            this.uxNewBoard.Click += new System.EventHandler(this.uxNewBoard_Click);
            // 
            // uxWordsFound
            // 
            this.uxWordsFound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxWordsFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxWordsFound.FormattingEnabled = true;
            this.uxWordsFound.ItemHeight = 24;
            this.uxWordsFound.Location = new System.Drawing.Point(463, 67);
            this.uxWordsFound.Name = "uxWordsFound";
            this.uxWordsFound.Size = new System.Drawing.Size(174, 388);
            this.uxWordsFound.TabIndex = 17;
            // 
            // uxWordsFoundLabel
            // 
            this.uxWordsFoundLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uxWordsFoundLabel.AutoSize = true;
            this.uxWordsFoundLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxWordsFoundLabel.Location = new System.Drawing.Point(459, 40);
            this.uxWordsFoundLabel.Name = "uxWordsFoundLabel";
            this.uxWordsFoundLabel.Size = new System.Drawing.Size(131, 24);
            this.uxWordsFoundLabel.TabIndex = 16;
            this.uxWordsFoundLabel.Text = "Words Found:";
            // 
            // uxOpenDialog
            // 
            this.uxOpenDialog.Title = "Select Dictionary File";
            // 
            // uxBoard
            // 
            this.uxBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxBoard.Location = new System.Drawing.Point(15, 13);
            this.uxBoard.Name = "uxBoard";
            this.uxBoard.Size = new System.Drawing.Size(442, 442);
            this.uxBoard.TabIndex = 20;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 519);
            this.Controls.Add(this.uxFindWords);
            this.Controls.Add(this.uxNewBoard);
            this.Controls.Add(this.uxWordsFound);
            this.Controls.Add(this.uxWordsFoundLabel);
            this.Controls.Add(this.uxBoard);
            this.Name = "UserInterface";
            this.Text = "Boggle Deluxe";
            this.Load += new System.EventHandler(this.UserInterface_Load);
            this.Click += new System.EventHandler(this.UserInterface_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxFindWords;
        private System.Windows.Forms.Button uxNewBoard;
        private System.Windows.Forms.ListBox uxWordsFound;
        private System.Windows.Forms.Label uxWordsFoundLabel;
        private System.Windows.Forms.OpenFileDialog uxOpenDialog;
        private System.Windows.Forms.Panel uxBoard;
    }
}

