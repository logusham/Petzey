using AutoMapper;
using Petzey.Pet.DTO;
using Petzey.Pet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.Pet.Service.PetMapping
{
    public class MappingPetProfile : Profile
    {
        public MappingPetProfile()
        {
            this.CreateMap<PetProfile, ViewAllPetDTO>();
            this.CreateMap<AddPetDTO, PetProfile>();
            this.CreateMap<PetOwner, PetOwnerDTO>();
        }
    }
}
