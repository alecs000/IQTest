using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKeyboard : MonoBehaviour
{
    private TouchScreenKeyboard keyboard;
    void Start()
    {
        TouchScreenKeyboard.Android.consumesOutsideTouches = false;
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
}
