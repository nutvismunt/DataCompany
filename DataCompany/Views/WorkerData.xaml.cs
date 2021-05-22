using DataCompany.Models;
using System;
using System.Linq;
using DataCompany.Repositories;
using Microsoft.EntityFrameworkCore.Internal;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataCompany.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkerData : ContentPage
    {
        private readonly WorkerRepository _worker;
        private readonly PositionRepository _position;
        private readonly CompanyRepository _company;
        private Worker form;

        public WorkerData()
        {
            InitializeComponent();
            _worker = new WorkerRepository();
            _position = new PositionRepository();
            _company = new CompanyRepository();
        }

        private async void DeleteMember(object sender, EventArgs e)
        {
            var member = (Worker) BindingContext;
            if (await DisplayAlert("Удаление участника", "Вы уверены что хотите удалить?", "Да", "Нет"))
                _worker.Delete(member);
            await Navigation.PopAsync();
        }

        private async void EditMember(object sender, EventArgs e)
        {
            var edit = new EditWorker {BindingContext = (Worker) BindingContext};
            await Navigation.PushAsync(edit);
        }
        protected override async void OnAppearing()
        {
            form = (Worker) BindingContext;
            var positions = await _position.GetPositions();
            var companies = await _company.GetCompanies();
            
            position.Text = positions.Any(x => x.Id == form.PositionId) 
                ? positions.First(x => x.Id == form.PositionId).PositionName
                : "Должность была удалена";
            company.Text = companies.Any(x => x.Id == form.CompanyId)
                ? _company.GetCompany(form.CompanyId).CompanyName
                : "Компания была удалена";
            
            base.OnAppearing();
        }
    }
}