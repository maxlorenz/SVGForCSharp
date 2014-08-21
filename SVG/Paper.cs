using System.Xml.Linq;

namespace SVG
{
    class Paper
    {

        private static XNamespace ns = "http://www.w3.org/2000/svg";
        public XElement content;

        public Paper(string identifier)
        {
            this.content = new XElement(ns + identifier);
        }

        public Paper(string identifier, string value)
        {
            this.content = new XElement(ns + identifier, value);
        }

        public static Paper root(dynamic width, dynamic height) {
            Paper root = new Paper("svg");
            root.setAttribute("xmlns", ns.NamespaceName);
            root.setAttribute("version", "1.1");
            root.setAttribute("baseProfile", "full");
            root.setAttribute("width", width.ToString());
            root.setAttribute("height", height.ToString());
            root.setAttribute("viewBox", "0 0 " + width + " " + height);

            return root;
        }

        public static Paper circle(double x, double y, double r)
        {
            Paper circle = new Paper("circle");
            circle.setAttribute("cx", x);
            circle.setAttribute("cy", y);
            circle.setAttribute("r", r);

            circle.setAttribute("fill", "none");
            circle.setAttribute("stroke", "blue");

            return circle; 
        }

        public static Paper ellipse(double x, double y, double rx, double ry)
        {
          Paper ellipse = new Paper("ellipse");
          ellipse.setAttribute("x", x);
          ellipse.setAttribute("y", y);
          ellipse.setAttribute("rx", rx);
          ellipse.setAttribute("ry", ry);

          return ellipse; 
        }

        public static Paper image(string path, double x, double y, double width, double height)
        {
          Paper image = new Paper("image");
          image.setAttribute("path", path);
          image.setAttribute("x", x);
          image.setAttribute("y", y);
          image.setAttribute("width", width);
          image.setAttribute("height", height);

          return image; 
        }

        public static Paper path(string pathString)
        {
          Paper path = new Paper("path");
          path.setAttribute("pathstring", pathString);

          return path; 
        }

        public static Paper rect(double x, double y, double width, double height, double roundedCorners = 0)
        {
          Paper rect = new Paper("rect");
          rect.setAttribute("x", x);
          rect.setAttribute("y", y);
          rect.setAttribute("width", width);
          rect.setAttribute("height", height);
          rect.setAttribute("r", roundedCorners);

          return rect; 
        }

        public static Paper text(double x, double y, string shownText)
        {
          Paper text = new Paper("text", shownText);
          text.setAttribute("x", x);
          text.setAttribute("y", y);

          return text; 
        }

        public void setAttribute(string attribute, dynamic value) {
            this.content.SetAttributeValue(attribute, value.ToString());
        }

        public void add(Paper element)
        {
            this.content.Add(element.content);
        }

        public string getSVGString()
        {
            XDocument returnXML = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), this.content);
            return returnXML.Declaration.ToString() + returnXML.ToString();
        }
    }
}
