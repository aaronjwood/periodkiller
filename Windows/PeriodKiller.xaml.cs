using PeriodKiller.Class;
using PeriodKiller.Cleaners;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace PeriodKiller.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PeriodKiller : Window
    {
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private static string selectedFolder;
        private FolderCleaner folderCleaner;
        private FilenameCleaner filenameCleaner;
        private bool filenameProcessingEnabled;
        private bool removeFolderTextEnabled;
        private bool removeFilenameTextEnabled;
        private bool recursiveProcessingEnabled;

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
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            //When a folder is selected, set the label, animate the window's width and height, and show additional controls
            if (this.folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Animate the window once a folder has been selected
                if (selectedFolder == null)
                {
                    this.animateWindowHeight(Application.Current.MainWindow, 400, .5, new Action(() =>
                    {
                        this.animateWindowWidth(Application.Current.MainWindow, 500, .5, new Action(() =>
                        {
                            this.animateControlOpacity(this.selectedFolderLabel, 1, 1);
                            this.animateControlOpacity(this.fixFoldersButton, 1, 1);
                        }));
                    }));
                }

                //Set the path selected
                selectedFolder = this.folderDialog.SelectedPath;
                this.selectedFolderLabel.Content = selectedFolder;
            }
        }

        /// <summary>
        /// Event handler for button to begin processing items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fixFoldersButton_Click(object sender, RoutedEventArgs e)
        {

            //Hide this each time a fresh run is performed
            this.duplicatesLabel.Cursor = Cursors.Arrow;
            this.animateControlOpacity(this.duplicatesLabel, 0, .3);

            //Make sure the directory hasn't been deleted outside of the program
            if(!Directory.Exists(selectedFolder))
            {
                this.selectedFolderLabel.Content = "Folder no longer exists!";
                return;
            }

            this.folderCleaner = new FolderCleaner(this.recursiveProcessingEnabled);
            this.filenameCleaner = new FilenameCleaner(this.recursiveProcessingEnabled);

            //Remove a string from each directory if option is checked and the text box isn't empty
            if (this.removeFolderTextEnabled && this.removeFolderTextBox.Text != "")
            {
                folderCleaner.removeText(this.folderDialog, this.removeFolderTextBox.Text);
            }

            //Remove a string from each file if option is checked and the text box isn't empty
            if (this.removeFilenameTextEnabled && this.removeFilenameTextBox.Text != "")
            {
                filenameCleaner.removeText(this.folderDialog, this.removeFilenameTextBox.Text);
            }

            //Remove periods from directory names
            folderCleaner.removePeriods(this.folderDialog);

            //Remove periods from filenames if the option has been selected
            if (this.filenameProcessingEnabled)
            {
                filenameCleaner.removePeriods(this.folderDialog);
            }

            //If there are duplicates 
            if (folderCleaner.Duplicates.Count > 0 || filenameCleaner.Duplicates.Count > 0)
            {
                duplicatesLabel.Content = (folderCleaner.Duplicates.Count + filenameCleaner.Duplicates.Count) + " collision(s) found when restructuring folders. Click here to view them.";
                this.duplicatesLabel.Cursor = Cursors.Hand;
                this.animateControlOpacity(this.duplicatesLabel, 1, .5);
            }

            //Display message about processed folders/files
            Messages cleanerMessages = new Messages(folderCleaner.numPeriods, folderCleaner.numRenames, filenameCleaner.numPeriods, filenameCleaner.numRenames);
            if (cleanerMessages.hasMessage())
            {
                MessageBox.Show(cleanerMessages.getMessage());
            }
        }

        /// <summary>
        /// Event handler to add duplicates to the collisions window and show it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DuplicatesLabel_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            if(folderCleaner.Duplicates.Count > 0 || filenameCleaner.Duplicates.Count > 0)
            {
                Collisions collisions = new Collisions();
                collisions.Owner = this;
                foreach (string[] folder in folderCleaner.Duplicates)
                {
                    collisions.addItem(folder);
                }
                foreach (string[] file in filenameCleaner.Duplicates)
                {
                    collisions.addItem(file);
                }
                collisions.Width = this.Width;
                collisions.ShowDialog();
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
        /// Event handler for the checkable option to enable file processing in the menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_ProcessFilenames_Checked(object sender, RoutedEventArgs e)
        {
            this.filenameProcessingEnabled = true;
            this.fixFoldersButton.Content = "Clean Directory and File Names";
        }

        /// <summary>
        /// Event handler for the checkable option to disable file processing in the menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_ProcessFilenames_Unchecked(object sender, RoutedEventArgs e)
        {
            this.filenameProcessingEnabled = false;
            this.fixFoldersButton.Content = "Clean Directory Names";
        }

        /// <summary>
        /// Event handler for the checkable option to enable removing folder text in the menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_RemoveFolderText_Checked(object sender, RoutedEventArgs e)
        {
            this.removeFolderTextEnabled = true;
            this.animateControlOpacity(this.removeFolderTextLabel, 1, 1);
            this.animateControlOpacity(this.removeFolderTextBox, 1, 1);
        }

        /// <summary>
        /// Event handler for the checkable option to disable removing folder text in the menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_RemoveFolderText_Unchecked(object sender, RoutedEventArgs e)
        {
            this.removeFolderTextEnabled = false;
            this.animateControlOpacity(this.removeFolderTextLabel, 0, 1);
            this.animateControlOpacity(this.removeFolderTextBox, 0, 1);
        }

        /// <summary>
        /// Event handler for the checkable option to enable removing filename text in the menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_RemoveFilenameText_Checked(object sender, RoutedEventArgs e)
        {
            this.removeFilenameTextEnabled = true;
            this.animateControlOpacity(this.removeFilenameTextLabel, 1, 1);
            this.animateControlOpacity(this.removeFilenameTextBox, 1, 1);
        }

        /// <summary>
        /// Event handler for the checkable option to disable removing filename text in the menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_RemoveFilenameText_Unchecked(object sender, RoutedEventArgs e)
        {
            this.removeFilenameTextEnabled = false;
            this.animateControlOpacity(this.removeFilenameTextLabel, 0, 1);
            this.animateControlOpacity(this.removeFilenameTextBox, 0, 1);
        }

        /// <summary>
        /// Event handler for the checkable option to enable recursive processing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_RecursiveProcessing_Checked(object sender, RoutedEventArgs e)
        {
            this.recursiveProcessingEnabled = true;
        }

        /// <summary>
        /// Event handler for the checkable option to disable recursive processing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_RecursiveProcessing_Unchecked(object sender, RoutedEventArgs e)
        {
            this.recursiveProcessingEnabled = false;
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
