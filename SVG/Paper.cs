using System.Globalization;
using System.Xml.Linq;

namespace SVG
{
    public class Paper
    {

        static XNamespace ns = "http://www.w3.org/2000/svg";
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
            root.setAttribute("width", width);
            root.setAttribute("height", height);
            root.setAttribute("viewBox", "0 0 " + width + " " + height);

            return root;
        }

        public static Paper group()
        {
            return new Paper("g");
        }

        public static Paper line(double x1, double y1, double x2, double y2)
        {
            Paper line = new Paper("line");
            line.setAttribute("x1", x1);
            line.setAttribute("y1", y1);
            line.setAttribute("x2", x2);
            line.setAttribute("y2", y2);

            line.setAttribute(PaperSettings.fillColor, "none");
            line.setAttribute(PaperSettings.strokeWidth, 1);
            line.setAttribute(PaperSettings.strokeColor, "black");

            return line;
        }

        public static Paper circle(double x, double y, double r)
        {
            Paper circle = new Paper("circle");
            circle.setAttribute("cx", x);
            circle.setAttribute("cy", y);
            circle.setAttribute("r", r);

            circle.setAttribute("fill", "none");
            circle.setAttribute("stroke", "black");

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
          rect.setAttribute("rx", roundedCorners);

          rect.setAttribute("fill", "none");
          rect.setAttribute("stroke", "black");

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
            this.content.SetAttributeValue(attribute, value.ToString(CultureInfo.InvariantCulture));
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

    class PaperSettings
    {
        public static string fillColor = "fill";
        public static string strokeColor = "stroke";
        public static string strokeWidth = "stroke-width";

        public static string fontFamily = "font-family";
        public static string fontSize = "font-size";

        public static string textAnchor = "text-anchor";
    }

    class PaperText
    {
        public static string textAnchorStart = "start";
        public static string textAnchorMiddle = "middle";
        public static string textAnchorEnd = "end";
    }

    class PaperColor
    {
        public static string none = "none";

        public static string aliceblue = "aliceblue";
        public static string antiquewhite = "antiquewhite";
        public static string aquamarine = "aquamarine";
        public static string azure = "azure";
        public static string beige = "beige";
        public static string bisque = "bisque";
        public static string blanchedalmond = "blanchedalmond";
        public static string blueviolet = "blueviolet";
        public static string brown = "brown";
        public static string burlywood = "burlywood";
        public static string cadetblue = "cadetblue";
        public static string chartreuse = "chartreuse";
        public static string chocolate = "chocolate";
        public static string coral = "coral";
        public static string cornflowerblue = "cornflowerblue";
        public static string cornsilk = "cornsilk";
        public static string crimson = "crimson";
        public static string darkblue = "darkblue";
        public static string darkcyan = "darkcyan";
        public static string darkgoldenrod = "darkgoldenrod";
        public static string darkgray = "darkgray";
        public static string darkgreen = "darkgreen";
        public static string darkgrey = "darkgrey";
        public static string darkkhaki = "darkkhaki";
        public static string darkmagenta = "darkmagenta";
        public static string darkolivegreen = "darkolivegreen";
        public static string darkorange = "darkorange";
        public static string darkorchid = "darkorchid";
        public static string darkred = "darkred";
        public static string darksalmon = "darksalmon";
        public static string darkseagreen = "darkseagreen";
        public static string darkslateblue = "darkslateblue";
        public static string darkslategray = "darkslategray";
        public static string darkslategrey = "darkslategrey";
        public static string darkturquoise = "darkturquoise";
        public static string darkviolet = "darkviolet";
        public static string deeppink = "deeppink";
        public static string deepskyblue = "deepskyblue";
        public static string dimgray = "dimgray";
        public static string dimgrey = "dimgrey";
        public static string dodgerblue = "dodgerblue";
        public static string firebrick = "firebrick";
        public static string floralwhite = "floralwhite";
        public static string forestgreen = "forestgreen";
        public static string gainsboro = "gainsboro";
        public static string ghostwhite = "ghostwhite";
        public static string gold = "gold";
        public static string goldenrod = "goldenrod";
        public static string greenyellow = "greenyellow";
        public static string honeydew = "honeydew";
        public static string hotpink = "hotpink";
        public static string indianred = "indianred";
        public static string indigo = "indigo";
        public static string ivory = "ivory";
        public static string khaki = "khaki";
        public static string lavender = "lavender";
        public static string lavenderblush = "lavenderblush";
        public static string lawngreen = "lawngreen";
        public static string lemonchiffon = "lemonchiffon";
        public static string lightblue = "lightblue";
        public static string lightcoral = "lightcoral";
        public static string lightcyan = "lightcyan";
        public static string lightgoldenrodyellow = "lightgoldenrodyellow";
        public static string lightgray = "lightgray";
        public static string lightgreen = "lightgreen";
        public static string lightgrey = "lightgrey";
        public static string lightpink = "lightpink";
        public static string lightsalmon = "lightsalmon";
        public static string lightseagreen = "lightseagreen";
        public static string lightskyblue = "lightskyblue";
        public static string lightsteelblue = "lightsteelblue";
        public static string lightyellow = "lightyellow";
        public static string limegreen = "limegreen";
        public static string linen = "linen";
        public static string mediumaquamarine = "mediumaquamarine";
        public static string mediumblue = "mediumblue";
        public static string mediumorchid = "mediumorchid";
        public static string mediumpurple = "mediumpurple";
        public static string mediumseagreen = "mediumseagreen";
        public static string mediumslateblue = "mediumslateblue";
        public static string mediumspringgreen = "mediumspringgreen";
        public static string mediumturquoise = "mediumturquoise";
        public static string mediumvioletred = "mediumvioletred";
        public static string midnightblue = "midnightblue";
        public static string mintcream = "mintcream";
        public static string mistyrose = "mistyrose";
        public static string moccasin = "moccasin";
        public static string navajowhite = "navajowhite";
        public static string olivedrab = "olivedrab";
        public static string orange = "orange";
        public static string orangered = "orangered";
        public static string orchid = "orchid";
        public static string palegoldenrod = "palegoldenrod";
        public static string palegreen = "palegreen";
        public static string paleturquoise = "paleturquoise";
        public static string palevioletred = "palevioletred";
        public static string papayawhip = "papayawhip";
        public static string peachpuff = "peachpuff";
        public static string peru = "peru";
        public static string pink = "pink";
        public static string plum = "plum";
        public static string powderblue = "powderblue";
        public static string rosybrown = "rosybrown";
        public static string royalblue = "royalblue";
        public static string saddlebrown = "saddlebrown";
        public static string salmon = "salmon";
        public static string sandybrown = "sandybrown";
        public static string seagreen = "seagreen";
        public static string seashell = "seashell";
        public static string sienna = "sienna";
        public static string skyblue = "skyblue";
        public static string slateblue = "slateblue";
        public static string slategray = "slategray";
        public static string slategrey = "slategrey";
        public static string snow = "snow";
        public static string springgreen = "springgreen";
        public static string steelblue = "steelblue";
        public static string tan = "tan";
        public static string thistle = "thistle";
        public static string tomato = "tomato";
        public static string turquoise = "turquoise";
        public static string violet = "violet";
        public static string wheat = "wheat";
        public static string whitesmoke = "whitesmoke";
        public static string yellowgreen = "yellowgreen";
    }
}
