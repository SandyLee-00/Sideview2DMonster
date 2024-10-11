using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        FirebaseAuthManager.Instance.Init();
        FirebaseAuthManager.Instance.LoginState += OnLoginStateChanged;

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

        DataManager.Instance.ServerDataSystem.CreateUser();
    }

    private void Login()
    {
        FirebaseAuthManager.Instance.Login(EmailInputField.text, PasswordInputField.text);

        SceneManager.LoadScene("MainScene");
        DataManager.Instance.ServerDataSystem.LoadUserData();
    }

    private void Logout()
    {
        FirebaseAuthManager.Instance.Logout();
    }

}
