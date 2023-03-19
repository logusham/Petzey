using Petzey.Pet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.Pet.Repository.Interface
{
    public interface IPetRepository
    {
        public List<PetProfile> GetAllPet();
        public bool AddPet(PetProfile petProfile);
        public PetOwner EditPetOwner(Guid Id,PetOwner petOwner);
        public PetOwner GetPetOwner(Guid Id);
    }
}
