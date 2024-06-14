using Assignment_3.Models.DbModels;
using Assignment_3.Models.RequestModels;
using Assignment_3.Models.ResponseModels;
using System.Collections.Generic;

namespace Assignment_3.Services.Interfaces
{
    public interface IProducerService
    {
        IList<ProducerResponse> Get();
        ProducerResponse Get(int id);
        int Create(ProducerRequest producer);
        void Update(Producer producer);
        void Delete(int id);
    }
}
