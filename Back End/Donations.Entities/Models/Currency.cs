using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donations.Entities.Models
{
    public class Currency
    {
        [Key]
        public int CurrencyId { get; set; } // Primary Key

        public string Name { get; set; }

        public string Symbol { get; set; }

    }
}
