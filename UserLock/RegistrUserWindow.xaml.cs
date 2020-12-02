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
using System.Windows.Shapes;

namespace UserLock
{
    /// <summary>
    /// Логика взаимодействия для RegistrUserWindow.xaml
    /// </summary>
    public partial class RegistrUserWindow : Window
    {
        public RegistrUserWindow()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if (tbPassword.Text != tbPasswordDouble.Text)//проверка на разные паролли
            {
                MessageBox.Show("пароли разные");
                return;
            }

            UserController controller = new UserController();
            User newUser = new User();
            newUser.Login = tbLogin.Text;
            newUser.Password = tbPassword.Text;
            newUser.Name = tbName.Text;
            controller.AddUser(newUser);

            MessageBox.Show("пользователь добавлен");
            this.Close();
        }
    }
}
