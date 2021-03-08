using System;

namespace ProjectOne
{
    class Program
    {
        static int Main(string[] args)
        {
            if( args.Length<1)
            { 
                Console.WriteLine("Please supply a file to run");
                
                return 1;
            }
            Processor p = new Processor();
            p.Process(args[0]);
            return 0;
           // var z = ~3;
        }
    }
}
