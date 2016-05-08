/* Stack.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.LinkedListLibrary
{
    /// <summary>
    /// A simple generic stack, implemented using a linked list.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the stack.</typeparam>
    public class Stack<T>
    {
        /// <summary>
        /// The top of the stack.
        /// </summary>
        private LinkedListCell<T> _top = null;

        /// <summary>
        /// The number of elements in the stack.
        /// </summary>
        private int _count = 0;

        /// <summary>
        /// Gets the number of elements in the stack.
        /// </summary>
        public int Count
        {
            get
            {
                return _count;
            }
        }

        /// <summary>
        /// Pushes the given element onto the top of the stack.
        /// </summary>
        /// <param name="x">The element to push onto the stack.</param>
        public void Push(T x)
        {
            LinkedListCell<T> cell = new LinkedListCell<T>();
            cell.Data = x;
            cell.Next = _top;
            _top = cell;
            _count++;
        }

        /// <summary>
        /// Retrieves the element at the top of the stack.
        /// If the stack is empty, throws an InvalidOperationException.
        /// </summary>
        /// <returns>The element at the top of the stack.</returns>
        public T Peek()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException();
            }
            return _top.Data;
        }

        /// <summary>
        /// Removes the element at the top of the stack.
        /// If the stack is empty, throws an InvalidOperationException.
        /// </summary>
        /// <returns>The element removed.</returns>
        public T Pop()
        {
            T x = Peek();
            _top = _top.Next;
            _count--;
            return x;
        }
    }
}
