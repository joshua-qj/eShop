using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.UseCases.PluginInterfaces.StateStore {
    public interface IStateStore {
        //register as a listener
        void AddStateChangeListeners(Action listener);
        void RemoveStateChangeListeners(Action listener);
        //broadcast to all listener
        void BroadCastStateChange();
    }
}
