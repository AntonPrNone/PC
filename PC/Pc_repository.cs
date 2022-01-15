using System;
using System.Collections.Generic;
using System.Text;

namespace PC
{
    public class Pc_repository
    {
        static List<PC_Config> assemblies = new List<PC_Config>();

        public static void CreateConfig(PC_Config conf)
        {
            assemblies.Add(conf);
        }

        public static bool RemoveConfig(string nameconf)
        {
            for (int i = 0; i < assemblies.Count; i++)
            {
                if (assemblies[i].namePC == nameconf)
                {
                    assemblies.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public static PC_Config ReturnConfig(string nameconf)
        {
            for (int i = 0; i < assemblies.Count; i++)
            {
                if (assemblies[i].namePC == nameconf) return assemblies[i];
            }
            return null;
        }
    }
}