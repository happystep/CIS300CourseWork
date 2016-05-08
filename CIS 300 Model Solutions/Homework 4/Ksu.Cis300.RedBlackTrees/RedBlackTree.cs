/* RedBlackTree.cs
 * Author: Julie Thornton
 */

using KansasStateUniversity.TreeViewer2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.RedBlackTrees
{
    /// <summary>
    /// An implementation of a red-black binary search tree
    /// </summary>
    /// <typeparam name="T">The type of data in the node</typeparam>
    public class RedBlackTree<T> where T: IComparable<T>
    {
        /// <summary>
        /// The root of the red-black tree
        /// </summary>
        private RedBlackNode<T> _root = null;

        /// <summary>
        /// Gets the root of the tree
        /// </summary>
        public RedBlackNode<T> Root
        {
            get
            {
                return _root;
            }
        }

        /// <summary>
        /// Draws the current red-black tree
        /// </summary>
        public void DrawTree()
        {
            new TreeForm(_root, 100, _root).Show();
        }
        
        /// <summary>
        /// Searches for a value within the tree
        /// </summary>
        /// <param name="val">The value to find</param>
        /// <returns>The data in the tree matching value, if found. If not found, returns
        /// the default value of T</returns>
        public T Contains(T val)
        {
            RedBlackNode<T> cur = _root;
            while (cur != null)
            {
                int comp = val.CompareTo(cur.Data);
                if (comp == 0)
                {
                    return cur.Data;
                }
                else if (comp < 0)
                {
                    cur = cur.LeftChild;
                }
                else
                {
                    cur = cur.RightChild;
                }
            }

            return default(T);
        }

        /// <summary>
        /// Fixes color violations (by recoloring and rotating)
        /// </summary>
        /// <param name="node">The node just added</param>
        private void FixColors(RedBlackNode<T> node)
        {
            node.IsBlack = false;

            while (node != _root && (node.Parent.IsBlack == false))
            {
                RedBlackNode<T> grandParent = node.Parent.Parent;
                if (node.Parent == grandParent.LeftChild)
                {
                    //uncle is red
                    if (grandParent.RightChild != null && !grandParent.RightChild.IsBlack)
                    {
                        node.Parent.IsBlack = true;
                        grandParent.RightChild.IsBlack = true;
                        grandParent.IsBlack = false;
                        node = grandParent;
                    }
                    //uncle is black
                    else if (grandParent.RightChild == null || grandParent.RightChild.IsBlack)
                    {
                        if (node == node.Parent.RightChild)
                        {
                            node = node.Parent;
                            RotateLeft(node);
                        }
                        node.Parent.IsBlack = true;
                        node.Parent.Parent.IsBlack = false;
                        RotateRight(node.Parent.Parent);
                    }
                }
                else
                {
                    //uncle is red
                    if (grandParent.LeftChild != null && !grandParent.LeftChild.IsBlack)
                    {
                        node.Parent.IsBlack = true;
                        grandParent.LeftChild.IsBlack = true;
                        grandParent.IsBlack = false;
                        node = grandParent;
                    }
                    //uncle is black
                    else if (grandParent.LeftChild == null || grandParent.LeftChild.IsBlack)
                    {
                        if (node == node.Parent.LeftChild)
                        {
                            node = node.Parent;
                            RotateRight(node);
                        }
                        node.Parent.IsBlack = true;
                        node.Parent.Parent.IsBlack = false;
                        RotateLeft(node.Parent.Parent);
                    }
                }
            }

            _root.IsBlack = true;
        }

        /// <summary>
        /// Performs a single rotate right
        /// </summary>
        /// <param name="node">The top node in the rotation</param>
        private void RotateRight(RedBlackNode<T> node)
        {
            if (node.LeftChild == null)
            {
                return;
            }

            RedBlackNode<T> oldLeft = node.LeftChild;
            oldLeft.Parent = node.Parent;
            node.LeftChild = node.LeftChild.RightChild;
    
            if (node.Parent == null)
            {
                _root = oldLeft;
            }
            else if (node.Parent.LeftChild == node)
            {
                node.Parent.LeftChild = oldLeft;
            }
            else
            {
                node.Parent.RightChild = oldLeft;
            }
            
            if (oldLeft.RightChild != null)
            {
                oldLeft.RightChild.Parent = node;
                node.LeftChild = oldLeft.RightChild;
            }

            oldLeft.RightChild = node;
            node.Parent = oldLeft;
        }

        /// <summary>
        /// Performs a single rotate left
        /// </summary>
        /// <param name="node">The top node in the rotation</param>
        private void RotateLeft(RedBlackNode<T> node)
        {
            if (node.RightChild == null)
            {
                return;
            }

            RedBlackNode<T> oldRight = node.RightChild;
            oldRight.Parent = node.Parent;
            node.RightChild = node.RightChild.LeftChild;

            if (node.Parent == null)
            {
                _root = oldRight;
            }
            else if (node.Parent.LeftChild == node)
            {
                node.Parent.LeftChild = oldRight;
            }
            else
            {
                node.Parent.RightChild = oldRight;
            }

            if (oldRight.LeftChild != null)
            {
                oldRight.LeftChild.Parent = node;
                node.RightChild = oldRight.LeftChild;
            }

            oldRight.LeftChild = node;
            node.Parent = oldRight;
        }

        /// <summary>
        /// Adds a new value to the tree
        /// </summary>
        /// <param name="val">The value to add</param>
        public void Add(T val)
        {
            if (_root == null)
            {
                _root = new RedBlackNode<T>(val, null, null, null);
                _root.IsBlack = true;
                return;
            }
            else
            {
                RedBlackNode<T> cur = _root;
                while (cur != null)
                {
                    int comp = val.CompareTo(cur.Data);
                    if (comp == 0)
                    {
                        throw new ArgumentException();
                    }
                    else if (comp < 0)
                    {
                        if (cur.LeftChild == null)
                        {
                            cur.LeftChild = new RedBlackNode<T>(val, null, null, cur);
                            FixColors(cur.LeftChild);
                            return;
                        }
                        else
                        {
                            cur = cur.LeftChild;
                        }
                    }
                    else
                    {
                        if (cur.RightChild == null)
                        {
                            cur.RightChild = new RedBlackNode<T>(val, null, null, cur);
                            FixColors(cur.RightChild);
                            return;
                        }
                        else
                        {
                            cur = cur.RightChild;
                        }
                    }
                }
            }
        }
    }
}
