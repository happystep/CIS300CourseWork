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
using Ksu.Cis300.Sort;
using KansasStateUniversity.TreeViewer2;
using Ksu.Cis300.ImmutableBinaryTrees;

namespace Ksu.Cis300.HuffmanTree
{
    /// <summary>
    /// A GUI for a program to construct and display Huffman trees.
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
        /// Handles a Click event on the "Select a File" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSelectFile_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BinaryTreeNode<byte> t = null;

                    t = BuildHuffmanTree(GetLeaves(BuildFrequencyTable(uxOpenDialog.FileName)));

                    new TreeForm(t, 100).Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Builds a frequency table for the given file.
        /// </summary>
        /// <param name="fn">The name of the file.</param>
        /// <returns>The frequency table.</returns>
        private long[] BuildFrequencyTable(string fn)
        {
            using (FileStream input = new FileStream(fn, FileMode.Open, FileAccess.Read))
            {
                long[] table = new long[256];
                int b;
                while ((b = input.ReadByte()) != -1)
                {
                    table[b]++;
                }
                return table;
            }
        }

        /// <summary>
        /// Constructs the leaves of a Huffman tree, together with their priorities, in a MinPriorityQueue.
        /// </summary>
        /// <param name="table">The frequency table.</param>
        /// <returns>A MinPriorityQueue containing the leaves.</returns>
        private MinPriorityQueue<long, BinaryTreeNode<byte>> GetLeaves(long[] table)
        {
            MinPriorityQueue<long, BinaryTreeNode<byte>> q = new MinPriorityQueue<long, BinaryTreeNode<byte>>();
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] != 0)
                {
                    q.Add(new BinaryTreeNode<byte>((byte)i, null, null), table[i]);
                }
            }
            return q;
        }

        /// <summary>
        /// Builds a Huffman tree from the given leaves.
        /// </summary>
        /// <param name="q">A MinPriorityQueue containing the leaves of the Huffman tree, with their frequencies as priorities.</param>
        /// <returns>The Huffman tree.</returns>
        private BinaryTreeNode<byte> BuildHuffmanTree(MinPriorityQueue<long, BinaryTreeNode<byte>> q)
        {
            while (q.Count > 1)
            {
                long p1 = q.MininumPriority;
                BinaryTreeNode<byte> t1 = q.RemoveMinimumPriority();
                long p2 = q.MininumPriority;
                BinaryTreeNode<byte> t2 = q.RemoveMinimumPriority();
                q.Add(new BinaryTreeNode<byte>(0, t1, t2), p1 + p2);
            }
            return q.RemoveMinimumPriority();
        }
    }
}
