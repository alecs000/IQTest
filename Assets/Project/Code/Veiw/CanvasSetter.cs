using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class CanvasSetter
{

    private CanvasGroup _curentCanvas;
    private float _durationForView;
    private static float _durationForSeparateUIElement;

    public CanvasSetter(CanvasGroup curentCanvas, float durationForView, float durationForSeparateUIElement = 0.3f)
    {
        SetCanvasGroup(curentCanvas);
        _durationForView = durationForView;
        _durationForSeparateUIElement = durationForSeparateUIElement;
    }

    public CanvasGroup CurentCanvas => _curentCanvas;

    public void SetCanvasGroup(CanvasGroup newGroup)
    {
        if (_curentCanvas != null)
        {
            _curentCanvas.alpha = 0;
            _curentCanvas.gameObject.SetActive(false);
        }
        _curentCanvas = newGroup;
        _curentCanvas.gameObject.SetActive(true);
        _curentCanvas.DOFade(1, _durationForView);
    }
    /// <summary>
    /// Use only with separate UI element.
    /// </summary>
    public static void TurnOffCanvasGroup(CanvasGroup group)
    {
        group.alpha = 0;
        group.gameObject.SetActive(false);
    }
    /// <summary>
    /// Use only with separate UI element
    /// </summary>
    public static void TurnOnCanvasGroup(CanvasGroup group)
    {
        group.gameObject.SetActive(true);
        group.DOFade(1, _durationForSeparateUIElement);
    }

}