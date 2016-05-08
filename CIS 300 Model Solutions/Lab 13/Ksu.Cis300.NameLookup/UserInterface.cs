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

namespace Ksu.Cis300.NameLookup
{
    /// <summary>
    /// A GUI for a program that retrieves information about last names in
    /// a sample of US data.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The information on all the names.
        /// </summary>
        private LinkedListCell<NameInformation> _names;

        /// <summary>
        /// Constructs a new GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles a Click event on the Open Data File button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpen_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _names = GetAllInformation(uxOpenDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Handles a Click event on the Get Statistics button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLookup_Click(object sender, EventArgs e)
        {
            string name = uxName.Text.Trim().ToUpper();
            LinkedListCell<NameInformation> p = _names;
            while (p != null)
            {
                if (p.Data.Name == name)
                {
                    uxFrequency.Text = p.Data.Frequency.ToString();
                    uxRank.Text = p.Data.Rank.ToString();
                    return;
                }
                p = p.Next;
            }
            MessageBox.Show("Name not found.");
            uxRank.Text = "";
            uxFrequency.Text = "";
        }

        /// <summary>
        /// Reads the given file and forms a linked list from its contents.
        /// </summary>
        /// <param name="fn">The name of the file.</param>
        /// <returns>The linked list containing all the name information.</returns>
        private LinkedListCell<NameInformation> GetAllInformation(string fn)
        {
            LinkedListCell<NameInformation> names = null;
            using (StreamReader input = new StreamReader(fn))
            {
                while (!input.EndOfStream)
                {
                    string name = input.ReadLine().Trim();
                    float freq = Convert.ToSingle(input.ReadLine());
                    int rank = Convert.ToInt32(input.ReadLine());
                    LinkedListCell<NameInformation> cell = new LinkedListCell<NameInformation>();
                    cell.Data = new NameInformation(name, freq, rank);
                    cell.Next = names;
                    names = cell;
                }
            }
            return names;
        }
    }
}
