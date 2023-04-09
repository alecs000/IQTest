using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIView : MonoBehaviour
{
    public int IndexForSaveCurrentState;

    [SerializeField] private CanvasGroup _canvasGroupUIView;

    public CanvasGroup CanvasGroupUIView => _canvasGroupUIView;

    public abstract void Initialize();
}
