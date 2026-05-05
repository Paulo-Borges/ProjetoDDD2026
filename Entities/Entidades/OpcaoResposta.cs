using Entities.Notificacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entidades
{

    [Table("OpcaoResposta")]
    public class OpcaoResposta : Notifica
    {
        public int Id { get; set; }

        [ForeignKey("Resposta")]
        public int IdResposta { get; set; }

        [ForeignKey("Opcao")]
        public int IdOpcao { get; set; }
    }
}
