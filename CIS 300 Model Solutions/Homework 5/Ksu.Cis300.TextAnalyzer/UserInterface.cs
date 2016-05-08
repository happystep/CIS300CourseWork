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
using Ksu.Cis300.Sort;
using System.IO;
using System.Text.RegularExpressions;

namespace Ksu.Cis300.TextAnalyzer
{
    /// <summary>
    /// A GUI for a program that compares texts for similarity in the use of most-common words.
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
        /// Handles a Click event on the "Text 1:" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSelectText1_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                uxText1.Text = uxOpenDialog.FileName;
                if (uxText2.Text != "")
                {
                    uxAnalyze.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Handles a Click event on the "Text 2:" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSelectText2_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                uxText2.Text = uxOpenDialog.FileName;
                if (uxText1.Text != "")
                {
                    uxAnalyze.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Handles a Click event on the "Analyze Texts" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAnalyze_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, WordCount> words = new Dictionary<string, WordCount>();
                int n1 = ProcessFile(uxText1.Text, 0, words);
                int n2 = ProcessFile(uxText2.Text, 1, words);
                MinPriorityQueue<float, WordFrequency> common = GetMostCommonWords(words, n1, n2);
                MessageBox.Show("Difference measure: " + GetDifference(common));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Gets the difference measure for the data in the given min-priority queue.
        /// </summary>
        /// <param name="common">The min-priority queue containing the frequencies of words in two files.</param>
        /// <returns>The difference measure.</returns>
        private float GetDifference(MinPriorityQueue<float, WordFrequency> common)
        {
            float sum = 0;
            int count = common.Count;
            while (common.Count > 0)
            {
                WordFrequency f = common.RemoveMinimumPriority();
                sum += Square(f[0] - f[1]);
            }
            return 100 * (float)Math.Sqrt(sum);
        }

        /// <summary>
        /// Computes the square of the given value.
        /// </summary>
        /// <param name="v">The value to square.</param>
        /// <returns>v squared.</returns>
        private float Square(float v)
        {
            return v * v;
        }

        /// <summary>
        /// Finds the 50 most common words in the files. If the files contain fewer than 50 words, all words are returned.
        /// </summary>
        /// <param name="words">A dictionary containing all the words in the two files with their number of occurrences in the files.</param>
        /// <param name="n1">The number of words in the first file.</param>
        /// <param name="n2">The number of words in the second file.</param>
        /// <returns>A min-priority queue containing the most common words.</returns>
        private MinPriorityQueue<float, WordFrequency> GetMostCommonWords(Dictionary<string, WordCount> words, int n1, int n2)
        {
            MinPriorityQueue<float, WordFrequency> q = new MinPriorityQueue<float, WordFrequency>();
            int[] nWords = new int[] { n1, n2 };
            foreach (WordCount c in words.Values)
            {
                WordFrequency f = new WordFrequency(c, nWords);
                q.Add(f, f[0] + f[1]);
                if (q.Count > 50)
                {
                    q.RemoveMinimumPriority();
                }
            }
            return q;
        }

        /// <summary>
        /// Processes the given file by counting the number of occurrences of each word.
        /// </summary>
        /// <param name="name">The name of the file.</param>
        /// <param name="fileNum">The file number.</param>
        /// <param name="wordInfo">A dictionary storing frequency information.</param>
        /// <returns>The number of words in the file.</returns>
        private int ProcessFile(string name, int fileNum, Dictionary<string, WordCount> wordInfo)
        {
            int nWords = 0;
            using (StreamReader input = new StreamReader(name))
            {
                while (!input.EndOfStream)
                {
                    string line = input.ReadLine().ToLower();
                    string[] words = Regex.Split(line, "[^abcdefghijklmnopqrstuvwxyz]+");
                    foreach (string word in words)
                    {
                        if (word != "")
                        {
                            nWords++;
                            WordCount c;
                            if (!wordInfo.TryGetValue(word, out c))
                            {
                                c = new WordCount(word, 2);
                                wordInfo.Add(word, c);
                            }
                            c.Increment(fileNum);
                        }
                    }
                }
            }
            return nWords;
        }
    }
}
