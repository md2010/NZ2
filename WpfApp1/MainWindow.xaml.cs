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
using System;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void btnNotepad_Click(object sender, RoutedEventArgs e)
        {        
            btnNotepad.IsEnabled = false;
            startProgram("notepad");       
        }
        
        private void btnPaint_Click(object sender, RoutedEventArgs e)
        {          
            btnPaint.IsEnabled = false;
            startProgram("mspaint");
        }

        private void btnCMD_Click_1(object sender, RoutedEventArgs e)
        {
            btnCMD.IsEnabled = false;
            startProgram("cmd");
        }


        private void startProgram(string programName)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(programName);
            startInfo.UseShellExecute = false;

            Process process = Process.Start(startInfo);
            process.EnableRaisingEvents = true;
           
            switch(process.StartInfo.FileName)
            {
                case "notepad":
                    lbNotepad.Content = "Running";
                    process.Exited += new EventHandler((sender, e) => processNotepad_Exited(sender, e, process));
                    break;
                case "mspaint":
                    lbPaint.Content = "Running";
                    process.Exited += new EventHandler((sender, e) => processPaint_Exited(sender, e, process));
                    break;
                case "cmd":
                    lbCMD.Content = "Running";                                 
                    process.Exited += new EventHandler((sender, e) => processCMD_Exited(sender, e, process));
                    break;                  
                default:                  
                    break;
            }          
        }

        private void processNotepad_Exited(object sender, System.EventArgs e, Process p)
        {
            p.WaitForExit();
            this.Dispatcher.Invoke(() =>
            {
                lbNotepad.Content = "Closed";
                btnNotepad.IsEnabled = true;
            });

        }

        private void processPaint_Exited(object sender, System.EventArgs e, Process p)
        {
            p.WaitForExit();
            this.Dispatcher.Invoke(() =>
            {
                lbPaint.Content = "Closed";
                btnPaint.IsEnabled = true;
            });

        }

        private void processCMD_Exited(object sender, System.EventArgs e, Process p)
        {
            p.WaitForExit();
            this.Dispatcher.Invoke(() =>
            {               
                lbCMD.Content = "Closed";
                btnCMD.IsEnabled = true;
            });

        }

        
    }
}
