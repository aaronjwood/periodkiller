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

namespace WPF
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
            //When a folder is selected, set the label, animate the window's width and height according to the length of the label, and show additional controls
            if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.selectedFolder = this.folderDialog.SelectedPath;
                selectedFolderLabel.Content = this.selectedFolder;
                selectedFolderLabel.Visibility = Visibility.Visible;

                //Measure the size of the label to be used for animating the window
                selectedFolderLabel.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
                selectedFolderLabel.Arrange(new Rect(selectedFolderLabel.DesiredSize));

                //Animate the window if the label is long
                animateWindowWidth(Application.Current.MainWindow, selectedFolderLabel.ActualWidth + 30, .5);

            }
        }

        private void animateWindowHeight(Window window, double height, double duration)
        {
            window.BeginInit();
            window.Dispatcher.BeginInvoke(new Action(() =>
            {
                DoubleAnimation windowAnimation = new DoubleAnimation();
                windowAnimation.Duration = new Duration(TimeSpan.FromSeconds(duration));
                windowAnimation.From = window.Height;
                windowAnimation.To = height;
                windowAnimation.FillBehavior = FillBehavior.HoldEnd;
                windowAnimation.Completed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    //TODO handle callback here
                });
                window.BeginAnimation(Window.HeightProperty, windowAnimation);
            }), null);
            window.EndInit();
        }

        private void animateWindowWidth(Window window, double width, double duration)
        {
            window.BeginInit();
            window.Dispatcher.BeginInvoke(new Action(() =>
            {
                DoubleAnimation windowAnimation = new DoubleAnimation();
                windowAnimation.Duration = new Duration(TimeSpan.FromSeconds(duration));
                windowAnimation.From = window.Width;
                windowAnimation.To = width;
                windowAnimation.FillBehavior = FillBehavior.HoldEnd;
                windowAnimation.Completed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    //TODO handle callback here
                });
                window.BeginAnimation(Window.WidthProperty, windowAnimation);
            }), null);
            window.EndInit();
        }
    }
}
