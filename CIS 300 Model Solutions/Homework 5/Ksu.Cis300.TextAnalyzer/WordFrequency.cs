/* WordFrequencey.cs
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
    /// Contains a word and its frequency of occurrence within multiple files.
    /// </summary>
    public struct WordFrequency
    {
        /// <summary>
        /// The word.
        /// </summary>
        private string _word;

        /// <summary>
        /// The frequencies.
        /// </summary>
        private float[] _frequencies;

        /// <summary>
        /// Constructs a WordFrequency for the given WordCount using the given number of words in each file.
        /// If the length of nWords is not the same as the number of files for c, throws an ArgumentException.
        /// </summary>
        /// <param name="c">The WordCount giving the word and the number of occurrences of this word in each file.</param>
        /// <param name="nWords">The total number of words in each file.</param>
        public WordFrequency(WordCount c, int[] nWords)
        {
            if (nWords.Length != c.NumberOfFiles)
            {
                throw new ArgumentException();
            }
            _word = c.Word;
            _frequencies = new float[nWords.Length];
            for (int i = 0; i < nWords.Length; i++)
            {
                _frequencies[i] = (float)c[i] / nWords[i];
            }
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
        /// Gets the frequency of the word in the given file.
        /// </summary>
        /// <param name="i">The file number.</param>
        /// <returns>The frequency of the word in file i.</returns>
        public float this[int i]
        {
            get
            {
                if (i < 0 || i >= _frequencies.Length)
                {
                    throw new ArgumentException();
                }
                return _frequencies[i];
            }
        }
    }
}
