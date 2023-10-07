using eShop.UseCases.PluginInterfaces.StateStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.StateStore.DI {
    public class StateStoreBase : IStateStore {
        protected Action listeners;
        public void AddStateChangeListeners(Action listener) {
            listeners += listener;
        }
        public void RemoveStateChangeListeners(Action listener) {
            if (listeners != null) {
                listeners -= listener;
            }
        }
        public void BroadCastStateChange() {
           if (listeners != null) {
                listeners.Invoke();
            }
        }

    }
}
