using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CustomToggle : MonoBehaviour, IObservable<UnityAction<CustomToggle, bool>>
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private Text lable;
    public Toggle Toggle => toggle;
    public Text Lable => lable;
    private UnityAction<CustomToggle, bool> toggleValueChange;
    public void OnToggleValueChange(bool value)
    {
        toggleValueChange?.Invoke(this, value);
    }
    public void AddObserver(UnityAction<CustomToggle, bool> @delegate)
    {
        toggleValueChange += @delegate;
    }

    public void RemoveObserver(UnityAction<CustomToggle, bool> @delegate)
    {
        toggleValueChange -= @delegate;
    }
}
