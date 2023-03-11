using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsentToProcessing : MonoBehaviour
{
    [SerializeField] private Button registrationButton;
    public void Onchecked(bool check)
    {
        registrationButton.interactable = check;
    }
}
