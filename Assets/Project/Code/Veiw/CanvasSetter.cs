using DG.Tweening;
using UnityEngine;

public class CanvasSetter
{
    private CanvasGroup _curentCanvas;
    private float _duration;

    public CanvasSetter(CanvasGroup curentCanvas, float duration)
    {
        SetCanvasGroup(curentCanvas);
        _duration = duration;
    }

    public CanvasGroup CurentCanvas => _curentCanvas;

    public void SetCanvasGroup(CanvasGroup newGroup)
    {
        if (_curentCanvas != null)
        {
            _curentCanvas.alpha = 0;
            _curentCanvas.interactable = false;
            _curentCanvas.blocksRaycasts = false;
        }
        _curentCanvas = newGroup;
        _curentCanvas.DOFade(1, _duration);
        _curentCanvas.interactable = true;
        _curentCanvas.blocksRaycasts = true;
    }
    /// <summary>
    /// Use only with separate UI element.
    /// </summary>
    public static void TurnOffCanvasGroup(CanvasGroup group)
    {
        group.alpha = 0;
        group.interactable = false;
        group.blocksRaycasts = false;
    }
    /// <summary>
    /// Use only with separate UI element
    /// </summary>
    public static void TurnOnCanvasGroup(CanvasGroup group)
    {
        group.alpha = 1;
        group.interactable = true;
        group.blocksRaycasts = true;
    }
}