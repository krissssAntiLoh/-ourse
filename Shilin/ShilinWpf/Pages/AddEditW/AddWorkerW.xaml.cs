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

namespace ShilinWpf.Pages.AddEditW
{
    /// <summary>
    /// Логика взаимодействия для AddWorkerW.xaml
    /// </summary>
    public partial class AddWorkerW : Window
    {
        Worker _curw = null;
        public AddWorkerW()
        {
            InitializeComponent();
            BTNAdd.Content = Properties.Resources.Add;
        }

        public AddWorkerW(Worker client)
        {
            InitializeComponent();
            _curw = client;
            BTNAdd.Content = Properties.Resources.Edit;
        }

        private void BTNNo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void BTNAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_curw == null)
                {
                    Worker worker = new Worker()
                    {
                        WorkerID = AppData.Context.Worker.Max(p => p.WorkerID) + 1,
                        Name = NameWorkerTB.Text,
                        Surname = SurnameWorkerTB.Text,
                        Function = FunctionWorkerTB.Text,
                        Login = LoginWorkerTB.Text,
                        Password = PasswordWorkerTB.Text,
                    };
                    AppData.Context.Worker.Add(worker);
                    System.Windows.MessageBox.Show(Properties.Resources.MessageSuccessfullAdd, Properties.Resources.CaptionSuccessfully,
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    _curw.Name = NameWorkerTB.Text;
                    _curw.Surname = SurnameWorkerTB.Text;
                    _curw.Function = FunctionWorkerTB.Text;
                    _curw.Login = LoginWorkerTB.Text;
                    _curw.Password = PasswordWorkerTB.Text;
                    System.Windows.MessageBox.Show(Properties.Resources.MessageSuccessfullEdit, Properties.Resources.CaptionSuccessfully,
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }
                AppData.Context.SaveChanges();
                DialogResult = true;
            }
            catch
            {

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_curw != null)
            {
                NameWorkerTB.Text = _curw.Name;
                SurnameWorkerTB.Text = _curw.Surname;
                FunctionWorkerTB.Text = _curw.Function ;
                LoginWorkerTB.Text = _curw.Login ;
                PasswordWorkerTB.Text = _curw.Password ;
            }
        }
    }
}
