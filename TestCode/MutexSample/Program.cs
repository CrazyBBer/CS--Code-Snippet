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

            var guitattr =
                (GuidAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(GuidAttribute));
            var guidkey = string.Format("DemoSet-{0}", guitattr.Value);

            Console.WriteLine("Assembly guid:{0}", guidkey);
            var _mutex = new Mutex(true, guidkey);


            try
            {
                _mutex.WaitOne(TimeSpan.FromSeconds(1), true);

            }
            catch (AbandonedMutexException ex)
            {
                if (ex.Mutex != null)
                    ex.Mutex.ReleaseMutex();

                Console.WriteLine("exist a running a program");
                //throw;
            }
            Console.WriteLine(" program end");
            Console.ReadKey();
            _mutex.ReleaseMutex();
        }
    }
}
