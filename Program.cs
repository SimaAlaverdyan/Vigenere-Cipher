using System;
using System.Collections.Generic;

namespace cipher
{
    class Program
    {
        static char[] MatrixRows(char[] alphabet)
        {
            char c = alphabet[0];

            for (int i = 0; i < alphabet.Length - 1; i++)
            {
                alphabet[i] = alphabet[i + 1];
            }
            alphabet[alphabet.Length - 1] = c;

            return alphabet;
        }
        static char[,] GenerateMatrix(char[] alphabet)
        {
            char[,] matrix = new char[alphabet.Length, alphabet.Length];

            for (int i = 0; i < alphabet.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    matrix[i, j] = alphabet[j];

                    //Console.Write(matrix[i, j] + " ");
                }
                alphabet = MatrixRows(alphabet);
                //Console.WriteLine();
            }

            return matrix;
        }
        static void Vigenere(char[] sentence, char[] key, char[,] matrix, char[] alph)
        {
            List<char> result = new List<char>();
            List<int> x = new List<int>();
            List<int> y = new List<int>();

            for (int i = 0; i < sentence.Length; i++)
            {
                for (int j = 0; j < alph.Length; j++)
                {
                    if (sentence[i] == alph[j])
                    {
                        x.Add(j);
                    }
                }
            }
            for (int i = 0; i < key.Length; i++)
            {
                for (int j = 0; j < alph.Length; j++)
                {
                    if (key[i] == alph[j])
                    {
                        y.Add(j);
                    }
                }
            }

            for (int i = 0; i < x.Count; i++)
            {
                result.Add(matrix[x[i], y[i]]);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Encrypted Sentence: ");
            foreach (var item in result)
            {
                Console.Write(item);
            }
            Console.ResetColor();
        }
        static void Main(string[] args)
        {
            Console.Write("Input The Sentence: ");
            string sent = Console.ReadLine().ToLower();

            Console.Write("Input Key: ");
            string key = Console.ReadLine().ToLower();

            //char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O',
            //                    'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o',
                                'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            char[] CharSent = sent.ToCharArray();
            char[] CharKey = key.ToCharArray();

            char[] FinKey = new char[CharSent.Length];

            char[,] matrix = GenerateMatrix(alphabet);

            if (key.Length < sent.Length)
            {
                int j = 0;
                for (int i = 0; i < CharSent.Length; i++)
                {
                    FinKey[i] = CharKey[j];
                    j++;

                    if (j > CharKey.Length - 1)
                    {
                        j = 0;
                    }
                }
            }
            else if (key.Length > sent.Length)
            {
                for (int i = 0; i < sent.Length; i++)
                {
                    FinKey[i] = key[i];
                }
            }

            Vigenere(CharSent, FinKey, matrix, alphabet);
        }
    }
}
