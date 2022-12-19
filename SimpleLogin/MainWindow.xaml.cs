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
using SimpleLogin.Models;
using SimpleLogin.Repositories;


namespace SimpleLogin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        User possibleUser = new();
        public MainWindow()
        {
            InitializeComponent();
            PossibleUserGrid.DataContext = possibleUser;
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            UserRepository saverRepository = new UserRepository();

            List<User> users = saverRepository.findUser(possibleUser.Email, possibleUser.Password);
            if (users.Count > 0)
            {
                User saver = users[0];
                MessageBox.Show("Usuário autenticado!");
            }
            else
            {
                MessageBox.Show("Credenciais Inválidas!");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
