using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PictureAndStringAnswerIQQuestionScriptableObject", menuName = "ScriptableObjects/PictureAndStringAnswerIQQuestionScriptableObject")]
public class PictureAndStringAnswerIQQuestionScriptableObject : StringAnswerIQQuestionScriptableObject
{
    [SerializeField] private Sprite picture;
    public Sprite Picture => picture;
}
