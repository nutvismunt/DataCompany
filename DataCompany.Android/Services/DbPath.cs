using System.IO;
using Xamarin.Forms;
using DataCompany.Interfaces;
using DataCompany.Droid.Services;
using System;

[assembly: Dependency(typeof(DbPath))]
namespace DataCompany.Droid.Services
{
    public class DbPath : IPath
    {
        public string GetDbPath (string dbname)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), dbname);
        }
    }
}