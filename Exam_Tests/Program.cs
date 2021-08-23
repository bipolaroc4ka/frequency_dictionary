using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Exam_Tests
{
    public class Text
    {
        string path;
        string[] files;        
        Dictionary<string, int> vacabulary = new Dictionary<string, int>();
        
        public Text(string path)
        {
            this.path = path;
            this.files = Directory.GetFiles(this.path);
        }
        public Dictionary<string, int> ReadText()
        {
           
            char[] separator = { ' ', ',', '.', '!', '?', ':' };
            foreach (var item in files)
            {
                if (item.Contains(".txt"))
                {
                    string[] text = File.ReadAllLines(item);
                    foreach (string tex in text)
                    {
                        string[] www = tex.Split(separator);
                        foreach (var item1 in www)
                        {
                            if (vacabulary.ContainsKey(item1))
                            {
                                vacabulary[item1]++;
                            }
                            else
                            {
                                vacabulary.Add(item1, 1);
                            }
                        }
                    }
                }
                
            }
            return this.vacabulary;
        }
        public IOrderedEnumerable<KeyValuePair<string, int>> SortDescending(Dictionary<string, int> pairs)
        {
           return pairs.OrderByDescending(i => i.Value);
        }
        public int SaveToFile(IOrderedEnumerable<KeyValuePair<string, int>> vacabulary, string fileresult)
        {
            try
            {
                StreamWriter sw = new StreamWriter(fileresult + "\\result.txt");
                foreach (var item in vacabulary)
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(item.Key + " " + item.Value);

                    sw.WriteLine(item.ToString());


                    //Console.WriteLine(item);
                }
                sw.Close();
                Console.WriteLine("Complete!");

                return 0;
            }
            catch (Exception)
            {

                return 1;
            }
            
        }
       
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter dir path: ");
            string path = Console.ReadLine();
            Text t = new Text(path);
            Dictionary<string, int> v = t.ReadText();
            IOrderedEnumerable<KeyValuePair<string, int>> vacabulary = t.SortDescending(v);
            Console.WriteLine("Enter path for file result: ");
            string fileresult = Console.ReadLine();
            t.SaveToFile(vacabulary, fileresult);           


        }
    }
}
