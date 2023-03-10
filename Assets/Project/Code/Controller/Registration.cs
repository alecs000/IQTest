using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Registration : MonoBehaviour
{
    private TouchScreenKeyboard keyboard;
    void Start()
    {
        keyboard =TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
}
