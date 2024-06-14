using Assignment_3.Models.DbModels;
using Assignment_3.Repository.Interfaces;
using System.Collections.Generic;
using System;
using AutoMapper;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

namespace Assignment_3.Repository
{
    public class ActorRepository : BaseRepository<Actor>, IActorRepository
    {
        public ActorRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public int Create(Actor actor)
        {
            return Add("[Foundation].[usp_AddActor]", new { Name = actor.Name, Dob = actor.DOB, Sex = actor.Gender, Bio = actor.Bio });
        }

        public void Delete(int id)
        {
            DeleteProcedure("[Foundation].[usp_DeleteActor]", new {Id= id});
        }

        public Actor GetById(int id)
        {
            var query = @"SELECT [PK_Id] AS Id
                        	,[Name]
                        	,[Sex] AS Gender
                        	,[Dob] AS DOB
                        	,[Bio]
                        FROM [IMDB].[Foundation].[Actors] WITH (NOLOCK)
                        WHERE PK_Id = @Id;";
            return Get(query, new { Id = id });
        }

        public List<Actor> GetAll()
        {
            string query = @"SELECT [PK_Id] as Id
                                ,[Name]
                                ,[Sex] as Gender
                                ,[Dob] as DOB
                                ,[Bio]
                            FROM [IMDB].[Foundation].[Actors] WITH (NOLOCK)";
            return Get(query);
        }

        public void Update(Actor actor)
        {
            Update("[Foundation].[usp_UpdateActor]", new { Id=actor.Id ,Name = actor.Name, Dob = actor.DOB, Sex = actor.Gender, Bio = actor.Bio });
        }
    }
}
