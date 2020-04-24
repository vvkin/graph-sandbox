using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
            sr.WriteLine("<graphml xmlns='http://graphml.graphdrawing.org/xmlns'\n xmlns:xsi = 'http://www.w3.org/2001/XMLSchema-instance' \n xsi: schemaLocation = 'http://graphml.graphdrawing.org/x \n http://graphml.graphdrawing.org/xmlns/1.0/graphml.xsd'>");
            sr.WriteLine("  <key id='d1' for='edge' attr.name='weight' attr.type='float'/>");
            sr.WriteLine("  <graph id='G'>");
            foreach(Circle vertex in ds.Vertices)
            {
                sr.WriteLine($"      <node id ='n{vertex.uniqueNumber-1}'/>");
            }
            foreach(Edge edge in ds.Edges)
            {
                sr.WriteLine($"      <edge directed='{edge.isDirected.ToString().ToLower()}' source='n{edge.start}' target='n{edge.end}'>");
                sr.WriteLine($"        <data key='d1'>{edge.w}.0</data>");
                sr.WriteLine($"      </edge>");
            }
            sr.WriteLine("  </graph>");
            sr.WriteLine("</graphml>");
            sr.Close();
        }
        public void UpLoad(DrawingSurface ds)
        {
        }
    }

}