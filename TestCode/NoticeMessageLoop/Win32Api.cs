using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace NoticeMessageLoop
{
    class Win32Api
    {
        public const int HWND_BROADCAST = 0xffff;
        public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");

        [DllImport("user32.dll")]
        public static extern bool PostMessage(IntPtr hwnd,int msg,IntPtr wparam,IntPtr lparam);

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImport("user32.dll")]
        public static extern int RegisterWindowMessage(string message);


    }
}
