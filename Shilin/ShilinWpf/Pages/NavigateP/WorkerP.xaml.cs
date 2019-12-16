using ShilinWpf.Entities;
using ShilinWpf.Pages;
using ShilinWpf.Pages.AddEdit;
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
    /// Логика взаимодействия для WorkerP.xaml
    /// </summary>
    public partial class WorkerP : Page
    {
        public WorkerP()
        {
            InitializeComponent();

            DGClient.AutoGenerateColumns = false;
            DGClient.ItemsSource = AppData.Context.Worker.ToList();

            List<Worker> listSearch = AppData.Context.Worker.ToList();
            listSearch.Insert(0, new Worker
            {
                Login = Properties.Resources.AllText
            });
            CBFil.ItemsSource = listSearch;
            CBFil.SelectedIndex = 0;
        }

        private void WorkerUpdate()
        {
            var ListServ = AppData.Context.Worker.ToList();
            if (CBFil.SelectedIndex > 0)
            {
                ListServ = ListServ.Where(p => p.Login == (CBFil.SelectedItem as Worker).Login).ToList();
            }
            DGClient.ItemsSource = ListServ;
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddWorkerW add = new AddWorkerW();
            add.ShowDialog();
            WorkerUpdate();
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
                AppData.Context.Worker.Remove((Worker)DGClient.SelectedItem);
                AppData.Context.SaveChanges();
                WorkerUpdate();
            }
            catch
            {

            }
        }

        private void CBFil_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WorkerUpdate();
        }

        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateText();
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
                WorkerUpdate();
            }
            else
            {
                MessageBox.Show("Вы не выбрать кого редактировать");
            }
        }
    }
}
