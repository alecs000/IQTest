using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InitializeEvents<T> where T : Delegate
{
    public void AddListener(T @delegate);
    public void RemoveListener(T @delegate);

}