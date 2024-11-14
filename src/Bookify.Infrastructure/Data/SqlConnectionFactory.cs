using System.Data;
using Bookify.Application.Abstractions.Data;

namespace Bookify.Infrastructure.Data;

internal sealed class SqlConnectionFactory(string connectionString) : ISqlConnectionFactory
{
    public IDbConnection CreateConnection()
    {
        var connection = new Npgsql.NpgsqlConnection(connectionString);
        connection.Open();
        
        return connection;
    }
}