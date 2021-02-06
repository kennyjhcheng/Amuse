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
    /// Interaction logic for PicsPage.xaml
    /// </summary>
    
    public partial class PicsPage : Page
    {
        string path = "";
        public PicsPage()
        {
            InitializeComponent();
        }

        private async void PicsPage_Loaded(object sender, RoutedEventArgs e)
        {
           
            await LoadImage();
          
        }
        public void UpdateImage(string url)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(url, UriKind.Absolute);
            bitmap.EndInit();
            image.Source = bitmap;
        }
        private void GoToJoke(object sender, RoutedEventArgs e)
        {
           JokesWindow.ParentFrame.NavigationService.Navigate(new JokesPage());
            
          
        }
        public async Task LoadImage()
        {

            image.Visibility = Visibility.Hidden;
            Spinner.Visibility = Visibility.Visible;
        
            path = "https://dog.ceo/api/breeds/image/random";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                dynamic picsResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine(picsResponse);

                Pic pic = JsonConvert.DeserializeObject<Pic>(picsResponse);
                UpdateImage(pic.message);
            }
            Spinner.Visibility = Visibility.Hidden;
            image.Visibility = Visibility.Visible;
        }

        //public async void SaveImage()
        //{
        //    var encoder = new JpegBitmapEncoder();
        //    if (path != "")
        //    {

        //    }
        //    var uri = new Uri(path);
        //    var bitmap = new BitmapImage(uri);
        //    encoder.Frames.Add(BitmapFrame.Create(bitmap));
        //    encoder.QualityLevel = 100; // Set quality
        //    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //    using (var stream = new FileStream(path, FileMode.Create))
        //    {
        //        encoder.Save(stream);
        //    }
        //}
        private async void Image_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            await LoadImage();
        }

        public class Pic
        {
            public string message { get; set; }
            public string status { get; set; }
        }


    }
}
