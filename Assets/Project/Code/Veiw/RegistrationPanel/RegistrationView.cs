using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegistrationView : UIView
{
    [SerializeField] private UIView waitVerificationView;
    [SerializeField] private UIView surveyNotificationView;
    [SerializeField] private UIView loginView;
    [SerializeField] private ViewSwitch viewSwitch;

    public override void Initialize()
    {
        
    }
    public void GoToLogin()
    {
        viewSwitch.Switch(loginView);
    }
    public void GoToWaitVerification()
    {
        viewSwitch.Switch(waitVerificationView);
    }
    public void GoToSurveyNotification()
    {
        viewSwitch.Switch(surveyNotificationView);
    }
}
