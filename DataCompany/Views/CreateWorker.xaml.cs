using DataCompany.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using DataCompany.Repositories;
using DataCompany.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataCompany.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateWorker : ContentPage
    {
        private readonly WorkerRepository _worker;
        private readonly CompanyRepository _company;
        private readonly PositionRepository _position;
        private List<Company> companies = new List<Company>();
        private List<Position> positions = new List<Position>();

        public CreateWorker()
        {
            InitializeComponent();
            _position = new PositionRepository();
            _company = new CompanyRepository();
            _worker = new WorkerRepository();
            birthDate.MaximumDate = DateTime.Now;
            birthDate.MinimumDate = DateTime.Now.AddYears(-100);
        }

        private async void SaveMember(object sender, EventArgs e)
        {
            var form = (Worker) BindingContext;
            form.WhenAdded = DateTime.Now;
            form.BirthDate = birthDate.Date;
            form.CompanyId = companies[company.SelectedIndex].Id;
            form.PositionId = positions[position.SelectedIndex].Id;
            var fields = new List<string>();
            var errors = new List<string>();

            var errorsList = _worker.IsDataValid(form)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();

            foreach (var combined in errorsList.Select(error => error.Split(new[] {';'}, 2)).Where(combined => !string.IsNullOrWhiteSpace(combined.Last())))
            {
                fields.Add(combined.First());
                errors.Add(combined.Last());
            }

            if (!errors.Any())
            {
                _worker.Create(form);
                errors.Clear();
                await Navigation.PopAsync();
            }
            else
            {
                for (int i = 0; errors.Count - 1 >= i; i++)
                {
                    await DisplayAlert(fields[i], errors[i], "OK");
                }

                errors.Clear();
            }
        }

        private void Entry_PropertyChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            if (!string.IsNullOrWhiteSpace(textChangedEventArgs.NewTextValue))
                ((Entry)sender).Text= Regex.Replace(textChangedEventArgs.NewTextValue, @"[0-9\-]", string.Empty);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            if (!(args.NewTextValue?.Length > args.OldTextValue?.Length)) return;
            if (string.IsNullOrWhiteSpace(args.NewTextValue)) return;
            
            var value = args.NewTextValue;
            ((Entry) sender).Text = PhoneMask.ApplyPhoneMask(value);
        }
        
        protected override async void OnAppearing()
        {
            companies = await _company.GetCompanies();
            companies.ForEach(x => company.Items.Add(x.CompanyName));

            positions = await _position.GetPositions();
            positions.ForEach(x => position.Items.Add(x.PositionName));
            
            base.OnAppearing();
        }

        private async void RandomNames(object sender, EventArgs e)
        {
            var c = await DisplayAlert("Рандомайзер имен", "Пол:", "Муж.", "Жен.");

            if (c)
            {
                (string, string, string) names = RandonNaming.MaleNames();
                surnameEntry.Text = names.Item1;
                nameEntry.Text = names.Item2;
                patronymicEntry.Text = names.Item3;
            }

            else
            {
                (string, string, string) names = RandonNaming.FemaleNames();
                surnameEntry.Text = names.Item1;
                nameEntry.Text = names.Item2;
                patronymicEntry.Text = names.Item3;  
            }
        }
    }
}