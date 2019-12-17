using ShilinWpf.Entities;
using ShilinWpf.Pages.AddEditW;
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
    /// Interaction logic for AddProjectP.xaml
    /// </summary>
    public partial class AddProjectP : Page
    {
        public AddProjectP()
        {
            InitializeComponent();
            var listSearch = AppData.Context.TypeService.ToList();
            listSearch.Insert(0, new TypeService
            {
                Name = Properties.Resources.AllText
            });
            CBFil.ItemsSource = listSearch;
            CBFil.SelectedIndex = 0;
            UpdateData();
        }

        public AddProjectP(Project project)
        {
            InitializeComponent();
            var listSearch = AppData.Context.TypeService.ToList();
            listSearch.Insert(0, new TypeService
            {
                Name = Properties.Resources.AllText
            });
            CBFil.ItemsSource = listSearch;
            CBFil.SelectedIndex = 0;
            UpdateData();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AppData.Context.Project.Remove((Project)DGClient.SelectedItem);
                AppData.Context.SaveChanges();
                UpdateData();
            }
            catch
            {

            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DGClient.SelectedItem != null)
            {
                AddProjectW add = new AddProjectW(DGClient.SelectedItem as Project);
                add.ShowDialog();
                UpdateData();
            }
            else
            {
                MessageBox.Show("Вы не выбрать кого редактировать");
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddProjectW add = new AddProjectW();
            add.ShowDialog();
            UpdateData();
        }

        private void CBFil_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            var ListServ = AppData.Context.Project.ToList();
            if (CBFil.SelectedIndex > 0)
            {
                ListServ = ListServ.Where(p => p.TypeService == (CBFil.SelectedItem as TypeService)).ToList();
            }
            if (TBSearch.Text != "")
            {
                ListServ = ListServ.Where(p => p.Client.Login.ToLower().Contains(TBSearch.Text.ToLower())|| p.Worker.FullName.ToLower().Contains(TBSearch.Text.ToLower())).ToList();
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

        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }
    }
}
