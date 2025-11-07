using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prak7_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private WorkWithData _dataDoctor = new WorkWithData();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Doctor();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is Doctor doctor)
            {
                doctor.Password = PasswordBox.Password;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string pass = PasswordBox.Password;
            if (!string.IsNullOrEmpty(NameBox.Text))
            {
                if (!string.IsNullOrEmpty(LastNameBox.Text))
                {
                    if (!string.IsNullOrEmpty(MiddleNameBox.Text))
                    {
                        if (!string.IsNullOrEmpty(SpecialisationBox.Text))
                        {
                            if (!string.IsNullOrEmpty(PasswordBox.Password))
                            {
                                if (pass == TryPassBox.Password)
                                {
                                    if (DataContext is Doctor doctor)
                                    {
                                        _dataDoctor.SaveDoctorInFile(doctor);
                                        new EnterPorm().Show();
                                        this.Hide();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Пароли не совпадают", "Ошибка");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Заполните пароль", "Ошибка");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Заполните профессию", "Ошибка");
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Заполните отчество", "Ошибка");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Заполните имя", "Ошибка");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Заполните фамилию", "Ошибка");
                return;
            }

        }
    }
}