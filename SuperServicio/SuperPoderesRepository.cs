using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperServicio
{
    public class SuperPoderesRepository
    {
        public static List<string> GetSuperPoderes(string fileName)
        {
            var list = new List<string>();
            var file = new System.IO.StreamReader(@"C:\Users\Darius\source\repos\SuperPoderes\SuperServicio\App_Data\"+ fileName +".DAT");
            string line;
            
            while((line = file.ReadLine()) != null)
            {
                list.Add(line);
            }
            file.Close();
            return list;
        }

        internal static void SetSuperPoderes(List<string> list, string fileName)
        {
            var file = new System.IO.StreamWriter(@"C:\Users\Darius\source\repos\SuperPoderes\SuperServicio\App_Data\" + fileName + ".DAT");
            
            foreach(var nombre in list)
            {
                file.WriteLine(nombre);
            }
            file.Close();
        }
    }
}