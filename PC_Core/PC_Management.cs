using System;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace PC_Core
{

    public class PC_Manag
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

        public List<string> ReturnTableValues()
        {
            try
            {
                string strSQL = "SELECT * FROM PC_config";
                SqlCommand myCommand = new SqlCommand(strSQL, connect);
                SqlDataReader dr = myCommand.ExecuteReader();
                List<string> values = new List<string>(35);
                while (dr.Read())
                {
                    if ((string)dr[0] == "MyPc")
                    {

                        for (int i = 0; i < 35; i++)
                        {
                            values.Add(dr[i].ToString());
                        }
                    }
                }   

                return values;
            }

            catch (SqlException ex)
            {
                // Протоколировать исключение
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void InsertTableValues(string namePC, string motherboard_name, int motherboard_numberSlotsForRAM)
        {
            // Оператор SQL
            string sql = string.Format("Insert Into PC_config" +
                   "(namePC, motherboard_name, motherboard_numberSlotsForRAM) Values(@namePC, @motherboard_name, @motherboard_numberSlotsForRAM)");

            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                // Добавить параметры
                cmd.Parameters.AddWithValue("@namePC", namePC);
                cmd.Parameters.AddWithValue("@motherboard_name", motherboard_name);
                cmd.Parameters.AddWithValue("@motherboard_numberSlotsForRAM", motherboard_numberSlotsForRAM);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTableValues(string pc_name)
        {
            string sql = string.Format("Delete from PC_config where namePC = '{0}'", pc_name);
            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("К сожалению, эта машина заказана!", ex);
                    throw error;
                }
            }
        }
    }
}
