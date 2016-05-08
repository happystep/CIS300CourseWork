/* Board.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.Nim
{
    /// <summary>
    /// An immutable representation of a Nim board position.
    /// </summary>
    public class Board
    {
        /// <summary>
        /// The number of stones on each pile.
        /// </summary>
        private int[] _piles;

        /// <summary>
        /// The limit for each pile.
        /// </summary>
        private int[] _limits;

        /// <summary>
        /// Gets the number of piles.
        /// </summary>
        public int NumberOfPiles
        {
            get
            {
                return _piles.Length;
            }
        }

        /// <summary>
        /// Constructs a new Board.
        /// </summary>
        /// <param name="piles">The number of stones on each pile.</param>
        /// <param name="limits">The limit for each pile.</param>
        public Board(int[] piles, int[] limits)
        {
            if (piles.Length != limits.Length)
            {
                throw new ArgumentException();
            }
            _piles = new int[piles.Length];
            piles.CopyTo(_piles, 0);
            _limits = new int[limits.Length];
            limits.CopyTo(_limits, 0);
        }

        /// <summary>
        /// Gets the number of stones on the given pile.
        /// </summary>
        /// <param name="pile">The pile.</param>
        /// <returns>The number of stones on the given pile.</returns>
        public int GetValue(int pile)
        {
            if (pile < 0 || pile >= _piles.Length)
            {
                throw new ArgumentException();
            }
            return _piles[pile];
        }

        /// <summary>
        /// Gets the limit for the given pile.
        /// </summary>
        /// <param name="pile">The pile.</param>
        /// <returns>The limit for the given pile.</returns>
        public int GetLimit(int pile)
        {
            if (pile < 0 || pile >= _piles.Length)
            {
                throw new ArgumentException();
            }
            return _limits[pile];
        }

        /// <summary>
        /// Determines whether the given boards are equal.
        /// </summary>
        /// <param name="x">The first board.</param>
        /// <param name="y">The second board.</param>
        /// <returns>Whether x is equal to y.</returns>
        public static bool operator ==(Board x, Board y)
        {
            if (Equals(x, null))
            {
                return (Equals(y, null));
            }
            else if (Equals(y, null))
            {
                return false;
            }
            else
            {
                if (x._limits.Length != y._limits.Length)
                {
                    return false;
                }
                for (int i = 0; i < x._limits.Length; i++)
                {
                    if (x._piles[i] != y._piles[i] || x._limits[i] != y._limits[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// Determines whether the given boards are unequal.
        /// </summary>
        /// <param name="x">The first board.</param>
        /// <param name="y">The second board.</param>
        /// <returns>Whether x and y are unequal.</returns>
        public static bool operator !=(Board x, Board y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Determines whether this board is equal to the given object.
        /// </summary>
        /// <param name="obj">The object to compare to this board.</param>
        /// <returns>Whether this board is equal to the given object.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Board)
            {
                return this == (Board)obj;
            }
            else
            {
                return false;
            }
        }
    }
}
