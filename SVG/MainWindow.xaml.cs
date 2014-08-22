using System;
using System.Windows;

namespace SVG
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int demoCounter = 7;

        public MainWindow()
        {
            InitializeComponent();

            webView.NavigateToString(getDemoChart(demoCounter).getSVGString());
        }

        public Paper getDemoChart(int count)
        {
            Paper chart = Paper.root(demoCounter * demoCounter * 5, 50 * demoCounter);

            int x = 50;
            int y = 50;

            int barHeight = 20;
            int barCount = count;

            int gridLines = 7;

            // Add grid for chart
            chart.add(grid(x, y, x + barCount * (barHeight + 2), 100, gridLines));

            // Add bars 
            for (int i = 1; i <= (barCount + 1); i++)
            {
                chart.add(bar(x, i * (barHeight + 2) + y, barHeight, i * i));
            }

            return chart;
        }

        public Paper bar(int x, int y, int height, int length)
        {
            Paper bar = Paper.group();

            Paper rect = Paper.rect(x, y, length, height);
            rect.setAttribute(PaperSettings.fillColor, PaperColor.steelblue);
            rect.setAttribute(PaperSettings.strokeColor, PaperColor.none);

            Paper value = Paper.text(x + length + 5, y + height - 5, (length).ToString());
            value.setAttribute(PaperSettings.fillColor, "gray");
            value.setAttribute(PaperSettings.fontFamily, "Calibri");

            bar.add(rect);
            bar.add(value);

            return bar;
        }

        public Paper grid(int x, int y, int height, int length, int lines)
        {
            Paper grid = Paper.group();

            for (int i = x; i < height + y; i = i + height / lines)
            {
                Paper line = Paper.line(i + 0.5, y, i + 0.5, y + height);
                line.setAttribute("opacity", 0.1);

                Paper value = Paper.text(i, y + height + 15, (i - x).ToString());
                value.setAttribute(PaperSettings.fontFamily, "Calibri");
                value.setAttribute(PaperSettings.textAnchor, PaperText.textAnchorMiddle);

                grid.add(line);
                grid.add(value);
            }

            return grid;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            demoCounter++;
            webView.NavigateToString(getDemoChart(demoCounter).getSVGString());
        }
    }
}
