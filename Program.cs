using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
            int numproc =Settings.MAXPROC;
            if (args.Length<numproc){ // get proper number of processes 
                numproc = args.Length;
            }
            List<Processor> procs= new List<Processor>();  // store procs for possible post processing 
            for( int i=0;i<numproc;++i )
            {
                Processor prc = new Processor(args[i]);
                procs.Add( prc);
                Thread thr = new Thread(prc.Process);
                thr.Start();
            }
            return 0;
           // var z = ~3;
        }
    }
}
