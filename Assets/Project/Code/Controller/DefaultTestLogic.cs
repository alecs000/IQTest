using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DefaultTestLogic<T> : BankDefault where T : ScriptableObject
{
    [SerializeField] protected T[] questions;
    protected int _curentQuestionIndex;
    public T CurentQuestion => questions[_curentQuestionIndex];
    public int CurentQuestionIndex => _curentQuestionIndex;
    public int LastQuestionIndex => questions.Length - 1;
    public virtual T InitializeFirstQuestion()
    {
        _curentQuestionIndex = 0;
        return CurentQuestion;
    }
    public virtual T SwitchQuestionToNext()
    {
        _curentQuestionIndex++;
        return CurentQuestion;
    }
    public virtual T SwitchQuestionToPrevious()
    {
        _curentQuestionIndex--;
        return CurentQuestion;
    }
}
