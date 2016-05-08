/* UserInterface.cs
 * Author: Rod Howell 
 * Modified by: Julie Thornton
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
        /// An array of name information data, with names being organized by first letter into an array
        /// of linked lists. Each linked list is sorted alphabetically by name.
        /// </summary>
        private LinkedListCell<NameInformation>[] _list = null;

        /// <summary>
        /// Constructs a new GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Converts an upper-case letter to a 0-25 index
        /// </summary>
        /// <param name="letter">An upper-case English letter</param>
        /// <returns>The corresponding 0-25 index</returns>
        private int GetIndex(char letter)
        {
            return ((int)letter) - 65;
        }

        /// <summary>
        /// Inserts a new NameInformation into a sorted linked list
        /// </summary>
        /// <param name="info">The data to add</param>
        /// <param name="front">The front of the sorted linked list</param>
        /// <returns>The new front of the updated list</returns>
        private LinkedListCell<NameInformation> InsertSorted(NameInformation info, LinkedListCell<NameInformation> front)
        {
            LinkedListCell<NameInformation> cell = new LinkedListCell<NameInformation>();
            cell.Data = info;

            //empty
            if (front == null)
            {
                return cell;
            }
            //before first
            if (info.Name.CompareTo(front.Data.Name) <= 0)
            {
                cell.Next = front;
                return cell;
            }
            //in middle
            LinkedListCell<NameInformation> temp = front;
            while (temp.Next != null)
            {
                if (info.Name.CompareTo(temp.Data.Name) >= 0 && info.Name.CompareTo(temp.Next.Data.Name) <= 0)
                {
                    cell.Next = temp.Next;
                    temp.Next = cell;
                    return front;
                }
                temp = temp.Next;
            }
            //after end
            temp.Next = cell;
            return front;
        }

        /// <summary>
        /// Reads an input file of name statistics and stores it in an array of sorted linked lists,
        /// with spot 0 being for the 'A' names, etc.
        /// </summary>
        /// <param name="filename">The input file of data</param>
        /// <returns>An array of sorted linked lists (one for each beginning letter) with information for each name from the file.</returns>
        private LinkedListCell<NameInformation>[] ReadFile(string filename)
        {
            LinkedListCell<NameInformation>[] array = new LinkedListCell<NameInformation>[26];
            int count = 0;
            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    string name = sr.ReadLine().Trim();
                    float freq = Convert.ToSingle(sr.ReadLine());
                    int rank = Convert.ToInt32(sr.ReadLine());
                    count++;

                    int index = GetIndex(name[0]);

                    NameInformation info = new NameInformation(name, freq, rank);
                    array[index] = InsertSorted(info, array[index]);  
                }
            }

            return array;
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
                    string filename = uxOpenDialog.FileName;
                    _list = ReadFile(filename);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
            if (_list == null)
            {
                MessageBox.Show("No file loaded.");
                return;
            }

            string name = uxName.Text.Trim().ToUpper();
            LinkedListCell<NameInformation> temp = _list[GetIndex(name[0])];
            while (temp != null)
            {
                NameInformation info = temp.Data;
                if (info.Name == name)
                {
                    uxFrequency.Text = info.Frequency.ToString();
                    uxRank.Text = info.Rank.ToString();
                    return;
                }
                temp = temp.Next;
            }

            uxFrequency.Text = "";
            uxRank.Text = "";
            MessageBox.Show("name not found.");
        }

        /// <summary>
        /// Returns the count of how many names begin with the given letter
        /// </summary>
        /// <param name="letter">The letter to count</param>
        /// <returns>How many names begin with that letter</returns>
        private int CountLetter(char letter)
        {
            int count = 0;
            int index = GetIndex(letter);

            LinkedListCell<NameInformation> temp = _list[index];
            while (temp != null)
            {
                count++;
                temp = temp.Next;
            }

            return count;
        }

        /// <summary>
        /// Handles a click event on the Find Most Common Letter button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxCommonLetter_Click(object sender, EventArgs e)
        {
            if (_list == null)
            {
                MessageBox.Show("No file loaded.");
                return;
            }

            int bestCount = 0;
            int bestIndex = 0;
            for (int i = 0; i < _list.Length; i++)
            {
                LinkedListCell<NameInformation> temp = _list[i];
                int count = CountLetter((char) (i + 65));

                if (count > bestCount)
                {
                    bestCount = count;
                    bestIndex = i;
                }
            }

            uxCommonText.Text = "Most frequent first letter: " + (char)(bestIndex + 65);
        }

        /// <summary>
        /// Handles a click event on the Output Sorted File button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSort_Click(object sender, EventArgs e)
        {
            if (uxSaveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(uxSaveDialog.FileName))
                    {
                        for (int i = 0; i < _list.Length; i++)
                        {
                            LinkedListCell<NameInformation> temp = _list[i];
                            while (temp != null)
                            {
                                sw.WriteLine(temp.Data.Name);
                                sw.WriteLine(temp.Data.Frequency.ToString());
                                sw.WriteLine(temp.Data.Rank.ToString());

                                temp = temp.Next;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error writing to file");
                }
            }
        }

        /// <summary>
        /// Handles a click event on the Count Names with Letter button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLetterCount_Click(object sender, EventArgs e)
        {
            if (_list == null)
            {
                MessageBox.Show("No file loaded.");
                return;
            }

            char letter = (uxLetter.Text.Trim().ToUpper()[0]);

            int count = CountLetter(letter);
         
            uxLetterResult.Text = count + " names begin with " + letter;
        }
    }
}
