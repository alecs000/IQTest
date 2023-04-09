using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurveyExecutor : DefaultTestLogic<SurveyQuestionScriptableObject>
{
    private const string SurveyText = "Survey";
    [SerializeField] private DataBase dataBase;
    public override SurveyQuestionScriptableObject InitializeFirstQuestion()
    {
        SurveyQuestionScriptableObject curentQuestion = base.InitializeFirstQuestion();
        if (PlayerPrefs.HasKey(SurveyText))
        {
            _curentQuestionIndex = PlayerPrefs.GetInt(SurveyText);
        }
        return curentQuestion;
    }
    public void SendDataInDataBase(string answerInSurvey)
    {
        if (answerInSurvey == null || answerInSurvey == string.Empty)
        {
            throw new Exception("Answer can`t be null or empty");
        }
        dataBase.RefreshUserData(answerInSurvey, CurentQuestion.AnswersInformation);
    }
    public override SurveyQuestionScriptableObject SwitchQuestionToNext()
    {
        SurveyQuestionScriptableObject curentQuestion = base.SwitchQuestionToNext();
        PlayerPrefs.SetInt(SurveyText, _curentQuestionIndex);
        return curentQuestion;
    }
}
