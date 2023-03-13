using UnityEngine;
using UnityEngine.UI;

public class AllFieldsChecked : MonoBehaviour
{
    [SerializeField] private Button registrationButton;
    private bool _isAgreeWithTheDataProcessing;
    private bool _isCorrectPasswordStyle;
    private void Start()
    {
    }
    public void Onchecked(bool check)
    {
        _isAgreeWithTheDataProcessing = check;
        TryToAstivateRegistrationButton();
    }
    public void TryToAstivateRegistrationButton()
    {
        if (!_isAgreeWithTheDataProcessing || !_isCorrectPasswordStyle)
        {
            registrationButton.interactable = false;
            return;
        }
        registrationButton.interactable = true;
    }
    public void OnPasswordChanged(string password)
    {
        _isCorrectPasswordStyle = password.Length>=5;
        TryToAstivateRegistrationButton();
    }
}
