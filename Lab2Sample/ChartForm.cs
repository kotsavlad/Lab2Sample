using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab2Sample
{
    public partial class ChartForm : Form
    {
        private readonly int[] _counts1;
        private readonly int[] _counts2;

        public ChartForm(int[] counts1, int[] counts2)
        {
            _counts1 = counts1;
            _counts2 = counts2;
            InitializeComponent();
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {
            chart.Titles.Add("Number of unique elements by rows");
            chart.ChartAreas[0].AxisX.Title = "Row index";
            chart.Series.Clear();
            AddSeries(_counts1, "matrix 1");
            AddSeries(_counts2, "matrix 2");

            void AddSeries(int[] dataVector, string name)
            {
                var series = new Series { ChartType = SeriesChartType.Column, Name = name };
                for (int i = 0; i < dataVector.Length; i++)
                {
                    series.Points.AddXY(i, dataVector[i]);
                }
                chart.Series.Add(series);
            }
        }
    }
}