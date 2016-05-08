/* RedBlackNode.cs
 * Author: Julie Thornton
 */

using KansasStateUniversity.TreeViewer2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Ksu.Cis300.RedBlackTrees
{
    /// <summary>
    /// Represents a single node in a red-black tree
    /// </summary>
    /// <typeparam name="T">The type of data in the node</typeparam>
    public class RedBlackNode<T> : ITree, IColorizer
    {
        private RedBlackNode<T> _leftChild = null;
        private RedBlackNode<T> _rightChild = null;
        private RedBlackNode<T> _parent = null;
        private T _data;
        private bool _isBlack = false;

        /// <summary>
        /// Gets and sets whether the node is black
        /// </summary>
        public bool IsBlack
        {
            get
            {
                return _isBlack;
            }
            set
            {
                _isBlack = value;
            }
        }

        /// <summary>
        /// Gets the data from the node
        /// </summary>
        public T Data
        {
            get
            {
                return _data;
            }
        }

        /// <summary>
        /// Gets and sets this node's left child.
        /// </summary>
        public RedBlackNode<T> LeftChild
        {
            get
            {
                return _leftChild;
            }
            set
            {
                _leftChild = value;
            }
        }

        /// <summary>
        /// Gets and sets this node's parent
        /// </summary>
        public RedBlackNode<T> Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }

        /// <summary>
        /// Gets and sets this node's right child.
        /// </summary>
        public RedBlackNode<T> RightChild
        {
            get
            {
                return _rightChild;
            }
            set
            {
                _rightChild = value;
            }
        }

        /// <summary>
        /// Creates a new RedBlackNode
        /// </summary>
        /// <param name="data">The data in the node</param>
        /// <param name="left">This node's left child</param>
        /// <param name="right">This node's right child</param>
        /// <param name="parent">This node's parent</param>
        public RedBlackNode(T data, RedBlackNode<T> left, RedBlackNode<T> right, RedBlackNode<T> parent)
        {
            _data = data;
            _leftChild = left;
            _rightChild = right;
            _parent = parent;
        }

        /// <summary>
        /// Gets the children of this node.
        /// </summary>
        public ITree[] Children
        {
            get
            {
                ITree[] children = new ITree[2];
                children[0] = (ITree)_leftChild;
                children[1] = (ITree)_rightChild;
                return children;
            }
        }

        /// <summary>
        /// Gets whether this node is empty. Because empty trees will be represented by
        /// null, it always returns false.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the object to be drawn as the contents of this node.
        /// </summary>
        public object Root
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// Gets a string representation of this node
        /// </summary>
        /// <returns>The data in this node as a string</returns>
        public override string ToString()
        {
            return _data.ToString();
        }

        /// <summary>
        /// Gets the color of a RedBlackNode
        /// </summary>
        /// <param name="obj">A red-black node</param>
        /// <returns>Either Color.Red or Color.Black, depending on the node's IsBlack property</returns>
        public Color GetColor(object obj)
        {
            RedBlackNode<T> t = (RedBlackNode<T>)obj;

            if (t.IsBlack)
            {
                return Color.Black;
            }
            else
            {
                return Color.Red;
            }
        }
    }
}
