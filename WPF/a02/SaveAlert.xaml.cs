/*
*   DESCRIPTION		:
* 	    Notification window to check with the user if the file is saved
*/

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Shapes;

namespace a02
{
    /// <summary>
    /// Interaction logic for SaveAlert.xaml
    /// </summary>
    public partial class SaveAlert : Window
    {        
        /* Constructor */
        public SaveAlert()
        {
            InitializeComponent();
        }

        /*
         * Method       : DontSave_Click()
         * Description  : Click on the Don't Save button check
         * Parameters   : object sender, ExecutedRoutedEventArgs e
         * Return       : void
         */
        private void DontSave_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = (MainWindow)Owner;
            mw.dontSaveChecker = true;
            this.Close();
        }

        /*
         * Method       : Cancle_Click()
         * Description  : Click on the Cancle button check
         * Parameters   : object sender, ExecutedRoutedEventArgs e
         * Return       : void
         */
        private void Cancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /*
         * Method       : Save_Click()
         * Description  : Click on the Save button check
         * Parameters   : object sender, ExecutedRoutedEventArgs e
         * Return       : void
         */
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = (MainWindow)Owner;
            mw.saveChecker = true;
            mw.SaveFile();
            this.Close();
        }
    }
}
