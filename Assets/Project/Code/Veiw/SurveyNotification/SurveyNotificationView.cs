using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurveyNotificationView : UIView
{
    [SerializeField] private UIView survey;
    [SerializeField] private UIView IQtest;
    [SerializeField] private ViewSwitch viewSwitch;
    public override void Initialize()
    {
    }
    public void OnStartClick()
    {
        viewSwitch.Switch(survey);
    }
    public void OnNoClick()
    {
        viewSwitch.Switch(IQtest);
    }
}
