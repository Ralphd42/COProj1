using System;
using System.Collections.Generic;


/// <summary>
/// This class will maintain memory
/// </summary>
namespace ProjectOne
{
    class Smemory
    {
        
        private Dictionary<string,int> _memory;// this is the  memory
        private int _memLength;  // this will be the length of the memory  not really used now Will be needed for future plans
        private Smemory(int length)  // private constructor
        {
            _memLength =0;
        }

        /// <summary>
        /// check if this instance is the main memory
        /// </summary>
        /// <returns>true if main, false if subroutine</returns>
        public bool isMainMem()
        {
            bool retval = false;
            if (parMem==null)
                {
                    retval =true;
                }
            return retval;
        }

        private Smemory parMem;    // instance to parent
        public  Smemory ParentMem {get{return parMem;}}  // public accesor to parent
        private int state;  // 0 = begin, 1 = called 2 = returned  
        public int State{get{return state;} set{state =value;} } // public accessor of mem state
        public Smemory addChild(Smemory par){   // this is a factory metjhod to create subroutine memory
            Smemory smem = new Smemory(1000);
            smem.parMem =par;
            smem.state =1;
            return smem;
        }

        // This is a way to access memory as a sigleton It is no linger used
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
       

/// <summary>
/// Debugging tool to show the contents of the memory
/// </summary>
        public static void dumpMemory()
        {
            if(Settings.DEBUGGING)
            { 
                Console.WriteLine("Begin Memory Dump");
                foreach(var item in MEM._memory)
                {
                    Console.WriteLine("{0} - {1}", item.Key, item.Value);
                }
                Console.WriteLine("End Memory Dump");
            }
        }


/// <summary>
/// puts value into memory
/// </summary>
/// <param name="addr"></param>
/// <returns></returns>
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
/// <summary>
/// gets value from memory
/// </summary>
/// <param name="r"></param>
/// <param name="l"></param>
/// <returns></returns>
        public bool raddValue(int r,string l)
        {
            return addValue(l,r);
        }

    }
}

/**
    Some Ideas that didn't work  
            /*
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
        private int loc =0;
*/
        
        

 