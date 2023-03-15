using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSwitch : MonoBehaviour
{
    [SerializeField] private CanvasGroup startCanvasGroup;
    [SerializeField] private float duration = 0.5f;

    private CanvasSetter _canvasSetter; 
    private void Start()
    {
        _canvasSetter = new(startCanvasGroup, duration);
    }
    private void Switch(CanvasGroup canvasGroup)
    {
        _canvasSetter.SetCanvasGroup(canvasGroup);
    }
}
