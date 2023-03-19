using Petzey.Pet.DTO;
using Petzey.Pet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.Pet.Service.Service.Interface
{
    public interface IPetService
    {
        public List<ViewAllPetDTO> GetAllPet();
        public PetProfile AddPet(Guid Id,AddPetDTO addPetDTO);
        public PetOwner EditPetOwner(Guid Id,PetOwner petOwner);
        public PetOwnerDTO GetPetOwner(Guid Id);
    }
}
