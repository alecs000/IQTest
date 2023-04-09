using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class LoginView : UIView
{
    [SerializeField] private CanvasGroup error;
    [SerializeField] private UIView registration;
    [SerializeField] private UIView profile;
    [SerializeField] private UIView reset;
    [SerializeField] private ViewSwitch viewSwitch;
    public override void Initialize()
    {
    }
    public void GoToRegistration()
    {
        viewSwitch.Switch(registration);
    }
    public void GoToProfile()
    {
        viewSwitch.Switch(profile);
    }
    public void GoToReset()
    {
        viewSwitch.Switch(reset);
    }
    public void ShowError()
    {
        CanvasSetter.TurnOnCanvasGroup(error);
    }
}
