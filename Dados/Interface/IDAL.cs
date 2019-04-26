using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Interface
{
    public interface IDAL<T> : IDisposable where T : class
    {
        #region CRUD
        void Insert(T Model);
        void Update(T Model);
        IEnumerable<T> SelectAll();
        T SelectOneLine(int Id);
        int SelectIdentity();
        #endregion

        #region CRUD_ASYNC
        Task InsertAsync(T Model);
        Task UpdateAsync(T Model);
        Task<IEnumerable<T>> SelectAllAsync();
        Task<T> SelectOneLineAsync(int Id);
        Task<int> SelectIdentityAsync(); 
        #endregion
    }
}
