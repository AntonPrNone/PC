using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

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

        public void InsertTableValues(string namePC, string motherboard_name, int motherboard_numberSlotsForRAM, int motherboard_numberSlotsForVideocard, int motherboard_numberSlotsForSATA, int motherboard_numberSlotsForUSB, string PSU_name, int PSU_power, int PSU_numberSATAconnectors, string CPU_name, int CPU_numberCores, int CPU_frequency, string videocard_name, int videocard_memory, int videocard_frequency, bool videocard_additionalMeals, string SSD_name, int SSD_memory, int SSD_reading, int SSD_record, string HDD_name, int HDD_memory, int HDD_reading, int HDD_record, string fan_name, int fan_rotationSpeed, int fan_quantity, string PC_Case_name, int PC_Case_length, int PC_Case_height, int PC_Case_width, int PC_Case_weight, string PC_Case_basicMaterial, int PC_Case_numberFans, bool PC_Case_illumination)
        {
            string sql = string.Format("Insert Into PC_config" +
                   "(namePC, motherboard_name, motherboard_numberSlotsForRAM, motherboard_numberSlotsForVideocard," +
                   " motherboard_numberSlotsForSATA, motherboard_numberSlotsForUSB, CPU_name, CPU_numberCores, CPU_frequency," +
                   " videocard_name, videocard_memory, videocard_frequency, videocard_additionalMeals, SSD_name, SSD_memory, " +
                   "SSD_reading, SSD_record, HDD_name, HDD_memory, HDD_reading, HDD_record, fan_name, fan_rotationSpeed, fan_quantity," +
                   " PSU_name, PSU_power, PSU_numberSATAconnectors, PC_Case_name, PC_Case_length, PC_Case_height, PC_Case_width, PC_Case_weight," +
                   " PC_Case_basicMaterial, PC_Case_numberFans, PC_Case_illumination) Values(@namePC, @motherboard_name, @motherboard_numberSlotsForRAM," +
                   " @motherboard_numberSlotsForVideocard, @motherboard_numberSlotsForSATA, @motherboard_numberSlotsForUSB, @CPU_name, @CPU_numberCores, " +
                   "@CPU_frequency, @videocard_name, @videocard_memory, @videocard_frequency, @videocard_additionalMeals, @SSD_name, @SSD_memory, @SSD_reading, " +
                   "@SSD_record, @HDD_name, @HDD_memory, @HDD_reading, @HDD_record, @fan_name, @fan_rotationSpeed, @fan_quantity, @PSU_name, @PSU_power, " +
                   "@PSU_numberSATAconnectors, @PC_Case_name, @PC_Case_length, @PC_Case_height, @PC_Case_width, @PC_Case_weight, @PC_Case_basicMaterial," +
                   " @PC_Case_numberFans, @PC_Case_illumination)");

            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                cmd.Parameters.AddWithValue("@namePC", namePC);
                cmd.Parameters.AddWithValue("@motherboard_name", motherboard_name);
                cmd.Parameters.AddWithValue("@motherboard_numberSlotsForRAM", motherboard_numberSlotsForRAM);
                cmd.Parameters.AddWithValue("@motherboard_numberSlotsForVideocard", motherboard_numberSlotsForVideocard);
                cmd.Parameters.AddWithValue("@motherboard_numberSlotsForSATA", motherboard_numberSlotsForSATA);
                cmd.Parameters.AddWithValue("@motherboard_numberSlotsForUSB", motherboard_numberSlotsForUSB);
                cmd.Parameters.AddWithValue("@CPU_name", CPU_name);
                cmd.Parameters.AddWithValue("@CPU_numberCores", CPU_numberCores);
                cmd.Parameters.AddWithValue("@CPU_frequency", CPU_frequency);
                cmd.Parameters.AddWithValue("@videocard_name", videocard_name);
                cmd.Parameters.AddWithValue("@videocard_memory", videocard_memory);
                cmd.Parameters.AddWithValue("@videocard_frequency", videocard_frequency);
                cmd.Parameters.AddWithValue("@videocard_additionalMeals", videocard_additionalMeals);
                cmd.Parameters.AddWithValue("@SSD_name", SSD_name);
                cmd.Parameters.AddWithValue("@SSD_memory", SSD_memory);
                cmd.Parameters.AddWithValue("@SSD_reading", SSD_reading);
                cmd.Parameters.AddWithValue("@SSD_record", SSD_record);
                cmd.Parameters.AddWithValue("@HDD_name", HDD_name);
                cmd.Parameters.AddWithValue("@HDD_memory", HDD_memory);
                cmd.Parameters.AddWithValue("@HDD_reading", HDD_reading);
                cmd.Parameters.AddWithValue("@HDD_record", HDD_record);
                cmd.Parameters.AddWithValue("@fan_name", fan_name);
                cmd.Parameters.AddWithValue("@fan_rotationSpeed", fan_rotationSpeed);
                cmd.Parameters.AddWithValue("@fan_quantity", fan_quantity);
                cmd.Parameters.AddWithValue("@PSU_name", PSU_name);
                cmd.Parameters.AddWithValue("@PSU_power", PSU_power);
                cmd.Parameters.AddWithValue("@PSU_numberSATAconnectors", PSU_numberSATAconnectors);
                cmd.Parameters.AddWithValue("@PC_Case_name", PC_Case_name);
                cmd.Parameters.AddWithValue("@PC_Case_length", PC_Case_length);
                cmd.Parameters.AddWithValue("@PC_Case_height", PC_Case_height);
                cmd.Parameters.AddWithValue("@PC_Case_width", PC_Case_width);
                cmd.Parameters.AddWithValue("@PC_Case_weight", PC_Case_weight);
                cmd.Parameters.AddWithValue("@PC_Case_basicMaterial", PC_Case_basicMaterial);
                cmd.Parameters.AddWithValue("@PC_Case_numberFans", PC_Case_numberFans);
                cmd.Parameters.AddWithValue("@PC_Case_illumination", PC_Case_illumination);

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
                    Exception error = new Exception("Данной конфигурации не существует", ex);
                    throw error;
                }
            }
        }
    }
}
