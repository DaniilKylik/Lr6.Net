using Lr6.Net.Interfaces;

namespace Lr6.Net.Services
{
    public class AgeValidationService : IAgeValidationService
    {
        public bool IsValidAge(DateTime dateOfBirth, int minimumAge)
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTime.Now.AddYears(-age)) age--;
            return age >= minimumAge;
        }
    }
}
