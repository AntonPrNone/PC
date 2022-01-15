using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PC_WPF
{
    /// <summary>
    /// Логика взаимодействия для Create.xaml
    /// </summary>
    public partial class Create : Window
    {
        public Create()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PC.PC_Config conf = new PC.PC_Config();
            conf.motherboard_name = tb1.Text;
            conf.motherboard_numberSlotsForRAM = Convert.ToInt32(tb2.Text);
            conf.motherboard_numberSlotsForVideocard = Convert.ToInt32(tb3.Text);
            conf.motherboard_numberSlotsForSATA = Convert.ToInt32(tb4.Text);
            conf.motherboard_numberSlotsForUSB = Convert.ToInt32(tb5.Text);
            conf.PSU_name = tb6.Text;
            conf.PSU_power = Convert.ToInt32(tb7.Text);
            conf.PSU_numberSATAconnectors = Convert.ToInt32(tb8.Text);
            conf.CPU_name = tb9.Text;
            conf.CPU_numberCores = Convert.ToInt32(tb10.Text);
            conf.CPU_frequency = Convert.ToInt32(tb11.Text);
            conf.videocard_name = tb12.Text;
            conf.videocard_memory = Convert.ToInt32(tb13.Text);
            conf.videocard_frequency = Convert.ToInt32(tb14.Text);
            conf.videocard_additionalMeals = Convert.ToBoolean(cb15.IsChecked);
            conf.SSD_name = tb16.Text;
            conf.SSD_memory = Convert.ToInt32(tb17.Text);
            conf.SSD_reading = Convert.ToInt32(tb18.Text);
            conf.SSD_record = Convert.ToInt32(tb19.Text);
            conf.HDD_name = tb20.Text;
            conf.HDD_memory = Convert.ToInt32(tb21.Text);
            conf.HDD_reading = Convert.ToInt32(tb22.Text);
            conf.HDD_record = Convert.ToInt32(tb23.Text);
            conf.fan_name = tb24.Text;
            conf.fan_rotationSpeed = Convert.ToInt32(tb25.Text);
            conf.fan_quantity = Convert.ToInt32(tb26.Text);
            conf.PC_Case_name = tb27.Text;
            conf.PC_Case_length = Convert.ToInt32(tb28.Text);
            conf.PC_Case_height = Convert.ToInt32(tb29.Text);
            conf.PC_Case_width = Convert.ToInt32(tb30.Text);
            conf.PC_Case_weight = Convert.ToInt32(tb31.Text);
            conf.PC_Case_basicMaterial = tb32.Text;
            conf.PC_Case_numberFans = Convert.ToInt32(tb33.Text);
            conf.PC_Case_illumination = Convert.ToBoolean(cb34.IsChecked);

            PC.Pc_repository.CreateConfig(conf);
        }
    }
}
