using MySql.Data.MySqlClient;

namespace DataAccess.Repositories;

public abstract class RepositoryBase
{
    private readonly string _connectionString;
    
    public RepositoryBase(string connectionString)
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        _connectionString = connectionString;
    }

    public MySqlConnection Connection()
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            return connection;
        } 
    }
    
}