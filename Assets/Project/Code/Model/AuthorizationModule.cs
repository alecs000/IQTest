using Firebase.Auth;
using System;
using UnityEngine;
using UnityEngine.Events;

public class AuthorizationModule : MonoBehaviour
{
    private FirebaseAuth _auth;
    private FirebaseUser _user;
    private string _displayName;
    private string _emailAddress;
    private Uri _photoUrl;

    public FirebaseUser User => _user;
    private void Awake()
    {
        InitializeFirebase();
    }
    private void InitializeFirebase()
    {
        _auth = FirebaseAuth.DefaultInstance;
        _auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    private void AuthStateChanged(object sender, EventArgs eventArgs)
    {
        if (_auth.CurrentUser != _user)
        {
            bool signedIn = _user != _auth.CurrentUser && _auth.CurrentUser != null;
            if (!signedIn && _user != null)
            {
                Debug.Log("Signed out " + _user.UserId);
            }
            _user = _auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + _user.UserId);
                _displayName = _user.DisplayName ?? "";
                _emailAddress = _user.Email ?? "";
                _photoUrl = _user.PhotoUrl ?? null;
            }
        }
    }

    private void OnDestroy()
    {
        _auth.StateChanged -= AuthStateChanged;
        _auth = null;
    }
    public void CreateUser(string email, string password, UnityAction onCreated)
    {
        _auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                if ("One or more errors occurred. (One or more errors occurred. (The given password is invalid.))"== task.Exception.Message)
                {
                    Debug.Log("ÍÅÂÅÐÍÛÉ ÏÀÐÎËÜ");
                }
                return;
            }

            // Firebase _user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            SignIn(email, password, onCreated);
            Debug.LogFormat("Firebase _user created successfully: {0} ({1})",
            newUser.DisplayName, newUser.UserId);
        });
    }
    public void SignIn(string email, string password, UnityAction onSignIn)
    {
        _auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            onSignIn?.Invoke();
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }
}
