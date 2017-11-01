using System.Data.Entity;

namespace Web.Models.Contexto
{
    public class Contexto : DbContext
    {
        public Contexto() : base("strConn")
        {

        }

        public System.Data.Entity.DbSet<Personagem.Models.Persona> Personas { get; set; }
    }
}