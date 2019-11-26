using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ShilinWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            if (Properties.Settings.Default.CurrentCulture == "")
            {
                Properties.Settings.Default.CurrentCulture =Thread.CurrentThread.CurrentUICulture.Name;
                Properties.Settings.Default.Save();
            }

            Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.CurrentCulture);

            InitializeComponent();

            if (Properties.Settings.Default.CurrentCulture == "ru-Ru")
            {
                CbxLanguage.SelectedIndex = 0;
            }
            else
            {
                CbxLanguage.SelectedIndex = 1;
            }
            AppData.MainFrame = MainFrame;
            AppData.MainFrame.Navigate(new Pages.AuthorizationPage());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (AppData.MainFrame.CanGoBack)
            AppData.MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            var page = MainFrame.Content as Page;
            if (page.Title == "Authorization")
            {
                BtnBack.Visibility = Visibility.Collapsed;
            }
            else 
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            Title = BlockHeader.Text = page.Title;
          
        }

        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {
            if (CbxLanguage.SelectedIndex == 0)
            {
                Properties.Settings.Default.CurrentCulture = "ru-Ru";
            }
            else
            {
                Properties.Settings.Default.CurrentCulture = "en-Us";
            }
            Properties.Settings.Default.Save();

            if (MessageBox.Show(Properties.Resources.MessageConfirmation,Properties.Resources.CaptionQuestion,
                MessageBoxButton.YesNo,MessageBoxImage.Question)==MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
                Process.Start(App.ResourceAssembly.Location);
            }
        }
    }
}
