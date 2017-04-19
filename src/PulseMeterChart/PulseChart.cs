using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PulseMeterChart.PulseMeter;

namespace PulseMeterChart
{
    public partial class PulseChart : UserControl
    {
        IPulseMeter pulseMeter;
        Series pulseWaveSeries;
        Series pulseRateSeries;
        DateTime? startTime;
        System.Timers.Timer heartTimer;
        int count;

        public PulseChart(IPulseMeter thePulseMeter)
        {
            InitializeComponent();

            pulseMeter = thePulseMeter;
            pulseMeter.OnInfoReceived += PulseNotification;

            // Customize
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(50, Color.Gray);
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(50, Color.Gray);

            // Series
            pulseWaveSeries = chart.Series[0];
            pulseWaveSeries.Name = "Pulse Wave";
            pulseWaveSeries.ChartType = SeriesChartType.Spline;
            pulseWaveSeries.Color = Color.FromArgb(0, 174, 219);
            pulseWaveSeries.BorderWidth = 1;
            pulseWaveSeries.MarkerStyle = MarkerStyle.None;

            chart.Series.Add(new Series());
            pulseRateSeries = chart.Series[1];
            pulseRateSeries.Name = "Pulse Rate";
            pulseRateSeries.ChartType = SeriesChartType.Spline;
            pulseRateSeries.Color = Color.Red;
            pulseRateSeries.BorderWidth = 2;
            pulseRateSeries.MarkerStyle = MarkerStyle.None;

            // Adjust size
            chart.Dock = DockStyle.Fill;

            // Heart image
            imgHeart.BackColor = Color.White;

            // Rate label
            lblRate.BackColor = Color.White;
        }

        public void PulseNotification(object sende, IPulseInfo info)
        {
            // Let's refresh every two received packets
            if (count == 1)
            {
                count = 0;
                return;
            }
            else
            {
                count++;
            }

            if (info.IsBeating)
            {
                Beat();
            }

            Invoke(new MethodInvoker(() =>
            {
                startTime = startTime ?? DateTime.Now;

                pulseWaveSeries.Color = Color.FromArgb(0, 174, 219);
                pulseWaveSeries.MarkerColor = Color.Red;

                lblRate.Text = $"Rate: {info.PulseRate} BPM";
                if (!info.IsFingerIn) lblRate.Text = "Finger out";

                var start = startTime.Value;
                var end = DateTime.Now;

                var minTime = DateTime.Now.AddSeconds(-10).ToOADate();
                var maxTime = DateTime.Now.ToOADate();

                // Clean old values
                for (int j = 0; j < pulseWaveSeries.Points.Count; j++)
                {
                    var point = pulseWaveSeries.Points[j];
                    if (point.XValue < minTime)
                    {
                        pulseWaveSeries.Points.RemoveAt(j);
                        pulseRateSeries.Points.RemoveAt(j);
                    }
                }

                chart.Series[0].XValueType = ChartValueType.DateTimeOffset;
                chart.ChartAreas[0].AxisX.LabelStyle.Format = "m':'ss";
                chart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
                chart.ChartAreas[0].AxisX.Interval = 100;
                chart.ChartAreas[0].AxisX.Minimum = minTime;
                chart.ChartAreas[0].AxisX.Maximum = maxTime;
                chart.ChartAreas[0].AxisY.Minimum = 0;
                chart.ChartAreas[0].AxisY.Maximum = 100;

                int i = pulseWaveSeries.Points.AddXY(DateTime.Now.ToOADate(), info.PulseWaveForm);
                pulseRateSeries.Points.AddXY(DateTime.Now.ToOADate(), info.PulseRate);
            }));
        }

        void Beat()
        {
            if (heartTimer != null) return;

            Invoke(new MethodInvoker(() => {
                imgHeart.Visible = true;
            }))
            ;
            heartTimer = new System.Timers.Timer();
            heartTimer.Interval = 100;
            heartTimer.Elapsed += (sedner, args) => {
                heartTimer.Stop();
                heartTimer = null;
                Invoke(new MethodInvoker(() => {
                    imgHeart.Visible = false;
                }));
            };
            heartTimer.Start();
        }

        private void chart_Click(object sender, EventArgs e)
        {

        }

        private void imgHeart_Click(object sender, EventArgs e)
        {

        }
    }
}
