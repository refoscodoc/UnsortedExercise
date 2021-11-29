using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using WebApplication.Models;
using WebApplication.Repositories;
using WebApplication.Validators;

namespace WebApplication.Services
{
    public interface IPersonService
    {
        List<Person> GetPerson(int? id);
        int AddPerson(Person person, out List<string> errors);
        List<Person> Delete(int? id);
        Person EditPerson(Person person);
    }
    
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonValidator _personValidator;

        public PersonService(IPersonRepository personRepository, IPersonValidator personValidator)
        {
            _personRepository = personRepository;
            _personValidator = personValidator;
        }
        public List<Person> GetPerson(int? id)
        {
            if (id == null || id == 0)
            {
                return _personRepository.GetPersons();
            }
            else
            {
                return new List<Person> {_personRepository.GetPersonById((int)id)};
            }
            
        }
        
        public int AddPerson(Person person, out List<string> errors)
        {
            if (!_personValidator.IsValid(person, out errors))
            {
                return 0;
            }
            
            return _personRepository.AddPerson(person);
        }

        public List<Person> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return _personRepository.DeleteAllPersons();
            }
            
            return _personRepository.DeletePerson(id);
        }

        public Person EditPerson(Person person)
        {
            if (person.Id == 0)
            {
                throw new Exception("The Id is not valid");
            }

            return _personRepository.EditPerson(person);
        }
    }
}