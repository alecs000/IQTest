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
        _surveyChoiseLogic = new(toggles);
        Initialize();
    }
    public override void Initialize()
    {
        QuestionScriptableObject question = surveyExecutor.InitializeFirstQuestion();
        UpdateText(question);
    }

    public void NextQuestion()
    {
        QuestionScriptableObject question = surveyExecutor.SwitchQuestionToNext(_surveyChoiseLogic.CurrentToggle.Lable.text);
        if (surveyExecutor.CurentQuestionIndex == surveyExecutor.CurentQuestionIndex)
        {
            nextButton.gameObject.SetActive(false);
            CanvasSetter.TurnOnCanvasGroup(finishButton);
        }
        UpdateText(question);
    }
    public void OnSurveyFinidhed()
    {

    }
    private void UpdateText(QuestionScriptableObject question)
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
