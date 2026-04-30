using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class  // Interface genérica, mas tem que ser uma class
    {
        Task<T> GetByIdAsync(int id);            // Busca um único registro do tipo T através do seu ID

        Task<IEnumerable<T>> GetAllAsync();       // Retorna uma lista de todos os registros daquela tabela

        Task AddAsync(T entity);                 //  Recebe um objeto do tipo T e Prepara para  inserção

        Task UpdateAsync(T entity);              // Recebe um objeto que já existe e atualiza seus dados.


        Task DeleteAsync(T entity);             // Remove o objeto especificado do banco de dados

    }
}
