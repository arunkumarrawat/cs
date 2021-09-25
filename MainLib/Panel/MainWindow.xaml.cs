using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Panel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_ncpa_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("control", "ncpa.cpl");
        }

        private void btn_locale_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("control", "intl.cpl");
        }

        private void btn_system_property_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("control", "sysdm.cpl");
        }

        private void btn_desktop_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("control", "desk.cpl");
        }

        private void btn_iis_Click(object sender, RoutedEventArgs e)
        {
            string path = @"C:\Windows\SysWOW64\inetsrv\InetMgr.exe";
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = System.IO.Path.GetFileName(path);
            p.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(path);
            p.Start();
        }

        private void btn_appwiz_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("control", "appwiz.cpl");
        }
    }
}
