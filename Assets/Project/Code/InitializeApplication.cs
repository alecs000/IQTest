using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeApplication : MonoBehaviour
{
    private const string LAST_ACTIVE_VIEW = "LastActiveView";
    [SerializeField] private ViewSwitch viewSwitch;
    [SerializeField] private UIView[] uIViews;
    [SerializeField] private UIView surveyNotificatiomView;
    [SerializeField] private DataBase dataBase;
    [SerializeField] private AuthorizationModule authorization;

    private int _indexViewForSave;
    private void Awake()
    {
        authorization.OnAutomaticAuthorization +=() =>StartCoroutine(dataBase.AuthorizateUser(OnUserDataBaseAuthorizate));
    }
    private void Start()
    {
        viewSwitch.AddObserver(OnViewSwitched);
    }
    private void OnUserDataBaseAuthorizate()
    {
        if (!TryOpenLastView())
        {
            viewSwitch.Switch(surveyNotificatiomView);
        }
    }
    private bool TryOpenLastView()
    {
        Debug.Log("TryOpenLastView");
        if (PlayerPrefs.HasKey(LAST_ACTIVE_VIEW))
        {
            Debug.Log($"OpenLastView : {PlayerPrefs.GetInt(LAST_ACTIVE_VIEW)}");
            viewSwitch.Switch(uIViews[PlayerPrefs.GetInt(LAST_ACTIVE_VIEW)]);
            return true;
        }
        return false;
    }
    private void OnViewSwitched(int index)
    {
        _indexViewForSave = index;
        Debug.Log($"OpenLastView - {_indexViewForSave}");
        PlayerPrefs.SetInt(LAST_ACTIVE_VIEW, _indexViewForSave);
    }
    private void OnDestroy()
    {
        viewSwitch.RemoveObserver(OnViewSwitched);
    }
}
