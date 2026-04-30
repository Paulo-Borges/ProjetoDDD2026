using Domain.Interfaces;
using Domain.InterfacesServicos;
using Domain.Servicos;
using Infra.Repositorios.Genericos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repositorios
{
    public static class RepositoryServiceCollectionExtension
    {
        public static IServiceCollection AddEfRepositories(this IServiceCollection services)     // Método vai conter todos os repositorios e interfaces
        {

            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IPesquisaRepository, PesquisaRepository>();
            services.AddScoped<IPerguntaRepository, PerguntasRepository>();
            services.AddScoped<IOpcaoRepository, OpcaoRepository>();

            services.AddScoped<IRespostaRepository, RespostaRepository>();
            services.AddScoped<IOpcaoRespostaRepository, OpcaoRespostaRepository>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


            services.AddScoped<IRespostaServico, RespostaServico>();
            services.AddScoped<IPerguntaServico, PerguntaServico>();


            return services;

        }
    }
}
