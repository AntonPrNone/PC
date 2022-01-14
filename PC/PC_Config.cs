using System;

namespace PC
{
    public class PC_Config
    {
        public string namePC; // Наименование ПК

        // Материнская плата
        public string motherboard_name;
        public int motherboard_numberSlotsForRAM, motherboard_numberSlotsForVideocard, motherboard_numberSlotsForSATA, motherboard_numberSlotsForUSB;

        // Процессор
        public string CPU_name = "1";
        public int CPU_numberCores;
        public int CPU_frequency;

        // Видеокарта
        public string videocard_name;
        public int videocard_memory;
        public int videocard_frequency;
        public bool videocard_additionalMeals;

        // SSD накопитель
        public string SSD_name;
        public int SSD_memory;
        public int SSD_reading;
        public int SSD_record;

        // HDD накопитель
        public string HDD_name;
        public int HDD_memory;
        public int HDD_reading;
        public int HDD_record;

        // Вентилятор
        public string fan_name;
        public int fan_rotationSpeed;
        public int fan_quantity;

        // Блок питания
        public string PSU_name;
        public int PSU_power;
        public int PSU_numberSATAconnectors;

        // Корпус
        public string PC_Case_name;
        public int PC_Case_length, PC_Case_height, PC_Case_width;
        public int PC_Case_weight;
        public string PC_Case_basicMaterial;
        public int PC_Case_numberFans;
        public bool PC_Case_illumination;
    }
}
