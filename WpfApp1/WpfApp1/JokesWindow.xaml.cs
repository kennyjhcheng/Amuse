using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
using Forms = System.Windows.Forms;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for JokesWindow.xaml
    /// </summary>
    public partial class JokesWindow : Window
    {
        private readonly Forms.NotifyIcon _notifyIcon;
        static public Frame ParentFrame;
        public void GoToJokeFromParent()
        {
            Frame.NavigationService.Navigate(new JokesPage());
        }
        public void GoToPicsFromParent()
        {
            Frame.NavigationService.Navigate(new PicsPage());
        }
        public JokesWindow()
        {
            InitializeComponent();
            _notifyIcon = new Forms.NotifyIcon();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ParentFrame = this.Frame;
            Frame.NavigationService.Navigate(new JokesPage());
          
        }
        private void CrossButton_Click(object sender, RoutedEventArgs e)
        {
            _notifyIcon.Icon = new System.Drawing.Icon(Directory.GetCurrentDirectory() + "\\icon.ico");
            _notifyIcon.Visible = true;
            _notifyIcon.MouseClick += NotifyTrayClick;
            _notifyIcon.Text = "Amuse";
            _notifyIcon.ContextMenuStrip = new Forms.ContextMenuStrip();
            _notifyIcon.ContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(cms_Opening);
            int hour = new DateTime().Hour;
            int minute = new DateTime().Minute;
            InitTimer();
            this.Hide();
        }
        async void DelayForOnce()
        {
            Joke j = new Joke();
            string path = "https://jokesapi.gottacatchemall.repl.co/jokes";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                dynamic jsonJoke = await response.Content.ReadAsStringAsync();
                j = JsonConvert.DeserializeObject<Joke>(jsonJoke);


            }

            await Task.Delay(new TimeSpan(0, 30, 30)).ContinueWith(o =>
            {

                _notifyIcon.BalloonTipText = j.q;
                _notifyIcon.BalloonTipTitle = j.a;
                _notifyIcon.ShowBalloonTip(3);
            });


        }
        async void DelayForTwo()
        {
            Joke j = new Joke();

            string path = "https://jokesapi.gottacatchemall.repl.co/jokes";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                dynamic jsonJoke = await response.Content.ReadAsStringAsync();
                j = JsonConvert.DeserializeObject<Joke>(jsonJoke);


            }

            await Task.Delay(new TimeSpan(0, 30, 30)).ContinueWith(o =>
            {
                _notifyIcon.BalloonTipText = "Hey how about you take a break?";
                _notifyIcon.BalloonTipTitle = "Click to see a cute picture!";
                _notifyIcon.ShowBalloonTip(3);
                _notifyIcon.BalloonTipClicked += _notifyIcon_BalloonTipClicked;
            });
            await Task.Delay(new TimeSpan(3, 30, 160)).ContinueWith(o =>
            {
                _notifyIcon.BalloonTipText = j.q;
                _notifyIcon.BalloonTipTitle = j.a;
                _notifyIcon.ShowBalloonTip(3);
            });

        }

        private void _notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            JokesWindow jw = new JokesWindow();
            jw.Frame.NavigationService.Navigate(new PicsPage());
            jw.Show();
        }

        async void DelayForThree()
        {
            Joke j = new Joke();

            string path = "https://jokesapi.gottacatchemall.repl.co/jokes";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                dynamic jsonJoke = await response.Content.ReadAsStringAsync();
                j = JsonConvert.DeserializeObject<Joke>(jsonJoke);


            }

            await Task.Delay(new TimeSpan(0, 30, 30)).ContinueWith(o =>
            {

                _notifyIcon.BalloonTipText = "Hey how about you take a break?";
                _notifyIcon.BalloonTipTitle = "Click to see a cute picture!";
                _notifyIcon.ShowBalloonTip(3);
                _notifyIcon.BalloonTipClicked += _notifyIcon_BalloonTipClicked;
            });
            await Task.Delay(new TimeSpan(3, 0, 160)).ContinueWith(o =>
            {
                _notifyIcon.BalloonTipText = j.q;
                _notifyIcon.BalloonTipTitle = j.a;
                _notifyIcon.ShowBalloonTip(3);
            });
            await Task.Delay(new TimeSpan(6, 30, 160)).ContinueWith(o =>
            {

                _notifyIcon.BalloonTipText = "Hey how about you take a break?";
                _notifyIcon.BalloonTipTitle = "Click to see a cute picture!";
                _notifyIcon.ShowBalloonTip(3);
                _notifyIcon.BalloonTipClicked += _notifyIcon_BalloonTipClicked;
            });

        }
        async void DelayForFive()
        {
            Joke j = new Joke();
            Joke j2 = new Joke();

            string path = "https://jokesapi.gottacatchemall.repl.co/jokes";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                dynamic jsonJoke = await response.Content.ReadAsStringAsync();
                j = JsonConvert.DeserializeObject<Joke>(jsonJoke);


            }
            HttpResponseMessage response2 = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                dynamic jsonJoke = await response2.Content.ReadAsStringAsync();
                j2 = JsonConvert.DeserializeObject<Joke>(jsonJoke);


            }

            await Task.Delay(new TimeSpan(0, 30, 30)).ContinueWith(o =>
            {
                _notifyIcon.BalloonTipText = j2.q;
                _notifyIcon.BalloonTipTitle = j2.a;
                _notifyIcon.ShowBalloonTip(3);
            });
            await Task.Delay(new TimeSpan(3, 0, 160)).ContinueWith(o =>
            {
                _notifyIcon.BalloonTipText = "Hey how about you take a break?";
                _notifyIcon.BalloonTipTitle = "Click to see a cute picture!";
                _notifyIcon.ShowBalloonTip(3);
                _notifyIcon.BalloonTipClicked += _notifyIcon_BalloonTipClicked;
            });

            await Task.Delay(new TimeSpan(6, 30, 160)).ContinueWith(o =>
            {
                _notifyIcon.BalloonTipText = j.q;
                _notifyIcon.BalloonTipTitle = j.a;
                _notifyIcon.ShowBalloonTip(3);
            });

            await Task.Delay(new TimeSpan(8, 30, 160)).ContinueWith(o =>
            {
                _notifyIcon.BalloonTipText = "Hey how about you take a break?";
                _notifyIcon.BalloonTipTitle = "Click to see a cute picture!";
                _notifyIcon.ShowBalloonTip(3);
                _notifyIcon.BalloonTipClicked += _notifyIcon_BalloonTipClicked;
            });


        }
        public void InitTimer()
        {
            string _path = Directory.GetCurrentDirectory() + "\\usersettings.json";
            string jsonFromFile = File.ReadAllText(_path);
            dynamic jsonObj = JsonConvert.DeserializeObject(jsonFromFile);
            if (jsonObj["interval"] == 1)
            {
                DelayForOnce();
            }
            if (jsonObj["interval"] == 2)
            {
                DelayForTwo();
            }
            if (jsonObj["interval"] == 3)
            {
                DelayForThree();
            }
            if (jsonObj["interval"] == 5)
            {
                DelayForFive();
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int rand = new Random().Next(0, 2);
            if (rand == 0)
            {
                _notifyIcon.BalloonTipText = "Why do programmers prefer using dark mode?";
                _notifyIcon.BalloonTipTitle = "Because light attracts bugs";
                _notifyIcon.ShowBalloonTip(3);
            }
            else
            {
                _notifyIcon.BalloonTipText = "Image";
                _notifyIcon.BalloonTipTitle = "This is a image";
                _notifyIcon.ShowBalloonTip(3);

            }


        }
        void cms_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _notifyIcon.ContextMenuStrip.Items.Clear();
            Forms.ToolStripItem close = new Forms.ToolStripButton("Close");
            close.Click += ShutDown;
            _notifyIcon.ContextMenuStrip.Items.Add(close);


            string _path = Directory.GetCurrentDirectory() + "\\usersettings.json";
            string jsonFromFile = File.ReadAllText(_path);
            dynamic jsonObj = JsonConvert.DeserializeObject(jsonFromFile);
            if (jsonObj["mute"] == null)
            {

                Forms.ToolStripItem fifteen = new Forms.ToolStripButton("For 15 Minutes");
                fifteen.Click += Fifteen_Click;
                Forms.ToolStripItem hour = new Forms.ToolStripButton("For 1 Hour");
                hour.Click += Hour_Click;
                Forms.ToolStripItem eightHours = new Forms.ToolStripButton("For 8 Hours");
                eightHours.Click += EightHours_Click;
                Forms.ToolStripItem day = new Forms.ToolStripButton("For 15 Hours");

                day.Click += Day_Click;
                //Forms.ToolStripItem day = new Forms.ToolStripButton("For 15 Hours");
                //day.Click += Day_Click;
                Forms.ToolStripItem dropDown = new Forms.ToolStripDropDownButton("Mute", null,
                   fifteen,
                   hour,
                    eightHours,
                    day
                    );
                _notifyIcon.ContextMenuStrip.Items.Add(
                        dropDown
                 );
            }
            else
            {
                Forms.ToolStripItem unMute = new Forms.ToolStripButton("Unmute");
                _notifyIcon.ContextMenuStrip.Items.Add(
                   unMute
             );
                unMute.Click += UnMute_Click;
                _notifyIcon.ContextMenuStrip.Items.Add(
                       unMute
                );
            }


            _notifyIcon.ContextMenuStrip.ItemClicked += new Forms.ToolStripItemClickedEventHandler(contexMenu_ItemClicked);
        }

        private void UnMute_Click(object sender, EventArgs e)
        {
            string _path = Directory.GetCurrentDirectory() + "\\usersettings.json";
            string jsonFromFile = File.ReadAllText(_path);
            dynamic jsonObj = JsonConvert.DeserializeObject(jsonFromFile);
            jsonObj["mute"] = null;
            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(_path, output);
        }

        void UpdateMuteSettings(int number)
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

        }
        private void Day_Click(object sender, EventArgs e)
        {
            UpdateMuteSettings(24);
        }

        private void EightHours_Click(object sender, EventArgs e)
        {
            UpdateMuteSettings(8);
        }

        private void Hour_Click(object sender, EventArgs e)
        {
            UpdateMuteSettings(1);
        }

        private void Fifteen_Click(object sender, EventArgs e)
        {
            UpdateMuteSettings(15);
        }

        void contexMenu_ItemClicked(object sender, Forms.ToolStripItemClickedEventArgs e)
        {
            string msg = String.Format("Item clicked: {0}", e.ClickedItem.Text);

            Forms.ToolStripItem item = e.ClickedItem;
            Console.WriteLine(msg);

        }
        private void NotifyTrayClick(object sender, EventArgs e)
        {
            if (e is MouseEventArgs)
            {
                Console.WriteLine("gg");
                MouseButton mouseButton = (MouseButton)(e as MouseEventArgs).LeftButton;
                if (mouseButton == MouseButton.Left)
                {
                    this.Show();
                    this.WindowState = WindowState.Normal;
                    this.Activate();
                }
            }
        }
        private void ShutDown(object sender, EventArgs e)
        {
            this.Close();
        }
        private void OpenSettingButton_Click(object sender, RoutedEventArgs e)
        {
            SettingWindow win2 = new SettingWindow();
            win2.ShowDialog();
        }
        protected override void OnClosed(EventArgs e)
        {
            _notifyIcon.Dispose();
            base.OnClosed(e);
        }

        public class Joke
        {
            public string type { get; set; }
            public string q { get; set; }
            public string a { get; set; }
            public string j { get; set; }
        }
        public class Dnd
        {
            public int dndstart { get; set; }
            public int dndstop { get; set; }
        }

        public class JokeCategory
        {
            public int programming { get; set; }
            public int miscellaneous { get; set; }

            public int current { get; set; }
            public int pun { get; set; }

            public int science { get; set; }
            public int history { get; set; }
            public int christmas { get; set; }
        }

        public class UserData
        {
            public int time { get; set; }
            public int jokeInterval { get; set; }
            public string jokeSelection { get; set; }
            public string jokeSelection1 { get; set; }
            public bool notifyJokes { get; set; }
            public bool notifyPics { get; set; }
            public int pic { get; set; }
            public List<Dnd> dnd { get; set; }
            public object name { get; set; }
            public JokeCategory jokeCategory { get; set; }
            public List<string> blacklist { get; set; }
            public bool notifyjokes { get; set; }
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Console.WriteLine("DRAG");
                DragMove();
            }
        }

        private void OpenSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingWindow win2 = new SettingWindow();
            win2.ShowDialog();
        }

      
    }
}
