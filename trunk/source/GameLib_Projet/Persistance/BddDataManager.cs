using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance
{
    class BddDataManager<T> : IDataManager<T> where T : class
    {
        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
