using System;
using DataCompany.Interfaces;

namespace DataCompany.Models
{
    public class Worker : IEntity
    {
        public long Id { get; set; }

        /// <summary>
        /// worker's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// worker's surname
        /// </summary>
        public string Surname { get; set; }
        
        /// <summary>
        /// worker's patronymic
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// worker's birthday
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// worker's phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// when was created
        /// </summary>
        public DateTime WhenAdded { get; set; }
        
        /// <summary>
        /// worker's company Id
        /// </summary>
        public long CompanyId { get; set; }

        /// <summary>
        /// worker's position Id
        /// </summary>
        public long PositionId { get; set; }
    }
}
