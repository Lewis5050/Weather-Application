using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Windows.Threading;
using Weather_App_3._0.Weather;

namespace Weather_App_3._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WeatherAccessor weatherAccessorObj;
        private bool toggleAdvancedInformation;

        public MainWindow()
        {
            InitializeComponent();

            // Hides the additional information panel.
            AdvInformationPanel.Visibility = Visibility.Hidden;
            toggleAdvancedInformation = false;
            
            // Creates the 'View-Model' object, and sets the data binding.
            weatherAccessorObj = new WeatherAccessor();
            this.DataContext = weatherAccessorObj;

            // Sets the timer used for the update time on the UI.
            DispatcherTimer time = new DispatcherTimer();
            time.Tick += TimerTick;
            time.Start();

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                weatherAccessorObj.GetWeather(SearchBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void ShowAdvInfoButton_Click(object sender, RoutedEventArgs e)
        {
            if (toggleAdvancedInformation)
            {
                ForecastPanel.Visibility = Visibility.Visible;
                AdvInformationPanel.Visibility = Visibility.Collapsed;
                toggleAdvancedInformation = false;
            } 
            else
            {
                ForecastPanel.Visibility = Visibility.Collapsed;
                AdvInformationPanel.Visibility = Visibility.Visible;
                toggleAdvancedInformation = true;
            }
            
        }

        private void TimerTick(object sender, EventArgs e)
        {
            TimeLabel.Content = DateTime.Now.ToString("HH:mm");
            TimeSecondsLabel.Content = DateTime.Now.ToString("ss");
        }
        

        
    }
}

