using System;
using System.Collections.Generic;

namespace HierarchicalDataStore
{
    public interface IOperations
    {
        void Create(string path, string data);

        bool Update(string path, string data);

        bool Delete(string path);

        string Get(string path);

        IEnumerable<Node> List(string path);
    }
}
