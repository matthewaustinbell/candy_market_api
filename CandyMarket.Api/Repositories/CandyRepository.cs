using System;
using System.Collections.Generic;
using CandyMarket.Api.DataModels;
using System.Data.SqlClient;
using CandyMarket.Api.Dtos;
using Dapper;

namespace CandyMarket.Api.Repositories
{
    public class CandyRepository : ICandyRepository
    {
        private string _connectionString = "Server=localhost;Database=CandyMarket;Trusted_Connection=True;";
       
        public IEnumerable<Candy> GetAllCandy()
        {
                    using (var db = new SqlConnection(_connectionString))
                    {

                        var candys = db.Query<Candy>("Select * From candy");

                        return candys.AsList();
                    }
        }
            

        public bool AddCandy(AddCandyDto newCandy)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql =
                    @"INSERT INTO [Candy]
                                           ([Name]
                                           ,[YearsOfExperience]
                                           ,[Specialty])
	                                 output inserted.*
                                     VALUES
                                           (@name
                                           ,@yearsOfExperience
                                           ,@specialty)";

                return db.QueryFirst<Candy>(sql, newCandy);

                //33:24
            }
        }

        public bool EatCandy(Guid candyIdToDelete)
        {
            throw new NotImplementedException();
        }
    }
}