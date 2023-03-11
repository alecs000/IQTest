using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AuthorizationTester : MonoBehaviour
{
    [Header("View")]
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TMP_InputField emailInput;
    [SerializeField] private TMP_InputField passwordInput;

    [Header("Module")]
    [SerializeField] private AuthorizationModule authorization;
    [SerializeField] private DataBase dataBase;

    void Start()
    {
        authorization.CreateUser("Alec@gmail.com", "fdhbdsfgsdftg3w31rFf", null);
    }

}
