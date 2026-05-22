using DAL; // Links to your DAL project
using System;
using System.Windows;

namespace MyTeacherMashov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BaseDal dal;

        public MainWindow()
        {
            InitializeComponent();
            dal = new BaseDal();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string userId = txtUsername.Text.Trim();
            string password = pwPassword.Password;

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both User ID and Password.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Note: Modified table name to 'Teachers' based on your Teacher class
                string sql = $"SELECT COUNT(*) FROM Teachers WHERE PersonalID = '{userId}' AND Password = '{password}'";

                bool isUserExists = dal.ExecuteSelectBoolQuery(sql);

                if (isUserExists)
                {
                    MessageBox.Show("Login successful! Welcome.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    // MainDashboard dashboard = new MainDashboard();
                    // dashboard.Show();
                    // this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid User ID or Password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message, "System Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtUsername_GotFocus(object sender, RoutedEventArgs e)
        {
        }

        private void txtUsername_LostFocus(object sender, RoutedEventArgs e)
        {
        }
    }
}