namespace REEP.WPF_Client.Backend.Models.UserModels.AuthModels
{
    public static class UserModelExtensions
    {
        public static UserFromAuthDetailsVm ToUserFromAuthDetails(this UserDetailsVm userDetails)
        {
            return new UserFromAuthDetailsVm
            {
                Id = userDetails.Id,
                FirstName = userDetails.FirstName,
                SecondName = userDetails.SecondName,
                LastName = userDetails.LastName,
                Email = userDetails.Email,
                OtherContacts = userDetails.OtherContacts,
                Password = userDetails.Password,
                CreatedAt = userDetails.CreatedAt,
                UpdatedAt = userDetails.UpdatedAt,
                DeletedAt = userDetails.DeletedAt,
                IsDeleted = userDetails.IsDeleted,
                Type = userDetails.Type
            };
        }
    }
}
