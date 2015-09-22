using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoticeMessageLoop
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var mutex = new Mutex(true, getAssemblyguid());
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());

            }
            else
            {
                //Console.WriteLine("alreadyrunning");
                //Console.ReadKey();

                Win32Api.PostMessage(
                    (IntPtr)Win32Api.HwndBroadcast,
                    Win32Api.WmShowme, IntPtr.Zero, IntPtr.Zero);
            }

        }


        static string getAssemblyguid()
        {

            var guitattr =
                (GuidAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(GuidAttribute));
            return string.Format("DemoSet-{0}", guitattr.Value);
        }
    }
}
