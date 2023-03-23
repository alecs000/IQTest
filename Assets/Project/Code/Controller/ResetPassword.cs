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
    public void TryToReset()
    {
        module.SendEmailReset(email.text, OnResetCompleted, OnResetFailed);
    }
    private void OnResetFailed(AuthError error)
    {
        resetView.ShowError();
    }
    private void OnResetCompleted()
    {
        resetView.GoToResetSendedNotification();
    }
}
