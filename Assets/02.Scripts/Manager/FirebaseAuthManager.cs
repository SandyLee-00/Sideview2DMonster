using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using UnityEngine.UI;
using TMPro;
using Firebase.Extensions;
using System;

public class FirebaseAuthManager : Singleton<FirebaseAuthManager>
{
    private FirebaseAuth auth;
    private FirebaseUser user;
    public string UserId => user.UserId;

    public Action<bool> LoginState;

    protected override void Awake()
    {
        _isDontDestroyOnLoad = true;
        base.Awake();
    }

    public void Init()
    {
        auth = FirebaseAuth.DefaultInstance;
        auth.StateChanged += OnAuthStateChanged;
    }

    private void OnAuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = (user != auth.CurrentUser && auth.CurrentUser != null);
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
                LoginState?.Invoke(false);
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + user.UserId);
                LoginState?.Invoke(true);
            }
        }
    }

    public void CreateAccount(string email, string passward)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, passward).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("FirebaseAuthManager::CreateAccount() 회원가입 취소");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("FirebaseAuthManager::CreateAccount() 회원가입 실패");
                return;
            }

            user = task.Result.User;
            Debug.Log("FirebaseAuthManager::CreateAccount() 회원가입 성공");
        });
    }

    public void Login(string email, string passward)
    {
        auth.SignInWithEmailAndPasswordAsync(email, passward).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("FirebaseAuthManager::Login() 로그인 취소");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("FirebaseAuthManager::Login() 로그인 실패");
                return;
            }

            user = task.Result.User;
            Debug.Log("FirebaseAuthManager::Login() 로그인 성공");
        });
    }

    public void Logout()
    {
        auth.SignOut();
        Debug.Log("FirebaseAuthManager::Logout() 로그아웃");
    }
}
