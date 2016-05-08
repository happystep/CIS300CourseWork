/* DirectedGraph.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ksu.Cis300.LinkedListLibrary;

namespace Ksu.Cis300.ShortestPaths
{
    /// <summary>
    /// A simple directed graph.
    /// </summary>
    /// <typeparam name="TNode">The type of the nodes in the graph.</typeparam>
    /// <typeparam name="TEdge">The type of data associated with the edged.</typeparam>
    public class DirectedGraph<TNode, TEdge>
    {
        /// <summary>
        /// The adjacency list for each node in the graph. Each node is a key whose value is a list
        /// of tuples representing the outgoing edges, where Item1 is the destination and Item2 is the
        /// data associate with the edge.
        /// </summary>
        private Dictionary<TNode, LinkedListCell<Tuple<TNode, TEdge>>> _adjacencyLists = new Dictionary<TNode, LinkedListCell<Tuple<TNode, TEdge>>>();

        /// <summary>
        /// The edges of the graph. Each key is a tuple representing an edge, and its associated value
        /// is the data associated with that edge.
        /// </summary>
        private Dictionary<Tuple<TNode, TNode>, TEdge> _edges = new Dictionary<Tuple<TNode,TNode>,TEdge>();

        /// <summary>
        /// Adds an edge from the given source to the given destination having the given value.
        /// If either node is not already in the graph, it is added. If either node is null, throws
        /// an ArgumentNullException. If the nodes are the same or if the graph already contains this
        /// edge, throws an ArgumentException
        /// </summary>
        /// <param name="source">The source node.</param>
        /// <param name="dest">The destination node.</param>
        /// <param name="value">The value associated with the edge.</param>
        public void AddEdge(TNode source, TNode dest, TEdge value)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }
            Tuple<TNode, TNode> edge = new Tuple<TNode, TNode>(source, dest);
            if (source.Equals(dest) || _edges.ContainsKey(edge))
            {
                throw new ArgumentException();
            }
            _edges.Add(edge, value);
            LinkedListCell<Tuple<TNode, TEdge>> list;
            _adjacencyLists.TryGetValue(source, out list);
            LinkedListCell<Tuple<TNode, TEdge>> cell = new LinkedListCell<Tuple<TNode, TEdge>>();
            cell.Data = new Tuple<TNode, TEdge>(dest, value);
            cell.Next = list;
            _adjacencyLists[source] = cell;
            if (!_adjacencyLists.ContainsKey(dest))
            {
                _adjacencyLists.Add(dest, null);
            }
        }

        /// <summary>
        /// Determines whether this graph contains the given node. If node is null, throws an
        /// ArgumentNullException.
        /// </summary>
        /// <param name="node">The node to look for.</param>
        /// <returns>Whether this graph contains node.</returns>
        public bool ContainsNode(TNode node)
        {
            return _adjacencyLists.ContainsKey(node);
        }

        /// <summary>
        /// Gets an enumerable collection of the outgoing edges from the given node. 
        /// If source is null, throws an ArgumentNullException.
        /// </summary>
        /// <param name="source">The node whose outgoing edges we want to enumerate.</param>
        /// <returns>An enumerable collection of the outgoing edges from source.</returns>
        public IEnumerable<Tuple<TNode, TEdge>> OutgoingEdges(TNode source)
        {
            LinkedListCell<Tuple<TNode, TEdge>> outgoing;
            _adjacencyLists.TryGetValue(source, out outgoing);
            return new AdjacencyList(outgoing);
        }

        /// <summary>
        /// An enumerator for an adjacency list.
        /// </summary>
        public class AdjacencyListEnumerator : IEnumerator<Tuple<TNode, TEdge>>
        {
            /// <summary>
            /// The current position in the enumeration.
            /// </summary>
            private LinkedListCell<Tuple<TNode, TEdge>> _current = new LinkedListCell<Tuple<TNode,TEdge>>();

            /// <summary>
            /// Constructs an enumerator for the given adjacency list.
            /// </summary>
            /// <param name="list"></param>
            public AdjacencyListEnumerator(LinkedListCell<Tuple<TNode, TEdge>> list)
            {
                _current.Next = list;
            }

            /// <summary>
            /// Gets the tuple at the current position. If the current position is either the starting position
            /// or the ending position, throws an InvalidOperationException.
            /// </summary>
            public Tuple<TNode, TEdge> Current
            {
                get 
                {
                    if (_current == null || _current.Data == null)
                    {
                        throw new InvalidOperationException();
                    }
                    return _current.Data;
                }
            }

            /// <summary>
            /// Disposes of any unmanaged resources (there are none).
            /// </summary>
            public void Dispose()
            {
                
            }

            /// <summary>
            /// Gets the tuple at the current position. If the current position is either the starting position
            /// or the ending position, throws an InvalidOperationException.
            /// </summary>
            object System.Collections.IEnumerator.Current
            {
                get { return Current; }
            }

            /// <summary>
            /// Advances the current position to the next position.
            /// </summary>
            /// <returns>Whether the resulting position is valid.</returns>
            public bool MoveNext()
            {
                if (_current == null)
                {
                    return false;
                }
                _current = _current.Next;
                return _current != null;
            }

            /// <summary>
            /// Not implemented.
            /// </summary>
            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// An enumerable adjacency list.
        /// </summary>
        public class AdjacencyList : IEnumerable<Tuple<TNode, TEdge>>
        {
            /// <summary>
            /// The adjacency list.
            /// </summary>
            private LinkedListCell<Tuple<TNode, TEdge>> _list;

            /// <summary>
            /// Constructs a new AdjacencyList for the given list.
            /// </summary>
            /// <param name="list"></param>
            public AdjacencyList(LinkedListCell<Tuple<TNode, TEdge>> list)
            {
                _list = list;
            }

            /// <summary>
            /// Gets an enumerator for this adjacency list.
            /// </summary>
            /// <returns>The enumerator.</returns>
            public IEnumerator<Tuple<TNode, TEdge>> GetEnumerator()
            {
                return new AdjacencyListEnumerator(_list);
            }

            /// <summary>
            /// Gets an enumerator for this adjacency list.
            /// </summary>
            /// <returns>The enumerator.</returns>
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
