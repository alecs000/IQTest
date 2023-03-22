using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;

public class Registration : MonoBehaviour
{
    [Header("View")]
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TMP_InputField emailInput;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private ErrorRegistration errorRegistration;
    [SerializeField] private UIView waitVerificationView;
    [SerializeField] private UIView surveyNotificationView;
    [SerializeField] private UIView loginView;
    [SerializeField] private ViewSwitch viewSwitch;

    [Header("Module")]
    [SerializeField] private AuthorizationModule authorization;
    [SerializeField] private DataBase dataBase;
    public void OnRegistrationClick()
    {
        authorization.CreateUser(emailInput.text, passwordInput.text, OnUserCreated, OnFailed);
        viewSwitch.Switch(waitVerificationView);
    }
    public void GoToLogin()
    {
        viewSwitch.Switch(loginView);
    }
    private void OnUserCreated()
    {
        dataBase.CreateUser(nameInput.text);
        viewSwitch.Switch(surveyNotificationView);
    }
    private void OnFailed(AuthError error)
    {
        switch (error)
        {
            case AuthError.EmailAlreadyInUse:
                errorRegistration.ShowError("Почта уже используется");
                break;
            case AuthError.InvalidEmail:
                errorRegistration.ShowError("Данной почты не существует");
                break;
            default:
                errorRegistration.ShowError("Неизвестная ошибка попробуйте позже");
                break;
        }
    }

}
