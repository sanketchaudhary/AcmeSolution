namespace Acme.Business.Dtos.Address
{
    /// <summary>
    /// Dto class for holding Country details
    /// </summary>
    public class CountryDto
    {
        public virtual int CountryId { get; set; }
        public virtual string CountryName { get; set; }
    }
}
