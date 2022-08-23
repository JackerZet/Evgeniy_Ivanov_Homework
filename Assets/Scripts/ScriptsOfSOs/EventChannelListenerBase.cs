using UnityEngine;
using UnityEngine.Events;

namespace MyGame.SO.Events
{
    [ExecuteInEditMode]
    public abstract class EventChannelListenerBase : MonoBehaviour
    {
        [TextArea]
        [SerializeField] private string _description;
    }
    public abstract class EventChannelListener : EventChannelListenerBase
    {
        public EventChannel GameAction;
        [SerializeField] public UnityEvent unityEvent;

        void OnEnable()
        {
            if (GameAction)
            {
                GameAction.RegisterListener(OnEventRaised);
            }
        }
        void OnDisable()
        {
            if (GameAction)
            {
                GameAction.UnregisterListener(OnEventRaised);
            }
        }         
        public void OnEventRaised()
        {
            unityEvent?.Invoke();
        }
    }

    public abstract class EventChannelListener<T> : EventChannelListenerBase//  where T: System.IComparable
    {
        public EventChannel<T> GameAction;
        [SerializeField]
        public UnityEvent<T> unityEvent;

        public virtual void OnEnable()
        {
            if (GameAction)
            {
                GameAction.RegisterListener(OnEventRaised);
            }
        }
        public virtual void OnDisable()
        {
            if (GameAction)
            {
                GameAction.UnregisterListener(OnEventRaised);
            }
        }        
        public virtual void OnEventRaised(T arg1)
        {
            unityEvent?.Invoke(arg1);           
        }
    }


    public abstract class EventChannelListener<T1, T2> : EventChannelListenerBase
    {
        public EventChannel<T1, T2> GameAction;
        [SerializeField]
        public UnityEvent<T1, T2> unityEvent;

        void OnEnable()
        {
            if (GameAction)
            {
                GameAction.RegisterListener(OnEventRaised);
            }
        }
        void OnDisable()
        {
            if (GameAction)
            {
                GameAction.UnregisterListener(OnEventRaised);
            }
        }        
        public void OnEventRaised(T1 arg1, T2 arg2)
        {
            unityEvent?.Invoke(arg1, arg2);
        }
    }
    public abstract class EventChannelListener<T1, T2, T3> : EventChannelListenerBase
    {
        public EventChannel<T1, T2, T3> GameAction;
        [SerializeField]
        public UnityEvent<T1, T2, T3> unityEvent;

        void OnEnable()
        {
            if (GameAction)
            {
                GameAction.RegisterListener(OnEventRaised);
            }
        }
        void OnDisable()
        {
            if (GameAction)
            {
                GameAction.UnregisterListener(OnEventRaised);
            }
        }        
        public void OnEventRaised(T1 arg1, T2 arg2, T3 arg3)
        {
            unityEvent?.Invoke(arg1, arg2, arg3);
        }
    }
    public abstract class EventChannelListener<T1, T2, T3, T4> : EventChannelListenerBase
    {
        public EventChannel<T1, T2, T3, T4> GameAction;
        [SerializeField]
        public UnityEvent<T1, T2, T3, T4> unityEvent;

        void OnEnable()
        {
            if (GameAction)
            {
                GameAction.RegisterListener(OnEventRaised);
            }
        }
        void OnDisable()
        {
            if (GameAction)
            {
                GameAction.UnregisterListener(OnEventRaised);
            }
        }       
        public void OnEventRaised(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            unityEvent?.Invoke(arg1, arg2, arg3, arg4);
        }
    }
}
