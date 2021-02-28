using System;
using System.Collections.Generic;
namespace ProjectOne
{
/// <summary>
/// This class manages loading the file and the actual "Program"
/// </summary>
    class ProgFileMan
    {
        
        private string _FileName;
        // program counter this is the next line
        private int progCounter = 0;
        //this holds the labels
        private Dictionary<String, int> Labels;
        //the program is held in this list
        private List<string> program;

        public ProgFileMan(string FileName) => _FileName = FileName;

         
        public bool LoadProg()
        {
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
                    if (cmd.CompareTo("label") == 0)
                    {
                        Labels[cmd] = cntr;

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




        public void SayHello()
        {
            Console.WriteLine("___________Hello___________");
        }
    }
}