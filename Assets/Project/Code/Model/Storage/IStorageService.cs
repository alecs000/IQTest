using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStorageServic
{
    void Save(string key, object data, Action<bool> callback = null);
    void Loud<T>(string key, Action<T> callback);
}
