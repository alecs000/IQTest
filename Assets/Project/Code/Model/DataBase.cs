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
    [SerializeField] private Authorization authorization;
    private string _userID;
    private DatabaseReference referenceDataBase;
    // Start is called before the first frame update
    void Start()
    {
        _userID = authorization.User.UserId;
        referenceDataBase = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void CreateUser(string username, string email, string fieldOfKnowledge)
    {
        User user = new User(username, email, fieldOfKnowledge);
        string json = JsonUtility.ToJson(user);
        referenceDataBase.Child(Users).Child(_userID).SetRawJsonValueAsync(json);
    }
    public IEnumerator Get(string parameter, Action<string> onValueReceived)
    {
        var userData = referenceDataBase.Child(Users).Child(_userID).Child(parameter).GetValueAsync();
        yield return new WaitUntil(() => userData.IsCompleted);
        if (userData!=null)
        { 
            onValueReceived?.Invoke((string)userData.Result.Value);
        }
    } 
}
