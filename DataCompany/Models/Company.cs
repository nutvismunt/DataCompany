using DataCompany.Interfaces;

namespace DataCompany.Models
{
    public class Company : IEntity
    {
        public long Id { get; set; }
        
        /// <summary>
        /// company's name
        /// </summary>
        public string CompanyName { get; set; }
    }
}