using DataStoringService.Module;
using System.Windows;
using Linus.SolarRiedi.DataStoringService.Contracts;

namespace ReportingWPF
{
    public partial class MainWindow : Window
    {
        private readonly IReadService service;

        public MainWindow()
        {
            InitializeComponent();

            this.service = new Initializer().GetService();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var path = this.textBox.Text;
            var dateFromPicker = this.datePicker.SelectedDate;

            var date = dateFromPicker.ToString().Split(' ')[0];
            this.service.CreateReport(date, path);
        }
    }
}
