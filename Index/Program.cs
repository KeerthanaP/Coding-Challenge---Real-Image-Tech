using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Index
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] index = new string[1000];
            string[] cindex = new string[1000];
            int ind=0;
            string path = args[0];
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] Files = d.GetFiles("*.txt"); 
            string str = "";
            string contents="";
            foreach(FileInfo file in Files )
            {
                str += file.Name+" ";
            }
            char[] c1 = { ' ' };
            char[] c2 = { '&' };
            string[] files = str.Split(c1);
              foreach (string f in files)
            {
                if (File.Exists(f))
                {
                    string c = File.ReadAllText(f);
                    contents+=c+"&";
                }
            }
            string[] content=contents.Split(c2);
            for(int i=0;i<content.Length;i++)
            {
                string c = content[i];
                string[] sp = c.Split(c1);
                int l = sp.Length;
                foreach (string word in sp)
                {
                    word.Trim();
                    if (!index.Contains(word))
                    {
                        
                        index[ind] = word;
                        cindex[ind] +=" " + files[i];
                        ind++;
                    }
                    else
                    {
                        int x = Array.IndexOf(index, word);
                        if (cindex[x].Contains(files[i]))
                            continue;
                        cindex[x] += " " + files[i];
                    }
                }              
            }
            int j = 0;
            FileStream f1 = new FileStream(@"C:\Documents and Settings\Administrator\My Documents\Visual Studio 2008\Projects\Index\Index\bin\index.txt", FileMode.Create, FileAccess.Write);
            f1.Close();
            StreamWriter s1 = new StreamWriter(@"C:\Documents and Settings\Administrator\My Documents\Visual Studio 2008\Projects\Index\Index\bin\index.txt", true);
            foreach(string st in cindex)
            {
                if (st == " ")
                    break;
                string text=index[j]+"-"+ st;
                s1.WriteLine(text);
                j++;
            }
            s1.Close();
            Console.WriteLine("Index file is created.");
            Console.ReadKey();
            
        }
    }
}
