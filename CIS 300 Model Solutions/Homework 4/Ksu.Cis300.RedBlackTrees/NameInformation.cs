﻿/* NameInformation.cs
 * Author: Rod Howell
 * Edited by: Julie THornton
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.RedBlackTrees
{
    /// <summary>
    /// A structure containing a name, frequency, and rank.
    /// </summary>
    public struct NameInformation : IComparable<NameInformation>
    {
        /// <summary>
        /// The name.
        /// </summary>
        private string _name;

        /// <summary>
        /// The frequency.
        /// </summary>
        private float _frequency;

        /// <summary>
        /// The rank.
        /// </summary>
        private int _rank;

        

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// Gets the frequency.
        /// </summary>
        public float Frequency
        {
            get
            {
                return _frequency;
            }
        }

        /// <summary>
        /// Gets the rank.
        /// </summary>
        public int Rank
        {
            get
            {
                return _rank;
            }
        }

        /// <summary>
        /// Constructs a new NameInformation containing the given name,
        /// frequency, and rank.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="frequency">The frequency.</param>
        /// <param name="rank">The rank.</param>
        public NameInformation(string name, float frequency, int rank)
        {
            _name = name;
            _frequency = frequency;
            _rank = rank;
        }

        /// <summary>
        /// Converts this NameInformation to a string.
        /// </summary>
        /// <returns>The string equivalent of this NameInformation.</returns>
        public override string ToString()
        {
            return _name;
        }

        /// <summary>
        /// Compares this NameInformation to the parameter, using just the Name property
        /// </summary>
        /// <param name="other">Another NameInformation object</param>
        /// <returns>The comparison of this object's Name to other's Name</returns>
        public int CompareTo(NameInformation other)
        {
            return _name.CompareTo(other.Name);
        }
    }
}
