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
    /// Interaction logic for AddProjectW.xaml
    /// </summary>
    public partial class AddProjectW : Window
    {
        Project _curp = null;

        public AddProjectW()
        {
            InitializeComponent();
            BTNAdd.Content = Properties.Resources.Add;
        }
        public AddProjectW(Project project)
        {
            InitializeComponent();
            _curp = project;
            BTNAdd.Content = Properties.Resources.Edit;
        }

        private void BTNAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (!(IDClients.SelectedItem is Client))
                error.AppendLine(Properties.Resources.ErrorClient);
            if (!(IDWorker.SelectedItem is Worker))
                error.AppendLine(Properties.Resources.ErrorWorker);
            if (!(IDAssets.SelectedItem is Assets))
                error.AppendLine(Properties.Resources.ErrorAssets);
            if (!(IDTypeService.SelectedItem is TypeService))
                error.AppendLine(Properties.Resources.ErrorEmail);
            if (DTPDateAdd.SelectedDate == null)
                error.AppendLine(Properties.Resources.ErrorDateAdd);
            else 
            {
                if (DTPDateEnd.SelectedDate != null)
                    if (DTPDateAdd.SelectedDate>DTPDateEnd.SelectedDate)
                        error.AppendLine(Properties.Resources.ErrorDate);
            }
            if (!error.ToString().Equals(""))
            {
                System.Windows.MessageBox.Show(Properties.Resources.ErrorSomethingWrong + "\n\n" + error, Properties.Resources.CaptionError,
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            try
            {
                if (_curp == null)
                {
                    Project project = new Project()
                    {
                        ProjectID = AppData.Context.Project.Max(p => p.ProjectID) + 1,
                        Client = IDClients.SelectedItem as Client,
                        Worker = IDWorker.SelectedItem as Worker,
                        Assets = IDAssets.SelectedItem as Assets,
                        TypeService = IDTypeService.SelectedItem as TypeService,
                        DateAdd = DTPDateAdd.SelectedDate.Value,
                        DateEnd = DTPDateEnd.SelectedDate.Value,
                        Description = TBDescription.Text
                    };
                    AppData.Context.Project.Add(project);
                    System.Windows.MessageBox.Show(Properties.Resources.MessageSuccessfullAdd, Properties.Resources.CaptionSuccessfully,
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    _curp.Client = IDClients.SelectedItem as Client;
                    _curp.Worker = IDWorker.SelectedItem as Worker;
                    _curp.Assets = IDAssets.SelectedItem as Assets;
                    _curp.TypeService = IDTypeService.SelectedItem as TypeService;
                    _curp.DateAdd = DTPDateAdd.SelectedDate.Value;
                    _curp.DateEnd = DTPDateEnd.SelectedDate.Value;
                    _curp.Description = TBDescription.Text;
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
            IDClients.ItemsSource = AppData.Context.Client.ToList();
            IDWorker.ItemsSource = AppData.Context.Worker.ToList();
            IDAssets.ItemsSource = AppData.Context.Assets.ToList();
            IDTypeService.ItemsSource = AppData.Context.TypeService.ToList();

            if (_curp != null)
            {
                IDClients.SelectedItem = _curp.Client;
                IDWorker.SelectedItem = _curp.Worker;
                IDAssets.SelectedItem = _curp.Assets;
                IDTypeService.SelectedItem = _curp.TypeService;
                DTPDateAdd.SelectedDate = _curp.DateAdd;
                DTPDateEnd.SelectedDate = _curp.DateEnd;
                TBDescription.Text = _curp.Description;
            }
        }

        private void BTNNo_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
