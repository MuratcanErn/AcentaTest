using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class AppUserProfile : BaseEntity
    {
        
        public string TelNo { get; set; }
        public string FaxNo { get; set; }
      
        public string Email { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        
        // Relational Properties

        public virtual AppUser AppUser { get; set; }

    }
}
