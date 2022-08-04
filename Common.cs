using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelManager
{
    public class Common
    {
        
        
        public static void GetPrinter(ComboBox comboBox)
        {
            var printers = File.ReadLines(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Label Manager\\Printers.ini");
            //ConfigFile GetConfig = new ConfigFile(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "Printers.ini");
            //comboBox.Items.Add(printers);
            comboBox.ItemsSource = printers;
        }

        public static void GetLabels(ComboBox comboBox)
        {
            var labels = File.ReadLines(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Label Manager\\Labels.ini");
            comboBox.ItemsSource = labels;
        }

        
        
    }
}
