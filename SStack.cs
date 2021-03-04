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
        public SStack(Smemory mem=null, string StackID="")
        {
            if( mem==null)
            {
                _Mem = Smemory.MEM;
            }else
            { 
            _Mem =mem;
            }
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

        public void pop()
        {
            _Stack.Pop();    


        }
        //rvalue l Pushes contents of data location l onto the stack

        public void rvalue (string l)
        {
            _Stack.Push( _Mem.getValue(l));
        }

        /*lvalue l
Pushes address of data location l onto the stack
*/
        public void lvalue (string l)
        {
            _Stack.Push( l);
        }

        /*
            :=Stack top is placed by the lvalue below it and both are popped
copy
Pushes a copy of the top value on stack

        
        
        
        */
        public void SetMemFromStack()
        {
            // pop the value
            //_Mem.addValue( "tmp" ,(int)_Stack.Pop());    
            //_Mem.addValue((string)_Stack.Pop(),(int)_Mem.getValue("tmp"));
            _Mem.raddValue((int) _Stack.Pop(), (string)_Stack.Pop());


        }

        public void gofalse( string label)
        {
            ProgFileMan.PFM.Go(label, (int)_Stack.Pop(),true);
        }
        public void goTrue( string label)
        {
            ProgFileMan.PFM.Go(label, (int)_Stack.Pop(),true);
        }

        public void add()
        {
            _Stack.Push((int)_Stack.Pop() + (int)_Stack.Pop());


        }

    }



}