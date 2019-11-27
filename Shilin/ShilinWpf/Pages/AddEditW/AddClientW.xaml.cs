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
using ShilinWpf.Entities;

namespace ShilinWpf.Pages.AddEdit
{
    /// <summary>
    /// Логика взаимодействия для AddClientW.xaml
    /// </summary>
    public partial class AddClientW : Window
    {
        public AddClientW()
        {
            InitializeComponent();
        }

        private void BTNNo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BTNAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var AddClient = new Client
                {
                    ClientID = Convert.ToInt32(IdClientTB.Text),
                    Login = LoginClientTB.Text,
                    Password = PasswordClientTB.Text,
                    Phone = PhoneClientTB.Text,
                    Email = EmailClientTB.Text,

                };
                AppData.Context.Client.Add(AddClient);
                AppData.Context.SaveChanges();
                Close();
                try
                {
                    MessageBox.Show("Запись добавлена");

                    IdClientTB.Clear();
                    LoginClientTB.Clear();
                    PasswordClientTB.Clear();
                    PhoneClientTB.Clear();
                    EmailClientTB.Clear();
                }
                catch
                {
                    MessageBox.Show("Введите данные клиента");
                }
            }
            catch
            {
                
            }
        }
    }
}
