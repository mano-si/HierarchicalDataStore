using System;
namespace HierarchicalDataStore
{
    public class NodeChangedArgs : EventArgs
    {
        public string operation { get; set; }
        public string name { get; set; }
    }
}
