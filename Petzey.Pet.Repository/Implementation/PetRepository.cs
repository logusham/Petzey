using Microsoft.EntityFrameworkCore;
using Petzey.Pet.Model;
using Petzey.Pet.Repository.DataAccessLayer;
using Petzey.Pet.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.Pet.Repository.Implementation
{
    public class PetRepository : IPetRepository
    {
        private PetDbContext db;
        public PetRepository(PetDbContext petDb)
        {
            db = petDb;
        }

        public bool AddPet(PetProfile petProfile)
        {
            
            db.PetProfile.Add(petProfile);
            db.SaveChanges();
            return true;
        }

        public PetOwner AddPetOwner(PetOwner petOwner)
        {
            petOwner.Id = Guid.NewGuid();
            db.PetOwner.Add(petOwner);
            db.SaveChanges();
            return petOwner;
        }

        public PetOwner EditPetOwner(Guid Id, PetOwner petOwner)
        {
            var existingPetOwner = db.PetOwner.FirstOrDefault(x => x.Id == Id);
            if (existingPetOwner != null)
            {
                existingPetOwner.PetOwnerName = petOwner.PetOwnerName;
                existingPetOwner.PhoneNo = petOwner.PhoneNo;
                existingPetOwner.Location = petOwner.Location;
                existingPetOwner.ImageUrl = petOwner.ImageUrl;
                db.SaveChangesAsync();
            }
            return existingPetOwner;
        }

        public List<PetProfile> GetAllPet()
        {
            return (db.PetProfile.ToList());
        }

        public PetOwner GetPetOwner(Guid Id)
        {
            var petOwner = db.PetOwner.Where(x => x.Id == Id).First();
            if (petOwner != null)
            {
                return petOwner;
            }
            return null;
        }
    }
}
