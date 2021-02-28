using System;
using System.Collections.Generic;
namespace ProjectOne
{

    class parser
    {
        public static amCommand parse( string line)
        {
            amCommand retval = new amCommand();
            line = line.Trim();
            string [] parts = line.Split(' ');
            retval.amcommand =parts[0].ToLower();

            if( parts.Length>1)
            {
                int ot;
                if( int.TryParse(parts[1],out ot))
                {
                    retval.ivalue = ot;


                }else
                {
                    retval.svalue = parts[1];
                }
            }
            return retval;
        }
    
    
    
        public class amCommand
        {
            public string amcommand{get;set;}
            public string svalue{get;set;}
            public int  ivalue{get;set;}

        }
    
    }

}
