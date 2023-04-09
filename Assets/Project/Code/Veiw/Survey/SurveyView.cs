using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SurveyView : UIView
{
    [SerializeField] private TMP_Text questionText;
    [SerializeField] private CustomToggle[] toggles;
    [SerializeField] private SurveyExecutor surveyExecutor;
    [SerializeField] private CanvasGroup nextButton;
    [SerializeField] private CanvasGroup finishButton;

    private SurveyChoiseLogic _surveyChoiseLogic;
    private void Start()
    {
        Initialize();
    }
    public override void Initialize()
    {
        _surveyChoiseLogic = new(toggles);
        SurveyQuestionScriptableObject question = surveyExecutor.InitializeFirstQuestion();
        UpdateText(question);
    }
    public void PreviousQuestion()
    {
        if (surveyExecutor.CurentQuestionIndex<1)
            return;
        SurveyQuestionScriptableObject question = surveyExecutor.SwitchQuestionToPrevious();
        CanvasSetter.TurnOnCanvasGroup(nextButton);
        CanvasSetter.TurnOffCanvasGroup(finishButton);
        _surveyChoiseLogic.RefreshToggle();
        UpdateText(question);
    }
    public void NextQuestion()
    {
        if (_surveyChoiseLogic.CurrentToggle == null)
            return;
        surveyExecutor.SendDataInDataBase(_surveyChoiseLogic.CurrentToggle.Lable.text);
        SurveyQuestionScriptableObject question = surveyExecutor.SwitchQuestionToNext();
        TryLastQuestionButtonActivate();
        _surveyChoiseLogic.RefreshToggle();
        UpdateText(question);
    }
    private void TryLastQuestionButtonActivate()
    {
        if (surveyExecutor.LastQuestionIndex == surveyExecutor.CurentQuestionIndex)
        {
            CanvasSetter.TurnOffCanvasGroup(nextButton);
            CanvasSetter.TurnOnCanvasGroup(finishButton);
        }
    }
    public void OnSurveyFinidhed()
    {
        surveyExecutor.SendDataInDataBase(_surveyChoiseLogic.CurrentToggle.Lable.text);
    }
    private void UpdateText(SurveyQuestionScriptableObject question)
    {
        questionText.text = question.Question;
        for (int i = 0; i < toggles.Length; i++)
        {
            if (i< question.Answers.Length)
            {
                toggles[i].gameObject.SetActive(true);
                toggles[i].Lable.text = question.Answers[i];
            }
            else
            {
                toggles[i].gameObject.SetActive(false);
            }
        }
    }
}
