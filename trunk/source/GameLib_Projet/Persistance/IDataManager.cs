using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance
{
    public interface IDataManager<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetByName(string name);
    }
}
