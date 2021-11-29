using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Repositories
{
    public interface IPersonRepository
    {
        public Person GetPersonById(int id);
        public List<Person> GetPersons();
        int AddPerson(Person person);
        List<Person> DeletePerson(int? id);
        List<Person> DeleteAllPersons();
        Person EditPerson(Person person);
    }
    
    public class PersonRepository : IPersonRepository
    {
        private List<Person> _persons = new List<Person>
        {
            new Person
            {
                FirstName = "Alberto",
                LastName = "Miorin",
                Id = 1
            },
            new Person
            {
                FirstName = "Filippo",
                LastName = "Miorin",
                Id = 2
            },
            new Person
            {
                FirstName = "Matteo",
                LastName = "Buonaccorsi",
                Id = 3
            }
        };
        
        public Person GetPersonById(int id)
        {
            return _persons.FirstOrDefault(n => n.Id == id);
        }

        public List<Person> GetPersons()
        {
            return _persons;
        }

        public int AddPerson(Person person)
        {
            var id = _persons.Max(x => x.Id) + 1;
            
            _persons.Add(new Person
            {
                Id = id,
                LastName = person.LastName,
                FirstName = person.FirstName
            });
            
            return person.Id;
        }

        public List<Person> DeletePerson(int? id)
        {
            _persons = _persons.Where(x => x.Id != id).ToList();
            return _persons;
        }

        public List<Person> DeleteAllPersons()
        {
            return new List<Person>();
        }

        public Person EditPerson(Person person)
        {
            // Person updatedPerson = Persons.FirstOrDefault(x => x.Id == person.Id);
            foreach (var x in _persons)
            {
                if (x.Id == person.Id)
                {
                    x.FirstName = person.FirstName;
                    x.LastName = person.LastName;
                }
            }

            return person;
        }
    }
}