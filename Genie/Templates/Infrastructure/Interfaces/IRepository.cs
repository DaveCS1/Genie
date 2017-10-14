#region Usings

using Genie.Core.Base.Generating.Concrete;

#endregion

namespace Genie.Core.Templates.Infrastructure.Interfaces
{
    internal class IRepositoryTemplate : GenieTemplate
    {
        public IRepositoryTemplate(string path) : base(path)
        {
        }

        public override string Generate()
        {
            L($@"

using System.Collections.Generic;
using System.Data;
using {GenerationContext.BaseNamespace}.Infrastructure.Models.Concrete;
using {GenerationContext.BaseNamespace}.Infrastructure.Filters.Abstract;

namespace {GenerationContext.BaseNamespace}.Infrastructure.Interfaces
{{
	public interface IRepository<T>
        where T : BaseModel
    {{
        IDbConnection Conn {{ get; }}
        IDapperContext Context {{ get; }}

        void Add(T entity, IDbTransaction transaction = null, int? commandTimeout = null);
        void Add(IEnumerable<T> entities, IDbTransaction transaction = null, int? commandTimeout = null);
        void Remove(T entity, IDbTransaction transaction = null, int? commandTimeout = null);
        void Remove(IEnumerable<T> entity, IDbTransaction transaction = null, int? commandTimeout = null);

        IEnumerable<T> Get(IRepoQuery query);
		T GetFirstOrDefault(IRepoQuery query);
	    int Count(IRepoQuery query);
		string GetWhereClause(IRepoQuery query);
    }}
}}
");

            return E();
        }
    }
}