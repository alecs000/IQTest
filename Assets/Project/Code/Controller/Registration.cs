using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;

public class Registration : MonoBehaviour
{
    [Header("View")]
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TMP_InputField emailInput;
    [SerializeField] private TMP_InputField passwordInput;

    [Header("Module")]
    [SerializeField] private AuthorizationModule authorization;
    [SerializeField] private DataBase dataBase;
    public void OnRegistrationClick()
    {
        authorization.CreateUser(emailInput.text, passwordInput.text, OnUserCreated);
    }
    private void OnUserCreated()
    {
        dataBase.CreateUser(nameInput.text);
    }

}
