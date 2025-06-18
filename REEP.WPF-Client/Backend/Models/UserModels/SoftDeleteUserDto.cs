namespace REEP.WPF_Client.Backend.Models.UserModels
{
    public class SoftDeleteUserDto
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = true;
    }
}
