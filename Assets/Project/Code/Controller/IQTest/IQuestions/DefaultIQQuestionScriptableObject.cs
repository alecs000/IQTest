using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class DefaultIQQuestionScriptableObject : ScriptableObject
{
    [TextArea()]
    [SerializeField] private string question;
    [SerializeField] private string rightAnswer;
    public string Question => question;
    public string RightAnswer => rightAnswer;

}
