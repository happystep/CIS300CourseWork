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

namespace Ksu.Cis300.CapitalGainCalculator
{
    /// <summary>
    /// A GUI for a capital gain calculator.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The cost of each share currently owned.
        /// </summary>
        private Queue<decimal> _costs = new Queue<decimal>();

        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles a Buy event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxBuy_Click(object sender, EventArgs e)
        {
            decimal n = uxNumber.Value;
            decimal cost = uxCost.Value;
            for (decimal i = 0; i < n; i++)
            {
                _costs.Enqueue(cost);
            }
            uxOwned.Text = _costs.Count.ToString();
        }

        /// <summary>
        /// Handles a Sell event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSell_Click(object sender, EventArgs e)
        {
            decimal n = uxNumber.Value;
            if (n > _costs.Count)
            {
                MessageBox.Show("You don't own that many shares!");
            }
            else
            {
                decimal gain = Convert.ToDecimal(uxGain.Text);
                decimal cost = uxCost.Value;
                for (decimal i = 0; i < n; i++)
                {
                    gain += cost - _costs.Dequeue();
                }
                uxGain.Text = gain.ToString();
                uxOwned.Text = _costs.Count.ToString();
            }
        }
    }
}
