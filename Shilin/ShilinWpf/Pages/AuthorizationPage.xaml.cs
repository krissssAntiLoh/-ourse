using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace ShilinWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public List<Entities.Client> clients;  
        private string _capchaText = "";
        public AuthorizationPage()
        {
            InitializeComponent();
            ImgCapcha.Source = Drawing(Convert.ToInt32(ImgCapcha.Width), Convert.ToInt32(ImgCapcha.Height));
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            clients = AppData.Context.Client.ToList();

            bool islogined = false;

            
            //if (AppData.Context.Client.Where(client => client.Login == TBoxLogin.Text && client.Password == PBoxPassword.Password).)
            //{

            //}

            foreach (Entities.Client client in clients)
            {
                if (client.Login == TBoxLogin.Text && client.Password == PBoxPassword.Password)
                {
                    islogined = true;
                    if (TbxCapcha.Text == _capchaText)
                    {
                        AppData.MainFrame.Navigate(new Pages.Admin.AdminPage());
                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.MessageCapcha, Properties.Resources.CaptionError,
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            if (!islogined)
            {
                MessageBox.Show(Properties.Resources.MessageLoginFailed, Properties.Resources.CaptionError,
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
      
            ImgCapcha.Source = Drawing(Convert.ToInt32(ImgCapcha.Width), Convert.ToInt32(ImgCapcha.Height));
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            ImgCapcha.Source = Drawing(Convert.ToInt32(ImgCapcha.Width), Convert.ToInt32(ImgCapcha.Height));
        }

        private DrawingImage Drawing(int width,int height)
        {
            Random random = new Random();
            _capchaText = "";
            string allText = "1234567890QqWwEeRrTtYyUuIiOoPpAaSsDdFfGgHhJjKkLlZzXxCcVvBbNnMm";
            for (int i = 0; i < 6; i++)
            {
                _capchaText += allText[random.Next(allText.Length)];
            }
            byte[] bytes = new byte[width * height * 100];
            random.NextBytes(bytes);
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                drawingContext.DrawImage(BitmapSource.Create(width, height, 300, 300, PixelFormats.Rgb48, null, bytes, width*30),
                    new Rect(0,0,width,height));
                drawingContext.DrawText(new FormattedText(_capchaText, CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                    new Typeface("Arial"), (height / 4 + width / 4) / 2, Brushes.Black), new Point(width / 5, height / 4));
            }
            return new DrawingImage(drawingVisual.Drawing);
        }
    }
}
