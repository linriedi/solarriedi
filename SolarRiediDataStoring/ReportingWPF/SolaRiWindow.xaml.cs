using DataStoringService.Module;
using System.Windows;
using Linus.SolarRiedi.DataStoringService.Contracts;
using System;
using System.Text;

namespace ReportingWPF
{
    public partial class SolaRiWindow : Window
    {
        private readonly IReadService service;

        public SolaRiWindow()
        {
            InitializeComponent();

            this.service = new Initializer().GetService();
        }

        private async void CreateDay_Click(object sender, RoutedEventArgs args)
        {
            try
            {
                SetBuisy();
                                
                await this.service.CreateReport(this.GetDate(), this.GetPath());

                ReSetBuisy();
            }
            catch (Exception e)
            {
                Log(e);
            }
        }

        private async void CreateMonth_Click(object sender, RoutedEventArgs args)
        {
            try
            {
                SetBuisy();

                await this.service.CreateMonthReport(this.GetDate(), this.GetPath());

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

        private string GetPath()
        {
            return this.textBox.Text;
        }

        private string GetDate()
        {
            var dateFromPicker = this.datePicker.SelectedDate;
            return dateFromPicker.ToString().Split(' ')[0];
        }
    }
}
