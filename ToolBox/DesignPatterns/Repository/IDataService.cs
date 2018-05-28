using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.DesignPatterns.Repository
{
    public interface IDataService<TEntity, TKey>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(TKey Key);
        TEntity Create(TEntity Entity);
        bool Update(TEntity Entity);
        bool Delete(TKey Key);
    }
}
