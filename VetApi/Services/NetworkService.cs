using System;
using System.Collections.Generic;
using MongoDB.Driver;
using VetApi.Models;

namespace VetApi.Services
{
    public class NetworkService : IUserManagementService
    {
        private readonly IMongoCollection<Pet> _pets;
        private readonly IMongoCollection<Owner> _owners;
        private readonly IMongoCollection<Vet> _vets;
        private readonly IMongoCollection<Med> _med;
        private readonly IMongoCollection<Vacc> _vacc;

        public NetworkService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _pets = database.GetCollection<Pet>(settings.PetCollectionName);
            _owners = database.GetCollection<Owner>(settings.OwnersCollectionName);
            _vets = database.GetCollection<Vet>(settings.VetCollectionName);
            _med = database.GetCollection<Med>(settings.MedCollectionName);
            _vacc = database.GetCollection<Vacc>(settings.VaccCollectionName);
        }
        
        public List<Pet> GetAllPet() =>
            _pets.Find(pets => true).ToList();

        public Pet GetPet(string id) =>
            _pets.Find<Pet>(pets => pets.Id == id).FirstOrDefault();

        public List<Owner> GetAllOwner() =>
            _owners.Find(owners => true).ToList();

        public Owner GetOwner(string id) =>
            _owners.Find<Owner>(owners => owners.Id == id).FirstOrDefault();

        public List<Vet> GetAllVet() =>
            _vets.Find(vets => true).ToList();

        public Vet GetVet(string id) =>
            _vets.Find<Vet>(vets => vets.Id == id).FirstOrDefault();

        public List<Med> GetAllMed() =>
          _med.Find(med => true).ToList();

        public Med GetMed(string id) =>
            _med.Find<Med>(med => med.Id == id).FirstOrDefault();

        public List<Vacc> GetAllVacc() =>
          _vacc.Find(vacc => true).ToList();

        public Vacc GetVacc(string id) =>
            _vacc.Find<Vacc>(vacc => vacc.Id == id).FirstOrDefault();



        public Vet CreateVet(Vet vet)
        {
            _vets.InsertOne(vet);
            return vet;
        }

        public void UpdateVet(string id, Vet vetIn) =>
            _vets.ReplaceOne(vet => vet.Id == id, vetIn);

        public void RemoveVet(string id) =>
            _vets.DeleteOne(vet => vet.Id == id);



        public Pet CreatePet(Pet pets)
        {
            _pets.InsertOne(pets);
            return pets;
        }

        public void UpdatePet(string id, Pet petIn) =>
            _pets.ReplaceOne(pet => pet.Id == id, petIn);

        public void RemovePet(string id) =>
            _pets.DeleteOne(pet => pet.Id == id);

        public Owner CreateOwner(Owner owner)
        {
            _owners.InsertOne(owner);
            return owner;
        }

        public void UpdateOwner(string id, Owner ownerIn) =>
            _owners.ReplaceOne(owner => owner.Id == id, ownerIn);

        public void RemoveOwner(string id) =>
            _owners.DeleteOne(owner => owner.Id == id);




        public Med CreateMed(Med med)
        {
            _med.InsertOne(med);
            return med;
        }

        public void UpdateMed(string id, Med medIn) =>
            _med.ReplaceOne(med => med.Id == id, medIn);

        public void RemoveMed(string id) =>
            _med.DeleteOne(med => med.Id == id);


        public Vacc CreateVacc(Vacc vacc)
        {
            _vacc.InsertOne(vacc);
            return vacc;
        }

        public void UpdateVacc(string id, Vacc vaccIn) =>
            _vacc.ReplaceOne(vacc => vacc.Id == id, vaccIn);

        public void RemoveVacc(string id) =>
            _vacc.DeleteOne(vacc => vacc.Id == id);

        //CHECK USER
        public string IsValidUser(string username, string password)
        {
            if (_vets.Find<Vet>(vet => vet.Username == username && vet.Password == password).FirstOrDefault() != null) return "vet";
            if (_owners.Find<Owner>(owner => owner.Username == username && owner.Password == password).FirstOrDefault() != null) return "owner";
            return "null";
        }

    }

    public interface IUserManagementService
    {
        string IsValidUser(string username, string password);
    }
}
