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
        private ProgFileMan PFM;  // a reference to the programManager
        public Smemory curMem   // a public accessors to the memory used by stack
        {
            get
            {
                return _Mem;
            }
            set
            {
                _Mem = value;
            }
        }
        /// <summary>
        /// This is the stack  
        /// </summary>
        public SStack(ProgFileMan pf, Smemory mem = null, string StackID = "")
        {
            if (mem == null)
            {
                _Mem = Smemory.MEM;
            }
            else
            {
                _Mem = mem;
            }
            _Stack = new Stack<object>();
            PFM = pf;

        }
        private Stack<object> _Stack;  // the instance of a stack
        private Smemory _Mem;
        /// <summary>
        /// Pushes c onto the stack
        /// </summary>
        /// <param name="c"></param>
        public void push(object c)
        {
            _Stack.Push(c);
        }

        /// <summary>
        ///  pops item off stack does not use item 
        /// </summary>
        public void pop()
        {
            _Stack.Pop();


        }
        //rvalue l Pushes contents of data location l onto the stack

        public void rvalue(string l, bool isLocal = false)
        {
            /*   Smemory mem;
               if( isLocal){
                   mem = Smemory.LMEM;
               }
               else
               { 
                   mem = Smemory.MEM;
               }*/
            if (_Mem.State == 1)
            {  // state 1 is begin
                _Stack.Push(_Mem.ParentMem.getValue(l));
            }
            else
            {
                _Stack.Push(_Mem.getValue(l));
            }


        }

        /// <summary>
        /// Pushes L Value onto Stack
        /// </summary>
        /// <param name="l"></param>
        public void lvalue(string l)
        {
            _Stack.Push(l);
        }


        /// <summary>
        /// sets memory from stack
        /// </summary>
        /// <param name="local"></param>
        public void SetMemFromStack(bool local = false)
        {
            if (_Mem.State == 3)
            {
                _Mem.ParentMem.raddValue((int)_Stack.Pop(), (string)_Stack.Pop());
            }
            else
            {
                _Mem.raddValue((int)_Stack.Pop(), (string)_Stack.Pop());
            }

            Smemory.dumpMemory();
        }







        /// <summary>
        /// This function will copy the Lvalues 
        /// </summary>
        /// <param name="local"></param>
        public void CopyLValue(bool local = false)
        {
            if (_Mem.State == 3)
            {
                _Mem.ParentMem.raddValue((int)_Stack.Pop(), (string)_Stack.Pop());
            }
            else
            {
                _Mem.raddValue((int)_Stack.Pop(), (string)_Stack.Pop());
            }

            Smemory.dumpMemory();
        }



        /// <summary>
        /// goes to label if top od stack is false
        /// </summary>
        /// <param name="label"></param>
        public void gofalse(string label)
        {
            PFM.Go(label, (int)_Stack.Pop(), true);
        }
        /// <summary>
        /// goes to label if top of stack is true
        /// </summary>
        /// <param name="label"></param>
        public void goTrue(string label)
        {
            PFM.Go(label, (int)_Stack.Pop(), true);
        }

        public void add()
        {
            _Stack.Push((int)_Stack.Pop() + (int)_Stack.Pop());


        }

        public void subtract()
        {
            _Stack.Push(-(int)_Stack.Pop() + (int)_Stack.Pop());


        }
        public void multiply()
        {
            _Stack.Push((int)_Stack.Pop() * (int)_Stack.Pop());

        }
        public void divide()
        {
            int one = (int)_Stack.Pop();
            int two = (int)_Stack.Pop();
            _Stack.Push((int)(two / one));
        }

        public void modulus()
        {
            int one = (int)_Stack.Pop();
            int two = (int)_Stack.Pop();
            _Stack.Push((int)(two % one));

        }
        public void OpAnd()
        {
            int one = (int)_Stack.Pop();
            int two = (int)_Stack.Pop();
            if (one != 0 && two != 0)
            {
                _Stack.Push(1);
                return;
            }
            _Stack.Push(0);
        }

        public void OpOr()
        {
            int one = (int)_Stack.Pop();
            int two = (int)_Stack.Pop();
            if (one != 0 || two != 0)
            {
                _Stack.Push(1);
                return;
            }
            _Stack.Push(0);
        }
        public void OpNot()
        {
            int one = (int)_Stack.Pop();
            if (one != 0)
            {
                _Stack.Push(0);
                return;
            }
            _Stack.Push(1);
        }


        /*Relational operators*/
        public void notEQ()
        {
            if (Popi() != Popi())
            {
                _Stack.Push(1);

            }
            else
            {
                _Stack.Push(0);
            }
        }
        public void lessEQ()
        {
            if (Popi() > Popi())
            {
                _Stack.Push(1);
            }
            else
            {
                _Stack.Push(0);
            }
        }

        public void grEQ()
        {
            {
                if (Popi() < Popi())
                {
                    _Stack.Push(1);
                }
                else
                {
                    _Stack.Push(0);
                }
            }


        }


        public void less()
        {
            if (Popi() > Popi())
            {
                _Stack.Push(1);
            }
            else
            {
                _Stack.Push(0);
            }
        }

        public int grEq()
        {
            int retval = 0;
            if (Popi() >= Popi())
            {
                retval = 1;
            }
            _Stack.Push(retval);
            return retval;
        }

        public int gr()
        {
            int retval = 0;
            if (!(Popi() >= Popi()))
            {
                retval = 1;
            }
            _Stack.Push(retval);
            return retval;
        }
        public void notEq()
        {
            if (Popi() != Popi())
            {
                _Stack.Push(1);
            }
            _Stack.Push(0);
        }
        public void EQ()
        {
            if (Popi() == Popi())
            {
                _Stack.Push(1);
            }
            _Stack.Push(0);
        }
        public void print(bool isSubProg = false)
        {
            Console.WriteLine("{0}", _Stack.Peek());


        }

        /// <summary>
        /// pops value from stack and returns it as interger
        /// </summary>
        /// <returns></returns>
        private int Popi()
        {
            var rv = _Stack.Pop();
            return (int)rv;
        }

        /**Project two additions */



        /// <summary>
        /// pops top two items off of stack and copys using pointers
        /// the result will have both lvalues pointing to the same memory location
        /// </summary>
        public void copyMainMem()
        {
            MainMemory.mMem.copy( _Stack.Pop().ToString() ,_Stack.Pop().ToString());
        }





    }



}