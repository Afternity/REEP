namespace REEP.WPF_Client.Backend.Models.UserModels
{
    public class UserListVm
    {
        public ICollection<UserLookupDto> Users { get; set; } = [];
    }
}
