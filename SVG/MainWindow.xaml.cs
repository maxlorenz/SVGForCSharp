using System;
using System.Windows;

namespace SVG
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Paper root = Paper.root(700, 400);

            for (int i = 1; i < 10; i++)
            {
                root.add(bar(50, i * 22 + 50, 20, i * i + new Random().Next(100)));
            }

            webView.NavigateToString(root.getSVGString());
            Console.WriteLine(root.getSVGString());
        }

        public Paper bar(int x, int y, int height, int length)
        {
            Paper bar = Paper.group();

            Paper rect = Paper.rect(x, y, length, height);
            rect.setAttribute(PaperSettings.fillColor, PaperColor.steelblue);
            rect.setAttribute(PaperSettings.strokeColor, PaperColor.none);

            Paper value = Paper.text(x + length + 5, y + height - 5, (length).ToString());
            value.setAttribute(PaperSettings.fillColor, "black");
            value.setAttribute(PaperSettings.fontFamily, "Calibri");

            bar.add(rect);
            bar.add(value);

            return bar;
        }
    }
}
