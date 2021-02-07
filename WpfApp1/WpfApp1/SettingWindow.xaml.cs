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
using Forms = System.Windows.Forms;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : Window
    {
        public SettingWindow()
        {
            InitializeComponent();
        }
        void unMute(object sender, RoutedEventArgs e)
        {
            string _path = Directory.GetCurrentDirectory() + "\\usersettings.json";
            string jsonFromFile = File.ReadAllText(_path);
            dynamic jsonObj = JsonConvert.DeserializeObject(jsonFromFile);
            jsonObj["mute"] = null;
            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(_path, output);
            this.Close();
        }
        private void SettingWindow_Loaded(object sender, RoutedEventArgs e)
        {
            string _path = Directory.GetCurrentDirectory() + "\\usersettings.json";
            string jsonFromFile = File.ReadAllText(_path);
            dynamic jsonObj = JsonConvert.DeserializeObject(jsonFromFile);
            if (jsonObj["mute"] == null)
            {

                MuteToggle.Text = "Mute: Off";
                MuteButton.Click += new RoutedEventHandler(MuteButtonClick);

            }
            else
            {
                MuteToggle.Text = "Unmute Notifications";
                MuteButton.Click += new RoutedEventHandler(unMute);

            }
        }
        private void OnPreferenceClick(object sender, RoutedEventArgs e)
        {
            PreferenceWindow pw = new PreferenceWindow();
            this.Hide();
            pw.ShowDialog();
            this.Show();
        }
        private void MuteButtonClick(object sender, RoutedEventArgs e)
        {
            MuteWindow mw = new MuteWindow();
            this.Hide();
            mw.ShowDialog();
            this.Close();
        }

        private void uninstall_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            About abt = new About();
            this.Hide();
            abt.ShowDialog();
            this.Show();
        }
    }
}
