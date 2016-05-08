namespace Ksu.Cis300.Sort
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
            this.uxSort = new System.Windows.Forms.Button();
            this.uxSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // uxSort
            // 
            this.uxSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxSort.Location = new System.Drawing.Point(12, 12);
            this.uxSort.Name = "uxSort";
            this.uxSort.Size = new System.Drawing.Size(302, 40);
            this.uxSort.TabIndex = 6;
            this.uxSort.Text = "Sort File";
            this.uxSort.UseVisualStyleBackColor = true;
            this.uxSort.Click += new System.EventHandler(this.uxSort_Click);
            // 
            // uxSaveDialog
            // 
            this.uxSaveDialog.Filter = "Text files (*.txt)|*.txt";
            // 
            // uxOpenDialog
            // 
            this.uxOpenDialog.Filter = "Text files (*.txt)|*.txt";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 63);
            this.Controls.Add(this.uxSort);
            this.Name = "UserInterface";
            this.Text = "Sorter";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button uxSort;
        private System.Windows.Forms.SaveFileDialog uxSaveDialog;
        private System.Windows.Forms.OpenFileDialog uxOpenDialog;
    }
}

