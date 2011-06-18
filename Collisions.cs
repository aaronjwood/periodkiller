using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
