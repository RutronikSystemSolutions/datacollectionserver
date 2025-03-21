using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot.Legends;
using System.Runtime.Intrinsics.X86;
using System.Net.NetworkInformation;

namespace datacollectionserver
{
    public partial class LiveSignalView : UserControl
    {
        /// <summary>
        /// X Axis
        /// </summary>
        LinearAxis xAxis = new LinearAxis
        {
            MajorGridlineStyle = LineStyle.Dot,
            Position = AxisPosition.Bottom,
            AxislineStyle = LineStyle.Solid,
            AxislineColor = OxyColors.Gray,
            FontSize = 10,
            PositionAtZeroCrossing = true,
            IsPanEnabled = false,
            IsZoomEnabled = true,
            Unit = "#"
        };

        /// <summary>
        /// Y Axis for amplitude
        /// </summary>
        private LinearAxis yAxis = new LinearAxis
        {
            MajorGridlineStyle = LineStyle.Dot,
            AxislineStyle = LineStyle.Solid,
            AxislineColor = OxyColors.Gray,
            FontSize = 10,
            TextColor = OxyColors.Gray,
            Position = AxisPosition.Left,
            IsPanEnabled = false,
            IsZoomEnabled = true,
            Minimum = -32767,
            Maximum = 32767,
            Unit = "Tick",
            Key = "Amp",
        };

        private LineSeries lineSerie = new LineSeries();
        private double counter = 0;

        public LiveSignalView()
        {
            InitializeComponent();
            InitPlot();
        }

        private void InitPlot()
        {
            // Raw signals plot
            var timeModel = new PlotModel
            {
                PlotType = PlotType.XY,
                PlotAreaBorderThickness = new OxyThickness(0),
            };

            // Set the axes
            timeModel.Axes.Add(xAxis);
            timeModel.Axes.Add(yAxis);

            // Add series
            lineSerie = new LineSeries();
            lineSerie.Title = "Live signal";
            lineSerie.YAxisKey = yAxis.Key;
            timeModel.Series.Add(lineSerie);

            plotView.Model = timeModel;
            plotView.InvalidatePlot(true);
        }

        public void Feed(short[] data)
        {
            if (data == null) return;
            if (data.Length == 0) return;

            for (int i = 0; i < data.Length; i++)
            {
                lineSerie.Points.Add(new DataPoint(counter, data[i]));
                counter++;

                if (lineSerie.Points.Count > 16000) lineSerie.Points.RemoveAt(0);
            }

            plotView.InvalidatePlot(true);
        }

        public void Clear()
        {
            counter = 0;
            lineSerie.Points.Clear();
            plotView.InvalidatePlot(true);
        }
    }
}
