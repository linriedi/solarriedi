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
                SetBuisy();

                var path = this.textBox.Text;
                var dateFromPicker = this.datePicker.SelectedDate;

                var date = dateFromPicker.ToString().Split(' ')[0];
                await this.service.CreateReport(date, path);

                ReSetBuisy();
            }
            catch (Exception e)
            {
                Log(e);
            }
        }

        private async void CreateFullReport_Click(object sender, RoutedEventArgs args)
        {
            try
            {
                SetBuisy();

                var path = this.textBox.Text;
                await this.service.CreateFullReport(path);

                ReSetBuisy();
            }
            catch (Exception e)
            {
                Log(e);
            }
        }

        private void Log(Exception e)
        {
            var bulider = new StringBuilder();
            bulider
                .AppendLine(e.Message)
                .AppendLine(e.StackTrace);
            this.message.Text = bulider.ToString();
        }

        private void SetBuisy()
        {
            this.message.Text = "vid crear...";
        }

        private void ReSetBuisy()
        {
            this.message.Text = "creau";
        }
    }
}
