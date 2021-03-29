using System;
using System.Collections.Generic;


/// <summary>
/// This will be the main memory and MEMORY BUS
/// They will work together using this class
/// These will be accessible by a thread safe singleton
/// </summary>
namespace ProjectOne
{
    public class MainMemory
    {
        private int?[,] _memory;  // this is the main memory
        private int _currAddres;  // this is the address to write new memory to
        private static MainMemory _mem = null;   // private instance to main memory 
        private static readonly object padlock = new object(); // lock object

        private Dictionary<string, int> LvaltoAddress;

        /// <summary>
        /// Private constructor set Memory here
        /// </summary>
        private MainMemory()
        {
            _memory = new int?[Settings.MEMSIZE, Settings.MEMSIZE];
            _currAddres =0;
            LvaltoAddress = new Dictionary<string, int>();
        }
        public static MainMemory mMem
        {
            get
            {
                if (_mem == null)
                {
                    _mem = new MainMemory();
                }
                return _mem;

            }

        }

        
        /// <summary>
        /// THis handles adding arras and single values int the data section
        /// this will handle .int d1, …, dn
        /// will work for updates also
        /// </summary>
        /// <param name="lvalue">the lvalue</param>
        /// <param name="items">the Items</param>
        public void addItem( string lvalue, string items/* can be comm separated list */)
        {

            // this must be a critical section one add at a time
            lock(padlock)
            {
                string [] itms = items.Split(",");
                int i =0;
                foreach (string s in itms)
                {
                    _memory[_currAddres,i] = Convert.ToInt32(s);
                }
                if( !LvaltoAddress.ContainsKey(lvalue))
                {
                    LvaltoAddress[lvalue]=_currAddres;  
                    ++_currAddres;
                }
            }
        }
        /// <summary>
        /// lto will point to same value as lfrom
        ///
        /// 
        /// <param name="lto">an lvalue to change address</param>
        /// <param name="lfrom">the address to copy from</param>
        public void copy(string lto, string lfrom  )
        {
            int fromaddy = LvaltoAddress[lfrom];
            LvaltoAddress[lto] =fromaddy;
        }




    }
}