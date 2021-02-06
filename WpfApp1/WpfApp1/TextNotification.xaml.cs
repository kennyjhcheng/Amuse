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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for TextNotification.xaml
    /// </summary>
    public partial class TextNotification : Window
    {
        public TextNotification()
        {
            InitializeComponent();
            Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() =>
            {
                var workingArea = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
                var transform = PresentationSource.FromVisual(this).CompositionTarget.TransformFromDevice;
                var corner = transform.Transform(new Point(workingArea.Right, workingArea.Bottom));

                this.Left = corner.X - this.ActualWidth;
                this.Top = corner.Y - this.ActualHeight;
            }));
        }
        private void Storyboard_Completed(object sender, EventArgs e)
        {
            this.Close();
        }
        private void View_More_Click(object sender, RoutedEventArgs e)
        {
            JokesWindow jw = new JokesWindow();
            jw.GoToPicsFromParent();
            jw.Show();
        }

        private void Close_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
      
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string path = "https://jokesapi.gottacatchemall.repl.co/jokesrand";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                dynamic jsonJoke = await response.Content.ReadAsStringAsync();
                
                Joke j = JsonConvert.DeserializeObject<Joke>(jsonJoke);
                if (j.type == "single") {

                    QText.Visibility = Visibility.Visible;
                    AText.Visibility = Visibility.Visible;
                    JokeText.Text = j.j;
                }
                else
                {
                    JokeText.Visibility = Visibility.Hidden;
                    QText.Text = j.q;
                    AText.Text = j.a;
                }
                Console.WriteLine(j);
            }
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
    }
}
