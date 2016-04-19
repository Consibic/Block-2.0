using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blocks_2._0
{
    public partial class BlockForm : Form
    {
        public BlockForm()
        {
            InitializeComponent();
            this.Controls.Add(new BlockControl());
        }
    }
}
