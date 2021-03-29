using System;
using System.Collections.Generic;
namespace ProjectOne
{
/// <summary>
/// This class manages loading the file and the actual "Program"
/// </summary>
    class Processor
    {
        /// <summary>
        /// the program to run
        /// </summary>
        private ProgFileMan pg;
        /// <summary>
        /// the stack fot this process
        /// </summary>
        private SStack _stack;
        /// <summary>
        /// file to process
        /// </summary>
        private string _filename;    
        public Processor(string FileName)
        {
            _filename =FileName;
            _pMode = ProcMode.Project1_Legacy;  // start out as legacy until something changes this
        }



        /// <summary>
        /// the current mode the processor is in
        /// </summary>
        private ProcMode _pMode;
        /// <summary>
        /// This is the main processor
        /// processing starts here
        /// </summary>
        public void Process( )
        {

            Smemory CurMem = Smemory.MEM;
            bool inBegin =false;
            bool inCall =false;
            
               
            //  load the program
            pg = new ProgFileMan(_filename);
            _stack = new SStack(pg);
            pg.LoadProg();
            // next we run the program by getting the instructions until complete
            var nxtStr =pg.NextCommand;
            var curcmd =parser.parse(nxtStr);
            while (curcmd.amcommand.CompareTo("halt")!=0)  // end of halt
            {
                if(Settings.DEBUGGING){ 
                    Console.WriteLine("FullCmd -- " +nxtStr);
                }
                // process cmds
                if( curcmd.amcommand.CompareTo("push")==0)
                {
                    _stack.push(curcmd.pushVal);
                }else
                if( curcmd.amcommand.CompareTo("rvalue")==0)
                {
                    _stack.rvalue(curcmd.svalue,inCall);//  .push(curcmd.pushVal);
                }else
                if( curcmd.amcommand.CompareTo("lvalue")==0)
                {
                    _stack.lvalue(curcmd.svalue);//  .push(curcmd.pushVal);
                }else
                if( curcmd.amcommand.CompareTo("pop")==0)
                {
                    _stack.pop();//  .push(curcmd.pushVal);
                }else if( curcmd.amcommand.CompareTo(":=")==0)
                {
                    _stack.SetMemFromStack( inBegin);//  .push(curcmd.pushVal);
                }
                
                else if( curcmd.amcommand.CompareTo("copy")==0)
                {
                    // not implemented
                }else  if( curcmd.amcommand.CompareTo("goto")==0)
                {
                    pg.Jump(curcmd.pushVal.ToString());//  .push(curcmd.pushVal);
                }else  if( curcmd.amcommand.CompareTo("gofalse")==0)
                {
                    _stack.gofalse(curcmd.svalue);
                }else  if( curcmd.amcommand.CompareTo("gotrue")==0)
                {
                    _stack.goTrue(curcmd.svalue);
                }else   if( curcmd.amcommand.CompareTo("+")==0)
                {
                    _stack.add();
                }else   if( curcmd.amcommand.CompareTo("-")==0)
                {
                    _stack.subtract();
                }else if( curcmd.amcommand.CompareTo("*")==0)
                {
                    _stack.multiply();
                }else if( curcmd.amcommand.CompareTo("/")==0)
                {
                    _stack.divide();
                }else if( curcmd.amcommand.CompareTo("div")==0)
                {
                    _stack.modulus();
                }
                else if ( curcmd.amcommand.CompareTo("show")==0)
                {
                    Console.WriteLine(curcmd.svalue);
                }
                else if ( curcmd.amcommand.CompareTo("print")==0)
                {
                    _stack.print();
                }
                else if ( curcmd.amcommand.CompareTo("call")==0)
                {
                    pg.call(curcmd.pushVal.ToString());
                    CurMem.State =2;
                    inCall =true;
                }else if ( curcmd.amcommand.CompareTo("return")==0)
                {
                    CurMem.State =3;
                    pg.returnFromCall();
                    inCall =false;
                    CurMem.State =3;
                 
                }else if ( curcmd.amcommand.CompareTo(">")==0)
                {
                    _stack.gr();
                //gr
                }else if ( curcmd.amcommand.CompareTo("<")==0)
                {
                    _stack.less();
                //gr
                }
                else if ( curcmd.amcommand.CompareTo("<>")==0)
                {
                    _stack.notEQ();
                //gr lessEQ  grEQ
                }else if (curcmd.amcommand.CompareTo("<=")==0)
                {
                    _stack.lessEQ();
                }else if (curcmd.amcommand.CompareTo(">=")==0)
                {
                    _stack.grEQ();
                }
                else if (curcmd.amcommand.CompareTo("begin")==0)
                {
                    inBegin =true;
                    CurMem = CurMem.addChild(CurMem);
                    _stack.curMem =CurMem;
                }else if (curcmd.amcommand.CompareTo("end")==0)
                {
                    inBegin =false;
                    CurMem = CurMem.ParentMem;
                    _stack.curMem = CurMem;
                }
                else if (curcmd.amcommand.CompareTo("&")==0)
                {
                    _stack.OpAnd();
                }
                else if (curcmd.amcommand.CompareTo("|")==0)
                {
                    _stack.OpOr();
                }
                else if (curcmd.amcommand.CompareTo("!")==0)
                {
                    _stack.OpNot();
                }
                /*Project 2 modification*/
                else if(curcmd.amcommand.CompareTo(".data") ==0    )
                {
                    _pMode = ProcMode.data;

                }
                else if(curcmd.amcommand.CompareTo(".text") ==0    )
                {
                    _pMode = ProcMode.text;

                }
                else if(curcmd.amcommand.CompareTo(".int") ==0    )
                {   
                    if( _pMode==ProcMode.data)
                    {
                        // add lvaue to data segment
                    }

                }
                else if( curcmd.amcommand.CompareTo("&=")==0)
                {
                    _stack.SetMemFromStack( inBegin);//  .push(curcmd.pushVal);
                }

                nxtStr =pg.NextCommand;
                curcmd =parser.parse(nxtStr);
            }
            return ;
        }
    }

    /// <summary>
    /// Enum for processor modes.Processor can either be in data or instruction mode
    /// op0
    /// </summary>
    public enum ProcMode
    {
        /// items stored in data segment
        data,
        ///Items stored in user text section
        text,
        ///This is to keep compatibility with project 1
        Project1_Legacy
    }
}