using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Profiling;

public class Login : MonoBehaviour
{
    [SerializeField] private AuthorizationModule authorizationModule;
    [SerializeField] private DataBase dataBase;
    [SerializeField] private TMP_InputField emailInput;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private LoginView loginView;

    private bool _isAutorizated;

    public void LoginIn()
    {
        authorizationModule.SignIn(emailInput.text, passwordInput.text, OnLogin, OnLoginFailed);
    }
    public void OnLogin()
    {
        dataBase.AuthorizateUser(OnAutorizated);
    }
    private void OnAutorizated()
    {
        _isAutorizated = true;
    }
    private void Update()
    {
        if (_isAutorizated)
        {
            loginView.GoToProfile();
            _isAutorizated = false;
        }
    }
    public void OnLoginFailed(AuthError error)
    {
        loginView.ShowError();
    }
}
