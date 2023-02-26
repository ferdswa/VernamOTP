using System;
using System.Collections.Generic;
using System.Text;

namespace VernamOTP
{
    class Vernam
    {
        static vernamEncrypt VE = new vernamEncrypt(); static vernamDecrypt VD = new vernamDecrypt();
        public void vEntry()
        {
            Console.Clear();
            char entry;
            Console.WriteLine("-----VERNAM CIPHER-----\n");
            Console.WriteLine("Enter a selection:\n\n[E]ncrypt\n[D]ecrypt\n\n");
            try
            {
                entry = char.Parse(Console.ReadLine().ToUpper());
                switch (entry)
                {
                    case 'E':
                        VE.vEncrypt();
                        break;
                    case 'D':
                        VD.vDecrypt();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please provide a valid option. Try again.\n");
                        vEntry();
                        break;
                }
                vEntry();
            }
            catch(FormatException)
            {
                Console.WriteLine("Please enter a single character. Try again.");
                vEntry();
            }
        }
    }
}
