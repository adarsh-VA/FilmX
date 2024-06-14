using Assignment_3.Models.DbModels;
using Assignment_3.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Assignment_3.Repository
{
    public class ProducerRepository : BaseRepository<Producer>, IProducerRepository
    {
        public ProducerRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public int Create(Producer producer)
        {
            return Add("[Foundation].[usp_AddProducer]", new { Name = producer.Name, Dob = producer.DOB, Sex = producer.Gender, Bio = producer.Bio });
        }

        public void Delete(int id)
        {
            var query = @"DELETE Foundation.Producers WHERE PK_Id = @Id;";
            var producerQuery = @"SELECT PK_Id
                                    FROM Foundation.Movies
                                    WHERE FK_ProducerId = @Id;";
            var movieIds = GetIds(producerQuery,new { Id = id});
            foreach (var mId in movieIds)
            {
                DeleteProcedure("[Foundation].[usp_DeleteMovie]", new { Id = mId });
            }
            Delete(query, new { Id = id });
        }

        public IList<Producer> GetAll()
        {
            string query = @"SELECT [PK_Id] as Id
                                ,[Name]
                                ,[Sex] as Gender
                                ,[Dob] as DOB
                                ,[Bio]
                            FROM [IMDB].[Foundation].[Producers] WITH (NOLOCK)";
            return Get(query);
        }

        public Producer GetById(int id)
        {
            var query = @"SELECT [PK_Id] AS Id
                        	,[Name]
                        	,[Sex] AS Gender
                        	,[Dob] AS DOB
                        	,[Bio]
                        FROM [IMDB].[Foundation].[Producers] WITH (NOLOCK)
                        WHERE PK_Id = @Id;";
            return Get(query, new { Id = id });
        }

        public void Update(Producer producer)
        {
            Update("[Foundation].[usp_UpdateActor]", new { Id = producer.Id, Name = producer.Name, Dob = producer.DOB, Sex = producer.Gender, Bio = producer.Bio });
        }
    }
}
