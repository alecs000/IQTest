using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Login : MonoBehaviour
{
    [SerializeField] private AuthorizationModule authorizationModule;
    [SerializeField] private TMP_InputField emailInput;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private CanvasGroup error;
    [SerializeField] private UIView registration;
    [SerializeField] private UIView profile;
    [SerializeField] private ViewSwitch viewSwitch;
    
    public void LoginIn()
    {
        authorizationModule.SignIn(emailInput.text, passwordInput.text, OnLogin, OnLoginFailed);
        CanvasSetter.TurnOffCanvasGroup(error);
    }
    public void GoToRegistration()
    {
        viewSwitch.Switch(registration);
    }
    private void OnLogin()
    {
        viewSwitch.Switch(profile);
    }
    private void OnLoginFailed(AuthError error)
    {
        CanvasSetter.TurnOnCanvasGroup(this.error);
    }

}
