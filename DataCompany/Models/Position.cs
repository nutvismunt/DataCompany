using DataCompany.Interfaces;

namespace DataCompany.Models
{
    public class Position: IEntity
    {
        public long Id { get; set; }
        
        /// <summary>
        /// position's name
        /// </summary>
        public string PositionName { get; set; }
    }
}