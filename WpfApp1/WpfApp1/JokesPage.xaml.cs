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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for JokesPage.xaml
    /// </summary>
 
    public partial class JokesPage : Page
    {
        bool reacted = false;
        UserData ud = null;
        List<int> jokeCategories = new List<int>() { };
        List<string> stringCategories = new List<string>() { };
        string currentCategory = "";
        public JokesPage()
        {
            InitializeComponent();
        }
        private async void JokePage_Loaded(object sender, RoutedEventArgs e)
        {
            await UpdateUI();

        }
        public void HideElementsForLoading()
        {
            q.Visibility = Visibility.Hidden;
            a.Visibility = Visibility.Hidden;
            j.Visibility = Visibility.Hidden;
        }
        public async Task UpdateUI()
        {
            HideElementsForLoading();
            spinner.Visibility = Visibility.Visible;
            Joke jsonJoke = await GetJoke();
            if (jsonJoke == null)
            {
                return;
            }
            else
            {
                if (jsonJoke.type == "twopart")
                {

                    q.Visibility = Visibility.Visible;
                    a.Visibility = Visibility.Visible;

                    q.Text = jsonJoke.q;
                    a.Text = jsonJoke.a;
                    Console.WriteLine("TWO");
                }
                else
                {

                    j.Visibility = Visibility.Visible;
                    j.Text = jsonJoke.j;
                }
            }
            spinner.Visibility = Visibility.Hidden;
        }
        private async void FirstTextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            await UpdateUI();
        }
        private void GetUserData()
        {


            try
            {
                string _path = Directory.GetCurrentDirectory() + "\\usersettings.json";
                string jsonFromFile = File.ReadAllText(_path);
                ud = JsonConvert.DeserializeObject<UserData>(jsonFromFile);
                if (jokeCategories.Count > 0)
                {
                    jokeCategories.Clear();
                }
                if (stringCategories.Count > 0)
                {
                    stringCategories.Clear();
                }

                jokeCategories.Add(ud.jokeCategory.programming);
                stringCategories.Add("programming");
                jokeCategories.Add(ud.jokeCategory.christmas);
                stringCategories.Add("christmas");
                jokeCategories.Add(ud.jokeCategory.pun);
                stringCategories.Add("pun");
                jokeCategories.Add(ud.jokeCategory.history);
                stringCategories.Add("history");
                jokeCategories.Add(ud.jokeCategory.science);
                stringCategories.Add("science");
                jokeCategories.Add(ud.jokeCategory.miscellaneous);
                stringCategories.Add("miscellaneous");
                jokeCategories.Add(ud.jokeCategory.current);
                stringCategories.Add("current");




            }
            catch
            {
                Console.WriteLine("Error saving initial preferences");
            }




        }

        public async Task<dynamic> GetJoke()
        {
            reacted = false;
            GetUserData();

            double avg = Queryable.Average((IQueryable<int>)jokeCategories.AsQueryable());
            int index;
            if (avg == 0)
            {
                index = new Random().Next(jokeCategories.Count);
            }
            else
            {
                index = jokeCategories.FindIndex(a => a >= avg);
            }


            currentCategory = stringCategories[index];
            string path = "https://jokesapi.gottacatchemall.repl.co/jokes/" + stringCategories[index];
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                dynamic jsonJoke = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonJoke);

                return JsonConvert.DeserializeObject<Joke>(jsonJoke);
            }
            return null;
        }

        private void HeartButton_Click(object sender, RoutedEventArgs e)
        {
            reacted = !reacted;
            string _path = Directory.GetCurrentDirectory() + "\\usersettings.json";
            string jsonFromFile = File.ReadAllText(_path);
            dynamic jsonObj = JsonConvert.DeserializeObject(jsonFromFile);
            jsonObj["jokeCategory"][currentCategory] += 1;

            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(_path, output);
            //HeartIcon.Background = new SolidColorBrush(Colors.Red);
            //DislikeIcon.Background = new SolidColorBrush(Colors.Transparent);
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

        private async void JTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            await UpdateUI();
        }

        private void DislikeButton_Click(object sender, RoutedEventArgs e)
        {
            reacted = !reacted;
            string _path = Directory.GetCurrentDirectory() + "\\usersettings.json";
            string jsonFromFile = File.ReadAllText(_path);
            dynamic jsonObj = JsonConvert.DeserializeObject(jsonFromFile);
            jsonObj["jokeCategory"][currentCategory] -= 1;

            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(_path, output);
            //HeartIcon.Background = new SolidColorBrush(Colors.Transparent);
            //DislikeIcon.Background = new SolidColorBrush(Colors.Blue);
        }

        private void DropDownOpen(object sender, RoutedEventArgs e)
        {

            //AddPresetButton_Click(AddPresetButton,e);
            //
        }

        private void AddJoke_Click(object sender, RoutedEventArgs e)
        {
            AddJoke aj = new AddJoke();
            
            aj.ShowDialog();

        }

        private void MoreMouseEnter(object sender, MouseEventArgs e)
        {
           
            AddPresetButton_Click(AddPresetButton, e);
        }
            
        private void MenuItemOne_Click(object sender, RoutedEventArgs e)
        {
            //Animal pictures
            JokesWindow.ParentFrame.NavigationService.Navigate(new PicsPage());
        }

        private void MenuItemTwo_Click(object sender, RoutedEventArgs e)
        {
            //Add jokes
            AddJoke aj = new AddJoke();
            aj.ShowDialog();
        }

        private void AddPresetButton_Click(object sender, RoutedEventArgs e)
        {
            var addButton = sender as FrameworkElement;
            if (!addButton.ContextMenu.IsOpen)
            {
               
               
                if (addButton != null)
                {
                    addButton.ContextMenu.IsOpen = true;
                }
            
            }
            
           
        }

        private void AddPresetButton_MouseEnter(object sender, MouseEventArgs e)
        {
            AddPresetButton.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            //Console.WriteLine("aj");

           AddPresetButton.ContextMenu.IsOpen = false;
            //opened = false;

        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            //opened = false;
        }

        private void AddPresetButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Console.WriteLine("aj");
            AddPresetButton.ContextMenu.IsOpen = false;
        }

        private void ContextMenu_MouseLeave(object sender, MouseEventArgs e)
        {
            AddPresetButton.ContextMenu.IsOpen = false;
        }

        private void MenuItem_MouseEnter(object sender, MouseEventArgs e)
        {
            AddPresetButton.ContextMenu.IsOpen = true;
        }

       
    }


}
