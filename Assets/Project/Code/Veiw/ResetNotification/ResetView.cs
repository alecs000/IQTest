using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetView : UIView
{
    [SerializeField] private UIView loginView;
    [SerializeField] private ViewSwitch viewSwitch;
    public override void Initialize()
    {
        
    }
    public void GoToLogin()
    {
        viewSwitch.Switch(loginView);
    }
}
