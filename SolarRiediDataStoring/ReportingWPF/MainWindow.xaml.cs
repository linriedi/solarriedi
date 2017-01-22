using DataStoringService.Module;
using System.Windows;
using Linus.SolarRiedi.DataStoringService.Contracts;
using System;
using System.Text;

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

        private async void Create_Click(object sender, RoutedEventArgs args)
        {
            try
            {
                this.message.Text = "vid crear...";

                var path = this.textBox.Text;
                var dateFromPicker = this.datePicker.SelectedDate;

                var date = dateFromPicker.ToString().Split(' ')[0];
                await this.service.CreateReport(date, path);

                this.message.Text = "creau";
            }
            catch (Exception e)
            {
                var bulider = new StringBuilder();
                bulider
                    .AppendLine(e.Message)
                    .AppendLine(e.StackTrace);
                this.message.Text = bulider.ToString();
            }
        }

        private async void CreateFullReport_Click(object sender, RoutedEventArgs args)
        {
            this.message.Text = "hi";
        }
    }
}
