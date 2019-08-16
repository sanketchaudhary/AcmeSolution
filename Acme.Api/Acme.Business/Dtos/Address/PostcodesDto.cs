namespace Acme.Business.Dtos.Address
{
    /// <summary>
    /// Dto class for holding Post Code details
    /// </summary>
    public class PostcodesDto
    {
        public virtual int Id { get; set; }
        public virtual string Pcode { get; set; }
    }
}
