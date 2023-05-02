using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IQTestView : UIView
{
    [SerializeField] private TMP_Text questionText;

    [Header("Option Question")]
    [SerializeField] private CustomToggle[] toggles;

    [Header("Picrure Question")]
    [SerializeField] private Image picture;

    [Header("String Question")]
    [SerializeField] private TMP_InputField inputField;

    [Header("Other Links")]
    [SerializeField] private IQTestExecutor testExecutor;
    [SerializeField] private CanvasGroup nextButton;
    [SerializeField] private CanvasGroup finishButton;
    [SerializeField] private UIView ResultView;
    [SerializeField] private ViewSwitch viewSwitch;

    private SurveyChoiseLogic _surveyChoiseLogic;
    private bool _isCurrentQuestionHaveStringAnswer;
    private void Awake()
    {
        _surveyChoiseLogic = new(toggles);
    }
    public override void Initialize()
    {
        DefaultIQQuestionScriptableObject question = testExecutor.InitializeFirstQuestion();
        ActivateQustion(question);
    }
    public void PreviousQuestion()
    {
        if (testExecutor.CurentQuestionIndex < 1)
            return;
        DefaultIQQuestionScriptableObject question = testExecutor.SwitchQuestionToPrevious();
        CanvasSetter.TurnOnCanvasGroup(nextButton);
        CanvasSetter.TurnOffCanvasGroup(finishButton);
        ActivateQustion(question);
    }
    public void NextQuestion()
    {
        SaveAnswerData();
        DefaultIQQuestionScriptableObject question = testExecutor.SwitchQuestionToNext();
        TryLastQuestionButtonActivate();
        _surveyChoiseLogic.RefreshToggle();
        ActivateQustion(question);
    }
    public void Reset()
    {
        testExecutor.Reset();
        CanvasSetter.TurnOffCanvasGroup(finishButton);
        CanvasSetter.TurnOnCanvasGroup(nextButton);
    }
    private void TryLastQuestionButtonActivate()
    {
        if (testExecutor.LastQuestionIndex == testExecutor.CurentQuestionIndex)
        {
            CanvasSetter.TurnOffCanvasGroup(nextButton);
            CanvasSetter.TurnOnCanvasGroup(finishButton);
        }
    }
    public void OnIQTestFinidhed()
    {
        SaveAnswerData();
        testExecutor.SendDataInDataBase();
        viewSwitch.Switch(ResultView);
    }
    private void SaveAnswerData()
    {
        if (_isCurrentQuestionHaveStringAnswer)
        {
            testExecutor.InsertTestData(inputField.text);
        }
        else
        {
            string answerNotNull = _surveyChoiseLogic.CurrentToggle != null ? _surveyChoiseLogic.CurrentToggle.Lable.text : "";
            testExecutor.InsertTestData(answerNotNull);
        }
    }
    private void ActivateQustion(DefaultIQQuestionScriptableObject question)
    {
        questionText.text = question.Question;
        if (question is OptionAnswerIQQuestionScriptableObject)
        {
            ActivateOptionAnswers(question as OptionAnswerIQQuestionScriptableObject);
            picture.gameObject.SetActive(false);
            inputField.gameObject.SetActive(false);
        }
        else if (question is PictureAndStringAnswerIQQuestionScriptableObject)
        {
            ActivatePictureAnswer(question as PictureAndStringAnswerIQQuestionScriptableObject);
            DeactivateOptionAnswers();

        }
        else if(question is StringAnswerIQQuestionScriptableObject)
        {
            ActivateStringAnswer(question as StringAnswerIQQuestionScriptableObject);
            DeactivateOptionAnswers();
            picture.gameObject.SetActive(false);
        }
        else
        {
            throw new Exception($"Такого вопроса не существует {question}");
        }
    }
    private void ActivateOptionAnswers(OptionAnswerIQQuestionScriptableObject question)
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            if (i < question.AnswersOption.Length)
            {
                toggles[i].gameObject.SetActive(true);
                toggles[i].Lable.text = question.AnswersOption[i];
            }
            else
            {
                toggles[i].gameObject.SetActive(false);
            }
        }
        if(_surveyChoiseLogic == null)
        {
            _surveyChoiseLogic = new(toggles);
        }
        _isCurrentQuestionHaveStringAnswer = false;
        _surveyChoiseLogic.RefreshToggle();
    }
    private void DeactivateOptionAnswers()
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            toggles[i].gameObject.SetActive(false);
        }
    }
    private void ActivatePictureAnswer(PictureAndStringAnswerIQQuestionScriptableObject question)
    {
        picture.gameObject.SetActive(true);
        picture.sprite = question.Picture;
        ActivateStringAnswer(question);
    }
    private void ActivateStringAnswer(StringAnswerIQQuestionScriptableObject question)
    {
        inputField.text = "";
        inputField.gameObject.SetActive(true);
        _isCurrentQuestionHaveStringAnswer = true;
    }
}
