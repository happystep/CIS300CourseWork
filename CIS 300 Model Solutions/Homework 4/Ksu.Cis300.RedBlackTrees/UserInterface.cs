/* UserInterface.cs
 * Author: Rod Howell 
 * Edited by: Julie Thornton
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
using KansasStateUniversity.TreeViewer2;
using System.Reflection;

namespace Ksu.Cis300.RedBlackTrees
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
        private RedBlackTree<NameInformation> _names = new RedBlackTree<NameInformation>();

        /// <summary>
        /// Constructs a new GUI.
        /// </summary>
        public UserInterface()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string resourceName = new AssemblyName(args.Name).Name + ".dll";
                //MessageBox.Show(resourceName);
                string resource = Array.Find(this.GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
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
                    _names.DrawTree();
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
            NameInformation info = _names.Contains(new NameInformation(name,0,0));
            if (info.Name == null)
            {
                MessageBox.Show("Name not found.");
                uxRank.Text = "";
                uxFrequency.Text = "";
            }
            else
            {
                uxFrequency.Text = info.Frequency.ToString();
                uxRank.Text = info.Rank.ToString();
                return;
            }
        }

        /// <summary>
        /// Reads the given file and forms a binary search tree from its contents.
        /// </summary>
        /// <param name="fn">The name of the file.</param>
        /// <returns>The binary search tree containing all the name information.</returns>
        private RedBlackTree<NameInformation> GetAllInformation(string fn)
        {
            RedBlackTree<NameInformation> names = new RedBlackTree<NameInformation>();
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

        /// <summary>
        /// Handles a click of the Add button to add a new NameInformation object to the tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = uxName.Text.Trim().ToUpper();
                float freq = Convert.ToSingle(uxFrequency.Text);
                int rank = Convert.ToInt32(uxRank.Text);

                NameInformation data = new NameInformation(name, freq, rank);
                _names.Add(data);

                _names.DrawTree();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
