using System;
using System.Windows.Forms;

namespace PeriodKiller
{
    public partial class Collisions : Form
    {
        public Collisions()
        {
            InitializeComponent();
        }
        public void addItem(string[] item)
        {
            ListViewItem duplicate = new ListViewItem(item);
            this.duplicateFolders.Items.Add(duplicate);
        }
    }
}
