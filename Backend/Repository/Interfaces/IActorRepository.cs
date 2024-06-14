using Assignment_3.Models.DbModels;
using System.Collections;
using System.Collections.Generic;

namespace Assignment_3.Repository.Interfaces
{
    public interface IActorRepository
    {
        List<Actor> GetAll();
        Actor GetById(int id);
        int Create(Actor actor);
        void Update(Actor actor);
        void Delete(int id);

    }
}
