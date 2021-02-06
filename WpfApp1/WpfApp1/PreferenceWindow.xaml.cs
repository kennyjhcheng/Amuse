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
    /// Interaction logic for PreferenceWindow.xaml
    /// </summary>
    public partial class PreferenceWindow : Window
    {
        public PreferenceWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void PreferenceWindow_Closed(object sender, EventArgs e)
        {

        }

        private void TimePicker_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine(e.NewValue);
        }

        
        int GetInterval(int index)
        {
            if (index == 0)
            {
                return 1;
            }else if (index == 1)
            {
                return 2;
            }else if (index == 2)
            {
                return 3;
            }
            else
            {
                return 5;
            }
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int interval = GetInterval(Notify.SelectedIndex);
            string formHour = ((ComboBoxItem)FromHour.SelectedItem).Content.ToString();
            string fromMin = ((ComboBoxItem)FromMin.SelectedItem).Content.ToString();
            string fromAMPM = ((ComboBoxItem)FromAMPM.SelectedItem).Content.ToString();
            string toHour = ((ComboBoxItem)ToHour.SelectedItem).Content.ToString();
            string toMin = ((ComboBoxItem)ToMin.SelectedItem).Content.ToString();
            string toAMPM = ((ComboBoxItem)ToAMPM.SelectedItem).Content.ToString();
            string _path = Directory.GetCurrentDirectory() + "\\usersettings.json";
            string jsonFromFile = File.ReadAllText(_path);
            dynamic jsonObj = JsonConvert.DeserializeObject(jsonFromFile);
            jsonObj["To"] = toHour + ":" + toMin + " " + toAMPM;
            jsonObj["From"] = formHour + ":"+fromMin + " "+ fromAMPM;
            jsonObj["interval"] = interval;
            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(_path, output);
            this.Hide();       
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
