using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serwer.Models;
namespace Serwer.Controllers
{
    public class SingleProjekt
    {
        
        public static ICollection<Person> GetAllDataFromProjekt(ICollection<PersonProjekty> personyprojekty, ICollection<Person> person)
        {

            ICollection<Person> persony = new List<Person>();

            if (persony.Count == 0)

            {

                return persony;
            }

                else
            {



                foreach (PersonProjekty projekt in personyprojekty)

                {

                    foreach (Person ludzie in person)
                    {
                        if (ludzie.PersonID == projekt.PersonID)
                        {
                            persony.Add(ludzie);
                        }

                    }

                }

                return persony;

            }
            
            
        }

    }
}
