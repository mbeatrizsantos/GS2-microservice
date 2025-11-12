using Microsoft.Data.Sqlite;
using Dapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

Console.WriteLine("--- [TESTE DE CONEXÃO SQLITE] ---");
try
{
    using (var connection = new SqliteConnection(connectionString))
    {
        connection.Open();

        connection.Execute(@"
            CREATE TABLE IF NOT EXISTS Prompts (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Titulo TEXT,
                Comando TEXT NOT NULL,
                DataCriacao DATETIME DEFAULT CURRENT_TIMESTAMP
            );
        ");

        var result = connection.QuerySingle<int>("SELECT 1");

        Console.WriteLine($"[SUCESSO] Conexão com SQLite OK! Resultado do DB: {result}");
        Console.WriteLine("Arquivo 'meuprojeto.db' e tabela 'Prompts' foram criados/verificados.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"[ERRO] Falha ao conectar ao SQLite: {ex.Message}");
}
Console.WriteLine("-------------------------------------");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();