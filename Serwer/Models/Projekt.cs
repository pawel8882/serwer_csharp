using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;



namespace Serwer.Models
{
    public class Projekt
    {
        public long ProjektID { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        public string numer { get; set; }

        public ICollection<ProjektDetails> ProjektDetails { get; set; }
        
        public ICollection<PersonProjekty> PersonProjekty { get; set; }

        public ICollection<Person> Persony { get; set; }

    }
}
