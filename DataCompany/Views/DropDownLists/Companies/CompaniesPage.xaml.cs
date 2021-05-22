using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCompany.Models;
using DataCompany.Repositories;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataCompany.Views.DropDownLists.Companies
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompaniesPage : ContentPage
    {
        private readonly CompanyRepository _company;
        public CompaniesPage()
        {
            InitializeComponent();
            _company = new CompanyRepository();
        }

        private async void CreateCompany(object sender, EventArgs e)
        {
            var createCompany = new CreateWorker {BindingContext = new Company()};
            await Navigation.PushAsync(createCompany);
        }

        private async void Delete(object sender, ItemTappedEventArgs e)
        {
            var position = (Company) e.Item;
            if (await DisplayAlert("Удаление должности", "Вы уверены что хотите удалить?", "Да", "Нет"))
                _company.Delete(position);
            await Navigation.PopAsync();
        }
        
        protected override async void OnAppearing()
        {
            companies.ItemsSource = await _company.GetCompanies();
            base.OnAppearing();
        }
    }
}