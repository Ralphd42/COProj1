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

        public bool isMainMem()
        {
            bool retval = false;
            if (parMem==null)
                {
                    retval =true;
                }
            return retval;
        }

        private Smemory parMem;
        public  Smemory ParentMem {get{return parMem;}}
        private int state;  // 0 = begin, 1 = called 2 returned 
        public int State{get{return state;} set{state =value;} }
        public Smemory addChild(Smemory par){
            Smemory smem = new Smemory(1000);
            smem.parMem =par;
            smem.state =1;
            return smem;
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
        private static Smemory _lmem;
        public static Smemory LMEM
        {
            get
            {
                if(_lmem==null)
                {
                    _lmem = new Smemory(1000);

                }
                return _lmem;
            }
        }

        //
        private int loc =0;


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
            int ? rv =0;
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