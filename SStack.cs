using System;
using System.Collections.Generic;
namespace ProjectOne
{
    

    /// <summary>
    /// this is the stack object.
    /// Handles the stack functions
    /// Maintains a stack
    /// </summary>
     class SStack
    {
        /// <summary>
        /// This is the stack  
        /// </summary>
        public SStack(Smemory mem)
        {
            _Mem =mem;
        }
        private Stack<object> _Stack  ;
        private Smemory _Mem;
        /// <summary>
        /// Pushes c onto the stack
        /// </summary>
        /// <param name="o"></param>
        public void push (object c)
        {
            _Stack.Push(c);
        }

    }



}