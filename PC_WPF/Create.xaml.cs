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
    public partial class Create : Window
    {
        public Create()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                List<Object> tbList = new List<Object>() {tb0, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8,
                                                      tb9, tb10, tb11, cb1, tb12, tb13, tb14, tb15,
                                                      tb16 , tb17, tb18, tb19, tb20, tb21, tb22,
                                                      tb23, tb24, tb25, tb26, tb27, tb28, tb29,
                                                      tb30, tb31, tb32, cb2};

                PC_Core.PC_Manag a = new PC_Core.PC_Manag();
                a.OpenConnection(@"Data Source=DESKTOP-L9II8RV;Initial Catalog=PC_repository;Integrated Security=True;trust server certificate=True");

                try
                {
                    string testX;
                    testX = tb0.Text; testX = tb1.Text; Convert.ToInt32(tb2.Text); Convert.ToInt32(tb3.Text); Convert.ToInt32(tb4.Text); Convert.ToInt32(tb5.Text);
                    testX = tb6.Text; Convert.ToInt32(tb7.Text); Convert.ToInt32(tb8.Text); testX = tb9.Text; Convert.ToInt32(tb10.Text); Convert.ToInt32(tb11.Text); testX = tb12.Text;
                    Convert.ToInt32(tb13.Text); Convert.ToInt32(tb14.Text); Convert.ToBoolean(cb1.IsChecked); testX = tb15.Text; Convert.ToInt32(tb16.Text);
                    Convert.ToInt32(tb17.Text); Convert.ToInt32(tb18.Text); testX = tb19.Text; Convert.ToInt32(tb20.Text); Convert.ToInt32(tb21.Text); Convert.ToInt32(tb22.Text);
                    testX = tb23.Text; Convert.ToInt32(tb24.Text); Convert.ToInt32(tb25.Text); testX = tb26.Text; Convert.ToInt32(tb27.Text); Convert.ToInt32(tb28.Text);
                    Convert.ToInt32(tb29.Text); Convert.ToInt32(tb30.Text); testX = tb31.Text; Convert.ToInt32(tb32.Text); Convert.ToBoolean(cb2.IsChecked);
                }

                catch
                {
                    Error_InputFormat error_InputFormat = new Error_InputFormat();
                    error_InputFormat.Show();
                }

                a.InsertTableValues(tb0.Text, tb1.Text, Convert.ToInt32(tb2.Text), Convert.ToInt32(tb3.Text), Convert.ToInt32(tb4.Text), Convert.ToInt32(tb5.Text),
                    tb6.Text, Convert.ToInt32(tb7.Text), Convert.ToInt32(tb8.Text), tb9.Text, Convert.ToInt32(tb10.Text), Convert.ToInt32(tb11.Text), tb12.Text,
                    Convert.ToInt32(tb13.Text), Convert.ToInt32(tb14.Text), Convert.ToBoolean(cb1.IsChecked), tb15.Text, Convert.ToInt32(tb16.Text),
                    Convert.ToInt32(tb17.Text), Convert.ToInt32(tb18.Text), tb19.Text, Convert.ToInt32(tb20.Text), Convert.ToInt32(tb21.Text), Convert.ToInt32(tb22.Text),
                    tb23.Text, Convert.ToInt32(tb24.Text), Convert.ToInt32(tb25.Text), tb26.Text, Convert.ToInt32(tb27.Text), Convert.ToInt32(tb28.Text),
                    Convert.ToInt32(tb29.Text), Convert.ToInt32(tb30.Text), tb31.Text, Convert.ToInt32(tb32.Text), Convert.ToBoolean(cb2.IsChecked));

                a.CloseConnection();

                for (int i = 0; i < 35; i++)
                {
                    if (tbList[i] is TextBox)
                        (tbList[i] as TextBox).Clear();
                    else if (tbList[i] is CheckBox)
                        (tbList[i] as CheckBox).IsChecked = false;
                }
            }

            catch
            {
                Error_NotFilledIn error_NotFilledIn = new Error_NotFilledIn();
                error_NotFilledIn.Show();
            }
        }
    }
}
