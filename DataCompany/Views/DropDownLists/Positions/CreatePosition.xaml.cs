using System;
using DataCompany.Models;
using DataCompany.Repositories;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataCompany.Views.DropDownLists.Positions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreatePosition : ContentPage
    {
        private readonly PositionRepository _position;
        
        public CreatePosition()
        {
            _position = new PositionRepository();
            InitializeComponent();
        }
        
        private async void SavePosition(object sender, EventArgs e)
        {
            var position = (Position) BindingContext; 
            _position.Create(position);
            await Navigation.PopAsync();
        }
    }
}