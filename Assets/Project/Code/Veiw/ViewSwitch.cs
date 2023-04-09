using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ViewSwitch : MonoBehaviour, IObservable<UnityAction<int>>
{
    private event UnityAction<int> CurrentCanvasSwitched;

    [SerializeField] private CanvasGroup startCanvasGroup;
    [SerializeField] private float duration = 0.5f;

    private CanvasSetter _canvasSetter; 
    private void Awake()
    {
        _canvasSetter = new(startCanvasGroup, duration);
    }
    public void Switch(UIView view)
    {
        _canvasSetter.SetCanvasGroup(view.CanvasGroupUIView);
        view.Initialize();
        CurrentCanvasSwitched?.Invoke(view.IndexForSaveCurrentState);
    }
    public void AddObserver(UnityAction<int> @delegate)
    {
        CurrentCanvasSwitched += @delegate;
    }

    public void RemoveObserver(UnityAction<int> @delegate)
    {
        CurrentCanvasSwitched -= @delegate;

    }
}
