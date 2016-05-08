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
using Ksu.Cis300.WordLookup;

namespace Ksu.Cis300.Boggle
{
    /// <summary>
    /// A user interface for a program that finds all words in a randomly-generated Boggle Deluxe board.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The length and width of the grid.
        /// </summary>
        private const int _gridSize = 5;

        /// <summary>
        /// The minimum allowed length of a word.
        /// </summary>
        private const int _minimumWordLength = 4;

        /// <summary>
        /// The font size to use to compute the maximum pixel length of a string on a die.
        /// </summary>
        private const float _testFontSize = 42f;

        /// <summary>
        /// The maximum fraction of a die's width to be occupied by its string.
        /// </summary>
        private const float _fractionOfDieUsed = 0.8f;

        /// <summary>
        /// The current board contents.
        /// </summary>
        private string[,] _board = new string[_gridSize, _gridSize];

        /// <summary>
        /// The longest string shown on a die.
        /// </summary>
        private const string _longestString = "Qu";

        /// <summary>
        /// The dice.
        /// </summary>
        private string[][] _dice = new string[][]
        {
            new string[] { "A", "F", "I", "R", "S", "Y" },
            new string[] { "A", "D", "E", "N", "N", "N" },
            new string[] { "A", "E", "E", "E", "E", "M" },
            new string[] { "A", "A", "A", "F", "R", "S" },
            new string[] { "A", "E", "G", "M", "N", "N" },
            new string[] { "A", "A", "E", "E", "E", "E" },
            new string[] { "A", "E", "E", "G", "M", "U" },
            new string[] { "A", "A", "F", "I", "R", "S" },
            new string[] { "B", "J", "K", "Qu", "X", "Z" },
            new string[] { "C", "C", "E", "N", "S", "T" },
            new string[] { "C", "E", "I", "L", "P", "T" },
            new string[] { "C", "E", "I", "I", "L", "T" },
            new string[] { "C", "E", "I", "P", "S", "T" },
            new string[] { "D", "H", "L", "N", "O", "R" },
            new string[] { "D", "H", "L", "N", "O", "R" },
            new string[] { "D", "D", "H", "N", "O", "T" },
            new string[] { "D", "H", "H", "L", "O", "R" },
            new string[] { "E", "N", "S", "S", "S", "U" },
            new string[] { "E", "M", "O", "T", "T", "T" },
            new string[] { "E", "I", "I", "I", "T", "T" },
            new string[] { "F", "I", "P", "R", "S", "Y" },
            new string[] { "G", "O", "R", "R", "V", "W" },
            new string[] { "I", "P", "R", "R", "R", "Y" },
            new string[] { "N", "O", "O", "T", "U", "W" },
            new string[] { "O", "O", "O", "T", "T", "U" }
        };

        /// <summary>
        /// The random number generator.
        /// </summary>
        private Random _randomNumbers = new Random();

        /// <summary>
        /// The list of allowable words.
        /// </summary>
        private ITrie _wordList = new TrieWithNoChildren();

        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
            GenerateNewBoard();
        }

        /// <summary>
        /// Generates a new game board.
        /// </summary>
        private void GenerateNewBoard()
        {
            uxBoard.Controls.Clear();
            int k = _dice.Length - 1;
            Size blockSize = new Size(uxBoard.Size.Width / _gridSize, uxBoard.Size.Height / _gridSize);
            Font testFont = new Font(FontFamily.GenericSansSerif, _testFontSize, FontStyle.Regular);
            Size testSize = TextRenderer.MeasureText(_longestString, testFont);
            float fontSize = _testFontSize * _fractionOfDieUsed * Math.Min((float)blockSize.Width / testSize.Width, (float)blockSize.Height / testSize.Height);
            Font f = new Font(FontFamily.GenericSansSerif, fontSize, FontStyle.Regular);
            for (int i = 0; i < _gridSize; i++)
            {
                for (int j = 0; j < _gridSize; j++)
                {
                    int loc = _randomNumbers.Next(k + 1);
                    string[] temp = _dice[loc];
                    _dice[loc] = _dice[k];
                    _dice[k] = temp;
                    Button b = new Button();
                    b.Font = f;
                    b.Size = blockSize;
                    b.Text = _dice[k][_randomNumbers.Next(6)];
                    b.TextAlign = ContentAlignment.MiddleCenter;
                    b.FlatStyle = FlatStyle.System;
                    b.Location = new Point(j * blockSize.Width, i * blockSize.Height);
                    uxBoard.Controls.Add(b);
                    _board[i, j] = b.Text.ToLower();
                    k--;
                }
            }
            uxFindWords.Enabled = true;
        }

        /// <summary>
        /// Handles a Load event on the GUI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserInterface_Load(object sender, EventArgs e)
        {
            uxOpenDialog.ShowDialog();
            try
            {
                using (StreamReader input = File.OpenText(uxOpenDialog.FileName))
                {
                    while (!input.EndOfStream)
                    {
                        string word = input.ReadLine();
                        if (word.Length >= _minimumWordLength)
                        {
                            _wordList = _wordList.Add(word);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Application.Exit();
            }
        }

        /// <summary>
        /// Handles a Click event on the New Board button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNewBoard_Click(object sender, EventArgs e)
        {
            GenerateNewBoard();
        }

        /// <summary>
        /// Handles a Click event on the Find Words button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxFindWords_Click(object sender, EventArgs e)
        {
            ITrie results = new TrieWithNoChildren();

            for (int i = 0; i < _gridSize; i++)
            {
                for (int j = 0; j < _gridSize; j++)
                {
                    results = FindWords(i, j, new bool[_gridSize, _gridSize], new StringBuilder(), _wordList, results);
                }
            }

            uxWordsFound.Items.Clear();
            uxWordsFound.BeginUpdate();
            results.AddAll(new StringBuilder(), uxWordsFound.Items);
            uxWordsFound.EndUpdate();
        }

        /// <summary>
        /// Finds all words starting with the content of path, followed by a word that is both contained in
        /// completions and formed by the letters on a nonempty path that starts from the given row and column, does
        /// not use any die for which used is true, and does not use any die more than once.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="col">The column</param>
        /// <param name="used">Indicates which dice have been used on the path.</param>
        /// <param name="path">The sequence of letters on the path.</param>
        /// <param name="completions">All valid completions of the path.</param>
        /// <param name="wordsFound">The words found so far.</param>
        /// <returns>A trie containing all words in wordsFound, plus those found by this method.</returns>
        private ITrie FindWords(int row, int col, bool[,] used, StringBuilder path, ITrie completions, ITrie wordsFound)
        {
            ITrie t = completions.GetCompletions(_board[row, col]);
            if (t == null)
            {
                return wordsFound;
            }
            used[row, col] = true;
            path.Append(_board[row, col]);
            if (t.Contains(""))
            {
                wordsFound = wordsFound.Add(path.ToString());
            }
            for (int i = Math.Max(0, row - 1); i < Math.Min(_gridSize, row + 2); i++)
            {
                for (int j = Math.Max(0, col - 1); j < Math.Min(_gridSize, col + 2); j++)
                {
                    if (!used[i, j])
                    {
                        wordsFound = FindWords(i, j, used, path, t, wordsFound);
                    }
                }
            }
            path.Length -= _board[row, col].Length;
            used[row, col] = false;
            return wordsFound;
        }
    }
}
