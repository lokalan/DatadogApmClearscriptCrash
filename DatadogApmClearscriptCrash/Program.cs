using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Datadog.Trace;
using Microsoft.ClearScript;
using Microsoft.ClearScript.JavaScript;
using Microsoft.ClearScript.V8;

namespace DatadogApmClearscriptCrash
{
    class Program
    {
        static void Main(string[] args)
        {
            var allAssemblies = new List<Assembly>();
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            foreach (var dll in Directory.GetFiles(path, "*.dll"))
            try
            {
                Console.WriteLine(dll);
                allAssemblies.Add(Assembly.LoadFile(dll));
            }
            catch (BadImageFormatException ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("Press any key to stop.");
            Console.ReadLine();
    }
    }
}
