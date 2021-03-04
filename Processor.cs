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
        private SStack _stack;
        /// <summary>
        /// This is the main processor
        /// processing starts here
        /// </summary>
        /// <param name="FileName">This is a file to be simulated</param>
        /// <returns>true if no errors</returns>
        public bool Process(  string FileName)
        {
            bool retval =false; 
            _stack = new SStack();   
            //  load the program
            pg = new ProgFileMan(FileName);
            // next we run the program by getting the instructions until complete
            var nxtStr =pg.NextCommand;
            var curcmd =parser.parse(nxtStr);
            while (curcmd.amcommand.CompareTo("halt")!=0)  // end of halt
            {
                Console.WriteLine("FullCmd -- " +nxtStr);
                // process cmds
                if( curcmd.amcommand.CompareTo("push")==0)
                {
                    _stack.push(curcmd.pushVal);
                }else
                if( curcmd.amcommand.CompareTo("rvalue")==0)
                {
                    _stack.rvalue(curcmd.svalue);//  .push(curcmd.pushVal);
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
                    _stack.SetMemFromStack();//  .push(curcmd.pushVal);
                }else if( curcmd.amcommand.CompareTo("copy")==0)
                {
                    // not implemented
                }else  if( curcmd.amcommand.CompareTo("goto")==0)
                {
                    pg.Jump(curcmd.svalue);//  .push(curcmd.pushVal);
                }else  if( curcmd.amcommand.CompareTo("gofalse")==0)
                {
                    _stack.gofalse(curcmd.svalue);
                }else  if( curcmd.amcommand.CompareTo("gotrue")==0)
                {
                    _stack.goTrue(curcmd.svalue);
                }else   if( curcmd.amcommand.CompareTo("+")==0)
                {
                    _stack.goTrue(curcmd.svalue);
                }else






                nxtStr =pg.NextCommand;
                curcmd =parser.parse(nxtStr);
            }





            return retval;
        }








    }
    
}