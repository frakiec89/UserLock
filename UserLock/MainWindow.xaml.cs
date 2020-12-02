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

namespace UserLock
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// обработчик  входа 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btIn_Click(object sender, RoutedEventArgs e)
        {
            UserController controller = new UserController(); // вытащит  всех юзеров  из файла

            for (int  i = 0; i< controller.Users.Count; i++)
            {
                string log = controller.Users[i].Login;
                string pass = controller.Users[i].Password;

                if (  log ==  tbLogin.Text &&  pass == tbPassword.Text)
                {
                    MessageBox.Show("Привет " + controller.Users[i].Name);
                    return;
                }
            }
            MessageBox.Show("пользователь не найден");
        }

        /// <summary>
        /// Открывает  окно регистрации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btReg_Click(object sender, RoutedEventArgs e)
        {
            RegistrUserWindow window = new RegistrUserWindow();
            window.ShowDialog();
        }
    }
}
