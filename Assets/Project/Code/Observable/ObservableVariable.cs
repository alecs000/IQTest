using System;

public class ObservableVariable<T>: IObservable<Action<T>>
{
    protected event Action<T> OnChanged;
    private T _value;
    public T Value
    {
        get { return _value; }
        set
        {
            T oldValue = _value;
            _value = value;
            OnChanged?.Invoke(value);
        }
    }
    public ObservableVariable()
    {
        Value = default;
    }

    public ObservableVariable(T value)
    {
        Value = value;
    }
    public override string ToString()
    {
        return Value.ToString();
    }
    public void AddObserver(Action<T> @delegate)
    {
        OnChanged += @delegate;
    }

    public void RemoveObserver(Action<T> @delegate)
    {
        OnChanged -= @delegate;
    }
}