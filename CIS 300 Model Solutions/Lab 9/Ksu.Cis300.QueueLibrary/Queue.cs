/* Queue.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.QueueLibrary
{
    /// <summary>
    /// A generic queue, implemented using a circular array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the queue.</typeparam>
    public class Queue<T>
    {
        /// <summary>
        /// The elements of the queue.
        /// </summary>
        private T[] _elements = new T[5];

        /// <summary>
        /// The number of elements in the queue.
        /// </summary>
        private int _count = 0;

        /// <summary>
        /// The index of the element at the front of the queue. If the queue is empty, any valid index will do.
        /// </summary>
        private int _front = 0;

        /// <summary>
        /// Gets the number of elements in the queue.
        /// </summary>
        public int Count
        {
            get
            {
                return _count;
            }
        }

        /// <summary>
        /// Enqueues the given element to the back of the queue.
        /// </summary>
        /// <param name="x">The element to enqueue.</param>
        public void Enqueue(T x)
        {
            if (_count == _elements.Length)
            {
                T[] el = new T[2 * _count];
                Array.Copy(_elements, _front, el, 0, _count - _front);
                Array.Copy(_elements, 0, el, _count - _front, _front);
                _elements = el;
                _front = 0;
            }
            int back = _count + _front;
            if (back >= _elements.Length)
            {
                back -= _elements.Length;
            }
            _elements[back] = x;
            _count++;
        }

        /// <summary>
        /// Retrieves the element at the front of the queue.
        /// If the queue is empty, throws an InvalidOperationException.
        /// </summary>
        /// <returns>The element at the front of the queue.</returns>
        public T Peek()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException();
            }
            return _elements[_front];
        }

        /// <summary>
        /// Removes the element at the front of the queue.
        /// If the queue is empty, throws an InvalidOperationException.
        /// </summary>
        /// <returns>The element removed.</returns>
        public T Dequeue()
        {
            T x = Peek();
            _front++;
            if (_front == _elements.Length)
            {
                _front = 0;
            }
            _count--;
            return x;
        }
    }
}
