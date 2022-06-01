using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientesEmpresa.Infra.Data.Interfaces
{
    public interface IBaseRepository<TEntity>
          where TEntity : class
    {
        #region Métodos abstratos

        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        List<TEntity> GetAll();
        TEntity GetById(Guid id);

        #endregion
    }

}
