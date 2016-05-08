/* WordCount.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TextAnalyzer
{
    /// <summary>
    /// Stores a word and its number of occurrences in multiple files.
    /// </summary>
    public class WordCount
    {
        /// <summary>
        /// The word.
        /// </summary>
        private string _word;

        /// <summary>
        /// The number of occurrences in each file.
        /// </summary>
        private int[] _counts;

        /// <summary>
        /// Constructs a new WordCount for the given word and the given number of files.
        /// All counts are initially 0.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <param name="numFiles">The number of files.</param>
        public WordCount(string word, int numFiles)
        {
            _word = word;
            _counts = new int[numFiles];
        }

        /// <summary>
        /// Gets the word.
        /// </summary>
        public string Word
        {
            get
            {
                return _word;
            }
        }

        /// <summary>
        /// Gets the number of files.
        /// </summary>
        public int NumberOfFiles
        {
            get
            {
                return _counts.Length;
            }
        }

        /// <summary>
        /// Gets the count for the given file.
        /// </summary>
        /// <param name="n">The file number.</param>
        /// <returns>The count for the given file.</returns>
        public int this[int n]
        {
            get
            {
                CheckRange(n);
                return _counts[n];
            }
        }

        /// <summary>
        /// Increments the count for the given file.
        /// </summary>
        /// <param name="n">The file number.</param>
        public void Increment(int n)
        {
            CheckRange(n);
            _counts[n]++;
        }

        /// <summary>
        /// Verifies that the given value is a valid file number. If not, throws an ArgumentException.
        /// </summary>
        /// <param name="n">The file number.</param>
        private void CheckRange(int n)
        {
            if (n < 0 || n >= _counts.Length)
            {
                throw new ArgumentException();
            }
        }
    }
}
