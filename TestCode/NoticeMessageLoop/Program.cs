using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NoticeMessageLoop
{
    class Program
    {
        static void Main(string[] args)
        {

        }


        static string getAssemblyguid()
        {

            var guitattr =
                (GuidAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(GuidAttribute));
            return string.Format("DemoSet-{0}", guitattr.Value);
        }
    }
}
