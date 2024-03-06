using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project.ENTITIES.Models
{
    public class AppUser : BaseEntity
    {

        public bool Admin { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AgencyNumber { get; set; }
        public  string AgencyName { get; set; }
        
        public override string ToString()
        {
            return $"{UserName}";
        }

        //Relation Properties

        public virtual AppUserProfile Profile { get; set; }
       
    }
}
