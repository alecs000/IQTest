using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    public string Username;
    public string Email;
    public string FieldOfKnowledge;

    public User()
    {
    }

    public User(string username, string email, string fieldOfKnowledge)
    {
        this.Username = username;
        this.Email = email;
        this.FieldOfKnowledge = fieldOfKnowledge;
    }
}
