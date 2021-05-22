using DataCompany.Repositories;
using DataCompany.Views;
using Xamarin.Forms;

namespace DataCompany
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            new PositionRepository().InitializeDatabase();
            new CompanyRepository().InitializeDatabase();
            new WorkerRepository().InitializeDatabase();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
