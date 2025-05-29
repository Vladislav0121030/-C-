using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Lab5
{
    class programm
    {
        static void Main(string[] args)
        {
            int num;
            Console.Write("Vvedite nomer zadaniya: ");
            num = Convert.ToInt32(Console.ReadLine());
            if (num == 1)
            {
                Regex regex1 = new Regex(@"a|a{5}|a aa a");
                string[] input = File.ReadAllLines(@"test.txt");
                for (int i = 0; i < input.Length; i++)
                {
                    if (regex1.IsMatch(input[i]))
                    {
                        Console.WriteLine("Good");
                    }
                    else
                    {
                        Console.WriteLine("Bad");
                    }
                }
            }
            if (num == 2)
            {
                Console.WriteLine("Vvedite ne menee 5 alfovitno-sifrovih simvolov:");
                string text = Console.ReadLine();
                string[] text2 = text.Split(new char[] {});
                Regex regex2 = new Regex(@"\d");
                //text = Convert.ToString(Console.ReadLine());
                if (text.Length >= 5)
                {
                    foreach (string el in text2)
                    {
                        if (regex2.IsMatch(el))
                        {
                            Console.WriteLine("Good");
                        }
                        else
                        {
                            Console.WriteLine("Bad");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Bad");
                }
            }
            //Console.ReadKey();
            if (num == 3)
            {
                Console.Write("Vvedite email: ");
                string text3 = Convert.ToString(Console.ReadLine());
                Regex regex3 = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
                    if (regex3.IsMatch(text3))
                    {
                        Console.WriteLine("Good");
                    }
                    else
                    {
                        Console.WriteLine("Bad");
                    }
            }
        }
      
    }
}
