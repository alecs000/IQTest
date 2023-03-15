using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class TimerForRetry : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private Button retryButton;
    [SerializeField] private TimeSpan timeBeforeRetry = new TimeSpan(0, 1, 0);

    private TimeSpan timeRemaning;

    private void StartTimer()
    {
        retryButton.interactable = false;
        timeRemaning = timeBeforeRetry;
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (timeRemaning>TimeSpan.Zero)
        {
            yield return new WaitForSeconds(1);
            timeRemaning -= new TimeSpan(0,0,1);
            timerText.text = timeRemaning.Minutes.ToString() +":"+ timeRemaning.Seconds.ToString();
        }
        Debug.Log("TIMER END");
    }
}
