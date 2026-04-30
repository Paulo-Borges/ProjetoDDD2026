using Domain.InterfacesServicos;
using Entities.EntidadesNoMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Servicos
{
    public class PerguntaServico : IPerguntaServico
    {


        public PerguntaServico()
        {

        }


        public async Task AdicionarPesquisaOpcoes(PerguntaOpcoesDTO Resposta)
        {
            throw new NotImplementedException();
        }

        public async Task AtualizarPesquisaOpcoes(PerguntaOpcoesDTO Resposta)
        {
            throw new NotImplementedException();
        }

        public async Task<PerguntaOpcoesDTO> ObterPerguntaComOpcoes(int IdPergunta)
        {
            throw new NotImplementedException();
        }
    }
}
