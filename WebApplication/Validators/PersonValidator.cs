using System.Collections.Generic;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Validators
{
    public interface IPersonValidator
    {
        bool IsValid(Person person, out List<string> errors);
    }
    
    public class PersonValidator : IPersonValidator
    {
        public bool IsValid(Person person, out List<string> errors)
        {
            errors = new List<string>();

            if (string.IsNullOrEmpty(person.FirstName))
            {
                errors.Add("First Name cannot be null");
            }
            
            if (string.IsNullOrEmpty(person.LastName))
            {
                errors.Add("Last Name cannot be null");
            }

            return !errors.Any();
        }
    }
}