using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIView : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroupUIView;
    public CanvasGroup CanvasGroupUIView => canvasGroupUIView;
    public abstract void Initialize();
}
