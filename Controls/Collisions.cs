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
        public String addItem
        {
            set { this.duplicateFolders.Items.Add(value); }
        }
    }
}
