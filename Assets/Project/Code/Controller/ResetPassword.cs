using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResetPassword : MonoBehaviour
{
    [SerializeField] private AuthorizationModule module;
    [SerializeField] private TMP_InputField email;
    [SerializeField] private ResetPasswordView resetView;
    private bool _isResetCompleted;
    private bool _isResetFailed;
    public void TryToReset()
    {
        module.SendEmailReset(email.text, OnResetCompleted, OnResetFailed);
    }
    private void OnResetFailed(AuthError error)
    {
        _isResetFailed = true;
    }
    private void OnResetCompleted()
    {
        _isResetCompleted = true;
    }
    private void Update()
    {
        if (_isResetCompleted)
        {
            resetView.GoToResetSendedNotification();
            _isResetCompleted = false;
        }
        if (_isResetFailed)
        {
            resetView.ShowError();
            _isResetFailed = false;
        }
    }
}
