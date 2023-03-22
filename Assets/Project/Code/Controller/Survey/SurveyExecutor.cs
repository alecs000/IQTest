using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurveyExecutor : BankDefault
{
    [SerializeField] private QuestionScriptableObject[] questions;
    [SerializeField] private DataBase dataBase;
    private int _curentQuestionIndex;
    public QuestionScriptableObject CurentQuestion => questions[_curentQuestionIndex];
    public QuestionScriptableObject InitializeFirstQuestion()
    {
        _curentQuestionIndex = 0;
        return CurentQuestion;
    }
    public QuestionScriptableObject SwitchQuestionToNext(string answer)
    {
        if (answer == null|| answer==string.Empty)
        {
            throw new Exception("Answer can`t be null or empty");
        }
        dataBase.RefreshUserData(answer, CurentQuestion.AnswersInformation);
        _curentQuestionIndex++;
        return CurentQuestion;
    }
    public QuestionScriptableObject SwitchQuestionToPrevious()
    {
        _curentQuestionIndex--;
        return CurentQuestion;
    }
}
