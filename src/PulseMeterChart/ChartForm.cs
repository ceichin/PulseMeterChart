using PulseMeterChart.PulseMeter.CMS50DPlus;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PulseMeterChart
{
    public partial class ChartForm : Form
    {
        public ChartForm()
        {
            InitializeComponent();

            var chart = new PulseChart(new CMS50DPlus());
            chart.Location = new Point(0, 0);
            Controls.Add(chart);
            Size = new Size(680, 360);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
