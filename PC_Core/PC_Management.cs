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

        public List<string> ReturnTableValues(string namePc)
        {
            try
            {
                string strSQL = "SELECT * FROM PC_config";
                SqlCommand myCommand = new SqlCommand(strSQL, connect);
                SqlDataReader dr = myCommand.ExecuteReader();
                List<string> values = new List<string>(35);
                while (dr.Read())
                {
                    if ((string)dr[0] == namePc)
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

        public void InsertTableValues(string namePC, string motherboard_name, int motherboard_numberSlotsForRAM, int motherboard_numberSlotsForVideocard, int motherboard_numberSlotsForSATA, int motherboard_numberSlotsForUSB, string PSU_name, int PSU_power, int PSU_numberSATAconnectors, string CPU_name, int CPU_numberCores, int CPU_frequency, string videocard_name, int videocard_memory, int videocard_frequency, bool videocard_additionalMeals, string SSD_name, int SSD_memory, int SSD_reading, int SSD_record, string HDD_name, int HDD_memory, int HDD_reading, int HDD_record, string fan_name, int fan_rotationSpeed, int fan_quantity, string PC_Case_name, int PC_Case_length, int PC_Case_height, int PC_Case_width, int PC_Case_weight, string PC_Case_basicMaterial, int PC_Case_numberFans, bool PC_Case_illumination)
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
