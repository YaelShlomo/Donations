using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donations.Entities.Models
{
    public class Donation
    {
        [Key]
        public int Id { get; set; } // Primary Key

        public string Name { get; set; }

        public decimal Amount { get; set; }

        public int EntityId { get; set; } // Foreign Key to the Entity model

        public string Destination { get; set; }

        public string Condition { get; set; }

        public int CurrencyId { get; set; } // Foreign Key to the Currency model

        public decimal ExchangeRate { get; set; }

        // Navigation Properties (for Entity Framework relationships)
        //public Entity Entity { get; set; }

        //public Currency Currency { get; set; }
    }
}
