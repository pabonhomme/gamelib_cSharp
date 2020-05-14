using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance
{
    public abstract class StubDataManager<T> : IDataManager<T> where T : class
    {
        protected List<T> MyCollection { get; set; } = new List<T>();
        public IEnumerable<T> GetAll()
        {
            return MyCollection;
        }

        public abstract T GetByName(string name);
        
    }
}
