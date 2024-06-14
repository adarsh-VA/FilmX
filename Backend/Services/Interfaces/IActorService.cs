using Assignment_3.Models.DbModels;
using Assignment_3.Models.RequestModels;
using Assignment_3.Models.ResponseModels;
using System.Collections.Generic;

namespace Assignment_3.Services.Interfaces
{
    public interface IActorService
    {
        List<ActorResponse> Get();
        ActorResponse Get(int id);
        int Create(ActorRequest actormodel);
        void Update(Actor actor);
        void Delete(int id);
    }
}
