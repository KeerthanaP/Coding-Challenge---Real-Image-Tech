using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Search
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] c1 = { ' ' };
            char[] c2 = { '-' };
            
           // Console.WriteLine("Enter words to search: ");
            //string search = Console.ReadLine();
            string[] sa = args;
            string[] words=File.ReadAllLines(@"C:\Documents and Settings\Administrator\My Documents\Visual Studio 2008\Projects\Index\Index\bin\index.txt").ToArray();
            int i = 1;
            FileStream f1 = new FileStream(@"C:\Documents and Settings\Administrator\My Documents\Visual Studio 2008\Projects\Search\Search\bin\search.txt", FileMode.Create, FileAccess.Write);
            f1.Close();
            StreamWriter s1 = new StreamWriter(@"C:\Documents and Settings\Administrator\My Documents\Visual Studio 2008\Projects\Search\Search\bin\search.txt", true);
            foreach (string sword in sa)
            {
                s1.WriteLine(" ");
                s1.WriteLine(" ");
                s1.WriteLine("{0}.Searching for {1}", i++, sword);
                bool found = false;
                foreach (string word in words)
                {
                    String[] s = word.Split(c2);
                    s[0].Trim();
                    sword.Trim();
                    if (s[0] == sword)
                    {
                        s1.WriteLine("     Found in:");
                        String[] f = s[1].Split(c1);
                        foreach (string s2 in f)
                            s1.WriteLine("         {0}",s2);
                        found = true;
                        break;
                    }
                }
                if (!found)
                    s1.WriteLine("         Not found");
            }

            s1.Close();
            Console.WriteLine("Search file is created.");
            Console.ReadKey();
            
        }
    }
}
