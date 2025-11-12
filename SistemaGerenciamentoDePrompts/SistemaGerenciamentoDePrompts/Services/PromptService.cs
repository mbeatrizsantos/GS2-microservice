using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using SistemaGerenciamentoDePrompts.Models;
using SistemaGerenciamentoDePrompts.Services.Interfaces;

namespace SistemaGerenciamentoDePrompts.Services
{
    public class PromptService : IPromptService
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public PromptService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection")!;
        }

        private SqliteConnection GetConnection()
        {
            return new SqliteConnection(_connectionString);
        }


        public async Task<int> CreatePromptAsync(Prompt prompt)
        {
            using (var connection = GetConnection())
            {
                var sql = "INSERT INTO Prompts (Titulo, Comando, DataCriacao) VALUES (@Titulo, @Comando, @DataCriacao); SELECT last_insert_rowid();";
                var newId = await connection.QuerySingleAsync<int>(sql, prompt);
                return newId;
            }
        }

        public async Task<IEnumerable<Prompt>> GetAllPromptsAsync()
        {
            using (var connection = GetConnection())
            {
                var sql = "SELECT * FROM Prompts";
                return await connection.QueryAsync<Prompt>(sql);
            }
        }

        public async Task<Prompt?> GetPromptByIdAsync(int id)
        {
            using (var connection = GetConnection())
            {
                var sql = "SELECT * FROM Prompts WHERE Id = @Id";
                return await connection.QuerySingleOrDefaultAsync<Prompt>(sql, new { Id = id });
            }
        }

        public async Task<bool> UpdatePromptAsync(Prompt prompt)
        {
            using (var connection = GetConnection())
            {
                var sql = "UPDATE Prompts SET Titulo = @Titulo, Comando = @Comando WHERE Id = @Id";
                var affectedRows = await connection.ExecuteAsync(sql, prompt);
                return affectedRows > 0; 
            }
        }

        public async Task<bool> DeletePromptAsync(int id)
        {
            using (var connection = GetConnection())
            {
                var sql = "DELETE FROM Prompts WHERE Id = @Id";
                var affectedRows = await connection.ExecuteAsync(sql, new { Id = id });
                return affectedRows > 0;
            }
        }
    }
}