using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MuteWindow.xaml
    /// </summary>
    public partial class MuteWindow : Window
    {
        public MuteWindow()
        {
            InitializeComponent();
        }
       
        void updateMute(int number)
        {
            string _path = Directory.GetCurrentDirectory() + "\\usersettings.json";
            string jsonFromFile = File.ReadAllText(_path);
            dynamic jsonObj = JsonConvert.DeserializeObject(jsonFromFile);
            DateTime currentTime = DateTime.Now;
            DateTime addedTime;
            if (number == 15)
            {
                addedTime = currentTime.AddMinutes(15);
                jsonObj["mute"] = addedTime.ToShortTimeString();

            }
            else if (number == 1) 
            {
                addedTime = currentTime.AddHours(1);
                jsonObj["mute"] = addedTime.ToShortTimeString();

            }
            else if (number == 8)
            {
                addedTime = currentTime.AddHours(8);
                jsonObj["mute"] = addedTime.ToShortTimeString();

            }
            else if (number == 24)
            {
                addedTime = currentTime.AddHours(24);
                jsonObj["mute"] = addedTime.ToShortTimeString();

            }
            else if (number == -1)
            {
               
                jsonObj["mute"] = "-1";

            }

            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(_path, output);
            this.Close();
        }
        private void Minutes_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            updateMute(15);
            
        }

        private void OneHour_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            updateMute(1);
        }

        private void EightHours_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            updateMute(8);
        }

        private void Day_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            updateMute(24);
        }

        private void Infinite_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            updateMute(-1);
        }

        private void TextBlock15_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            
          //  fifteenMin.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#2d9cdb"));
        }
    }
}
