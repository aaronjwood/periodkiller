using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PeriodKiller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Forms.FolderBrowserDialog folderDialog = new System.Windows.Forms.FolderBrowserDialog();
        private string selectedFolder;
        private bool filenameProcessingEnabled = false;
        private bool filenameVariableRemovalEnabled = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void selectFolderButton_Click(object sender, RoutedEventArgs e)
        {
            //When a folder is selected, set the label, animate the window's width and height, and show additional controls
            if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Animate the window once a folder has been selected
                if (this.selectedFolder == null)
                {
                    animateWindowHeight(Application.Current.MainWindow, 500, .5, new Action(() =>
                    {
                        animateWindowWidth(Application.Current.MainWindow, 500, .5, new Action(() =>
                        {
                            animateControlOpacity(selectedFolderLabel, 1, 1);
                            animateControlOpacity(fixFoldersButton, 1, 1);
                        }));
                    }));
                }
                
                //Set the path selected
                this.selectedFolder = this.folderDialog.SelectedPath;
                selectedFolderLabel.Content = this.selectedFolder;

            }
        }

        private void animateWindowHeight(Window window, double height, double duration, Action callback = null)
        {
            window.BeginInit();
            window.Dispatcher.BeginInvoke((Action)(() =>
            {
                DoubleAnimation windowAnimation = new DoubleAnimation();
                windowAnimation.Duration = new Duration(TimeSpan.FromSeconds(duration));
                windowAnimation.From = window.Height;
                windowAnimation.To = height;
                windowAnimation.FillBehavior = FillBehavior.HoldEnd;

                //If a callback is passed, execute it using a lambda expression
                if (callback != null)
                {
                    windowAnimation.Completed += (s, e) => callback();
                }
                window.BeginAnimation(Window.HeightProperty, windowAnimation);
            }), null);
            window.EndInit();
        }

        private void animateWindowWidth(Window window, double width, double duration, Action callback = null)
        {
            window.BeginInit();
            window.Dispatcher.BeginInvoke((Action)(() =>
            {
                DoubleAnimation windowAnimation = new DoubleAnimation();
                windowAnimation.Duration = new Duration(TimeSpan.FromSeconds(duration));
                windowAnimation.From = window.Width;
                windowAnimation.To = width;
                windowAnimation.FillBehavior = FillBehavior.HoldEnd;

                //If a callback is passed, execute it using a lambda expression
                if (callback != null)
                {
                    windowAnimation.Completed += (s, e) => callback();
                }
                window.BeginAnimation(Window.WidthProperty, windowAnimation);
            }), null);
            window.EndInit();
        }

        private void animateControlOpacity(Control control, double opacity, double duration)
        {
            control.BeginInit();
            control.Dispatcher.BeginInvoke((Action)(() =>
            {
                DoubleAnimation selectedFolderAnimation = new DoubleAnimation(opacity, new Duration(TimeSpan.FromSeconds(duration)));
                control.BeginAnimation(Label.OpacityProperty, selectedFolderAnimation);
            }), null);
            control.EndInit();
        }
    }
}
