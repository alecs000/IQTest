using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthorizationTester : MonoBehaviour
{
    [SerializeField] private Authorization authorization;
    void Start()
    {
        authorization.SignIn("Alec@gmail.com", "fdhbdsfgsdftg3w31rFf");
    }

}
