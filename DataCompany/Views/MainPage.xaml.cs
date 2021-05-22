using System;
using DataCompany.Models;
using DataCompany.Repositories;
using DataCompany.Views.DropDownLists;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataCompany.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private readonly WorkerRepository _worker;

        public MainPage()
        {
            InitializeComponent();
            _worker = new WorkerRepository();
            
        }

        protected override async void OnAppearing()
        {
            members.ItemsSource = await _worker.GetWorkers();
            base.OnAppearing();
        }

        private async void CreateWorker(object sender, EventArgs e)
        {
            var createMember = new CreateWorker {BindingContext = new Worker()};
            await Navigation.PushAsync(createMember);
        }

        private void Workers_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var memberData = new WorkerData {BindingContext = (Worker)e.Item};
            Navigation.PushAsync(memberData);
        }

        private void DropDownLists(object sender, EventArgs e)
        {
            var dropDownMenu = new DropDownMenu();
            Navigation.PushAsync(dropDownMenu);
        }
    }
}
