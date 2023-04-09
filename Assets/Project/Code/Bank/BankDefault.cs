using System;
using UnityEngine;


    public abstract class BankDefault : MonoBehaviour, IObservable<Action<int>>
    {
        protected ObservableVariable<int> _bankValue;
        public int Value => _bankValue.Value;
        void Awake()
        {
            Initialize();
        }
        protected virtual void Initialize()
        {
            _bankValue = new ObservableVariable<int>(0);
        }

        public virtual void Add(int value)
        {
            _bankValue.Value += value;
        }

        public virtual bool TryRemove(int value)
        {
            if (_bankValue.Value >= value)
            {
                _bankValue.Value -= value;
                return true;
            }
            return false;
        }
    public void AddObserver(Action<int> @delegate)
    {
        _bankValue.AddObserver(@delegate);
    }

    public void RemoveObserver(Action<int> @delegate)
    {
        _bankValue.RemoveObserver(@delegate);
    }
}
