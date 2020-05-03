using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Data;
using System.Globalization;

namespace XMLWithLineReturn
{
    //@example: DataTable to XML with LineReturn
    [XmlRoot(ElementName = "root", Namespace = "urn2", IsNullable = false), Serializable]
    public class Sample
    {
        [XmlElement(ElementName = "value", Namespace = "urn2")]
        public string Value { get; set; }
    }

    class Program
    {
        static void DataTableToXML()
        {
            DataTable dt = new DataTable();
            dt.TableName = "ModemString";
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));

            dt.Rows.Add(1, "abc\r\nadf");
            dt.Rows.Add(2, "adf\r\nxxx");


            DataSet ds = new DataSet("root");
            ds.Tables.Add(dt);
            ds.Locale = CultureInfo.InvariantCulture;
            StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);

            XmlWriterSettings ws = new XmlWriterSettings();
            ws.NewLineHandling = NewLineHandling.Entitize;

            XmlWriter wr = XmlWriter.Create(stringWriter, ws);

            dt.WriteXml(wr);

            string xml = stringWriter.GetStringBuilder().ToString();
            Console.WriteLine(xml);
        }

        static void Main(string[] args)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Sample));
            Sample s = new Sample();
            s.Value = "'\r\n'";
            StringWriter w = new StringWriter();
            XmlWriterSettings ws = new XmlWriterSettings();
            ws.NewLineHandling = NewLineHandling.Entitize;
            using (XmlWriter wr = XmlWriter.Create(w, ws))
            {
                ser.Serialize(wr, s);
            }
            Console.WriteLine(w.GetStringBuilder().ToString());

            Sample s2 = (Sample)ser.Deserialize(new StringReader(w.GetStringBuilder().ToString()));
            foreach (char c in s2.Value.ToCharArray())
            {
                Console.WriteLine((int)c);
            }

            DataTableToXML();
        }
    }
}
