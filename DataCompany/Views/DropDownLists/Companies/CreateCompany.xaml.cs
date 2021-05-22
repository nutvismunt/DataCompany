using System;
using DataCompany.Models;
using DataCompany.Repositories;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataCompany.Views.DropDownLists.Companies
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateCompany : ContentPage
    {
        private readonly CompanyRepository _company;
        
        public CreateCompany()
        {
            _company = new CompanyRepository();
            InitializeComponent();
        }

        private async void SaveCompany(object sender, EventArgs e)
        {
            var company = (Company) BindingContext; 
            _company.Create(company);
            await Navigation.PopAsync();
        }
    }
}