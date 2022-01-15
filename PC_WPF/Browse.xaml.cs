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
    /// Логика взаимодействия для Browse.xaml
    /// </summary>
    public partial class Browse : Window
    {
        public Browse()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var conf = PC.Pc_repository.ReturnConfig(tb0.Text);
            if (conf != null)
            {
                tb1.Text = conf.motherboard_name;
                tb2.Text = conf.motherboard_numberSlotsForRAM.ToString();
                tb3.Text = conf.motherboard_numberSlotsForVideocard.ToString();
                tb4.Text = conf.motherboard_numberSlotsForSATA.ToString();
                tb5.Text = conf.motherboard_numberSlotsForUSB.ToString();
                tb6.Text = conf.PSU_name;
                tb7.Text = conf.PSU_power.ToString();
                tb8.Text = conf.PSU_numberSATAconnectors.ToString();
                tb9.Text = conf.CPU_name;
                tb10.Text = conf.CPU_numberCores.ToString();
                tb11.Text = conf.CPU_frequency.ToString();
                tb12.Text = conf.videocard_name;
                tb13.Text = conf.videocard_memory.ToString();
                tb14.Text = conf.videocard_frequency.ToString();
                cb15.IsChecked = conf.videocard_additionalMeals;
                tb16.Text = conf.SSD_name;
                tb17.Text = conf.SSD_memory.ToString();
                tb18.Text = conf.SSD_reading.ToString();
                tb19.Text = conf.SSD_record.ToString();
                tb20.Text = conf.HDD_name;
                tb21.Text = conf.HDD_memory.ToString();
                tb22.Text = conf.HDD_reading.ToString();
                tb23.Text = conf.HDD_record.ToString();
                tb24.Text = conf.fan_name.ToString();
                tb25.Text = conf.fan_rotationSpeed.ToString();
                tb26.Text = conf.fan_quantity.ToString();
                tb27.Text = conf.PC_Case_name;
                tb28.Text = conf.PC_Case_length.ToString();
                tb29.Text = conf.PC_Case_height.ToString();
                tb30.Text = conf.PC_Case_width.ToString();
                tb31.Text = conf.PC_Case_weight.ToString();
                tb32.Text = conf.PC_Case_basicMaterial.ToString();
                tb33.Text = conf.PC_Case_numberFans.ToString();
                cb34.IsChecked = conf.PC_Case_illumination;

                label1.Content = "Название сборки";
            }

            else
            {
                label1.Content = "Не найдено";
            }
            
        }
    }
}
