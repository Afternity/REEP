namespace REEP.Domain.InterfaceModels
{
    public interface IAuditable
    {
        DateTime CreateDate { get; set; } 
        DateTime? UpdateDate { get; set; }
    }
}
