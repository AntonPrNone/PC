using System;
using System.Collections.Generic;
using System.Text;

namespace PC
{
    class Pc_repository
    {
        List<PC_Config> assemblies = new List<PC_Config>();

        public void CreateConfig(PC_Config conf)
        {
            assemblies.Add(conf);
        }

        public void RemoveConfig(string nameconf)
        {
            for (int i = 0; i < assemblies.Count; i++)
            {
                if (assemblies[i].namePC == nameconf) assemblies.RemoveAt(i);
            }
        }

        public PC_Config ReturnConfig(string nameconf)
        {
            for (int i = 0; i < assemblies.Count; i++)
            {
                if (assemblies[i].namePC == nameconf) return assemblies[i];
            }

            return null;
        }
    }
}