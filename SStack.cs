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
            _Stack = new Stack<object>();

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
             Smemory.dumpMemory();

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

        public void subtract()
        {
            _Stack.Push((int)_Stack.Pop() - (int)_Stack.Pop());


        }
        public void multiply()
        {
            _Stack.Push((int)_Stack.Pop() * (int)_Stack.Pop());

        }
        public void divide()
        {
            _Stack.Push((int)((int)_Stack.Pop() / (int)_Stack.Pop()));

        }

        public void modulus()
        {
            _Stack.Push((int)((int)_Stack.Pop() % (int)_Stack.Pop()));

        }

        /*Relational operators*/
        public int notEQ()
        {
            if( Popi()!=Popi())
            {
                return 1;
            }
            return 0;
        }
        public int lessEQ()
        {
            if( Popi()<= Popi())
            {
                return 1;
            }
            return 0;
        }

        public int less()
        {
            if( Popi()< Popi())
            {
                return 1;
            }
            return 0;
        }

        public int grEq()
        {
            if( Popi()>= Popi())
            {
                return 1;
            }
            return 0;
        }

        public int gr()
        {
            if( Popi()> Popi())
            {
                return 1;
            }
            return 0;
        }
        public int EQ()
        {
            if( Popi()== Popi())
            {
                return 1;
            }
            return 0;
        }
        public void print()
        {
            Console.WriteLine("{0}", _Stack.Peek());


        }


        private int Popi()
        {
            var rv =_Stack.Pop();
            return (int)rv;
        }

    }



}