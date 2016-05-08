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
            bool[] used = new bool[points.Length];
            LinkedListCell<int> tour;
            double tourLen = ComputeBestCompletion(0, 0, used, 1, distances, Double.PositiveInfinity, out tour);
            DisplayResults(points, tour, tourLen);
        }

        /// <summary>
        /// Displays the minimum tour information.
        /// </summary>
        /// <param name="points">The given points.</param>
        /// <param name="tour">The indices of a minimum-length tour, in order.</param>
        /// <param name="tourLen">The length of a shortest tour.</param>
        private void DisplayResults(Point[] points, LinkedListCell<int> tour, double tourLen)
        {
            uxTourPoints.Items.Add(points[0]);
            int prev = 0;
            for (LinkedListCell<int> p = tour; p != null; p = p.Next)
            {
                uxPanel.DrawLine(points[p.Data], points[prev]);
                uxTourPoints.Items.Add(points[p.Data]);
                prev = p.Data;
            }
            MessageBox.Show("Tour length: " + tourLen);
        }

        /// <summary>
        /// Computes the best completion of a tour consisting of the points indicated in used and ending with cur.
        /// </summary>
        /// <param name="cur">The point from which the tour should continue.</param>
        /// <param name="len">The length of the path to cur.</param>
        /// <param name="used">Indicates which points have been used in the path to cur.</param>
        /// <param name="pointsUsed">The number of points in the path to cur.</param>
        /// <param name="distances">The distances between pairs of points.</param>
        /// <param name="min">The minimum length of any tour found so far.</param>
        /// <param name="bestPath">The points on the best completion. If the best completion is not shorter than min, this value is not meaningful.</param>
        /// <returns>The length of the shortest completion, or a value of at least min if no completion is shorter than min.</returns>
        private double ComputeBestCompletion(int cur, double len, bool[] used, int pointsUsed, double[,] distances, double min, out LinkedListCell<int> bestPath)
        {
            if (len >= min)
            {
                bestPath = null;
                return len;
            }
            else if (pointsUsed == used.Length)
            {
                bestPath = new LinkedListCell<int>();
                bestPath.Data = 0;
                return len + distances[cur, 0];
            }
            else
            {
                LinkedListCell<int> bestPoint = new LinkedListCell<int>();
                for (int i = 1; i < used.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        double compLen = ComputeBestCompletion(i, len + distances[cur, i], used, pointsUsed + 1, distances, min, out bestPath);
                        used[i] = false;
                        if (compLen < min)
                        {
                            min = compLen;
                            bestPoint.Data = i;
                            bestPoint.Next = bestPath;
                        }
                    }
                }
                bestPath = bestPoint;
                return min;
            }
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
