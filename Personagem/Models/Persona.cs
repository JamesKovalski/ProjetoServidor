using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personagem.Models
{
    public class Persona
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int Força { get; set; }

        public int Peso { get; set; }

    }
}