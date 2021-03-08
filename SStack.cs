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
        private ProgFileMan PFM;
        public Smemory curMem 
        {
            get{ 
                return _Mem;  
            }
            set{ 
                _Mem =value;   
            }
        }
        /// <summary>
        /// This is the stack  
        /// </summary>
        public SStack( ProgFileMan pf,Smemory mem=null, string StackID="")
        {
            if( mem==null)
            {
                _Mem = Smemory.MEM;
            }else
            { 
                _Mem =mem;
            }
            _Stack = new Stack<object>();
            PFM = pf;

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

        public void rvalue (string l, bool isLocal=false)
        {
         /*   Smemory mem;
            if( isLocal){
                mem = Smemory.LMEM;
            }
            else
            { 
                mem = Smemory.MEM;
            }*/
            if (_Mem.State ==1){  // state 1 is begin
                _Stack.Push( _Mem.ParentMem.getValue(l));
            }else{
                _Stack.Push( _Mem.getValue(l));
            }

            
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
        public void SetMemFromStack(bool local =false)
        {
            // pop the value
            //_Mem.addValue( "tmp" ,(int)_Stack.Pop());    
            //_Mem.addValue((string)_Stack.Pop(),(int)_Mem.getValue("tmp"));
          /*  if(local)
            { 
                Smemory.LMEM.raddValue((int) _Stack.Pop(), (string)_Stack.Pop());
            }else
            {
                Smemory.MEM.raddValue((int) _Stack.Pop(), (string)_Stack.Pop());
            }*/
            if(_Mem.State==3){ 
                _Mem.ParentMem.raddValue((int) _Stack.Pop(), (string)_Stack.Pop());
            }else
            {
                _Mem.raddValue((int) _Stack.Pop(), (string)_Stack.Pop());
            }

            Smemory.dumpMemory();
        }

        public void gofalse( string label)
        {
            PFM.Go(label, (int)_Stack.Pop(),true);
        }
        public void goTrue( string label)
        {
            PFM.Go(label, (int)_Stack.Pop(),true);
        }

        public void add()
        {
            _Stack.Push((int)_Stack.Pop() + (int)_Stack.Pop());


        }

        public void subtract()
        {
            _Stack.Push( -(int)_Stack.Pop() + (int)_Stack.Pop()   );


        }
        public void multiply()
        {
            _Stack.Push((int)_Stack.Pop() * (int)_Stack.Pop());

        }
        public void divide()
        {
            int one =(int)_Stack.Pop();
            int two =(int)_Stack.Pop();
            _Stack.Push((int)( two / one ) );
        }

        public void modulus()
        {
            int one =(int)_Stack.Pop();
            int two =(int)_Stack.Pop();
            _Stack.Push((int)( two % one ) );

        }
        public void OpAnd()
        {
            int one =(int)_Stack.Pop();
            int two =(int)_Stack.Pop();
            if( one !=0 && two!=0)
            {
                _Stack.Push(1);
                return;
            }
            _Stack.Push(0);
        }

        public void OpOr()
        {
            int one =(int)_Stack.Pop();
            int two =(int)_Stack.Pop();
            if( one !=0 || two!=0)
            {
                _Stack.Push(1);
                return;
            }
            _Stack.Push(0);
        }
        public void OpNot()
        {
            int one =(int)_Stack.Pop();
            if(one!=0)
            {
                _Stack.Push(0);
                return;
            }
            _Stack.Push(1);
        }


        /*Relational operators*/
        public void notEQ()
        {
            if( Popi()!= Popi())
            {
                _Stack.Push(1);
                
            }else
            { 
                _Stack.Push(0);
            }
        }
        public void lessEQ()
        {
            if( Popi()> Popi())
            {
                _Stack.Push(1);
            }else{ 
            _Stack.Push(0);
        }}

        public void grEQ()
        {
            {
            if( Popi()< Popi())
            {
                _Stack.Push(1);
            }else{ 
            _Stack.Push(0);
        }}


        }


        public void less()
        {
            if( Popi()> Popi())
            {
                _Stack.Push(1);
            }else
            {
                _Stack.Push(0);
            }
        }

        public int grEq()
        {
            int retval =0;
            if( Popi()>= Popi())
            {
                retval = 1;
            }
            _Stack.Push(retval);
            return retval;
        }

        public int gr()
        {
            int retval =0;
            if( !(Popi()>= Popi()))
            {
                retval = 1;
            }
            _Stack.Push(retval);
            return retval;
        }
        public void notEq()
        {
            if( Popi()!= Popi())
            {
                _Stack.Push(1);
            }
            _Stack.Push(0);
        }
        public void EQ()
        {
            if( Popi()== Popi())
            {
                _Stack.Push(1);
            }
            _Stack.Push(0);
        }
        public void print(bool isSubProg=false)
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