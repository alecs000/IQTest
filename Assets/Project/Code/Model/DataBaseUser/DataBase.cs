using Firebase.Database;
using System;
using System.Collections;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    private const string Users = "users";
    [SerializeField] private AuthorizationModule authorization;
    private string _userID;
    private DatabaseReference _referenceDataBase;
    private User _currentUser;
    void Start()
    {
        _referenceDataBase = FirebaseDatabase.GetInstance("https://courceprojectiq-default-rtdb.asia-southeast1.firebasedatabase.app/").RootReference;
    }
    public void RefreshUserData(string answer, UserInformation userInformation)
    {
        switch (userInformation)
        {
            case UserInformation.FieldOfKnowledge:
                _currentUser.FieldOfKnowledge = answer;
                break;
            case UserInformation.FamilyStatus:
                _currentUser.FamilyStatus = answer;
                break;
            case UserInformation.HealthStatus:
                _currentUser.HealthStatus = answer;
                break;
            case UserInformation.MaritalStatus:
                _currentUser.MaritalStatus = answer;
                break;
            case UserInformation.TypeOfPerception:
                _currentUser.TypeOfPerception = answer;
                break;
            case UserInformation.SpiritualStatus:
                _currentUser.SpiritualStatus = answer;
                break;
        }
        AddData();
    }
    public void CreateUser(string username)
    {
        _userID = authorization.User.UserId;
        _currentUser = new User(username);
        string json = JsonUtility.ToJson(_currentUser);
        _referenceDataBase.Child(Users).Child(_userID).SetRawJsonValueAsync(json);
    }
    public void AddData()
    {
        string json = JsonUtility.ToJson(_currentUser);

        _referenceDataBase.Child("users").Child(_userID).SetRawJsonValueAsync(json);
    }
    public IEnumerator Get(string parameter, Action<string> onValueReceived)
    {
        var userData = _referenceDataBase.Child(Users).Child(_userID).Child(parameter).GetValueAsync();
        yield return new WaitUntil(() => userData.IsCompleted);
        if (userData != null)
        {
            onValueReceived?.Invoke((string)userData.Result.Value);
        }
    }
}
