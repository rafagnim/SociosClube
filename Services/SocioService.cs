using MongoDB.Driver;
using System.Collections.Generic;
using Socios.Models;
using Microsoft.Extensions.Configuration;
using System;

namespace ApiSocios.Services
{
    public class SocioService
    {

        private const string DB_NAME = "SociosDB";
        private const string COLLECTION_NAME = "Socios";
        private readonly IMongoCollection<Socio> _socios;
        public SocioService(IConfiguration configuration)
        {
            try
            {
                var connectionString = configuration.GetSection("MongoDb:ConnectionString").Value;
                var mongoClient = new MongoClient(connectionString);
                var database = mongoClient.GetDatabase(DB_NAME);

                _socios = database.GetCollection<Socio>(COLLECTION_NAME);
            }
            catch (Exception ex)
            {
                throw new MongoException("Não foi possível conectar ao Banco de Dados", ex);
            }
        }

         //métodos implentados diretamente no Controller, para fins de prática e aprendizagem      

    }
}
