using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Repository.Store;

namespace DriverConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DataStore dataStore = DataStore.GetInstance();

            // add root node with data nothing
            dataStore.Create("/root", "nothing");


            // add two child nodes
            dataStore.Create("/root/child1", "childdata1");
            dataStore.Create("/root/child2", "childdata2");

            // add subchild to child node
            dataStore.Create("/root/child1/subchild1", "subchild1");

            // get and print the data for all nodes
            Console.WriteLine(dataStore.Get("/root"));
            Console.WriteLine(dataStore.Get("/root/child1"));
            Console.WriteLine(dataStore.Get("/root/child2"));
            Console.WriteLine(dataStore.Get("/root/child1/subchild1"));

            // list all child nodes for root
            IEnumerable<Node> allNodes = dataStore.List("/root");

            // delete the node child2
            dataStore.Delete("/root/child2");
        }
    }
}
