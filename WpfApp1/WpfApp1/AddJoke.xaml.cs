using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfAnimatedGif;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for AddJoke.xaml
    /// </summary>
    public partial class AddJoke : Window
    {
        public AddJoke()
        {
            InitializeComponent();
           

        }
        public void UpdateImage(string url)
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(url);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(spinner, image);
        }

        private async void DoneJoke_Click(object sender, RoutedEventArgs e)
        {          
            spinner.Visibility = Visibility.Visible;
            string path = "https://jokesapi.gottacatchemall.repl.co/jokesadd"; 
            HttpClient client = new HttpClient();
            var joke = new Jokes();
            joke.j = Question.Text;         
            joke.type = "single";     
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(joke);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(path, data);
            string resultContent = await result.Content.ReadAsStringAsync();
            Console.WriteLine(resultContent);
            spinner.Visibility = Visibility.Hidden;
            this.Close();
        }
    
        
        private async void Done2Button_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(2)),
                AutoReverse = true
            };
            spinner.BeginAnimation(OpacityProperty, da);
            Submit.Visibility = Visibility.Hidden;
            spinner.Visibility = Visibility.Visible;
            string path = "https://jokesapi.gottacatchemall.repl.co/jokesadd";
            HttpClient client = new HttpClient();


            var joke = new Jokes();
            joke.j = Question.Text;

            joke.type = "single";
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(joke);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(path, data);
            string resultContent = await result.Content.ReadAsStringAsync();
            Console.WriteLine(resultContent);
            spinner.Visibility = Visibility.Hidden;
            this.Close();
        }

        private void Single_Click(object sender, RoutedEventArgs e)
        {
       
            Question.Visibility = Visibility.Hidden;

            Joke.Visibility = Visibility.Visible;    
            JokeText.Visibility = Visibility.Visible;
            Submit.Visibility = Visibility.Hidden;
            TwoPart.Visibility = Visibility.Visible;
            
            Done2Button.Visibility = Visibility.Visible;
        }

        private void TwoPart_Click(object sender, RoutedEventArgs e)
        {
          
            Question.Visibility = Visibility.Visible;
           
            Joke.Visibility = Visibility.Hidden;
            JokeText.Visibility = Visibility.Hidden;
            Submit.Visibility = Visibility.Visible;
            TwoPart.Visibility = Visibility.Hidden;
           
            Done2Button.Visibility = Visibility.Hidden;
        }
        public class Jokes
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

        private void TwoPart_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //StringBuilder bodyContent = new StringBuilder();
            //string fileName = "amuseloading.gif";
            //try
            //{
            //    string filePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
            //    using (StreamReader sr = new StreamReader(filePath))
            //    {
            //        // Read the stream.
            //        bodyContent.Append(sr.ReadToEnd());
            //    }
            //   UpdateImage(fileName);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(String.Format("{0} @ {1}", "Exception while reading the file: " + ex.InnerException.Message, DateTime.Now));
            //    throw ex;
            //}
        }
    }
}
