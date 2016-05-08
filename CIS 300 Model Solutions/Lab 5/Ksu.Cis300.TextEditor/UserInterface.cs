/* UserInterface.cs
 * Author: Rod Howell
 */
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ksu.Cis300.TextEditor
{
    /// <summary>
    /// A GUI for a simple text editor.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The history of edits.
        /// </summary>
        private Stack _editingHistory = new Stack();

        /// <summary>
        /// The history of undos.
        /// </summary>
        private Stack _undoHistory = new Stack();

        /// <summary>
        /// The last string seen in the editor.
        /// </summary>
        private string _lastText = "";

        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles an "Open . . ." event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpen_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _lastText = File.ReadAllText(uxOpenDialog.FileName);
                    uxDisplay.Text = _lastText;
                    _editingHistory.Clear();
                    _undoHistory.Clear();
                    uxUndo.Enabled = false;
                    uxRedo.Enabled = false;
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        /// <summary>
        /// Handles a "Save As . . ." event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSaveAs_Click(object sender, EventArgs e)
        {
            if (uxSaveAsDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(uxSaveAsDialog.FileName, uxDisplay.Text);
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        /// <summary>
        /// Displays the given exception in an error message.
        /// </summary>
        /// <param name="e"></param>
        private void ShowError(Exception e)
        {
            MessageBox.Show("The following error occurred: " + e.ToString());
        }

        /// <summary>
        /// Rotates the given character c n positions through the alphabet whose first
        /// letter is firstLetter and whose number of letters is alphabetLen. alphabetLen
        /// must be positive.
        /// </summary>
        /// <param name="c">The character to rotate.</param>
        /// <param name="n">The number of positions to rotate c.</param>
        /// <param name="firstLetter">The first letter of the alphabet.</param>
        /// <param name="alphabetLen">The number of letters in the alphabet.</param>
        /// <returns>The result of the rotation.</returns>
        private char Rotate(char c, int n, char firstLetter, int alphabetLen)
        {
            return (char)(firstLetter + (c - firstLetter + n) % alphabetLen);
        }

        /// <summary>
        /// Encrypts the given character.
        /// </summary>
        /// <param name="c">The character to encrypt.</param>
        /// <returns>The encrypted character.</returns>
        private char Encrypt(char c)
        {
            if (c >= 'a' && c <= 'z')
            {
                return Rotate(c, 13, 'a', 26);
            }
            else if (c >= 'A' && c <= 'Z')
            {
                return Rotate(c, 13, 'A', 26);
            }
            else return c;
        }

        /// <summary>
        /// Handles a "With String" event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxWithString_Click(object sender, EventArgs e)
        {
            string text = uxDisplay.Text;
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                result += Encrypt(text[i]);
            }
            uxDisplay.Text = result;
        }

        /// <summary>
        /// Handles a "With StringBuilder" event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxWithStringBuilder_Click(object sender, EventArgs e)
        {
            string text = uxDisplay.Text;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                result.Append(Encrypt(text[i]));
            }
            uxDisplay.Text = result.ToString();
        }

        /// <summary>
        /// Records an edit made by the user.
        /// </summary>
        private void RecordEdit()
        {
            bool isDel = IsDeletion(uxDisplay, _lastText);
            _editingHistory.Push(isDel);
            int len = GetEditLength(uxDisplay, _lastText);
            int loc = GetEditLocation(uxDisplay, isDel, len);
            _editingHistory.Push(loc);
            string text = uxDisplay.Text;
            _editingHistory.Push(GetEditString(text, _lastText, isDel, loc, len));
            uxUndo.Enabled = true;
            _undoHistory.Clear();
            uxRedo.Enabled = false;
            _lastText = text;
        }

        /// <summary>
        /// Returns whether text was deleted from the given string in order to obtain the contents
        /// of the given TextBox.
        /// </summary>
        /// <param name="editor">The TextBox containing the result of the edit.</param>
        /// <param name="lastContent">The string representing the text prior to the edit.</param>
        /// <returns>Whether the edit was a deletion.</returns>
        private bool IsDeletion(TextBox editor, string lastContent)
        {
            return editor.TextLength < lastContent.Length;
        }

        /// <summary>
        /// Gets the length of the text inserted or deleted.
        /// </summary>
        /// <param name="editor">The TextBox containing the result of the edit.</param>
        /// <param name="lastContent">The string representing the text prior to the edit.</param>
        /// <returns>The length of the edit.</returns>
        private int GetEditLength(TextBox editor, string lastContent)
        {
            return Math.Abs(editor.TextLength - lastContent.Length);
        }

        /// <summary>
        /// Gets the location of the beginning of the edit.
        /// </summary>
        /// <param name="editor">The TextBox containing the result of the edit.</param>
        /// <param name="isDeletion">Indicates whether the edit was a deletion.</param>
        /// <param name="len">The length of the edit string.</param>
        /// <returns>The location of the beginning of the edit.</returns>
        private int GetEditLocation(TextBox editor, bool isDeletion, int len)
        {
            if (isDeletion)
            {
                return editor.SelectionStart;
            }
            else
            {
                return editor.SelectionStart - len;
            }
        }

        /// <summary>
        /// Gets the edit string.
        /// </summary>
        /// <param name="content">The current content of the TextBox.</param>
        /// <param name="lastContent">The string representing the text prior to the edit.</param>
        /// <param name="isDeletion">Indicates whether the edit was a deletion.</param>
        /// <param name="editLocation">The location of the beginning of the edit.</param>
        /// <param name="len">The length of the edit.</param>
        /// <returns>The edit string.</returns>
        private string GetEditString(string content, string lastContent, bool isDeletion, int editLocation, int len)
        {
            if (isDeletion)
            {
                return lastContent.Substring(editLocation, len);
            }
            else
            {
                return content.Substring(editLocation, len);
            }
        }

        /// <summary>
        /// Performs the given edit on the contents of the given TextBox.
        /// </summary>
        /// <param name="editor">The TextBox to edit.</param>
        /// <param name="isDeletion">Indicates whether the edit is a deletion.</param>
        /// <param name="loc">The location of the beginning of the edit.</param>
        /// <param name="text">The text to insert or delete.</param>
        private void DoEdit(TextBox editor, bool isDeletion, int loc, string text)
        {
            if (isDeletion)
            {
                _lastText = editor.Text.Remove(loc, text.Length);
                editor.Text = _lastText;
                editor.SelectionStart = loc;
            }
            else
            {
                _lastText = editor.Text.Insert(loc, text);
                editor.Text = _lastText;
                editor.SelectionStart = loc + text.Length;
            }
        }

        /// <summary>
        /// Handles a TextChanged event on the display.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxDisplay_TextChanged(object sender, EventArgs e)
        {
            if (uxDisplay.Modified)
            {
                RecordEdit();
            }
        }

        /// <summary>
        /// Handles an Undo event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxUndo_Click(object sender, EventArgs e)
        {
            string editStr = (string)_editingHistory.Pop();
            int loc = (int)_editingHistory.Pop();
            bool isDel = (bool)_editingHistory.Pop();
            _undoHistory.Push(isDel);
            _undoHistory.Push(loc);
            _undoHistory.Push(editStr);
            uxRedo.Enabled = true;
            DoEdit(uxDisplay, !isDel, loc, editStr);
            uxUndo.Enabled = _editingHistory.Count > 0;
        }

        /// <summary>
        /// Handles a Redo event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxRedo_Click(object sender, EventArgs e)
        {
            string editStr = (string)_undoHistory.Pop();
            int loc = (int)_undoHistory.Pop();
            bool isDel = (bool)_undoHistory.Pop();
            _editingHistory.Push(isDel);
            _editingHistory.Push(loc);
            _editingHistory.Push(editStr);
            uxUndo.Enabled = true;
            DoEdit(uxDisplay, isDel, loc, editStr);
            uxRedo.Enabled = _undoHistory.Count > 0;
        }
    }
}
