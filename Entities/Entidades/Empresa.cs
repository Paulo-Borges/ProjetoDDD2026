using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entidades
{

    [Table("Empresa")]   // Aqui é o nome da Tabela
    public class Empresa : Base
    {
        public string Documento { get; set; }

        public bool Ativo { get; set; }

    }
}
