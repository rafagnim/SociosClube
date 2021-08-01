using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Socios.Models
{
    public class Socio
    {
        public Socio(string nome, string telefone, DateTime dataNascimento, DateTime dataIngresso, Boolean ativo)
        {
            Nome = nome;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            DataIngresso = dataIngresso;
            Ativo = ativo;
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public String Nome { get; set; }
        public String Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataIngresso { get; set; }
        public Boolean Ativo { get; set; }
    }
}
