using System.Windows;

namespace PC_WPF
{
    public partial class Delete : Window // Удаление конфигурации
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PC_Core.PC_Manag obj = new PC_Core.PC_Manag();
            if (!obj.DeleteTableValues(tb.Text)) // Возращает наличие данной конфигурации
            {
                Error_NotConfig error_NotConfig = new Error_NotConfig();
                error_NotConfig.Show();
            }

            tb.Clear();
        }
    }
}
