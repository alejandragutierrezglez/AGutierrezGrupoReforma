using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DatosXML
{
    public class Program
    {
        static void Main(string[] args)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\digis\\Desktop\\XML\\Datos.xml");

            XmlDocument NuevoXML = new XmlDocument();

            XmlDeclaration xmlDeclaration = NuevoXML.CreateXmlDeclaration("1.0", "ISO-8859-1", null);
            NuevoXML.AppendChild(xmlDeclaration);
            XmlNode infoNode = NuevoXML.CreateElement("info");
            NuevoXML.AppendChild(infoNode);

            XmlNode noticiasNode = doc.SelectSingleNode("/noticias");

            foreach (XmlNode noticiaNode in noticiasNode.ChildNodes)
            {
                XmlNode podcastNode = NuevoXML.CreateElement("podcast");
                podcastNode.Attributes.Append(NuevoXML.CreateAttribute("tipo")).Value = noticiaNode.Attributes["tipo"].Value;
                podcastNode.Attributes.Append(NuevoXML.CreateAttribute("libre")).Value = noticiaNode.SelectSingleNode("libre").InnerText;
                podcastNode.Attributes.Append(NuevoXML.CreateAttribute("id")).Value = noticiaNode.SelectSingleNode("id").InnerText;
                podcastNode.Attributes.Append(NuevoXML.CreateAttribute("is3idfp")).Value = noticiaNode.SelectSingleNode("is3idfp").InnerText;
                podcastNode.Attributes.Append(NuevoXML.CreateAttribute("idaudio")).Value = noticiaNode.SelectSingleNode("idaudio").InnerText;


                XmlNode categoriaNode = NuevoXML.CreateElement("categoria");
                categoriaNode.InnerText = noticiaNode.SelectSingleNode("categoria").InnerText;
                podcastNode.AppendChild(categoriaNode);

                XmlNode tituloNode = NuevoXML.CreateElement("titulo");
                tituloNode.InnerText = noticiaNode.SelectSingleNode("titulo").InnerText;
                podcastNode.AppendChild(tituloNode);

                XmlNode resumenNode = NuevoXML.CreateElement("resumen");
                resumenNode.InnerText = noticiaNode.SelectSingleNode("resumen").InnerText;
                podcastNode.AppendChild(resumenNode);

                XmlNode prevurlNode = NuevoXML.CreateElement("prevurl");
                prevurlNode.InnerText = noticiaNode.SelectSingleNode("prevurl").InnerText;
                podcastNode.AppendChild(prevurlNode);

                XmlNode urlNode = NuevoXML.CreateElement("url");
                urlNode.InnerText = noticiaNode.SelectSingleNode("url").InnerText;
                podcastNode.AppendChild(urlNode);

                infoNode.AppendChild(podcastNode);
            }
             Console.WriteLine(NuevoXML.OuterXml);
            NuevoXML.Save("C:\\Users\\digis\\Desktop\\XML\\NuevoArchivoDatosXML.xml");
            Console.ReadKey();

        }
    }
}
