using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldsNotNull : MonoBehaviour
{
    [SerializeField] private Button loginButton;
    [SerializeField] private InputFieldWithoutNull[] inputFields;
    private Dictionary<InputFieldWithoutNull, bool> inputFieldsAndValues;
    private void Start()
    {
        inputFieldsAndValues = new();
        foreach (var item in inputFields)
        {
            inputFieldsAndValues.Add(item, false);
            item.AddObserver(OnFieldChanged);
        }
    }
    public void OnFieldChanged(InputFieldWithoutNull inputField, bool isNull)
    {
        inputFieldsAndValues[inputField] = isNull;
        TryActivateButton();
    }
    private void TryActivateButton()
    {
        bool isAllFieldsFulled = true;
        foreach (var item in inputFieldsAndValues)
        {
            if (!item.Value)
            {
                isAllFieldsFulled = false;
                break;
            }
        }
        if (isAllFieldsFulled)
            loginButton.interactable = true;
        else
            loginButton.interactable = false;
    }
}
