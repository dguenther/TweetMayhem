using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MayhemWpf.UserControls;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Net;
using TweetSharp;

namespace TweetMayhem
{

    /// <summary>
    /// Interaction logic for TweetConfig.xaml
    /// </summary>
    public partial class TweetConfig : WpfConfiguration
    {
        public string Status { get; private set; }
        public string Username { get; private set; }
        public string OAuthToken { get; private set; }
        public string AccessToken { get; private set; }

        private TwitterService service;
        private OAuthRequestToken requestToken;

        public TweetConfig(string status, string username, string oauthToken, string accessToken)
        {
            this.Status = status;
            this.Username = username;
            this.OAuthToken = oauthToken;
            this.AccessToken = accessToken;
            InitializeComponent();
        }

        public override void OnSave()
        {
            this.Status = MessageTextBox.Text;
        }

        public override void OnLoad()
        {
            MessageTextBox.Text = this.Status;
            if (this.Username != string.Empty && this.Username != null)
            {
                LoginButton.Visibility = System.Windows.Visibility.Hidden;
                LogoutButton.Visibility = System.Windows.Visibility.Visible;
                LoginTextBlock.Text = TweetMayhem.Properties.Resources.LoginConfirm + this.Username;
                CanSave = true;
            }
            else
            {
                CanSave = false;
            }
        }

        public override string Title
        {
            get
            {
                return TweetMayhem.Properties.Resources.Title;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            // Pass your credentials to the service
            this.service = new TwitterService(TweetMayhem.Properties.Resources.ConsumerKey, TweetMayhem.Properties.Resources.ConsumerSecret);

            // Step 1 - Retrieve an OAuth Request Token
            this.requestToken = this.service.GetRequestToken();

            // Step 2 - Redirect to the OAuth Authorization URL
            Uri uri = this.service.GetAuthorizationUri(requestToken);
            Process.Start(uri.ToString());
            LoginTextBlock.Visibility = System.Windows.Visibility.Hidden;
            LoginButton.Visibility = System.Windows.Visibility.Hidden;
            PinTextBlock.Visibility = System.Windows.Visibility.Visible;
            PinTextBox.Visibility = System.Windows.Visibility.Visible;
            PinButton.Visibility = System.Windows.Visibility.Visible;

        }

        private void PinButton_Click(object sender, RoutedEventArgs e)
        {
            
            // Step 3 - Exchange the Request Token for an Access Token
            string verifier = PinTextBox.Text; // <-- This is input into your application by your user

            try
            {
                OAuthAccessToken access = this.service.GetAccessToken(this.requestToken, verifier);

                // Step 4 - User authenticates using the Access Token
                this.AccessToken = access.Token;
                this.OAuthToken = access.TokenSecret;

                service.AuthenticateWith(access.Token, access.TokenSecret);
                this.Username = this.service.GetUserProfile().ScreenName;
                LoginTextBlock.Text = TweetMayhem.Properties.Resources.LoginConfirm + this.Username;
                LoginTextBlock.Visibility = System.Windows.Visibility.Visible;
                PinButton.Visibility = System.Windows.Visibility.Hidden;
                PinTextBlock.Visibility = System.Windows.Visibility.Hidden;
                PinTextBox.Visibility = System.Windows.Visibility.Hidden;
                PinButton.Visibility = System.Windows.Visibility.Hidden;
                LogoutButton.Visibility = System.Windows.Visibility.Visible;
                if (MessageTextBox.Text.Trim() != string.Empty)
                {
                    CanSave = true;
                }
                var output = "User (#" + this.service.GetUserProfile().Id
                    + "): " + this.Username
                    + "\nAccount credentials are verified.";
                MessageBox.Show(output);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            CanSave = false;
            this.Username = string.Empty;
            this.AccessToken = string.Empty;
            this.OAuthToken = string.Empty;
            LoginTextBlock.Text = TweetMayhem.Properties.Resources.LoginPrompt;
            LogoutButton.Visibility = System.Windows.Visibility.Hidden;
            LoginButton.Visibility = System.Windows.Visibility.Visible;
        }

        private void MessageTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.Username != null && this.Username != string.Empty && MessageTextBox.Text.Trim() != string.Empty)
            {
                CanSave = true;
            }
            else
            {
                CanSave = false;
            }
        }
        
    }


}
