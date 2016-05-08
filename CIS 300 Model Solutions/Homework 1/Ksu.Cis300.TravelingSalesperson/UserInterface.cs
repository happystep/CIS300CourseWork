/* UserInterface.cs
 * Author: Rod Howell
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

namespace Ksu.Cis300.TravelingSalesperson
{
    /// <summary>
    /// A GUI for a program that solves the Traveling Salesperson Problem
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles a Clear event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxClear_Click(object sender, EventArgs e)
        {
            uxPanel.Clear();
            uxTourPoints.Items.Clear();
        }

        /// <summary>
        /// Handles a Find Tour event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxFindTour_Click(object sender, EventArgs e)
        {
            Point[] points = uxPanel.Points;
            uxTourPoints.Items.Clear();
            uxPanel.ClearLines();
            if (points.Length < 2)
            {
                MessageBox.Show("You must plot at least 2 points.");
                return;
            }
            double[,] distances = GetDistances(points);
            int[] tour = new int[points.Length];
            int n = points.Length;
            double tourLen = ComputeMinumumLengthTour(n, distances, tour);
            DisplayResults(points, tour, tourLen);
        }

        /// <summary>
        /// Displays the minimum tour information.
        /// </summary>
        /// <param name="points">The given points.</param>
        /// <param name="tour">The indices of a minimum-length tour, in order.</param>
        /// <param name="tourLen">The length of a shortest tour.</param>
        private void DisplayResults(Point[] points, int[] tour, double tourLen)
        {
            uxTourPoints.Items.Add(points[tour[0]]);
            for (int i = 1; i < tour.Length; i++)
            {
                uxPanel.DrawLine(points[tour[i - 1]], points[tour[i]]);
                uxTourPoints.Items.Add(points[tour[i]]);
            }
            uxPanel.DrawLine(points[tour[points.Length - 1]], points[tour[0]]);
            uxTourPoints.Items.Add(points[tour[0]]);
            MessageBox.Show("Tour length: " + tourLen);
        }

        /// <summary>
        /// Finds the minimum-length tour.
        /// </summary>
        /// <param name="n">The number of points.</param>
        /// <param name="distances">The distances between each pair of points.</param>
        /// <param name="tour">An array in which the indices of a minimum-length tour are to be placed.</param>
        /// <returns>The length of the shortest tour.</returns>
        private double ComputeMinumumLengthTour(int n, double[,] distances, int[] tour)
        {
            Stack<int> path = new Stack<int>();
            path.Push(0);
            double tourLen = Double.PositiveInfinity;
            bool[] used = new bool[n];
            int p = 1;
            double len = 0;
            while (p < n || path.Count > 1)
            {
                if (path.Count == n)
                {
                    double thisTourLen = len + distances[0, path.Peek()];
                    if (thisTourLen < tourLen)
                    {
                        tourLen = thisTourLen;
                        path.CopyTo(tour, 0);
                    }
                    p = path.Pop();
                    used[p] = false;
                    len -= distances[path.Peek(), p];
                    p++;
                }
                else if (p == n)
                {
                    p = path.Pop();
                    used[p] = false;
                    len -= distances[path.Peek(), p];
                    p++;
                }
                else if (used[p])
                {
                    p++;
                }
                else
                {
                    used[p] = true;
                    len += distances[path.Peek(), p];
                    path.Push(p);
                    p = 1;
                }
            }
            return tourLen;
        }

        /// <summary>
        /// Produces an array of distances between the given points.
        /// </summary>
        /// <param name="points">The points between which the distances are needed.</param>
        /// <returns>An array such that element [i,j] gives the distance from points[i] to points[j].</returns>
        private double[,] GetDistances(Point[] points)
        {
            double[,] distances = new double[points.Length, points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = 0; j < points.Length; j++)
                {
                    double xDiff = points[i].X - points[j].X;
                    double yDiff = points[i].Y - points[j].Y;
                    distances[i, j] = Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
                }
            }
            return distances;
        }
    }
}
