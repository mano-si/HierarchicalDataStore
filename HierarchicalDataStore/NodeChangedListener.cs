using System;
namespace Manohar.Singh.Data.Store
{
    public class NodeChangedListener
    {
        public void NodeCreatedHandler(object sender, EventArgs eventArgs)
        { 
            // handle here
        }

        public void NodeUpdatedHandler(object sender, EventArgs eventArgs)
        {
            // handle here
        }

        public void NodeDeletedHandler(object sender, EventArgs eventArgs)
        {
            // handle here
        }

        public void PrintEvent(object sender, NodeChangedArgs eventArgs)
        {
            Console.WriteLine("{0} : Event happened in {1}", eventArgs.operation, eventArgs.name);
        }
    }
}
