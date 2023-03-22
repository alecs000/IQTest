using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionScriptableObject", menuName = "ScriptableObjects/QuestionScriptableObject")]
public class QuestionScriptableObject : ScriptableObject
{
    [SerializeField] private string question;
    [SerializeField] private string[] answers;
    public string Question => question;
    public string[] Answers => answers;

}
