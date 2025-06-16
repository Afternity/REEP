namespace REEP.WPF_Client.Backend.Services.IApiServices.IAuthApiServices
{
    public interface IAuthService
    {
        Task<bool> AuthAsync(string username, string password);
        Task<bool> RegisterAsync(
            string firstName,
            string secondName,
            string lastName,
            string email,
            string otherContacts,
            string password);
    }
}
