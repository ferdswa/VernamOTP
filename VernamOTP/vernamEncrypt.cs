using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VernamOTP
{
    class vernamEncrypt:Vernam
    {
        Random rnd = new Random();
        char[] alphabet = { 'A', 'a', 'B', 'b', 'C', 'c', 'D', 'd', 'E', 'e', 'F', 'f', 'G', 'g', 'H', 'h', 'I', 'i', 'J', 'j', 'K', 'k', 'L', 'l', 'M', 'm', 'N', 'n', 'O', 'o', 'P', 'p', 'Q', 'q', 'R', 'r', 'S', 's', 'T', 't', 'U', 'u', 'V', 'v', 'W', 'w', 'X', 'x', 'Y', 'y', 'Z', 'z' };
        public void vEncrypt()
        {
            int cipherBinary;
            char cipherCharacter;
            Console.Clear();
            string plainText = string.Empty,key;
            Console.WriteLine("Enter the text that you would like to encrypt.\n");
            plainText = Console.ReadLine();

            if (plainText == string.Empty)
            {
                vEntry();
            }
            //generate key
            key = keyGen(plainText);
            string cipherText = string.Empty;
            int[] ASCIIVals = new int[plainText.Length];

            for (int charPos = 0; charPos < plainText.Length; charPos++)//encryption happens here
            {
                cipherBinary = plainText[charPos] ^ key[charPos];//XOR
                cipherCharacter = (char)cipherBinary;
                ASCIIVals[charPos] = cipherBinary;
                cipherText += cipherCharacter;
            }

            Console.Clear();
            Console.WriteLine("Your plaintext was:\n\n" + plainText);
            Console.WriteLine("\nYour key was:\n\n" + key);
            Console.WriteLine("\nYour ciphertext is:\n\n" + cipherText);
            Console.WriteLine("\nOr as ASCII values:\n\n");
            foreach(int i in ASCIIVals)
            {
                Console.Write(i+" ");
            }
            char yesNo;
            Console.WriteLine("\n\nDo you want to save this ciphertext? (Y|N)");
            yesNo = Char.Parse(Console.ReadLine().ToUpper());
            if (yesNo == 'Y')
                saveFile(cipherText, key);
            else
            {
                Console.WriteLine("Returning to main menu.");
                vEntry();
            }
            Console.WriteLine("\nPress ENTER to continue");
            Console.ReadLine();
            Console.WriteLine("Returning to main menu.");
            vEntry();
        }
        string keyGen(string x)//Generates pseudorandom key that is the same length as plaintext
        {
            string key = string.Empty;
            foreach(char c in x)
            {
                int i = rnd.Next(52);
                char d = alphabet[i];
                key += d;
            }
            return key;
        }
        void saveFile(string cipherT, string key)
        {
            string fileName, fileNameKey;
            Console.WriteLine("Enter a filename to save with");
            fileName = Console.ReadLine();
            fileNameKey = (fileName + "key");

            using(System.IO.StreamWriter CT = new System.IO.StreamWriter(fileName+".txt"))
            {
                Console.WriteLine("Saving ciphertext @ " + fileName + ".txt.");
                CT.Write(cipherT);
                CT.Close();
            }
            using (System.IO.StreamWriter K = new System.IO.StreamWriter(fileNameKey + ".txt"))
            {
                Console.WriteLine("Saving key @ " + fileNameKey + ".txt.");
                K.Write(key);
                K.Close();
            }
        }
    }
}
