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
            QuickSort(list, 0, list.Count, 0);
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
        /// <param name="depth">The recursion depth.</param>
        private void QuickSort(IList<int> list, int start, int len, int depth)
        {
            if (len < 10)
            {
                InsertionSort(list, start, len);
            }
            else if (depth == 32)
            {
                MergeSort(list, start, len);
            }
            else
            {
                depth++;
                int pivot = MedianOfThree(list[start], list[start + len / 2], list[start + len - 1]);
                int afterLess = start;
                int beforeEqual = start + len - 1;
                int beforeGreater = beforeEqual;
                while (afterLess <= beforeEqual)
                {
                    if (list[beforeEqual] < pivot)
                    {
                        Swap(list, afterLess, beforeEqual);
                        afterLess++;
                    }
                    else if (list[beforeEqual] == pivot)
                    {
                        beforeEqual--;
                    }
                    else
                    {
                        Swap(list, beforeEqual, beforeGreater);
                        beforeEqual--;
                        beforeGreater--;
                    }
                }
                QuickSort(list, start, afterLess - start, depth);
                QuickSort(list, beforeGreater + 1, start + len - beforeGreater - 1, depth);
            }
        }

        /// <summary>
        /// Sorts the given portion of the given list.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        /// <param name="start">The index of the first element of the portion to sort.</param>
        /// <param name="len">The number of elements to sort.</param>
        private void MergeSort(IList<int> list, int start, int len)
        {
            if (len > 1)
            {
                int half = len / 2;
                MergeSort(list, start, half);
                int half2 = len - half;
                MergeSort(list, start + half, half2);
                Merge(list, start, half, half2);
            }
        }

        /// <summary>
        /// Sorts the given IList.
        /// </summary>
        /// <param name="list">The values to sort.</param>
        /// <param name="start">The first index of the list portion being sorted.</param>
        /// <param name="len">The length of the list portion being sorted.</param>
        private void InsertionSort(IList<int> list, int start, int len)
        {
            int end = start + len;
            for (int i = start + 1; i < end; i++)
            {
                int temp = list[i];
                int j = i;
                while (j > start && list[j - 1] > temp)
                {
                    list[j] = list[j - 1];
                    j--;
                }
                list[j] = temp;
            }
        }

        /// <summary>
        /// Finds the median of the given values.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <param name="c">The third value.</param>
        /// <returns>The median of a, b, and c.</returns>
        private int MedianOfThree(int a, int b, int c)
        {
            if (a < b)
            {
                if (b < c)
                {
                    return b;
                }
                else if (a < c)
                {
                    return c;
                }
                else
                {
                    return a;
                }
            }
            else if (a < c)
            {
                return a;
            }
            else if (b < c)
            {
                return c;
            }
            else
            {
                return b;
            }
        }
    }
}
