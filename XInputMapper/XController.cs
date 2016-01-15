using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SharpDX.XInput;
using System.Diagnostics;
using SharpDX.DirectInput;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Threading.Tasks;

namespace XInputMapper
{
    class XController
    {
        #region DllImport
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        // Get a handle to an application window.
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName,
            string lpWindowName);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
        #endregion

        public static Controller[] _controller = new Controller[4];

        public static int time = 0;//this is 2 sec interval so you cant send two commands at the same time. 

        private static System.Threading.Timer t;

        public void Initialize()
        {

            _controller[0] = new Controller(UserIndex.One); // Get Controller at index 0
            _controller[1] = new Controller(UserIndex.Two); // Get Controller at index 1
            _controller[2] = new Controller(UserIndex.Three); // Get Controller at index 2
            _controller[3] = new Controller(UserIndex.Four); // Get Controller at index 3

            t = new System.Threading.Timer(TimerCallback, null, 0, 100); // Timer set for 100ms
        }

        private static void TimerCallback(Object o)
        {

            try
            {
                if(time > 1)
                {
                    time -= 1;
                }
                DisplayControllerInformation();
            }
            catch(Exception ex)
            {
            }

        }

        private static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        private static void DisplayControllerInformation()
        {
            //Console.Clear();
            foreach (var controller in _controller)
            {
                if (controller.IsConnected)
                {
                    var state = controller.GetState();

                    //Console.Out.WriteLine("Player: (" + controller.UserIndex.ToString() + ") -- " + state.Gamepad.Buttons.ToString());

                    if (time <= 1)
                    {
                        if (state.Gamepad.Buttons.ToString() == "Back, RightShoulder") //Exit Emulator
                        {
                            CloseProgram();
                            time = 11; //reset timer to 1 seconds
                        }
                        if (state.Gamepad.Buttons.ToString() == "Back, LeftShoulder") //Enable Software/Hardware Mode Pcsx2
                        {
                            CloseProgram();
                            time = 11; //reset timer to 1 seconds
                        }
                        else if (state.Gamepad.Buttons.ToString() == "Back, A") //Save State 0
                        {
                            SendKeys.SendWait("{F1}");
                            time = 11; //reset timer to 1 seconds
                        }
                        else if (state.Gamepad.Buttons.ToString() == "Back, B") //Load State 0
                        {
                            SendKeys.SendWait("{F3}");
                            time = 11; //reset timer to 1 seconds
                        }
                        else if (state.Gamepad.Buttons.ToString() == "Back, X") //Save State 0
                        {
                            SendKeys.SendWait("{F5}");
                            time = 11; //reset timer to 1 seconds
                        }
                        else if (state.Gamepad.Buttons.ToString() == "Back, Y") //Load State 0
                        {
                            SendKeys.SendWait("{F7}");
                            time = 11; //reset timer to 1 seconds
                        }

                        
                    }                  
                }
                else
                {
                    //Console.Out.WriteLine("Player: (" + controller.UserIndex.ToString() + ") -- Not Connected");
                }
            }

        }

        private static void CloseProgram()
        {

            if (Process.GetProcessesByName("nestopia").Length > 0)// Nes
            {
                //Console.Out.WriteLine("  --[Attempting to Exit NES Emulator] ");
                SendKeys.SendWait("%{F4}");
            }
            else if (Process.GetProcessesByName("snes9x").Length > 0)// Snes
            {
                //Console.Out.WriteLine("  --[Attempting to Exit SNES Emulator] ");
                SendKeys.SendWait("%{F4}");
            }
            else if (Process.GetProcessesByName("nullDC").Length > 0)// Dreamcast
            {
                //Console.Out.WriteLine("  --[Attempting to Exit Dreamcast Emulator] ");
                SendKeys.SendWait("%{F4}");
            }
            else if (Process.GetProcessesByName("Dolphin").Length > 0) // Gamecube, Wii
            {
                // Console.Out.WriteLine("  --[Attempting to Exit Dolphin Emulator] ");
                //SendKeys.SendWait("{ESCAPE}");

                //Im not super sure why 
                IntPtr calculatorHandle = FindWindow("wxWindowNR", GetActiveWindowTitle());

                // Verify that Calculator is a running process.
                if (calculatorHandle == IntPtr.Zero)
                {
                   // Console.Out.WriteLine("Cant find dolphin window");

                }
                else
                {
                    //Console.Out.WriteLine("Finally Found the Window");
                }
                SetForegroundWindow(calculatorHandle);
                SendKeys.SendWait("%{F4}");

                //SetForegroundWindow(Process.GetProcessesByName("Dolphin")[0].MainWindowHandle);
                //SendKeys.SendWait("{Esc}"); 
            }
            else if (Process.GetProcessesByName("Fusion").Length > 0) //Genesis, CD, 32X
            {
                //Console.Out.WriteLine("  --[Attempting to Exit Fusion Emulator] ");
                SendKeys.SendWait("{Esc}");
            }
            else if (Process.GetProcessesByName("pcsx2").Length > 0)//PS2
            {
                //Console.Out.WriteLine("  --[Attempting to Exit pcsx2 Emulator] ");
                SendKeys.SendWait("{Esc}");
            }
            else if (Process.GetProcessesByName("ePSXe").Length > 0)//PSX
            {
                //Console.Out.WriteLine("  --[Attempting to Exit ePSXe Emulator] ");

                SendKeys.SendWait("{Esc}");
                SendKeys.SendWait("{Esc}");
            }
            else if (Process.GetProcessesByName("PPSSPPWindows64").Length > 0)//PSP
            {
                //Console.Out.WriteLine("  --[Attempting to Exit psp Emulator] ");
                SendKeys.SendWait("{Esc}");
            }
            else if (Process.GetProcessesByName("Project64").Length > 0)//N64
            {
                //Console.Out.WriteLine("  --[Attempting to Exit N64 Emulator] ");
                SendKeys.SendWait("%{F4}");
                //SendKeys.SendWait("{Esc}");
            }
            else if (Process.GetProcessesByName("VisualBoyAdvance").Length > 0)//GBA
            {
                //Console.Out.WriteLine("  --[Attempting to Exit GBA Emulator] ");
                SendKeys.SendWait("%{F4}");
                // SendKeys.SendWait("{Esc}");
            }
            else if (Process.GetProcessesByName("SSF_Launcher").Length > 0)//Saturn
            {
                //Console.Out.WriteLine("  --[Attempting to Exit Saturn Emulator] ");
                SendKeys.SendWait("{Esc}");

                Task.Delay(500).ContinueWith(_ =>
                    {
                        SendKeys.SendWait("{Enter}");
                    });
            }
            else
            {
                //do nothing
            }

        }

    }
}
