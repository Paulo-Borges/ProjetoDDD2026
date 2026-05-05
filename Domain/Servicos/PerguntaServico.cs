using Domain.Interfaces;
using Domain.InterfacesServicos;
using Entities.Entidades;
using Entities.EntidadesNoMap;

namespace Domain.Servicos
{
    public class PerguntaServico : IPerguntaServico
    {


        private readonly IPerguntaRepository _perguntaRepository;
        private readonly IOpcaoRepository _opcaoRepository;


        public PerguntaServico(IOpcaoRepository opcaoRepository, IPerguntaRepository perguntaRepository)
        {
            _opcaoRepository = opcaoRepository;
            _perguntaRepository = perguntaRepository;
        }


        public async Task AdicionarPesquisaOpcoes(PerguntaOpcoesDTO Resposta)
        {

            // 1 - Perguntas
            var pergunta = new Pergunta
            {
                Ativo= Resposta.Ativo, 
                IdPesquisa = Resposta.IdPesquisa, 
                Nome = Resposta.Nome
            };

            await _perguntaRepository.AddAsync(pergunta);

            //  Opcoes Vinculadas a perguntas criadas

            foreach (var item in Resposta.Opcao)
            {
                var opcao = new Opcao
                {
                    Peso = item.Peso,
                    Ativo = item.Ativo,
                    IdPergunta = item.IdPergunta,
                    Nome = item.Nome
                };

                await _opcaoRepository.AddAsync(opcao);
            }
        }

        public async Task AtualizarPesquisaOpcoes(PerguntaOpcoesDTO dto)
        {
            // bucar a pergunta 
            var pergunta = await _perguntaRepository.GetByIdAsync(dto.Id);
            if (pergunta == null)
                throw new Exception();
            // Atualiza a pergunta
            pergunta.Ativo = dto.Ativo;
            await _perguntaRepository.UpdateAsync(pergunta);

            // buscar as opções da pergunta

            var opcoesAtuais = (await _opcaoRepository.GetAllAsync())
                .Where(o => o.IdPergunta == pergunta.Id)
                .ToList();

            foreach (var opcaoDto in dto.Opcao)
            {
                if(opcaoDto.Id > 0)
                {
                    // Atualiza opção Existente
                    var opcaoExistente = opcoesAtuais
                        .FirstOrDefault(o => o.Id == opcaoDto.Id);

                    if(opcaoExistente != null)
                    {
                        opcaoExistente.Peso = opcaoDto.Peso;
                        opcaoExistente.Ativo = opcaoDto.Ativo;
                        opcaoExistente.Nome = opcaoDto.Nome;


                        await _opcaoRepository.UpdateAsync(opcaoExistente);
                        continue;

                    }
                }

                var opcao = new Opcao
                {
                    Peso = opcaoDto.Peso,
                    Ativo = opcaoDto.Ativo,
                    IdPergunta = opcaoDto.IdPergunta,
                    Nome = opcaoDto.Nome
                };

                await _opcaoRepository.AddAsync(opcao);

            }

            // Inativar opçoes removidas

            var idsRecebidos = dto.Opcao
                .Where(o => o.Id > 0)
                .Select(o => o.Id)
                .ToList();


            var opcoesRemovidas = opcoesAtuais
                .Where(o => !idsRecebidos.Contains(o.Id))
                .ToList();


            foreach (var opcoes in opcoesRemovidas)
            {
                opcoes.Ativo = false;
                await _opcaoRepository.UpdateAsync(opcoes);
            }

        }

        public async Task<PerguntaOpcoesDTO> ObterPerguntaComOpcoes(int idPergunta)
        {
            // Buscar a pergunta
            var pergunta = await _opcaoRepository.GetByIdAsync(idPergunta);

            if (pergunta == null)
                throw new Exception();
            //Buscar as opçoes da pergunta
            var opcoes = (await _opcaoRepository.GetAllAsync())
                .Where(o => o.IdPergunta == pergunta.Id && o.Ativo)
                .ToList();

            //Montar o DTO de retorno
            var dto = new PerguntaOpcoesDTO
            {
                Id = pergunta.Id,
                Nome = pergunta.Nome,
                Ativo = pergunta.Ativo,
                //IdPesquisa = pergunta.IdPesquisa,
                Opcao = opcoes.Select(o => new OpcaoDTO
                {
                    Id = o.Id,
                    Nome = o.Nome,
                    Ativo= o.Ativo,
                    Peso = o.Peso,
                }).ToList()
            };

            return dto;

        }
    }
}
