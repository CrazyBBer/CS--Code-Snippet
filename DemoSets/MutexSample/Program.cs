using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutexSample
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            var guidkey = getAssemblyguid();
            Console.WriteLine("Assembly guid:{0}", guidkey);
            var _mutex = new Mutex(true, guidkey);
            try
            {

                if (_mutex.WaitOne(TimeSpan.FromSeconds(0), true))
                {
                    _mutex.ReleaseMutex();
                    Console.WriteLine("start app ok");
                }
                else
                {
                    Console.WriteLine("exist a running a program");
                }

            }
            catch (AbandonedMutexException ex)
            {
                if (ex.Mutex != null)
                    ex.Mutex.ReleaseMutex();

                Console.WriteLine("release ok,and will start a running a program");
                //throw;
            }
            Console.WriteLine(" program end");
            Console.ReadKey();

        }

        static string getAssemblyguid()
        {

            var guitattr =
                (GuidAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(GuidAttribute));
            return string.Format("DemoSet-{0}", guitattr.Value);
        }
    }
}
