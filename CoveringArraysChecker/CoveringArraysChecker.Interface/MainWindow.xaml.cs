using Microsoft.Win32;
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

namespace CoveringArraysChecker.Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static File currentFile;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (currentFile == null)
                {
                    throw new Exception("No file chosen !");
                }

                Checker checker = new Checker(currentFile);
                checker.CheckAllColumns();
                lblResult.Content = Log.ReadResult();
            }
            catch (Exception ex)
            {
                lblResult.Content = "Error !" + Environment.NewLine + ex.Message;
            }
        }

        private void btnChoseFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ofd = new OpenFileDialog();
                ofd.ShowDialog();
                currentFile = new File(ofd.FileName);
                lblArray.Content = Log.ReadArray();
            }
            catch (Exception)
            {
                // No file selected
            }
        }
    }
}
