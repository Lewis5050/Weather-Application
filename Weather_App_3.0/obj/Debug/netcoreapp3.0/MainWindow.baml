   M S B A M L   `   `   `  ����J  FWeather_App_3.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Weather_App_3._0Weather_App_3._0  5   	   !    Weather_App_3._0.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Weather_App_3._0     5   	     � Title$  Weather Application��5   	   $	��530��6%   $	��900��62    � 
ResizeMode$ NoResize=�6>   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��600 �6   6-   �� 5      $	��300 �6   6-   �� 5      $��0 �6   .+�5   
   �� $��0��6   $��2��6%   $��	0,0,227,0q�69   .+�5      �  5      �� 5      $
��288* �6'   66   �� 5      $
��385* �6'   66   .+�5      �� -   5         ��Name$ currentDateLabel��5      $��Sun 29 June��62   $��	60,30,0,0q�6H   $��Nirmala UI Semilight)�6[   $��22(�6}   
�������$��0��6�   �� 5       �� Orientation$ 
Horizontal=�6   $��1��66   .+�5      �� -   5         ��Name$ 	SearchBox��5      $��0 35 0 0q�61   $
��18px��6C   $��150px��6Q   $��1��6_   $
��Left=�6o   �� 5!      -   5         ��Name$ SearchButton��5!      $��	10 35 0 0q�63   $��20��6F   $��80��6R   $��Search��6]   $��Nirmala UI Semilight)�6n   $��11(�6�   ���	#FFF3C32A
���������6�   Z� 6�   �� 5"      -   5        $ ShowAdvInfoButton��5"      $
��Left=�68   $��5 35 0 0q�6S   $��20��6e   $��22��6q   $	��⮟��6|   $��Nirmala UI Semilight)�6�   $��11(�6�   ���	#FFF3C32A
���������6�   Z� 6�   5#      5%      �� 5(      -   5        $ locationLabel��5(      $��	60,10,0,0q�6j   $��Nirmala UI Semilight)�6}   $��48(�6�   ���	#FFEEBA2A��6,   �� *City+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5+      $ 
Horizontal=�6   .+�5.      �� -   5        $ currentTemperatureLabel��5.      $��	70,30,0,0q�6~   $��Nirmala UI Semilight)�6�   $��64(�6�   ���	#FFEEBA2A��69   �� *Temperature+$ PropertyChanged=�6�   �� 5/      $	��°C��6   $��0,30,0,0q�6%   $��Nirmala UI Semilight)�67   $��64(�6Y   ���	#FFEEBA2A6g   �� 53      $��	60,20,0,0q�6<   $	��112��6O   $	��112��6[   ��6   �� *MainWeatherImage+6[   55      �� 58      -   5         ��Name$ ForecastPanel��58      $ 
Horizontal=�60   .+�5;      �� $��	60,50,0,0q�6   .+�5<      �� $��Nirmala UI Semilight)�6]   $��14(�6   
�������$��Center=�6�   ��6   �� *	Days[1]+$ PropertyChanged=�6�   �� 5=      $��56��6h   $��56��6s   ��6   �� *ForecastDayOneImage+$ PropertyChanged=�6s   �� 5>      $��Nirmala UI Semilight)�6m   $��14(�6�   
�������$��Center=�6�   ��6   �� *ForecastTemperatures[0]+$ PropertyChanged=�6�   5?      �� 5B      $��	50,50,0,0q�6   .+�5C      �� $��Nirmala UI Semilight)�6]   $��14(�6   
�������$��Center=�6�   ��6   �� *	Days[2]+$ PropertyChanged=�6�   �� 5D      $��56��6h   $��56��6s   ��6   �� *ForecastDayOneImage+$ PropertyChanged=�6s   �� 5E      $��Nirmala UI Semilight)�6m   $��14(�6�   
�������$��Center=�6�   ��6   �� *ForecastTemperatures[1]+$ PropertyChanged=�6�   5F      �� 5I      $��	50,50,0,0q�6   .+�5J      �� $��Nirmala UI Semilight)�6]   $��14(�6   
�������$��Center=�6�   ��6   �� *	Days[3]+$ PropertyChanged=�6�   �� 5K      $��56��6h   $��56��6s   ��6   �� *ForecastDayOneImage+$ PropertyChanged=�6s   �� 5L      $��Nirmala UI Semilight)�6m   $��14(�6�   
�������$��Center=�6�   ��6   �� *ForecastTemperatures[2]+$ PropertyChanged=�6�   5M      �� 5P      $��	50,50,0,0q�6   .+�5Q      �� $��Nirmala UI Semilight)�6]   $��14(�6   
�������$��Center=�6�   ��6   �� *	Days[4]+$ PropertyChanged=�6�   �� 5R      $��56��6h   $��56��6s   ��6   �� *ForecastDayOneImage+$ PropertyChanged=�6s   �� 5S      $��Nirmala UI Semilight)�6m   $��14(�6�   
�������$��Center=�6�   ��6   �� *ForecastTemperatures[3]+$ PropertyChanged=�6�   5T      �� 5W      $��	50,50,0,0q�6   .+�5X      �� $��Nirmala UI Semilight)�6]   $��14(�6   
�������$��Center=�6�   ��6   �� *	Days[5]+$ PropertyChanged=�6�   �� 5Y      $��56��6h   $��56��6s   ��6   �� *ForecastDayOneImage+$ PropertyChanged=�6s   �� 5Z      $��Nirmala UI Semilight)�6m   $��14(�6�   
�������$��Center=�6�   ��6   �� *ForecastTemperatures[4]+$ PropertyChanged=�6�   5[      5\      �� 5_      -   5        $ AdvInformationPanel��5_      $ 
Horizontal=�66   .+�5b      �� $��	60,50,0,0q�6   .+�5c      �� $��
Wind Speed��6   $��Nirmala UI Semilight)�61   $��14(�6S   
�������$��Center=�6s   �� 5d      $��56��6c   $��56��6n   ��6   �� *WindSpeedImage+$ PropertyChanged=�6n   �� 5e      $��Nirmala UI Semilight)�6_   $��14(�6�   
�������$��Center=�6�   ��6   �� *	WindSpeed+$ PropertyChanged=�6�   5f      �� 5i      $��	50,50,0,0q�6   .+�5j      �� $��Wind Direction��6   $��Nirmala UI Semilight)�65   $��14(�6W   
�������$��Center=�6w   �� 5k      $��56��6g   $��56��6r   ��6   �� *WindDirectionImage+$ PropertyChanged=�6r   �� 5l      $��Nirmala UI Semilight)�6c   $��14(�6�   
�������$��Center=�6�   ��6   �� *WindDirection+$ PropertyChanged=�6�   5m      �� 5p      $��	50,50,0,0q�6   .+�5q      �� $��Air Pressure��6   $��Nirmala UI Semilight)�63   $��14(�6U   
�������$��Center=�6u   �� 5r      $��56��6e   $��56��6p   ��6   �� *AirPressureImage+$ PropertyChanged=�6p   �� 5s      $��Nirmala UI Semilight)�6a   $��14(�6�   
�������$��Center=�6�   ��6   �� *AirPressure+$ PropertyChanged=�6�   5t      �� 5w      $��	50,50,0,0q�6   .+�5x      �� $��Humidity��6   $��Nirmala UI Semilight)�6/   $��14(�6Q   
�������$��Center=�6q   �� 5y      $��56��6b   $��56��6m   ��6   �� *HumidityImage+$ PropertyChanged=�6m   �� 5z      $��Nirmala UI Semilight)�6^   $��14(�6�   
�������$��Center=�6�   ��6   �� *
Humidity+$ PropertyChanged=�6�   5{      5}      5      �� 5�   
   $��1��6   ��5�      �� 5�      	 �� ImageSource$ 	 Resources/CornishBeach.jpg��6   .+�5�      �� -	   5        $��	TimeLabel��5�      $��0 60 0 0q�6%   $��00:00��67   $��Center=�6G   $��72(�6d   
�������$��Nirmala UI Semilight)�6�   �� 5�      -
   5        $��TimeSecondsLabel��5�      $��100 -20 0 0q�6,   $��00:00��6A   $��Center=�6Q   $��24(�6n   
�������$��Nirmala UI Semilight)�6�   5�      5�      5�      