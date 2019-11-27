using ShilinWpf.Entities;
using ShilinWpf.Pages;
using ShilinWpf.Pages.AddEdit;
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

namespace ShilinWpf.Pages.NavigateP
{
    /// <summary>
    /// Логика взаимодействия для ClientP.xaml
    /// </summary>
    public partial class ClientP : Page
    {
        public ClientP()
        {
            InitializeComponent();

            DGClient.AutoGenerateColumns = false;
            DGClient.ItemsSource = AppData.Context.Client.ToList();

            List<Client> listSearch = AppData.Context.Client.ToList();
            listSearch.Insert(0, new Client
            {
                Login = Properties.Resources.AllText
            });
            CBFil.ItemsSource = listSearch;
            CBFil.SelectedIndex = 0;
        }
      
        private void ClientUpdate()
        {
            var ListServ = AppData.Context.Client.ToList();
            if (CBFil.SelectedIndex > 0)
            {
                ListServ = ListServ.Where(p => p.Login == (CBFil.SelectedItem as Client).Login).ToList();
            }
            DGClient.ItemsSource = ListServ;
        }
            private void BtnAdd_Click(object sender, RoutedEventArgs e)
            {
            AddClientW add = new AddClientW();
            add.ShowDialog();
            ClientUpdate();
            }

            private void UpdateText()
            {
                var ListServ = AppData.Context.Client.ToList();
                if (TBSearch.Text != "")
                {
                    ListServ = ListServ.Where(p => p.Login.ToLower().Contains(TBSearch.Text.ToLower())).ToList();
                }
                if (ListServ.Count == 0)
                {
                DGClient.Visibility = Visibility.Hidden;
                }
                else
                {
                DGClient.ItemsSource = ListServ;
                DGClient.Visibility = Visibility.Visible;
                }

            }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AppData.Context.Client.Remove((Client)DGClient.SelectedItem);
                AppData.Context.SaveChanges();
                ClientUpdate();
            }
            catch
            {

            }
        }

        private void CBFil_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClientUpdate();
        }

        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateText();
        }

        private void DGClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
