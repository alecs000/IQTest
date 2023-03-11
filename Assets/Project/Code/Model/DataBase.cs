using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    private const string Users = "users";
    [SerializeField] private AuthorizationModule authorization;
    private string _userID;
    private DatabaseReference _referenceDataBase;
    private User _currentUser;
    // Start is called before the first frame update
    void Start()
    {
        _userID = authorization.User.UserId;
        _referenceDataBase = FirebaseDatabase.GetInstance("https://courceprojectiq-default-rtdb.asia-southeast1.firebasedatabase.app/").RootReference;
    }

    public void CreateUser(string username)
    {
        User user = new User(username);
        string json = JsonUtility.ToJson(user);
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
        if (userData!=null)
        { 
            onValueReceived?.Invoke((string)userData.Result.Value);
        }
    } 
}
