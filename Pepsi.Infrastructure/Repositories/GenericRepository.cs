using Pepsi.Core.Entities;
using Pepsi.Infrastructure.DatabaseAccess;
using Pepsi.Core.Interfaces.Repositories;

namespace Pepsi.Infrastructure.Repositories;

public abstract class GenericRepository<TEntity>(IDatabaseAccessor dbAccessor, string tableName) : IRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly IDatabaseAccessor DbAccessor = dbAccessor;
    protected readonly string TableName = tableName;

    public virtual async Task<TEntity?> GetByIdAsync(int id)
    {
        var sql = $"SELECT * FROM {TableName} WHERE Id = @Id";
        return await DbAccessor.QuerySingleOrDefaultAsync<TEntity>(sql, new { Id = id }).ConfigureAwait(false);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var sql = $"SELECT * FROM {TableName}";
        return await DbAccessor.QueryAsync<TEntity>(sql).ConfigureAwait(false);
    }

    public virtual async Task<int> AddAsync(TEntity entity)
    {
        var properties = typeof(TEntity).GetProperties()
            .Where(p => p.Name != "Id")
            .Select(p => p.Name);
        IEnumerable<string> enumerable = properties.ToList();
        var columnNames = string.Join(", ", enumerable);
        var parameterNames = string.Join(", ", enumerable.Select(p => "@" + p));
        var sql = $"INSERT INTO {TableName} ({columnNames}) VALUES ({parameterNames}) RETURNING Id";

        return await DbAccessor.ExecuteScalarAsync<int>(sql, entity).ConfigureAwait(false);
    }


    public virtual async Task UpdateAsync(TEntity entity)
    {
        var properties = typeof(TEntity).GetProperties()
            .Where(p => p.Name != "Id")
            .Select(p => $"{p.Name} = @{p.Name}");

        var sql = $"UPDATE {TableName} SET {string.Join(", ", properties)} WHERE Id = @Id";
        await DbAccessor.ExecuteAsync(sql, entity).ConfigureAwait(false);
    }

    public virtual async Task DeleteAsync(int id)
    {
        var sql = $"DELETE FROM {TableName} WHERE Id = @Id";
        await DbAccessor.ExecuteAsync(sql, new { Id = id }).ConfigureAwait(false);
    }
}
