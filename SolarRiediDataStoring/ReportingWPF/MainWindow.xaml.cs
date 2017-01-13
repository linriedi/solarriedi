using DataStoringService.Module;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Linus.SolarRiedi.DataStoringService.Contracts;
using Common;

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

            var date = new ReportDate(
                dateFromPicker.Value.Year, 
                dateFromPicker.Value.Month, 
                dateFromPicker.Value.Day);

            this.service.CreateReport(date, path);
        }
    }
}
