using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OptionAnswerIQQuestionScriptableObject", menuName = "ScriptableObjects/OptionAnswerIQQuestionScriptableObject")]
public class OptionAnswerIQQuestionScriptableObject : DefaultIQQuestionScriptableObject
{
    [SerializeField] private string[] answersOption;
    public string[] AnswersOption => answersOption;

}
