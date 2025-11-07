using System.Numerics;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace prak7_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rand = new Random();
        private Doctor doctor = new Doctor();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            doctor = (Doctor)Resources["CurDoctor"];
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
            };
            doctor.Id = rand.Next(10000, 100000);
            string json = JsonSerializer.Serialize(doctor, options);
            File.WriteAllText($"D_{doctor.Id}.json", json);
            MessageBox.Show($"Успешно\t {doctor.Id}");
            Clipboard.SetText(doctor.Id.ToString());


        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            doctor = (Doctor)Resources["CurDoctor"];
            string doctorFile = $"D_{doctor.Id}.json";
            string doctorReadFile = File.ReadAllText(doctorFile);
            var doctorJson = JsonSerializer.Deserialize<Doctor>(doctorReadFile);
            if (doctor.Password == doctorJson?.Password)
            {
                doctor.Name = doctorJson.Name;
                doctor.LastName = doctorJson.LastName;
                doctor.MiddleName = doctorJson.MiddleName;
                doctor.Specialisation = doctorJson.Specialisation;
                MessageBox.Show("Все гуд");

            }
            else
            {
                MessageBox.Show("Ytn");
            }
        }
    }
}