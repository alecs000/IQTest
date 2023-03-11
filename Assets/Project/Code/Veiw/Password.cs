using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Password : MonoBehaviour
{
    [SerializeField] private TMP_InputField passwordText;
    [SerializeField] private TMP_Text hide;
    [SerializeField] private TMP_Text show;
    private bool _isPasswordShowed;
    public void ShowPassword()
    {
        _isPasswordShowed = !_isPasswordShowed;
        if (_isPasswordShowed)
        {
            passwordText.contentType = TMP_InputField.ContentType.Standard;
        }
        else
        {
            passwordText.contentType = TMP_InputField.ContentType.Password;
        }

        passwordText.ForceLabelUpdate();
        hide.gameObject.SetActive(_isPasswordShowed);
        show.gameObject.SetActive(!_isPasswordShowed);
    }
}
