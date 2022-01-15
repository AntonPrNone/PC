using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PC_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            Create create = new Create();
            create.Show();
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            Delete delete = new Delete();
            delete.Show();
        }

        private void btn_browse_Click(object sender, RoutedEventArgs e)
        {
            Browse browse = new Browse();
            browse.Show();
        }
    }
}
