using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for Notification.xaml
    /// </summary>
    public partial class Notification : Window
    {
        public Notification()
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
        public void UpdateImage(string url)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(url, UriKind.Absolute);
            bitmap.EndInit();
            Image.Source = bitmap;
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string path = "https://dog.ceo/api/breeds/image/random";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                dynamic picsResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine(picsResponse);

                Pic pic = JsonConvert.DeserializeObject<Pic>(picsResponse);
                UpdateImage(pic.message);
            }
        }
    }
    
    public class Pic
    {
        public string message { get; set; }
        public string status { get; set; }
    }

}
