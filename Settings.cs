using System;
using System.Collections.Generic;
namespace ProjectOne
{
    /// <summary>
    /// This class manages Settings
    /// Change all configurable items here
    /// 
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Maximum allowed processors
        /// </summary>
        public const int MAXPROC = 2;  // maximum processors this simulator will run    
        /// <summary>
        /// the size of the memory
        /// </summary>
        public const int MEMSIZE = 10000;  // Size of Memory  memory is an nxn integer array
        /// <summary>
        /// a constant to indicate debugging
        /// </summary>
        public const bool DEBUGGING=false;  // set this to true for extra info when debugging
        /// <summary>
        /// a constant to indicate whether to use memdmp when debugging
        /// </summary>
        public const bool dmpMem =false;   // set this to true to use memory dumo to assist with debugging
    }
}