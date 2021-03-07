using Serwer.Data;
using Serwer.Models;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
namespace Serwer.Data
{
    public class ini
    {
        public static void Initialize(ProjektContext context) {

            context.Database.EnsureCreated();

                if (context.ProjektItems.Any())
            {
                return;
            }


            var projekty = new Projekt[]
            {
                new Projekt {Name="Silos stalowy", numer="888", IsComplete=false},
                new Projekt {Name="Hala stalowa", numer="587", IsComplete=false},
                new Projekt {Name="Placek", numer="546", IsComplete=false},
                new Projekt {Name="Naleśnik", numer="785", IsComplete=false},
                new Projekt {Name="Hala żelbetowa", numer="222", IsComplete=false}
            };

            context.ProjektItems.AddRange(projekty);
            context.SaveChanges();

            var detale = new ProjektDetails[]
         {
                new ProjektDetails {ProjektID=1, DataDodania="12.12.2020", opis="Konstrukcja nośna"},
                new ProjektDetails {ProjektID=2, DataDodania="12.12.2020", opis="Konstrukcja"},
                new ProjektDetails {ProjektID=3, DataDodania="12.12.2020", opis="Na patelni"},
                new ProjektDetails {ProjektID=4, DataDodania="12.12.2020", opis="Makowy"},
                new ProjektDetails {ProjektID=5, DataDodania="12.12.2020", opis="Konstrukcja z żelbetu"},
         };

            context.ProjektDetailsItems.AddRange(detale);
            context.SaveChanges();

            var osoby = new Person[]
{
                new Person {Name="Igor", Nazwisko="Schevchenko", Rola="Obliczenia" },
                new Person {Name="Sletiana", Nazwisko="Massernova", Rola="Warsztat" },
                new Person {Name="Dakota", Nazwisko="James", Rola="Warsztat"}
};
            context.PersonItems.AddRange(osoby);
            context.SaveChanges();

            var przypisanie = new PersonProjekty[]
{
                new PersonProjekty {PersonID=1, ProjektID=1},
                new PersonProjekty {PersonID=1, ProjektID=2},
                new PersonProjekty {PersonID=1, ProjektID=3},
                new PersonProjekty {PersonID=1, ProjektID=4},
                new PersonProjekty {PersonID=1, ProjektID=5},
                new PersonProjekty {PersonID=2, ProjektID=1},
                new PersonProjekty {PersonID=2, ProjektID=2},
                new PersonProjekty {PersonID=2, ProjektID=3},
                new PersonProjekty {PersonID=3, ProjektID=3},
                new PersonProjekty {PersonID=3, ProjektID=4},
                new PersonProjekty {PersonID=3, ProjektID=5},

};
            context.PersonProjekts.AddRange(przypisanie);
            context.SaveChanges();

            

        }

    }
}
