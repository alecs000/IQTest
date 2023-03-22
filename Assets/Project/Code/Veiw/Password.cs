using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Password : MonoBehaviour
{
    [SerializeField] private TMP_InputField passwordText;
    [SerializeField] private CanvasGroup hide;
    [SerializeField] private CanvasGroup show;
    private bool _isPasswordShowed;

    public void ShowPassword()
    {
        _isPasswordShowed = !_isPasswordShowed;
        if (_isPasswordShowed)
        {
            passwordText.contentType = TMP_InputField.ContentType.Standard;
            CanvasSetter.TurnOnCanvasGroup(hide);
            CanvasSetter.TurnOffCanvasGroup(show);
        }
        else
        {
            passwordText.contentType = TMP_InputField.ContentType.Password;
            CanvasSetter.TurnOnCanvasGroup(show);
            CanvasSetter.TurnOffCanvasGroup(hide);
        }

        passwordText.ForceLabelUpdate();
    }
}
