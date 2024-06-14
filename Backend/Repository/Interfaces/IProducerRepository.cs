using Assignment_3.Models.DbModels;
using System.Collections.Generic;

namespace Assignment_3.Repository.Interfaces
{
    public interface IProducerRepository
    {
        IList<Producer> GetAll(); 
        Producer GetById(int id); 
        int Create(Producer producer); 
        void Update(Producer producer); 
        void Delete(int id);
    }
}
