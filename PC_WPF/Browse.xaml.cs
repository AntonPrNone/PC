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
            List<Object> tbList = new List<Object>() {tb0, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8,
                                                      tb9, tb10, tb11, cb1, tb12, tb13, tb14, tb15,
                                                      tb16 , tb17, tb18, tb19, tb20, tb21, tb22,
                                                      tb23, tb24, tb25, tb26, tb27, tb28, tb29,
                                                      tb30, tb31, tb32, cb2};

            PC_Core.PC_Manag a = new PC_Core.PC_Manag();
            if (tb0.Text != "")
            {
                a = new PC_Core.PC_Manag();
                a.OpenConnection(@"Data Source=DESKTOP-L9II8RV;Initial Catalog=PC_repository;Integrated Security=True;trust server certificate=True");
                var configList = a.ReturnTableValues(tb0.Text);
                a.CloseConnection();

                for (int i = 0; i < 35; i++)
                {
                    if (tbList[i] is TextBox)
                        (tbList[i] as TextBox).Text = configList[i];
                    else if (tbList[i] is CheckBox)
                        try
                        {
                            (tbList[i] as CheckBox).IsChecked = Convert.ToBoolean(configList[i]);
                        }

                        catch
                        {
                            (tbList[i] as CheckBox).IsChecked = false;
                        }
                }

                label1.Content = "Название сборки";
            }

            else
            {
                label1.Content = "Не найдено";
            }
            
        }
    }
}
