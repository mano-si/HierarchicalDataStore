using System;
using System.Collections.Generic;

namespace HierarchicalDataStore
{
    public class Node
    {
        public Node(string name, string data)
        {
            this.Name = name;
            this.Data = data;
        }

        public List<Node> ChildNodes { get; set; } = new List<Node>();

        public string Name { get; set; }

        public string Data { get; set; }

        public void AddChild(Node child)
        {
            this.ChildNodes.Add(child);
        }

        public bool TryGetChild(string name, out Node child)
        {
            child = null;

            foreach (var curChild in ChildNodes)
            {
                if (curChild.Name == name)
                {
                    child = curChild;

                    return true;
                }
            }

            return false;
        }

        public void RemoveChild(string name)
        {
            foreach (var curChild in ChildNodes)
            {
                if (curChild.Name == name)
                {
                    this.ChildNodes.Remove(curChild);
                    return;
                }
            }
        }
    }
}
