using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donations.Entities.Models
{
    public class PoliticalEntity
    {
        [Key]
        public int EntityId { get; set; } // Primary Key

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
