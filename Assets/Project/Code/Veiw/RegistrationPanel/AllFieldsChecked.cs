using UnityEngine;
using UnityEngine.UI;

public class AllFieldsChecked : MonoBehaviour
{
    [SerializeField] private Button registrationButton;
    private bool _isAgreeWithTheDataProcessing;
    private bool _isCorrectPasswordStyle;
    private bool _isNameWritten;
    private bool _isEmailWritten;
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
        if (!_isAgreeWithTheDataProcessing || !_isCorrectPasswordStyle||!_isNameWritten || !_isEmailWritten)
        {
            registrationButton.interactable = false;
            return;
        }
        registrationButton.interactable = true;
    }
    public void OnEmailChanged(string email)
    {
        foreach (var item in email)
        {
            if (item =='@')
            {
                _isEmailWritten = true;
                TryToAstivateRegistrationButton();
                return;
            }
        }
        _isEmailWritten = false;
        TryToAstivateRegistrationButton();
    }
    public void OnNameChanged(string name)
    {
        _isNameWritten = name.Length > 0;
        TryToAstivateRegistrationButton();
    }
    public void OnPasswordChanged(string password)
    {
        _isCorrectPasswordStyle = password.Length>=5;
        TryToAstivateRegistrationButton();
    }
}
