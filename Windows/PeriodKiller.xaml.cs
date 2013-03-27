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
using PeriodKiller.Windows;

namespace PeriodKiller.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PeriodKiller : Window
    {
        private System.Windows.Forms.FolderBrowserDialog folderDialog = new System.Windows.Forms.FolderBrowserDialog();
        private static string selectedFolder;

        public PeriodKiller()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the button to select a folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectFolderButton_Click(object sender, RoutedEventArgs e)
        {
            //When a folder is selected, set the label, animate the window's width and height, and show additional controls
            if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Animate the window once a folder has been selected
                if (selectedFolder == null)
                {
                    animateWindowHeight(Application.Current.MainWindow, 400, .5, new Action(() =>
                    {
                        animateWindowWidth(Application.Current.MainWindow, 500, .5, new Action(() =>
                        {
                            animateControlOpacity(selectedFolderLabel, 1, 1);
                            animateControlOpacity(fixFoldersButton, 1, 1);
                        }));
                    }));
                }

                //Set the path selected
                selectedFolder = this.folderDialog.SelectedPath;
                selectedFolderLabel.Content = selectedFolder;

            }
        }

        /// <summary>
        /// Animates the window's height
        /// </summary>
        /// <param name="window">The window to animate</param>
        /// <param name="height">The height to animate the window to</param>
        /// <param name="duration">The duration for the animation</param>
        /// <param name="callback">An optional callback to be executed when the animation finishes</param>
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

        /// <summary>
        /// Animates the window's width
        /// </summary>
        /// <param name="window">The window to animate</param>
        /// <param name="width">The width to animate the window to</param>
        /// <param name="duration">The duration for the animation</param>
        /// <param name="callback">An optional callback to be executed when the animation finishes</param>
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

                //If a callback is passed, execute it using a lambda
                if (callback != null)
                {
                    windowAnimation.Completed += (s, e) => callback();
                }
                window.BeginAnimation(Window.WidthProperty, windowAnimation);
            }), null);
            window.EndInit();
        }

        /// <summary>
        /// Animates a control and allows control of the duration and opacity
        /// </summary>
        /// <param name="control">The control to be animated</param>
        /// <param name="opacity">The opacity value for the animation</param>
        /// <param name="duration">The duration for the animation</param>
        private void animateControlOpacity(Control control, double opacity, double duration)
        {
            control.BeginInit();
            control.Dispatcher.BeginInvoke((Action)(() =>
            {
                DoubleAnimation controlAnimation = new DoubleAnimation(opacity, new Duration(TimeSpan.FromSeconds(duration)));
                control.BeginAnimation(Label.OpacityProperty, controlAnimation);
            }), null);
            control.EndInit();
        }

        /// <summary>
        /// Event handler for the About menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_About_Click(object sender, EventArgs e)
        {
            About aboutWindow = new About();
            aboutWindow.Owner = this;
            aboutWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            aboutWindow.ShowDialog();
        }
    }
}
