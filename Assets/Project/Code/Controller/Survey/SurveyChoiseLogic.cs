using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SurveyChoiseLogic
{
    private CustomToggle[] _toggles;
    private CustomToggle _currentToggle;
    public CustomToggle CurrentToggle => _currentToggle;
    public SurveyChoiseLogic(CustomToggle[] toggles)
    {
        _toggles = toggles;
        foreach (var item in _toggles)
        {
            item.AddObserver(OnToggleValueChange);
        }
    }
    public void RefreshToggle()
    {
        if (CurrentToggle!= null)
        {
            OnToggleValueChange(null, true);
        }
    }
    private void OnToggleValueChange(CustomToggle newToggle, bool value)
    {
        if (value)
        {
            if (_currentToggle!=null)
            {
                _currentToggle.Toggle.isOn = false;
                _currentToggle.Toggle.interactable = true;
            }
            _currentToggle = newToggle;
            if (newToggle == null)
            {
                return;
            }
            _currentToggle.Toggle.interactable = false;
        }
    }
}
