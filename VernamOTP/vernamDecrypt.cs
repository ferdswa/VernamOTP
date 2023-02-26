using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VernamOTP
{
    class vernamDecrypt:Vernam
    {
        public void vDecrypt()
        {
            char opt;
            Console.Clear();
            Console.WriteLine("Where to decrypt from?\n\n[F]ile\n[L]ine\n[Q]uit back to main menu");
            opt = Char.Parse(Console.ReadLine().ToUpper());
            switch(opt)
            {
                case 'F':
                    vernamDecryptFromfile();
                    break;
                case 'L':
                    vernamDecryptFromEntry();
                    break;
                case 'Q':
                    vEntry();
                    break;
                default:
                    Console.WriteLine("Invelid entry, try again");
                    vDecrypt();
                    break;
            }
        }
        void vernamDecryptFromEntry()
        {
            string cipherText, key;

            Console.WriteLine("Enter ciphertext:\n");
            cipherText = Console.ReadLine();
            Console.WriteLine("Enter key: \n");
            key = Console.ReadLine();

            string result = Decrypt(cipherText, key);

            Console.Clear();
            Console.WriteLine("Your ciphertext was: \n" + cipherText);
            Console.WriteLine("\nYour key was: \n" + key);
            Console.WriteLine("\nYour plaintext is: \n" + result);
            Console.WriteLine("\n\nPress [ENTER] to continue...");
            Console.ReadLine();

            vEntry();
        }
        void vernamDecryptFromfile()
        {
            string fileName, fileNameKey, key, cipherText;
            
            Console.WriteLine("Enter the filename (Don't include .txt)\n");
            string input = Console.ReadLine();
            fileName = input + ".txt"; 
            fileNameKey = input + "key" + ".txt";
            try
            {
                using(StreamReader srtxt = new StreamReader(fileName))
                {
                    cipherText = srtxt.ReadToEnd();
                    srtxt.Close();
                }
                using(StreamReader srkey = new StreamReader(fileNameKey))
                {
                    key = srkey.ReadToEnd();
                    srkey.Close();
                }
                string plainText = Decrypt(cipherText, key);

                Console.Clear();
                Console.WriteLine("Your ciphertext was: \n" + cipherText);
                Console.WriteLine("\nYour key was: \n" + key);
                Console.WriteLine("\nYour plaintext is: \n" + plainText);
                Console.WriteLine("\n\nPress [ENTER] to continue...");
                Console.ReadLine();

                vEntry();

            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }
        }
        string Decrypt(string cipherText, string key)
        {
            string plainText = string.Empty;
            int plainBinary;
            char plainChar;
            for (int charPos = 0; charPos < cipherText.Length; charPos++)//encryption happens here
            {
                plainBinary = cipherText[charPos] ^ key[charPos];//XOR
                plainChar = (char)plainBinary;
                plainText += plainChar;
            }
            return plainText;
        }
    }
}
