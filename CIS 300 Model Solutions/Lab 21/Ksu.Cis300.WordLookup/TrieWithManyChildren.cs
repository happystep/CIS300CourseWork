/* TrieWithManyChildren.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.WordLookup
{
    /// <summary>
    /// A single trie node having 2-26 children.
    /// </summary>
    public class TrieWithManyChildren : ITrie
    {
        /// <summary>
        /// Indicates whether the trie rooted at this node contains the empty string.
        /// </summary>
        private bool _hasEmptyString = false;

        /// <summary>
        /// The children of this node.
        /// </summary>
        private ITrie[] _children = new ITrie[26];

        /// <summary>
        /// Constructs a trie containing (1) the given string; (2) all of the strings in the
        /// given ITrie, with the given char added as a prefix to each; and (3) the empty string
        /// the given bool is true.
        /// </summary>
        /// <param name="s">The string that the trie should include.</param>
        /// <param name="hasEmpty">Indicates whether the trie should contain the empty string.</param>
        /// <param name="childLabel">A label for one of the children of the trie.</param>
        /// <param name="child">The child that should have the above label.</param>
        public TrieWithManyChildren(string s, bool hasEmpty, char childLabel, ITrie child)
        {
            if (childLabel < 'a' || childLabel > 'z')
            {
                throw new ArgumentException();
            }
            _hasEmptyString = hasEmpty;
            int index = childLabel - 'a';
            _children[index] = child;
            Add(s);
        }

        /// <summary>
        /// Determines whether the trie rooted at this node contains the given string.
        /// </summary>
        /// <param name="s">The string to look up.</param>
        /// <returns>Whether the trie rooted at this node contains s.</returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _hasEmptyString;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                return false;
            }
            else
            {
                int loc = s[0] - 'a';
                if (_children[loc] == null)
                {
                    return false;
                }
                else
                {
                    return _children[loc].Contains(s.Substring(1));
                }
            }
        }

        /// <summary>
        /// Adds the given string to the trie rooted at this node.
        /// If the string contains any characters other than lower-case English letters,
        /// throws an ArgumentException.
        /// </summary>
        /// <param name="s">The string to add.</param>
        /// <returns>The resulting trie.</returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _hasEmptyString = true;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            else
            {
                int loc = s[0] - 'a';
                if (_children[loc] == null)
                {
                    _children[loc] = new TrieWithNoChildren();
                }
                _children[loc] = _children[loc].Add(s.Substring(1));
            }
            return this;
        }
    }
}
