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
using Ksu.Cis300.Graphs;
using System.IO;

namespace Ksu.Cis300.MaxOutgoingEdgeWeight
{
    /// <summary>
    /// A GUI for a program to compute the maximum sum of outgoing edge weights from any node in a graph.
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
        /// Handles a Click event on the "Read a File" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxRead_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    MessageBox.Show("Maximum sum of outgoing edges = " + FindMaxOutgoing(ReadGraph(uxOpenDialog.FileName)));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Reads the graph described in the given file.
        /// </summary>
        /// <param name="fn">The name of the file to read.</param>
        /// <returns>The graph encoded in the file.</returns>
        private DirectedGraph<string, decimal> ReadGraph(string fn)
        {
            DirectedGraph<string, decimal> graph = new DirectedGraph<string, decimal>();
            using (StreamReader input = new StreamReader(fn))
            {
                input.ReadLine();
                while (!input.EndOfStream)
                {
                    string line = input.ReadLine();
                    string[] fields = line.Split(',');
                    decimal weight = Convert.ToDecimal(fields[2]);
                    graph.AddEdge(fields[0], fields[1], weight);
                }
            }
            return graph;
        }

        /// <summary>
        /// Finds the maximum sum of outgoing edges from any node in the given graph.
        /// </summary>
        /// <param name="graph">The graph to search.</param>
        /// <returns>The maximum sum of outgoing edges.</returns>
        private decimal FindMaxOutgoing(DirectedGraph<string, decimal> graph)
        {
            decimal max = 0;
            foreach (string source in graph.Nodes)
            {
                decimal sum = 0;
                foreach (Tuple<string, decimal> t in graph.OutgoingEdges(source))
                {
                    sum += t.Item2;
                }
                if (sum > max)
                {
                    max = sum;
                }
            }
            return max;
        }
    }
}
