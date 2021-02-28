using System;

namespace ProjectOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            for(int i=0;i<100000;i++){ 
                Console.Beep();
            }
            ProgFileMan pman = new ProgFileMan("");
            pman.SayHello();


        }
    }
}
