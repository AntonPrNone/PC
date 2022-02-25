using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PC_WPF
{
    public partial class Create : Window // Создание конфигурации
    {
        public Create()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Массив объектов с данными
            List<object> tbList = new List<object>() {tb0, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8,
                                                  tb9, tb10, tb11, cb1, tb12, tb13, tb14, tb15,
                                                  tb16 , tb17, tb18, tb19, tb20, tb21, tb22,
                                                  tb23, tb24, tb25, tb26, tb27, tb28, tb29,
                                                  tb30, tb31, tb32, cb2};

            List<string> ListData = new List<string>() { tb0.Text, tb1.Text, tb2.Text, tb3.Text,
                                                    tb4.Text, tb5.Text, tb6.Text, tb7.Text, tb8.Text,
                                                    tb9.Text, tb10.Text, tb11.Text, Convert.ToString(cb1.IsChecked),
                                                    tb12.Text, tb13.Text, tb14.Text, tb15.Text,
                                                    tb16.Text, tb17.Text, tb18.Text, tb19.Text,
                                                    tb20.Text, tb21.Text, tb22.Text, tb23.Text,
                                                    tb24.Text, tb25.Text, tb26.Text, tb27.Text,
                                                    tb28.Text, tb29.Text, tb30.Text, tb31.Text,
                                                    tb32.Text, Convert.ToString(cb2.IsChecked)};

            PC_Core.PC_Manag obj = new PC_Core.PC_Manag();
            if (!obj.InsertTableValues(ListData))
            {
                Error_InputFormat error_InputFormat = new Error_InputFormat();
                error_InputFormat.Show();
            }

            else
            {
                for (int i = 0; i < 35; i++) // Очищение формы от данных
                {
                    if (tbList[i] is TextBox)
                        (tbList[i] as TextBox).Clear();
                    else if (tbList[i] is CheckBox)
                        (tbList[i] as CheckBox).IsChecked = false;
                }
            }
        }
    }
}
