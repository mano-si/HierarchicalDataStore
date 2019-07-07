using System;
namespace Manohar.Singh.Data.Store
{
    public interface ISubscriber<TEventType>
    {
        void OnEventHandler(TEventType eventType);
    }
}
