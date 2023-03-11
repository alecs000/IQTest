using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    public string Username;
    public string FieldOfKnowledge;

    public User()
    {
    }

    public User(string username, string fieldOfKnowledge ="")
    {
        this.Username = username;
        this.FieldOfKnowledge = fieldOfKnowledge;
    }
}
