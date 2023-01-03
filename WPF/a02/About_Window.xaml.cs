/*
*   DESCRIPTION		:
* 	    Notification window to show the information
*/

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
using System.Windows.Shapes;

namespace a02
{
    /// <summary>
    /// Interaction logic for About_Window.xaml
    /// </summary>
    public partial class About_Window : Window
    {
        /* Constructor */
        public About_Window()
        {
            InitializeComponent();
        }

       /*
        * Method       : BtnOK_Click()
        * Description  : Click on the OK button check
        * Parameters   : object sender, ExecutedRoutedEventArgs e
        * Return       : void
        */
        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
