using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;

public class ErrorRegistration : MonoBehaviour
{
    [SerializeField] private CanvasGroup errorPanel;
    [SerializeField] private TMP_Text errorText;
    private bool _isErrorActiveButNotShow;
    private bool _isPanelActive;
    private string _errorMessage;
    public void ShowError(string error)
    {
        _errorMessage = error;
        _isErrorActiveButNotShow = true;
    }
    private void Update()
    {
        if (_isErrorActiveButNotShow)
        {
            CanvasSetter.TurnOnCanvasGroup(errorPanel);
            errorText.text = _errorMessage;
            _isPanelActive = true;
            _isErrorActiveButNotShow = false;
        }
        if (_isPanelActive && Input.touchCount>0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                CanvasSetter.TurnOffCanvasGroup(errorPanel);
                _isPanelActive = false;
            }
        }
    }
}
