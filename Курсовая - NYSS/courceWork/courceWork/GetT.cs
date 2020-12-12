using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courceWork
{
    public class GetT
    {
        public static List<char> GetText(string path)
        {
            List<char> s = new List<char>();
            StreamReader rd = new StreamReader(path, System.Text.Encoding.UTF8);
            string st = rd.ReadToEnd();
            if (st.Contains('�')) st = File.ReadAllText(path, System.Text.Encoding.GetEncoding(1251));
            foreach (char a in st)
            {
                s.Add(a);
            }
            return s;
        }
    }
}


