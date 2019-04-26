using System;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Runtime.InteropServices;
using WindowsInput.Native;
using WindowsInput;

namespace osu_discordmute
{
    class Program
    {
        static public bool isGameActive;
        static public int hasGamePlayed = 0;

        //public bool isGameActive = false;
        static String title = null;

        static void Main(string[] args)
        {
            while (true)
            {
                Thread.Sleep(1000);
                Process[] ps = Process.GetProcessesByName("osu!");
                if (ps.Length > 0)
                {
                    Process osu = ps[0];
                    title = osu.MainWindowTitle;
                }

                if (title.IndexOf('-') > 0)
                {
                    isGameActive = true;
                    Console.WriteLine(isGameActive);

                }
                else
                {
                    Console.WriteLine(isGameActive);
                    isGameActive = false;
                }
                Console.WriteLine(isGameActive);
                if (isGameActive == true && hasGamePlayed == 0)
                {
                    InputSimulator sim = new InputSimulator();
                    // Press 0 key
                    sim.Keyboard.KeyPress(VirtualKeyCode.VK_0);
                    hasGamePlayed = 1;
                }
                if (isGameActive == false && hasGamePlayed == 1)
                {
                    InputSimulator sim = new InputSimulator();
                    sim.Keyboard.KeyPress(VirtualKeyCode.VK_0);
                    hasGamePlayed = 0;
                }
                // -> Close if(isGameActive)
            } // -> Close while(true)
        } // -> Close Main()


    }

}