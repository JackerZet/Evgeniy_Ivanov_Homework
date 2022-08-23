using UnityEngine.Events;

namespace MyGame.SO.Events
{
    public abstract class EventChannelBase : DescriptionBase
    {
        
    }
    
    public abstract class EventChannel : EventChannelBase
    {
        private UnityAction _onEventRaised;

        public virtual void RegisterListener(UnityAction action)
        {
            _onEventRaised += action;
        }

        public virtual void UnregisterListener(UnityAction action)
        {
            _onEventRaised -= action;
        }
        
        public virtual void RaiseEvent()
        {
            _onEventRaised?.Invoke();
        }
    }

    public abstract class EventChannel<T> : EventChannelBase
    {
        private UnityAction<T> _onEventRaised;
        
        public virtual void RegisterListener(UnityAction<T> action)
        {
            _onEventRaised += action;
        }

        public virtual void UnregisterListener(UnityAction<T> action)
        {
            _onEventRaised -= action;
        }        
        
        public virtual void RaiseEvent(T arg1)
        {
            _onEventRaised?.Invoke(arg1);
        }
    }
    
    public abstract class EventChannel<T1, T2> : EventChannelBase
    {
        private UnityAction<T1, T2> _onEventRaised;
        
        public virtual void RegisterListener(UnityAction<T1, T2> action)
        {
            _onEventRaised += action;
        }

        public virtual void UnregisterListener(UnityAction<T1, T2> action)
        {
            _onEventRaised -= action;
        }        
        
        public virtual void RaiseEvent(T1 arg1, T2 arg2)
        {
            _onEventRaised?.Invoke(arg1, arg2);
        }
    }
    
    public abstract class EventChannel<T1, T2, T3> : EventChannelBase
    {
        private UnityAction<T1, T2, T3> _onEventRaised;
        
        public virtual void RegisterListener(UnityAction<T1, T2, T3> action)
        {
            _onEventRaised += action;
        }

        public virtual void UnregisterListener(UnityAction<T1, T2, T3> action)
        {
            _onEventRaised -= action;
        }        
        
        public virtual void RaiseEvent(T1 arg1, T2 arg2, T3 arg3)
        {
            _onEventRaised?.Invoke(arg1, arg2, arg3);
        }
    }
    
    public abstract class EventChannel<T1, T2, T3, T4> : EventChannelBase
    {
        private UnityAction<T1, T2, T3, T4> _onEventRaised;
        
        public virtual void RegisterListener(UnityAction<T1, T2, T3, T4> action)
        {
            _onEventRaised += action;
        }

        public virtual void UnregisterListener(UnityAction<T1, T2, T3, T4> action)
        {
            _onEventRaised -= action;
        }
               
        public virtual void RaiseEvent(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            _onEventRaised?.Invoke(arg1, arg2, arg3, arg4);
        }
    }
}
