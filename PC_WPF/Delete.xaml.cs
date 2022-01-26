using System.Windows;

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

            a.DeleteTableValues(tb.Text);
            tb.Clear();

            a.CloseConnection();
        }
    }
}
