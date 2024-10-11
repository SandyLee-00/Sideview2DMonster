using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ServerDataSystem
{
    private string userId;
    private DatabaseReference databaseReference;

    public ServerUserData User;

    public void Init()
    {
        // TODO : 디바이스 말고 파이어베이스 로그인한 아이디로 변경
        userId = SystemInfo.deviceUniqueIdentifier;
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseDatabase.DefaultInstance.SetPersistenceEnabled(false);
    }

    public void CreateUser()
    {
        User = new ServerUserData(userId, 0);
        string json = JsonUtility.ToJson(User);
        databaseReference.Child("users").Child(userId).SetRawJsonValueAsync(json);
    }

    public void SaveUserData()
    {
        databaseReference.Child("users").Child(userId).Child("KillCount").SetValueAsync(User.KillCount);
    }

    public void LoadUserData()
    {
        databaseReference.Child("users").Child(userId).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if(task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                if(snapshot.Exists)
                {
                    User = JsonUtility.FromJson<ServerUserData>(snapshot.GetRawJsonValue());
                }
                else
                {
                    CreateUser();
                }
            }
            else
            {
                Debug.LogError("ServerDataSystem LoadUserData Error : " + task.Exception.Message);
            }
        });
    }
}