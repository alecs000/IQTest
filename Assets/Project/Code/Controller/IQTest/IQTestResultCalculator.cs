using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IQTestResultCalculator
{
    private List<bool> results = new List<bool>();

    public IQTestResultCalculator(List<bool> results)
    {
        this.results = results;
    }

    public float CalculateWithBarelyRandom(float offence = 3)
    {
        float IQAmount = 0;
        int rightAnswerAmount = 0;
        foreach (var item in results)
        {
            if (item)
            {
                rightAnswerAmount++;
            }
        }
        IQAmount = CalculateIQForFiveOrLessRightAnswers(rightAnswerAmount);
        if (IQAmount > 0)
            return IQAmount + Random.Range(-offence, offence);

        IQAmount = CalculateForAverageRightAnswersAmount(rightAnswerAmount);
        if (IQAmount > 0)
            return IQAmount + Random.Range(-offence, offence);

        IQAmount = CalculateForAtLeastThirtyThreeRightAnswers(rightAnswerAmount);
        if (IQAmount > 0)
            return IQAmount + Random.Range(-offence, offence);

        throw new System.Exception($"Ќеверное колличесво правленых ответов: {rightAnswerAmount}");
    }
    private float CalculateIQForFiveOrLessRightAnswers(int rightAnswerAmount)
    {
        float IQAmount = 0;
        switch (rightAnswerAmount)
        {
            case 0:
                IQAmount = 39;
                break;
            case 1:
                IQAmount = 48;
                break;
            case 2:
                IQAmount = 63;
                break;
            case 3:
                IQAmount = 71;
                break;
            case 4:
                IQAmount = 79;
                break;
            case 5:
                IQAmount = 85;
                break;
        }
        return IQAmount;
    }
    private float CalculateForAverageRightAnswersAmount(int rightAnswerAmount)
    {
        bool IQAmountWithoutRange = rightAnswerAmount < 6 || rightAnswerAmount > 32;
        if (IQAmountWithoutRange)
        {
            return 0;
        }
        int IQAmount = 90;
        float IQToAdd = (rightAnswerAmount - 6) * 2.5f;
        return IQAmount + IQToAdd;
    }
    private float CalculateForAtLeastThirtyThreeRightAnswers(int rightAnswerAmount)
    {
        float IQAmount = 150;
        switch (rightAnswerAmount)
        {
            case 33:
                IQAmount = 160;
                break;
            case 34:
                IQAmount = 180;
                break;
            case 35:
                IQAmount = 210;
                break;
            case 36:
                IQAmount = 270;
                break;
            case 37:
                IQAmount = 350;
                break;
            case 38:
                IQAmount = 490;
                break;
            case 39:
                IQAmount = 700;
                break;
            case 40:
                IQAmount = 999;
                break;
        }
        return IQAmount;
    }
}
