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

namespace Ksu.Cis300.Sort
{
    /// <summary>
    /// A GUI for a simple sorting program.
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
        /// Handles a Click event on the "Sort File" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSort_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK && uxSaveDialog.ShowDialog() == DialogResult.OK)
            {
                List<int> values = new List<int>();
                try
                {
                    using (StreamReader input = new StreamReader(uxOpenDialog.FileName))
                    {
                        while (!input.EndOfStream)
                        {
                            int value = Convert.ToInt32(input.ReadLine());
                            values.Add(value);
                        }
                    }
                    Sort(values);
                    using (StreamWriter output = new StreamWriter(uxSaveDialog.FileName))
                    {
                        foreach (int i in values)
                        {
                            output.WriteLine("{0,10:D}", i);
                        }
                    }
                    MessageBox.Show("Sorting complete.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.ToString());
                }
            }
        }

        /// <summary>
        /// Swaps the values at the given locations in the given IList.
        /// </summary>
        /// <param name="list">The list of values.</param>
        /// <param name="i">The first location.</param>
        /// <param name="j">The second location.</param>
        private void Swap(IList<int> list, int i, int j)
        {
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        /// <summary>
        /// Sorts the given IList.
        /// </summary>
        /// <param name="list">The values to sort.</param>
        private void Sort(IList<int> list)
        {
            Sort(list, 0, list.Count);
        }

        /// <summary>
        /// Merges the two given sorted portions of the given list into a single sorted portion. The sorted
        /// portions are consecutive.
        /// </summary>
        /// <param name="list">The list to merge.</param>
        /// <param name="start">The first index of the first sorted portion.</param>
        /// <param name="len1">The length of the first sorted portion.</param>
        /// <param name="len2">The length of the second sorted portion.</param>
        private void Merge(IList<int> list, int start, int len1, int len2)
        {
            int n = len1 + len2;
            int[] merged = new int[n];
            int next1 = start;
            int next2 = start + len1;
            int end1 = next2;
            int end2 = start + n;
            int nextMerged = 0;
            while (next1 < end1 && next2 < end2)
            {
                if (list[next1] <= list[next2])
                {
                    merged[nextMerged] = list[next1];
                    next1++;
                }
                else
                {
                    merged[nextMerged] = list[next2];
                    next2++;
                }
                nextMerged++;
            }
            while (next1 < end1)
            {
                merged[nextMerged] = list[next1];
                next1++;
                nextMerged++;
            }
            while (next2 < end2)
            {
                merged[nextMerged] = list[next2];
                next2++;
                nextMerged++;
            }
            for (int i = 0; i < merged.Length; i++)
            {
                list[start + i] = merged[i];
            }
        }

        /// <summary>
        /// Sorts the given portion of the given list.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        /// <param name="start">The index of the first element of the portion to sort.</param>
        /// <param name="len">The number of elements to sort.</param>
        private void Sort(IList<int> list, int start, int len)
        {
            if (len > 1)
            {
                int half = len / 2;
                Sort(list, start, half);
                int half2 = len - half;
                Sort(list, start + half, half2);
                Merge(list, start, half, half2);
            }
        }
    }
}
