using Assignment_3.Models.DbModels;
using Assignment_3.Models.RequestModels;
using Assignment_3.Models.ResponseModels;
using Assignment_3.Repository.Interfaces;
using Assignment_3.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_3.Services
{
    public class ActorService : IActorService
    {
        private IActorRepository _actorRepository;
        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository= actorRepository;
        }

        public void checkActor(int id)
        {
            if (id == 0)
                throw new ArgumentException("Id should not be zero");
            var actor = _actorRepository.GetById(id);
            if (actor == null)
                throw new KeyNotFoundException("Actor Not Found!");
        }

        public int Create(ActorRequest actormodel)
        {
            var actor = new Actor { 
                Name= actormodel.Name,
                Bio = actormodel.Bio,
                DOB= actormodel.DOB,
                Gender= actormodel.Gender
            };
            var id = _actorRepository.Create(actor);
            return id;
        }

        public void Delete(int id)
        {
            checkActor(id);
            _actorRepository.Delete(id);
        }

        public List<ActorResponse> Get()
        {
            return _actorRepository.GetAll().Select(a=>new ActorResponse { Name=a.Name,Id=a.Id,Gender=a.Gender,Bio=a.Bio,DOB=a.DOB}).ToList();
        }

        public ActorResponse Get(int id)
        {
            checkActor(id);
            var actor=_actorRepository.GetById(id);

            return new ActorResponse
            {
                Id= actor.Id,
                Name= actor.Name,
                Bio= actor.Bio,
                DOB= actor.DOB,
                Gender= actor.Gender
            };
        }

        public void Update(Actor actor)
        {
            checkActor(actor.Id);
            _actorRepository.Update(actor);
        }
    }
}
