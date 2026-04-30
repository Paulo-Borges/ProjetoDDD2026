using Entities.EntidadesNoMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.InterfacesServicos
{
    public interface IPerguntaServico
    {

        //Com três Metodos
         
        Task AdicionarPesquisaOpcoes(PerguntaOpcoesDTO Resposta);

        Task AtualizarPesquisaOpcoes(PerguntaOpcoesDTO Resposta);

        Task<PerguntaOpcoesDTO> ObterPerguntaComOpcoes(int IdPergunta);
    }
}
