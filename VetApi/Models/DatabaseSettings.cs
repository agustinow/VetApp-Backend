using System;
namespace VetApi.Models
{
    public class DatabaseSettings: IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string VetCollectionName { get; set; }
        public string PetCollectionName { get; set; }
        public string MedCollectionName { get; set; }
        public string VaccCollectionName { get; set; }
        public string OwnersCollectionName { get; set; }
    }

    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string VetCollectionName { get; set; }
        string PetCollectionName { get; set; }
        string MedCollectionName { get; set; }
        string VaccCollectionName { get; set; }
        string OwnersCollectionName { get; set; }
    }
}
