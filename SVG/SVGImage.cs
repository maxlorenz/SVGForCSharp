using System;
using System.Xml.Linq;

namespace Charting_Demo
{
    class SVGImage
    {
        XElement content;
        XNamespace ns = "http://www.w3.org/2000/svg";

        public string strokeColor { set; get; }
        public int strokeWidth { set; get; }

        public string fillColor { set; get; }

        public string fontFamily { get; set; }
        public int fontSize { get; set; }
        public string textAnchor { set; get; }

        public SVGImage(int width, int height)
        {
            content = new XElement(ns + "svg",
                    new XAttribute("xmlns", ns.NamespaceName),
                    new XAttribute("version", "1.1"),
                    new XAttribute("baseProfile", "full"),
                    new XAttribute("width", width.ToString()),
                    new XAttribute("height", height.ToString()),
                    new XAttribute("viewBox", "0 0 " + width + " " + height));

            this.strokeWidth = 1;
            this.strokeColor = "black";
            this.fillColor = "grey";

            this.fontFamily = "Calibri";
            this.fontSize = 14;
            this.textAnchor = "";
        }

        public void addLine(double x1, double y1, double x2, double y2)
        {
            XElement line = new XElement(ns + "line",
                new XAttribute("x1", x1.ToString()),
                new XAttribute("y1", y1.ToString()),
                new XAttribute("x2", x2.ToString()),
                new XAttribute("y2", y2.ToString()),
                new XAttribute("fill", this.fillColor),
                new XAttribute("stroke", this.strokeColor),
                new XAttribute("stroke-width", this.strokeWidth.ToString()));

            content.Add(line);
        }

        public void addRect(double x, double y, double width, double height)
        {
            XElement rect = new XElement(ns + "rect",
                new XAttribute("x", x.ToString()),
                new XAttribute("y", y.ToString()),
                new XAttribute("width", width.ToString()),
                new XAttribute("height", height.ToString()),
                new XAttribute("fill", this.fillColor),
                new XAttribute("stroke", this.strokeColor),
                new XAttribute("stroke-width", this.strokeWidth.ToString()));

            content.Add(rect);
        }

        public void addCircle(double x, double y, double radius)
        {
            XElement circle = new XElement(ns + "circle",
                new XAttribute("cx", x.ToString()),
                new XAttribute("cy", y.ToString()),
                new XAttribute("r", radius.ToString()),
                new XAttribute("fill", this.fillColor),
                new XAttribute("stroke", this.strokeColor),
                new XAttribute("stroke-width", this.strokeWidth.ToString()));

            content.Add(circle);
        }

        public void addPolygon(string points, string transform = "")
        {
            XElement polygon = new XElement(ns + "polygon",
                new XAttribute("points", points),
                new XAttribute("transform", transform),
                new XAttribute("stroke", this.strokeColor),
                new XAttribute("stroke-width", this.strokeWidth.ToString()));

            content.Add(polygon);
        }

        public void addArc(dynamic x1, dynamic y1, dynamic x2, dynamic y2, int radius, int largeArc, int sweep)
        {
            XElement arc = new XElement(ns + "path",
                new XAttribute("d", String.Format("M{0},{1} A{2},{2} 0 {3},{4} {5},{6}", x1, y1, radius, largeArc, sweep, x2, y2)),
                new XAttribute("stroke", this.strokeColor),
                new XAttribute("stroke-width", this.strokeWidth.ToString()),
                new XAttribute("fill", this.fillColor));

            content.Add(arc);
        }

        public void addText(double x, double y, string Text, string transform = "")
        {
            XElement text = new XElement(ns + "text",
                new XAttribute("x", x.ToString()),
                new XAttribute("y", y.ToString()),
                new XAttribute("transform", transform),
                new XAttribute("stroke", this.strokeColor),
                new XAttribute("fill", this.fillColor),
                new XAttribute("font-family", this.fontFamily),
                new XAttribute("font-size", this.fontSize.ToString()),
                new XAttribute("text-anchor", this.textAnchor),
                    Text);

            content.Add(text);
        }

        public string getSVGString()
        {
            XDocument returnXML = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), content);
            return returnXML.Declaration.ToString() + returnXML.ToString();
        }

        // Public operators

        public static string translate(int x, int y)
        {
            return String.Format("translate({0} {1})", x, y);
        }

        public static string scale(int x, int y)
        {
            return String.Format("scale({0} {1})", x, y);
        }

        public static string rotate(int angle)
        {
            return String.Format("rotate({0})", angle);
        }

        public static string rotate(int angle, int x, int y)
        {
            return String.Format("rotate({0} {1} {2})", angle, x, y);
        }

        public static string polygonPath(params int[] points)
        {
            return String.Join(" ", points);
        }
    }
}
