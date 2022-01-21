using System;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace sqltest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection cn = new SqlConnection())
            {

                cn.ConnectionString = @"Data Source=DESKTOP-L9II8RV;Initial Catalog=PC_repository;Integrated Security=True;trust server certificate=True";
                try
                {
                    
                    //Открыть подключение
                    cn.Open();

                    string strSQL = "SELECT * FROM PC_config";
                    SqlCommand myCommand = new SqlCommand(strSQL, cn);
                    SqlDataReader dr = myCommand.ExecuteReader();
                    while (dr.Read())
                    { 
                        if ((string)dr[0] == "MyPc")
                        Console.WriteLine("{0}; {1}; {2}; {3}; {4}; {5}", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
                    }
                        

                    Console.ReadKey();
                    

                   


                }
                catch (SqlException ex)
                {
                    // Протоколировать исключение
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // Гарантировать освобождение подключения
                    cn.Close();
                }
            }

            
        }
    }

    public class InventoryDAL
    {
        private SqlConnection connect = null;

        public void OpenConnection(string connectionString)
        {
            connect = new SqlConnection(connectionString);
            connect.Open();
        }

        public void CloseConnection()
        {
            connect.Close();
        }

        public void InsertAuto(string namePC, string motherboard_name, int motherboard_numberSlotsForRAM)
        {
            // Оператор SQL
            string sql = string.Format("Insert Into PC_config" +
                   "(namePC, motherboard_name, motherboard_numberSlotsForRAM) Values(@namePC, @motherboard_name, @motherboard_numberSlotsForRAM)");

            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                // Добавить параметры
                cmd.Parameters.AddWithValue("@namePC", namePC);
                cmd.Parameters.AddWithValue("@motherboard_name", motherboard_name);
                cmd.Parameters.AddWithValue("@motherboard_numberSlots", motherboard_numberSlotsForRAM);

            }
        }
    }
}