using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Serwer.Models
{
    public class Person
    {

        public long PersonID { get; set; }
        public string Name { get; set; }
        public string Nazwisko { get; set; }

        public string Rola { get; set; }






    }

}
