using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPopup_FirebaseLogin : MonoBehaviour
{
    public TMP_InputField EmailInputField;
    public TMP_InputField PasswordInputField;

    public TextMeshProUGUI LoginStateText;

    public Button CreateAccountButton;
    public Button LoginButton;
    public Button LogoutButton;

    public void Start()
    {
        // TODO : Init 전에 이벤트 등록? 확인해보기
        FirebaseAuthManager.Instance.LoginState += OnLoginStateChanged;
        FirebaseAuthManager.Instance.Init();

        CreateAccountButton.onClick.AddListener(CreateAccount);
        LoginButton.onClick.AddListener(Login);
        LogoutButton.onClick.AddListener(Logout);
    }

    private void OnLoginStateChanged(bool isLogin)
    {
        if (isLogin)
        {
            LoginStateText.text = "로그인 ";
            LoginStateText.text += FirebaseAuthManager.Instance.UserId;
        }
        else
        {
            LoginStateText.text = "로그아웃";
        }

    }

    private void CreateAccount()
    {
        FirebaseAuthManager.Instance.CreateAccount(EmailInputField.text, PasswordInputField.text);
    }

    private void Login()
    {
        FirebaseAuthManager.Instance.Login(EmailInputField.text, PasswordInputField.text);
    }

    private void Logout()
    {
        FirebaseAuthManager.Instance.Logout();
    }

}
