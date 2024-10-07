namespace Lr6.Net.Interfaces
{
    public interface IAgeValidationService
    {
        bool IsValidAge(DateTime dateOfBirth, int minimumAge);
    }
}
