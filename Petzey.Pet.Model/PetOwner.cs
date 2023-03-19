using System.ComponentModel.DataAnnotations;

namespace Petzey.Pet.Model
{
    public class PetOwner
    {
        [Key]
        public Guid Id { get; set; }
        public string PetOwnerName { get; set; }
        public string PhoneNo { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }
    }
}