/* UserInterface.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ksu.Cis300.TextEditor
{
    /// <summary>
    /// A GUI for a simple text editor.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles an "Open . . ." event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpen_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    uxDisplay.Text = File.ReadAllText(uxOpenDialog.FileName);
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        /// <summary>
        /// Handles a "Save As . . ." event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSaveAs_Click(object sender, EventArgs e)
        {
            if (uxSaveAsDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(uxSaveAsDialog.FileName, uxDisplay.Text);
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        /// <summary>
        /// Displays the given exception in an error message.
        /// </summary>
        /// <param name="e"></param>
        private void ShowError(Exception e)
        {
            MessageBox.Show("The following error occurred: " + e.ToString());
        }
    }
}
