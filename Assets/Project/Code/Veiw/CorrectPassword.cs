using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectPassword : MonoBehaviour
{
    [SerializeField] private CanvasGroup passwordIsTooSmall;
    private bool _isPasswordIsTooSmall;

    public void OnDeselect(string password)
    {
        if (password.Length <= 5)
        {
            CanvasSetter.TurnOnCanvasGroup(passwordIsTooSmall);
            _isPasswordIsTooSmall = true;
        }
    }
    public void OnPasswordValueChange(string password)
    {
        if (password.Length > 5)
        {
            if (!_isPasswordIsTooSmall)
            {
                return;
            }
            CanvasSetter.TurnOffCanvasGroup(passwordIsTooSmall);
            _isPasswordIsTooSmall = false;
        }
    }
}
