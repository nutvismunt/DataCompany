using System;
using DataCompany.Views.DropDownLists.Companies;
using DataCompany.Views.DropDownLists.Positions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataCompany.Views.DropDownLists
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DropDownMenu : ContentPage
    {
        public DropDownMenu()
        {
            InitializeComponent();
        }

        private void CompaniesClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CompaniesPage());
        }

        private void PositionsClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PositionsPage());
        }
    }
}