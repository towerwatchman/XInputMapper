using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XInputMapper
{
    class ContextMenus
    {
        public ContextMenuStrip menu = new ContextMenuStrip();
        private Debug_Console _cs = new Debug_Console();

        public ContextMenuStrip Create()
        {
            // Add the default menu options.
            
            ToolStripMenuItem item;

            // Separator
            ToolStripSeparator sep = new ToolStripSeparator();
            
            //Show Controllers connected
           /* item = new ToolStripMenuItem();
            item.Text = "Controller";
            //item.Click += new System.EventHandler(Exit_Click);
            //item.Image = Resources.Exit;
            menu.Items.Add(item);
            (menu.Items[0] as ToolStripMenuItem).DropDownItems.Add("1: Unplugged");
            (menu.Items[0] as ToolStripMenuItem).DropDownItems.Add("2: Unplugged");
            (menu.Items[0] as ToolStripMenuItem).DropDownItems.Add("3: Unplugged");
            (menu.Items[0] as ToolStripMenuItem).DropDownItems.Add("4: Unplugged");*/

            //menu.Items.Add(sep);

            //Input Watcher
            //item = new ToolStripMenuItem();
            //item.Text = "Debug Console";
            //item.Click += new System.EventHandler(Debug_Click);
            //item.Image = Resources.Exit;
            //menu.Items.Add(item);

            //Input Watcher
            //item = new ToolStripMenuItem();
            //item.Text = "Input Watcher";
            //item.Click += new System.EventHandler(Exit_Click);
            //item.Image = Resources.Exit;
            //menu.Items.Add(item);

           // menu.Items.Add(sep);

            // Exit
            item = new ToolStripMenuItem();
            item.Text = "Exit";
            item.Click += new System.EventHandler(Exit_Click);
            //item.Image = Resources.Exit;
            menu.Items.Add(item);

            return menu;
        }

       
        void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void Debug_Click(object sender, EventArgs e)
        {            
            _cs.Show();
        }

        public void updateText(string name, int id)
        {
            this.menu.Items[id].Text = name;
        }

    }
}