using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaitEmailVerificationView : UIView
{
    [SerializeField] private TimerForRetry timerForRetry;
    [SerializeField] private AuthorizationModule authorizationModule;
    [SerializeField] private TMP_Text notificationText;
    [SerializeField] private UIView registrationView;
    [SerializeField] private ViewSwitch viewSwitch;
    public override void Initialize()
    {
        timerForRetry.StartTimer();
        notificationText.text = $"������� �� ����� {authorizationModule.User.Email}, � ���������� �� ������ � ������, ���� ������ �� ��������, �� ��������� ����� ����. ";
    }
    public void RetryEmail()
    {
        authorizationModule.SendEmail(null);
    }
    public void BackToRegistration()
    {
        viewSwitch.Switch(registrationView);
    }
}
