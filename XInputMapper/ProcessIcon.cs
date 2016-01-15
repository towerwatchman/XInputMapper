using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XInputMapper
{
    class ProcessIcon : IDisposable
    {
        NotifyIcon ni;
        ContextMenus cm = new ContextMenus();

        public ProcessIcon()
        {
            ni = new NotifyIcon();
        }

        public void Display()
        {
            ni.MouseClick += new MouseEventHandler(ni_MouseClick);
            ni.Icon = new Icon("Appicon.ico");
            ni.Text = "Xinput Mapper";
            ni.Visible = true;

            ni.ContextMenuStrip = new ContextMenus().Create();
        }

        public void Dispose()
        {
            ni.Dispose();
        }

        public void ni_MouseClick(object sender, MouseEventArgs e)
        { 
            ni.ContextMenuStrip.Update();
        }
    }
}
