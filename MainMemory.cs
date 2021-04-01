using System;
using System.Collections.Generic;



namespace ProjectOne
{
/// <summary>
/// This will be the main memory and MEMORY BUS
/// They will work together using this class
/// These will be accessible by a thread safe singleton
/// This memory is the shared memory between all cores
/// </summary>
    public class MainMemory
    {
        private int?[,] _memory;  // this is the main memory  2 deimensional array
        private int _currAddres;  // this is the address to write new memory to  
        private static MainMemory _mem = null;   // private instance to main memory 
        private static readonly object padlock = new object(); // lock object

        private Dictionary<string, memAddress> LvaltoAddress;

        /// <summary>
        /// Private constructor set Memory here
        /// </summary>
        private MainMemory()
        {
            _memory = new int?[Settings.MEMSIZE, Settings.MEMSIZE];
            _currAddres =0;
            LvaltoAddress = new Dictionary<string, memAddress>();
        }
        /// <summary>
        /// Static interface to get main memory
        /// </summary>
        /// <value></value>
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
                    LvaltoAddress[lvalue]=new memAddress(_currAddres,0);  
                    ++_currAddres;
                }
            }
        }
        /// <summary>
        /// lto will point to same value as lfrom
        ///
        /// </summary>
        /// <param name="lto">an lvalue to change address</param>
        /// <param name="lfrom">the address to copy from</param>
        public void copy(string lto, string lfrom  )
        {
            memAddress fromaddy = LvaltoAddress[lfrom];
            LvaltoAddress[lto] =fromaddy;
        }

        /// <summary>
        /// Tests if lvalue is a main memory item
        /// </summary>
        /// <param name="lvalue">the lvaue to check</param>
        /// <returns></returns>
        bool inMainMem(string lvalue)
        {
            bool retval = false;
            if(LvaltoAddress.ContainsKey(lvalue))
            {
                retval =true;
            }
            return retval;
        }

        /// <summary>
        /// Gets the memaddress of an lvalue
        /// </summary>
        /// <param name="lvalue"></param>
        /// <returns></returns>
        public memAddress LValAddr(string lvalue)
        {
            return LvaltoAddress[lvalue];
        }


        /// <summary>
        /// class for storing a complete memory address
        /// /// </summary>
        public class memAddress  
        {
            /// <summary>
            /// constructor for memory address
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            public memAddress(int x,int y)
            {
                X=x;
                Y=y;
            }
            
            /// <summary>
            /// X
            /// </summary>
            /// <value></value>
            public int X{get;set;}
            
            /// <summary>
            /// Y
            /// </summary>
            /// <value></value>
            public int Y{get;set;}

        }


    }
}