using System;
using System.Collections.Generic;


/// <summary>
/// This class will maintain memory
/// </summary>
namespace ProjectOne
{
    class Smemory
    {
        private Dictionary<string,int> _memory;
        private int _memLength;
        private Smemory(int length)
        {
            _memLength =0;


        }
        public static Smemory MEM
        {
            get
            {
                if(_mem==null)
                {
                    _mem = new Smemory(1000);

                }
                return _mem;
            }
        }
        private static Smemory _mem;
        public static void dumpMemory()
        {
            if(parser.DEBUGGING)
            { 
                Console.WriteLine("Begin Memory Dump");
                foreach(var item in MEM._memory)
                {
                    Console.WriteLine("{0} - {1}", item.Key, item.Value);
                }
                Console.WriteLine("End Memory Dump");
            }
        }



        public int? getValue( string addr)
        {
            int ? rv =null;
            if(_memory!=null)
            {
                if(_memory.ContainsKey(addr))
                {
                    return _memory[addr];

                }
            }
            return rv;
        }
        public bool addValue(string l, int r)
        {
            bool retval = true;
            if( _memory ==null)
            {
                _memory = new Dictionary<string, int>();
            }
            _memory[l] =r;
            return retval;
        }
        public bool raddValue(int r,string l)
        {
            return addValue(l,r);
        }

    }
}