using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Lists
{
    public class L
    {
        private List<string> Lists = new List<string>();
        private LinkedList<string> LinkedLists = new LinkedList<string>();
        private List<HashSet<string>> ListHesh = new List<HashSet<string>>();
        private HashSet<char> Hashs= new HashSet<char>();
        private Dictionary<string,List<int>> Tost = new Dictionary<string, List<int>>();
        public List<string> Keys = new List<string>();//Создано для серриализации
        public List<List<int>> Values = new List<List<int>>();//Создано для серриализации
        public L()
        {
        }
        private void nDict(string Name, string LName, int c = 0, int t = 1)
        {
            try
            {
                if (t == 1) { Tost.Add(Name + " " + LName, new List<int>()); }
                else { Tost[Name + " " + LName].Add(c); }
            }
            catch
            {
                Tost.Remove(Name + " " + LName);
                Tost.Add(Name + " " + LName, new List<int>());
            }
        }
        private void nDict(string Key,List<int> Value)
        {
            Tost.Add(Key, Value);
        }
        public HashSet<string> allStudent() {
            HashSet<string> set = new HashSet<string>();
            set = ListHesh[0];
            foreach (var s in ListHesh) {
                set.IntersectWith(s);
            }
            return set;
        }
        public HashSet<string> someStudent(HashSet<string> lis)
        {
            HashSet<string> set = new HashSet<string>();
            set = ListHesh[0];
            foreach (var s in ListHesh)
            {
                set.UnionWith(s);
            }
            set.ExceptWith(lis);
            return set;
        }
        public List<string> notStudent(List<string> temp) {
            HashSet<string> set = new HashSet<string>();
            set = ListHesh[0];
            List<string> set2=new List<string>();
            foreach (var s in ListHesh)
            {
                set.UnionWith(s);
            }
            foreach (var item in temp)
            {
                if (set.Contains(item)==false) {
                    set2.Add(item); 
                }
            }
            return set2; 
        }
        public void AddHash(string text,int i) {
            try
            {
                ListHesh[i].Add(text);
            }
            catch {
                ListHesh.Add(new HashSet<string>());
                ListHesh[ListHesh.Count()-1].Add(text);
            }
        }
        public void AddList(string text) {
            Lists.Add(text);
        }
        public void AddLinked(string text) {
            LinkedLists.AddLast(text);
        }
        public void AddBack(L L1) {
            L Li = new L();
            foreach (var i in L1.LinkedLists) {
                Li.LinkedLists.AddFirst(i);
            }
            foreach (var i in Li.LinkedLists) {
                L1.AddLinked(i);
            }
        }
        public L intersection(L L1,L L2) {
            L Li = new L();
            foreach (string l in L1.Lists) {
                foreach (string l2 in L2.Lists) {
                    if ((l == l2 )&&(Li.Lists.Contains(l)==false)) {
                        Li.AddList(l);
                    }
                }
            }
            return Li;
        }
        public string printHash(HashSet<string> set) {
            string text = "";
            foreach (string l in set) {
                text += l + " ";
            }

            return text;
        }
        public string printList(List<string> set)
        {
            string text = "";
            foreach (string l in set)
            {
                text += l + " ";
            }
            return text;
        }
        public string print(int i=1) {
            string text = "";
            if (i == 1)
            {
                foreach (var item in Lists)
                {
                    text += item+" ";
                }
            }
            else if(i==2) {
                foreach (var item in LinkedLists)
                {
                    text += item + " ";
                }
            }
            return text;
        }
        
        private bool letter(char c) {
            foreach (var i in " 1234567890-=.,/|!@#$%^&*()_+{}[]~`")
            {
                if (c == i) {
                    return false;
                }
            }
            return true;
        }
        public int numbers()
        {
            using (StreamReader reader = new StreamReader("Text.txt"))
            {
                string text = reader.ReadLine();
                while (text != null)
                {
                    foreach (var i in text)
                    {
                        if (Hashs.Contains(i) == false && letter(i))
                        {
                            Hashs.Add(i);
                        }
                    }
                    text = reader.ReadLine();
                }
            }
            return Hashs.Count();
        }
        public void writeFile(int N,int M)
        {
            string Name = "";
            string LName = "";
            string text = "";
            int c = 0;
            string[] texts;
            L lis = new L();
            for (int i = 0; i < N; i++) {
                
                text = Console.ReadLine();
                texts = text.Split(' ');
                while (texts[0].Length > 20)
                {
                    Console.WriteLine("Слишком большое имя. Введите ещё раз.");
                    texts[0] = Console.ReadLine();
                }
                while (texts[1].Length > 12)
                {
                    Console.WriteLine("Слишком большая фамилия. Введите её ещё раз.");
                    texts[1] = Console.ReadLine();
                }
                lis.nDict(texts[0], texts[1]);
                for (int j = 2; j < M+2; j++) {
                    try
                    {
                        c = Convert.ToInt32(texts[j]);
                    }
                    catch
                    {
                        c = 0;
                    }
                    lis.nDict(texts[0], texts[1], c,2);
                }
            }
            foreach(var s in lis.Tost.Keys)
            {
                lis.Keys.Add(s);
                lis.Values.Add(lis.Tost[s]);
            }
            XmlSerializer f = new XmlSerializer(typeof(L));
            using (FileStream fs = new FileStream("date.xml", FileMode.OpenOrCreate))
            {
                f.Serialize(fs, lis);
            }

        }
        public void readeFile()
        {
            XmlSerializer f = new XmlSerializer(typeof(L));
            L lis = new L();
            using (FileStream fs = new FileStream("date.xml", FileMode.OpenOrCreate))
            {
                lis=f.Deserialize(fs) as L;
            }
            int c = 0;
            foreach (var i in lis.Keys) {
                lis.nDict(i, lis.Values[c]);
                c++;
            }
            Dictionary<String, int> D = new Dictionary<string, int>();
            int temp = 0;
            foreach(var s in lis.Tost.Keys)
            {
                foreach(var t in lis.Tost[s])
                {
                    temp += t;
                }
                D.Add(s, temp);
                temp = 0;
            }
            var CD = from entry in D orderby entry.Value ascending select entry;
            c = 1;
            foreach(var i in CD.Reverse())
            {
                Console.Write(Convert.ToString(i));
                Console.WriteLine(" "+c);
                c++;
                
            }
        }

    }
}
