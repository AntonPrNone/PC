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
    /// Логика взаимодействия для Delete.xaml
    /// </summary>
    public partial class Delete : Window
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PC_Core.PC_Manag a = new PC_Core.PC_Manag();
            a.OpenConnection(@"Data Source=DESKTOP-L9II8RV;Initial Catalog=PC_repository;Integrated Security=True;trust server certificate=True");
            try
            {
                a.DeleteTableValues(tb.Text);

                label1.Content = "Удачно!";
            }

            catch
            {
                label1.Content = "Неудача";
            }

            finally
            {
                tb.Text = "";
            }

            a.CloseConnection();
        }
    }
}
