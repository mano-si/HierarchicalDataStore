using System;
using System.Collections.Generic;
using System.Linq;

namespace HierarchicalDataStore
{
    public class DataStore : IOperations
    {
        private static readonly DataStore _datastore = new DataStore();
        private Node _rootNode;

        public static DataStore GetInstance()
        {
            return _datastore;
        }

        public Node RootNode
        {
            get 
            {
                return this._rootNode; 
            }

            set
            {
                if (this._rootNode != null)
                {
                    // log and raise error
                }

                this._rootNode = value;
            }
        }

        // event handlers not wired yet
        public void Create(string path, string data)
        {
            string[] nodeNames = StringHelper.ParseString(path);

            if (nodeNames[1] != "root")
            {
                // raise error and return null. perhaps log it
                return;
            }

            if (this.RootNode == null)
            {
                this._rootNode = new Node(nodeNames[1], data);
            }

            Node parent = RootNode;

            for (int i = 2; i < nodeNames.ToList().Count; i++)
            {
                string nodeName = nodeNames[i];

                if (parent.TryGetChild(nodeNames[i], out Node node))
                {
                    parent = node;
                    continue;
                }

                else
                {
                    Node childNode = new Node(nodeName, data);

                    parent.AddChild(childNode);

                    parent = childNode;
                }

            }

        }

        // event handlers not wired yet
        public bool Delete(string path)
        {
            string[] nodeNames = StringHelper.ParseString(path);

            if (nodeNames[1] != "root")
            {
                // raise error and return null. perhaps log it
                return false;
            }

            if (nodeNames.ToList().Count == 2) // delete root
            {
                this._rootNode = null;

                return true;
            }
            Node parent = RootNode;

            if (nodeNames.ToList().Count == 3) // only one level root
            {
                if (parent.TryGetChild(nodeNames[2], out Node node))
                {
                    parent.RemoveChild(nodeNames[2]);
                }

                return true;
            }


            for (int i = 2; i < nodeNames.ToList().Count - 1; i++)
            {
                 
                if (parent.TryGetChild(nodeNames[i], out Node node))
                {
                    parent = node;
                }

            }

            parent.RemoveChild(nodeNames[nodeNames.ToList().Count - 1]);

            return true;
        }

        // event handlers not wired yet
        public string Get(string path)
        {
            string[] nodeNames = StringHelper.ParseString(path);

            if (nodeNames[1] != "root")
            {
                // raise error and return null. perhaps log it
                return null;
            }

            Node parent = RootNode;

            if (nodeNames.ToList().Count == 2) // root
            {
                return parent.Data;
            }

            for (int i = 2; i < nodeNames.ToList().Count; i++)
            {
                if (parent.TryGetChild(nodeNames[i], out Node node))
                {
                    parent = node;

                }
            }

            return parent.Data;

        }


        public IEnumerable<Node> List(string path)
        {
            string[] nodeNames = StringHelper.ParseString(path);

            if (nodeNames[1] != "root")
            {
                // raise error and return null. perhaps log it
                return null;
            }

            Node parent = RootNode;

            if (nodeNames.ToList().Count == 2) // root
            {
                return parent.ChildNodes;
            }

            for (int i = 2; i < nodeNames.ToList().Count; i++)
            {
                if (parent.TryGetChild(nodeNames[i], out Node node))
                {
                    parent = node;
                }
            }

            return parent.ChildNodes;
        }

        // event handlers not wired yet
        public bool Update(string path, string data)
        {
            string[] nodeNames = StringHelper.ParseString(path);

            if (nodeNames[1] != "root")
            {
                // raise error and return null. perhaps log it
                return false;
            }

            Node parent = RootNode;

            if (nodeNames.ToList().Count == 2) // root
            {
                parent.Data = data;

                return true;
            }

            for (int i = 2; i < nodeNames.ToList().Count; i++)
            {
                if (parent.TryGetChild(nodeNames[i], out Node node))
                {
                    parent = node;
                }
            }

            parent.Data = data;

            return false;
        }
    }
}
