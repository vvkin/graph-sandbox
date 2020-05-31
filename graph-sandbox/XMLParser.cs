using System;
using System.IO;
using System.Xml;
namespace graph_sandbox
{
    class XMLParser
    {
        private readonly string filename;
        public XMLParser(string filename) { this.filename = filename; }
        public void Save(DrawingSurface ds)
        {
            FileStream fs = File.Create(filename);
            fs.Close();
            StreamWriter sr = new StreamWriter(filename);
            sr.WriteLine("<?xml version='1.0' encoding='utf-8'?>");
            sr.WriteLine("<graphml xmlns='http://graphml.graphdrawing.org/xmlns'\n xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' \n xsi:schemaLocation='http://graphml.graphdrawing.org/x \n http://graphml.graphdrawing.org/xmlns/1.0/graphml.xsd'>");
            sr.WriteLine("  <key id='d1' for='edge' attr.name='weight' attr.type='float'/>");
            sr.WriteLine("  <graph id='G'>");
            foreach (Circle vertex in ds.Vertices)
            {
                sr.WriteLine($"      <node id ='{vertex.uniqueNumber - 1}'/>");
            }
            foreach (Edge edge in ds.Edges)
            {
                sr.WriteLine($"      <edge directed='{edge.isDirected.ToString().ToLower()}' source='{edge.start}' target='{edge.end}'>");
                sr.WriteLine($"        <data key='d1'>{edge.w},0</data>");
                sr.WriteLine($"      </edge>");
            }
            sr.WriteLine("  </graph>");
            sr.WriteLine("</graphml>");
            sr.Close();
        }
        public void UpLoad(DrawingSurface ds)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(filename);
            XmlElement xroot = xml.DocumentElement;
            ds.Edges.Clear();
            Circle.number = 0;
            ds.Vertices.Clear();
            foreach (XmlElement xnode in xroot)
            {
                foreach (XmlElement xNode in xnode)
                {
                    if (xNode.Name == "node")
                    {
                        var c = new Circle(0,0);
                        c.uniqueNumber = Convert.ToInt32(xNode.GetAttribute("id")) + 1;
                        ds.Vertices.Add(c);
                    }
                    if (xNode.Name == "edge")
                    {
                        var isDirected = xNode.GetAttribute("directed") == "true" ? true : false;
                        Console.WriteLine(xNode.GetAttribute("source"));
                        var startVertex = ds.Vertices[Convert.ToInt32(xNode.GetAttribute("source"))];
                        var endVertex = ds.Vertices[Convert.ToInt32(xNode.GetAttribute("target"))];
                        var weight = (float)Convert.ToDouble(xNode.FirstChild.InnerText);
                        var edge = new Edge(startVertex, endVertex, weight, isDirected);
                        ds.Edges.Add(edge);
                    }
                }
            }
            
        }
    }
}