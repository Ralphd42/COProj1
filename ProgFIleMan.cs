using System;
using System.Collections.Generic;
namespace ProjectOne
{
/// <summary>
/// This class manages loading the file and the actual "Program"
/// </summary>
    class ProgFileMan
    {
        Stack<int> retStack;  // this manages rreturn values from routines
        private string _FileName;  // this is the file name
        // program counter this is the next line
        private int progCounter = 0;   // this is the program counter
        //this holds the labels
        private Dictionary<String, int> Labels;
        //the program is held in this list
        private List<string> program;   // this is the program in a list of strings
        

        public  ProgFileMan(string FileName) => _FileName = FileName;
                
         /// <summary>
         /// this loads the program stores it in program
         /// </summary>
         /// <returns></returns>
        public bool LoadProg()
        {
            retStack = new Stack<int>();
            program = new List<string>();
            progCounter = 0;
            Labels = new Dictionary<string, int>();
            string line;
            bool retval = false;
            int cntr = 0;
            using (System.IO.StreamReader sr = new System.IO.StreamReader(_FileName))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    program.Add(line);
                    string cmd = parser.parse(line).amcommand;
                    //string label = cmd.
                    if (cmd.CompareTo("label") == 0)
                    {
                        string label = parser.parse(line).pushVal.ToString().Trim();
                        Labels[label] = cntr;

                    }
                    cntr++;
                }
            }
            return retval;
        }
        /*
            GetNext command #
        */
        public int NextCmdNum
        {
            get
            {
                return progCounter;
            }
        }
/// <summary>
/// gets the next command Processor will call thsi
/// </summary>
/// <value></value>
        public string NextCommand
        {
            get
            {
                string retval = string.Empty;
                if (progCounter < program.Count)
                {
                    retval = program[progCounter];
                    ++progCounter;
                }
                return retval;
            }
        }
        
        /*
            moves to label return next Command sets 
        */
        public string Jump( string label)
        {
            int lbnum = Labels[label];
            progCounter =lbnum;
            return NextCommand;
        }

        public string Go( string label ,int checkVal ,bool isZero =true)
        {
            if( (isZero && checkVal ==0) || !isZero && checkVal!=0 )
            {
                return Jump(label);
            }
            return "";//NextCommand;
        }
/// <summary>
/// handles call to subroutine
/// </summary>
/// <param name="label"></param>
/// <returns></returns>
        public string call( string label)
        {
            retStack.Push(progCounter -1);
            return Jump(  label);
        }

        /// <summary>
        /// handles returning from subroutine
        /// </summary>
        /// <returns></returns>
        public string returnFromCall()
        {
            progCounter = retStack.Pop()+1;
            return "";//NextCommand"";
        }
        
    }
}

/*
    Storage for bad ideas
    public static ProgFileMan  PFM_NotUsed{get{
            if( _prog ==null)
            {
                _prog = new ProgFileMan("");

            }
            return _prog;

        }}
        private static ProgFileMan _prog; 




*/