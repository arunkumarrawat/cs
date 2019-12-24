using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace MainLib
{
    public class CXML
    {
        /// <summary>
        /// Delete All Comment in xml
        /// </summary>
        /// <param name="configFile">the path to config File such as 'D:\app.config'</param>
        public void XMLDeleteComment(string configFile)
        {
            XmlDocument doc;
            XmlReader reader;
            // Create the validating reader and specify DTD validation.
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ValidationType = ValidationType.DTD;
            settings.IgnoreComments = true;

            reader = XmlReader.Create(configFile, settings);

            doc = new XmlDocument();
            doc.Load(reader);

            reader.Close();

            XmlWriterSettings writerSettings = new XmlWriterSettings();
            writerSettings.Indent = true;
            XmlWriter writer = XmlWriter.Create(configFile, writerSettings);
            doc.Save(writer);
        }

        /// <summary>
        /// Remove single XML Node, remove xml xmlnode
        /// </summary>
        /// <param name="configFile">the path to config file such as 'D:\app.config'</param>
        /// <param name="xPath">example /configuration/connectionStrings/add[@name="DefaultConnectionString"]</param>
        public void RemoveXmlNode(string configFile, string xPath)
        {
            XmlDocument doc;
            XmlReader reader;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ValidationType = ValidationType.DTD;
            settings.IgnoreComments = true;

            reader = XmlReader.Create(configFile, settings);

            doc = new XmlDocument();
            doc.Load(reader);

            reader.Close();

            XmlNode node = doc.SelectSingleNode(xPath);

            if (node != null)
            {
                XmlNode parentNode = node.ParentNode;
                if (parentNode != null)
                    parentNode.RemoveChild(node);
            }

            XmlWriterSettings writerSettings = new XmlWriterSettings();
            writerSettings.Indent = true;
            XmlWriter writer = XmlWriter.Create(configFile, writerSettings);
            doc.Save(writer);
        }

        /// <summary>
        /// Remove All Children Node example
        /// </summary>
        public void RemoveAllChildrenNodeExample()
        {

            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<book genre='novel' ISBN='1-861001-57-5'>" +
                        "<title>Pride And Prejudice</title>" +
                        "</book>");

            XmlNode root = doc.DocumentElement;

            //Remove all attribute and child nodes.
            root.RemoveAll();

            Console.WriteLine("Display the modified XML...");
            doc.Save(Console.Out);
        }

        /// <summary>
        /// Update configuration file
        /// </summary>
        /// <param name="configFile">Configuration file</param>
        /// <param name="xpath">Path to node</param>
        /// <param name="attribute">Attribute</param>
        /// <param name="value">Value of attribute</param>
        public void UpdateConfig(string configFile,
                                 string xpath,
                                 string attribute,
                                 string value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(configFile);

            XmlNode root = doc.DocumentElement;
            XmlNode node = root.SelectSingleNode(xpath);

            node.Attributes[attribute].Value = value.Remove(value.IndexOf('\0'));

            doc.Save(configFile);
        }


        /// <summary>
        /// Example using Linq to XMl 
        /// </summary>
        public void XmlStringToDictionary()
        {
            string data = "<data><test>foo</test><test>foobbbbb</test><bar>123</bar><username>foobar</username></data>";

            XDocument doc = XDocument.Parse(data);
            Dictionary<string, string> dataDictionary = new Dictionary<string, string>();

            foreach (XElement element in doc.Descendants().Where(p => p.HasElements == false))
            {
                int keyInt = 0;
                string keyName = element.Name.LocalName;

                while (dataDictionary.ContainsKey(keyName))
                {
                    keyName = element.Name.LocalName + "_" + keyInt++;
                }

                dataDictionary.Add(keyName, element.Value);
            }
        }



        // TODO: xml add node

    }
}
