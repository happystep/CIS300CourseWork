namespace Ksu.Cis300.TextAnalyzer
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
            this.uxSelectText1 = new System.Windows.Forms.Button();
            this.uxText1 = new System.Windows.Forms.TextBox();
            this.uxSelectText2 = new System.Windows.Forms.Button();
            this.uxText2 = new System.Windows.Forms.TextBox();
            this.uxAnalyze = new System.Windows.Forms.Button();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // uxSelectText1
            // 
            this.uxSelectText1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxSelectText1.Location = new System.Drawing.Point(12, 12);
            this.uxSelectText1.Name = "uxSelectText1";
            this.uxSelectText1.Size = new System.Drawing.Size(107, 42);
            this.uxSelectText1.TabIndex = 0;
            this.uxSelectText1.Text = "Text 1:";
            this.uxSelectText1.UseVisualStyleBackColor = true;
            this.uxSelectText1.Click += new System.EventHandler(this.uxSelectText1_Click);
            // 
            // uxText1
            // 
            this.uxText1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxText1.Location = new System.Drawing.Point(125, 18);
            this.uxText1.Name = "uxText1";
            this.uxText1.ReadOnly = true;
            this.uxText1.Size = new System.Drawing.Size(472, 29);
            this.uxText1.TabIndex = 1;
            // 
            // uxSelectText2
            // 
            this.uxSelectText2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxSelectText2.Location = new System.Drawing.Point(12, 60);
            this.uxSelectText2.Name = "uxSelectText2";
            this.uxSelectText2.Size = new System.Drawing.Size(107, 42);
            this.uxSelectText2.TabIndex = 2;
            this.uxSelectText2.Text = "Text 2:";
            this.uxSelectText2.UseVisualStyleBackColor = true;
            this.uxSelectText2.Click += new System.EventHandler(this.uxSelectText2_Click);
            // 
            // uxText2
            // 
            this.uxText2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxText2.Location = new System.Drawing.Point(125, 66);
            this.uxText2.Name = "uxText2";
            this.uxText2.ReadOnly = true;
            this.uxText2.Size = new System.Drawing.Size(472, 29);
            this.uxText2.TabIndex = 3;
            // 
            // uxAnalyze
            // 
            this.uxAnalyze.Enabled = false;
            this.uxAnalyze.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxAnalyze.Location = new System.Drawing.Point(12, 108);
            this.uxAnalyze.Name = "uxAnalyze";
            this.uxAnalyze.Size = new System.Drawing.Size(585, 42);
            this.uxAnalyze.TabIndex = 4;
            this.uxAnalyze.Text = "Analyze Texts";
            this.uxAnalyze.UseVisualStyleBackColor = true;
            this.uxAnalyze.Click += new System.EventHandler(this.uxAnalyze_Click);
            // 
            // uxOpenDialog
            // 
            this.uxOpenDialog.Filter = "Text files|*.txt|All files|*.*";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 165);
            this.Controls.Add(this.uxAnalyze);
            this.Controls.Add(this.uxText2);
            this.Controls.Add(this.uxSelectText2);
            this.Controls.Add(this.uxText1);
            this.Controls.Add(this.uxSelectText1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "UserInterface";
            this.Text = "Text Analyzer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxSelectText1;
        private System.Windows.Forms.TextBox uxText1;
        private System.Windows.Forms.Button uxSelectText2;
        private System.Windows.Forms.TextBox uxText2;
        private System.Windows.Forms.Button uxAnalyze;
        private System.Windows.Forms.OpenFileDialog uxOpenDialog;
    }
}

