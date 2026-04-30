using Domain.Interfaces;
using Entities.Entidades;
using Infra.Config;
using Infra.Repositorios.Genericos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repositorios
{
    public class PerguntasRepository : Repository<Pergunta>, IPerguntaRepository
    {


        public PerguntasRepository(PesquisaContext context): base(context) { }
    }
}
