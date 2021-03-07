using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Serwer.Models
{
    public class PersonProjekty
    {
        public long PersonProjektyID{ get; set; }
        public long PersonID { get; set; }
        public long ProjektID { get; set; }


    }
}
