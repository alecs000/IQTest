using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputFieldWithoutNull : MonoBehaviour, IObservable<UnityAction<InputFieldWithoutNull, bool>>
{
    private UnityAction<InputFieldWithoutNull, bool> _onChange;

    public void AddObserver(UnityAction<InputFieldWithoutNull, bool> @delegate)
    {
        _onChange += @delegate;
    }

    public void RemoveObserver(UnityAction<InputFieldWithoutNull, bool> @delegate)
    {
        _onChange -= @delegate;

    }
    public void OnFieldChanged(string value)
    {
        if (value.Length > 0)
            _onChange?.Invoke(this, true);
        else
            _onChange?.Invoke(this, false);
    }
}
