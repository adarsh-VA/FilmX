using Assignment_3.Models.DbModels;
using Assignment_3.Models.RequestModels;
using Assignment_3.Models.ResponseModels;
using Assignment_3.Repository;
using Assignment_3.Repository.Interfaces;
using Assignment_3.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_3.Services
{
    public class ProducerService : IProducerService
    {
        private IProducerRepository _producerRepository;
        public ProducerService(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }
        public void checkProducer(int id)
        {
            if (id == 0)
                throw new ArgumentException("Id should not be zero");
            if (_producerRepository.GetById(id) == null)
                throw new KeyNotFoundException("Producer Not Found!");
        }

        public int Create(ProducerRequest producermodel)
        {
            var producer = new Producer
            {
                Name= producermodel.Name,
                Bio = producermodel.Bio,
                DOB= producermodel.DOB,
                Gender= producermodel.Gender,
            };
            
            return _producerRepository.Create(producer);
        }

        public void Delete(int id)
        {
            checkProducer(id);
            _producerRepository.Delete(id);
        }

        public IList<ProducerResponse> Get()
        {
            return _producerRepository.GetAll().Select(p=> new ProducerResponse { Id=p.Id,Name=p.Name,Bio=p.Bio,DOB=p.DOB,Gender=p.Gender}).ToList();
        }

        public ProducerResponse Get(int id)
        {
            checkProducer(id);
            var producer = _producerRepository.GetById(id);
            return new ProducerResponse { Id = producer.Id, Name = producer.Name, Gender = producer.Gender, Bio = producer.Bio, DOB = producer.DOB };
        }

        public void Update(Producer producer)
        {
            checkProducer(producer.Id);
            _producerRepository.Update(producer);
        }
    }
}
