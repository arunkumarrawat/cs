using Microsoft.Web.Mvc.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace asp.net_mvc_cli
{
    class Program
    {
        static void Main(string[] args)
        {
            StringWriter stringWriter = new StringWriter();

            HtmlTextWriter writer = new HtmlTextWriter(stringWriter);

            Label label = new Label();
            label.Name = "Name: ";
            label.ID = "123";
            label.EnableViewState = true;
            label.PublicRender(writer);

            Console.WriteLine(stringWriter.ToString());
        }
    }
}
