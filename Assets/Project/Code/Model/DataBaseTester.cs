using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseTester : MonoBehaviour
{
    [SerializeField] private DataBase dataBase;
    // Start is called before the first frame update
    public void Test()
    {
        dataBase.CreateUser("Alex");
    }
}
