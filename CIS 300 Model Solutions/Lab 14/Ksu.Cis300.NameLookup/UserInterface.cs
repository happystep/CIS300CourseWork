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
        private List<NameInformation> _names = new List<NameInformation>();

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
            int start = 0;
            int end = _names.Count;
            while (start < end)
            {
                int mid = (start + end) / 2;
                int comp = name.CompareTo(_names[mid].Name);
                if (comp == 0)
                {
                    uxFrequency.Text = _names[mid].Frequency.ToString();
                    uxRank.Text = _names[mid].Rank.ToString();
                    return;
                }
                else if (comp < 0)
                {
                    end = mid;
                }
                else
                {
                    start = mid + 1;
                }
            }
            MessageBox.Show("Name not found.");
            uxRank.Text = "";
            uxFrequency.Text = "";
        }

        /// <summary>
        /// Reads the given file and forms a list from its contents.
        /// </summary>
        /// <param name="fn">The name of the file.</param>
        /// <returns>The list containing all the name information.</returns>
        private List<NameInformation> GetAllInformation(string fn)
        {
            List<NameInformation> names = new List<NameInformation>();
            using (StreamReader input = new StreamReader(fn))
            {
                while (!input.EndOfStream)
                {
                    string name = input.ReadLine().Trim();
                    float freq = Convert.ToSingle(input.ReadLine());
                    int rank = Convert.ToInt32(input.ReadLine());
                    names.Add(new NameInformation(name, freq, rank));
                }
            }
            return names;
        }
    }
}
