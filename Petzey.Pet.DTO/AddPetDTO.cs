using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.Pet.DTO
{
    public class AddPetDTO
    {
        public string PetName { get; set; }
        public string DateOfBirth { get; set; }
        public int Age { get; set; }
        public string BloodGroup { get; set; }
        public string Allergies { get; set; }
        public string Gender { get; set; }
        public string Species { get; set; }
        public string URL { get; set; }
    }
}
