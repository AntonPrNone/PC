using System;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace PC_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            PC_Manag a = new PC_Manag();
            a.OpenConnection(@"Data Source=DESKTOP-L9II8RV;Initial Catalog=PC_repository;Integrated Security=True;trust server certificate=True");
            //a.InsertTableValues("Name", "nameMother", 10);
            //a.DeleteTableValues("Name");
            foreach (string i in a.ReturnTableValues())
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
            a.CloseConnection();
        }
    }

}
