using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldsNotNull : MonoBehaviour
{
    [SerializeField] private Button loginButton;
    private bool _isEmailNotNull;
    private bool _isPassNotNull;
    public void OnEmailChanged(string email)
    {
        if(email.Length>0)
            _isEmailNotNull = true;
        TryActivateButton();
    }
    public void OnPasswordChanged(string pass)
    {
        if (pass.Length > 0)
            _isPassNotNull = true;
        TryActivateButton();
    }
    private void TryActivateButton()
    {
        if (_isEmailNotNull && _isPassNotNull)
            loginButton.interactable = true;
        else
            loginButton.interactable = false;
    }
}
