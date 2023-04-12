using DG.Tweening;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultView : UIView
{
    [Header("Module")]
    [SerializeField] private DataBase data;
    [Header("Configurable values")]
    [SerializeField] private float duration;
    [SerializeField] private float maximumIQ = 160;
    [Header("Links")]
    [SerializeField] private TMP_Text iQAmountText;
    [SerializeField] private TMP_Text iQPercentText;
    [SerializeField] private Image circleBar;
    [SerializeField] private IQTestView IQTestView;
    [SerializeField] private UIView SurveyView;
    [SerializeField] private UIView SurveyNotificationView;
    [SerializeField] private ViewSwitch viewSwitch;

    private float _iqAmount;
    public override void Initialize()
    {
        if (data.CurrentUser == null)
        {
            viewSwitch.Switch(SurveyNotificationView);
            return;
        }
        _iqAmount = data.CurrentUser.IQAmount;
        PlayIQAmountAnimation();
        PlayPercentAnimation();
        PlayCircleAnimation();
    }
    public void GoToIQTest()
    {
        IQTestView.Reset();
        viewSwitch.Switch(IQTestView);
    }
    public void GoToSurvey()
    {
        viewSwitch.Switch(SurveyNotificationView);
    }
    private void PlayIQAmountAnimation()
    {
        float iQAmount = 0;
        DOTween.To(() => iQAmount, x => {
            iQAmount = x;
            iQAmountText.text = iQAmount.ToString()+ " IQ";
        }
        , _iqAmount, duration);
    }
    private void PlayPercentAnimation()
    {
        float iQInOnePercent = maximumIQ / 100;
        float iQPercentAmount = 0;
        DOTween.To(() => iQPercentAmount, x => {
            iQPercentAmount = x;
            iQPercentText.text = $"Лучше чем {iQPercentAmount}%";
        }
       , _iqAmount * iQInOnePercent, duration);
    }
    private void PlayCircleAnimation()
    {
        circleBar.fillAmount = 0;
        circleBar.DOFillAmount(1, duration);
    }
}
