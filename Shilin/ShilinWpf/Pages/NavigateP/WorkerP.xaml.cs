using NorbitWpf.Entities;
using NorbitWpf.Pages;
using NorbitWpf.Pages.AddEdit;
using NorbitWpf.Pages.AddEditW;
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

namespace NorbitWpf.Pages.NavigateP
{
    /// <summary>
    /// Логика взаимодействия для WorkerP.xaml
    /// </summary>
    public partial class WorkerP : Page
    {
        public WorkerP()
        {
            InitializeComponent();


            var listSearch = AppData.Context.Function.ToList();
            listSearch.Insert(0, new Function
            {
                Name = Properties.Resources.AllText
            });
            CBFil.ItemsSource = listSearch;
            CBFil.SelectedIndex = 0;
            UpdateData();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddWorkerW add = new AddWorkerW();
            add.ShowDialog();
            UpdateData();
        }

        private void UpdateData()
        {
            var ListServ = AppData.Context.Worker.ToList();
            if (CBFil.SelectedIndex > 0)
            {
                ListServ = ListServ.Where(p => p.Function == (CBFil.SelectedItem as Function)).ToList();
            }
            if (TBSearch.Text != "")
            {
                ListServ = ListServ.Where(p => p.FullName.Contains(TBSearch.Text.ToLower())).ToList();
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
                AppData.Context.Worker.Remove((Worker)DGClient.SelectedItem);
                AppData.Context.SaveChanges();
                UpdateData();
            }
            catch
            {

            }
        }

        private void CBFil_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }

        private void DGClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DGClient.SelectedItem != null)
            {
                AddWorkerW add = new AddWorkerW(DGClient.SelectedItem as Worker);
                add.ShowDialog();
                UpdateData();
            }
            else
            {
                MessageBox.Show("Вы не выбрать кого редактировать");
            }
        }
    }
}
