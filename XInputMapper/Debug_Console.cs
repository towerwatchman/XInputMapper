using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XInputMapper
{
    public partial class Debug_Console : Form
    {
        static Debug_Console instance;

        public static Debug_Console Instance { get { return instance; } }

        public Debug_Console()
        {
            InitializeComponent();
        }

        
    }
}
