using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Exam_Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter dir path: ");
            string path = Console.ReadLine();            
            string[] files = Directory.GetFiles(path);
            Dictionary<string, int> vacabulary = new Dictionary<string, int>();
            char[] separator = { ' ', ',', '.', '!', '?', ':' };
            foreach (string file in files)
            {
                if (file.Contains(".txt"))
                {
                   string[] text = File.ReadAllLines(file);
                    foreach (string tex in text)
                    {
                        string[] www = tex.Split(separator);
                        foreach (var item in www)
                        {
                            if (vacabulary.ContainsKey(item))
                            {
                                vacabulary[item]++;
                            }
                            else
                            {
                                vacabulary.Add(item, 1);
                            }
                        }
                    }
                }
                
            }
            var result = vacabulary.OrderByDescending(i => i.Value);
            Console.WriteLine("Enter path for file result: ");
            string fileresult = Console.ReadLine();
            StreamWriter sw = new StreamWriter(fileresult + "\\result.txt");
            foreach (var item in result)
            {
               byte[] array = System.Text.Encoding.Default.GetBytes(item.Key + " " +item.Value);

                sw.WriteLine(item.ToString());
                
               
                //Console.WriteLine(item);
            }
            sw.Close();
            Console.WriteLine("Complete!");


        }
    }
}
