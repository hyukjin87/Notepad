/*
* DESCRIPTION		:
* 	This program functions similar to Notepad.
*	It can load or save a text file.
*	Copy and cut and paste features are available.
*/

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
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

namespace a02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /* Property */
        public bool isDataDirty { get; set; } 
        public bool saveChecker { get; set; }
        public bool dontSaveChecker { get; set; }
        /* Constructor */
        public MainWindow()
        {
            InitializeComponent();
            InputTxt.Focus();           // Cursor position text box at program start
        }

        /*
         * Method       : SaveFile()
         * Description  : Method for save text file
         * Parameters   : None
         * Return       : void
         */
        public void SaveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                FileName = ".txt",
                Filter = "txt file|*.txt|All file|*.*",
                InitialDirectory = Directory.GetCurrentDirectory()
            };

            bool? result = saveFileDialog.ShowDialog();
            if (result == true)
            {
                File.WriteAllText(saveFileDialog.FileName, InputTxt.Text);
                this.Title = saveFileDialog.SafeFileName;                   // Add the title of the current file to the title
                isDataDirty = false;                                        // Check for changes in files
            }
            else
            {
                saveChecker = false;
            }
        }

        /*
         * Method       : OpenFile()
         * Description  : Method for load text file
         * Parameters   : None
         * Return       : void
         */
        public void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                FileName = ".txt",
                Filter = "txt file|*.txt|All file|*.*",
                InitialDirectory = Directory.GetCurrentDirectory()
            };

            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                InputTxt.Text = File.ReadAllText(openFileDialog.FileName);
                this.Title = openFileDialog.SafeFileName;                   // Add the title of the current file to the title
                isDataDirty = false;                                        // Check for changes in files
            }            
        }

        /*
         * Method       : DisplaySaveAlert()
         * Description  : Method for load save alert window
         * Parameters   : None
         * Return       : void
         */
        public void DisplaySaveAlert()
        {
            SaveAlert saveAlert = new SaveAlert();
            saveAlert.Owner = Application.Current.MainWindow;
            saveAlert.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            saveAlert.ShowDialog();
        }

        /*
         * Method       : NewCommand_Executed()
         * Description  : Bind new command method, Initialize the file
         * Parameters   : object sender, ExecutedRoutedEventArgs e
         * Return       : void
         */
        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Check for changes in files
            if (isDataDirty == false)
            {                
                InputTxt.Text = "";                     // Initialize the string in the file
                isDataDirty = false;
            }
            else
            {
                DisplaySaveAlert();
                if (saveChecker == true)
                {
                    InputTxt.Text = "";                 // Initialize the string in the file
                    this.Title = "HK_NOTEPAD";          // Change Title to Initial Value
                    isDataDirty = false;
                    saveChecker = false;
                }
                else if (dontSaveChecker == true)
                {
                    InputTxt.Text = "";
                    this.Title = "HK_NOTEPAD";
                    isDataDirty = false;
                    dontSaveChecker = false;
                }
            }
        }

        /*
         * Method       : NewCommand_CanExecute()
         * Description  : Binded command enabled or disabled
         * Parameters   : object sender, ExecutedRoutedEventArgs e
         * Return       : void
         */
        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        /*
        * Method       : OpenCommand_Executed()
        * Description  : Bind open command method, open the file
        * Parameters   : object sender, ExecutedRoutedEventArgs e
        * Return       : void
        */
        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Check for changes in files
            if (isDataDirty == false)
            {
                OpenFile();
                InputTxt.Select(InputTxt.Text.Length, 0);           // Cursor position text last when opening a file
            }
            else
            {
                DisplaySaveAlert();
                if (dontSaveChecker == true)
                {
                    InputTxt.Text = "";                             // Initialize existing text
                    OpenFile();
                    InputTxt.Select(InputTxt.Text.Length, 0);
                    dontSaveChecker = false;
                }
                else if(saveChecker == true)
                {
                    InputTxt.Text = "";
                    OpenFile();
                    InputTxt.Select(InputTxt.Text.Length, 0);
                    saveChecker = false;
                }
            }
        }

        /*
         * Method       : OpenCommand_CanExecute()
         * Description  : Binded command enabled or disabled
         * Parameters   : object sender, ExecutedRoutedEventArgs e
         * Return       : void
         */
        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        /*
        * Method       : SaveCommand_Executed()
        * Description  : Bind save as command method, save the file
        * Parameters   : object sender, ExecutedRoutedEventArgs e
        * Return       : void
        */
        private void SaveAsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFile();            
        }

        /*
        * Method       : SaveCommand_CanExecute()
        * Description  : Binded command enabled or disabled
        * Parameters   : object sender, ExecutedRoutedEventArgs e
        * Return       : void
        */
        private void SaveAsCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        /*
        * Method       : ExitCommand_Executed()
        * Description  : Bind close command method, save the file
        * Parameters   : object sender, ExecutedRoutedEventArgs e
        * Return       : void
        */
        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Check for changes in files
            if (isDataDirty == false)
            {
                Close();
            }
            else
            {
                DisplaySaveAlert();
                if (dontSaveChecker == true)
                {
                    Close();
                }
                else if (saveChecker == true)
                {
                    Close();
                }
            }
        }

      /*
       * Method       : ExitCommand_CanExecute()
       * Description  : Binded command enabled or disabled
       * Parameters   : object sender, ExecutedRoutedEventArgs e
       * Return       : void
       */
        private void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        /*
         * Method       : About_Click()
         * Description  : Displays the application information new window
         * Parameters   : object sender, ExecutedRoutedEventArgs e
         * Return       : void
         */
        private void About_Click(object sender, RoutedEventArgs e)
        {
            About_Window aw = new About_Window();
            aw.Owner = Application.Current.MainWindow;
            aw.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            aw.ShowDialog();
        }

        /*
         * Method       : Input_TextChanged()
         * Description  : Detects text changes in text
         * Parameters   : object sender, ExecutedRoutedEventArgs e
         * Return       : void
         */
        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isDataDirty == false)
            {
                isDataDirty = true;
                this.Title = "*" + this.Title;      // Display text changes in the title
            }
        }

        /*
         * Method       : InputTxt_SelectionoChanged()
         * Description  : Display text information in the status bar
         * Parameters   : object sender, ExecutedRoutedEventArgs e
         * Return       : void
         */
        private void InputTxt_SelectionChanged(object sender, RoutedEventArgs e)
        {
            int row = InputTxt.GetLineIndexFromCharacterIndex(InputTxt.CaretIndex);
            int col = InputTxt.CaretIndex - InputTxt.GetCharacterIndexFromLineIndex(row);
            int len = InputTxt.Text.Length;
            int lines = InputTxt.LineCount;
            int chars = len - (2 * (lines - 1));
            TxtLineStatus.Text = "Chars " + chars + ", Ln " + (row + 1) + ", Col " + (col + 1);
        }

        /*
        * Method       : Window_Closing()
        * Description  : Window closing control method
        * Parameters   : object sender, System.ComponentModel.CancelEventArgs e
        * Return       : void
        */
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Check for changes in files
            if (isDataDirty == false)
            {
                Close();
            }
            else
            {
                DisplaySaveAlert();
                if (dontSaveChecker == true)
                {
                    Close();
                }
                else if (saveChecker == true)
                {
                    Close();
                }
                else
                {
                    e.Cancel = true;            // cancel the event
                }
            }
        }
    }
}
