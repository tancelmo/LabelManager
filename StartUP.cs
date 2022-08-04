using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelManager
{
    internal class StartUP
    {
        public static void CreateFilesIfNotExist()
        {
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string specificFolder = Path.Combine(directory, "Label Manager");
            

            if (!Directory.Exists(specificFolder))
            {
                Directory.CreateDirectory(specificFolder);
                

            }

            if (!File.Exists(specificFolder + "\\Config.ini"))
            {

                CreateConfigFile();
            }

            if (!File.Exists(specificFolder + "\\Printers.ini"))
            {

                CreatePrintersFile();
            }

            if (!File.Exists(specificFolder + "\\Labels.ini"))
            {

                CreateLabelsFile();
            }
        }
        internal static void CreateConfigFile()
        {
            using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Label Manager\\Config.ini", append: true))
            {
                writer.Write(
    @"[General]

[Printer]
Location =\\ame-dgs-cyble\GasEtiqueta88

[Label]
LabelTemplate=Techem.prn");
            }
        }
        internal static void CreatePrintersFile()
        {
            using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Label Manager\\Printers.ini", append: true))
            {
                writer.Write(@"\\ame-dgs-cyble\GasEtiqueta");
            }
        }

        internal static void CreateLabelsFile()
        {
            using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Label Manager\\Labels.ini", append: true))
            {
                writer.Write(@"Techem.prn");
            }
        }
    }
}
