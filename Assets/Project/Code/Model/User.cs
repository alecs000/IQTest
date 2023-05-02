using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    public string Username;
    public float IQAmount;
    public string FieldOfKnowledge;
    public string FamilyStatus;
    public string HealthStatus;
    public string MaritalStatus;
    public string TypeOfPerception;
    public string SpiritualStatus;

    public User()
    {
    }

    public User(string username, string fieldOfKnowledge ="")
    {
        this.Username = username;
    }
}
