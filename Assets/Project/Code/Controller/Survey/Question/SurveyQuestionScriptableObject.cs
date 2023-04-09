using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SurveyQuestionScriptableObject", menuName = "ScriptableObjects/SurveyQuestionScriptableObject")]
public class SurveyQuestionScriptableObject : ScriptableObject
{
    [SerializeField] private string question;
    [SerializeField] private string[] answers;
    [SerializeField] private UserInformation answersInformation;
    public string Question => question;
    public string[] Answers => answers;
    public UserInformation AnswersInformation => answersInformation;

}
