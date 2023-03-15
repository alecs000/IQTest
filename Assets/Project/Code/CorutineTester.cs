using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorutineTester : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(SomeShit());
    }
    IEnumerator SomeShit()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("2132341234");
    }
}
