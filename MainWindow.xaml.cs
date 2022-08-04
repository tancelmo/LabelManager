using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LabelManager
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            StartUP.CreateFilesIfNotExist();
            #region Window StartUp Size
            //Window StartUp Size//

            IntPtr hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this); // m_window in App.cs
            WindowId windowId = Win32Interop.GetWindowIdFromWindow(hWnd);
            AppWindow appWindow = AppWindow.GetFromWindowId(windowId);
            
            var size = new Windows.Graphics.SizeInt32();
            size.Width = 580;
            size.Height = 380;
            appWindow.Resize(size);
            #endregion

            #region Window Configuration
            var presenter = AppWindow.GetFromWindowId(windowId).Presenter as OverlappedPresenter;
            presenter.IsResizable = false;
            presenter.IsMaximizable = false;
            
            #endregion

            

            Title = "Label Manager";
            

            //ExtendsContentIntoTitleBar = true;
            //SetTitleBar(AppTitleBar);

            Common.GetPrinter(Cbx_Printer);
            Common.GetLabels(Cbx_Label);
            
        }

        private void Tbx_SN_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Tbx_SN.Text.Length == 12)
            {
                Tbx_CN.Focus(FocusState.Programmatic);
            }
        }

        private void Tbx_CN_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Tbx_SN.Text.Length == 12 && Tbx_CN.Text.Length == 9)
            {
                Historic.Items.Insert(0, Tbx_SN.Text + " - " + Tbx_CN.Text);
                Tbx_CN.Text = string.Empty;
                Tbx_SN.Text = string.Empty;
                Tbx_SN.Focus(FocusState.Programmatic);
               // DisplayNoWifiDialog();
                Print();
            }
        }

        private void Print()
        {
            ConfigFile configFile = new ConfigFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Label Manager\\Config.ini");
            string showPrompt;
            if(configFile.Read("ShowPrompt","General") == "1")
            {
                showPrompt = "/k";
            }
            else
            {
                showPrompt = "/c";
            }
            string strCmdText;
            strCmdText = showPrompt + " copy " + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Label Manager\\" + Cbx_Label.SelectedItem.ToString() + " /b " + Cbx_Printer.SelectedItem.ToString();
            configFile.Write("test", showPrompt + " copy " + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Label Manager\\" + Cbx_Label.SelectedItem.ToString() + " /b " + Cbx_Printer.SelectedItem.ToString());



            System.Diagnostics.Process.Start("CMD.exe", strCmdText);
        }
        private async void DisplayNoWifiDialog()
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = "No wifi connection",
                Content = @"/c copy " + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Label Manager\\" + Cbx_Label.SelectedItem.ToString() + " /b " + Cbx_Printer.SelectedItem.ToString(),
                CloseButtonText = "Ok"
                 
        };
            //await noWifiDialog.ShowAsync();
            noWifiDialog.XamlRoot = this.Content.XamlRoot;
            ContentDialogResult result = await noWifiDialog.ShowAsync();

            //System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Label Manager22\\Printers.ini")
            //{
            //    FileName = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Label Manager\\",
            //    UseShellExecute = true,
            //    Verb = "open"
            //});
        }
    }
}
