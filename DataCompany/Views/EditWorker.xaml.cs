using DataCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DataCompany.Repositories;
using DataCompany.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataCompany.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditWorker : ContentPage
    {
        private readonly WorkerRepository _worker;
        private readonly CompanyRepository _company;
        private readonly PositionRepository _position;
        private List<Company> companies = new List<Company>();
        private List<Position> positions = new List<Position>();

        public EditWorker()
        {
            InitializeComponent();
            _worker = new WorkerRepository();
            _company = new CompanyRepository();
            _position = new PositionRepository();
            birthDate.MaximumDate = DateTime.Now;
            birthDate.MinimumDate = DateTime.Now.AddYears(-100);
        }
        private async void SaveMember(object sender, EventArgs e)
        {
            var form = (Worker)BindingContext;
            form.BirthDate = birthDate.Date;
            form.CompanyId = companies[company.SelectedIndex].Id;
            form.PositionId = positions[position.SelectedIndex].Id;
            var fields = new List<string>();
            var errors = new List<string>();
            
            var errorsList = _worker.IsDataValid(form)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(error => error.Split(new[] { ';' }, 2))
                .Where(combined => !string.IsNullOrWhiteSpace(combined.Last()));
            
            foreach (var combined in errorsList)
            {
                fields.Add(combined.First());
                errors.Add(combined.Last());
            }
            if (!errors.Any())
            {
                _worker.Update(form);
                errors.Clear();
                await Navigation.PopToRootAsync();
            }
            else
            {
                for (int i = 0; errors.Count - 1 >= i; i++)
                { await DisplayAlert(fields[i], errors[i], "OK"); }
                errors.Clear();
            }
        }
        private void Entry_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text))
                nameEntry.Text = Regex.Replace(nameEntry.Text, @"[0-9\-]", string.Empty);
            if (!string.IsNullOrWhiteSpace(surnameEntry.Text))
                surnameEntry.Text = Regex.Replace(surnameEntry.Text, @"[0-9\-]", string.Empty);
            if (!string.IsNullOrWhiteSpace(patronymicEntry.Text))
                surnameEntry.Text = Regex.Replace(surnameEntry.Text, @"[0-9\-]", string.Empty);
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
            var form = (Worker)BindingContext;
            
            companies = await _company.GetCompanies();
            companies.ForEach(x => company.Items.Add(x.CompanyName));

            company.SelectedItem = companies.Any(x => x.Id == form.CompanyId)
                ? companies.First(x => x.Id == form.CompanyId).CompanyName
                : "Компания";

            positions = await _position.GetPositions();
            positions.ForEach(x => position.Items.Add(x.PositionName));

            position.SelectedItem = positions.Any(x => x.Id == form.PositionId)
                ? positions.First(x => x.Id == form.PositionId).PositionName
                : "Должность";
            
            base.OnAppearing();
        }
    }
}