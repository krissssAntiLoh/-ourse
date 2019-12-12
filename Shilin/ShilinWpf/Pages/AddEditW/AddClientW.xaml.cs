﻿using System;
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
        Client _curc = null;
        public AddClientW()
        {
            InitializeComponent();
            BTNAdd.Content = Properties.Resources.Add;
        }
        public AddClientW(Client client)
        {
            InitializeComponent();
            _curc = client;
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
                if (_curc == null)
                {
                    Client client = new Client()
                    {
                        ClientID = AppData.Context.Client.Max(p => p.ClientID) + 1,
                        Login = LoginClientTB.Text,
                        Password = PasswordClientTB.Text,
                        Phone = PhoneClientTB.Text,
                        Email = EmailClientTB.Text,
                    };
                    AppData.Context.Client.Add(client);
                    System.Windows.MessageBox.Show(Properties.Resources.MessageSuccessfullAdd, Properties.Resources.CaptionSuccessfully,
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    _curc.Login = LoginClientTB.Text;
                    _curc.Password = PasswordClientTB.Text;
                    _curc.Phone = PhoneClientTB.Text;
                    _curc.Email = EmailClientTB.Text;
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
            if (_curc != null)
            {
                LoginClientTB.Text = _curc.Login;
                PasswordClientTB.Text = _curc.Password;
                PhoneClientTB.Text = _curc.Phone;
                EmailClientTB.Text = _curc.Email;
            }
        }
    }
}
