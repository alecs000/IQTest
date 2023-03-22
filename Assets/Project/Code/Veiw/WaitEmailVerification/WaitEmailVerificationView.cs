using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitEmailVerificationView : UIView
{
    [SerializeField] private TimerForRetry timerForRetry;
    [SerializeField] private AuthorizationModule authorizationModule;
    public override void Initialize()
    {
        timerForRetry.StartTimer();
    }
    public void RetryEmail()
    {
        authorizationModule.SendEmail(null);
    }
}
