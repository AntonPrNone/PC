﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PC_WPF
{
    public partial class Browse : Window // Просмотр конфигурации
    {
        public Browse()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Массив объектов с данными
            List<object> tbList = new List<Object>() {tb0, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8,
                                                      tb9, tb10, tb11, cb1, tb12, tb13, tb14, tb15,
                                                      tb16 , tb17, tb18, tb19, tb20, tb21, tb22,
                                                      tb23, tb24, tb25, tb26, tb27, tb28, tb29,
                                                      tb30, tb31, tb32, cb2};

            PC_Core.PC_Manag obj = new PC_Core.PC_Manag();
            List<string> configList = obj.ReturnTableValues(tb0.Text);

            if (configList.Count > 0) // Проверка на существовании конфигурации
            {
                for (int i = 0; i < 35; i++)
                {
                    if (tbList[i] is TextBox)
                    {
                        (tbList[i] as TextBox).Text = configList[i]; // Заполнение ТекстБоксов
                    }

                    if (tbList[i] is CheckBox)
                    {
                        try
                        {
                            (tbList[i] as CheckBox).IsChecked = Convert.ToBoolean(configList[i]); // Заполнение ЧекБоксов
                        }

                        catch
                        {
                            (tbList[i] as CheckBox).IsChecked = false;
                        }
                    }
                }
            }

            else // Окно-сообщение о не существовании данной конфигурации
            {
                Error_NotConfig error_NotConfig = new Error_NotConfig();
                error_NotConfig.Show();
            }
        }
    }
}
