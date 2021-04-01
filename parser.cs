using System;
using System.Collections.Generic;
namespace ProjectOne
{
    /// <summary>
    /// THis class handles the paring of commands
    /// </summary>
    class parser
    {
        /// <summary>
        /// this function handles paring
        /// </summary>
        /// <param name="line">the line to parse</param>
        /// <returns>amCommand object containing parsing info</returns>
        public static amCommand parse(string line)
        {
            amCommand retval = new amCommand();

            line = line.Trim();
            if (line.Length > 0)
            {
                string[] parts = line.Split(' ');
                retval.amcommand = parts[0].ToLower().Trim();
                if (retval.amcommand.CompareTo("show") == 0)
                {
                    retval.svalue = line.Replace("show", "").Trim();
                    retval.pushVal = line.Replace("show", "").Trim();
                }
                else if(retval.amcommand.CompareTo(".int") == 0)
                {
                    retval.svalue = parts[1];
                    retval.arrStr =parts[2];
                }
                else if (parts.Length > 1)
                {
                    int ot;
                    if (int.TryParse(parts[1], out ot))
                    {
                        retval.ivalue = ot;
                        retval.pushVal = ot;
                    }
                    else
                    {
                        retval.svalue = parts[1];
                        retval.pushVal = parts[1];
                    }
                }
            }
            else
            {
                retval.amcommand = "halt";
            }
            return retval;
        }
        /// <summary>
        /// Object to handle information about a command
        /// </summary>
        public class amCommand
        {
            public string amcommand { get; set; }
            public string svalue { get; set; }
            public int ivalue { get; set; }
            public object pushVal { get; set; }
            public string arrStr{get;set;}
        }

    }

}
