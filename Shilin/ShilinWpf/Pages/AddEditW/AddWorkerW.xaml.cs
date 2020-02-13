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
using NorbitWpf.Entities;

namespace NorbitWpf.Pages.AddEditW
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

        public AddWorkerW(Worker worker)
        {
            InitializeComponent();
            _curw = worker;
            BTNAdd.Content = Properties.Resources.Edit;
        }

        private void BTNNo_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }


        private void BTNAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrWhiteSpace(NameWorkerTB.Text))
                error.AppendLine(Properties.Resources.ErrorWorker);
            if (string.IsNullOrWhiteSpace(SurnameWorkerTB.Text))
                error.AppendLine(Properties.Resources.ErrorSurname);
            if (!(CBFunction.SelectedItem is TypeService))
                error.AppendLine(Properties.Resources.ErrorFuncion);
            if (string.IsNullOrWhiteSpace(LoginWorkerTB.Text))
                error.AppendLine(Properties.Resources.ErrorLogin);
            if (string.IsNullOrWhiteSpace(PasswordWorkerTB.Text))
                error.AppendLine(Properties.Resources.ErrorPassword);
            if (!error.ToString().Equals(""))
            {
                System.Windows.MessageBox.Show(Properties.Resources.ErrorSomethingWrong + "\n\n" + error, Properties.Resources.CaptionError,
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                if (_curw == null)
                {
                    Worker worker = new Worker()
                    {
                        WorkerID = AppData.Context.Worker.Max(p => p.WorkerID) + 1,
                        Name = NameWorkerTB.Text,
                        Surname = SurnameWorkerTB.Text,
                        Function = CBFunction.SelectedItem as Function,
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
                    _curw.Function = CBFunction.SelectedItem as Function;
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
            var functions = AppData.Context.Function.ToList();
            var newFunction = new Function()
            {
                FunctionID = 0,
                Name = "Добавить новую профессию"
            };
            functions.Insert(0, newFunction);
            CBFunction.ItemsSource = functions;
            if (_curw != null)
            {
                NameWorkerTB.Text = _curw.Name;
                SurnameWorkerTB.Text = _curw.Surname;
                CBFunction.SelectedItem = _curw.Function;
                LoginWorkerTB.Text = _curw.Login ;
                PasswordWorkerTB.Text = _curw.Password ;
            }
        }

        private void CBFunction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex == 0)
            {
                if ((sender as ComboBox).Text == "")
                {
                    System.Windows.MessageBox.Show("Нельзя добавить профессию без названия.", Properties.Resources.CaptionError, MessageBoxButton.OK, MessageBoxImage.Error);
                    (sender as ComboBox).SelectedItem = null;
                    return;
                }
                if (AppData.Context.Function.Where(p => p.Name.ToLower() == CBFunction.Text.ToLower()).Count() > 0)
                {
                    System.Windows.MessageBox.Show("Такая профессия уже есть.", Properties.Resources.CaptionError, MessageBoxButton.OK, MessageBoxImage.Error);
                    (sender as ComboBox).SelectedItem = AppData.Context.Function.FirstOrDefault(p => p.Name.ToLower() == CBFunction.Text.ToLower());
                    return;
                }
                var function = new Function()
                {
                    FunctionID = AppData.Context.Function.Max(p => p.FunctionID) + 1,
                    Name = (sender as ComboBox).Text
                };
                AppData.Context.Function.Add(function);
                AppData.Context.SaveChanges();
                var functions = AppData.Context.Function.ToList(); 
                var newFunction = new Function()
                {
                    FunctionID = 0,
                    Name = "Добавить новую профессию"
                };
                functions.Insert(0, newFunction);
                (sender as ComboBox).ItemsSource = functions;
                (sender as ComboBox).SelectedItem = function;
            }
        }
    }
}
