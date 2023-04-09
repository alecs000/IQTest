using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPasswordView : UIView
{
    [SerializeField] private UIView registration;
    [SerializeField] private UIView login;
    [SerializeField] private UIView resetSendedNotification;
    [SerializeField] private CanvasGroup error;
    [SerializeField] private ViewSwitch viewSwitch;

    public override void Initialize()
    {
        
    }
    public void GoToRegistration()
    {
        viewSwitch.Switch(registration);
    }
    public void GoToLogin()
    {
        viewSwitch.Switch(login);
    }
    public void GoToResetSendedNotification()
    {
        viewSwitch.Switch(resetSendedNotification);
    }
    public void ShowError()
    {
        CanvasSetter.TurnOnCanvasGroup(error);
    }
}
