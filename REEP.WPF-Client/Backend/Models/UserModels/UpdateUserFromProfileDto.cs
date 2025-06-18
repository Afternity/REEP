namespace REEP.WPF_Client.Backend.Models.UserModels
{
    public class UpdateUserFromProfileDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string? OtherContacts { get; set; }
        public string Password { get; set; } = null!;
        public string Type { get; set; } = null!;
    }
}
