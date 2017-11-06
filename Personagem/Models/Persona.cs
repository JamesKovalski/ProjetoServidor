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

        public string Detalhe { get; set; }

        public int Poder { get; set; }

        public int Tamanho { get; set; }

    }
}