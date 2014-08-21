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

            Paper root = Paper.root(300, 400);
            root.add(Paper.text(100, 100, "test"));

            Paper circle = Paper.circle(100, 100, 50);
            circle.setAttribute("stroke", "green");
            root.add(circle);

            root.add(Paper.rect(200, 200, 50, 60, 20));

            webView.NavigateToString(root.getSVGString());
            Console.WriteLine(root.getSVGString());
        }
    }
}
