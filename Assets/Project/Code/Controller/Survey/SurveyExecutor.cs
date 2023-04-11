using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurveyExecutor : DefaultTestLogic<SurveyQuestionScriptableObject>
{
    [SerializeField] private DataBase dataBase;
    public override SurveyQuestionScriptableObject InitializeFirstQuestion()
    {
        SurveyQuestionScriptableObject curentQuestion = base.InitializeFirstQuestion();
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
        return curentQuestion;
    }
}
