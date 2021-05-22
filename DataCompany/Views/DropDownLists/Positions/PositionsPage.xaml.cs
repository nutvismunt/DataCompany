using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCompany.Models;
using DataCompany.Repositories;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataCompany.Views.DropDownLists.Positions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PositionsPage : ContentPage
    {
        private readonly PositionRepository _position;
        public PositionsPage()
        {
            InitializeComponent();
            _position = new PositionRepository();
        }

        private async void CreatePosition(object sender, EventArgs e)
        {
            var createPosition = new CreatePosition() {BindingContext = new Position()};
            await Navigation.PushAsync(createPosition);
        }

        private async void Delete(object sender, ItemTappedEventArgs e)
        {
            var position = (Position) e.Item;
            if (await DisplayAlert("Удаление должности", "Вы уверены что хотите удалить?", "Да", "Нет"))
                _position.Delete(position);
            await Navigation.PopAsync();
        }
        
        protected override async void OnAppearing()
        {
            positions.ItemsSource = await _position.GetPositions();
            base.OnAppearing();
        }
    }
}