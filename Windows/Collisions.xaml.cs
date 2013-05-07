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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PeriodKiller.Windows
{
    /// <summary>
    /// Interaction logic for Collisions.xaml
    /// </summary>
    public partial class Collisions : Window
    {
        public Collisions()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Add a duplicate item to the list
        /// </summary>
        /// <param name="item">The array of items that should be added to the list</param>
        public void addItem(string[] item)
        {
            this.duplicateItems.Items.Add(new { Type = item[0], Original = item[1], Renamed = item[2], Collides = item[3] });
        }
    }
}
