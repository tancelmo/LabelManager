using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelManager
{
    public class Common
    {
        
        
        public static void GetPrinter(ComboBox comboBox)
        {
            ConfigFile GetConfig = new ConfigFile("C:\\Users\\bakur\\Desktop\\config.ini");
            comboBox.Items.Add(GetConfig.Read("Location", "Printer"));
        }

        public static void GetLabels(ComboBox comboBox)
        {
            ConfigFile GetConfig = new ConfigFile("C:\\Users\\bakur\\Desktop\\config.ini");
            comboBox.Items.Add(GetConfig.Read("LabelTemplate", "Label"));
        }
    }
}
