using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Weather_App_3._0.Weather;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Weather_App_3._0.Weather
{
    class WeatherAccessor : INotifyPropertyChanged
    {
        /*The weather data is stored in the WeatherInformation class, due to the JSON format
         it contains nested classes in which the data from the API is written to, the Rootobject is 
         how you access the information within the other nested classes. */

        // Current Weather and Forecast information is deserialised to here:
        WeatherInformation.Rootobject weatherInfo;
        WeatherForecastInformation.Rootobject weatherForecastInfo;

        // Using INotifyPropertyChanged alerts the UI ('View') that there has been updates to the values.
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Constructor of the WeatherAccessor class, by default the consturctor calls the method GetWeather("London") so the UI has
        /// something to display when first launched.
        /// </summary>
        public WeatherAccessor()
        {
            // Gets the current weather and forecast. (Uses London as the default).
            GetWeather("London");
        }

        /// <summary>
        /// This method, takes the parameter and incorperates it into the URL to fetch the data from the API. The data is then 
        /// deserialised into the weatherInfo, and weatherForecastInfo objects, in which the properities in this WeatherAccessor class
        /// use to return the information to the UI, this method also makes a call to the PropertyChanged event which notifies the UI, and updates
        /// it of changes made to the weatherInfo and weatherForecastInfo objects.
        /// </summary>
        public void GetWeather(string city)
        {
            try
            {
                using (WebClient web = new WebClient())
                {
                    // Call the API to get the JSON data for the current weather:
                    string currentUrl = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&APPID=5f5df07b212acf43e9effdc87b182922", city);
                    string forecastUrl = string.Format("http://api.openweathermap.org/data/2.5/forecast?q={0}&APPID=5f5df07b212acf43e9effdc87b182922", city);

                    // Download the JSON data:
                    string Json = web.DownloadString(currentUrl);

                    // Deserialize the Json, and apply it to the Rootobject within the WeatherInformation class:
                    weatherInfo = JsonConvert.DeserializeObject<WeatherInformation.Rootobject>(Json);

                    // Download forecast JSON data:
                    Json = web.DownloadString(forecastUrl);

                    // Deserialize the JSON and apply it to the Rootobject within the WeatherForecastInformation class:
                    weatherForecastInfo = JsonConvert.DeserializeObject<WeatherForecastInformation.Rootobject>(Json);

                    OnPropertyChanged("City");
                    OnPropertyChanged("Days");
                    OnPropertyChanged("Temperature");
                    OnPropertyChanged("WindSpeed");
                    OnPropertyChanged("WindDirection");
                    OnPropertyChanged("AirPressure");
                    OnPropertyChanged("Humidity");
                    OnPropertyChanged("MainWeatherImage");
                    OnPropertyChanged("ForecastTemperatures");
                    OnPropertyChanged("ForecastDayOneImage");
                    OnPropertyChanged("ForecastDayTwoImage");
                    OnPropertyChanged("ForecastDayThreeImage");
                    OnPropertyChanged("ForecastDayFourImage");
                    OnPropertyChanged("ForecastDayFiveImage");
                    OnPropertyChanged("WindSpeedImage");
                    OnPropertyChanged("WindDirectionImage");
                    OnPropertyChanged("AirPressureImage");
                    OnPropertyChanged("HumidityImage");
                }
            }
            catch (Exception ex)
            {
                // Exception most likely to be thrown if there's a problem connecting to the API.
                MessageBox.Show(ex.Message);
            }
        }

        // Gets the location from the 'Model' (WeatherInformation.cs)
        public string City
        {
            get { return weatherInfo.name; }
        }

        // Gets the temperature from the 'Model'
        public int Temperature
        {
            // -273 is because the API returns the temperature in Kevlin (conversion)
            get { return (int)weatherInfo.main.temp - 273; }
        }

        // Gets the wind speed from the 'Model'
        public string WindSpeed
        {
            // Returns in m/s so timesed by 2.237 to get mph
            get { return ((int)weatherInfo.wind.speed * 2.237).ToString() + "mph"; }
        }

        // Gets the wind direction from the 'Model'
        public string WindDirection
        {
            get { return weatherInfo.wind.deg.ToString() + "°"; }
        }

        // Gets the air pressure from the 'Model'
        public string AirPressure
        {
            get { return weatherInfo.main.pressure.ToString() + " hPa"; }
        }

        // Gets the humidity from the 'Model'
        public string Humidity
        {
            get { return weatherInfo.main.humidity.ToString() + "%"; }
        }

        // Returns an array of strings used in the UI ('Model') for labels for showing days.
        public string[] Days
        {
            get
            {
                string[] daysOfWeek = new string[6];

                daysOfWeek[0] = GetDay((int)DateTime.Now.DayOfWeek);
                daysOfWeek[1] = GetDay((int)DateTime.Now.DayOfWeek + 1);
                daysOfWeek[2] = GetDay((int)DateTime.Now.DayOfWeek + 2);
                daysOfWeek[3] = GetDay((int)DateTime.Now.DayOfWeek + 3);
                daysOfWeek[4] = GetDay((int)DateTime.Now.DayOfWeek + 4);
                daysOfWeek[5] = GetDay((int)DateTime.Now.DayOfWeek + 5);

                return daysOfWeek;
            }
        }

        // Returns an array of temperatures from one of the 'Models'
        public string[] ForecastTemperatures
        {
            get
            {
                string[] forecastTemperatures = new string[5];
                forecastTemperatures[0] = ((int)weatherForecastInfo.list[8].main.temp - 273).ToString() + "°C";
                forecastTemperatures[1] = ((int)weatherForecastInfo.list[15].main.temp - 273).ToString() + "°C";
                forecastTemperatures[2] = ((int)weatherForecastInfo.list[23].main.temp - 273).ToString() + "°C";
                forecastTemperatures[3] = ((int)weatherForecastInfo.list[31].main.temp - 273).ToString() + "°C";
                forecastTemperatures[4] = ((int)weatherForecastInfo.list[39].main.temp - 273).ToString() + "°C";

                return forecastTemperatures;
            }
        }

        // Returns the file path for the wind speed image.
        public string WindSpeedImage
        {
            get { return "Resources/Wind.png"; }
        }

        // Returns the file path for the wind direction image.
        public string WindDirectionImage
        {
            get { return "Resources/Navigation.png"; }
        }

        // Returns the file path for the air pressure image.
        public string AirPressureImage
        {
            get { return "Resources/AirPressure.png"; }
        }

        // Returns the file path for the humidity image.
        public string HumidityImage
        {
            get { return "Resources/Humidity.png"; }
        }

        // Returns the file path for the current weather image based on certain information from the 'Model'
        // Below Image string properties do the same.
        public string MainWeatherImage
        {
            get
            {
                if (weatherInfo.weather[0].main == "Rain" || weatherInfo.weather[0].main == "Drizzle" || weatherInfo.weather[0].main == "Thunderstorm")
                {
                    return "Resources/Rain.png";
                }
                else if (weatherInfo.weather[0].main == "Clear")
                {
                    return "Resources/Sun.png";
                }
                else if (weatherInfo.weather[0].main == "Clouds")
                {
                    return "Resources/Cloudy.jpg";
                }
                else if (weatherInfo.weather[0].main == "Snow")
                {
                    return "Resources/Snow.png";
                }
                else
                {
                    return "Resources/Scattered-Cloud.jpg";
                }
            }
        }

        public string ForecastDayOneImage
        {
            get
            {
                if (weatherForecastInfo.list[8].weather[0].main == "Rain" || weatherForecastInfo.list[8].weather[0].main == "Drizzle" || weatherForecastInfo.list[8].weather[0].main == "Thunderstorm")
                {
                    return "Resources/Rain.png";
                }
                else if (weatherForecastInfo.list[8].weather[0].main == "Clear")
                {
                    return "Resources/Sun.png";
                }
                else if (weatherForecastInfo.list[8].weather[0].main == "Clouds")
                {
                    return "Resources/Cloudy.jpg";
                }
                else if (weatherForecastInfo.list[8].weather[0].main == "Snow")
                {
                    return "Resources/Snow.png";
                }
                else
                {
                    return "Resources/Scattered-Cloud.jpg";
                }
            }
        }
        public string ForecastDayTwoImage
        {
            get
            {
                if (weatherForecastInfo.list[15].weather[0].main == "Rain" || weatherForecastInfo.list[15].weather[0].main == "Drizzle" || weatherForecastInfo.list[15].weather[0].main == "Thunderstorm")
                {
                    return "Resources/Rain.png";
                }
                else if (weatherForecastInfo.list[15].weather[0].main == "Clear")
                {
                    return "Resources/Sun.png";
                }
                else if (weatherForecastInfo.list[15].weather[0].main == "Clouds")
                {
                    return "Resources/Cloudy.jpg";
                }
                else if (weatherForecastInfo.list[15].weather[0].main == "Snow")
                {
                    return "Resources/Snow.png";
                }
                else
                {
                    return "Resources/Scattered-Cloud.jpg";
                }
            }
        }
        public string ForecastDayThreeImage
        {
            get
            {
                if (weatherForecastInfo.list[23].weather[0].main == "Rain" || weatherForecastInfo.list[23].weather[0].main == "Drizzle" || weatherForecastInfo.list[23].weather[0].main == "Thunderstorm")
                {
                    return "Resources/Rain.png";
                }
                else if (weatherForecastInfo.list[23].weather[0].main == "Clear")
                {
                    return "Resources/Sun.png";
                }
                else if (weatherForecastInfo.list[23].weather[0].main == "Clouds")
                {
                    return "Resources/Cloudy.jpg";
                }
                else if (weatherForecastInfo.list[23].weather[0].main == "Snow")
                {
                    return "Resources/Snow.png";
                }
                else
                {
                    return "Resources/Scattered-Cloud.jpg";
                }
            }
        }
        public string ForecastDayFourImage
        {
            get
            {
                if (weatherForecastInfo.list[31].weather[0].main == "Rain" || weatherForecastInfo.list[31].weather[0].main == "Drizzle" || weatherForecastInfo.list[31].weather[0].main == "Thunderstorm")
                {
                    return "Resources/Rain.png";
                }
                else if (weatherForecastInfo.list[31].weather[0].main == "Clear")
                {
                    return "Resources/Sun.png";
                }
                else if (weatherForecastInfo.list[31].weather[0].main == "Clouds")
                {
                    return "Resources/Cloudy.jpg";
                }
                else if (weatherForecastInfo.list[31].weather[0].main == "Snow")
                {
                    return "Resources/Snow.png";
                }
                else
                {
                    return "Resources/Scattered-Cloud.jpg";
                }
            }
        }
        public string ForecastDayFiveImage
        {
            get
            {
                if (weatherForecastInfo.list[39].weather[0].main == "Rain" || weatherForecastInfo.list[39].weather[0].main == "Drizzle" || weatherForecastInfo.list[39].weather[0].main == "Thunderstorm")
                {
                    return "Resources/Rain.png";
                }
                else if (weatherForecastInfo.list[39].weather[0].main == "Clear")
                {
                    return "Resources/Sun.png";
                }
                else if (weatherForecastInfo.list[39].weather[0].main == "Clouds")
                {
                    return "Resources/Cloudy.jpg";
                }
                else if (weatherForecastInfo.list[39].weather[0].main == "Snow")
                {
                    return "Resources/Snow.png";
                }
                else
                {
                    return "Resources/Scattered-Cloud.jpg";
                }
            }
        }

        /// <summary>
        /// This uses the numeric value of DateTime.Now.DayOfWeek to return the day of the week.
        /// </summary>
        private string GetDay(int i)
        {
            if (i > 7)
            {
                i -= 7;
            }
            switch (i)
            {
                case 1:
                    return "Mon";
                case 2:
                    return "Tue";
                case 3:
                    return "Wed";
                case 4:
                    return "Thu";
                case 5:
                    return "Fri";
                case 6:
                    return "Sat";
                case 7:
                    return "Sun";
                default:
                    return "N/A";
            }
        }

        /// This method is part of INotifyPropertyChanged to notify the UI that the 'Models' have been updated/changed.
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
