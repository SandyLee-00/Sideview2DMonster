using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using UnityEngine.UI;
using TMPro;
using Firebase.Extensions;

public class FirebaseAuthManager : MonoBehaviour
{
    private FirebaseAuth auth;
    private FirebaseUser user;

    public TMP_InputField EmailInputField;
    public TMP_InputField PasswordInputField;

    private void Awake()
    {
        auth = FirebaseAuth.DefaultInstance;
    }

    public void CreateAccount()
    {
        auth.CreateUserWithEmailAndPasswordAsync(EmailInputField.text, PasswordInputField.text).ContinueWith(task =>
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

    public void Login()
    {
        auth.SignInWithEmailAndPasswordAsync(EmailInputField.text, PasswordInputField.text).ContinueWith(task =>
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
