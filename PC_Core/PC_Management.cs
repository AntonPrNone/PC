using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace PC_Core
{
    public class PC_Manag // Взаимодействие с данными из БД
    {
        private SqlConnection connect = null;

        public PC_Manag()
        {
            OpenConnection(@"Data Source=DESKTOP-E15SOJN;Initial Catalog=PC_repository;Integrated Security=True;trust server certificate=True"); // Строка подключения
        }

        private void OpenConnection(string connectionString) // Создание подключение
        {
            connect = new SqlConnection(connectionString);
            connect.Open();
        }

        private void CloseConnection() // Закрытие подключения
        {
            connect.Close();
        }

        private bool CheckingTheCorrectnessOfTheData(List<string> ListData) // Проверка на корректность введёных данных
        {
            List<int> int_values = new List<int>() { 2, 3, 4, 5, 7, 8, 10, 11, 14, 15, 16, 18, 19, 20, 22, 23, 25, 26, 28, 29, 30, 31, 33 };
            List<int> bool_values = new List<int>() { 12, 34 };
            for (int i = 0; i < 35; i++)
            {
                if (int_values.Contains(i) && ListData[i] != "") // Если данное значение должно представлять из себя число
                {
                    try
                    {
                        Convert.ToInt32(ListData[i]);
                    }


                    catch
                    {
                        return false;
                    }
                }

                if (bool_values.Contains(i) && ListData[i] != "") // Если данное значение должно представлять из себя булев тип
                {
                    if (!(ListData[i] == "False" || ListData[i] == "True"))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public List<string> ReturnTableValues(string namePc) // Возращение конфигурации
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

            CloseConnection();
            return values;
        }

        public bool InsertTableValues(List<string> ListData) // Добавление конфигурации
        {
            if (CheckingTheCorrectnessOfTheData(ListData)) // Проверка корректности данных
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

                using (SqlCommand cmd = new SqlCommand(sql, connect))
                {
                    // Занесение данных в БД
                    cmd.Parameters.AddWithValue("@namePC", ListData[0]);
                    cmd.Parameters.AddWithValue("@motherboard_name", ListData[1]);
                    cmd.Parameters.AddWithValue("@motherboard_numberSlotsForRAM", ListData[2]);
                    cmd.Parameters.AddWithValue("@motherboard_numberSlotsForVideocard", ListData[3]);
                    cmd.Parameters.AddWithValue("@motherboard_numberSlotsForSATA", ListData[4]);
                    cmd.Parameters.AddWithValue("@motherboard_numberSlotsForUSB", ListData[5]);
                    cmd.Parameters.AddWithValue("@CPU_name", ListData[6]);
                    cmd.Parameters.AddWithValue("@CPU_numberCores", ListData[7]);
                    cmd.Parameters.AddWithValue("@CPU_frequency", ListData[8]);
                    cmd.Parameters.AddWithValue("@videocard_name", ListData[9]);
                    cmd.Parameters.AddWithValue("@videocard_memory", ListData[10]);
                    cmd.Parameters.AddWithValue("@videocard_frequency", ListData[11]);
                    cmd.Parameters.AddWithValue("@videocard_additionalMeals", ListData[12]);
                    cmd.Parameters.AddWithValue("@SSD_name", ListData[13]);
                    cmd.Parameters.AddWithValue("@SSD_memory", ListData[14]);
                    cmd.Parameters.AddWithValue("@SSD_reading", ListData[15]);
                    cmd.Parameters.AddWithValue("@SSD_record", ListData[16]);
                    cmd.Parameters.AddWithValue("@HDD_name", ListData[17]);
                    cmd.Parameters.AddWithValue("@HDD_memory", ListData[18]);
                    cmd.Parameters.AddWithValue("@HDD_reading", ListData[19]);
                    cmd.Parameters.AddWithValue("@HDD_record", ListData[20]);
                    cmd.Parameters.AddWithValue("@fan_name", ListData[21]);
                    cmd.Parameters.AddWithValue("@fan_rotationSpeed", ListData[22]);
                    cmd.Parameters.AddWithValue("@fan_quantity", ListData[23]);
                    cmd.Parameters.AddWithValue("@PSU_name", ListData[24]);
                    cmd.Parameters.AddWithValue("@PSU_power", ListData[25]);
                    cmd.Parameters.AddWithValue("@PSU_numberSATAconnectors", ListData[26]);
                    cmd.Parameters.AddWithValue("@PC_Case_name", ListData[27]);
                    cmd.Parameters.AddWithValue("@PC_Case_length", ListData[28]);
                    cmd.Parameters.AddWithValue("@PC_Case_height", ListData[29]);
                    cmd.Parameters.AddWithValue("@PC_Case_width", ListData[30]);
                    cmd.Parameters.AddWithValue("@PC_Case_weight", ListData[31]);
                    cmd.Parameters.AddWithValue("@PC_Case_basicMaterial", ListData[32]);
                    cmd.Parameters.AddWithValue("@PC_Case_numberFans", ListData[33]);
                    cmd.Parameters.AddWithValue("@PC_Case_illumination", ListData[34]);

                    cmd.ExecuteNonQuery();
                }

                CloseConnection();
                return true;
            }

            else
            {
                return false;
            }
        }

        public bool DeleteTableValues(string pc_name) // Удаление конфигурации
        {
            PC_Manag obj = new PC_Manag();
            List<string> configList = obj.ReturnTableValues(pc_name);

            string sql = string.Format("Delete from PC_config where namePC = '{0}'", pc_name);
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    CloseConnection();

                    return configList.Count != 0;
                }

                catch (SqlException ex)
                {
                    Exception error = new Exception("Не удалось выполнить операцию", ex);
                    throw error;
                }
            }
        }
    }
}
