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
    /// Логика взаимодействия для Error_NotFilledIn.xaml
    /// </summary>
    public partial class Error_NotFilledIn : Window
    {
        public Error_NotFilledIn()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
