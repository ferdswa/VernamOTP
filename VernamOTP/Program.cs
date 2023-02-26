using System;

namespace VernamOTP
{
    class Program
    {
        static Vernam cVernam = new Vernam();
        static void Main(string[] args)
        {
            cVernam.vEntry();
        }
    }
}
